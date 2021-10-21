
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
            this.findLocationButton = new System.Windows.Forms.Button();
            this.hotkeyTextBox = new System.Windows.Forms.TextBox();
            this.toggleButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.startUpChk = new System.Windows.Forms.CheckBox();
            this.osuEscapeNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.toggleSoundChk = new System.Windows.Forms.CheckBox();
            this.osuCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemTrayChk = new System.Windows.Forms.CheckBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.topMostChk = new System.Windows.Forms.CheckBox();
            this.openOsuButton = new System.Windows.Forms.Button();
            this.toggleOsuTextBox = new System.Windows.Forms.TextBox();
            this.closeOsuButton = new System.Windows.Forms.Button();
            this.osuCMS.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // findLocationButton
            // 
            this.findLocationButton.BackColor = System.Drawing.Color.Transparent;
            this.findLocationButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findLocationButton.ForeColor = System.Drawing.Color.Gray;
            this.findLocationButton.Location = new System.Drawing.Point(200, 53);
            this.findLocationButton.Name = "findLocationButton";
            this.findLocationButton.Size = new System.Drawing.Size(50, 50);
            this.findLocationButton.TabIndex = 2;
            this.findLocationButton.Text = "📂";
            this.findLocationButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.findLocationButton.UseVisualStyleBackColor = false;
            this.findLocationButton.Click += new System.EventHandler(this.FindLocationButton_Click);
            // 
            // hotkeyTextBox
            // 
            this.hotkeyTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.hotkeyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hotkeyTextBox.Location = new System.Drawing.Point(10, 129);
            this.hotkeyTextBox.Name = "hotkeyTextBox";
            this.hotkeyTextBox.ReadOnly = true;
            this.hotkeyTextBox.Size = new System.Drawing.Size(145, 13);
            this.hotkeyTextBox.TabIndex = 4;
            this.hotkeyTextBox.Text = "Global Toggle Hotkey: F6";
            // 
            // toggleButton
            // 
            this.toggleButton.BackColor = System.Drawing.Color.White;
            this.toggleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.toggleButton.Location = new System.Drawing.Point(9, 52);
            this.toggleButton.Name = "toggleButton";
            this.toggleButton.Size = new System.Drawing.Size(184, 54);
            this.toggleButton.TabIndex = 0;
            this.toggleButton.Text = "Toggle";
            this.toggleButton.UseVisualStyleBackColor = false;
            this.toggleButton.Click += new System.EventHandler(this.ToggleButton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.pathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pathTextBox.Location = new System.Drawing.Point(10, 147);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(256, 13);
            this.pathTextBox.TabIndex = 12;
            this.pathTextBox.Text = "osu! Path:";
            // 
            // startUpChk
            // 
            this.startUpChk.AutoSize = true;
            this.startUpChk.Location = new System.Drawing.Point(10, 164);
            this.startUpChk.Name = "startUpChk";
            this.startUpChk.Size = new System.Drawing.Size(96, 17);
            this.startUpChk.TabIndex = 14;
            this.startUpChk.Text = "Run at start up";
            this.startUpChk.UseVisualStyleBackColor = true;
            this.startUpChk.CheckedChanged += new System.EventHandler(this.StartUpChk_CheckedChanged);
            // 
            // osuEscapeNotifyIcon
            // 
            this.osuEscapeNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("osuEscapeNotifyIcon.Icon")));
            this.osuEscapeNotifyIcon.Text = "osu!Escape";
            this.osuEscapeNotifyIcon.Visible = true;
            this.osuEscapeNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OsuEscapeNotifyIcon_MouseDoubleClick);
            // 
            // toggleSoundChk
            // 
            this.toggleSoundChk.AutoSize = true;
            this.toggleSoundChk.Location = new System.Drawing.Point(10, 187);
            this.toggleSoundChk.Name = "toggleSoundChk";
            this.toggleSoundChk.Size = new System.Drawing.Size(113, 17);
            this.toggleSoundChk.TabIndex = 15;
            this.toggleSoundChk.Text = "Toggle with sound";
            this.toggleSoundChk.UseVisualStyleBackColor = true;
            this.toggleSoundChk.CheckedChanged += new System.EventHandler(this.ToggleSoundChk_CheckedChanged);
            // 
            // osuCMS
            // 
            this.osuCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.osuCMS.Name = "osuCMS";
            this.osuCMS.Size = new System.Drawing.Size(110, 48);
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.statusToolStripMenuItem.Text = "Status:";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // systemTrayChk
            // 
            this.systemTrayChk.AutoSize = true;
            this.systemTrayChk.Location = new System.Drawing.Point(10, 210);
            this.systemTrayChk.Name = "systemTrayChk";
            this.systemTrayChk.Size = new System.Drawing.Size(139, 17);
            this.systemTrayChk.TabIndex = 18;
            this.systemTrayChk.Text = "Minimize to System Tray";
            this.systemTrayChk.UseVisualStyleBackColor = true;
            this.systemTrayChk.CheckedChanged += new System.EventHandler(this.SystemTrayChk_CheckedChanged);
            // 
            // topPanel
            // 
            this.topPanel.AllowDrop = true;
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.topPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topPanel.Controls.Add(this.exitButton);
            this.topPanel.Controls.Add(this.minimizeBtn);
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(261, 33);
            this.topPanel.TabIndex = 1;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            this.topPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseUp);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(229, -15);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(31, 62);
            this.exitButton.TabIndex = 22;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.minimizeBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.minimizeBtn.ForeColor = System.Drawing.Color.White;
            this.minimizeBtn.Location = new System.Drawing.Point(199, -25);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(31, 62);
            this.minimizeBtn.TabIndex = 21;
            this.minimizeBtn.Text = "_";
            this.minimizeBtn.UseVisualStyleBackColor = false;
            this.minimizeBtn.Click += new System.EventHandler(this.MinimizeBtn_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AllowDrop = true;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(2, 7);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(85, 17);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "osu! Escape";
            this.titleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseDown);
            this.titleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseMove);
            this.titleLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseUp);
            // 
            // topMostChk
            // 
            this.topMostChk.AutoSize = true;
            this.topMostChk.Location = new System.Drawing.Point(10, 233);
            this.topMostChk.Name = "topMostChk";
            this.topMostChk.Size = new System.Drawing.Size(93, 17);
            this.topMostChk.TabIndex = 19;
            this.topMostChk.Text = "Always at Top";
            this.topMostChk.UseVisualStyleBackColor = true;
            this.topMostChk.CheckedChanged += new System.EventHandler(this.TopMostChk_CheckedChanged);
            // 
            // openOsuButton
            // 
            this.openOsuButton.BackColor = System.Drawing.Color.Transparent;
            this.openOsuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openOsuButton.ForeColor = System.Drawing.Color.Gray;
            this.openOsuButton.Image = ((System.Drawing.Image)(resources.GetObject("openOsuButton.Image")));
            this.openOsuButton.Location = new System.Drawing.Point(200, 109);
            this.openOsuButton.Name = "openOsuButton";
            this.openOsuButton.Size = new System.Drawing.Size(50, 50);
            this.openOsuButton.TabIndex = 20;
            this.openOsuButton.UseVisualStyleBackColor = false;
            this.openOsuButton.Click += new System.EventHandler(this.OpenOsuButton_Click);
            // 
            // toggleOsuTextBox
            // 
            this.toggleOsuTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.toggleOsuTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toggleOsuTextBox.Location = new System.Drawing.Point(10, 111);
            this.toggleOsuTextBox.Name = "toggleOsuTextBox";
            this.toggleOsuTextBox.ReadOnly = true;
            this.toggleOsuTextBox.Size = new System.Drawing.Size(145, 13);
            this.toggleOsuTextBox.TabIndex = 21;
            // 
            // closeOsuButton
            // 
            this.closeOsuButton.BackColor = System.Drawing.Color.Transparent;
            this.closeOsuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeOsuButton.ForeColor = System.Drawing.Color.Gray;
            this.closeOsuButton.Image = global::osuEscape.Properties.Resources.banned_osu_icon;
            this.closeOsuButton.Location = new System.Drawing.Point(200, 165);
            this.closeOsuButton.Name = "closeOsuButton";
            this.closeOsuButton.Size = new System.Drawing.Size(50, 50);
            this.closeOsuButton.TabIndex = 22;
            this.closeOsuButton.UseVisualStyleBackColor = false;
            this.closeOsuButton.Click += new System.EventHandler(this.CloseOsuButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 255);
            this.Controls.Add(this.closeOsuButton);
            this.Controls.Add(this.toggleOsuTextBox);
            this.Controls.Add(this.openOsuButton);
            this.Controls.Add(this.topMostChk);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.systemTrayChk);
            this.Controls.Add(this.toggleSoundChk);
            this.Controls.Add(this.startUpChk);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.hotkeyTextBox);
            this.Controls.Add(this.findLocationButton);
            this.Controls.Add(this.toggleButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "osu!Escape";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.osuCMS.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button findLocationButton;
        private System.Windows.Forms.TextBox hotkeyTextBox;
        private System.Windows.Forms.Button toggleButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.CheckBox startUpChk;
        private System.Windows.Forms.NotifyIcon osuEscapeNotifyIcon;
        private System.Windows.Forms.CheckBox toggleSoundChk;
        private System.Windows.Forms.ContextMenuStrip osuCMS;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.CheckBox systemTrayChk;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.CheckBox topMostChk;
        private System.Windows.Forms.Button openOsuButton;
        private System.Windows.Forms.TextBox toggleOsuTextBox;
        private System.Windows.Forms.Button closeOsuButton;
    }
}

