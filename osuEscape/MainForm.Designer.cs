namespace osuEscape
{
    partial class osuEscape
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(osuEscape));
            this.textBox_mapData = new System.Windows.Forms.TextBox();
            this.label_status = new System.Windows.Forms.Label();
            this.textBox_Status = new System.Windows.Forms.TextBox();
            this.label_currentPlayingData = new System.Windows.Forms.Label();
            this.textBox_currentPlayData = new System.Windows.Forms.TextBox();
            this.label_refreshRate = new System.Windows.Forms.Label();
            this.numericUpDown_readDelay = new System.Windows.Forms.NumericUpDown();
            this.textBox_currentMapTime = new System.Windows.Forms.TextBox();
            this.button_ResetReadTimeMinMax = new System.Windows.Forms.Button();
            this.panel_top = new System.Windows.Forms.Panel();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_minimize = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.button_findLocation = new System.Windows.Forms.Button();
            this.button_toggle = new System.Windows.Forms.Button();
            this.label_currentMapTime = new System.Windows.Forms.Label();
            this.checkBox_topMost = new System.Windows.Forms.CheckBox();
            this.checkBox_systemTray = new System.Windows.Forms.CheckBox();
            this.checkBox_toggleSound = new System.Windows.Forms.CheckBox();
            this.checkBox_startUp = new System.Windows.Forms.CheckBox();
            this.textBox_osuPath = new System.Windows.Forms.TextBox();
            this.textBox_hotkey = new System.Windows.Forms.TextBox();
            this.notifyIcon_osuEscape = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_osu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_map = new System.Windows.Forms.Label();
            this.checkBox_submitIfFC = new System.Windows.Forms.CheckBox();
            this.checkBox_hideData = new System.Windows.Forms.CheckBox();
            this.groupBox_checkBoxes = new System.Windows.Forms.GroupBox();
            this.checkBox_autoDisconnect = new System.Windows.Forms.CheckBox();
            this.textBox_submitAcc = new System.Windows.Forms.TextBox();
            this.groupBox_Data = new System.Windows.Forms.GroupBox();
            this.textBox_apiKey = new System.Windows.Forms.TextBox();
            this.label_apiKey = new System.Windows.Forms.Label();
            this.button_checkApiKey = new System.Windows.Forms.Button();
            this.label_submissionStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_readDelay)).BeginInit();
            this.panel_top.SuspendLayout();
            this.contextMenuStrip_osu.SuspendLayout();
            this.groupBox_checkBoxes.SuspendLayout();
            this.groupBox_Data.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_mapData
            // 
            this.textBox_mapData.Location = new System.Drawing.Point(5, 18);
            this.textBox_mapData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_mapData.Multiline = true;
            this.textBox_mapData.Name = "textBox_mapData";
            this.textBox_mapData.Size = new System.Drawing.Size(280, 97);
            this.textBox_mapData.TabIndex = 1;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(290, 107);
            this.label_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(39, 15);
            this.label_status.TabIndex = 5;
            this.label_status.Text = "Status";
            // 
            // textBox_Status
            // 
            this.textBox_Status.Location = new System.Drawing.Point(290, 122);
            this.textBox_Status.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Status.Name = "textBox_Status";
            this.textBox_Status.Size = new System.Drawing.Size(116, 23);
            this.textBox_Status.TabIndex = 4;
            // 
            // label_currentPlayingData
            // 
            this.label_currentPlayingData.AutoSize = true;
            this.label_currentPlayingData.Cursor = System.Windows.Forms.Cursors.No;
            this.label_currentPlayingData.Location = new System.Drawing.Point(-1, 118);
            this.label_currentPlayingData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_currentPlayingData.Name = "label_currentPlayingData";
            this.label_currentPlayingData.Size = new System.Drawing.Size(116, 15);
            this.label_currentPlayingData.TabIndex = 7;
            this.label_currentPlayingData.Text = "Current Playing Data";
            // 
            // textBox_currentPlayData
            // 
            this.textBox_currentPlayData.Location = new System.Drawing.Point(5, 134);
            this.textBox_currentPlayData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_currentPlayData.Multiline = true;
            this.textBox_currentPlayData.Name = "textBox_currentPlayData";
            this.textBox_currentPlayData.Size = new System.Drawing.Size(279, 103);
            this.textBox_currentPlayData.TabIndex = 6;
            // 
            // label_refreshRate
            // 
            this.label_refreshRate.AutoSize = true;
            this.label_refreshRate.Location = new System.Drawing.Point(290, 148);
            this.label_refreshRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_refreshRate.Name = "label_refreshRate";
            this.label_refreshRate.Size = new System.Drawing.Size(104, 15);
            this.label_refreshRate.TabIndex = 9;
            this.label_refreshRate.Text = "Refresh rate in ms ";
            // 
            // numericUpDown_readDelay
            // 
            this.numericUpDown_readDelay.Location = new System.Drawing.Point(292, 167);
            this.numericUpDown_readDelay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericUpDown_readDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_readDelay.Name = "numericUpDown_readDelay";
            this.numericUpDown_readDelay.Size = new System.Drawing.Size(77, 23);
            this.numericUpDown_readDelay.TabIndex = 10;
            this.numericUpDown_readDelay.Value = new decimal(new int[] {
            33,
            0,
            0,
            0});
            // 
            // textBox_currentMapTime
            // 
            this.textBox_currentMapTime.Location = new System.Drawing.Point(289, 79);
            this.textBox_currentMapTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_currentMapTime.Name = "textBox_currentMapTime";
            this.textBox_currentMapTime.Size = new System.Drawing.Size(116, 23);
            this.textBox_currentMapTime.TabIndex = 13;
            // 
            // button_ResetReadTimeMinMax
            // 
            this.button_ResetReadTimeMinMax.Location = new System.Drawing.Point(290, 195);
            this.button_ResetReadTimeMinMax.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_ResetReadTimeMinMax.Name = "button_ResetReadTimeMinMax";
            this.button_ResetReadTimeMinMax.Size = new System.Drawing.Size(75, 23);
            this.button_ResetReadTimeMinMax.TabIndex = 17;
            this.button_ResetReadTimeMinMax.Text = "Reset";
            this.button_ResetReadTimeMinMax.UseVisualStyleBackColor = true;
            this.button_ResetReadTimeMinMax.Click += new System.EventHandler(this.Button_ResetReadTimeMinMax_Click);
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
            this.panel_top.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(426, 38);
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
            this.button_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_exit.ForeColor = System.Drawing.Color.White;
            this.button_exit.Location = new System.Drawing.Point(389, -15);
            this.button_exit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(36, 72);
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
            this.button_minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_minimize.ForeColor = System.Drawing.Color.White;
            this.button_minimize.Location = new System.Drawing.Point(354, -27);
            this.button_minimize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_minimize.Name = "button_minimize";
            this.button_minimize.Size = new System.Drawing.Size(36, 72);
            this.button_minimize.TabIndex = 21;
            this.button_minimize.Text = "_";
            this.button_minimize.UseVisualStyleBackColor = false;
            this.button_minimize.Click += new System.EventHandler(this.Button_minimize_Click);
            // 
            // label_title
            // 
            this.label_title.AllowDrop = true;
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            // button_findLocation
            // 
            this.button_findLocation.BackColor = System.Drawing.Color.Transparent;
            this.button_findLocation.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_findLocation.ForeColor = System.Drawing.Color.Gray;
            this.button_findLocation.Location = new System.Drawing.Point(297, 51);
            this.button_findLocation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_findLocation.Name = "button_findLocation";
            this.button_findLocation.Size = new System.Drawing.Size(58, 58);
            this.button_findLocation.TabIndex = 24;
            this.button_findLocation.Text = "📂";
            this.button_findLocation.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button_findLocation.UseVisualStyleBackColor = false;
            this.button_findLocation.Click += new System.EventHandler(this.Button_findLocation_Click);
            // 
            // button_toggle
            // 
            this.button_toggle.BackColor = System.Drawing.Color.White;
            this.button_toggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_toggle.Location = new System.Drawing.Point(67, 48);
            this.button_toggle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_toggle.Name = "button_toggle";
            this.button_toggle.Size = new System.Drawing.Size(215, 62);
            this.button_toggle.TabIndex = 23;
            this.button_toggle.Text = "Toggle";
            this.button_toggle.UseVisualStyleBackColor = false;
            this.button_toggle.Click += new System.EventHandler(this.Button_toggle_Click);
            // 
            // label_currentMapTime
            // 
            this.label_currentMapTime.AutoSize = true;
            this.label_currentMapTime.Location = new System.Drawing.Point(289, 61);
            this.label_currentMapTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_currentMapTime.Name = "label_currentMapTime";
            this.label_currentMapTime.Size = new System.Drawing.Size(103, 15);
            this.label_currentMapTime.TabIndex = 25;
            this.label_currentMapTime.Text = "Current Map Time";
            // 
            // checkBox_topMost
            // 
            this.checkBox_topMost.AutoSize = true;
            this.checkBox_topMost.Location = new System.Drawing.Point(136, 65);
            this.checkBox_topMost.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox_topMost.Name = "checkBox_topMost";
            this.checkBox_topMost.Size = new System.Drawing.Size(98, 19);
            this.checkBox_topMost.TabIndex = 31;
            this.checkBox_topMost.Text = "Always at Top";
            this.checkBox_topMost.UseVisualStyleBackColor = true;
            this.checkBox_topMost.CheckedChanged += new System.EventHandler(this.CheckBox_topMost_CheckedChanged);
            // 
            // checkBox_systemTray
            // 
            this.checkBox_systemTray.AutoSize = true;
            this.checkBox_systemTray.Location = new System.Drawing.Point(135, 40);
            this.checkBox_systemTray.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox_systemTray.Name = "checkBox_systemTray";
            this.checkBox_systemTray.Size = new System.Drawing.Size(154, 19);
            this.checkBox_systemTray.TabIndex = 30;
            this.checkBox_systemTray.Text = "Minimize to System Tray";
            this.checkBox_systemTray.UseVisualStyleBackColor = true;
            this.checkBox_systemTray.CheckedChanged += new System.EventHandler(this.CheckBox_systemTray_CheckedChanged);
            // 
            // checkBox_toggleSound
            // 
            this.checkBox_toggleSound.AutoSize = true;
            this.checkBox_toggleSound.Location = new System.Drawing.Point(5, 65);
            this.checkBox_toggleSound.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox_toggleSound.Name = "checkBox_toggleSound";
            this.checkBox_toggleSound.Size = new System.Drawing.Size(123, 19);
            this.checkBox_toggleSound.TabIndex = 29;
            this.checkBox_toggleSound.Text = "Toggle with sound";
            this.checkBox_toggleSound.UseVisualStyleBackColor = true;
            this.checkBox_toggleSound.CheckedChanged += new System.EventHandler(this.CheckBox_toggleSound_CheckedChanged);
            // 
            // checkBox_startUp
            // 
            this.checkBox_startUp.AutoSize = true;
            this.checkBox_startUp.Location = new System.Drawing.Point(5, 40);
            this.checkBox_startUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox_startUp.Name = "checkBox_startUp";
            this.checkBox_startUp.Size = new System.Drawing.Size(103, 19);
            this.checkBox_startUp.TabIndex = 28;
            this.checkBox_startUp.Text = "Run at start up";
            this.checkBox_startUp.UseVisualStyleBackColor = true;
            this.checkBox_startUp.CheckedChanged += new System.EventHandler(this.CheckBox_startUp_CheckedChanged);
            // 
            // textBox_osuPath
            // 
            this.textBox_osuPath.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_osuPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_osuPath.Location = new System.Drawing.Point(5, 20);
            this.textBox_osuPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_osuPath.Name = "textBox_osuPath";
            this.textBox_osuPath.ReadOnly = true;
            this.textBox_osuPath.Size = new System.Drawing.Size(299, 16);
            this.textBox_osuPath.TabIndex = 27;
            this.textBox_osuPath.Text = "osu! Path:";
            // 
            // textBox_hotkey
            // 
            this.textBox_hotkey.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_hotkey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_hotkey.Location = new System.Drawing.Point(241, 21);
            this.textBox_hotkey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_hotkey.Name = "textBox_hotkey";
            this.textBox_hotkey.ReadOnly = true;
            this.textBox_hotkey.Size = new System.Drawing.Size(135, 16);
            this.textBox_hotkey.TabIndex = 26;
            this.textBox_hotkey.Text = "Global Toggle Hotkey: F6";
            // 
            // notifyIcon_osuEscape
            // 
            this.notifyIcon_osuEscape.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_osuEscape.Icon")));
            this.notifyIcon_osuEscape.Text = "osu! Escape";
            this.notifyIcon_osuEscape.Visible = true;
            this.notifyIcon_osuEscape.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_osuEscape_MouseDoubleClick);
            // 
            // contextMenuStrip_osu
            // 
            this.contextMenuStrip_osu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripMenuItem,
            this.connectingToolStripMenuItem});
            this.contextMenuStrip_osu.Name = "contextMenuStrip_osu";
            this.contextMenuStrip_osu.Size = new System.Drawing.Size(107, 48);
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.statusToolStripMenuItem.Text = "Status";
            // 
            // connectingToolStripMenuItem
            // 
            this.connectingToolStripMenuItem.Name = "connectingToolStripMenuItem";
            this.connectingToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.connectingToolStripMenuItem.Text = "Quit";
            // 
            // label_map
            // 
            this.label_map.AutoSize = true;
            this.label_map.Location = new System.Drawing.Point(3, 0);
            this.label_map.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_map.Name = "label_map";
            this.label_map.Size = new System.Drawing.Size(31, 15);
            this.label_map.TabIndex = 32;
            this.label_map.Text = "Map";
            // 
            // checkBox_submitIfFC
            // 
            this.checkBox_submitIfFC.AutoSize = true;
            this.checkBox_submitIfFC.Location = new System.Drawing.Point(5, 90);
            this.checkBox_submitIfFC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox_submitIfFC.Name = "checkBox_submitIfFC";
            this.checkBox_submitIfFC.Size = new System.Drawing.Size(247, 19);
            this.checkBox_submitIfFC.TabIndex = 33;
            this.checkBox_submitIfFC.Text = "Submit if FC with ≥          acc (API needed)";
            this.checkBox_submitIfFC.UseVisualStyleBackColor = true;
            this.checkBox_submitIfFC.CheckedChanged += new System.EventHandler(this.CheckBox_submitIfFC_CheckedChanged);
            // 
            // checkBox_hideData
            // 
            this.checkBox_hideData.AutoSize = true;
            this.checkBox_hideData.Location = new System.Drawing.Point(290, 42);
            this.checkBox_hideData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox_hideData.Name = "checkBox_hideData";
            this.checkBox_hideData.Size = new System.Drawing.Size(78, 19);
            this.checkBox_hideData.TabIndex = 34;
            this.checkBox_hideData.Text = "Hide Data";
            this.checkBox_hideData.UseVisualStyleBackColor = true;
            this.checkBox_hideData.CheckedChanged += new System.EventHandler(this.CheckBox_hideData_CheckedChanged);
            // 
            // groupBox_checkBoxes
            // 
            this.groupBox_checkBoxes.Controls.Add(this.checkBox_autoDisconnect);
            this.groupBox_checkBoxes.Controls.Add(this.textBox_submitAcc);
            this.groupBox_checkBoxes.Controls.Add(this.textBox_hotkey);
            this.groupBox_checkBoxes.Controls.Add(this.checkBox_hideData);
            this.groupBox_checkBoxes.Controls.Add(this.checkBox_submitIfFC);
            this.groupBox_checkBoxes.Controls.Add(this.checkBox_topMost);
            this.groupBox_checkBoxes.Controls.Add(this.checkBox_systemTray);
            this.groupBox_checkBoxes.Controls.Add(this.checkBox_toggleSound);
            this.groupBox_checkBoxes.Controls.Add(this.checkBox_startUp);
            this.groupBox_checkBoxes.Controls.Add(this.textBox_osuPath);
            this.groupBox_checkBoxes.Location = new System.Drawing.Point(8, 394);
            this.groupBox_checkBoxes.Name = "groupBox_checkBoxes";
            this.groupBox_checkBoxes.Size = new System.Drawing.Size(381, 139);
            this.groupBox_checkBoxes.TabIndex = 35;
            this.groupBox_checkBoxes.TabStop = false;
            // 
            // checkBox_autoDisconnect
            // 
            this.checkBox_autoDisconnect.AutoSize = true;
            this.checkBox_autoDisconnect.Location = new System.Drawing.Point(5, 114);
            this.checkBox_autoDisconnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox_autoDisconnect.Name = "checkBox_autoDisconnect";
            this.checkBox_autoDisconnect.Size = new System.Drawing.Size(228, 19);
            this.checkBox_autoDisconnect.TabIndex = 36;
            this.checkBox_autoDisconnect.Text = "Automatically disconnect after upload";
            this.checkBox_autoDisconnect.UseVisualStyleBackColor = true;
            this.checkBox_autoDisconnect.CheckedChanged += new System.EventHandler(this.checkBox_autoDisconnect_CheckedChanged);
            // 
            // textBox_submitAcc
            // 
            this.textBox_submitAcc.Location = new System.Drawing.Point(127, 88);
            this.textBox_submitAcc.MaxLength = 3;
            this.textBox_submitAcc.Name = "textBox_submitAcc";
            this.textBox_submitAcc.Size = new System.Drawing.Size(25, 23);
            this.textBox_submitAcc.TabIndex = 35;
            this.textBox_submitAcc.Text = "100";
            this.textBox_submitAcc.TextChanged += new System.EventHandler(this.TextBox_submitAcc_TextChanged);
            // 
            // groupBox_Data
            // 
            this.groupBox_Data.Controls.Add(this.label_map);
            this.groupBox_Data.Controls.Add(this.label_currentMapTime);
            this.groupBox_Data.Controls.Add(this.button_ResetReadTimeMinMax);
            this.groupBox_Data.Controls.Add(this.textBox_currentMapTime);
            this.groupBox_Data.Controls.Add(this.numericUpDown_readDelay);
            this.groupBox_Data.Controls.Add(this.label_refreshRate);
            this.groupBox_Data.Controls.Add(this.label_currentPlayingData);
            this.groupBox_Data.Controls.Add(this.textBox_currentPlayData);
            this.groupBox_Data.Controls.Add(this.label_status);
            this.groupBox_Data.Controls.Add(this.textBox_Status);
            this.groupBox_Data.Controls.Add(this.textBox_mapData);
            this.groupBox_Data.Location = new System.Drawing.Point(8, 111);
            this.groupBox_Data.Name = "groupBox_Data";
            this.groupBox_Data.Size = new System.Drawing.Size(409, 243);
            this.groupBox_Data.TabIndex = 36;
            this.groupBox_Data.TabStop = false;
            // 
            // textBox_apiKey
            // 
            this.textBox_apiKey.Location = new System.Drawing.Point(11, 373);
            this.textBox_apiKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_apiKey.Name = "textBox_apiKey";
            this.textBox_apiKey.Size = new System.Drawing.Size(201, 23);
            this.textBox_apiKey.TabIndex = 33;
            this.textBox_apiKey.UseSystemPasswordChar = true;
            // 
            // label_apiKey
            // 
            this.label_apiKey.AutoSize = true;
            this.label_apiKey.Location = new System.Drawing.Point(11, 357);
            this.label_apiKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_apiKey.Name = "label_apiKey";
            this.label_apiKey.Size = new System.Drawing.Size(107, 15);
            this.label_apiKey.TabIndex = 34;
            this.label_apiKey.Text = "Input your API key:";
            // 
            // button_checkApiKey
            // 
            this.button_checkApiKey.Location = new System.Drawing.Point(220, 372);
            this.button_checkApiKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_checkApiKey.Name = "button_checkApiKey";
            this.button_checkApiKey.Size = new System.Drawing.Size(75, 23);
            this.button_checkApiKey.TabIndex = 33;
            this.button_checkApiKey.Text = "Check";
            this.button_checkApiKey.UseVisualStyleBackColor = true;
            this.button_checkApiKey.Click += new System.EventHandler(this.Button_checkApiKey_Click);
            // 
            // label_submissionStatus
            // 
            this.label_submissionStatus.AutoSize = true;
            this.label_submissionStatus.Location = new System.Drawing.Point(8, 536);
            this.label_submissionStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_submissionStatus.Name = "label_submissionStatus";
            this.label_submissionStatus.Size = new System.Drawing.Size(105, 15);
            this.label_submissionStatus.TabIndex = 38;
            this.label_submissionStatus.Text = "Submission status:";
            // 
            // osuEscape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 559);
            this.ControlBox = false;
            this.Controls.Add(this.label_submissionStatus);
            this.Controls.Add(this.button_checkApiKey);
            this.Controls.Add(this.label_apiKey);
            this.Controls.Add(this.textBox_apiKey);
            this.Controls.Add(this.groupBox_Data);
            this.Controls.Add(this.groupBox_checkBoxes);
            this.Controls.Add(this.button_findLocation);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.button_toggle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "osuEscape";
            this.Text = "osu!Escape";
            this.Load += new System.EventHandler(this.OsuEscape_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_readDelay)).EndInit();
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.contextMenuStrip_osu.ResumeLayout(false);
            this.groupBox_checkBoxes.ResumeLayout(false);
            this.groupBox_checkBoxes.PerformLayout();
            this.groupBox_Data.ResumeLayout(false);
            this.groupBox_Data.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.TextBox textBox_Status;
        private System.Windows.Forms.Label label_currentPlayingData;
        private System.Windows.Forms.TextBox textBox_currentPlayData;
        private System.Windows.Forms.Label label_refreshRate;
        private System.Windows.Forms.NumericUpDown numericUpDown_readDelay;
        private System.Windows.Forms.Button button_ResetReadTimeMinMax;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_minimize;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Button button_findLocation;
        private System.Windows.Forms.Button button_toggle;
        private System.Windows.Forms.Label label_currentMapTime;
        private System.Windows.Forms.CheckBox checkBox_topMost;
        private System.Windows.Forms.CheckBox checkBox_systemTray;
        private System.Windows.Forms.CheckBox checkBox_toggleSound;
        private System.Windows.Forms.CheckBox checkBox_startUp;
        private System.Windows.Forms.TextBox textBox_osuPath;
        private System.Windows.Forms.TextBox textBox_hotkey;
        private System.Windows.Forms.NotifyIcon notifyIcon_osuEscape;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_osu;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectingToolStripMenuItem;
        private System.Windows.Forms.Label label_map;
        private System.Windows.Forms.CheckBox checkBox_submitIfFC;
        private System.Windows.Forms.CheckBox checkBox_hideData;
        private System.Windows.Forms.TextBox textBox_currentMapTime;
        private System.Windows.Forms.GroupBox groupBox_checkBoxes;
        private System.Windows.Forms.GroupBox groupBox_Data;
        private System.Windows.Forms.TextBox textBox_apiKey;
        private System.Windows.Forms.Label label_apiKey;
        private System.Windows.Forms.Button button_checkApiKey;
        private System.Windows.Forms.TextBox textBox_mapData;
        private System.Windows.Forms.TextBox textBox_submitAcc;
        private System.Windows.Forms.Label label_submissionStatus;
        private System.Windows.Forms.CheckBox checkBox_autoDisconnect;
    }
}

