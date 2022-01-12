namespace osuEscape
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.materialTabControl_menu = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage_main = new System.Windows.Forms.TabPage();
            this.materialLabel_globalToggleHotkey = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel_osuPath = new MaterialSkin.Controls.MaterialLabel();
            this.materialSwitch_osuConnection = new MaterialSkin.Controls.MaterialSwitch();
            this.materialLabel_submissionStatus = new MaterialSkin.Controls.MaterialLabel();
            this.tabPage_settings = new System.Windows.Forms.TabPage();
            this.materialSwitch_theme = new MaterialSkin.Controls.MaterialSwitch();
            this.numericUpDown_submitAcc = new System.Windows.Forms.NumericUpDown();
            this.materialSlider_refreshRate = new MaterialSkin.Controls.MaterialSlider();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton_changeToggleKey = new MaterialSkin.Controls.MaterialButton();
            this.materialTextBox_apiInput = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialButton_findOsuLocation = new MaterialSkin.Controls.MaterialButton();
            this.materialButton_checkApi = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel_apiNeeded = new MaterialSkin.Controls.MaterialLabel();
            this.materialSwitch_autoDisconnect = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitch_submitIfFC = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitch_topMost = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitch_toggleWithSound = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitch_minimizeToSystemTray = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitch_runAtStartup = new MaterialSkin.Controls.MaterialSwitch();
            this.materialLabel_focus = new MaterialSkin.Controls.MaterialLabel();
            this.tabPage_uploadedScores = new System.Windows.Forms.TabPage();
            this.contextMenuStrip_osu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon_osuEscape = new System.Windows.Forms.NotifyIcon(this.components);
            this.materialTabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.materialTabControl_menu.SuspendLayout();
            this.tabPage_main.SuspendLayout();
            this.tabPage_settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_submitAcc)).BeginInit();
            this.contextMenuStrip_osu.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl_menu
            // 
            this.materialTabControl_menu.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.materialTabControl_menu.Controls.Add(this.tabPage_main);
            this.materialTabControl_menu.Controls.Add(this.tabPage_settings);
            this.materialTabControl_menu.Controls.Add(this.tabPage_uploadedScores);
            this.materialTabControl_menu.Depth = 0;
            this.materialTabControl_menu.Location = new System.Drawing.Point(3, 105);
            this.materialTabControl_menu.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl_menu.Multiline = true;
            this.materialTabControl_menu.Name = "materialTabControl_menu";
            this.materialTabControl_menu.SelectedIndex = 0;
            this.materialTabControl_menu.Size = new System.Drawing.Size(548, 451);
            this.materialTabControl_menu.TabIndex = 0;
            this.materialTabControl_menu.Selected += new System.Windows.Forms.TabControlEventHandler(this.materialTabControl_menu_Selected);
            // 
            // tabPage_main
            // 
            this.tabPage_main.BackColor = System.Drawing.Color.White;
            this.tabPage_main.Controls.Add(this.materialLabel_globalToggleHotkey);
            this.tabPage_main.Controls.Add(this.materialLabel_osuPath);
            this.tabPage_main.Controls.Add(this.materialSwitch_osuConnection);
            this.tabPage_main.Controls.Add(this.materialLabel_submissionStatus);
            this.tabPage_main.ImageKey = "Home_32.png";
            this.tabPage_main.Location = new System.Drawing.Point(4, 27);
            this.tabPage_main.Name = "tabPage_main";
            this.tabPage_main.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_main.Size = new System.Drawing.Size(540, 420);
            this.tabPage_main.TabIndex = 0;
            this.tabPage_main.Text = "Main";
            // 
            // materialLabel_globalToggleHotkey
            // 
            this.materialLabel_globalToggleHotkey.AutoSize = true;
            this.materialLabel_globalToggleHotkey.Depth = 0;
            this.materialLabel_globalToggleHotkey.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_globalToggleHotkey.Location = new System.Drawing.Point(20, 88);
            this.materialLabel_globalToggleHotkey.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_globalToggleHotkey.Name = "materialLabel_globalToggleHotkey";
            this.materialLabel_globalToggleHotkey.Size = new System.Drawing.Size(161, 19);
            this.materialLabel_globalToggleHotkey.TabIndex = 23;
            this.materialLabel_globalToggleHotkey.Text = "Global Toggle Hotkey: ";
            // 
            // materialLabel_osuPath
            // 
            this.materialLabel_osuPath.AutoSize = true;
            this.materialLabel_osuPath.Depth = 0;
            this.materialLabel_osuPath.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_osuPath.Location = new System.Drawing.Point(20, 150);
            this.materialLabel_osuPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_osuPath.Name = "materialLabel_osuPath";
            this.materialLabel_osuPath.Size = new System.Drawing.Size(72, 19);
            this.materialLabel_osuPath.TabIndex = 22;
            this.materialLabel_osuPath.Text = "osu! Path:";
            // 
            // materialSwitch_osuConnection
            // 
            this.materialSwitch_osuConnection.AutoSize = true;
            this.materialSwitch_osuConnection.Depth = 0;
            this.materialSwitch_osuConnection.Location = new System.Drawing.Point(20, 24);
            this.materialSwitch_osuConnection.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_osuConnection.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_osuConnection.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_osuConnection.Name = "materialSwitch_osuConnection";
            this.materialSwitch_osuConnection.Ripple = true;
            this.materialSwitch_osuConnection.Size = new System.Drawing.Size(215, 37);
            this.materialSwitch_osuConnection.TabIndex = 18;
            this.materialSwitch_osuConnection.Text = "Block osu! Connection";
            this.materialSwitch_osuConnection.UseVisualStyleBackColor = true;
            this.materialSwitch_osuConnection.CheckedChanged += new System.EventHandler(this.materialSwitch_osuConnection_CheckedChanged);
            // 
            // materialLabel_submissionStatus
            // 
            this.materialLabel_submissionStatus.AutoSize = true;
            this.materialLabel_submissionStatus.Depth = 0;
            this.materialLabel_submissionStatus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_submissionStatus.Location = new System.Drawing.Point(20, 213);
            this.materialLabel_submissionStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_submissionStatus.Name = "materialLabel_submissionStatus";
            this.materialLabel_submissionStatus.Size = new System.Drawing.Size(143, 19);
            this.materialLabel_submissionStatus.TabIndex = 12;
            this.materialLabel_submissionStatus.Text = "Submission Status: ";
            // 
            // tabPage_settings
            // 
            this.tabPage_settings.BackColor = System.Drawing.Color.White;
            this.tabPage_settings.Controls.Add(this.materialSwitch_theme);
            this.tabPage_settings.Controls.Add(this.numericUpDown_submitAcc);
            this.tabPage_settings.Controls.Add(this.materialSlider_refreshRate);
            this.tabPage_settings.Controls.Add(this.materialLabel1);
            this.tabPage_settings.Controls.Add(this.materialButton_changeToggleKey);
            this.tabPage_settings.Controls.Add(this.materialTextBox_apiInput);
            this.tabPage_settings.Controls.Add(this.materialButton_findOsuLocation);
            this.tabPage_settings.Controls.Add(this.materialButton_checkApi);
            this.tabPage_settings.Controls.Add(this.materialLabel_apiNeeded);
            this.tabPage_settings.Controls.Add(this.materialSwitch_autoDisconnect);
            this.tabPage_settings.Controls.Add(this.materialSwitch_submitIfFC);
            this.tabPage_settings.Controls.Add(this.materialSwitch_topMost);
            this.tabPage_settings.Controls.Add(this.materialSwitch_toggleWithSound);
            this.tabPage_settings.Controls.Add(this.materialSwitch_minimizeToSystemTray);
            this.tabPage_settings.Controls.Add(this.materialSwitch_runAtStartup);
            this.tabPage_settings.Controls.Add(this.materialLabel_focus);
            this.tabPage_settings.ImageKey = "Setting_32.png";
            this.tabPage_settings.Location = new System.Drawing.Point(4, 27);
            this.tabPage_settings.Name = "tabPage_settings";
            this.tabPage_settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings.Size = new System.Drawing.Size(540, 420);
            this.tabPage_settings.TabIndex = 1;
            this.tabPage_settings.Text = "Settings";
            // 
            // materialSwitch_theme
            // 
            this.materialSwitch_theme.AutoSize = true;
            this.materialSwitch_theme.Depth = 0;
            this.materialSwitch_theme.Location = new System.Drawing.Point(3, 150);
            this.materialSwitch_theme.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_theme.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_theme.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_theme.Name = "materialSwitch_theme";
            this.materialSwitch_theme.Ripple = true;
            this.materialSwitch_theme.Size = new System.Drawing.Size(144, 37);
            this.materialSwitch_theme.TabIndex = 30;
            this.materialSwitch_theme.TabStop = false;
            this.materialSwitch_theme.Text = "Dark Theme";
            this.materialSwitch_theme.UseVisualStyleBackColor = true;
            this.materialSwitch_theme.CheckedChanged += new System.EventHandler(this.materialSwitch_theme_CheckedChanged);
            // 
            // numericUpDown_submitAcc
            // 
            this.numericUpDown_submitAcc.AutoSize = true;
            this.numericUpDown_submitAcc.Location = new System.Drawing.Point(207, 194);
            this.numericUpDown_submitAcc.Name = "numericUpDown_submitAcc";
            this.numericUpDown_submitAcc.Size = new System.Drawing.Size(50, 23);
            this.numericUpDown_submitAcc.TabIndex = 29;
            this.numericUpDown_submitAcc.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_submitAcc.ValueChanged += new System.EventHandler(this.numericUpDown_submitAcc_ValueChanged);
            // 
            // materialSlider_refreshRate
            // 
            this.materialSlider_refreshRate.Depth = 0;
            this.materialSlider_refreshRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialSlider_refreshRate.Location = new System.Drawing.Point(376, 40);
            this.materialSlider_refreshRate.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSlider_refreshRate.Name = "materialSlider_refreshRate";
            this.materialSlider_refreshRate.RangeMax = 1000;
            this.materialSlider_refreshRate.RangeMin = 50;
            this.materialSlider_refreshRate.Size = new System.Drawing.Size(146, 40);
            this.materialSlider_refreshRate.TabIndex = 28;
            this.materialSlider_refreshRate.Text = "";
            this.materialSlider_refreshRate.UseAccentColor = true;
            this.materialSlider_refreshRate.Click += new System.EventHandler(this.materialSlider_refreshRate_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(374, 18);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(123, 19);
            this.materialLabel1.TabIndex = 27;
            this.materialLabel1.Text = "Refresh rate (ms)";
            // 
            // materialButton_changeToggleKey
            // 
            this.materialButton_changeToggleKey.AutoSize = false;
            this.materialButton_changeToggleKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton_changeToggleKey.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton_changeToggleKey.Depth = 0;
            this.materialButton_changeToggleKey.HighEmphasis = true;
            this.materialButton_changeToggleKey.Icon = null;
            this.materialButton_changeToggleKey.Location = new System.Drawing.Point(351, 89);
            this.materialButton_changeToggleKey.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton_changeToggleKey.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton_changeToggleKey.Name = "materialButton_changeToggleKey";
            this.materialButton_changeToggleKey.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton_changeToggleKey.Size = new System.Drawing.Size(181, 41);
            this.materialButton_changeToggleKey.TabIndex = 26;
            this.materialButton_changeToggleKey.TabStop = false;
            this.materialButton_changeToggleKey.Text = "Change Toggle Key";
            this.materialButton_changeToggleKey.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.materialButton_changeToggleKey.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton_changeToggleKey.UseAccentColor = true;
            this.materialButton_changeToggleKey.UseVisualStyleBackColor = true;
            this.materialButton_changeToggleKey.Click += new System.EventHandler(this.MaterialButton_changeToggleKey_Click);
            // 
            // materialTextBox_apiInput
            // 
            this.materialTextBox_apiInput.AnimateReadOnly = false;
            this.materialTextBox_apiInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox_apiInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox_apiInput.Depth = 0;
            this.materialTextBox_apiInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox_apiInput.HideSelection = true;
            this.materialTextBox_apiInput.LeadingIcon = null;
            this.materialTextBox_apiInput.Location = new System.Drawing.Point(13, 255);
            this.materialTextBox_apiInput.MaxLength = 255;
            this.materialTextBox_apiInput.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox_apiInput.Name = "materialTextBox_apiInput";
            this.materialTextBox_apiInput.PasswordChar = '●';
            this.materialTextBox_apiInput.PrefixSuffixText = null;
            this.materialTextBox_apiInput.ReadOnly = false;
            this.materialTextBox_apiInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox_apiInput.SelectedText = "";
            this.materialTextBox_apiInput.SelectionLength = 0;
            this.materialTextBox_apiInput.SelectionStart = 0;
            this.materialTextBox_apiInput.ShortcutsEnabled = true;
            this.materialTextBox_apiInput.Size = new System.Drawing.Size(399, 36);
            this.materialTextBox_apiInput.TabIndex = 23;
            this.materialTextBox_apiInput.TabStop = false;
            this.materialTextBox_apiInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox_apiInput.TrailingIcon = null;
            this.materialTextBox_apiInput.UseSystemPasswordChar = true;
            this.materialTextBox_apiInput.UseTallSize = false;
            // 
            // materialButton_findOsuLocation
            // 
            this.materialButton_findOsuLocation.AutoSize = false;
            this.materialButton_findOsuLocation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton_findOsuLocation.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton_findOsuLocation.Depth = 0;
            this.materialButton_findOsuLocation.HighEmphasis = true;
            this.materialButton_findOsuLocation.Icon = null;
            this.materialButton_findOsuLocation.Location = new System.Drawing.Point(339, 142);
            this.materialButton_findOsuLocation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton_findOsuLocation.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton_findOsuLocation.Name = "materialButton_findOsuLocation";
            this.materialButton_findOsuLocation.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton_findOsuLocation.Size = new System.Drawing.Size(193, 41);
            this.materialButton_findOsuLocation.TabIndex = 22;
            this.materialButton_findOsuLocation.TabStop = false;
            this.materialButton_findOsuLocation.Text = "find osu!.exe location";
            this.materialButton_findOsuLocation.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton_findOsuLocation.UseAccentColor = true;
            this.materialButton_findOsuLocation.UseVisualStyleBackColor = true;
            this.materialButton_findOsuLocation.Click += new System.EventHandler(this.MaterialButton_findOsuLocation_Click);
            // 
            // materialButton_checkApi
            // 
            this.materialButton_checkApi.AutoSize = false;
            this.materialButton_checkApi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton_checkApi.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton_checkApi.Depth = 0;
            this.materialButton_checkApi.HighEmphasis = true;
            this.materialButton_checkApi.Icon = null;
            this.materialButton_checkApi.Location = new System.Drawing.Point(428, 256);
            this.materialButton_checkApi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton_checkApi.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton_checkApi.Name = "materialButton_checkApi";
            this.materialButton_checkApi.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton_checkApi.Size = new System.Drawing.Size(56, 34);
            this.materialButton_checkApi.TabIndex = 18;
            this.materialButton_checkApi.TabStop = false;
            this.materialButton_checkApi.Text = "Verify";
            this.materialButton_checkApi.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton_checkApi.UseAccentColor = true;
            this.materialButton_checkApi.UseVisualStyleBackColor = true;
            this.materialButton_checkApi.Click += new System.EventHandler(this.materialButton_checkApi_Click);
            // 
            // materialLabel_apiNeeded
            // 
            this.materialLabel_apiNeeded.AutoSize = true;
            this.materialLabel_apiNeeded.Depth = 0;
            this.materialLabel_apiNeeded.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_apiNeeded.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel_apiNeeded.Location = new System.Drawing.Point(14, 229);
            this.materialLabel_apiNeeded.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_apiNeeded.Name = "materialLabel_apiNeeded";
            this.materialLabel_apiNeeded.Size = new System.Drawing.Size(131, 17);
            this.materialLabel_apiNeeded.TabIndex = 8;
            this.materialLabel_apiNeeded.Text = "API required options";
            // 
            // materialSwitch_autoDisconnect
            // 
            this.materialSwitch_autoDisconnect.AutoSize = true;
            this.materialSwitch_autoDisconnect.Depth = 0;
            this.materialSwitch_autoDisconnect.Enabled = false;
            this.materialSwitch_autoDisconnect.Location = new System.Drawing.Point(3, 300);
            this.materialSwitch_autoDisconnect.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_autoDisconnect.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_autoDisconnect.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_autoDisconnect.Name = "materialSwitch_autoDisconnect";
            this.materialSwitch_autoDisconnect.Ripple = true;
            this.materialSwitch_autoDisconnect.Size = new System.Drawing.Size(317, 37);
            this.materialSwitch_autoDisconnect.TabIndex = 16;
            this.materialSwitch_autoDisconnect.TabStop = false;
            this.materialSwitch_autoDisconnect.Text = "Disconnect after score upload (Auto)";
            this.materialSwitch_autoDisconnect.UseVisualStyleBackColor = true;
            this.materialSwitch_autoDisconnect.CheckedChanged += new System.EventHandler(this.materialCheckbox_autoDisconnect_CheckedChanged);
            // 
            // materialSwitch_submitIfFC
            // 
            this.materialSwitch_submitIfFC.AutoSize = true;
            this.materialSwitch_submitIfFC.Depth = 0;
            this.materialSwitch_submitIfFC.Location = new System.Drawing.Point(3, 186);
            this.materialSwitch_submitIfFC.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_submitIfFC.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_submitIfFC.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_submitIfFC.Name = "materialSwitch_submitIfFC";
            this.materialSwitch_submitIfFC.Ripple = true;
            this.materialSwitch_submitIfFC.Size = new System.Drawing.Size(372, 37);
            this.materialSwitch_submitIfFC.TabIndex = 15;
            this.materialSwitch_submitIfFC.TabStop = false;
            this.materialSwitch_submitIfFC.Text = "Connect if FC with ≥               Accuracy (Auto)";
            this.materialSwitch_submitIfFC.UseVisualStyleBackColor = true;
            this.materialSwitch_submitIfFC.CheckedChanged += new System.EventHandler(this.materialCheckbox_submitIfFC_CheckedChanged);
            // 
            // materialSwitch_topMost
            // 
            this.materialSwitch_topMost.AutoSize = true;
            this.materialSwitch_topMost.Depth = 0;
            this.materialSwitch_topMost.Location = new System.Drawing.Point(3, 113);
            this.materialSwitch_topMost.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_topMost.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_topMost.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_topMost.Name = "materialSwitch_topMost";
            this.materialSwitch_topMost.Ripple = true;
            this.materialSwitch_topMost.Size = new System.Drawing.Size(159, 37);
            this.materialSwitch_topMost.TabIndex = 13;
            this.materialSwitch_topMost.TabStop = false;
            this.materialSwitch_topMost.Text = "Always at Top";
            this.materialSwitch_topMost.UseVisualStyleBackColor = true;
            this.materialSwitch_topMost.CheckedChanged += new System.EventHandler(this.materialCheckbox_topMost_CheckedChanged);
            // 
            // materialSwitch_toggleWithSound
            // 
            this.materialSwitch_toggleWithSound.AutoSize = true;
            this.materialSwitch_toggleWithSound.Depth = 0;
            this.materialSwitch_toggleWithSound.Location = new System.Drawing.Point(3, 77);
            this.materialSwitch_toggleWithSound.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_toggleWithSound.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_toggleWithSound.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_toggleWithSound.Name = "materialSwitch_toggleWithSound";
            this.materialSwitch_toggleWithSound.Ripple = true;
            this.materialSwitch_toggleWithSound.Size = new System.Drawing.Size(191, 37);
            this.materialSwitch_toggleWithSound.TabIndex = 12;
            this.materialSwitch_toggleWithSound.TabStop = false;
            this.materialSwitch_toggleWithSound.Text = "Toggle with Sound";
            this.materialSwitch_toggleWithSound.UseVisualStyleBackColor = true;
            this.materialSwitch_toggleWithSound.CheckedChanged += new System.EventHandler(this.materialCheckbox_toggleWithSound_CheckedChanged);
            // 
            // materialSwitch_minimizeToSystemTray
            // 
            this.materialSwitch_minimizeToSystemTray.AutoSize = true;
            this.materialSwitch_minimizeToSystemTray.Depth = 0;
            this.materialSwitch_minimizeToSystemTray.Location = new System.Drawing.Point(3, 40);
            this.materialSwitch_minimizeToSystemTray.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_minimizeToSystemTray.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_minimizeToSystemTray.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_minimizeToSystemTray.Name = "materialSwitch_minimizeToSystemTray";
            this.materialSwitch_minimizeToSystemTray.Ripple = true;
            this.materialSwitch_minimizeToSystemTray.Size = new System.Drawing.Size(234, 37);
            this.materialSwitch_minimizeToSystemTray.TabIndex = 10;
            this.materialSwitch_minimizeToSystemTray.TabStop = false;
            this.materialSwitch_minimizeToSystemTray.Text = "Minimize to System Tray";
            this.materialSwitch_minimizeToSystemTray.UseVisualStyleBackColor = true;
            this.materialSwitch_minimizeToSystemTray.CheckedChanged += new System.EventHandler(this.materialCheckbox_minimizeToSystemTray_CheckedChanged);
            // 
            // materialSwitch_runAtStartup
            // 
            this.materialSwitch_runAtStartup.AutoSize = true;
            this.materialSwitch_runAtStartup.Depth = 0;
            this.materialSwitch_runAtStartup.Location = new System.Drawing.Point(3, 3);
            this.materialSwitch_runAtStartup.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_runAtStartup.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_runAtStartup.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_runAtStartup.Name = "materialSwitch_runAtStartup";
            this.materialSwitch_runAtStartup.Ripple = true;
            this.materialSwitch_runAtStartup.Size = new System.Drawing.Size(160, 37);
            this.materialSwitch_runAtStartup.TabIndex = 11;
            this.materialSwitch_runAtStartup.TabStop = false;
            this.materialSwitch_runAtStartup.Text = "Run at Startup";
            this.materialSwitch_runAtStartup.UseVisualStyleBackColor = true;
            this.materialSwitch_runAtStartup.CheckedChanged += new System.EventHandler(this.materialCheckbox_runAtStartup_CheckedChanged);
            // 
            // materialLabel_focus
            // 
            this.materialLabel_focus.AutoSize = true;
            this.materialLabel_focus.Depth = 0;
            this.materialLabel_focus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_focus.Location = new System.Drawing.Point(408, 154);
            this.materialLabel_focus.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_focus.Name = "materialLabel_focus";
            this.materialLabel_focus.Size = new System.Drawing.Size(103, 19);
            this.materialLabel_focus.TabIndex = 24;
            this.materialLabel_focus.Text = "label for focus";
            // 
            // tabPage_uploadedScores
            // 
            this.tabPage_uploadedScores.Location = new System.Drawing.Point(4, 27);
            this.tabPage_uploadedScores.Name = "tabPage_uploadedScores";
            this.tabPage_uploadedScores.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_uploadedScores.Size = new System.Drawing.Size(540, 420);
            this.tabPage_uploadedScores.TabIndex = 2;
            this.tabPage_uploadedScores.Text = "Uploaded Scores";
            this.tabPage_uploadedScores.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip_osu
            // 
            this.contextMenuStrip_osu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextMenuStrip_osu.Name = "contextMenuStrip_osu";
            this.contextMenuStrip_osu.Size = new System.Drawing.Size(113, 48);
            this.contextMenuStrip_osu.Text = "osu!Escape";
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.statusToolStripMenuItem.Text = "Status: ";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // notifyIcon_osuEscape
            // 
            this.notifyIcon_osuEscape.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_osuEscape.Icon")));
            this.notifyIcon_osuEscape.Text = "osu!Escape";
            this.notifyIcon_osuEscape.Visible = true;
            this.notifyIcon_osuEscape.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_osuEscape_MouseDoubleClick);
            // 
            // materialTabSelector
            // 
            this.materialTabSelector.BaseTabControl = this.materialTabControl_menu;
            this.materialTabSelector.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            this.materialTabSelector.Depth = 0;
            this.materialTabSelector.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTabSelector.Location = new System.Drawing.Point(0, 64);
            this.materialTabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector.Name = "materialTabSelector";
            this.materialTabSelector.Size = new System.Drawing.Size(553, 35);
            this.materialTabSelector.TabIndex = 1;
            this.materialTabSelector.TabStop = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(553, 497);
            this.Controls.Add(this.materialTabSelector);
            this.Controls.Add(this.materialTabControl_menu);
            this.DrawerShowIconsWhenHidden = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "HomeForm";
            this.Text = "osu! Escape";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HomeForm_FormClosing);
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HomeForm_KeyDown);
            this.materialTabControl_menu.ResumeLayout(false);
            this.tabPage_main.ResumeLayout(false);
            this.tabPage_main.PerformLayout();
            this.tabPage_settings.ResumeLayout(false);
            this.tabPage_settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_submitAcc)).EndInit();
            this.contextMenuStrip_osu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl_menu;
        private System.Windows.Forms.TabPage tabPage_main;
        private System.Windows.Forms.TabPage tabPage_settings;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_runAtStartup;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_minimizeToSystemTray;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_toggleWithSound;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_topMost;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_submitIfFC;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_autoDisconnect;
        private MaterialSkin.Controls.MaterialLabel materialLabel_apiNeeded;
        private MaterialSkin.Controls.MaterialButton materialButton_checkApi;
        private MaterialSkin.Controls.MaterialLabel materialLabel_submissionStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_osu;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon_osuEscape;
        private MaterialSkin.Controls.MaterialButton materialButton_findOsuLocation;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox_apiInput;
        private MaterialSkin.Controls.MaterialButton materialButton_changeToggleKey;
        private System.Windows.Forms.ToolTip toolTips;
        private MaterialSkin.Controls.MaterialSlider materialSlider_refreshRate;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel_focus;
        private System.Windows.Forms.NumericUpDown numericUpDown_submitAcc;
        private System.Windows.Forms.TabPage tabPage_uploadedScores;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_osuConnection;
        private MaterialSkin.Controls.MaterialLabel materialLabel_globalToggleHotkey;
        private MaterialSkin.Controls.MaterialLabel materialLabel_osuPath;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_theme;
    }
}