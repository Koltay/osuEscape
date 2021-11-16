﻿namespace osuEscape
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

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
            this.materialSlider_refreshRate = new MaterialSkin.Controls.MaterialSlider();
            this.groupBox_mapStatus = new System.Windows.Forms.GroupBox();
            this.materialMultiLineTextBox_status = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.materialMultiLineTextBox_currentMapTime = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.materialLabel_currentMapTime = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel_status = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel_submissionStatus = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel_refeshRate = new MaterialSkin.Controls.MaterialLabel();
            this.materialMultiLineTextBox_currentPlayingData = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.materialLabel_currentPlayingData = new MaterialSkin.Controls.MaterialLabel();
            this.materialMultiLineTextBox_mapData = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.materialLabel_MapData = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton_toggle = new MaterialSkin.Controls.MaterialButton();
            this.tabPage_settings = new System.Windows.Forms.TabPage();
            this.materialLabel_saved = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton_changeTheme = new MaterialSkin.Controls.MaterialButton();
            this.materialTextBox_apiInput = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialButton_findOsuLocation = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel_globalToggleHotkey = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel_osuPath = new MaterialSkin.Controls.MaterialLabel();
            this.materialMultiLineTextBox_submitAcc = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.materialButton_checkApi = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel_apiNeeded = new MaterialSkin.Controls.MaterialLabel();
            this.materialCheckbox_autoDisconnect = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialCheckbox_submitIfFC = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialCheckbox_hideData = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialCheckbox_topMost = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialCheckbox_toggleWithSound = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialCheckbox_minimizeToSystemTray = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialCheckbox_runAtStartup = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialLabel_focus = new MaterialSkin.Controls.MaterialLabel();
            this.contextMenuStrip_osu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon_osuEscape = new System.Windows.Forms.NotifyIcon(this.components);
            this.materialTabSelector_main = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl_menu.SuspendLayout();
            this.tabPage_main.SuspendLayout();
            this.groupBox_mapStatus.SuspendLayout();
            this.tabPage_settings.SuspendLayout();
            this.contextMenuStrip_osu.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl_menu
            // 
            this.materialTabControl_menu.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.materialTabControl_menu.Controls.Add(this.tabPage_main);
            this.materialTabControl_menu.Controls.Add(this.tabPage_settings);
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
            this.tabPage_main.Controls.Add(this.materialSlider_refreshRate);
            this.tabPage_main.Controls.Add(this.groupBox_mapStatus);
            this.tabPage_main.Controls.Add(this.materialLabel_submissionStatus);
            this.tabPage_main.Controls.Add(this.materialLabel_refeshRate);
            this.tabPage_main.Controls.Add(this.materialMultiLineTextBox_currentPlayingData);
            this.tabPage_main.Controls.Add(this.materialLabel_currentPlayingData);
            this.tabPage_main.Controls.Add(this.materialMultiLineTextBox_mapData);
            this.tabPage_main.Controls.Add(this.materialLabel_MapData);
            this.tabPage_main.Controls.Add(this.materialButton_toggle);
            this.tabPage_main.ImageKey = "Home_32.png";
            this.tabPage_main.Location = new System.Drawing.Point(4, 27);
            this.tabPage_main.Name = "tabPage_main";
            this.tabPage_main.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_main.Size = new System.Drawing.Size(540, 420);
            this.tabPage_main.TabIndex = 0;
            this.tabPage_main.Text = "Main";
            // 
            // materialSlider_refreshRate
            // 
            this.materialSlider_refreshRate.Depth = 0;
            this.materialSlider_refreshRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialSlider_refreshRate.Location = new System.Drawing.Point(383, 209);
            this.materialSlider_refreshRate.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSlider_refreshRate.Name = "materialSlider_refreshRate";
            this.materialSlider_refreshRate.RangeMax = 1000;
            this.materialSlider_refreshRate.RangeMin = 33;
            this.materialSlider_refreshRate.Size = new System.Drawing.Size(146, 40);
            this.materialSlider_refreshRate.TabIndex = 14;
            this.materialSlider_refreshRate.Text = "";
            this.materialSlider_refreshRate.Click += new System.EventHandler(this.materialSlider_refreshRate_Click);
            // 
            // groupBox_mapStatus
            // 
            this.groupBox_mapStatus.Controls.Add(this.materialMultiLineTextBox_status);
            this.groupBox_mapStatus.Controls.Add(this.materialMultiLineTextBox_currentMapTime);
            this.groupBox_mapStatus.Controls.Add(this.materialLabel_currentMapTime);
            this.groupBox_mapStatus.Controls.Add(this.materialLabel_status);
            this.groupBox_mapStatus.Location = new System.Drawing.Point(376, 59);
            this.groupBox_mapStatus.Name = "groupBox_mapStatus";
            this.groupBox_mapStatus.Size = new System.Drawing.Size(158, 125);
            this.groupBox_mapStatus.TabIndex = 15;
            this.groupBox_mapStatus.TabStop = false;
            // 
            // materialMultiLineTextBox_status
            // 
            this.materialMultiLineTextBox_status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialMultiLineTextBox_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialMultiLineTextBox_status.Depth = 0;
            this.materialMultiLineTextBox_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialMultiLineTextBox_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialMultiLineTextBox_status.Location = new System.Drawing.Point(5, 88);
            this.materialMultiLineTextBox_status.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialMultiLineTextBox_status.Name = "materialMultiLineTextBox_status";
            this.materialMultiLineTextBox_status.Size = new System.Drawing.Size(131, 31);
            this.materialMultiLineTextBox_status.TabIndex = 11;
            this.materialMultiLineTextBox_status.Text = "";
            // 
            // materialMultiLineTextBox_currentMapTime
            // 
            this.materialMultiLineTextBox_currentMapTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialMultiLineTextBox_currentMapTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialMultiLineTextBox_currentMapTime.Depth = 0;
            this.materialMultiLineTextBox_currentMapTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialMultiLineTextBox_currentMapTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialMultiLineTextBox_currentMapTime.Location = new System.Drawing.Point(5, 32);
            this.materialMultiLineTextBox_currentMapTime.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialMultiLineTextBox_currentMapTime.Name = "materialMultiLineTextBox_currentMapTime";
            this.materialMultiLineTextBox_currentMapTime.Size = new System.Drawing.Size(131, 31);
            this.materialMultiLineTextBox_currentMapTime.TabIndex = 10;
            this.materialMultiLineTextBox_currentMapTime.Text = "";
            // 
            // materialLabel_currentMapTime
            // 
            this.materialLabel_currentMapTime.AutoSize = true;
            this.materialLabel_currentMapTime.Depth = 0;
            this.materialLabel_currentMapTime.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_currentMapTime.Location = new System.Drawing.Point(5, 12);
            this.materialLabel_currentMapTime.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_currentMapTime.Name = "materialLabel_currentMapTime";
            this.materialLabel_currentMapTime.Size = new System.Drawing.Size(128, 19);
            this.materialLabel_currentMapTime.TabIndex = 8;
            this.materialLabel_currentMapTime.Text = "Current Map Time";
            // 
            // materialLabel_status
            // 
            this.materialLabel_status.AutoSize = true;
            this.materialLabel_status.Depth = 0;
            this.materialLabel_status.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_status.Location = new System.Drawing.Point(5, 66);
            this.materialLabel_status.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_status.Name = "materialLabel_status";
            this.materialLabel_status.Size = new System.Drawing.Size(47, 19);
            this.materialLabel_status.TabIndex = 7;
            this.materialLabel_status.Text = "Status";
            // 
            // materialLabel_submissionStatus
            // 
            this.materialLabel_submissionStatus.AutoSize = true;
            this.materialLabel_submissionStatus.Depth = 0;
            this.materialLabel_submissionStatus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_submissionStatus.Location = new System.Drawing.Point(14, 384);
            this.materialLabel_submissionStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_submissionStatus.Name = "materialLabel_submissionStatus";
            this.materialLabel_submissionStatus.Size = new System.Drawing.Size(143, 19);
            this.materialLabel_submissionStatus.TabIndex = 12;
            this.materialLabel_submissionStatus.Text = "Submission Status: ";
            // 
            // materialLabel_refeshRate
            // 
            this.materialLabel_refeshRate.AutoSize = true;
            this.materialLabel_refeshRate.Depth = 0;
            this.materialLabel_refeshRate.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_refeshRate.Location = new System.Drawing.Point(381, 187);
            this.materialLabel_refeshRate.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_refeshRate.Name = "materialLabel_refeshRate";
            this.materialLabel_refeshRate.Size = new System.Drawing.Size(123, 19);
            this.materialLabel_refeshRate.TabIndex = 9;
            this.materialLabel_refeshRate.Text = "Refresh rate (ms)";
            // 
            // materialMultiLineTextBox_currentPlayingData
            // 
            this.materialMultiLineTextBox_currentPlayingData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialMultiLineTextBox_currentPlayingData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialMultiLineTextBox_currentPlayingData.Depth = 0;
            this.materialMultiLineTextBox_currentPlayingData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialMultiLineTextBox_currentPlayingData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialMultiLineTextBox_currentPlayingData.Location = new System.Drawing.Point(14, 238);
            this.materialMultiLineTextBox_currentPlayingData.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialMultiLineTextBox_currentPlayingData.Name = "materialMultiLineTextBox_currentPlayingData";
            this.materialMultiLineTextBox_currentPlayingData.Size = new System.Drawing.Size(361, 133);
            this.materialMultiLineTextBox_currentPlayingData.TabIndex = 6;
            this.materialMultiLineTextBox_currentPlayingData.Text = "";
            // 
            // materialLabel_currentPlayingData
            // 
            this.materialLabel_currentPlayingData.AutoSize = true;
            this.materialLabel_currentPlayingData.Depth = 0;
            this.materialLabel_currentPlayingData.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_currentPlayingData.Location = new System.Drawing.Point(14, 216);
            this.materialLabel_currentPlayingData.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_currentPlayingData.Name = "materialLabel_currentPlayingData";
            this.materialLabel_currentPlayingData.Size = new System.Drawing.Size(147, 19);
            this.materialLabel_currentPlayingData.TabIndex = 5;
            this.materialLabel_currentPlayingData.Text = "Current Playing Data";
            // 
            // materialMultiLineTextBox_mapData
            // 
            this.materialMultiLineTextBox_mapData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialMultiLineTextBox_mapData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialMultiLineTextBox_mapData.Depth = 0;
            this.materialMultiLineTextBox_mapData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialMultiLineTextBox_mapData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialMultiLineTextBox_mapData.Location = new System.Drawing.Point(14, 91);
            this.materialMultiLineTextBox_mapData.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialMultiLineTextBox_mapData.Name = "materialMultiLineTextBox_mapData";
            this.materialMultiLineTextBox_mapData.Size = new System.Drawing.Size(361, 115);
            this.materialMultiLineTextBox_mapData.TabIndex = 4;
            this.materialMultiLineTextBox_mapData.Text = "";
            // 
            // materialLabel_MapData
            // 
            this.materialLabel_MapData.AutoSize = true;
            this.materialLabel_MapData.Depth = 0;
            this.materialLabel_MapData.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_MapData.Location = new System.Drawing.Point(14, 69);
            this.materialLabel_MapData.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_MapData.Name = "materialLabel_MapData";
            this.materialLabel_MapData.Size = new System.Drawing.Size(33, 19);
            this.materialLabel_MapData.TabIndex = 2;
            this.materialLabel_MapData.Text = "Map";
            // 
            // materialButton_toggle
            // 
            this.materialButton_toggle.AutoSize = false;
            this.materialButton_toggle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton_toggle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton_toggle.Depth = 0;
            this.materialButton_toggle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.materialButton_toggle.HighEmphasis = true;
            this.materialButton_toggle.Icon = null;
            this.materialButton_toggle.Location = new System.Drawing.Point(14, 9);
            this.materialButton_toggle.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton_toggle.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton_toggle.Name = "materialButton_toggle";
            this.materialButton_toggle.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton_toggle.Size = new System.Drawing.Size(246, 54);
            this.materialButton_toggle.TabIndex = 0;
            this.materialButton_toggle.TabStop = false;
            this.materialButton_toggle.Text = "Toggle";
            this.materialButton_toggle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton_toggle.UseAccentColor = false;
            this.materialButton_toggle.UseVisualStyleBackColor = true;
            this.materialButton_toggle.Click += new System.EventHandler(this.materialButton_toggle_Click);
            // 
            // tabPage_settings
            // 
            this.tabPage_settings.BackColor = System.Drawing.Color.White;
            this.tabPage_settings.Controls.Add(this.materialLabel_saved);
            this.tabPage_settings.Controls.Add(this.materialButton_changeTheme);
            this.tabPage_settings.Controls.Add(this.materialTextBox_apiInput);
            this.tabPage_settings.Controls.Add(this.materialButton_findOsuLocation);
            this.tabPage_settings.Controls.Add(this.materialLabel_globalToggleHotkey);
            this.tabPage_settings.Controls.Add(this.materialLabel_osuPath);
            this.tabPage_settings.Controls.Add(this.materialMultiLineTextBox_submitAcc);
            this.tabPage_settings.Controls.Add(this.materialButton_checkApi);
            this.tabPage_settings.Controls.Add(this.materialLabel_apiNeeded);
            this.tabPage_settings.Controls.Add(this.materialCheckbox_autoDisconnect);
            this.tabPage_settings.Controls.Add(this.materialCheckbox_submitIfFC);
            this.tabPage_settings.Controls.Add(this.materialCheckbox_hideData);
            this.tabPage_settings.Controls.Add(this.materialCheckbox_topMost);
            this.tabPage_settings.Controls.Add(this.materialCheckbox_toggleWithSound);
            this.tabPage_settings.Controls.Add(this.materialCheckbox_minimizeToSystemTray);
            this.tabPage_settings.Controls.Add(this.materialCheckbox_runAtStartup);
            this.tabPage_settings.Controls.Add(this.materialLabel_focus);
            this.tabPage_settings.ImageKey = "Setting_32.png";
            this.tabPage_settings.Location = new System.Drawing.Point(4, 27);
            this.tabPage_settings.Name = "tabPage_settings";
            this.tabPage_settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings.Size = new System.Drawing.Size(540, 420);
            this.tabPage_settings.TabIndex = 1;
            this.tabPage_settings.Text = "Settings";
            // 
            // materialLabel_saved
            // 
            this.materialLabel_saved.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel_saved.Depth = 0;
            this.materialLabel_saved.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.materialLabel_saved.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_saved.ForeColor = System.Drawing.Color.Green;
            this.materialLabel_saved.Location = new System.Drawing.Point(491, 264);
            this.materialLabel_saved.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_saved.Name = "materialLabel_saved";
            this.materialLabel_saved.Size = new System.Drawing.Size(61, 25);
            this.materialLabel_saved.TabIndex = 26;
            this.materialLabel_saved.Text = "Saved!";
            this.materialLabel_saved.Visible = false;
            // 
            // materialButton_changeTheme
            // 
            this.materialButton_changeTheme.AutoSize = false;
            this.materialButton_changeTheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton_changeTheme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton_changeTheme.Depth = 0;
            this.materialButton_changeTheme.HighEmphasis = true;
            this.materialButton_changeTheme.Icon = null;
            this.materialButton_changeTheme.Location = new System.Drawing.Point(390, 62);
            this.materialButton_changeTheme.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton_changeTheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton_changeTheme.Name = "materialButton_changeTheme";
            this.materialButton_changeTheme.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton_changeTheme.Size = new System.Drawing.Size(142, 41);
            this.materialButton_changeTheme.TabIndex = 25;
            this.materialButton_changeTheme.TabStop = false;
            this.materialButton_changeTheme.Text = "Mode";
            this.materialButton_changeTheme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton_changeTheme.UseAccentColor = false;
            this.materialButton_changeTheme.UseVisualStyleBackColor = true;
            this.materialButton_changeTheme.Click += new System.EventHandler(this.materialButton_changeTheme_Click);
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
            this.materialTextBox_apiInput.Location = new System.Drawing.Point(13, 256);
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
            this.materialButton_findOsuLocation.Location = new System.Drawing.Point(339, 9);
            this.materialButton_findOsuLocation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton_findOsuLocation.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton_findOsuLocation.Name = "materialButton_findOsuLocation";
            this.materialButton_findOsuLocation.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton_findOsuLocation.Size = new System.Drawing.Size(193, 41);
            this.materialButton_findOsuLocation.TabIndex = 22;
            this.materialButton_findOsuLocation.TabStop = false;
            this.materialButton_findOsuLocation.Text = "find osu!.exe location";
            this.materialButton_findOsuLocation.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton_findOsuLocation.UseAccentColor = false;
            this.materialButton_findOsuLocation.UseVisualStyleBackColor = true;
            this.materialButton_findOsuLocation.Click += new System.EventHandler(this.materialButton_findOsuLocation_Click);
            // 
            // materialLabel_globalToggleHotkey
            // 
            this.materialLabel_globalToggleHotkey.AutoSize = true;
            this.materialLabel_globalToggleHotkey.Depth = 0;
            this.materialLabel_globalToggleHotkey.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_globalToggleHotkey.Location = new System.Drawing.Point(13, 344);
            this.materialLabel_globalToggleHotkey.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_globalToggleHotkey.Name = "materialLabel_globalToggleHotkey";
            this.materialLabel_globalToggleHotkey.Size = new System.Drawing.Size(179, 19);
            this.materialLabel_globalToggleHotkey.TabIndex = 21;
            this.materialLabel_globalToggleHotkey.Text = "Global Toggle Hotkey: F6";
            // 
            // materialLabel_osuPath
            // 
            this.materialLabel_osuPath.AutoSize = true;
            this.materialLabel_osuPath.Depth = 0;
            this.materialLabel_osuPath.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_osuPath.Location = new System.Drawing.Point(13, 380);
            this.materialLabel_osuPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_osuPath.Name = "materialLabel_osuPath";
            this.materialLabel_osuPath.Size = new System.Drawing.Size(72, 19);
            this.materialLabel_osuPath.TabIndex = 20;
            this.materialLabel_osuPath.Text = "osu! Path:";
            // 
            // materialMultiLineTextBox_submitAcc
            // 
            this.materialMultiLineTextBox_submitAcc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialMultiLineTextBox_submitAcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialMultiLineTextBox_submitAcc.Depth = 0;
            this.materialMultiLineTextBox_submitAcc.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.materialMultiLineTextBox_submitAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialMultiLineTextBox_submitAcc.Location = new System.Drawing.Point(181, 189);
            this.materialMultiLineTextBox_submitAcc.MaxLength = 3;
            this.materialMultiLineTextBox_submitAcc.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialMultiLineTextBox_submitAcc.Multiline = false;
            this.materialMultiLineTextBox_submitAcc.Name = "materialMultiLineTextBox_submitAcc";
            this.materialMultiLineTextBox_submitAcc.Size = new System.Drawing.Size(37, 29);
            this.materialMultiLineTextBox_submitAcc.TabIndex = 19;
            this.materialMultiLineTextBox_submitAcc.Text = "100";
            this.materialMultiLineTextBox_submitAcc.TextChanged += new System.EventHandler(this.materialMultiLineTextBox_submitAcc_TextChanged);
            // 
            // materialButton_checkApi
            // 
            this.materialButton_checkApi.AutoSize = false;
            this.materialButton_checkApi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton_checkApi.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton_checkApi.Depth = 0;
            this.materialButton_checkApi.HighEmphasis = true;
            this.materialButton_checkApi.Icon = null;
            this.materialButton_checkApi.Location = new System.Drawing.Point(428, 258);
            this.materialButton_checkApi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton_checkApi.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton_checkApi.Name = "materialButton_checkApi";
            this.materialButton_checkApi.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton_checkApi.Size = new System.Drawing.Size(56, 34);
            this.materialButton_checkApi.TabIndex = 18;
            this.materialButton_checkApi.TabStop = false;
            this.materialButton_checkApi.Text = "Check";
            this.materialButton_checkApi.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton_checkApi.UseAccentColor = false;
            this.materialButton_checkApi.UseVisualStyleBackColor = true;
            this.materialButton_checkApi.Click += new System.EventHandler(this.materialButton_checkApi_Click);
            // 
            // materialLabel_apiNeeded
            // 
            this.materialLabel_apiNeeded.AutoSize = true;
            this.materialLabel_apiNeeded.Depth = 0;
            this.materialLabel_apiNeeded.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_apiNeeded.Location = new System.Drawing.Point(13, 233);
            this.materialLabel_apiNeeded.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_apiNeeded.Name = "materialLabel_apiNeeded";
            this.materialLabel_apiNeeded.Size = new System.Drawing.Size(143, 19);
            this.materialLabel_apiNeeded.TabIndex = 8;
            this.materialLabel_apiNeeded.Text = "API required options";
            // 
            // materialCheckbox_autoDisconnect
            // 
            this.materialCheckbox_autoDisconnect.AutoSize = true;
            this.materialCheckbox_autoDisconnect.Depth = 0;
            this.materialCheckbox_autoDisconnect.Location = new System.Drawing.Point(3, 301);
            this.materialCheckbox_autoDisconnect.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox_autoDisconnect.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox_autoDisconnect.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox_autoDisconnect.Name = "materialCheckbox_autoDisconnect";
            this.materialCheckbox_autoDisconnect.ReadOnly = false;
            this.materialCheckbox_autoDisconnect.Ripple = true;
            this.materialCheckbox_autoDisconnect.Size = new System.Drawing.Size(304, 37);
            this.materialCheckbox_autoDisconnect.TabIndex = 16;
            this.materialCheckbox_autoDisconnect.TabStop = false;
            this.materialCheckbox_autoDisconnect.Text = "Automatically disconnect after upload";
            this.materialCheckbox_autoDisconnect.UseVisualStyleBackColor = true;
            this.materialCheckbox_autoDisconnect.CheckedChanged += new System.EventHandler(this.materialCheckbox_autoDisconnect_CheckedChanged);
            // 
            // materialCheckbox_submitIfFC
            // 
            this.materialCheckbox_submitIfFC.AutoSize = true;
            this.materialCheckbox_submitIfFC.Depth = 0;
            this.materialCheckbox_submitIfFC.Location = new System.Drawing.Point(3, 187);
            this.materialCheckbox_submitIfFC.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox_submitIfFC.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox_submitIfFC.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox_submitIfFC.Name = "materialCheckbox_submitIfFC";
            this.materialCheckbox_submitIfFC.ReadOnly = false;
            this.materialCheckbox_submitIfFC.Ripple = true;
            this.materialCheckbox_submitIfFC.Size = new System.Drawing.Size(286, 37);
            this.materialCheckbox_submitIfFC.TabIndex = 15;
            this.materialCheckbox_submitIfFC.TabStop = false;
            this.materialCheckbox_submitIfFC.Text = "Submit if FC with ≥             Accuracy";
            this.materialCheckbox_submitIfFC.UseVisualStyleBackColor = true;
            this.materialCheckbox_submitIfFC.CheckedChanged += new System.EventHandler(this.materialCheckbox_submitIfFC_CheckedChanged);
            // 
            // materialCheckbox_hideData
            // 
            this.materialCheckbox_hideData.AutoSize = true;
            this.materialCheckbox_hideData.Depth = 0;
            this.materialCheckbox_hideData.Location = new System.Drawing.Point(3, 150);
            this.materialCheckbox_hideData.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox_hideData.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox_hideData.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox_hideData.Name = "materialCheckbox_hideData";
            this.materialCheckbox_hideData.ReadOnly = false;
            this.materialCheckbox_hideData.Ripple = true;
            this.materialCheckbox_hideData.Size = new System.Drawing.Size(105, 37);
            this.materialCheckbox_hideData.TabIndex = 14;
            this.materialCheckbox_hideData.TabStop = false;
            this.materialCheckbox_hideData.Text = "Hide Data";
            this.materialCheckbox_hideData.UseVisualStyleBackColor = true;
            this.materialCheckbox_hideData.CheckedChanged += new System.EventHandler(this.materialCheckbox_hideData_CheckedChanged);
            // 
            // materialCheckbox_topMost
            // 
            this.materialCheckbox_topMost.AutoSize = true;
            this.materialCheckbox_topMost.Depth = 0;
            this.materialCheckbox_topMost.Location = new System.Drawing.Point(3, 113);
            this.materialCheckbox_topMost.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox_topMost.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox_topMost.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox_topMost.Name = "materialCheckbox_topMost";
            this.materialCheckbox_topMost.ReadOnly = false;
            this.materialCheckbox_topMost.Ripple = true;
            this.materialCheckbox_topMost.Size = new System.Drawing.Size(136, 37);
            this.materialCheckbox_topMost.TabIndex = 13;
            this.materialCheckbox_topMost.TabStop = false;
            this.materialCheckbox_topMost.Text = "Always at Top";
            this.materialCheckbox_topMost.UseVisualStyleBackColor = true;
            this.materialCheckbox_topMost.CheckedChanged += new System.EventHandler(this.materialCheckbox_topMost_CheckedChanged);
            // 
            // materialCheckbox_toggleWithSound
            // 
            this.materialCheckbox_toggleWithSound.AutoSize = true;
            this.materialCheckbox_toggleWithSound.Depth = 0;
            this.materialCheckbox_toggleWithSound.Location = new System.Drawing.Point(3, 77);
            this.materialCheckbox_toggleWithSound.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox_toggleWithSound.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox_toggleWithSound.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox_toggleWithSound.Name = "materialCheckbox_toggleWithSound";
            this.materialCheckbox_toggleWithSound.ReadOnly = false;
            this.materialCheckbox_toggleWithSound.Ripple = true;
            this.materialCheckbox_toggleWithSound.Size = new System.Drawing.Size(168, 37);
            this.materialCheckbox_toggleWithSound.TabIndex = 12;
            this.materialCheckbox_toggleWithSound.TabStop = false;
            this.materialCheckbox_toggleWithSound.Text = "Toggle with Sound";
            this.materialCheckbox_toggleWithSound.UseVisualStyleBackColor = true;
            this.materialCheckbox_toggleWithSound.CheckedChanged += new System.EventHandler(this.materialCheckbox_toggleWithSound_CheckedChanged);
            // 
            // materialCheckbox_minimizeToSystemTray
            // 
            this.materialCheckbox_minimizeToSystemTray.AutoSize = true;
            this.materialCheckbox_minimizeToSystemTray.Depth = 0;
            this.materialCheckbox_minimizeToSystemTray.Location = new System.Drawing.Point(3, 40);
            this.materialCheckbox_minimizeToSystemTray.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox_minimizeToSystemTray.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox_minimizeToSystemTray.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox_minimizeToSystemTray.Name = "materialCheckbox_minimizeToSystemTray";
            this.materialCheckbox_minimizeToSystemTray.ReadOnly = false;
            this.materialCheckbox_minimizeToSystemTray.Ripple = true;
            this.materialCheckbox_minimizeToSystemTray.Size = new System.Drawing.Size(211, 37);
            this.materialCheckbox_minimizeToSystemTray.TabIndex = 10;
            this.materialCheckbox_minimizeToSystemTray.TabStop = false;
            this.materialCheckbox_minimizeToSystemTray.Text = "Minimize to System Tray";
            this.materialCheckbox_minimizeToSystemTray.UseVisualStyleBackColor = true;
            this.materialCheckbox_minimizeToSystemTray.CheckedChanged += new System.EventHandler(this.materialCheckbox_minimizeToSystemTray_CheckedChanged);
            // 
            // materialCheckbox_runAtStartup
            // 
            this.materialCheckbox_runAtStartup.AutoSize = true;
            this.materialCheckbox_runAtStartup.Depth = 0;
            this.materialCheckbox_runAtStartup.Location = new System.Drawing.Point(3, 3);
            this.materialCheckbox_runAtStartup.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox_runAtStartup.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox_runAtStartup.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox_runAtStartup.Name = "materialCheckbox_runAtStartup";
            this.materialCheckbox_runAtStartup.ReadOnly = false;
            this.materialCheckbox_runAtStartup.Ripple = true;
            this.materialCheckbox_runAtStartup.Size = new System.Drawing.Size(137, 37);
            this.materialCheckbox_runAtStartup.TabIndex = 11;
            this.materialCheckbox_runAtStartup.TabStop = false;
            this.materialCheckbox_runAtStartup.Text = "Run at Startup";
            this.materialCheckbox_runAtStartup.UseVisualStyleBackColor = true;
            this.materialCheckbox_runAtStartup.CheckedChanged += new System.EventHandler(this.materialCheckbox_runAtStartup_CheckedChanged);
            // 
            // materialLabel_focus
            // 
            this.materialLabel_focus.AutoSize = true;
            this.materialLabel_focus.Depth = 0;
            this.materialLabel_focus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_focus.Location = new System.Drawing.Point(390, 21);
            this.materialLabel_focus.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_focus.Name = "materialLabel_focus";
            this.materialLabel_focus.Size = new System.Drawing.Size(103, 19);
            this.materialLabel_focus.TabIndex = 24;
            this.materialLabel_focus.Text = "label for focus";
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
            this.notifyIcon_osuEscape.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_osuEscape_MouseDoubleClick);
            // 
            // materialTabSelector_main
            // 
            this.materialTabSelector_main.BaseTabControl = this.materialTabControl_menu;
            this.materialTabSelector_main.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            this.materialTabSelector_main.Depth = 0;
            this.materialTabSelector_main.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTabSelector_main.Location = new System.Drawing.Point(0, 64);
            this.materialTabSelector_main.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector_main.Name = "materialTabSelector_main";
            this.materialTabSelector_main.Size = new System.Drawing.Size(553, 37);
            this.materialTabSelector_main.TabIndex = 1;
            this.materialTabSelector_main.TabStop = false;
            this.materialTabSelector_main.Text = "materialTabSelector_main";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(553, 562);
            this.Controls.Add(this.materialTabSelector_main);
            this.Controls.Add(this.materialTabControl_menu);
            this.DrawerShowIconsWhenHidden = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HomeForm";
            this.Text = "osu! Escape";
            this.Load += new System.EventHandler(this.OsuEscape_Load);
            this.Resize += new System.EventHandler(this.HomeForm_Resize);
            this.materialTabControl_menu.ResumeLayout(false);
            this.tabPage_main.ResumeLayout(false);
            this.tabPage_main.PerformLayout();
            this.groupBox_mapStatus.ResumeLayout(false);
            this.groupBox_mapStatus.PerformLayout();
            this.tabPage_settings.ResumeLayout(false);
            this.tabPage_settings.PerformLayout();
            this.contextMenuStrip_osu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl_menu;
        private System.Windows.Forms.TabPage tabPage_main;
        private System.Windows.Forms.TabPage tabPage_settings;
        private MaterialSkin.Controls.MaterialButton materialButton_toggle;
        private MaterialSkin.Controls.MaterialLabel materialLabel_MapData;
        private MaterialSkin.Controls.MaterialMultiLineTextBox materialMultiLineTextBox_currentMapTime;
        private MaterialSkin.Controls.MaterialLabel materialLabel_refeshRate;
        private MaterialSkin.Controls.MaterialLabel materialLabel_currentMapTime;
        private MaterialSkin.Controls.MaterialLabel materialLabel_status;
        private MaterialSkin.Controls.MaterialMultiLineTextBox materialMultiLineTextBox_currentPlayingData;
        private MaterialSkin.Controls.MaterialLabel materialLabel_currentPlayingData;
        private MaterialSkin.Controls.MaterialMultiLineTextBox materialMultiLineTextBox_mapData;
        private MaterialSkin.Controls.MaterialMultiLineTextBox materialMultiLineTextBox_status;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_runAtStartup;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_minimizeToSystemTray;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_toggleWithSound;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_topMost;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_hideData;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_submitIfFC;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_autoDisconnect;
        private MaterialSkin.Controls.MaterialLabel materialLabel_apiNeeded;
        private MaterialSkin.Controls.MaterialButton materialButton_checkApi;
        private MaterialSkin.Controls.MaterialSlider materialSlider_refreshRate;
        private MaterialSkin.Controls.MaterialLabel materialLabel_submissionStatus;
        private MaterialSkin.Controls.MaterialMultiLineTextBox materialMultiLineTextBox_submitAcc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_osu;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon_osuEscape;
        private MaterialSkin.Controls.MaterialLabel materialLabel_osuPath;
        private MaterialSkin.Controls.MaterialLabel materialLabel_globalToggleHotkey;
        private MaterialSkin.Controls.MaterialButton materialButton_findOsuLocation;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector_main;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox_apiInput;
        private MaterialSkin.Controls.MaterialLabel materialLabel_focus;
        private MaterialSkin.Controls.MaterialButton materialButton_changeTheme;
        private System.Windows.Forms.GroupBox groupBox_mapStatus;
        private MaterialSkin.Controls.MaterialLabel materialLabel_saved;
    }
}