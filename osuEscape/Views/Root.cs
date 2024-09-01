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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osuEscape
{
    public partial class Root : MaterialForm
    {
        private const string VersionControlAddress = "https://pastebin.com/5hDSctE0";
        private readonly MainForm _mainForm;
        private readonly SettingsForm _settingsForm;
        private readonly UploadedScoresForm _uploadedScoresForm;

        private Size mainFormSize;
        private Size settingsFormSize;
        private Size uploadedScoresFormSize;

        // osu! data reader
        private readonly string _osuWindowTitleHint;
        private readonly int _readDelay = 50;
        private readonly StructuredOsuMemoryReader _sreader;
        private readonly CancellationTokenSource cts = new();

        // Hotkey
        // Keyboard hook for multiple keys
        public readonly KeyboardHook keyboardHook = new();
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

        // score upload
        private static readonly HttpClient client = new();
        private static int beatmapLastNoteOffset = Int32.MinValue;

        // material skin ui
        public readonly MaterialSkinManager materialSkinManager;

        // startup
        private static readonly string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private static readonly string StartupValue = Assembly.GetExecutingAssembly().GetName().Name;

        private bool isItemQuit = false;
        private bool isSetScore = false;
        private string previousSubmittedBeatmapMd5 = string.Empty;
        private bool isOffsetFound = false;
        private bool isSnipedScoreFound = false;

        // Encapsulation starts here
        public MainForm MainForm => _mainForm;
        public SettingsForm SettingsForm => _settingsForm;
        public UploadedScoresForm UploadedScoresForm => _uploadedScoresForm;

        public Root(string osuWindowTitleHint)
        {
            _osuWindowTitleHint = osuWindowTitleHint;
            _mainForm = new MainForm(this);
            _settingsForm = new SettingsForm();
            _uploadedScoresForm = new UploadedScoresForm();

            mainFormSize = _mainForm.Size;
            settingsFormSize = _settingsForm.Size;
            uploadedScoresFormSize = _uploadedScoresForm.Size;

            // Initialize material skin manager
            FormStyleManager.AddFormToManage(this);

            InitializeComponent();

            _sreader = StructuredOsuMemoryReader.Instance.GetInstanceForWindowTitleHint(osuWindowTitleHint);

            // For UI resizing
            // Design editor pixels height offset (50px)
            Size = new Size(Size.Width, Size.Height);

            // Avoid opening osu!Escape twice
            if (Process.GetProcessesByName("osuEscape").Length > 1)
            {
                notifyIcon_osuEscape.Visible = false;
                Close();
            }

            // Hotkey
            keyboardHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(KeyboardHook_OnKeyPressed);
            keyboardHook.RegisterHotKey((ModifierKeys)Properties.Settings.Default.ModifierKeys,
                                        KeysToStringDictionary.FirstOrDefault(x => x.Value == Properties.Settings.Default.GlobalHotKey).Key);

            // UI 
            Resize();
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

        private static Form ConvertFormToTabPage(Form f)
        {
            f.TopLevel = false;
            f.Visible = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            return f;
        }

        private async void Root_Load(object sender, EventArgs e)
        {
            materialTabControl_menu.TabPages[0].Controls.Clear();
            materialTabControl_menu.TabPages[1].Controls.Clear();
            materialTabControl_menu.TabPages[2].Controls.Clear();
            materialTabControl_menu.TabPages[0].Controls.Add(ConvertFormToTabPage(_mainForm));
            materialTabControl_menu.TabPages[1].Controls.Add(ConvertFormToTabPage(_settingsForm));
            materialTabControl_menu.TabPages[2].Controls.Add(ConvertFormToTabPage(_uploadedScoresForm));

            // Check if osu!Escape is already opened 
            if (Process.GetProcessesByName(Name).Length > 1)
                Close();

            // Check administrator privileges
            if (!IsAdministrator())
            {
                MessageBox.Show("Please open osu!Escape with administrator privileges for toggling firewall permission.");
                Close();
            }

            osuDataReaderAsync();

            // Open the app at the previous position (location on window) 
            Location = Properties.Settings.Default.appPosition;

            #region Check for Update
            HttpClient httpClient = new();
            // Compare versions instead of string comparison
            Version expectedVersion = new(await httpClient.GetStringAsync(VersionControlAddress));
            Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;

            // Compare versions instead of string comparison
            if (currentVersion < expectedVersion)
            {
                if (MessageBox.Show($"This version is outdated! Please download the latest version at GitHub's release page. {Environment.NewLine}" +
                    $"Current Version: {currentVersion}; Expected Version: {expectedVersion}",
                    "osu!Escape",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _ = Process.Start(new ProcessStartInfo("https://github.com/Koltay/osuEscape/releases/") { UseShellExecute = true });
                }
            }
            #endregion
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

                        // Beatmap Offset
                        // Only read the audio offset if it is not the previous beatmap
                        if (!isOffsetFound)
                        {
                            try
                            {
                                await Task.Run(async () =>
                                {
                                    string beatmapFile = $"{Properties.Settings.Default.osuPath}\\Songs\\{baseAddresses.Beatmap.FolderName}\\{baseAddresses.Beatmap.OsuFileName}";

                                    await Task.Run(() =>
                                    {
                                        beatmapLastNoteOffset = 0;

                                        foreach (string str in File.ReadLines(beatmapFile).Last().Split(","))
                                        {
                                            if (Int32.TryParse(str, out var value))
                                                beatmapLastNoteOffset = Math.Max(beatmapLastNoteOffset, value);
                                        }

                                        Debug.WriteLine($"Beatmap last note offset before adding slider value: {beatmapLastNoteOffset}");
                                        // Special case: slider (and reverse slider)
                                        // Hit object syntax: x,y,time,type,hitSound,curveType|curvePoints,slides,length,edgeSounds,edgeSets,hitSample
                                        // Old: 0,2 and 6 mean slider in type
                                        // New: use | to determine if it is a hitobject with type "slider"

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

                                        // Slider
                                        if (File.ReadLines(beatmapFile).Last().Contains('|') && beatmapMode == '0')
                                        {
                                            // [7] is the slider pixel length of slider (syntax above)
                                            decimal sliderPixelLength = Convert.ToDecimal(File.ReadLines(beatmapFile).Last().Split(",")[7]);

                                            // Reverse slider's repeat count
                                            int revSliderRepeatCount = Convert.ToInt32(File.ReadLines(beatmapFile).Last().Split(",")[6]);

                                            decimal sliderMultiplier = 1;
                                            decimal beatLength = 1;
                                            decimal BPM = 1;
                                            decimal sliderVelocity = 1;
                                            int difficultySessionIndex = 0;
                                            int timingPointSessionIndex = 0;
                                            int sliderLengthOffset = 0;
                                            bool uninherited = true;

                                            // Locate the sessions: difficulty and timing
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

                                            // Difficulty session to find slider multiplier
                                            for (int i = difficultySessionIndex + 1; i < beatmapFileLines.Length; i++)
                                            {
                                                if (!beatmapFileLines[i].Contains(':'))
                                                    break;

                                                if (File.ReadAllLines(beatmapFile)[i].Contains("SliderMultiplier:"))
                                                {
                                                    sliderMultiplier = Convert.ToDecimal(File.ReadAllLines(beatmapFile)[i][17..]);
                                                    Debug.WriteLine("Slider Multiplier: " + sliderMultiplier);
                                                }
                                            }

                                            // Timing point syntax: time,beatLength,meter,sampleSet,sampleIndex,volume,uninherited,effects
                                            // Depends on format version, old format only contains time, beatLength
                                            for (int i = timingPointSessionIndex + 1; i < beatmapFileLines.Length; i++)
                                            {
                                                // Check the corresponding timing point
                                                if (!beatmapFileLines[i].Contains(','))
                                                    break;

                                                // Only find the timing point before the last note
                                                if (Convert.ToInt32(File.ReadAllLines(beatmapFile)[i].Split(",")[0]) <= beatmapLastNoteOffset)
                                                {
                                                    beatLength = Convert.ToDecimal(File.ReadAllLines(beatmapFile)[i].Split(",")[1]);

                                                    // Uninherited == 1, red line
                                                    if (File.ReadAllLines(beatmapFile)[i].Split(",").Length >= 7)
                                                    {
                                                        if (Convert.ToInt32(File.ReadAllLines(beatmapFile)[i].Split(",")[6]) == 1)
                                                        {
                                                            BPM = 60000 / Convert.ToDecimal(File.ReadAllLines(beatmapFile)[i].Split(",")[1]);
                                                            uninherited = true;
                                                        }
                                                        else
                                                            uninherited = false;
                                                    }
                                                }
                                            }

                                            if (!uninherited)
                                                sliderVelocity = -100 / beatLength;

                                            sliderLengthOffset = (int)Math.Abs(Math.Round(600 * sliderPixelLength / (BPM * sliderMultiplier * sliderVelocity)));
                                            beatmapLastNoteOffset += (sliderLengthOffset * revSliderRepeatCount);

                                            Debug.WriteLine($"Beatmap id: {baseAddresses.Beatmap.Id}");
                                            Debug.WriteLine($"Beatmap name: {baseAddresses.Beatmap.MapString}");

                                            Debug.WriteLine("Beatmap BPM: " + BPM);
                                            Debug.WriteLine("Beatmap slider uninherited?: " + uninherited);
                                            Debug.WriteLine("Beatmap slider length offset: " + sliderLengthOffset);
                                            Debug.WriteLine("Beatmap slider repeat count:" + revSliderRepeatCount);
                                        }
                                    });
                                    isOffsetFound = true;
                                    Debug.WriteLine("Offset Found!");
                                    Debug.WriteLine("Beatmap last note offset: " + beatmapLastNoteOffset);
                                });
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex);
                            }
                        }

                        // Snipe Mode
                        // Only read the user's score if the mode is enabled
                        if (!isSnipedScoreFound)
                        {
                            try
                            {
                                await Task.Run(async () =>
                                {
                                    string username = Properties.Settings.Default.snipedUser;

                                    int snipedUserScore = await GetSnipedUserBeatmapScoreAsync(Properties.Settings.Default.snipedUser,
                                                                                                baseAddresses.Beatmap.Id,
                                                                                                baseAddresses.GeneralData.GameMode);

                                    isSnipedScoreFound = true;

                                    Debug.WriteLine($"Sniped Score Found: {snipedUserScore}");
                                });
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex);
                                Debug.WriteLine($"ERROR: Sniped Score Not Found: {ex.Message}");
                            }
                        }

                        // Automatic Function #1: Auto Connection
                        // 1.   *** It has to be done on playing status for instant connection
                        //      otherwise, connection checking on result screen would cause about 30 seconds or more
                        // 2.   Use beatmap's last HitObject's offset to determine if the map ended
                        // 3.   Determine if it meets the requirement (acc, fc)
                        //      "FC": 0 misscount / dropped some sliderends / sliderbreak at start
                        // 4.   Submit if it meets the requirement, and it has to be not a replay and the map has a leaderboard (qualifed/ ranked/ loved)
                        // 5.   Disable the block rule to connect to the server
                        // 6.   Verify Md5 to avoid false auto connection on same beatmap set

                        if (Properties.Settings.Default.isSubmitIfFC &&
                            baseAddresses.GeneralData.AudioTime >= beatmapLastNoteOffset &&
                            baseAddresses.GeneralData.AudioTime >= 12000 && // Shortest map in ranked 
                            baseAddresses.Player.MaxCombo >= 1 && // Least combo required
                            isOffsetFound &&
                            baseAddresses.Player.HitMiss == 0 &&
                            (!Properties.Settings.Default.isCheckingFullCombo || baseAddresses.Player.Combo == baseAddresses.Player.MaxCombo) &&
                            baseAddresses.Player.Accuracy >= Properties.Settings.Default.submitAcc &&
                            !Properties.Settings.Default.isAllowConnection &&
                            previousSubmittedBeatmapMd5 != baseAddresses.Beatmap.Md5 &&
                            isSubmittableBeatmapStatus()
                            )
                        {
                            Properties.Settings.Default.isAllowConnection = true;
                            Firewall.Toggle();
                            isSetScore = true;

                            _mainForm.Controls["materialLabel_submissionStatus"].BeginInvoke((MethodInvoker)delegate
                            {
                                _mainForm.materialLabel_SubmissionStatus_TextChanged("Uploading recent score...");
                            });

                            Debug.WriteLine("Submission: uploading recent score.");
                        }
                    }
                    else
                    {
                        baseAddresses.LeaderBoard.Players.Clear();
                        isOffsetFound = false;
                    }

                    // Automatic Function #2: Auto Disconnection
                    if (isSetScore &&
                        Properties.Settings.Default.isAutoDisconnect &&
                        Properties.Settings.Default.isAllowConnection &&
                        isSubmittableBeatmapStatus())
                    {
                        previousSubmittedBeatmapMd5 = baseAddresses.Beatmap.Md5;

                        // Submission frequency test
                        await Task.Delay(50);

                        // GET Method of user's recent score (osu! api v1)
                        // Get the recent 3 scores, as there might be multiple submissions at one connection
                        // So that the recent set score could be recognized

                        int checkScoresCount = 3;

                        JArray jarr = await GetUserRecentScoreAsync(baseAddresses.Player.Username, baseAddresses.Player.Mode, checkScoresCount);

                        bool isRecentSetScoreUploaded = false;

                        foreach (var element in jarr)
                        {
                            if (Convert.ToInt32(element["beatmap_id"]) == baseAddresses.Beatmap.Id &&
                                Convert.ToInt32(element["score"]) == baseAddresses.Player.Score)
                            {
                                isRecentSetScoreUploaded = true;

                                Properties.Settings.Default.isAllowConnection = false;
                                Firewall.Toggle();

                                isSetScore = false;

                                // Uploaded scores tab page update
                                _uploadedScoresForm.UpdateScores(baseAddresses);

                                // Submission status update
                                _mainForm.Controls["materialLabel_submissionStatus"].BeginInvoke((MethodInvoker)delegate
                                {
                                    string text = isRecentSetScoreUploaded ? "Uploaded recent score." : "";
                                    _mainForm.materialLabel_SubmissionStatus_TextChanged(text);
                                });

                                Debug.WriteLine("Submission: Uploaded recent score.");

                                break;
                            }
                        }
                    }

                    bool isSubmittableBeatmapStatus()
                    {
                        // Disable isreplay for testing
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

        #endregion

        #region CheckBoxes related 

        #region Run at Startup
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
        #endregion

        #region System Tray
        private void ToggleSystemTray(bool enabled)
        {
            ShowInTaskbar = !enabled;
        }

        #endregion

        #region ContextMenuStrip
        public void ContextMenuStripUpdate()
        {
            notifyIcon_osuEscape.ContextMenuStrip = contextMenuStrip_osu;

            // Status Update
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
            Close();
        }

        #endregion

        #endregion

        #region Global HotKey        

        #endregion

        #region GET Method from osu! api   
        private static async Task<JArray> GetUserRecentScoreAsync(string userName, int mode, int recentScoreLimits)
        {
            var url = $"https://osu.ppy.sh/api/get_user_recent?k={Properties.Settings.Default.userApiKey}&u={userName}&m={mode}&limit={recentScoreLimits}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer");
            request.Content = new StringContent("{...}", Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request, CancellationToken.None);

            if (response.IsSuccessStatusCode)
            {
                var JsonString = await response.Content.ReadAsStringAsync();
                return (JArray)JsonConvert.DeserializeObject(JsonString);
            }
            else
            {
                IncorrectAPITextOutput();
                return null;
            }
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
        #endregion
        private void materialTabControl_menu_Selected(object sender, TabControlEventArgs e)
        {
            Resize();           
        }

        private void notifyIcon_osuEscape_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ToggleSystemTray(false);
        }

        private void KeyboardHook_OnKeyPressed(object sender, KeyPressedEventArgs e)
        {
            // Toggle Connection status on properties settings and update switch status 
            Properties.Settings.Default.isAllowConnection = !Properties.Settings.Default.isAllowConnection;
            Firewall.Toggle();

            ((MaterialSwitch)_mainForm.Controls["materialSwitch_osuConnection"]).Checked = !Properties.Settings.Default.isAllowConnection;
        }

        private void FormClosing_RootForm(object sender, FormClosingEventArgs e)
        {
            if (((MaterialSwitch)_settingsForm.Controls["materialSwitch_isSystemTray"]).Checked && !isItemQuit)
            {
                // Cancel form closing event
                e.Cancel = true;

                WindowState = FormWindowState.Minimized;
                ToggleSystemTray(((MaterialSwitch)_settingsForm.Controls["materialSwitch_isSystemTray"]).Checked);
                ContextMenuStripUpdate();
            }

            // Save the last position of the application
            if (WindowState != FormWindowState.Minimized)
            {
                Properties.Settings.Default.appPosition = Location;
            }

            Properties.Settings.Default.Save();
            notifyIcon_osuEscape.Visible = false;
        }

        public static bool IsAdministrator()
        {
            using WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private new void Resize()
        {
            Size resize = new();

            switch (materialTabControl_menu.SelectedTab)
            {
                case TabPage tabPage when tabPage == tabPage_main:
                    resize = mainFormSize;
                    break;
                case TabPage tabPage when tabPage == tabPage_settings:
                    resize = settingsFormSize;
                    break;
                case TabPage tabPage when tabPage == tabPage_uploadedScores:
                    resize = uploadedScoresFormSize;
                    break;                   
            }

            //offset for tabControl panel
            resize = new Size(resize.Width - 15, resize.Height + 70);

            MaximumSize = resize;
            Size = resize;
            MinimumSize = resize;
        }

        private static async Task<int> GetSnipedUserBeatmapScoreAsync(string userName, int beatmap_id, int mode)
        {
            var url = $"https://osu.ppy.sh/api/get_scores?k={Properties.Settings.Default.userApiKey}&u={userName}&b={beatmap_id}&m={mode}";


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

                int score = 0;

                // find the best score from the sniped user
                foreach (var item in arr)
                {
                    score = Math.Max(Convert.ToInt32(item["score"].ToString()), score); 
                }

                return score;
            }
            else
            {
                IncorrectAPITextOutput();

                return 0;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Ensure the StructuredOsuMemoryReader is not null before disposing
                _sreader?.Dispose();

                // Cancel any ongoing operations before disposing the CancellationTokenSource
                if (cts != null)
                {
                    cts.Cancel();
                    cts.Dispose();
                }

                // Dispose of forms if they have not already been disposed
                _mainForm?.Dispose();
                _settingsForm?.Dispose();
                _uploadedScoresForm?.Dispose();

                // Dispose of the keyboard hook and HttpClient
                keyboardHook?.Dispose();
                client?.Dispose();
            }

            // Call the base class Dispose method
            base.Dispose(disposing);
        }
    }
}
