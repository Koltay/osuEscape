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
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osuEscape
{
    public partial class osuEscape : Form
    {
        private readonly string _osuWindowTitleHint;
        private int _readDelay = 33;
        private readonly object _minMaxLock = new object();
        private double _memoryReadTimeMin = double.PositiveInfinity;
        private double _memoryReadTimeMax = double.NegativeInfinity;
        private readonly ISet<string> _patternsToSkip = new HashSet<string>();
        private readonly StructuredOsuMemoryReader _sreader;
        private CancellationTokenSource cts = new CancellationTokenSource();

        private KeyHandler ghk;
        public const int WM_HOTKEY_MSG_ID = 0x0312;

        public int resultsScreenScoreV2 = 0;

        private bool isAllowConnection = true;

        private static HttpClient client = new HttpClient();

        public int previousBeatmapId = 0;

        public int BeatmapMaxCombo = 0;

        public static List<int> recentUploadScoreList = new List<int>();

        private Size originalSize;

        public static string userName;

        #region Initialize and OnLoad
        public osuEscape(string osuWindowTitleHint)
        {

            _osuWindowTitleHint = osuWindowTitleHint;

            InitializeComponent();

            _sreader = StructuredOsuMemoryReader.Instance.GetInstanceForWindowTitleHint(osuWindowTitleHint);

            Shown += OnShown;
            Closing += OnClosing;
            numericUpDown_readDelay.ValueChanged += NumericUpDownReadDelayOnValueChanged;

            // check if osu!Escape is already opened

            if (Process.GetProcessesByName("osuEscape").Length > 1)
            {
                this.Close();
            }

            originalSize = this.Size;

            UIUserSettingsUpdate();
        }

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


        private void UIUserSettingsUpdate()
        {
            // UI Update with saved user settings
            checkBox_startUp.Checked = Properties.Settings.Default.isStartUp;
            checkBox_toggleSound.Checked = Properties.Settings.Default.isToggleSound;
            checkBox_systemTray.Checked = Properties.Settings.Default.isSystemTray;
            checkBox_topMost.Checked = Properties.Settings.Default.isTopMost;
            checkBox_submitIfFC.Checked = Properties.Settings.Default.isSubmitIfFC;
            checkBox_hideData.Checked = Properties.Settings.Default.isHideData;
            checkBox_autoDisconnect.Checked = Properties.Settings.Default.isAutoDisconnect;

            numericUpDown_readDelay.Value = Properties.Settings.Default.refreshRate;

            textBox_apiKey.Text = Properties.Settings.Default.userApiKey;
            textBox_submitAcc.Text = Properties.Settings.Default.submitAcc.ToString();
        }

        private void OsuEscape_Load(object sender, EventArgs e)
        {
            // check if osu!Escape is already opened 
            if (Process.GetProcessesByName("osuEscape").Length > 1)
                this.Close();

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

            // hide notifyIcon until user settings allows minimizing to system tray
            notifyIcon_osuEscape.Visible = false;
        }

        #endregion


        private void NumericUpDownReadDelayOnValueChanged(object sender, EventArgs eventArgs)
        {
            if (int.TryParse(numericUpDown_readDelay.Value.ToString(CultureInfo.InvariantCulture), out var value))
            {
                _readDelay = value;
            }
            else
            {
                numericUpDown_readDelay.Value = 33;
            }
        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            cts.Cancel();
        }

        private async void OnShown(object sender, EventArgs eventArgs)
        {
            if (!string.IsNullOrEmpty(_osuWindowTitleHint)) Text += $": {_osuWindowTitleHint}";
            Text += $" ({(Environment.Is64BitProcess ? "x64" : "x86")})";
            _sreader.InvalidRead += SreaderOnInvalidRead;
            await Task.Run(async () =>
            {
                Stopwatch stopwatch;

                double readTimeMs, readTimeMsMin, readTimeMsMax;

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
                            //textBox_Status.Text = "NotRunning";

                            var status = ReadInt(baseAddresses.GeneralData, nameof(GeneralData.RawStatus));

                            if (status == -5)
                                textBox_Status.Text = "NotRunning";
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
                    }
                    //else
                    //    baseAddresses.SongSelectionScores.Scores.Clear();

                    if (baseAddresses.GeneralData.OsuStatus == OsuMemoryStatus.ResultsScreen)
                    {
                        _sreader.TryRead(baseAddresses.ResultsScreen);

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
                                        label_submissionStatus.Invoke((MethodInvoker)delegate {
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

                                        label_submissionStatus.Invoke((MethodInvoker)delegate
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

                                        // 3s for displaying label message
                                        await Task.Delay(3000);
                                    }
                                }
                            }
                        }                      
                    }


                    if (baseAddresses.GeneralData.OsuStatus == OsuMemoryStatus.Playing)
                    {
                        baseAddresses.Player.MaxCombo = 0;
                        _sreader.TryRead(baseAddresses.Player);
                        //TODO: flag needed for single/multi player detection (should be read once per play in singleplayer)
                        _sreader.TryRead(baseAddresses.LeaderBoard);
                        _sreader.TryRead(baseAddresses.KeyOverlay);

                        if (readUsingProperty)
                        {
                            //Testing reading of reference types(other than string)
                            _sreader.TryReadProperty(baseAddresses.Player, nameof(Player.Mods), out var dummyResult);
                        }

                        if (textBox_apiKey.Text != null)
                        {
                            // First GET
                            if (BeatmapMaxCombo == 0)
                            {
                                BeatmapMaxCombo = await GetBeatmapIdAsync(baseAddresses.Beatmap.Id);
                            }
                            else if (previousBeatmapId != baseAddresses.Beatmap.Id) // loaded new beatmap
                            {
                                BeatmapMaxCombo = await GetBeatmapIdAsync(baseAddresses.Beatmap.Id);
                            }
                        }

                        //Submit if FC / SS
                        if (Properties.Settings.Default.isSubmitIfFC)
                        {
                            if (BeatmapMaxCombo != 0) // Already gets the max combo from osu! api
                            {
                                if (BeatmapMaxCombo == baseAddresses.Player.MaxCombo) // FC //if (baseAddresses.Player.MaxCombo == 1)//
                                {
                                    if (baseAddresses.Player.Accuracy >= Convert.ToInt32(textBox_submitAcc.Text)) // above or equal to the required acc
                                    {
                                        if (!isAllowConnection) // if there is block connection, disable it
                                        {
                                            ToggleFirewall();
                                        }
                                    }
                                }
                            }
                        }

                        userName = baseAddresses.Player.Username;
                        previousBeatmapId = baseAddresses.Beatmap.Id;
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
                    lock (_minMaxLock)
                    {
                        if (readTimeMs < _memoryReadTimeMin) _memoryReadTimeMin = readTimeMs;
                        if (readTimeMs > _memoryReadTimeMax) _memoryReadTimeMax = readTimeMs;
                        // copy value since we're inside lock
                        readTimeMsMin = _memoryReadTimeMin;
                        readTimeMsMax = _memoryReadTimeMax;
                    }

                    try
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            //full data
                            //textBox_Data.Text = JsonConvert.SerializeObject(baseAddresses, Formatting.Indented); 

                            textBox_mapData.Text =
                                $"Map: {baseAddresses.Beatmap.MapString}{Environment.NewLine}" +
                                $"AR: {baseAddresses.Beatmap.Ar} CS: {baseAddresses.Beatmap.Cs} HP: {baseAddresses.Beatmap.Hp} OD: {baseAddresses.Beatmap.Od}{Environment.NewLine}" +
                                $"Gamemode: {(Gamemode)baseAddresses.GeneralData.GameMode}{Environment.NewLine}" +
                                $"Map Status: {(BeatmapStatus)baseAddresses.Beatmap.Status}{Environment.NewLine}" +
                                $"Mods: {(Mods)baseAddresses.GeneralData.Mods}"
                                ;

                            textBox_currentPlayData.Text =
                                $"Player: {baseAddresses.Player.Username}{Environment.NewLine}" +
                                $"Score: {baseAddresses.Player.Score}{Environment.NewLine}" +
                                $"Your Best Combo: {baseAddresses.Player.MaxCombo}{Environment.NewLine}" +
                                $"Beatmap Max Combo: {BeatmapMaxCombo}{Environment.NewLine}" +
                                $"Accuracy: {baseAddresses.Player.Accuracy.ToString("0.00")}{Environment.NewLine}" +
                                $"300: {baseAddresses.Player.Hit300} 100: {baseAddresses.Player.Hit100} 50: {baseAddresses.Player.Hit50} Miss: {baseAddresses.Player.HitMiss}"
                                ;

                            textBox_currentMapTime.Text = $"{baseAddresses.GeneralData.AudioTime}";
                            textBox_Status.Text = $"{baseAddresses.GeneralData.OsuStatus}";


                        }));
                    }
                    catch (ObjectDisposedException)
                    {
                        return;
                    }

                    _sreader.ReadTimes.Clear();
                    await Task.Delay(_readDelay);
                }
            }, cts.Token);
        }

        private void SreaderOnInvalidRead(object sender, (object readObject, string propPath) e)
        {
            try
            {
                if (InvokeRequired)
                {
                    //Async call to not impact memory read times(too much)
                    BeginInvoke((MethodInvoker)(() => SreaderOnInvalidRead(sender, e)));
                    return;
                }

                // *not showing any invalid read recently

                //listBox_logs.Items.Add($"{DateTime.Now:T} Error reading {e.propPath}{Environment.NewLine}");
                //if (listBox_logs.Items.Count > 500)
                //    listBox_logs.Items.RemoveAt(0);

                //listBox_logs.SelectedIndex = listBox_logs.Items.Count - 1;
                //listBox_logs.ClearSelected();
            }
            catch (ObjectDisposedException)
            {

            }
        }

        private void Button_ResetReadTimeMinMax_Click(object sender, EventArgs e)
        {
            lock (_minMaxLock)
            {
                _memoryReadTimeMin = double.PositiveInfinity;
                _memoryReadTimeMax = double.NegativeInfinity;
            }
        }


        #region Panel Buttons
        private void Button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            if (checkBox_systemTray.Checked)
            {
                ToggleSystemTray(checkBox_systemTray.Checked);
                ContextMenuStripUpdate();
            }

            GlobalHotkeyRegister();
        }

        #endregion

        #region ToggleConnection 
        private void Button_toggle_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.osuLocation == "")
            {
                MessageBox.Show("Invalid Location");
            }
            else
            {
                ToggleFirewall();
            }
        }



        private void ToggleFirewall()
        {
            // toggle the connection status
            isAllowConnection = !isAllowConnection;

            AllowConnection(isAllowConnection);

            if (checkBox_toggleSound.Checked)
                System.Media.SystemSounds.Asterisk.Play();
        }


        private void AllowConnection(bool isAllow)
        {
            Process cmd = new Process();
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
            if (button_toggle.InvokeRequired)
            {
                button_toggle.Invoke(new MethodInvoker(delegate
                {
                    button_toggle.Text = isAllow ? "Connecting" : "Blocked";
                    button_toggle.ForeColor = isAllow ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                }));
            }
            else
            {
                button_toggle.Text = isAllow ? "Connecting" : "Blocked";
                button_toggle.ForeColor = isAllow ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            }
        }

        private void FirewallRuleSetUp(string filename)
        {
            if (filename.Contains("osu!.exe"))
            {
                Properties.Settings.Default.osuLocation = filename;

                UpdateOsuLocationText();

                Process cmd = new Process();
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

                // Disable block rule at start
                // To avoid unneeded disconnection
                isAllowConnection = false;
                ToggleFirewall();
            }
        }

        #endregion

        #region Find osu! location
        private void Button_findLocation_Click(object sender, EventArgs e) // select osu!.exe
        {
            FindOsuLocation();
        }

        private void FindOsuLocation()
        {
            OpenFileDialog ofd = new OpenFileDialog
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
            textBox_osuPath.Text = "osu! Path: " + String.Join("\\", Properties.Settings.Default.osuLocation.Split('\\').Reverse().Skip(1).Reverse()) + "\\";
        }

        private static string GetOsuPath()
        {
            return Process.GetProcessesByName("osu!").Length == 0 ? "" : Process.GetProcessesByName("osu!").FirstOrDefault().MainModule.FileName;
        }


        #endregion

        #region CheckBox Settings
        // Include:
        // - startup
        // - toggle with sound
        // - minimize to system tray
        // - top most
        // - submit if fc
        // - hide Data
        // - auto disconnect
        #region Run at Startup
        private void CheckBox_startUp_CheckedChanged(object sender, EventArgs e)
        {
            SetRunAtStartup(checkBox_startUp.Checked);

            Properties.Settings.Default.isStartUp = checkBox_startUp.Checked;
        }
        private static void SetRunAtStartup(bool enabled)
        {
            try
            {
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (enabled)
                    rk.SetValue("osu!Escape", "\"" + path + "\" --hide");
                else
                    rk.DeleteValue("osu!Escape", false);

                rk.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Toggle with Sound
        private void CheckBox_toggleSound_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isToggleSound = checkBox_toggleSound.Checked;
        }

        #endregion

        #region NotifyIcon, SystemTray, ContextMenuStrip
        private void NotifyIcon_osuEscape_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            ToggleSystemTray(false);

            // Re-enable Hotkey
            GlobalHotkeyRegister();
        }

        private void CheckBox_systemTray_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isSystemTray = checkBox_systemTray.Checked;
        }

        private void ToggleSystemTray(bool enabled)
        {
            notifyIcon_osuEscape.Visible = enabled;
            this.ShowInTaskbar = !enabled;
        }

        #region ContextMenuStrip
        private void ContextMenuStripUpdate()
        {
            notifyIcon_osuEscape.ContextMenuStrip = contextMenuStrip_osu;

            //Status Update
            contextMenuStrip_osu.Items[0].Text = "Status: " + button_toggle.Text;

            contextMenuStrip_osu.Items[1].Click += new EventHandler(Item_quit_Click);

            notifyIcon_osuEscape.Icon = (button_toggle.Text == "Connecting" ? Properties.Resources.osuEscapeConnecting : Properties.Resources.osuEscapeBlocking);
        }
        private void Item_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #endregion

        #region TopMost
        private void CheckBox_topMost_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTopMost = checkBox_topMost.Checked;
            this.TopMost = checkBox_topMost.Checked;
        }

        #endregion

        #region Submit If FC
        private void CheckBox_submitIfFC_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isSubmitIfFC = checkBox_submitIfFC.Checked;
        }

        #endregion

        #region Hide Data
        private void CheckBox_hideData_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isHideData = checkBox_hideData.Checked;

            if (checkBox_hideData.Checked)
            {
                // pause updating data 
                cts.Cancel();

                // hide data, smaller ui
                this.MinimumSize = new Size(426, 240);
                this.Size = this.MinimumSize;
                this.MaximumSize = this.Size;

                groupBox_hideData.Location = new Point(8, 120);
                groupBox_Data.Visible = false;
            }
            else
            {
                // reset cts and resume
                cts.Dispose();
                cts = new CancellationTokenSource();

                //RealTimeDataDisplayAsync();

                groupBox_Data.Visible = true;
                groupBox_hideData.Location = new Point(8, 374);

                // reset ui with fixed size
                this.MaximumSize = originalSize;
                this.Size = originalSize;
                this.MinimumSize = originalSize;
            }
        }
        #endregion

        #region Automatically disconnect after score uploading
        private void checkBox_autoDisconnect_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isAutoDisconnect = checkBox_autoDisconnect.Checked;
        }

        #endregion

        #endregion

        #region Panel Dragging

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Panel_top_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Panel_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Panel_top_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        // Make dragging also usable for label
        private void Label_title_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Label_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Label_title_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        #endregion

        #region FormClose
        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            // save the last position of the application
            if (this.WindowState != FormWindowState.Minimized)
                Properties.Settings.Default.appLocation = this.Location;

            Properties.Settings.Default.refreshRate = Convert.ToInt32(numericUpDown_readDelay.Value);

            Properties.Settings.Default.Save();
        }

        #endregion

        #region HotKey
        private void HandleHotkey()
        {
            ToggleFirewall();
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
            if (ghk.Register() == true)
                ghk.Unregiser();

            ghk = new KeyHandler(Keys.F6, this);
            ghk.Register();
        }


        #endregion

        #region GET Method from osu! api   

        private static async Task<int> GetBeatmapIdAsync(int beatmapId)
        {
            var url = $"https://osu.ppy.sh/api/get_beatmaps?k={Properties.Settings.Default.userApiKey}&b={beatmapId}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer");
            request.Content = new StringContent("{...}", Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request, CancellationToken.None);

            if (response.IsSuccessStatusCode)
            {
                var JsonString = await response.Content.ReadAsStringAsync();

                JArray arr = (JArray)JsonConvert.DeserializeObject(JsonString);

                return (int)arr[0]["max_combo"];
            }
            else
            {
                MessageBox.Show(
                    $"Internal server Error/ Incorrect API! {Environment.NewLine} " +
                    $"Please restart the application")
                    ;
            }
            return -1;
        }

        private static async Task<List<int>> GetUserRecentScoreAsync(string userName, int recentScoreLimits)
        {
            var url = $"https://osu.ppy.sh/api/get_user_recent?k={Properties.Settings.Default.userApiKey}&u={userName}&limit={recentScoreLimits}";


            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer");
            request.Content = new StringContent("{...}", Encoding.UTF8, "application/json");

            List<int> result = new List<int>();

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
                MessageBox.Show(
                    $"Internal server Error/ Incorrect API! {Environment.NewLine} " +
                    $"Please restart the application")
                    ;
            }

            return result;
        }



        #endregion

        private void Button_checkApiKey_Click(object sender, EventArgs e)
        {
            //***verify api not added

            Properties.Settings.Default.userApiKey = textBox_apiKey.Text;
        }

        private void TextBox_submitAcc_TextChanged(object sender, EventArgs e)
        {
            if(textBox_submitAcc.Text.Equals("")) { textBox_submitAcc.Text = "0"; }
            if (Convert.ToInt32(textBox_submitAcc.Text) > 100)
            {
                Properties.Settings.Default.submitAcc = 100;
                textBox_submitAcc.Text = "100";
            }
            if (Convert.ToInt32(textBox_submitAcc.Text) < 0) // reset the accuracy to 100 to avoid unneeded submission
            {
                Properties.Settings.Default.submitAcc = 100;
                textBox_submitAcc.Text = "100";
            }
        }

        private void TextBox_enableToggle(bool isEnabled)
        {
            textBox_currentMapTime.Enabled = isEnabled;
            textBox_currentPlayData.Enabled = isEnabled;
            textBox_mapData.Enabled = isEnabled;
        }

        private void Label_SubmissionStatus_TextChanged(string str)
        {
            label_submissionStatus.Text = "Submission Status: " + str;
        }
    }

    #region internal struct PatternsToRead

    internal struct PatternsToRead
    {
        public readonly bool OsuBase;
        public readonly bool Mods;
        public readonly bool IsReplay;
        public readonly bool CurrentSkinData;
        public readonly bool TourneyBase;
        public readonly bool PlayContainer;

        public PatternsToRead(ISet<string> patternsToSkip)
        {
            OsuBase = !patternsToSkip.Contains(nameof(OsuBase));
            Mods = !patternsToSkip.Contains(nameof(Mods));
            IsReplay = !patternsToSkip.Contains(nameof(IsReplay));
            CurrentSkinData = !patternsToSkip.Contains(nameof(CurrentSkinData));
            TourneyBase = !patternsToSkip.Contains(nameof(TourneyBase));
            PlayContainer = !patternsToSkip.Contains(nameof(PlayContainer));
        }
    }

    #endregion
}