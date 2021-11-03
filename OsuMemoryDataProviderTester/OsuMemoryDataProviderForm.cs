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

namespace osuEscape_2
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


        private enum Connection
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> parent of 71cdd4c (added submit if ss button (not working))
=======
>>>>>>> parent of 71cdd4c (added submit if ss button (not working))
            Allow = 1,
            Block = -1
        }

        private int toggle = -1;
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 71cdd4c (added submit if ss button (not working))
=======
>>>>>>> parent of 71cdd4c (added submit if ss button (not working))
=======
>>>>>>> parent of 71cdd4c (added submit if ss button (not working))


        public osuEscape(string osuWindowTitleHint)
        {
            System.Diagnostics.Debug.WriteLine("arguments: " + osuWindowTitleHint);
            _osuWindowTitleHint = osuWindowTitleHint;

            InitializeComponent();

            _reader = OsuMemoryReader.Instance.GetInstanceForWindowTitleHint(osuWindowTitleHint);
            _sreader = StructuredOsuMemoryReader.Instance.GetInstanceForWindowTitleHint(osuWindowTitleHint);

            Shown += OnShown;
            Closing += OnClosing;
            numericUpDown_readDelay.ValueChanged += NumericUpDownReadDelayOnValueChanged;

            // check if osu!Escape is already opened

            if (Process.GetProcessesByName("osuEscape").Count() > 1)
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
            numericUpDown_readDelay.Value = Properties.Settings.Default.refreshRate;
    

            // UI fixed size 
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void osuEscape_Load(object sender, EventArgs e)
        {
            // avoid opening twice
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

            notifyIcon_osuEscape.Visible = false;
        }


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

            if (!string.IsNullOrEmpty(_osuWindowTitleHint)) Text += $": {_osuWindowTitleHint}";
            _ = Task.Run(async () =>
            {
                try
                {
                    RealTimeUpdateDisplay();

                    await Task.Delay(_readDelay);
                }
                catch (ThreadAbortException)
                {

                }
            });
        }

        public void RealTimeUpdateDisplay()
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

                #region IsReplay

                bool isReplay = false;
                if (status == OsuMemoryStatus.Playing && patternsToRead.IsReplay)
                {
                    isReplay = _reader.IsReplay();
                }

                #endregion

                #region PlayContainer

                double hp = 0;
                var playerName = string.Empty;
                var hitErrorCount = -1;
                var playingMods = -1;
                double displayedPlayerHp = 0;
                int scoreV2 = -1;
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
                }
                else if (status == OsuMemoryStatus.ResultsScreen && patternsToRead.PlayContainer)
                {
                    playReseted = false;
                    scoreV2 = resultsScreenScoreV2;
                    
                }
                else if (!playReseted)
                {
                    playReseted = true;
                    playContainer.Reset();
                }

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
                    if (readTimeMs < _memoryReadTimeMin) _memoryReadTimeMin = readTimeMs;
                    if (readTimeMs > _memoryReadTimeMax) _memoryReadTimeMax = readTimeMs;
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

                    textBox_time.Text = playTime.ToString();

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
            }
        }

        public class PlayContainerEx : PlayContainer
        {
            private int PreviousC100 { get; set; }

            public int Sliderbreak { get; private set; } = 0;

            public override string ToString()
            {
                if (C100 - PreviousC100 == 1 && Score != 0)
                {
                    Sliderbreak += 1;
                }

                if (Score == 0)
                    Sliderbreak = 0;

                PreviousC100 = C100;




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

        private void ChangeConnection(bool isAllow)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "netsh";
            cmd.StartInfo.Arguments =
            //    @"advfirewall firewall set rule name=""osu block"" new enable=" + (isAllow == Connection.Allow ? "no" : "yes");
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
            button_toggle.Text = isAllow ? "Connecting" : "Blocked";
            button_toggle.ForeColor = isAllow ? System.Drawing.Color.Green : System.Drawing.Color.Red;
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

        private void Button_toggle_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.osuLocation != "")
            {
                ToggleFirewall();
            }
            else
            {
                MessageBox.Show("Invalid Location");
            }
        }

        

        private void ToggleFirewall()
        {
            ChangeConnection(toggle == 1); // isAllow
            toggle *= -1;

            if (checkBox_toggleSound.Checked)
                System.Media.SystemSounds.Asterisk.Play();
        }

        private void Button_findLocation_Click(object sender, EventArgs e) // select osu!.exe
        {
            FindOsuLocation();
        }

        private void FindOsuLocation()
        {
            OpenFileDialog ofd = new OpenFileDialog();
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

                // disable at first to avoid unneeded disconnection
                cmd.StartInfo.Arguments =
                    "advfirewall firewall set rule name=\"osu block\" new enable=no"; ;
                cmd.Start();
                cmd.WaitForExit();

                button_toggle.Text = "Connecting";
                button_toggle.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void UpdateOsuLocationText()
        {
            textBox_osuPath.Text = "osu! Path: " + String.Join("\\", Properties.Settings.Default.osuLocation.Split('\\').Reverse().Skip(1).Reverse()) + "\\";
        }

        

        #region CheckBox Settings
        
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

        #region NotifyIcon and SystemTray
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

        #endregion

        #region TopMost
        private void CheckBox_topMost_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTopMost = checkBox_topMost.Checked;
            this.TopMost = checkBox_topMost.Checked;
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

        private static string GetOsuPath()
        {
            return (Process.GetProcessesByName("osu!").Count() == 0 ? "" : Process.GetProcessesByName("osu!").FirstOrDefault().MainModule.FileName);
        }

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

        private void ContextMenuStripUpdate()
        {
            notifyIcon_osuEscape.ContextMenuStrip = contextMenuStrip_osu;

            //Status Update
            contextMenuStrip_osu.Items[0].Text = "Status: " + button_toggle.Text;

            contextMenuStrip_osu.Items[1].Click += new EventHandler(Item_quit_Click);

            //notifyIcon_osuEscape.Icon = (button_toggle.Text == "Connecting" ? Properties.Resources. : Properties.Resources.osuEscapeBlocking);
        }
        private void Item_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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