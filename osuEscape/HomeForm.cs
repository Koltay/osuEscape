using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OsuMemoryDataProvider;
using OsuMemoryDataProvider.OsuMemoryModels;
using OsuMemoryDataProvider.OsuMemoryModels.Direct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace osuEscape
{

    public partial class HomeForm : MaterialForm
    {

        private readonly string _osuWindowTitleHint;
        private int _readDelay = 33;
        private readonly StructuredOsuMemoryReader _sreader;
        private readonly CancellationTokenSource cts = new();

        private KeyHandler ghk;
        public const int WM_HOTKEY_MSG_ID = 0x0312;

        private bool isAllowConnection = true;

        private static readonly HttpClient client = new();

        private static int lastNoteOffset = -1;

        private static List<int> recentUploadScoreList = new();

        private Size FormSize_init;

        private Point labelSubmissionStatus_Location_init;

        private Point groupBoxMapStatus_Location_init;

        private Size button_Toggle_Size_init;

        readonly MaterialSkinManager materialSkinManager;

        //Startup registry key and value
        private static readonly string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private static readonly string StartupValue = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        public HomeForm(string osuWindowTitleHint)
        {
            _osuWindowTitleHint = osuWindowTitleHint;

            InitializeComponent();

            //Initialize material skin manager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme
                (Primary.Indigo500,
                Primary.Indigo700,
                Primary.Indigo100,
                Accent.LightBlue100,
                TextShade.WHITE);

            _sreader = StructuredOsuMemoryReader.Instance.GetInstanceForWindowTitleHint(osuWindowTitleHint);

            // check if osu!Escape is already opened
            if (Process.GetProcessesByName("osuEscape").Length > 1)
            {
                AppClosing();
            }


            // for ui resizing
            // editor pixels offset (50px)
            this.Size = new Size(this.Size.Width, this.Size.Height - 50);
            FormSize_init = this.Size;
            labelSubmissionStatus_Location_init = materialLabel_submissionStatus.Location;
            groupBoxMapStatus_Location_init = groupBox_mapStatus.Location;
            button_Toggle_Size_init = materialButton_toggle.Size;

            // change ui size according to user setting on isHideData
            HideData();

            SettingFormUpdate();
        }

        #region Initialize and OnLoad



        #region Structured Reader

        private T ReadProperty<T>(object readObj, string propName, T defaultValue = default) where T : struct
        {
            if (_sreader.TryReadProperty(readObj, propName, out var readResult))
                return (T)readResult;

            return defaultValue;
        }

        private T ReadClassProperty<T>(object readObj, string propName, T defaultValue = default) where T : class
        {
            if (_sreader.TryReadProperty(readObj, propName, out var readResult))
                return (T)readResult;

            return defaultValue;
        }

        private int ReadInt(object readObj, string propName)
            => ReadProperty<int>(readObj, propName, -5);
        private short ReadShort(object readObj, string propName)
            => ReadProperty<short>(readObj, propName, -5);

        private float ReadFloat(object readObj, string propName)
            => ReadProperty<float>(readObj, propName, -5f);

        private string ReadString(object readObj, string propName)
            => ReadClassProperty<string>(readObj, propName, "INVALID READ");


        #endregion


        private void SettingFormUpdate()
        {
            // UI Update with saved user settings
            materialCheckbox_runAtStartup.Checked = Properties.Settings.Default.isStartup;
            materialCheckbox_toggleWithSound.Checked = Properties.Settings.Default.isToggleSound;
            materialCheckbox_minimizeToSystemTray.Checked = Properties.Settings.Default.isSystemTray;
            materialCheckbox_topMost.Checked = Properties.Settings.Default.isTopMost;
            materialCheckbox_submitIfFC.Checked = Properties.Settings.Default.isSubmitIfFC;
            materialCheckbox_hideData.Checked = Properties.Settings.Default.isHideData;
            materialCheckbox_autoDisconnect.Checked = Properties.Settings.Default.isAutoDisconnect;

            materialTextBox_apiInput.Text = Properties.Settings.Default.userApiKey;
            materialMultiLineTextBox_submitAcc.Text = Properties.Settings.Default.submitAcc.ToString();

            materialSkinManager.Theme = (MaterialSkinManager.Themes)Properties.Settings.Default.Theme;
            materialButton_changeTheme.Text = (Properties.Settings.Default.Theme == 0 ? "Dark Mode" : "Light Mode");
        }

        private void OsuEscape_Load(object sender, EventArgs e)
        {
            // check if osu!Escape is already opened 
            if (Process.GetProcessesByName(this.Name).Length > 1)
                this.Close();

            osuDataReaderAsync();

            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

            // open the app at the previous location 
            this.Location = Properties.Settings.Default.appLocation;

            // getting osu! directory from running process
            string str = GetOsuPath();

            if (str != "")
            {
                Properties.Settings.Default.osuLocation = Process.GetProcessesByName("osu!").FirstOrDefault().MainModule.FileName;

                UpdateOsuLocationText();

                FirewallRuleSetUp(Properties.Settings.Default.osuLocation);
            }
            else
            {
                if (Properties.Settings.Default.osuLocation.Contains("osu!"))
                {
                    FirewallRuleSetUp(Properties.Settings.Default.osuLocation);
                }
                else
                {
                    // if there is no saved osu location at user settings,
                    // initialize this function to find osu! location
                    FindOsuLocation();
                }
            }

            ghk = new KeyHandler(Keys.F6, this);
            ghk.Register();
        }

        #endregion

        #region Main Functions

        #region osu data reader

        private async void osuDataReaderAsync()
        {
            if (!string.IsNullOrEmpty(_osuWindowTitleHint)) Text += $": {_osuWindowTitleHint}";
            Text += $" ({(Environment.Is64BitProcess ? "x64" : "x86")})";
            await Task.Run(async () =>
            {
                Stopwatch stopwatch;

                double readTimeMs;

                _sreader.WithTimes = true;

                var readUsingProperty = false;

                var baseAddresses = new OsuBaseAddresses();

                while (true)
                {
                    if (cts.IsCancellationRequested)
                        return;

                    if (!_sreader.CanRead)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            if (ReadInt(baseAddresses.GeneralData, nameof(GeneralData.RawStatus)) == -5)
                                materialMultiLineTextBox_status.Text = "NotRunning";
                        }));

                        await Task.Delay(_readDelay);

                        continue;
                    }

                    stopwatch = Stopwatch.StartNew();
                    if (readUsingProperty)
                    {
                        baseAddresses.Beatmap.Id = ReadInt(baseAddresses.Beatmap, nameof(CurrentBeatmap.Id));
                        baseAddresses.Beatmap.SetId = ReadInt(baseAddresses.Beatmap, nameof(CurrentBeatmap.SetId));
                        baseAddresses.Beatmap.MapString = ReadString(baseAddresses.Beatmap, nameof(CurrentBeatmap.MapString));
                        baseAddresses.Beatmap.FolderName = ReadString(baseAddresses.Beatmap, nameof(CurrentBeatmap.FolderName));
                        baseAddresses.Beatmap.OsuFileName = ReadString(baseAddresses.Beatmap, nameof(CurrentBeatmap.OsuFileName));
                        baseAddresses.Beatmap.Md5 = ReadString(baseAddresses.Beatmap, nameof(CurrentBeatmap.Md5));
                        baseAddresses.Beatmap.Ar = ReadFloat(baseAddresses.Beatmap, nameof(CurrentBeatmap.Ar));
                        baseAddresses.Beatmap.Cs = ReadFloat(baseAddresses.Beatmap, nameof(CurrentBeatmap.Cs));
                        baseAddresses.Beatmap.Hp = ReadFloat(baseAddresses.Beatmap, nameof(CurrentBeatmap.Hp));
                        baseAddresses.Beatmap.Od = ReadFloat(baseAddresses.Beatmap, nameof(CurrentBeatmap.Od));
                        baseAddresses.Beatmap.Status = ReadShort(baseAddresses.Beatmap, nameof(CurrentBeatmap.Status));
                        baseAddresses.Skin.Folder = ReadString(baseAddresses.Skin, nameof(Skin.Folder));
                        baseAddresses.GeneralData.RawStatus = ReadInt(baseAddresses.GeneralData, nameof(GeneralData.RawStatus));
                        baseAddresses.GeneralData.GameMode = ReadInt(baseAddresses.GeneralData, nameof(GeneralData.GameMode));
                        baseAddresses.GeneralData.Retries = ReadInt(baseAddresses.GeneralData, nameof(GeneralData.Retries));
                        baseAddresses.GeneralData.AudioTime = ReadInt(baseAddresses.GeneralData, nameof(GeneralData.AudioTime));
                        baseAddresses.GeneralData.Mods = ReadInt(baseAddresses.GeneralData, nameof(GeneralData.Mods));
                    }
                    else
                    {
                        _sreader.TryRead(baseAddresses.Beatmap);
                        _sreader.TryRead(baseAddresses.Skin);
                        _sreader.TryRead(baseAddresses.GeneralData);
                    }

                    if (baseAddresses.GeneralData.OsuStatus == OsuMemoryStatus.SongSelect)
                    {
                        _sreader.TryRead(baseAddresses.SongSelectionScores);

                        lastNoteOffset = -1;
                    }
                    else
                    {
                        baseAddresses.SongSelectionScores.Scores.Clear();
                    }


                    if (baseAddresses.GeneralData.OsuStatus == OsuMemoryStatus.ResultsScreen)
                    {
                        _sreader.TryRead(baseAddresses.ResultsScreen);


                        if (Properties.Settings.Default.isAutoDisconnect)
                        {
                            //upload if only it is not a replay
                            if (!baseAddresses.Player.IsReplay)
                            {
                                //upload if only the map is ranked or loved
                                if (baseAddresses.Beatmap.Status == ((short)BeatmapStatus.Ranked) || baseAddresses.Beatmap.Status == ((short)BeatmapStatus.Loved))
                                {
                                    if (baseAddresses.Player.MaxCombo != 0)
                                    {
                                        // Connection should be enabled because of meeting the requirement of submitting
                                        if (isAllowConnection)
                                        {
                                            materialLabel_submissionStatus.BeginInvoke((MethodInvoker)delegate
                                            {
                                                Label_SubmissionStatus_TextChanged("Ready to upload recent score.");
                                            });

                                            // delay the task for 1.5s to let the score submitted first
                                            await Task.Delay(1500);

                                            // GET Method of user's recent score (osu! api v1)
                                            // get the recent 3 scores, even though there is multiple submissions at one connection
                                            // the recent score could still be recognized
                                            recentUploadScoreList = await GetUserRecentScoreAsync(baseAddresses.Player.Username, 3);

                                            bool isUploaded = false;

                                            foreach (int responseScore in recentUploadScoreList)
                                            {
                                                // the score player recently submitted
                                                if (responseScore == baseAddresses.Player.Score)
                                                {
                                                    isUploaded = true;

                                                    isAllowConnection = true;

                                                    ToggleFirewall();
                                                    // to avoid toggling twice for same score submission
                                                }
                                            }

                                            materialLabel_submissionStatus.BeginInvoke((MethodInvoker)delegate
                                            {
                                                if (isUploaded)
                                                {
                                                    Label_SubmissionStatus_TextChanged("SUCCESS: Uploaded recent score.");
                                                }
                                                else
                                                {
                                                    Label_SubmissionStatus_TextChanged("FAILED: Did not upload recent score.");
                                                }
                                            });

                                            // 5s for displaying label message
                                            await Task.Delay(5000);

                                            Label_SubmissionStatus_TextChanged("");
                                        }
                                    }
                                }
                            }
                        }
                    }


                    if (baseAddresses.GeneralData.OsuStatus == OsuMemoryStatus.Playing)
                    {
                        _sreader.TryRead(baseAddresses.Player);
                        _sreader.TryRead(baseAddresses.LeaderBoard);
                        _sreader.TryRead(baseAddresses.KeyOverlay);

                        if (readUsingProperty)
                        {
                            //Testing reading of reference types(other than string)
                            _sreader.TryReadProperty(baseAddresses.Player, nameof(Player.Mods), out var dummyResult);
                        }

                        // only read the audio offset if it is not the previous beatmap
                        if (lastNoteOffset == -1)
                        {
                            string beatmapLocation = $"{Properties.Settings.Default.osuPath}\\Songs\\{baseAddresses.Beatmap.FolderName}\\{baseAddresses.Beatmap.OsuFileName}";

                            try
                            {
                                string lastLine = File.ReadLines(beatmapLocation).Last();

                                lastNoteOffset = Convert.ToInt32(lastLine.Split(',')[2]); // 0: x-coordinate, 1: y-coordinate, 2: audio offset
                            }
                            catch (Exception ex) // random exceptions happening
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        if (Properties.Settings.Default.isSubmitIfFC)
                        {
                            // using last note offset to determine if the map ended, after that we determine if it is an "FC"
                            if (baseAddresses.GeneralData.AudioTime >= lastNoteOffset)
                            {
                                if (baseAddresses.Player.Combo == baseAddresses.Player.MaxCombo) // This method ignores sliderbreak score
                                {
                                    if (baseAddresses.Player.HitMiss == 0) // full combo / dropped some sliderends
                                    {
                                        if (baseAddresses.Player.Accuracy >= Convert.ToInt32(materialMultiLineTextBox_submitAcc.Text)) // above or equal to the required acc
                                        {
                                            if (!isAllowConnection) // if there is block connection, disable it
                                            {
                                                ToggleFirewall();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        baseAddresses.LeaderBoard.Players.Clear();
                    }

                    var hitErrors = baseAddresses.Player?.HitErrors;
                    if (hitErrors != null)
                    {
                        var hitErrorsCount = hitErrors.Count;
                        hitErrors.Clear();
                        hitErrors.Add(hitErrorsCount);
                    }

                    stopwatch.Stop();
                    readTimeMs = stopwatch.ElapsedTicks / (double)TimeSpan.TicksPerMillisecond;

                    try
                    {
                        _ = Invoke((MethodInvoker)(() =>
                        {
                            //full data
                            //textBox_Data.Text = JsonConvert.SerializeObject(baseAddresses, Formatting.Indented); 

                            materialMultiLineTextBox_mapData.Text =
                                  $"Map: {baseAddresses.Beatmap.MapString}{Environment.NewLine}" +
                                  $"AR: {baseAddresses.Beatmap.Ar} CS: {baseAddresses.Beatmap.Cs} HP: {baseAddresses.Beatmap.Hp} OD: {baseAddresses.Beatmap.Od}{Environment.NewLine}" +
                                  $"Gamemode: {(Gamemode)baseAddresses.GeneralData.GameMode}{Environment.NewLine}" +
                                  $"Map Status: {(BeatmapStatus)baseAddresses.Beatmap.Status}{Environment.NewLine}" +
                                  $"Mods: {(Mods)baseAddresses.GeneralData.Mods}"
                                  ;

                            materialMultiLineTextBox_currentPlayingData.Text =
                                $"Player: {baseAddresses.Player.Username}{Environment.NewLine}" +
                                $"Score: {baseAddresses.Player.Score}{Environment.NewLine}" +
                                $"Player Recent Combo: {baseAddresses.Player.Combo}{Environment.NewLine}" +
                                $"Player Best Combo: {baseAddresses.Player.MaxCombo}{Environment.NewLine}" +
                                $"Accuracy: {baseAddresses.Player.Accuracy:0.00}{Environment.NewLine}" +
                                $"300: {baseAddresses.Player.Hit300} 100: {baseAddresses.Player.Hit100} 50: {baseAddresses.Player.Hit50} Miss: {baseAddresses.Player.HitMiss}"
                                ;

                            materialMultiLineTextBox_currentMapTime.Text = $"{baseAddresses.GeneralData.AudioTime}";
                            materialMultiLineTextBox_status.Text = $"{baseAddresses.GeneralData.OsuStatus}";


                        }));
                    }
                    catch (ObjectDisposedException)
                    {

                    }

                    _sreader.ReadTimes.Clear();
                    await Task.Delay(_readDelay);
                }
            }, cts.Token);
        }

        #endregion 

        #region ToggleConnection 

        private void ToggleFirewall()
        {
            // toggle the connection status
            isAllowConnection = !isAllowConnection;

            AllowConnection(isAllowConnection);

            ToggleSound(Properties.Settings.Default.isToggleSound);
        }

        private void AllowConnection(bool isAllow)
        {
            Process cmd = new();
            cmd.StartInfo.FileName = "netsh";
            cmd.StartInfo.Arguments =
                  @"advfirewall firewall set rule name=""osu block"" new enable=" + (isAllow ? "no" : "yes");
            cmd.StartInfo.Verb = "runas";
            cmd.StartInfo.UseShellExecute = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.Start();

            ToggleButtonUpdate(isAllow);

            ContextMenuStripUpdate();
        }


        private void ToggleButtonUpdate(bool isAllow)
        {
            if (materialButton_toggle.InvokeRequired)
            {
                materialButton_toggle.Invoke(new MethodInvoker(delegate
                {
                    materialButton_toggle.Text = isAllow ? "Connecting" : "Blocked";
                    materialButton_toggle.ForeColor = isAllow ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                }));
            }
            else
            {
                materialButton_toggle.Text = isAllow ? "Connecting" : "Blocked";
                materialButton_toggle.ForeColor = isAllow ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            }
        }

        private void FirewallRuleSetUp(string filename)
        {
            if (filename.Contains("osu!.exe"))
            {
                Properties.Settings.Default.osuLocation = filename;

                UpdateOsuLocationText();

                Process cmd = new();
                cmd.StartInfo.FileName = "netsh";
                cmd.StartInfo.Verb = "runas";
                cmd.StartInfo.UseShellExecute = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                // reset the rules if the users used this application before
                cmd.StartInfo.Arguments =
                    "advfirewall firewall delete rule name=\"osu block\"";
                cmd.Start();

                cmd.StartInfo.Arguments =
                    "advfirewall firewall add rule name=\"osu block\" dir=out action=block program=" + filename;
                cmd.Start();

                // Disable block rule at start to avoid unneeded disconnection
                isAllowConnection = false;
                ToggleFirewall();
            }
        }

        #endregion

        #endregion

        #region Find osu! location


        private void FindOsuLocation()
        {
            OpenFileDialog ofd = new()
            {
                Filter = "osu.exe |*.EXE"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.Contains("osu!.exe"))
                {
                    FirewallRuleSetUp(ofd.FileName);
                }
                else
                {
                    // run again until user finds osu.exe or user cancelled the action
                    FindOsuLocation();
                }
            }
        }

        private void UpdateOsuLocationText()
        {
            string osuPath = String.Join("\\", Properties.Settings.Default.osuLocation.Split('\\').Reverse().Skip(1).Reverse()) + "\\";

            Properties.Settings.Default.osuPath = osuPath;

            materialLabel_osuPath.Text = "osu! Path: " + osuPath;
        }

        private static string GetOsuPath()
        {
            return Process.GetProcessesByName("osu!").Length == 0 ? "" : Process.GetProcessesByName("osu!").FirstOrDefault().MainModule.FileName;
        }


        #endregion

        #region CheckBoxes

        #region Run at Startup
        public static void StartupSetUp(bool enabled)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
                if (enabled)
                    key.SetValue(StartupValue, Application.ExecutablePath.ToString());
                else
                    key.DeleteValue(StartupValue, false);
                key.Close();
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }
        }
        #endregion

        #region System Tray
        private void ToggleSystemTray(bool enabled)
        {
            notifyIcon_osuEscape.Visible = enabled;
            this.ShowInTaskbar = !enabled;
        }

        #endregion

        #region ContextMenuStrip
        private void ContextMenuStripUpdate()
        {
            notifyIcon_osuEscape.ContextMenuStrip = contextMenuStrip_osu;

            // status Update
            contextMenuStrip_osu.Items[0].Text = "Status: " + materialButton_toggle.Text;

            contextMenuStrip_osu.Items[1].Click += new EventHandler(Item_quit_Click);

            notifyIcon_osuEscape.Icon = (materialButton_toggle.Text == "Connecting" ? Properties.Resources.osuEscapeConnecting : Properties.Resources.osuEscapeBlocking);
        }
        private void Item_quit_Click(object sender, EventArgs e)
        {
            AppClosing();
        }

        #endregion



        private void materialCheckbox_autoDisconnect_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isAutoDisconnect = materialCheckbox_autoDisconnect.Checked;
        }

        private void materialCheckbox_submitIfFC_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isSubmitIfFC = materialCheckbox_submitIfFC.Checked;
        }

        private void materialCheckbox_hideData_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isHideData = materialCheckbox_hideData.Checked;
        }

        private void materialCheckbox_topMost_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTopMost = materialCheckbox_topMost.Checked;
            this.TopMost = materialCheckbox_topMost.Checked;
        }

        private void materialCheckbox_toggleWithSound_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isToggleSound = materialCheckbox_toggleWithSound.Checked;
        }

        private void materialCheckbox_minimizeToSystemTray_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isSystemTray = materialCheckbox_minimizeToSystemTray.Checked;
        }

        private void materialCheckbox_runAtStartup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isStartup = materialCheckbox_runAtStartup.Checked;

            StartupSetUp(materialCheckbox_runAtStartup.Checked);
        }

        #endregion

        #region Buttons

        private void materialButton_checkApi_Click(object sender, EventArgs e)
        {
            //***verify api not added
            Task.Run(async () =>
            {
                bool verified = await CheckAPIKeyAsync(materialTextBox_apiInput.Text);

                if (verified)
                {
                    Properties.Settings.Default.userApiKey = materialTextBox_apiInput.Text;
                    Properties.Settings.Default.isAPIKeyVerified = true;
                }
                else
                    Properties.Settings.Default.isAPIKeyVerified = false;

                MessageBox.Show(Properties.Settings.Default.isAPIKeyVerified.ToString());
                APIRequiredCheckBoxesEnabled();
            });
        }

        private void materialButton_findOsuLocation_Click(object sender, EventArgs e)
        {
            FindOsuLocation();
        }

        private void materialButton_changeTheme_Click(object sender, EventArgs e)
        {
            UIThemeToggle();
        }

        private void UIThemeToggle()
        {
            // light mode toggles to dark mode
            if (Properties.Settings.Default.Theme == 0)
            {
                materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
                Properties.Settings.Default.Theme = 1;

                materialButton_changeTheme.Text = "Light Mode";
            }
            else
            {
                materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
                Properties.Settings.Default.Theme = 0;

                materialButton_changeTheme.Text = "Dark Mode";
            }
        }
        private void materialButton_toggle_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.osuLocation == "")
            {
                ShowMessageBox("Invalid Location");
            }
            else
            {
                ToggleFirewall();
            }
        }


        #endregion

        #region FormClose
        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            // save the last position of the application
            if (this.WindowState != FormWindowState.Minimized)
                Properties.Settings.Default.appLocation = this.Location;

            Properties.Settings.Default.Save();
        }
        private void AppClosing()
        {
            cts.Cancel();
            cts.Dispose();
            this.Close();
        }

        #endregion

        #region Global HotKey
        private void HandleHotkey()
        {
            if (Properties.Settings.Default.osuLocation == "")
            {
                ShowMessageBox("ERROR: Invalid Location!");
            }
            else
            {
                ToggleFirewall();
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY_MSG_ID)
            {
                HandleHotkey();
            }
            base.WndProc(ref m);
        }

        private void GlobalHotkeyRegister()
        {

            if (ghk != null && ghk.Register() == true)
                ghk.Unregiser();

            ghk = new KeyHandler(Keys.F6, this);
            ghk.Register();
        }


        #endregion

        #region GET Method from osu! api   

        private static async Task<List<int>> GetUserRecentScoreAsync(string userName, int recentScoreLimits)
        {
            var url = $"https://osu.ppy.sh/api/get_user_recent?k={Properties.Settings.Default.userApiKey}&u={userName}&limit={recentScoreLimits}";


            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer");
            request.Content = new StringContent("{...}", Encoding.UTF8, "application/json");

            List<int> result = new();

            var response = await client.SendAsync(request, CancellationToken.None);

            if (response.IsSuccessStatusCode)
            {
                var JsonString = await response.Content.ReadAsStringAsync();

                JArray arr = (JArray)JsonConvert.DeserializeObject(JsonString);

                if (arr.Count == 0)
                    result.Add(0);
                else
                {
                    for (int i = 0; i < System.Math.Min(arr.Count, recentScoreLimits); i++)
                    {
                        result.Add((int)arr[i]["score"]);
                    }
                }
            }
            else
            {
                IncorrectAPITextOutput();
            }

            return result;
        }

        private static async Task<bool> CheckAPIKeyAsync(string textBoxAPIKey)
        {
            // verifying api key using one of the osu! api urls
            // we use get_beatmaps as it requires the least parameter
            // this url returns nothing but only success status
            // result should be []
            var url = $"https://osu.ppy.sh/api/get_beatmaps?k={textBoxAPIKey}&b=1&m=0&limit=1";


            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer");
            request.Content = new StringContent("{...}", Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request, CancellationToken.None);

            if (response.IsSuccessStatusCode)
            {
                // check if the response is successful, response content is not needed
                return true;
            }
            else
            {
                IncorrectAPITextOutput();
                return false;
            }
        }



        #endregion


        private void materialMultiLineTextBox_submitAcc_TextChanged(object sender, EventArgs e)
        {
            if (materialMultiLineTextBox_submitAcc.Text.Equals("")) { materialMultiLineTextBox_submitAcc.Text = "0"; }
            if (Convert.ToInt32(materialMultiLineTextBox_submitAcc.Text) > 100)
            {
                Properties.Settings.Default.submitAcc = 100;
                materialMultiLineTextBox_submitAcc.Text = "100";
            }
            // reset the accuracy to 100 to avoid unneeded submission
            if (Convert.ToInt32(materialMultiLineTextBox_submitAcc.Text) < 0)
            {
                Properties.Settings.Default.submitAcc = 100;
                materialMultiLineTextBox_submitAcc.Text = "100";
            }
        }

        private void Label_SubmissionStatus_TextChanged(string str)
        {
            materialLabel_submissionStatus.Text = "Submission Status: " + str;
        }

        private void materialSlider_refreshRate_Click(object sender, EventArgs e)
        {
            _readDelay = materialSlider_refreshRate.Value;

            if (materialSlider_refreshRate.Value < 33)
                _readDelay = 33;
        }
        private void materialTabControl_menu_Selected(object sender, TabControlEventArgs e)
        {
            if (materialTabControl_menu.SelectedTab == tabPage_main)
            {
                HideData();
            }
            else
            {
                // reset ui size with fixed min/max
                this.MaximumSize = FormSize_init;
                this.Size = FormSize_init;
                this.MinimumSize = FormSize_init;

                materialLabel_submissionStatus.Location = labelSubmissionStatus_Location_init;
                groupBox_mapStatus.Location = groupBoxMapStatus_Location_init;
                materialButton_toggle.Size = button_Toggle_Size_init;
                materialLabel_MapData.Visible = true;
                materialMultiLineTextBox_mapData.Visible = true;

                APIRequiredCheckBoxesEnabled();
            }
            //avoid button focus
            materialLabel_focus.Focus();
        }

        private void HideData()
        {
            if (Properties.Settings.Default.isHideData)
            {
                // hide data, smaller ui
                this.MinimumSize = new Size(500, 275);
                this.Size = this.MinimumSize;
                this.MaximumSize = this.Size;

                materialLabel_submissionStatus.Location = new Point(14, 140);
                groupBox_mapStatus.Location = new Point(330, 5);
                materialButton_toggle.Size = new Size(300, 120);
                materialLabel_MapData.Visible = false;
                materialMultiLineTextBox_mapData.Visible = false;
            }
        }

        private void HomeForm_Resize(object sender, EventArgs e)
        {
            if (materialCheckbox_minimizeToSystemTray.Checked && this.WindowState == FormWindowState.Minimized)
            {
                ToggleSystemTray(materialCheckbox_minimizeToSystemTray.Checked);
                ContextMenuStripUpdate();
            }

            GlobalHotkeyRegister();
        }

        private static void ShowMessageBox(string message)
        {
            ToggleSound(Properties.Settings.Default.isToggleSound);

            MessageBox.Show(message);
        }

        private static void ToggleSound(bool enabled)
        {
            if (enabled)
                System.Media.SystemSounds.Asterisk.Play();
        }

        private void notifyIcon_osuEscape_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            ToggleSystemTray(false);

            // Re-enable Hotkey
            GlobalHotkeyRegister();
        }

        private static void IncorrectAPITextOutput()
        {
            ShowMessageBox(
                    $"Internal server Error/ Incorrect API! {Environment.NewLine} " +
                    $"Please check if your API key is correct.")
                    ;
        }
        private void APIRequiredCheckBoxesEnabled()
        {
            if (materialCheckbox_autoDisconnect.InvokeRequired)
            {
                materialCheckbox_autoDisconnect.Invoke(new MethodInvoker(delegate
                {
                    materialCheckbox_autoDisconnect.Enabled = Properties.Settings.Default.isAPIKeyVerified;
                    if (!materialCheckbox_autoDisconnect.Enabled)
                        materialCheckbox_autoDisconnect.Checked = false;
                }));
            }
            else
            {
                materialCheckbox_autoDisconnect.Enabled = Properties.Settings.Default.isAPIKeyVerified;
                if (!materialCheckbox_autoDisconnect.Enabled)
                    materialCheckbox_autoDisconnect.Checked = false;
            }
        }
    }
}
