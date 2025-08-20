using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using osuEscape.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace osuEscape
{
    public partial class MainForm : Form
    {
        private bool _isEditingHotkey = false;
        private readonly Root _parent;
        private readonly MainViewModel _viewModel;

        private readonly FormManager _formManager;
        private readonly KeyboardManager _keyboardManager;
        private readonly ScoreUploader _scoreUploader;
        private readonly StartupManager _startupManager;

        public MainForm(Root parent)
        {
            InitializeComponent();
            _parent = parent;

            _formManager = new FormManager();
            _keyboardManager = new KeyboardManager();
            _scoreUploader = new ScoreUploader();
            _startupManager = new StartupManager();
            
            // Bind a TextBox to a ViewModel property
            //textBox1.DataBindings.Add("Text", _viewModel, nameof(_viewModel.SomeProperty), false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            if (!OperatingSystem.IsWindows())
            {
                MessageBox.Show("This application is only supported on Windows.", "Unsupported OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            materialSwitch_osuConnection.Checked = !Properties.Settings.Default.isAllowConnection;
            materialSlider_refreshRate.Value = Properties.Settings.Default.refreshRate;

            // Get osu! directory from running process
            var osuProcess = Process.GetProcessesByName("osu!").FirstOrDefault();
            Properties.Settings.Default.osuLocation = osuProcess == null
                                                    ? Properties.Settings.Default.osuLocation
                                                    : osuProcess.MainModule.FileName;

            // Let user manually find the osu directory if it's still not found
            if (string.IsNullOrEmpty(Properties.Settings.Default.osuLocation))
            {
                OpenFileDialog_FindOsuLocation();
            }
            else
            {
                materialLabel_osuPath.Text = Label_ShortenedPath();
                await Firewall.SetUpFirewallRulesAsync(Properties.Settings.Default.osuLocation);
            }

            TextBox_GlobalHotkey_Update();
        }

        public async void materialSwitch_osuConnection_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isAllowConnection = !materialSwitch_osuConnection.Checked;
            await Firewall.SetUpFirewallRulesAsync(Properties.Settings.Default.osuLocation);
        }

        public void materialButton_findOsuLocation_Click(object sender, EventArgs e)
        {
            materialButton_findOsuLocation.UseAccentColor = true;
            OpenFileDialog_FindOsuLocation();
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

        public async void OpenFileDialog_FindOsuLocation()
        {
            using OpenFileDialog ofd = new()
            {
                Filter = "osu!.exe |*.EXE",
                InitialDirectory = ""
            };
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.Cancel || result == DialogResult.Abort)
            {
                materialButton_findOsuLocation.UseAccentColor = false;
                return;
            }
            if (result == DialogResult.OK && ofd.FileName.Contains("osu!.exe"))
            {
                Properties.Settings.Default.osuLocation = ofd.FileName;
                Properties.Settings.Default.osuPath = string.Join("\\", ofd.FileName.Split('\\').Reverse().Skip(1).Reverse()) + "\\";

                materialLabel_osuPath.Text = Label_ShortenedPath();
                await Firewall.SetUpFirewallRulesAsync(Properties.Settings.Default.osuLocation);
            }
            else if (result == DialogResult.OK && !ofd.FileName.Contains("osu!.exe"))
            {
                // Run again until user finds osu.exe or user cancels the action
                OpenFileDialog_FindOsuLocation();
            }
            materialButton_findOsuLocation.UseAccentColor = false;
        }

        public void materialLabel_SubmissionStatus_TextChanged(string str)
        {
            materialLabel_submissionStatus.Text = "Submission Status: " + str;
        }

        private void materialSlider_refreshRate_onValueChanged(object sender, int newValue)
        {
            materialSlider_refreshRate.Value = Math.Max(materialSlider_refreshRate.Value, 50);
            Properties.Settings.Default.refreshRate = materialSlider_refreshRate.Value;
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
                    _parent.KeyboardHook.Dispose();

                    // User settings
                    Properties.Settings.Default.ModifierKeys = (e.Alt ? 1 : 0) + (e.Control ? 2 : 0) + (e.Shift ? 4 : 0);
                    Properties.Settings.Default.GlobalHotKey = _keyboardManager.KeysToStringDictionary[e.KeyCode];

                    // UI
                    TextBox_GlobalHotkey_Update();

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
            _keyboardManager.KeyboardHook.Dispose();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _scoreUploader?.Dispose();
                _keyboardManager?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
