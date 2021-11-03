using Microsoft.Win32;
using OsuMemoryDataProvider;
using OsuMemoryDataProvider.OsuMemoryModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
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
        private readonly IOsuMemoryReader _reader;
        private readonly StructuredOsuMemoryReader _sreader;
        private CancellationTokenSource cts = new CancellationTokenSource();

        private KeyHandler ghk;
        public const int WM_HOTKEY_MSG_ID = 0x0312;

        public int previousCombo = 0;

        public int resultsScreenScoreV2 = 0;

        private bool isAllowConnection = true;

        private Size originalSize;

        private Task runningTask;

        #region Initialize and OnLoad
        public osuEscape(string osuWindowTitleHint)
        {
            //ApiHelper.InitializeClient();

            _osuWindowTitleHint = osuWindowTitleHint;

            InitializeComponent();

            _reader = OsuMemoryReader.Instance.GetInstanceForWindowTitleHint(osuWindowTitleHint);
            _sreader = StructuredOsuMemoryReader.Instance.GetInstanceForWindowTitleHint(osuWindowTitleHint);

            Shown += OnShown;
            Closing += OnClosing;
            numericUpDown_readDelay.ValueChanged += NumericUpDownReadDelayOnValueChanged;

            // check if osu!Escape is already opened

            if (Process.GetProcessesByName("osuEscape").Length > 1)
            {
                this.Close();
            }            

            UIUpdate();
        }


        private void UIUpdate()
        {
            // UI Update with saved user settings
            checkBox_startUp.Checked = Properties.Settings.Default.isStartUp;
            checkBox_toggleSound.Checked = Properties.Settings.Default.isToggleSound;
            checkBox_systemTray.Checked = Properties.Settings.Default.isSystemTray;
            checkBox_topMost.Checked = Properties.Settings.Default.isTopMost;
            checkBox_submitIfSS.Checked = Properties.Settings.Default.isSubmitIfSS;
            checkBox_hideData.Checked = Properties.Settings.Default.isHideData;

            numericUpDown_readDelay.Value = Properties.Settings.Default.refreshRate;    
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
                // if there is no user settings saved, initialize it
                if (Properties.Settings.Default.osuLocation.Contains("osu!"))
                {
                    FirewallRuleSetUp(Properties.Settings.Default.osuLocation);
                }
                else
                {
                    FindOsuLocation(); // trigger select folder function since there is no any record
                }
            }

            ghk = new KeyHandler(Keys.F6, this);
            ghk.Register();

            // hide notifyIcon until it's minimized to system tray
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

        private void OnShown(object sender, EventArgs eventArgs)
        {
            RealTimeDataDisplayAsync();
        }

        private async void RealTimeDataDisplayAsync()
        {
            if (!string.IsNullOrEmpty(_osuWindowTitleHint)) Text += $": {_osuWindowTitleHint}";
            runningTask = Task.Run(async () =>
            {
                try
                {
                    Stopwatch stopwatch;
                    double readTimeMs, readTimeMsMin, readTimeMsMax;
                    var playContainer = new PlayContainerEx();
                    var playReseted = false;
                    var baseAddresses = new OsuBaseAddresses();

                    while (true)
                    {
                        if (cts.IsCancellationRequested)
                            return;

                        var patternsToRead = GetPatternsToRead();

                        stopwatch = Stopwatch.StartNew();

                        #region OsuBase

                        var mapId = -1;
                        var mapSetId = -1;
                        var songString = string.Empty;
                        var mapMd5 = string.Empty;
                        var mapFolderName = string.Empty;
                        var osuFileName = string.Empty;
                        var retrys = -1;
                        var gameMode = -1;
                        var mapData = string.Empty;
                        var status = OsuMemoryStatus.Unknown;
                        var statusNum = -1;
                        var playTime = -1;

                        if (patternsToRead.OsuBase)
                        {
                            mapId = _reader.GetMapId();
                            mapSetId = _reader.GetMapSetId();
                            songString = _reader.GetSongString();
                            mapMd5 = _reader.GetMapMd5();
                            mapFolderName = _reader.GetMapFolderName();
                            osuFileName = _reader.GetOsuFileName();
                            retrys = _reader.GetRetrys();
                            gameMode = _reader.ReadSongSelectGameMode();
                            mapData =
                                $"HP:{_reader.GetMapHp()} OD:{_reader.GetMapOd()}, CS:{_reader.GetMapCs()}, AR:{_reader.GetMapAr()}, setId:{_reader.GetMapSetId()}";
                            status = _reader.GetCurrentStatus(out statusNum);
                            playTime = _reader.ReadPlayTime();
                        }

                        #endregion

                        #region Mods

                        var mods = -1;
                        if (patternsToRead.Mods)
                        {
                            mods = _reader.GetMods();
                        }

                        #endregion

                        #region CurrentSkinData

                        var skinFolderName = string.Empty;
                        if (patternsToRead.CurrentSkinData)
                        {
                            skinFolderName = _reader.GetSkinFolderName();
                        }

                        #endregion

                        #region PlayContainer

                        double hp = 0;
                        var playerName = string.Empty;
                        var hitErrorCount = -1;
                        var playingMods = -1;
                        double displayedPlayerHp = 0;
                        int scoreV2 = -1;

                        Invoke((MethodInvoker)(() =>
                        {
                            if (status == OsuMemoryStatus.Playing && patternsToRead.PlayContainer)
                            {
                                playReseted = false;
                                _reader.GetPlayData(playContainer);
                                hp = _reader.ReadPlayerHp();
                                playerName = _reader.PlayerName();
                                hitErrorCount = _reader.HitErrors()?.Count ?? -2;
                                playingMods = _reader.GetPlayingMods();
                                displayedPlayerHp = _reader.ReadDisplayedPlayerHp();
                                scoreV2 = _reader.ReadScoreV2();
                                resultsScreenScoreV2 = scoreV2;


                                //Connect again if the score is an SS
                                if (checkBox_submitIfSS.Checked)
                                {
                                    // if not connecting and the score is SS, then upload it through reconnecting
                                    if (!isAllowConnection && playContainer.Acc == 100)
                                    {
                                        ToggleFirewall();
                                        isAllowConnection = true;
                                    }
                                }

                            }
                            else if (status == OsuMemoryStatus.ResultsScreen)
                            {
                                playReseted = false;
                                scoreV2 = resultsScreenScoreV2;

                                //to be implemented: api detect submission -> block submission
                            }
                            else if (status == OsuMemoryStatus.NotRunning)
                            {
                                textBox_strings.Clear();
                                textBox_currentMapTime.Clear();
                            }
                            else if (!playReseted)
                            {
                                playReseted = true;
                                playContainer.Reset();
                            }
                        }));

                        #endregion

                        #region TourneyBase

                        // TourneyBase
                        var tourneyIpcState = TourneyIpcState.Unknown;
                        var tourneyIpcStateNumber = -1;
                        var tourneyLeftStars = -1;
                        var tourneyRightStars = -1;
                        var tourneyBO = -1;
                        var tourneyStarsVisible = false;
                        var tourneyScoreVisible = false;
                        if (status == OsuMemoryStatus.Tourney && patternsToRead.TourneyBase)
                        {
                            tourneyIpcState = _reader.GetTourneyIpcState(out tourneyIpcStateNumber);
                            tourneyLeftStars = _reader.ReadTourneyLeftStars();
                            tourneyRightStars = _reader.ReadTourneyRightStars();
                            tourneyBO = _reader.ReadTourneyBO();
                            tourneyStarsVisible = _reader.ReadTourneyStarsVisible();
                            tourneyScoreVisible = _reader.ReadTourneyScoreVisible();
                        }

                        #endregion

                        stopwatch.Stop();

                        readTimeMs = stopwatch.ElapsedTicks / (double)TimeSpan.TicksPerMillisecond;
                        lock (_minMaxLock)
                        {

                            if (readTimeMs < _memoryReadTimeMin) 
                                _memoryReadTimeMin = readTimeMs;

                            if (readTimeMs > _memoryReadTimeMax) 
                                _memoryReadTimeMax = readTimeMs;

                            // copy value since we're inside lock
                            readTimeMsMin = _memoryReadTimeMin;
                            readTimeMsMax = _memoryReadTimeMax;
                        }

                        Invoke((MethodInvoker)(() =>
                        {
                            //textBox_mapId.Text = $"Id:{mapId} {Environment.NewLine}" +
                            //                     $"setId:{mapSetId} {Environment.NewLine}";

                            textBox_strings.Text = $"Now Playing: {songString} {Environment.NewLine}" +
                                                   //$"md5: \"{mapMd5}\" {Environment.NewLine}" +
                                                   //$"mapFolder: \"{mapFolderName}\" {Environment.NewLine}" +
                                                   //$"fileName: \"{osuFileName}\" {Environment.NewLine}" +
                                                   //$"Retrys:{retrys} {Environment.NewLine}" +
                                                   $"Mods: {(Mods)mods}"
                                                   // + "({mods}) {Environment.NewLine}";
                                                   // + $"SkinName: \"{skinFolderName}\""
                                                   ;

                            textBox_currentMapTime.Text = playTime.ToString();

                            //textBox_mapData.Text = mapData;

                            textBox_Status.Text = status + " ";
                            // + statusNum + " " + gameMode;

                            textBox_CurrentPlayData.Text =
                                playContainer + Environment.NewLine +
                                $"Score: {scoreV2} {Environment.NewLine}"
                                //$"IsReplay: {isReplay} {Environment.NewLine}" +
                                //$"hp________: {hp:00.##} {Environment.NewLine}" +
                                //$"displayedHp: {displayedPlayerHp:00.##} {Environment.NewLine}" +
                                //$"Mods: {(Mods)playingMods}, " 
                                //$"PlayerName: {playerName}{Environment.NewLine}" +
                                //$"HitErrorCount: {hitErrorCount} ";
                                ;

                            if (status != OsuMemoryStatus.Playing && status != OsuMemoryStatus.ResultsScreen)
                            {
                                textBox_CurrentPlayData.Clear();
                            }
                        }));
                        await Task.Delay(_readDelay);
                    }
                }
                catch (ThreadAbortException)
                {

                }
            });
        }

       

        public class PlayContainerEx : PlayContainer
        {
            private int PreviousC100 { get; set; }

            public int Sliderbreak { get; private set; } = 0;

            public double Accuracy { get; private set; }

            public override string ToString()
            {
                if (C100 - PreviousC100 == 1 && Score != 0)
                {
                    Sliderbreak += 1;
                }

                if (Score == 0)
                    Sliderbreak = 0;

                PreviousC100 = C100;

                Accuracy = Acc;

                var nl = Environment.NewLine;
                return $"300: {C300}, 100: {C100}, 50: {C50}, Miss: {CMiss}" + nl +
                       $"Accuracy: {Acc}" + nl +
                       $"Recent Combo: {Combo}, Max Combo: {MaxCombo}" + nl +
                       $"Sliderbreak: {Sliderbreak} " 
                       //$"Score: {scoreV2} {Environment.NewLine}"
                       //+ $"Score: {Score}"
                       ;
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

        private PatternsToRead GetPatternsToRead()
        {
            lock (_patternsToSkip)
            {
                return new PatternsToRead(_patternsToSkip);
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
        // Include: startup, toggle with sound, minimize to system tray, top most, submit if ss
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

        #region Submit If SS
        private void CheckBox_submitIfSS_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isSubmitIfSS = checkBox_submitIfSS.Checked;
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
                this.MinimumSize = new Size(426, 215);
                this.Size = this.MinimumSize;
                this.MaximumSize = this.Size;

                groupBox_hideData.Location = new Point(8,120);
                groupBox_Data.Visible = false;
            }                
            else
            {
                // reset cts and resume
                //cts.Dispose();
                //cts = new CancellationTokenSource();
                
                //RealTimeDataDisplayAsync();

                groupBox_Data.Visible = true;
                groupBox_hideData.Location = new Point(8, 335);

                // reset ui with fixed size
                this.MaximumSize = new Size (426,427);
                this.Size = this.MaximumSize;
                this.MinimumSize = this.Size;
            }
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