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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osuEscape
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private static HttpClient Client => Root.SharedHttpClient;

        // startup
        private static readonly string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
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

            // Set focus to a label
            materialLabel_focus.Focus();

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
            materialSwitch_isAutoDisconnect.Enabled = Properties.Settings.Default.isAPIKeyVerified;
            materialSwitch_isSnipeMode.Enabled = Properties.Settings.Default.isAPIKeyVerified;

            materialTextBox_apiInput.Text = Properties.Settings.Default.userApiKey;
            materialTextBox_userId.Text = Properties.Settings.Default.snipedUser;
            materialSlider_Accuracy.Value = Properties.Settings.Default.submitAcc;
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

        private void materialButton_checkApi_Click(object sender, EventArgs e)
        {
            _ = VerifyApiKeyAsync();
        }

        private void materialSlider_Accuracy_onValueChanged(object sender, int newValue)
        {
            Properties.Settings.Default.submitAcc = materialSlider_Accuracy.Value;
            Properties.Settings.Default.Save();
        }

        private async Task VerifyApiKeyAsync()
        {
            try
            {
                var url = $"https://osu.ppy.sh/api/get_beatmaps?k={materialTextBox_apiInput.Text}&b=100&m=0";

                using var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer");
                request.Content = new StringContent("{...}", Encoding.UTF8, "application/json");

                using var response = await Client.SendAsync(request, CancellationToken.None);

                Properties.Settings.Default.isAPIKeyVerified = response.IsSuccessStatusCode;
                materialSwitch_isAutoDisconnect.Enabled = response.IsSuccessStatusCode;
                materialSwitch_isSnipeMode.Enabled = response.IsSuccessStatusCode;

                if (response.IsSuccessStatusCode)
                {
                    Properties.Settings.Default.userApiKey = materialTextBox_apiInput.Text;
                }
                else
                {
                    Response_InvalidInput();
                    materialSwitch_isAutoDisconnect.Checked = false;
                    materialSwitch_isSnipeMode.Checked = false;
                }

                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MainFunction.ShowMessageBox(ex.Message);
            }
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
                    materialSwitch_isAutoDisconnect.Enabled = Properties.Settings.Default.isAPIKeyVerified;
                    if (!materialSwitch_isAutoDisconnect.Enabled)
                        materialSwitch_isAutoDisconnect.Checked = false;
                }));
            }
            else
            {
                materialSwitch_isAutoDisconnect.Enabled = Properties.Settings.Default.isAPIKeyVerified;
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
            _ = VerifyUsernameAsync();
        }

        private async Task VerifyUsernameAsync()
        {
            try
            {
                var url = $"https://osu.ppy.sh/api/get_user?k={materialTextBox_apiInput.Text}&u={materialTextBox_userId.Text}";

                using var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer");
                request.Content = new StringContent("{...}", Encoding.UTF8, "application/json");

                using var response = await Client.SendAsync(request, CancellationToken.None);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    JArray arr = (JArray)JsonConvert.DeserializeObject(jsonString);

                    foreach (var item in arr)
                    {
                        materialTextBox_userId.Text = item["username"]?.ToString();
                    }

                    Properties.Settings.Default.snipedUser = materialTextBox_userId.Text;
                    Properties.Settings.Default.Save();
                    MainFunction.ShowMessageBox($"Sniping User: {materialTextBox_userId.Text}", "Username Verification", MessageBoxIcon.Information);
                }
                else
                {
                    Response_InvalidInput();
                }
            }
            catch (Exception ex)
            {
                MainFunction.ShowMessageBox(ex.Message);
            }
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
                string switchName = mswitch.Name["materialSwitch_".Length..];
                Properties.Settings.Default[switchName] = mswitch.Checked;

                switch (switchName)
                {
                    case nameof(Properties.Settings.Default.isStartup):
                        StartupSetUp(mswitch.Checked);
                        break;
                    case nameof(Properties.Settings.Default.isTopMost):
                        if (Application.OpenForms["Root"] is Form rootForm)
                        {
                            rootForm.TopMost = mswitch.Checked;
                        }
                        break;
                    case nameof(Properties.Settings.Default.isSnipeMode):
                        materialButton_isSnipeMode.Enabled = mswitch.Checked;
                        break;
                }

                Properties.Settings.Default.Save();
            }
            else if (sender is MaterialCheckbox checkbox)
            {
                string checkBoxName = checkbox.Name["materialCheckbox_".Length..];
                Properties.Settings.Default[checkBoxName] = checkbox.Checked;
                Properties.Settings.Default.Save();
            }
        }
    }
}
