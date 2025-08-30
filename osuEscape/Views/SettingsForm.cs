using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using osuEscape.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace osuEscape
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        // score upload
        private static readonly HttpClient client = new();

        // startup
        private static readonly string StartupKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private static readonly string StartupValue = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

        // material skin ui
        // should be placed in a new class
        public readonly MaterialSkinManager materialSkinManager;

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Initialize switches with saved settings
            InitializeSwitches();

            // Set API required checkboxes enabled state
            APIRequiredCheckBoxesEnabled();

            // Setup tooltips
            SetupTooltips();
        }

        private void InitializeSwitches()
        {
            materialSwitch_isStartup.Checked = Properties.Settings.Default.isStartup;
            materialSwitch_isToggleSound.Checked = Properties.Settings.Default.isToggleSound;
            materialSwitch_isSystemTray.Checked = Properties.Settings.Default.isSystemTray;
            materialSwitch_isTopMost.Checked = Properties.Settings.Default.isTopMost;
            materialSwitch_isSubmitIfFC.Checked = Properties.Settings.Default.isSubmitIfFC;
            materialSwitch_isAutoDisconnect.Checked = Properties.Settings.Default.isAutoDisconnect;
            materialSwitch_isAutoDisconnect.Enabled = Properties.Settings.Default.isOAuthVerified;
            materialSwitch_isSnipeMode.Enabled = Properties.Settings.Default.isOAuthVerified;
            materialSlider_accuracy.Value = Properties.Settings.Default.submitAcc;
            materialCheckbox_isCheckingFullCombo.Checked = Properties.Settings.Default.isCheckingFullCombo;
        }

        private void SetupTooltips()
        {
            toolTips.SetToolTip(materialSwitch_isAutoDisconnect, "Enabling this option will automatically disconnect after the recent score is submitted.");
            toolTips.SetToolTip(materialSwitch_isToggleSound, "Enabling this option will toggle firewall with system notification sound.");
            toolTips.SetToolTip(materialSwitch_isTopMost, "Enabling this option will overlap all the other application even if it is not focused.");
            toolTips.SetToolTip(materialSwitch_isStartup, "Enabling this option will allow osu!Escape to run automatically when the system is booted.");
            toolTips.SetToolTip(materialSwitch_isSystemTray, "Enabling this option will hide osu!Escape to taskbar when clicking the close button.");
            toolTips.SetToolTip(materialSwitch_isSubmitIfFC, "Enabling this option will automatically submit before jumping into result screen if the set score meets the requirement.");
        }

        async private void materialButton_OAuth_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Method called: materialButton_checkApi_Click");
            OsuApiClient api = new();
            var result = await api.TryLoginAsync();
            Debug.WriteLine("Login result: " + result);
            // update settings based on the result
            if (result == 1)
            {
                SetUIAvailability();
            }
        }

        private void materialSlider_Accuracy_onValueChanged(object sender, int newValue)
        {
            Properties.Settings.Default.submitAcc = materialSlider_accuracy.Value;
        }

        private void SetUIAvailability()
        {
            materialSwitch_isAutoDisconnect.Enabled = Properties.Settings.Default.isOAuthVerified;
            materialSwitch_isSnipeMode.Enabled = Properties.Settings.Default.isOAuthVerified;
        }

        private static void Response_InvalidInput()
        {
            MainFunction.ShowMessageBox(
                $"Internal server Error/ Incorrect API! {Environment.NewLine} " +
                $"Please check if your API key/ Sniping username is correct. {Environment.NewLine}"
            );
        }

        private void APIRequiredCheckBoxesEnabled()
        {
            if (materialSwitch_isAutoDisconnect.InvokeRequired)
            {
                materialSwitch_isAutoDisconnect.Invoke(new MethodInvoker(delegate
                {
                    materialSwitch_isAutoDisconnect.Enabled = Properties.Settings.Default.isOAuthVerified;
                    if (!materialSwitch_isAutoDisconnect.Enabled)
                        materialSwitch_isAutoDisconnect.Checked = false;
                }));
            }
            else
            {
                materialSwitch_isAutoDisconnect.Enabled = Properties.Settings.Default.isOAuthVerified;
                if (!materialSwitch_isAutoDisconnect.Enabled)
                    materialSwitch_isAutoDisconnect.Checked = false;
            }
        }

        public static void StartupSetUp(bool enabled)
        {
            try
            {
                using RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
                if (enabled)
                    key.SetValue(StartupValue, $"{Application.ExecutablePath}");
                else
                    key.DeleteValue(StartupValue, false);
            }
            catch (Exception ex)
            {
                MainFunction.ShowMessageBox(ex.Message);
            }
        }

        private void materialButton_isSnipeMode_Click(object sender, EventArgs e)
        {
            //Verify_Username_Async();
            Verify_Username_AsyncV2();
        }

        async private void Verify_Username_AsyncV2()
        {
            var userInfo = await OsuApiClient.GetUserInfoByUserNameAsync(materialTextBox_userId.Text);
            if (userInfo.TryGetProperty("error", out var error))
            {
                MainFunction.ShowMessageBox($"Internal server Error/ Incorrect Username! {Environment.NewLine} ");
                return;
            }

            int userId = userInfo.GetProperty("id").GetInt32();
            string username = userInfo.GetProperty("username").GetString() ?? "";
            Properties.Settings.Default.snipedUser = username;
            MainFunction.ShowMessageBox($"Sniping User: {username}", "Username Verification", MessageBoxIcon.Information);
        }
        private void materialSwitch_sniping_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isSnipeMode = materialSwitch_isSnipeMode.Checked;
            materialButton_isSnipeMode.Enabled = materialSwitch_isSnipeMode.Checked;
        }

        private void materialSwitch_grouped_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is MaterialSwitch mswitch)
            {
                // Handle MaterialSwitch changes
                string switchName = mswitch.Name[15..].Replace("_CheckedChanged", "");
                Properties.Settings.Default[switchName] = ((MaterialSwitch)Controls[$"materialSwitch_{switchName}"]).Checked;

                // Special case for some properties which need instant changes
                switch (switchName)
                {
                    case "isStartUp":
                        StartupSetUp(materialSwitch_isStartup.Checked);
                        break;
                    case "topMost":
                        this.TopMost = materialSwitch_isTopMost.Checked;
                        break;
                    case "isSnipeMode":
                        materialButton_isSnipeMode.Enabled = materialSwitch_isSnipeMode.Checked;
                        break;
                }
            }
            else if (sender is MaterialCheckbox checkbox)
            {
                // Handle MaterialCheckbox changes
                string checkBoxName = checkbox.Name[17..].Replace("_CheckedChanged", "");
                Properties.Settings.Default[checkBoxName] = ((MaterialCheckbox)Controls[$"materialCheckBox_{checkBoxName}"]).Checked;
            }
        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void materialSlider_accuracy_Click(object sender, EventArgs e)
        {

        }
    }
}
