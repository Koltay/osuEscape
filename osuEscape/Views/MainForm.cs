using MaterialSkin.Controls;
using osuEscape.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osuEscape
{
    public partial class MainForm : Form
    {
        private bool _isEditingHotkey = false;
        private readonly Root _parent;
        private readonly KeyboardManager _keyboardManager;

        public MainForm(Root parent)
        {
            InitializeComponent();
            _parent = parent;

            _keyboardManager = new KeyboardManager();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!OperatingSystem.IsWindows())
                {
                    MessageBox.Show("This application is only supported on Windows.", "Unsupported OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                materialSwitch_osuConnection.Checked = !Properties.Settings.Default.isAllowConnection;
                materialSlider_refreshRate.Value = Properties.Settings.Default.refreshRate;

                using var osuProcess = Process.GetProcessesByName("osu!").FirstOrDefault();
                if (osuProcess != null)
                {
                    Properties.Settings.Default.osuLocation = osuProcess.MainModule.FileName;
                    Properties.Settings.Default.osuPath = Path.GetDirectoryName(osuProcess.MainModule.FileName) + Path.DirectorySeparatorChar;
                    Properties.Settings.Default.Save();
                }

                if (string.IsNullOrEmpty(Properties.Settings.Default.osuLocation))
                {
                    await OpenFileDialog_FindOsuLocationAsync();
                }
                else
                {
                    materialLabel_osuPath.Text = Label_ShortenedPath();
                    await Firewall.SetUpFirewallRulesAsync(Properties.Settings.Default.osuLocation);
                }

                TextBox_GlobalHotkey_Update();
            }
            catch (Exception ex)
            {
                MainFunction.ShowMessageBox(ex.Message);
            }
        }

        public async void materialSwitch_osuConnection_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.isAllowConnection = !materialSwitch_osuConnection.Checked;
                Properties.Settings.Default.Save();
                _parent.ContextMenuStripUpdate();
                FormStyleManager.ColorSchemeUpdate(_parent);
                FormStyleManager.Refresh();
                await Firewall.ToggleFirewallSettingsAsync();
            }
            catch (Exception ex)
            {
                MainFunction.ShowMessageBox(ex.Message);
            }
        }

        public async void materialButton_findOsuLocation_Click(object sender, EventArgs e)
        {
            materialButton_findOsuLocation.UseAccentColor = true;
            try
            {
                await OpenFileDialog_FindOsuLocationAsync();
            }
            catch (Exception ex)
            {
                MainFunction.ShowMessageBox(ex.Message);
            }
            finally
            {
                materialButton_findOsuLocation.UseAccentColor = false;
            }
        }

        public void materialButton_changeToggleHotkey_Click(object sender, EventArgs e)
        {
            _isEditingHotkey = !_isEditingHotkey;

            if (_isEditingHotkey)
            {
                materialButton_changeToggleHotkey.UseAccentColor = true;
                Properties.Settings.Default.GHKText = materialLabel_globalToggleHotkey.Text;
                materialLabel_globalToggleHotkey.Text = "Press Key(s) as Global Toggle Hotkey...";
            }
            else
            {
                // Click again to cancel edit
                materialButton_changeToggleHotkey.UseAccentColor = false;
                materialLabel_globalToggleHotkey.Text = Properties.Settings.Default.GHKText;
            }
        }

        private async Task OpenFileDialog_FindOsuLocationAsync()
        {
            using OpenFileDialog ofd = new()
            {
                Filter = "osu!.exe |*.EXE",
                InitialDirectory = ""
            };

            while (true)
            {
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.Cancel || result == DialogResult.Abort)
                {
                    return;
                }

                if (result == DialogResult.OK && string.Equals(Path.GetFileName(ofd.FileName), "osu!.exe", StringComparison.OrdinalIgnoreCase))
                {
                    Properties.Settings.Default.osuLocation = ofd.FileName;
                    Properties.Settings.Default.osuPath = Path.GetDirectoryName(ofd.FileName) + Path.DirectorySeparatorChar;
                    Properties.Settings.Default.Save();

                    materialLabel_osuPath.Text = Label_ShortenedPath();
                    await Firewall.SetUpFirewallRulesAsync(Properties.Settings.Default.osuLocation);
                    return;
                }

                MainFunction.ShowMessageBox("Please select osu!.exe.", "Invalid File", MessageBoxIcon.Warning);
            }
        }

        public void materialLabel_SubmissionStatus_TextChanged(string statusText)
        {
            materialLabel_submissionStatus.Text = "Submission Status: " + statusText;
        }

        private void materialSlider_refreshRate_onValueChanged(object sender, int newValue)
        {
            materialSlider_refreshRate.Value = Math.Max(materialSlider_refreshRate.Value, 50);
            Properties.Settings.Default.refreshRate = materialSlider_refreshRate.Value;
            Properties.Settings.Default.Save();
        }

        private void TextBox_GlobalHotkey_Update()
        {
            int modifierKeys = Properties.Settings.Default.ModifierKeys;
            bool isCtrl = (modifierKeys & 2) == 2;
            bool isAlt = (modifierKeys & 1) == 1;
            bool isShift = (modifierKeys & 4) == 4;

            materialLabel_globalToggleHotkey.Text = "Global Toggle Hotkey: ";
            materialLabel_globalToggleHotkey.Text += isCtrl ? "Ctrl + " : "";
            materialLabel_globalToggleHotkey.Text += isShift ? "Shift + " : "";
            materialLabel_globalToggleHotkey.Text += isAlt ? "Alt + " : "";
            materialLabel_globalToggleHotkey.Text += Properties.Settings.Default.GlobalHotKey;
        }

        #region Global HotKey

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_isEditingHotkey)
            {
                // Cancel changes
                if (e.KeyCode == Keys.Escape)
                {
                    _isEditingHotkey = false;
                    TextBox_GlobalHotkey_Update();
                }
                else if (_keyboardManager.KeysToStringDictionary.ContainsKey(e.KeyCode))
                {
                    _isEditingHotkey = false;

                    // User settings
                    Properties.Settings.Default.ModifierKeys = (e.Alt ? 1 : 0) + (e.Control ? 2 : 0) + (e.Shift ? 4 : 0);
                    Properties.Settings.Default.GlobalHotKey = _keyboardManager.KeysToStringDictionary[e.KeyCode];
                    Properties.Settings.Default.Save();

                    // UI
                    TextBox_GlobalHotkey_Update();

                    _parent.KeyboardHook.ClearHotKeys();
                    _parent.KeyboardHook.RegisterHotKey((ModifierKeys)Properties.Settings.Default.ModifierKeys,
                                        _keyboardManager.KeysToStringDictionary.FirstOrDefault(x => x.Value == Properties.Settings.Default.GlobalHotKey).Key);

                    System.Media.SystemSounds.Asterisk.Play();

                    materialButton_changeToggleHotkey.UseAccentColor = false;
                }
            }
        }

        #endregion

        private static string Label_ShortenedPath()
        {
            var shortPathStr = Properties.Settings.Default.osuPath;
            string[] pathArray = Properties.Settings.Default.osuPath.Split('\\');

            if (Properties.Settings.Default.osuPath.Length > 25)
            {
                shortPathStr = $"{Properties.Settings.Default.osuPath[..13]}...{Properties.Settings.Default.osuPath[^10..]}";
            }
            else if (pathArray.Length > 3)
            {
                List<string> pathList = new()
                {
                    pathArray[0],
                    pathArray[1],
                    pathArray[^1]
                };
                shortPathStr = string.Join("\\", pathList);
            }

            Debug.WriteLine(shortPathStr);

            return "osu! Path: " + shortPathStr;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _keyboardManager?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
