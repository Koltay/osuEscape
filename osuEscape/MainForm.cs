using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace osuEscape
{
    public partial class MainForm : Form
    {
        public static bool isEditingHotkey { get; set; } = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            materialSwitch_osuConnection.Checked = !Properties.Settings.Default.isAllowConnection;

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
                Firewall.RuleSetUp(Properties.Settings.Default.osuLocation);
            }
        }
        public void MaterialButton_changeToggleHotKey_Click(object sender, EventArgs e)
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
                materialButton_changeToggleHotkey.UseAccentColor = false;
                materialLabel_globalToggleHotkey.Text = Properties.Settings.Default.GHKText;
            }
        }
        public void materialSwitch_osuConnection_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isAllowConnection = !materialSwitch_osuConnection.Checked;
            ToggleFirewall();
        }

        private void ToggleFirewall()
        {
            if (Properties.Settings.Default.osuLocation == "")
            {
                MainFunction.ShowMessageBox("ERROR: Invalid Location!");
            }
            else
            {
                Firewall.AllowConnection(Properties.Settings.Default.isAllowConnection);

                Audio.ToggleSound(Properties.Settings.Default.isToggleSound);

                MainFunction.Invoke_FormRefresh();
            }
        }

        private void OpenFileDialog_FindOsuLocation()
        {
            OpenFileDialog ofd = new()
            {
                Filter = "osu!.exe |*.EXE"
            };

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Contains("osu!.exe"))
            {
                Properties.Settings.Default.osuLocation = ofd.FileName;

                Firewall.RuleSetUp(Properties.Settings.Default.osuLocation);
            }
            else if(ofd.ShowDialog() == DialogResult.OK)
            {
                // run again until user finds osu.exe or user cancelled the action
                OpenFileDialog_FindOsuLocation();
            }
            materialButton_findOsuLocation.UseAccentColor = false;
        }

        public void updateMaterialLabel_globalToggleHotkey(string text)
        {
            materialLabel_globalToggleHotkey.Text = text;
        }
    }
}
