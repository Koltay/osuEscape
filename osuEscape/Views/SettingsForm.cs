using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private static readonly string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private static readonly string StartupValue = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

        // material skin ui
        // should be placed in a new class
        public readonly MaterialSkinManager materialSkinManager;

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // switches
            materialSwitch_isStartup.Checked = Properties.Settings.Default.isStartup;
            materialSwitch_isToggleSound.Checked = Properties.Settings.Default.isToggleSound;
            materialSwitch_isSystemTray.Checked = Properties.Settings.Default.isSystemTray;
            materialSwitch_isTopMost.Checked = Properties.Settings.Default.isTopMost;
            materialSwitch_isSubmitIfFC.Checked = Properties.Settings.Default.isSubmitIfFC;
            materialSwitch_isAutoDisconnect.Checked = Properties.Settings.Default.isAutoDisconnect;
            materialSwitch_isAutoDisconnect.Enabled = Properties.Settings.Default.isAPIKeyVerified;

            materialTextBox_apiInput.Text = Properties.Settings.Default.userApiKey;
            materialSlider_Accuracy.Value = Properties.Settings.Default.submitAcc;
            materialCheckbox_isCheckingFullCombo.Checked = Properties.Settings.Default.isCheckingFullCombo;

            APIRequiredCheckBoxesEnabled();

            materialLabel_focus.Focus();

            #region Tooltip setup

            toolTips.SetToolTip(materialSwitch_isAutoDisconnect, "Enabling this option will automatically disconnect after the recent score is submitted.");
            toolTips.SetToolTip(materialSwitch_isToggleSound, "Enabling this option will toggle firewall with system notification sound.");
            toolTips.SetToolTip(materialSwitch_isTopMost, "Enabling this option will overlap all the other application even if it is not focused.");
            toolTips.SetToolTip(materialSwitch_isStartup, "Enabling this option will allow osu!Escape to run automatically when the system is booted.");
            toolTips.SetToolTip(materialSwitch_isSystemTray, "Enabling this option will hide osu!Escape to taskbar when clicking the close button.");
            toolTips.SetToolTip(materialSwitch_isSubmitIfFC, "Enabling this option will automatically submit before jumping into result screen if the set score meets the requirement.");

            #endregion
        }

        /*
        private void materialmaterialSwitch_runAtStartup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isStartup = materialSwitch_isStartup.Checked;

            StartupSetUp(materialSwitch_isStartup.Checked);
        }

        private void materialSwitch_toggleWithSound_CheckedChanged(object sender, EventArgs e)
        => Properties.Settings.Default.isToggleSound = materialSwitch_isToggleSound.Checked;

        private void materialSwitch_minimizeToSystemTray_CheckedChanged(object sender, EventArgs e)
        => Properties.Settings.Default.isSystemTray = materialSwitch_isSystemTray.Checked;

        private void materialSwitch_autoDisconnect_CheckedChanged(object sender, EventArgs e) 
        => Properties.Settings.Default.isAutoDisconnect = materialSwitch_isAutoDisconnect.Checked;

        private void materialSwitch_submitIfFC_CheckedChanged(object sender, EventArgs e)
        => Properties.Settings.Default.isSubmitIfFC = materialSwitch_isSubmitIfFC.Checked;

        private void materialSwitch_topMost_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTopMost = materialSwitch_isTopMost.Checked;
            this.TopMost = materialSwitch_isTopMost.Checked;
        }
        private void materialCheckbox_isFullCombo_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isCheckingFullCombo = materialCheckbox_isCheckingFullCombo.Checked;
        }
        */

        private void materialButton_checkApi_Click(object sender, EventArgs e)
       => Verify_APIKey_Async();


        private void materialSlider_Accuracy_onValueChanged(object sender, int newValue)
        {
            Properties.Settings.Default.submitAcc = materialSlider_Accuracy.Value;
        }

        private async void Verify_APIKey_Async()
        {
            // verifying api key using one of the osu! api urls
            // using get_beatmaps as it requires the least parameter

            var url = $"https://osu.ppy.sh/api/get_beatmaps?k={materialTextBox_apiInput.Text}&b=100&m=0";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer");
            request.Content = new StringContent("{...}", Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request, CancellationToken.None);

            Properties.Settings.Default.isAPIKeyVerified = response.IsSuccessStatusCode;
            materialSwitch_isAutoDisconnect.Enabled = response.IsSuccessStatusCode;
            materialSwitch_isSnipeMode.Enabled = response.IsSuccessStatusCode;

            if (response.IsSuccessStatusCode)
            {
                // only success status code is needed
                // response content is not needed
                Properties.Settings.Default.userApiKey = materialTextBox_apiInput.Text;
            }
            else
            {
                Response_InvalidInput();
                materialSwitch_isAutoDisconnect.Checked = false;
                materialSwitch_isSnipeMode.Checked = false;
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
                RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
                if (enabled)
                    key.SetValue(StartupValue, $"{Application.ExecutablePath}");
                else
                    key.DeleteValue(StartupValue, false);
                key.Close();
            }
            catch (Exception ex)
            {
                MainFunction.ShowMessageBox(ex.Message);
            }
        }

        private void materialButton_isSnipeMode_Click(object sender, EventArgs e)
        {
            Verify_Username_Async();
        }

        private async void Verify_Username_Async()
        {
            // verifying api key using one of the osu! api urls
            // using get_beatmaps as it requires the least parameter

            // not specifying username or userid on purpose
            var url = $"https://osu.ppy.sh/api/get_user?k={materialTextBox_apiInput.Text}&u={materialTextBox_userId.Text}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer");
            request.Content = new StringContent("{...}", Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request, CancellationToken.None);

            if (response.IsSuccessStatusCode)
            {
                // only success status code is needed
                // response content is not needed

                var JsonString = await response.Content.ReadAsStringAsync();

                JArray arr = (JArray)JsonConvert.DeserializeObject(JsonString);

                foreach (var item in arr)
                {
                    //MessageBox.Show(item["username"].ToString());
                    //MessageBox.Show(item["user_id"].ToString());

                    materialTextBox_userId.Text = item["username"].ToString();
                }

                Properties.Settings.Default.userApiKey = materialTextBox_userId.Text;
                MainFunction.ShowMessageBox(
                    $"Sniping User: {materialTextBox_userId.Text}"
                    );
            }
            else
            {
                Response_InvalidInput();
            }
        }

        private void materialSwitch_sniping_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isSnipeMode = materialSwitch_isSnipeMode.Checked;

            // material button for verification
            materialButton_isSnipeMode.Enabled = materialSwitch_isSnipeMode.Checked;
        }

        private void materialSwitch_grouped_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is MaterialSwitch mswitch)
            {
                // materialSwitch_[...]_CheckedChanged
                string switchName = mswitch.Name[15..].Replace("_CheckedChanged", "");

                Properties.Settings.Default[switchName] = ((MaterialSwitch)Controls[$"materialSwitch_{switchName}"]).Checked;

                // special case for some properties which needs instant changes
                switch (switchName)
                {
                    case "isStartUp":
                        StartupSetUp(materialSwitch_isStartup.Checked);
                        break;
                    case "topMost":
                        this.TopMost = materialSwitch_isTopMost.Checked;
                        break;
                    case "isSnipeMode":
                        // button for username verification
                        materialButton_isSnipeMode.Enabled = materialSwitch_isSnipeMode.Checked;
                        break;
                    default:
                        break;
                }
            }
            else if (sender is MaterialCheckbox checkbox)
            {
                // materialCheckBox_[...]_CheckedChanged
                string checkBoxName = checkbox.Name[17..].Replace("_CheckedChanged", "");
                Properties.Settings.Default[checkBoxName] = ((MaterialCheckbox)Controls[$"materialCheckBox_{checkBoxName}"]).Checked;
            }
        }
    }
}
