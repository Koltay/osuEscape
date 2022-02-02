﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        // score upload
        private static readonly HttpClient client = new();
        private static int beatmapLastNoteOffset = Int32.MinValue;

        // startup
        private static readonly string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private static readonly string StartupValue = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // UI Update with saved user settings
            materialSwitch_runAtStartup.Checked = Properties.Settings.Default.isStartup;
            materialSwitch_toggleWithSound.Checked = Properties.Settings.Default.isToggleSound;
            materialSwitch_minimizeToSystemTray.Checked = Properties.Settings.Default.isSystemTray;
            materialSwitch_topMost.Checked = Properties.Settings.Default.isTopMost;
            materialSwitch_submitIfFC.Checked = Properties.Settings.Default.isSubmitIfFC;
            materialSwitch_autoDisconnect.Checked = Properties.Settings.Default.isAutoDisconnect;
            materialSwitch_autoDisconnect.Enabled = Properties.Settings.Default.isAPIKeyVerified;
            materialTextBox_apiInput.Text = Properties.Settings.Default.userApiKey;
            materialSlider_Accuracy.Value = Properties.Settings.Default.submitAcc;
            materialCheckbox_isFullCombo.Checked = Properties.Settings.Default.isCheckingFullCombo;
            /*materialSlider_refreshRate.Value = Properties.Settings.Default.refreshRate;*/
            materialSkinManager.Theme = (MaterialSkinManager.Themes)Properties.Settings.Default.Theme;

            materialSwitch_theme.Checked = Properties.Settings.Default.Theme == 1; // 1: enum value for Dark Theme
            /*materialSwitch_osuConnection.Checked = !Properties.Settings.Default.isAllowConnection;*/
            Firewall.ToggleFirewall();

            TextBox_GlobalHotkey_Update(); // use this to mainform_load
        }
        private void materialmaterialSwitch_runAtStartup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isStartup = materialSwitch_runAtStartup.Checked;

            StartupSetUp(materialSwitch_runAtStartup.Checked);
        }

        private void materialSwitch_toggleWithSound_CheckedChanged(object sender, EventArgs e)
        => Properties.Settings.Default.isToggleSound = materialSwitch_toggleWithSound.Checked;

        private void materialSwitch_minimizeToSystemTray_CheckedChanged(object sender, EventArgs e)
        => Properties.Settings.Default.isSystemTray = materialSwitch_minimizeToSystemTray.Checked;

        private void materialSwitch_autoDisconnect_CheckedChanged(object sender, EventArgs e) => Properties.Settings.Default.isAutoDisconnect = materialSwitch_autoDisconnect.Checked;

        private void materialSwitch_submitIfFC_CheckedChanged(object sender, EventArgs e)
        => Properties.Settings.Default.isSubmitIfFC = materialSwitch_submitIfFC.Checked;

        private void materialSwitch_topMost_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTopMost = materialSwitch_topMost.Checked;
            this.TopMost = materialSwitch_topMost.Checked;
        }

        private void materialButton_checkApi_Click(object sender, EventArgs e)
       => VerifyAPIKeyAsync();

        private void materialSwitch_theme_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Theme = materialSwitch_theme.Checked ? 1 : 0;
            materialSkinManager.Theme = (MaterialSkinManager.Themes)Properties.Settings.Default.Theme;
        }

        private void materialCheckbox_isFullCombo_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isCheckingFullCombo = materialCheckbox_isFullCombo.Checked;
        }

        private void materialSlider_Accuracy_onValueChanged(object sender, int newValue)
        {
            Properties.Settings.Default.submitAcc = materialSlider_Accuracy.Value;
        }

        private async void VerifyAPIKeyAsync()
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
            materialSwitch_autoDisconnect.Enabled = response.IsSuccessStatusCode;

            if (response.IsSuccessStatusCode)
            {
                // only success status code is needed
                // response content is not needed
                Properties.Settings.Default.userApiKey = materialTextBox_apiInput.Text;
            }
            else
            {
                IncorrectAPITextOutput();
                materialSwitch_autoDisconnect.Checked = false;
            }

            MainFunction.Invoke_FormRefresh();
        }

        private static void IncorrectAPITextOutput()
        {
            MainFunction.ShowMessageBox(
                    $"Internal server Error/ Incorrect API! {Environment.NewLine} " +
                    $"Please check if your API key is correct.")
                    ;
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

    }
}