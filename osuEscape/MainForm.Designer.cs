
namespace osuEscape
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button_findLocation = new System.Windows.Forms.Button();
            this.textBox_hotkey = new System.Windows.Forms.TextBox();
            this.button_toggle = new System.Windows.Forms.Button();
            this.textBox_osuPath = new System.Windows.Forms.TextBox();
            this.checkBox_startUp = new System.Windows.Forms.CheckBox();
            this.notifyIcon_osuEscape = new System.Windows.Forms.NotifyIcon(this.components);
            this.checkBox_toggleSound = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip_osu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_status = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_quit = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox_systemTray = new System.Windows.Forms.CheckBox();
            this.panel_top = new System.Windows.Forms.Panel();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_minimize = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.checkBox_topMost = new System.Windows.Forms.CheckBox();
            this.button_reOpenOsu = new System.Windows.Forms.Button();
            this.textBox_toggleOsu = new System.Windows.Forms.TextBox();
            this.textBox_readTime = new System.Windows.Forms.TextBox();
            this.textBox_strings = new System.Windows.Forms.TextBox();
            this.textBox_time = new System.Windows.Forms.TextBox();
            this.textBox_mapData = new System.Windows.Forms.TextBox();
            this.textBox_Status = new System.Windows.Forms.TextBox();
            this.textBox_CurrentPlayData = new System.Windows.Forms.TextBox();
            this.numericUpDown_readDelay = new System.Windows.Forms.NumericUpDown();
            this.button_ResetReadTimeMinMax = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_mapId = new System.Windows.Forms.TextBox();
            this.checkBox_IsReplay = new System.Windows.Forms.CheckBox();
            this.checkBox_PlayContainer = new System.Windows.Forms.CheckBox();
            this.checkBox_TourneyBase = new System.Windows.Forms.CheckBox();
            this.checkBox_CurrentSkinData = new System.Windows.Forms.CheckBox();
            this.checkBox_Mods = new System.Windows.Forms.CheckBox();
            this.checkBox_OsuBase = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip_osu.SuspendLayout();
            this.panel_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_readDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // button_findLocation
            // 
            this.button_findLocation.BackColor = System.Drawing.Color.Transparent;
            this.button_findLocation.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_findLocation.ForeColor = System.Drawing.Color.Gray;
            this.button_findLocation.Location = new System.Drawing.Point(200, 53);
            this.button_findLocation.Name = "button_findLocation";
            this.button_findLocation.Size = new System.Drawing.Size(50, 50);
            this.button_findLocation.TabIndex = 2;
            this.button_findLocation.Text = "📂";
            this.button_findLocation.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button_findLocation.UseVisualStyleBackColor = false;
            this.button_findLocation.Click += new System.EventHandler(this.Button_findLocation_Click);
            // 
            // textBox_hotkey
            // 
            this.textBox_hotkey.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_hotkey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_hotkey.Location = new System.Drawing.Point(10, 129);
            this.textBox_hotkey.Name = "textBox_hotkey";
            this.textBox_hotkey.ReadOnly = true;
            this.textBox_hotkey.Size = new System.Drawing.Size(145, 13);
            this.textBox_hotkey.TabIndex = 4;
            this.textBox_hotkey.Text = "Global Toggle Hotkey: F6";
            // 
            // button_toggle
            // 
            this.button_toggle.BackColor = System.Drawing.Color.White;
            this.button_toggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_toggle.Location = new System.Drawing.Point(9, 52);
            this.button_toggle.Name = "button_toggle";
            this.button_toggle.Size = new System.Drawing.Size(184, 54);
            this.button_toggle.TabIndex = 0;
            this.button_toggle.Text = "Toggle";
            this.button_toggle.UseVisualStyleBackColor = false;
            this.button_toggle.Click += new System.EventHandler(this.Button_toggle_Click);
            // 
            // textBox_osuPath
            // 
            this.textBox_osuPath.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_osuPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_osuPath.Location = new System.Drawing.Point(10, 147);
            this.textBox_osuPath.Name = "textBox_osuPath";
            this.textBox_osuPath.ReadOnly = true;
            this.textBox_osuPath.Size = new System.Drawing.Size(256, 13);
            this.textBox_osuPath.TabIndex = 12;
            this.textBox_osuPath.Text = "osu! Path:";
            // 
            // checkBox_startUp
            // 
            this.checkBox_startUp.AutoSize = true;
            this.checkBox_startUp.Location = new System.Drawing.Point(10, 164);
            this.checkBox_startUp.Name = "checkBox_startUp";
            this.checkBox_startUp.Size = new System.Drawing.Size(96, 17);
            this.checkBox_startUp.TabIndex = 14;
            this.checkBox_startUp.Text = "Run at start up";
            this.checkBox_startUp.UseVisualStyleBackColor = true;
            this.checkBox_startUp.CheckedChanged += new System.EventHandler(this.CheckBox_startUp_CheckedChanged);
            // 
            // notifyIcon_osuEscape
            // 
            this.notifyIcon_osuEscape.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_osuEscape.Icon")));
            this.notifyIcon_osuEscape.Text = "osu!Escape";
            this.notifyIcon_osuEscape.Visible = true;
            this.notifyIcon_osuEscape.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_osuEscape_MouseDoubleClick);
            // 
            // checkBox_toggleSound
            // 
            this.checkBox_toggleSound.AutoSize = true;
            this.checkBox_toggleSound.Location = new System.Drawing.Point(10, 187);
            this.checkBox_toggleSound.Name = "checkBox_toggleSound";
            this.checkBox_toggleSound.Size = new System.Drawing.Size(113, 17);
            this.checkBox_toggleSound.TabIndex = 15;
            this.checkBox_toggleSound.Text = "Toggle with sound";
            this.checkBox_toggleSound.UseVisualStyleBackColor = true;
            this.checkBox_toggleSound.CheckedChanged += new System.EventHandler(this.CheckBox_toggleSound_CheckedChanged);
            // 
            // contextMenuStrip_osu
            // 
            this.contextMenuStrip_osu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_status,
            this.ToolStripMenuItem_quit});
            this.contextMenuStrip_osu.Name = "osuCMS";
            this.contextMenuStrip_osu.Size = new System.Drawing.Size(110, 48);
            // 
            // ToolStripMenuItem_status
            // 
            this.ToolStripMenuItem_status.Name = "ToolStripMenuItem_status";
            this.ToolStripMenuItem_status.Size = new System.Drawing.Size(109, 22);
            this.ToolStripMenuItem_status.Text = "Status:";
            // 
            // ToolStripMenuItem_quit
            // 
            this.ToolStripMenuItem_quit.Name = "ToolStripMenuItem_quit";
            this.ToolStripMenuItem_quit.Size = new System.Drawing.Size(109, 22);
            this.ToolStripMenuItem_quit.Text = "Quit";
            // 
            // checkBox_systemTray
            // 
            this.checkBox_systemTray.AutoSize = true;
            this.checkBox_systemTray.Location = new System.Drawing.Point(10, 210);
            this.checkBox_systemTray.Name = "checkBox_systemTray";
            this.checkBox_systemTray.Size = new System.Drawing.Size(139, 17);
            this.checkBox_systemTray.TabIndex = 18;
            this.checkBox_systemTray.Text = "Minimize to System Tray";
            this.checkBox_systemTray.UseVisualStyleBackColor = true;
            this.checkBox_systemTray.CheckedChanged += new System.EventHandler(this.CheckBox_systemTray_CheckedChanged);
            // 
            // panel_top
            // 
            this.panel_top.AllowDrop = true;
            this.panel_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.panel_top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_top.Controls.Add(this.button_exit);
            this.panel_top.Controls.Add(this.button_minimize);
            this.panel_top.Controls.Add(this.label_title);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(631, 33);
            this.panel_top.TabIndex = 1;
            this.panel_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_top_MouseDown);
            this.panel_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_top_MouseMove);
            this.panel_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel_top_MouseUp);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button_exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button_exit.ForeColor = System.Drawing.Color.White;
            this.button_exit.Location = new System.Drawing.Point(229, -15);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(31, 62);
            this.button_exit.TabIndex = 22;
            this.button_exit.Text = "X";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.Button_exit_Click);
            // 
            // button_minimize
            // 
            this.button_minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button_minimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button_minimize.ForeColor = System.Drawing.Color.White;
            this.button_minimize.Location = new System.Drawing.Point(199, -25);
            this.button_minimize.Name = "button_minimize";
            this.button_minimize.Size = new System.Drawing.Size(31, 62);
            this.button_minimize.TabIndex = 21;
            this.button_minimize.Text = "_";
            this.button_minimize.UseVisualStyleBackColor = false;
            this.button_minimize.Click += new System.EventHandler(this.Button_minimize_Click);
            // 
            // label_title
            // 
            this.label_title.AllowDrop = true;
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_title.ForeColor = System.Drawing.Color.White;
            this.label_title.Location = new System.Drawing.Point(2, 7);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(85, 17);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "osu! Escape";
            this.label_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label_title_MouseDown);
            this.label_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Label_title_MouseMove);
            this.label_title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label_title_MouseUp);
            // 
            // checkBox_topMost
            // 
            this.checkBox_topMost.AutoSize = true;
            this.checkBox_topMost.Location = new System.Drawing.Point(11, 233);
            this.checkBox_topMost.Name = "checkBox_topMost";
            this.checkBox_topMost.Size = new System.Drawing.Size(93, 17);
            this.checkBox_topMost.TabIndex = 19;
            this.checkBox_topMost.Text = "Always at Top";
            this.checkBox_topMost.UseVisualStyleBackColor = true;
            this.checkBox_topMost.CheckedChanged += new System.EventHandler(this.CheckBox_topMost_CheckedChanged);
            // 
            // button_reOpenOsu
            // 
            this.button_reOpenOsu.BackColor = System.Drawing.Color.Transparent;
            this.button_reOpenOsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_reOpenOsu.ForeColor = System.Drawing.Color.Gray;
            this.button_reOpenOsu.Image = global::osuEscape.Properties.Resources.reopen_osu_icon;
            this.button_reOpenOsu.Location = new System.Drawing.Point(200, 109);
            this.button_reOpenOsu.Name = "button_reOpenOsu";
            this.button_reOpenOsu.Size = new System.Drawing.Size(50, 50);
            this.button_reOpenOsu.TabIndex = 20;
            this.button_reOpenOsu.UseVisualStyleBackColor = false;
            this.button_reOpenOsu.Click += new System.EventHandler(this.Button_reOpenOsu_Click);
            // 
            // textBox_toggleOsu
            // 
            this.textBox_toggleOsu.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_toggleOsu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_toggleOsu.Location = new System.Drawing.Point(10, 111);
            this.textBox_toggleOsu.Name = "textBox_toggleOsu";
            this.textBox_toggleOsu.ReadOnly = true;
            this.textBox_toggleOsu.Size = new System.Drawing.Size(145, 13);
            this.textBox_toggleOsu.TabIndex = 21;
            // 
            // textBox_readTime
            // 
            this.textBox_readTime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_readTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_readTime.Location = new System.Drawing.Point(12, 256);
            this.textBox_readTime.Multiline = true;
            this.textBox_readTime.Name = "textBox_readTime";
            this.textBox_readTime.ReadOnly = true;
            this.textBox_readTime.Size = new System.Drawing.Size(237, 38);
            this.textBox_readTime.TabIndex = 24;
            this.textBox_readTime.Text = "read time";
            // 
            // textBox_strings
            // 
            this.textBox_strings.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_strings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_strings.Location = new System.Drawing.Point(13, 300);
            this.textBox_strings.Multiline = true;
            this.textBox_strings.Name = "textBox_strings";
            this.textBox_strings.ReadOnly = true;
            this.textBox_strings.Size = new System.Drawing.Size(237, 82);
            this.textBox_strings.TabIndex = 25;
            this.textBox_strings.Text = "settings";
            // 
            // textBox_time
            // 
            this.textBox_time.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_time.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_time.Location = new System.Drawing.Point(13, 388);
            this.textBox_time.Multiline = true;
            this.textBox_time.Name = "textBox_time";
            this.textBox_time.ReadOnly = true;
            this.textBox_time.Size = new System.Drawing.Size(237, 21);
            this.textBox_time.TabIndex = 26;
            this.textBox_time.Text = "time";
            // 
            // textBox_mapData
            // 
            this.textBox_mapData.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_mapData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_mapData.Location = new System.Drawing.Point(13, 415);
            this.textBox_mapData.Multiline = true;
            this.textBox_mapData.Name = "textBox_mapData";
            this.textBox_mapData.ReadOnly = true;
            this.textBox_mapData.Size = new System.Drawing.Size(237, 47);
            this.textBox_mapData.TabIndex = 27;
            this.textBox_mapData.Text = "map data";
            // 
            // textBox_Status
            // 
            this.textBox_Status.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Status.Location = new System.Drawing.Point(13, 468);
            this.textBox_Status.Multiline = true;
            this.textBox_Status.Name = "textBox_Status";
            this.textBox_Status.ReadOnly = true;
            this.textBox_Status.Size = new System.Drawing.Size(237, 18);
            this.textBox_Status.TabIndex = 28;
            this.textBox_Status.Text = "status";
            // 
            // textBox_CurrentPlayData
            // 
            this.textBox_CurrentPlayData.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_CurrentPlayData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_CurrentPlayData.Location = new System.Drawing.Point(13, 492);
            this.textBox_CurrentPlayData.Multiline = true;
            this.textBox_CurrentPlayData.Name = "textBox_CurrentPlayData";
            this.textBox_CurrentPlayData.ReadOnly = true;
            this.textBox_CurrentPlayData.Size = new System.Drawing.Size(237, 76);
            this.textBox_CurrentPlayData.TabIndex = 29;
            this.textBox_CurrentPlayData.Text = "current play data";
            // 
            // numericUpDown_readDelay
            // 
            this.numericUpDown_readDelay.Location = new System.Drawing.Point(129, 230);
            this.numericUpDown_readDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_readDelay.Name = "numericUpDown_readDelay";
            this.numericUpDown_readDelay.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_readDelay.TabIndex = 250;
            this.numericUpDown_readDelay.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // button_ResetReadTimeMinMax
            // 
            this.button_ResetReadTimeMinMax.Location = new System.Drawing.Point(197, 187);
            this.button_ResetReadTimeMinMax.Name = "button_ResetReadTimeMinMax";
            this.button_ResetReadTimeMinMax.Size = new System.Drawing.Size(52, 22);
            this.button_ResetReadTimeMinMax.TabIndex = 32;
            this.button_ResetReadTimeMinMax.Text = "Reset";
            this.button_ResetReadTimeMinMax.UseVisualStyleBackColor = true;
            this.button_ResetReadTimeMinMax.Click += new System.EventHandler(this.Button_ResetReadTimeMinMax_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // checkBox_OsuBase
            // 
            this.checkBox_OsuBase.AutoSize = true;
            this.checkBox_OsuBase.Checked = true;
            this.checkBox_OsuBase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_OsuBase.Location = new System.Drawing.Point(255, 348);
            this.checkBox_OsuBase.Name = "checkBox_OsuBase";
            this.checkBox_OsuBase.Size = new System.Drawing.Size(52, 17);
            this.checkBox_OsuBase.TabIndex = 0;
            this.checkBox_OsuBase.Tag = "OsuBase";
            this.checkBox_OsuBase.Text = "OsuBase";
            this.checkBox_OsuBase.UseVisualStyleBackColor = true;
            this.checkBox_OsuBase.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // textBox_mapId
            // 
            this.textBox_mapId.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_mapId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_mapId.Location = new System.Drawing.Point(11, 574);
            this.textBox_mapId.Multiline = true;
            this.textBox_mapId.Name = "textBox_mapId";
            this.textBox_mapId.ReadOnly = true;
            this.textBox_mapId.Size = new System.Drawing.Size(237, 18);
            this.textBox_mapId.TabIndex = 33;
            this.textBox_mapId.Text = "map id";
            // 
            // checkBox_IsReplay
            // 
            this.checkBox_IsReplay.AutoSize = true;
            this.checkBox_IsReplay.Checked = true;
            this.checkBox_IsReplay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_IsReplay.Location = new System.Drawing.Point(255, 233);
            this.checkBox_IsReplay.Name = "checkBox_IsReplay";
            this.checkBox_IsReplay.Size = new System.Drawing.Size(67, 17);
            this.checkBox_IsReplay.TabIndex = 2;
            this.checkBox_IsReplay.Tag = "IsReplay";
            this.checkBox_IsReplay.Text = "IsReplay";
            this.checkBox_IsReplay.UseVisualStyleBackColor = true;
            this.checkBox_IsReplay.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox_PlayContainer
            // 
            this.checkBox_PlayContainer.AutoSize = true;
            this.checkBox_PlayContainer.Checked = true;
            this.checkBox_PlayContainer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_PlayContainer.Location = new System.Drawing.Point(255, 256);
            this.checkBox_PlayContainer.Name = "checkBox_PlayContainer";
            this.checkBox_PlayContainer.Size = new System.Drawing.Size(184, 17);
            this.checkBox_PlayContainer.TabIndex = 5;
            this.checkBox_PlayContainer.Tag = "PlayContainer";
            this.checkBox_PlayContainer.Text = "PlayContainer (only when playing)";
            this.checkBox_PlayContainer.UseVisualStyleBackColor = true;
            this.checkBox_PlayContainer.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox_TourneyBase
            // 
            this.checkBox_TourneyBase.AutoSize = true;
            this.checkBox_TourneyBase.Checked = true;
            this.checkBox_TourneyBase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_TourneyBase.Location = new System.Drawing.Point(255, 302);
            this.checkBox_TourneyBase.Name = "checkBox_TourneyBase";
            this.checkBox_TourneyBase.Size = new System.Drawing.Size(217, 17);
            this.checkBox_TourneyBase.TabIndex = 4;
            this.checkBox_TourneyBase.Tag = "TourneyBase";
            this.checkBox_TourneyBase.Text = "TourneyBase (only when Tourney mode)";
            this.checkBox_TourneyBase.UseVisualStyleBackColor = true;
            this.checkBox_TourneyBase.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox_CurrentSkinData
            // 
            this.checkBox_CurrentSkinData.AutoSize = true;
            this.checkBox_CurrentSkinData.Checked = true;
            this.checkBox_CurrentSkinData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_CurrentSkinData.Location = new System.Drawing.Point(255, 279);
            this.checkBox_CurrentSkinData.Name = "checkBox_CurrentSkinData";
            this.checkBox_CurrentSkinData.Size = new System.Drawing.Size(104, 17);
            this.checkBox_CurrentSkinData.TabIndex = 3;
            this.checkBox_CurrentSkinData.Tag = "CurrentSkinData";
            this.checkBox_CurrentSkinData.Text = "CurrentSkinData";
            this.checkBox_CurrentSkinData.UseVisualStyleBackColor = true;
            this.checkBox_CurrentSkinData.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox_Mods
            // 
            this.checkBox_Mods.AutoSize = true;
            this.checkBox_Mods.Checked = true;
            this.checkBox_Mods.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Mods.Location = new System.Drawing.Point(255, 325);
            this.checkBox_Mods.Name = "checkBox_Mods";
            this.checkBox_Mods.Size = new System.Drawing.Size(52, 17);
            this.checkBox_Mods.TabIndex = 2;
            this.checkBox_Mods.Tag = "Mods";
            this.checkBox_Mods.Text = "Mods";
            this.checkBox_Mods.UseVisualStyleBackColor = true;
            this.checkBox_Mods.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 692);
            this.Controls.Add(this.checkBox_OsuBase);
            this.Controls.Add(this.checkBox_Mods);
            this.Controls.Add(this.checkBox_CurrentSkinData);
            this.Controls.Add(this.checkBox_TourneyBase);
            this.Controls.Add(this.checkBox_PlayContainer);
            this.Controls.Add(this.checkBox_IsReplay);
            this.Controls.Add(this.textBox_mapId);
            this.Controls.Add(this.button_ResetReadTimeMinMax);
            this.Controls.Add(this.numericUpDown_readDelay);
            this.Controls.Add(this.textBox_CurrentPlayData);
            this.Controls.Add(this.textBox_Status);
            this.Controls.Add(this.textBox_mapData);
            this.Controls.Add(this.textBox_time);
            this.Controls.Add(this.textBox_strings);
            this.Controls.Add(this.textBox_readTime);
            this.Controls.Add(this.textBox_toggleOsu);
            this.Controls.Add(this.button_reOpenOsu);
            this.Controls.Add(this.checkBox_topMost);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.checkBox_systemTray);
            this.Controls.Add(this.checkBox_toggleSound);
            this.Controls.Add(this.checkBox_startUp);
            this.Controls.Add(this.textBox_osuPath);
            this.Controls.Add(this.textBox_hotkey);
            this.Controls.Add(this.button_findLocation);
            this.Controls.Add(this.button_toggle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "osu!Escape";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip_osu.ResumeLayout(false);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_readDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_findLocation;
        private System.Windows.Forms.TextBox textBox_hotkey;
        private System.Windows.Forms.Button button_toggle;
        private System.Windows.Forms.TextBox textBox_osuPath;
        private System.Windows.Forms.CheckBox checkBox_startUp;
        private System.Windows.Forms.NotifyIcon notifyIcon_osuEscape;
        private System.Windows.Forms.CheckBox checkBox_toggleSound;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_osu;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_status;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_quit;
        private System.Windows.Forms.CheckBox checkBox_systemTray;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Button button_minimize;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.CheckBox checkBox_topMost;
        private System.Windows.Forms.Button button_reOpenOsu;
        private System.Windows.Forms.TextBox textBox_toggleOsu;
        private System.Windows.Forms.TextBox textBox_readTime;
        private System.Windows.Forms.TextBox textBox_strings;
        private System.Windows.Forms.TextBox textBox_time;
        private System.Windows.Forms.TextBox textBox_mapData;
        private System.Windows.Forms.TextBox textBox_Status;
        private System.Windows.Forms.TextBox textBox_CurrentPlayData;
        private System.Windows.Forms.NumericUpDown numericUpDown_readDelay;
        private System.Windows.Forms.Button button_ResetReadTimeMinMax;
        private System.Windows.Forms.CheckBox checkBox_OsuBase;
        private System.Windows.Forms.CheckBox checkBox_Mods;
        private System.Windows.Forms.CheckBox checkBox_CurrentSkinData;
        private System.Windows.Forms.CheckBox checkBox_TourneyBase;
        private System.Windows.Forms.CheckBox checkBox_PlayContainer;
        private System.Windows.Forms.CheckBox checkBox_IsReplay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_mapId;
    }
}

