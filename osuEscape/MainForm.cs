using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace osuEscape
{
    public partial class MainForm : Form
    {
        private bool isEditingHotkey = false;
        private readonly Root parent;
        private static readonly Dictionary<Keys, string> KeysToStringDictionary = new()
        {
            [Keys.A] = "A",
            [Keys.B] = "B",
            [Keys.C] = "C",
            [Keys.D] = "D",
            [Keys.E] = "E",
            [Keys.F] = "F",
            [Keys.G] = "G",
            [Keys.H] = "H",
            [Keys.I] = "I",
            [Keys.J] = "J",
            [Keys.K] = "K",
            [Keys.L] = "L",
            [Keys.M] = "M",
            [Keys.N] = "N",
            [Keys.O] = "O",
            [Keys.P] = "P",
            [Keys.Q] = "Q",
            [Keys.R] = "R",
            [Keys.S] = "S",
            [Keys.T] = "T",
            [Keys.U] = "U",
            [Keys.V] = "V",
            [Keys.W] = "W",
            [Keys.X] = "X",
            [Keys.Y] = "Y",
            [Keys.Z] = "Z",
            [Keys.D1] = "1",
            [Keys.D2] = "2",
            [Keys.D3] = "3",
            [Keys.D4] = "4",
            [Keys.D5] = "5",
            [Keys.D6] = "6",
            [Keys.D7] = "7",
            [Keys.D8] = "8",
            [Keys.D9] = "9",
            [Keys.D0] = "0",
            [Keys.F1] = "F1",
            [Keys.F2] = "F2",
            [Keys.F3] = "F3",
            [Keys.F4] = "F4",
            [Keys.F5] = "F5",
            [Keys.F6] = "F6",
            [Keys.F7] = "F7",
            [Keys.F8] = "F8",
            [Keys.F9] = "F9",
            [Keys.F10] = "F10",
            [Keys.F11] = "F11",
            [Keys.F12] = "F12",
            [Keys.OemMinus] = "-",
            [Keys.Oemplus] = "=",
            [Keys.OemOpenBrackets] = "[",
            [Keys.OemCloseBrackets] = "]",
            [Keys.OemPipe] = @"\",
            [Keys.OemSemicolon] = ";",
            [Keys.OemQuotes] = "'",
            [Keys.Oemtilde] = "`",
            [Keys.Oemcomma] = ",",
            [Keys.OemPeriod] = ".",
            [Keys.OemQuestion] = "/"
        };
        public MainForm(Root parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            materialSwitch_osuConnection.Checked = !Properties.Settings.Default.isAllowConnection;
            materialSlider_refreshRate.Value = Properties.Settings.Default.refreshRate;

            // get osu! directory from running process
            Properties.Settings.Default.osuLocation = Process.GetProcessesByName("osu!").Length == 0
                                                    ? Properties.Settings.Default.osuLocation
                                                    : Process.GetProcessesByName("osu!").FirstOrDefault().MainModule.FileName;

            // let user manually find the osu directory if it's still finding
            if (Properties.Settings.Default.osuLocation == string.Empty)
            {
                // if the app is first opened and there is no existing osu! process
                OpenFileDialog_FindOsuLocation();
            }
            else
            {
                //materialLabel_osuPath.Text = "osu! Path: " + Properties.Settings.Default.osuPath;
                materialLabel_osuPath.Text = Label_ShortenedPath();

                Firewall.RuleSetUp(Properties.Settings.Default.osuLocation);
            }

            TextBox_GlobalHotkey_Update();
        }

        public void materialSwitch_osuConnection_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isAllowConnection = !materialSwitch_osuConnection.Checked;
            Firewall.Toggle();
        }

        public void materialButton_findOsuLocation_Click(object sender, EventArgs e)
        {
            materialButton_findOsuLocation.UseAccentColor = true;
            OpenFileDialog_FindOsuLocation();
        }
        public void materialButton_changeToggleHotkey_Click(object sender, EventArgs e)
        {
            isEditingHotkey = !isEditingHotkey;

            if (isEditingHotkey)
            {
                materialButton_changeToggleHotkey.UseAccentColor = true;
                Properties.Settings.Default.GHKText = materialLabel_globalToggleHotkey.Text;
                materialLabel_globalToggleHotkey.Text = "Press Key(s) as Global Toggle Hotkey...";
            }
            else
            {
                // click again to cancel edit
                materialButton_changeToggleHotkey.UseAccentColor = false;
                materialLabel_globalToggleHotkey.Text = Properties.Settings.Default.GHKText;
            }
        }

        public void OpenFileDialog_FindOsuLocation()
        {
            OpenFileDialog ofd = new()
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
                Properties.Settings.Default.osuPath = String.Join("\\", ofd.FileName.Split('\\').Reverse().Skip(1).Reverse()) + "\\";

                materialLabel_osuPath.Text = Label_ShortenedPath();



                Firewall.RuleSetUp(Properties.Settings.Default.osuLocation);
            }
            else if (result == DialogResult.OK && !ofd.FileName.Contains("osu!.exe"))
            {
                // run again until user finds osu.exe or user cancelled the action
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
            materialSlider_refreshRate.Value = materialSlider_refreshRate.Value < 50
                                                ? 50
                                                : materialSlider_refreshRate.Value;
            Properties.Settings.Default.refreshRate = materialSlider_refreshRate.Value;
        }

        private void TextBox_GlobalHotkey_Update()
        {
            int modifierKeys = Properties.Settings.Default.ModifierKeys;
            bool isCtrl = false;
            bool isAlt = false;
            bool isShift = false;

            if (modifierKeys >= 4)
            {
                isShift = true;
                modifierKeys -= 4;
            }

            if (modifierKeys >= 2)
            {
                isCtrl = true;
                modifierKeys -= 2;
            }

            if (modifierKeys == 1)
            {
                isAlt = true;
            }

            materialLabel_globalToggleHotkey.Text = "Global Toggle Hotkey: ";
            materialLabel_globalToggleHotkey.Text += isCtrl ? "Ctrl + " : "";
            materialLabel_globalToggleHotkey.Text += isShift ? "Shift + " : "";
            materialLabel_globalToggleHotkey.Text += isAlt ? "Alt + " : "";
            materialLabel_globalToggleHotkey.Text += Properties.Settings.Default.GlobalHotKey;
        }

        #region Global HotKey

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (isEditingHotkey)
            {
                // cancel changes
                if (e.KeyCode == Keys.Escape)
                {
                    isEditingHotkey = false;
                    TextBox_GlobalHotkey_Update();
                }
                else if (KeysToStringDictionary.ContainsKey(e.KeyCode))
                {
                    isEditingHotkey = false;
                    parent.keyboardHook.Dispose();

                    // user settings
                    Properties.Settings.Default.ModifierKeys = 0;
                    Properties.Settings.Default.ModifierKeys += e.Alt ? 1 : 0;
                    Properties.Settings.Default.ModifierKeys += e.Control ? 2 : 0;
                    Properties.Settings.Default.ModifierKeys += e.Shift ? 4 : 0;
                    Properties.Settings.Default.GlobalHotKey = KeysToStringDictionary[e.KeyCode];

                    // ui
                    TextBox_GlobalHotkey_Update();

                    parent.keyboardHook.RegisterHotKey((ModifierKeys)Properties.Settings.Default.ModifierKeys,
                                        KeysToStringDictionary.FirstOrDefault(x => x.Value == Properties.Settings.Default.GlobalHotKey).Key);

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
                // to do
                shortPathStr = $"{Properties.Settings.Default.osuPath[..13]}...{Properties.Settings.Default.osuPath[^10..]}";
            }
            else if (pathArray.Length > 3)
            {
                List<string> pathList = new()
                {
                    pathArray[0],
                    pathArray[1],
                    pathArray[pathArray.Length - 1]
                };
                shortPathStr = string.Join("\\", pathList);
            }
            

            Debug.WriteLine(shortPathStr);

            return "osu! Path: " + shortPathStr;
        }
    }
}
