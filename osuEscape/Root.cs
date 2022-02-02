﻿using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OsuMemoryDataProvider;
using OsuMemoryDataProvider.OsuMemoryModels;
using OsuMemoryDataProvider.OsuMemoryModels.Direct;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace osuEscape
{

    public partial class Root : MaterialForm
    {
        public Form mainForm = new MainForm();
        public Form settingsForm = new SettingsForm();
        public Form uploadedScoresForm = new UploadedScoresForm();

        // osu! data reader
        private readonly string _osuWindowTitleHint;
        private int _readDelay = 50;
        private readonly StructuredOsuMemoryReader _sreader;
        private readonly CancellationTokenSource cts = new();

        // Hotkey
        // Keyboard hook for multiple keys
        private readonly KeyboardHook keyboardHook = new();
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
        /*private bool isEditingHotkey = false;*/

        // score upload
        private static readonly HttpClient client = new();
        private static int beatmapLastNoteOffset = Int32.MinValue;

        // resize ui variables
        /*private Size FormSize_init;*/
        private Point labelSubmissionStatus_Location_init;

        // material skin ui
        readonly MaterialSkinManager materialSkinManager;

        // startup
        private static readonly string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private static readonly string StartupValue = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

        private bool isItemQuit = false;

        private bool isSetScore = false;
        private string previousSubmittedBeatmapMd5 = string.Empty;

        bool isOffsetFound = false;


        public Root(string osuWindowTitleHint)
        {
            _osuWindowTitleHint = osuWindowTitleHint;

            InitializeComponent();

            // Initialize material skin manager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);

            _sreader = StructuredOsuMemoryReader.Instance.GetInstanceForWindowTitleHint(osuWindowTitleHint);

            // for ui resizing
            // design editor pixels height offset (50px)
            /*this.Size = new Size(this.Size.Width, this.Size.Height - 50);
            FormSize_init = this.Size;*/
            this.Size = new Size(this.Size.Width, this.Size.Height - 50);
            labelSubmissionStatus_Location_init = materialLabel_submissionStatus.Location;

            // avoid opening osu!Escape twice
            if (Process.GetProcessesByName("osuEscape").Length > 1)
            {
                notifyIcon_osuEscape.Visible = false;
                this.Close();
            }

            // startup issue check
            // hotkey
            keyboardHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(KeyboardHook_OnKeyPressed);
            keyboardHook.RegisterHotKey((ModifierKeys)Properties.Settings.Default.ModifierKeys,
                                        KeysToStringDictionary.FirstOrDefault(x => x.Value == Properties.Settings.Default.GlobalHotKey).Key);

            // ui 
            MainTabResize();
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


        private void SettingForm_Init()
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

            TextBox_GlobalHotkey_Update();
        }
        private Form ConvertFormToTabPage(Form f)
        {
            Form form = f;
            form.TopLevel = false;
            form.Visible = true;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            return form;
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            materialTabControl_menu.TabPages[0].Controls.Clear();
            materialTabControl_menu.TabPages[1].Controls.Clear();
            materialTabControl_menu.TabPages[2].Controls.Clear();
            materialTabControl_menu.TabPages[0].Controls.Add(ConvertFormToTabPage(mainForm));
            materialTabControl_menu.TabPages[1].Controls.Add(ConvertFormToTabPage(settingsForm));
            materialTabControl_menu.TabPages[2].Controls.Add(ConvertFormToTabPage(uploadedScoresForm));

            // check if osu!Escape is already opened 
            if (Process.GetProcessesByName(this.Name).Length > 1)
                this.Close();

            // check administrator privileges
            if (!IsAdministrator())
            {
                MessageBox.Show("Please open osu!Escape with administrator privileges for toggling firewall permission.");
                this.Close();
            }

            osuDataReaderAsync();

            // open the app at the previous position (location on window) 
            this.Location = Properties.Settings.Default.appPosition;

            // get osu! directory from running process
            /*Properties.Settings.Default.osuLocation = Process.GetProcessesByName("osu!").Length == 0
                                                    ? Properties.Settings.Default.osuLocation
                                                    : Process.GetProcessesByName("osu!").FirstOrDefault().MainModule.FileName;*/

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

            #region Tooltip setup

            toolTips.SetToolTip(materialSwitch_autoDisconnect, "Enabling this option will automatically disconnect after the recent score is submitted.");
            toolTips.SetToolTip(materialSwitch_toggleWithSound, "Enabling this option will toggle firewall with system notification sound.");
            toolTips.SetToolTip(materialSwitch_topMost, "Enabling this option will overlap all the other application even if it is not focused.");
            toolTips.SetToolTip(materialSwitch_runAtStartup, "Enabling this option will allow osu!Escape to run automatically when the system is booted.");
            toolTips.SetToolTip(materialSwitch_minimizeToSystemTray, "Enabling this option will hide osu!Escape to taskbar when clicking the close button.");
            toolTips.SetToolTip(materialSwitch_submitIfFC, "Enabling this option will automatically submit before jumping into result screen if the set score meets the requirement.");

            #endregion

            #region Check for Update
            WebClient webClient = new();
            if (!webClient.DownloadString("https://pastebin.com/5hDSctE0").Contains(Assembly.GetExecutingAssembly().GetName().Version.ToString()))
            {
                if (MessageBox.Show("This version is outdated! Please download the latest version at GitHub's release page.",
                    "osu!Escape",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _ = Process.Start(new ProcessStartInfo("https://github.com/Koltay/osuEscape/releases/") { UseShellExecute = true });
                }
            }
            #endregion

            // setting form
            SettingForm_Init();
        }

        #endregion

        #region Main Functions

        #region osu! Data Reader

        private async void osuDataReaderAsync()
        {
            if (!string.IsNullOrEmpty(_osuWindowTitleHint)) Text += $": {_osuWindowTitleHint}";
            Text += " " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

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

                        beatmapLastNoteOffset = -9999;
                    }
                    else
                    {
                        baseAddresses.SongSelectionScores.Scores.Clear();
                    }


                    if (baseAddresses.GeneralData.OsuStatus == OsuMemoryStatus.ResultsScreen)
                    {
                        _sreader.TryRead(baseAddresses.ResultsScreen);
                    }


                    if (baseAddresses.GeneralData.OsuStatus == OsuMemoryStatus.Playing)
                    {
                        _sreader.TryRead(baseAddresses.Player);
                        _sreader.TryRead(baseAddresses.LeaderBoard);
                        _sreader.TryRead(baseAddresses.KeyOverlay);

                        if (readUsingProperty)
                        {
                            _sreader.TryReadProperty(baseAddresses.Player, nameof(Player.Mods), out var dummyResult);
                        }

                        // only read the audio offset if it is not the previous beatmap
                        if (!isOffsetFound)
                        {
                            try
                            {
                                await Task.Run(async () =>
                                {
                                    string beatmapFile = $"{Properties.Settings.Default.osuPath}\\Songs\\{baseAddresses.Beatmap.FolderName}\\{baseAddresses.Beatmap.OsuFileName}";

                                    await Task.Run(() =>
                                    {
                                        foreach (string str in File.ReadLines(beatmapFile).Last().Split(","))
                                        {
                                            if (Int32.TryParse(str, out var value))
                                                beatmapLastNoteOffset = Math.Max(beatmapLastNoteOffset, value);
                                        }
                                        // special case: slider (and reverse slider)
                                        // Hit object syntax: x,y,time,type,hitSound,curveType|curvePoints,slides,length,edgeSounds,edgeSets,hitSample
                                        // old: 0,2 and 6 mean slider in type
                                        // new: use | to determine if it is a hitobject with type "slider"

                                        char beatmapMode = '0';
                                        string[] beatmapFileLines = File.ReadAllLines(beatmapFile);

                                        for (int i = 0; i < beatmapFileLines.Length; i++)
                                        { 
                                            if (beatmapFileLines[i].Contains("Mode: "))
                                            {
                                                beatmapMode = beatmapFileLines[i].Last();
                                                Debug.WriteLine("Beatmap Mode: " + beatmapMode);
                                            }
                                        }                                 

                                        if (File.ReadLines(beatmapFile).Last().Contains("|") && beatmapMode == '0')
                                        {
                                            // [7] is the slider pixel length of slider (syntax above)
                                            decimal sliderPixelLength = Convert.ToDecimal(File.ReadLines(beatmapFile).Last().Split(",")[7]);

                                            // reverse slider 
                                            int sliderRepeatCount = Convert.ToInt32(File.ReadLines(beatmapFile).Last().Split(",")[6]);

                                            decimal sliderMultiplier = 0;
                                            decimal beatLength = 0;
                                            decimal BPM = 0;
                                            decimal sliderVelocity = 1;
                                            int difficultySessionIndex = 0;
                                            int timingPointSessionIndex = 0;
                                            int sliderLengthOffset = 0;
                                            bool uninherited = true;
                                            
                                            // locate the sessions
                                            for (int i = 0; i < beatmapFileLines.Length; i++)
                                            {
                                                if (beatmapFileLines[i] == "[Difficulty]")
                                                {
                                                    difficultySessionIndex = i;
                                                }
                                                else if (beatmapFileLines[i] == "[TimingPoints]")
                                                {
                                                    timingPointSessionIndex = i;
                                                }
                                            }

                                            for (int i = difficultySessionIndex + 1; i < beatmapFileLines.Length; i++)
                                            {
                                                if (!beatmapFileLines[i].Contains(":"))
                                                    break;

                                                if (File.ReadAllLines(beatmapFile)[i].Contains("SliderMultiplier:"))
                                                    sliderMultiplier = Convert.ToDecimal(File.ReadAllLines(beatmapFile)[i][17..]);
                                            }

                                            // timing point syntax: time,beatLength,meter,sampleSet,sampleIndex,volume,uninherited,effects
                                            for (int i = timingPointSessionIndex + 1; i < beatmapFileLines.Length; i++)
                                            {
                                                // check the corresponding timing point
                                                if (!beatmapFileLines[i].Contains(","))
                                                    break;

                                                beatLength = Convert.ToDecimal(File.ReadAllLines(beatmapFile)[i].Split(",")[1]);

                                                // uninherited == 1, red line
                                                if (Convert.ToInt32(File.ReadAllLines(beatmapFile)[i].Split(",")[6]) == 1)
                                                {
                                                    BPM = 60000 / Convert.ToDecimal(File.ReadAllLines(beatmapFile)[i].Split(",")[1]);
                                                    uninherited = true;
                                                }
                                                else
                                                    uninherited = false;
                                            }
                                            if (!uninherited)
                                                sliderVelocity = -100 / beatLength;

                                            sliderLengthOffset = (int)Math.Abs(Math.Round(600 * sliderPixelLength / (BPM * sliderMultiplier * sliderVelocity)));

                                            beatmapLastNoteOffset += (sliderLengthOffset * sliderRepeatCount);
                                        }
                                    });
                                });

                                isOffsetFound = true;
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex);
                            }
                        }


                        // 1.   *** Auto Connection has to be done on playing status for instant connection,
                        //      otherwise, connection checking on results screen would take about 30 seconds or more
                        // 2.   Using beatmap's last HitObject's offset to determine if the map ended
                        // 3.   Determine if it is an "FC" (depends on user)
                        //      "FC": 0 misscount / dropped some sliderends / sliderbreak at start
                        // 4.   Submit if it is above or equal to the required accuracy, and it has to be not a replay
                        // 5.   If there is already blocked connection, disable the block rule
                        //      Verify Md5 to avoid false auto connection on same beatmap set
                        if (Properties.Settings.Default.isSubmitIfFC &&
                            baseAddresses.GeneralData.AudioTime >= beatmapLastNoteOffset &&
                            isOffsetFound &&
                            baseAddresses.Player.HitMiss == 0 &&
                            (!Properties.Settings.Default.isCheckingFullCombo || baseAddresses.Player.Combo == baseAddresses.Player.MaxCombo) &&
                            baseAddresses.Player.Accuracy >= Properties.Settings.Default.submitAcc &&
                            !Properties.Settings.Default.isAllowConnection &&
                            previousSubmittedBeatmapMd5 != baseAddresses.Beatmap.Md5 &&
                            isSubmittableBeatmapStatus())
                        {
                            Properties.Settings.Default.isAllowConnection = true;
                            Firewall.ToggleFirewall();
                            isSetScore = true;
                        }
                    }
                    else
                    {
                        baseAddresses.LeaderBoard.Players.Clear();
                        isOffsetFound = false;
                    }

                    // score submission
                    // upload if only it is not a replay
                    // miss count == 0 means full comboing 
                    // do not upload if the map is pending or not submitted
                    if (isSetScore &&
                        Properties.Settings.Default.isAutoDisconnect &&
                        Properties.Settings.Default.isAllowConnection &&
                        baseAddresses.GeneralData.OsuStatus != OsuMemoryStatus.Playing &&
                        isSubmittableBeatmapStatus())
                    {
                        previousSubmittedBeatmapMd5 = baseAddresses.Beatmap.Md5;

                        materialLabel_submissionStatus.BeginInvoke((MethodInvoker)delegate
                        {
                            materialLabel_SubmissionStatus_TextChanged("Uploading recent score...");
                        });

                        // submission frequency test
                        await Task.Delay(750);

                        // GET Method of user's recent score (osu! api v1)
                        // get the recent 3 scores, even though there is multiple submissions at one connection
                        // the recent score could still be recognized
                        Dictionary<int, int> recentUploadScoreDict = await GetUserRecentScoreAsync(baseAddresses.Player.Username, baseAddresses.Player.Mode, 3);

                        bool isRecentSetScoreUploaded = false;

                        foreach (var responseScore in recentUploadScoreDict)
                        {
                            // the score player recently submitted
                            if (responseScore.Key == baseAddresses.Beatmap.Id &&
                                responseScore.Value == baseAddresses.Player.Score)
                            {
                                isRecentSetScoreUploaded = true;

                                Properties.Settings.Default.isAllowConnection = false;
                                Firewall.ToggleFirewall();

                                isSetScore = false;

                                // uploaded scores tab page update

                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    ListViewItem item = new(baseAddresses.Beatmap.MapString);
                                    item.SubItems.Add(baseAddresses.Player.Score.ToString());
                                    item.SubItems.Add(baseAddresses.Player.Accuracy.ToString("0.00"));
                                    // rank icon TBD
                                    // pp TBD
                                    materialListView_uploadedScores.Items.Add(item);
                                }));

                                break;
                            }
                        }

                        materialLabel_submissionStatus.BeginInvoke((MethodInvoker)delegate
                        {
                            string text = isRecentSetScoreUploaded ? "Uploaded recent score." : "";
                            materialLabel_SubmissionStatus_TextChanged(text);
                        });
                    }

                    bool isSubmittableBeatmapStatus()
                    {
                        return !baseAddresses.Player.IsReplay &&
                                baseAddresses.Beatmap.Status != ((short)BeatmapStatus.Pending) &&
                                baseAddresses.Beatmap.Status != ((short)BeatmapStatus.NotSubmitted);
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

                    _sreader.ReadTimes.Clear();
                    await Task.Delay(_readDelay);
                }
            }, cts.Token);
        }

        #endregion 

        #region ToggleConnection 

        /*private void ToggleFirewall()
        {
            if (Properties.Settings.Default.osuLocation == "")
            {
                MainFunction.ShowMessageBox("ERROR: Invalid Location!");
            }
            else
            {
                AllowConnection(Properties.Settings.Default.isAllowConnection);

                Audio.ToggleSound(Properties.Settings.Default.isToggleSound);

                Invoke_FormRefresh();
            }
        }*/

        /*private void AllowConnection(bool isAllow)
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

            ColorSchemeUpdate();

            ContextMenuStripUpdate();
        }*/

        private void ColorSchemeUpdate()
        {
            // Allow: Green; Blocked: Red
            materialSkinManager.ColorScheme = Properties.Settings.Default.isAllowConnection ?
            new ColorScheme(
                    Primary.Grey800,
                    Primary.Grey900,
                    Primary.Grey500,
                    Accent.Green700,
                    TextShade.WHITE)
            :
            new ColorScheme(
                    Primary.Grey800,
                    Primary.Grey900,
                    Primary.Grey500,
                    Accent.Red400,
                    TextShade.WHITE);
        }

        /*private async void FirewallRuleSetUp(string filename)
        {
            await Task.Run(async () =>
            {
                if (filename.Contains("osu!.exe"))
                {


                    Properties.Settings.Default.osuLocation = filename;

                    // UpdateOsuLocationText
                    // osuPath: osuLocation without osu.exe at the end
                    string osuPath = String.Join("\\", Properties.Settings.Default.osuLocation.Split('\\').Reverse().Skip(1).Reverse()) + "\\";
                    Properties.Settings.Default.osuPath = osuPath;

                    materialLabel_osuPath.Invoke(new MethodInvoker(delegate
                    {
                        materialLabel_osuPath.Text = "osu! Path: " + osuPath;
                    }));

                    // create cmd
                    Process cmd = new();
                    cmd.StartInfo.FileName = "netsh";
                    cmd.StartInfo.Verb = "runas";
                    cmd.StartInfo.UseShellExecute = true;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    // delete the rules if the users used this application before
                    cmd.StartInfo.Arguments =
                        "advfirewall firewall delete rule name=\"osu block\"";
                    cmd.Start();

                    await Task.Delay(500);

                    // add blocking rule into advanced firewall 
                    cmd.StartInfo.Arguments =
                        "advfirewall firewall add rule name=\"osu block\" dir=out action=block program=" + filename;
                    cmd.Start();

                    await Task.Delay(500);

                    Debug.WriteLine("Connection status: " + Properties.Settings.Default.isAllowConnection);
                }
            });
        }*/

        #endregion

        #endregion

        #region Find osu! location


        /*private void OpenFileDialog_FindOsuLocation()
        {
            OpenFileDialog ofd = new()
            {
                Filter = "osu.exe |*.EXE"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!ofd.FileName.Contains("osu!.exe"))
                {
                    // run again until user finds osu.exe or user cancelled the action
                    OpenFileDialog_FindOsuLocation();
                }
                else
                {
                    Properties.Settings.Default.osuLocation = ofd.FileName;

                    FirewallRuleSetUp(Properties.Settings.Default.osuLocation);
                }
            }
            materialButton_findOsuLocation.UseAccentColor = false;
        }*/

        #endregion

        #region CheckBoxes related 

        #region Run at Startup
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
        #endregion

        #region System Tray
        private void ToggleSystemTray(bool enabled)
        {
            this.ShowInTaskbar = !enabled;
        }

        #endregion

        #region ContextMenuStrip
        private void ContextMenuStripUpdate()
        {
            notifyIcon_osuEscape.ContextMenuStrip = contextMenuStrip_osu;

            // status Update
            contextMenuStrip_osu.Items[0].Text = "Status: " + (Properties.Settings.Default.isAllowConnection ? "Connecting" : "Blocked");

            contextMenuStrip_osu.Items[1].Click += new EventHandler(Item_quit_Click);

            notifyIcon_osuEscape.Icon =
                (Properties.Settings.Default.isAllowConnection ?
                Properties.Resources.osuEscapeConnecting :
                Properties.Resources.osuEscapeBlocking);
        }
        private void Item_quit_Click(object sender, EventArgs e)
        {
            isItemQuit = true;
            this.Close();
        }

        #endregion

        #region Checkboxes' Checked changed

        private void materialCheckbox_autoDisconnect_CheckedChanged(object sender, EventArgs e) => Properties.Settings.Default.isAutoDisconnect = materialSwitch_autoDisconnect.Checked;

        private void materialCheckbox_submitIfFC_CheckedChanged(object sender, EventArgs e)
        => Properties.Settings.Default.isSubmitIfFC = materialSwitch_submitIfFC.Checked;

        private void materialCheckbox_topMost_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTopMost = materialSwitch_topMost.Checked;
            this.TopMost = materialSwitch_topMost.Checked;
        }

        private void materialCheckbox_toggleWithSound_CheckedChanged(object sender, EventArgs e)
        => Properties.Settings.Default.isToggleSound = materialSwitch_toggleWithSound.Checked;

        private void materialCheckbox_minimizeToSystemTray_CheckedChanged(object sender, EventArgs e)
        => Properties.Settings.Default.isSystemTray = materialSwitch_minimizeToSystemTray.Checked;

        private void materialCheckbox_runAtStartup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isStartup = materialSwitch_runAtStartup.Checked;

            StartupSetUp(materialSwitch_runAtStartup.Checked);
        }

        #endregion

        #endregion

        #region Buttons

        private void materialButton_checkApi_Click(object sender, EventArgs e)
        => VerifyAPIKeyAsync();

        /*private void MaterialButton_findOsuLocation_Click(object sender, EventArgs e)
        {
            materialButton_findOsuLocation.UseAccentColor = true;
            OpenFileDialog_FindOsuLocation();
        }*/
        /*private void MaterialButton_changeToggleHotKey_Click(object sender, EventArgs e)
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
        }*/


        #endregion

        #region Global HotKey
        private bool isEditingHotkey = false;
        private void HomeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (MainForm.isEditingHotkey)
            {
                // cancel changes
                if (e.KeyCode == Keys.Escape)
                {
                    TextBox_GlobalHotkey_Update();
                    isEditingHotkey = false;
                }
                else if (KeysToStringDictionary.ContainsKey(e.KeyCode))
                {
                    keyboardHook.Dispose();

                    // user settings
                    Properties.Settings.Default.ModifierKeys = 0;
                    Properties.Settings.Default.ModifierKeys += e.Alt ? 1 : 0;
                    Properties.Settings.Default.ModifierKeys += e.Control ? 2 : 0;
                    Properties.Settings.Default.ModifierKeys += e.Shift ? 4 : 0;
                    Properties.Settings.Default.GlobalHotKey = KeysToStringDictionary[e.KeyCode];

                    // ui
                    TextBox_GlobalHotkey_Update();

                    keyboardHook.RegisterHotKey((ModifierKeys)Properties.Settings.Default.ModifierKeys,
                                        KeysToStringDictionary.FirstOrDefault(x => x.Value == Properties.Settings.Default.GlobalHotKey).Key);

                    System.Media.SystemSounds.Asterisk.Play();

                    isEditingHotkey = false;

                    materialButton_changeToggleHotkey.UseAccentColor = false;
                }
            }
        }


        #endregion

        #region GET Method from osu! api   

        private static async Task<Dictionary<int, int>> GetUserRecentScoreAsync(string userName, int mode, int recentScoreLimits)
        {
            var url = $"https://osu.ppy.sh/api/get_user_recent?k={Properties.Settings.Default.userApiKey}&u={userName}&m={mode}&limit={recentScoreLimits}";


            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer");
            request.Content = new StringContent("{...}", Encoding.UTF8, "application/json");

            // beatmap_id, score
            Dictionary<int, int> resultDict = new();

            var response = await client.SendAsync(request, CancellationToken.None);

            if (response.IsSuccessStatusCode)
            {
                var JsonString = await response.Content.ReadAsStringAsync();

                JArray arr = (JArray)JsonConvert.DeserializeObject(JsonString);

                if (arr.Count != 0)
                {
                    for (int i = 0; i < System.Math.Min(arr.Count, recentScoreLimits); i++)
                    {
                        int beatmap_id = Convert.ToInt32(arr[i]["beatmap_id"]);
                        int score = Convert.ToInt32(arr[i]["score"]);
                        resultDict[beatmap_id] = score;
                    }
                }
            }
            else
            {
                IncorrectAPITextOutput();
            }

            return resultDict;
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

            Invoke_FormRefresh();
        }

        private void Invoke_FormRefresh()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                this.Refresh();
            }));
        }
        #endregion

        #region API Required Options

        private static void IncorrectAPITextOutput()
        {
            MainFunction.ShowMessageBox(
                    $"Internal server Error/ Incorrect API! {Environment.NewLine} " +
                    $"Please check if your API key is correct.")
                    ;
        }
        private void APIRequiredCheckBoxesEnabled()
        {
            if (materialSwitch_autoDisconnect.InvokeRequired)
            {
                materialSwitch_autoDisconnect.Invoke(new MethodInvoker(delegate
                {
                    materialSwitch_autoDisconnect.Enabled = Properties.Settings.Default.isAPIKeyVerified;
                    if (!materialSwitch_autoDisconnect.Enabled)
                        materialSwitch_autoDisconnect.Checked = false;
                }));
            }
            else
            {
                materialSwitch_autoDisconnect.Enabled = Properties.Settings.Default.isAPIKeyVerified;
                if (!materialSwitch_autoDisconnect.Enabled)
                    materialSwitch_autoDisconnect.Checked = false;
            }
        }

        #endregion

        private void materialLabel_SubmissionStatus_TextChanged(string str)
        {
            materialLabel_submissionStatus.Text = "Submission Status: " + str;
        }
        //
        private void materialTabControl_menu_Selected(object sender, TabControlEventArgs e)
        {
            if (materialTabControl_menu.SelectedTab == tabPage_main)
            {
                MainTabResize();
            }
            else
            {
                // reset ui size with fixed min/max
                /*this.MaximumSize = FormSize_init;
                this.Size = FormSize_init;
                this.MinimumSize = FormSize_init;*/

                materialLabel_focus.Focus();

                APIRequiredCheckBoxesEnabled();
            }
        }

        /*private static void ShowMessageBox(string message)
        {
            ToggleSound(Properties.Settings.Default.isToggleSound);

            MessageBox.Show(message);
        }*/

        /*private static void ToggleSound(bool enabled)
        {
            if (enabled)
                System.Media.SystemSounds.Asterisk.Play();
        }*/

        private void notifyIcon_osuEscape_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            ToggleSystemTray(false);
        }

        private void KeyboardHook_OnKeyPressed(object sender, KeyPressedEventArgs e)
        {
            // Toggle Connection status on properties settings and update switch status 
            Properties.Settings.Default.isAllowConnection = !Properties.Settings.Default.isAllowConnection;
            materialSwitch_osuConnection.Checked = !Properties.Settings.Default.isAllowConnection;
            Firewall.ToggleFirewall();
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
            foreach (Form tmp in Application.OpenForms)
                foreach (System.Windows.Forms.Control temp in tmp.Controls)
                    if (temp.Name == "materialLabel_globalToggleHotkey")
                        temp.Text = "Global Toggle Hotkey: " +
                                    (isCtrl ? "Ctrl + " : "") +
                                    (isShift ? "Shift + " : "") +
                                    (isAlt ? "Alt + " : "") +
                                    Properties.Settings.Default.GlobalHotKey;

            /*materialLabel_globalToggleHotkey.Text = "Global Toggle Hotkey: ";
            materialLabel_globalToggleHotkey.Text += isCtrl ? "Ctrl + " : "";
            materialLabel_globalToggleHotkey.Text += isShift ? "Shift + " : "";
            materialLabel_globalToggleHotkey.Text += isAlt ? "Alt + " : "";
            materialLabel_globalToggleHotkey.Text += Properties.Settings.Default.GlobalHotKey;*/
        }

        private void FormClosing_HomeForm(object sender, FormClosingEventArgs e)
        {
            if (materialSwitch_minimizeToSystemTray.Checked && !isItemQuit)
            {
                // cancel form closing event
                e.Cancel = true;

                this.WindowState = FormWindowState.Minimized;
                ToggleSystemTray(materialSwitch_minimizeToSystemTray.Checked);
                ContextMenuStripUpdate();
            }

            // save the last position of the application
            if (this.WindowState != FormWindowState.Minimized)
                Properties.Settings.Default.appPosition = this.Location;

            Properties.Settings.Default.Save();
        }

        public static bool IsAdministrator()
        {
            using WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }     
       
        private void MainTabResize()
        {
            // set the ui size for main tab
            int unneededWidth = 45;
            int unneededHeight = 130;
            this.MaximumSize = new Size(this.Size.Width - unneededWidth, this.Size.Height - unneededHeight);
            this.Size = new Size(this.Size.Width - unneededWidth, this.Size.Height - unneededHeight);
            this.MinimumSize = new Size(this.Size.Width - unneededWidth, this.Size.Height - unneededHeight);
        }

        private void materialSwitch_theme_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Theme = materialSwitch_theme.Checked ? 1 : 0;
            materialSkinManager.Theme = (MaterialSkinManager.Themes)Properties.Settings.Default.Theme;
        }

        private void materialCheckbox_isFullCombo_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isCheckingFullCombo = materialCheckbox_isFullCombo.Checked;
        }
        private void materialSlider_refreshRate_onValueChanged(object sender, int newValue)
        {
            _readDelay = materialSlider_refreshRate.Value < 50 ? 50 : materialSlider_refreshRate.Value;

            Properties.Settings.Default.refreshRate = materialSlider_refreshRate.Value;
        }

        private void materialSlider_Accuracy_onValueChanged(object sender, int newValue)
        {
            Properties.Settings.Default.submitAcc = materialSlider_Accuracy.Value;
        }
    }
}