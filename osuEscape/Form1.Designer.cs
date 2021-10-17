
namespace osuEscape
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.findLocationButton = new System.Windows.Forms.Button();
            this.hotkeyTextBox = new System.Windows.Forms.TextBox();
            this.toggleButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.startUpChk = new System.Windows.Forms.CheckBox();
            this.osuEscapeNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.toggleSoundChk = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemTrayChk = new System.Windows.Forms.CheckBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // findLocationButton
            // 
            this.findLocationButton.BackColor = System.Drawing.Color.Transparent;
            this.findLocationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findLocationButton.ForeColor = System.Drawing.Color.Gray;
            this.findLocationButton.Location = new System.Drawing.Point(197, 53);
            this.findLocationButton.Name = "findLocationButton";
            this.findLocationButton.Size = new System.Drawing.Size(52, 52);
            this.findLocationButton.TabIndex = 2;
            this.findLocationButton.Text = "📂";
            this.findLocationButton.UseVisualStyleBackColor = false;
            this.findLocationButton.Click += new System.EventHandler(this.FindLocationButton_Click);
            // 
            // hotkeyTextBox
            // 
            this.hotkeyTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.hotkeyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hotkeyTextBox.Location = new System.Drawing.Point(10, 109);
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
            this.pathTextBox.Location = new System.Drawing.Point(10, 127);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(256, 13);
            this.pathTextBox.TabIndex = 12;
            this.pathTextBox.Text = "osu! Path:";
            // 
            // startUpChk
            // 
            this.startUpChk.AutoSize = true;
            this.startUpChk.Location = new System.Drawing.Point(10, 144);
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
            this.osuEscapeNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // toggleSoundChk
            // 
            this.toggleSoundChk.AutoSize = true;
            this.toggleSoundChk.Location = new System.Drawing.Point(10, 167);
            this.toggleSoundChk.Name = "toggleSoundChk";
            this.toggleSoundChk.Size = new System.Drawing.Size(113, 17);
            this.toggleSoundChk.TabIndex = 15;
            this.toggleSoundChk.Text = "Toggle with sound";
            this.toggleSoundChk.UseVisualStyleBackColor = true;
            this.toggleSoundChk.CheckedChanged += new System.EventHandler(this.ToggleSoundChk_CheckedChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 48);
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
            this.systemTrayChk.Location = new System.Drawing.Point(10, 190);
            this.systemTrayChk.Name = "systemTrayChk";
            this.systemTrayChk.Size = new System.Drawing.Size(139, 17);
            this.systemTrayChk.TabIndex = 18;
            this.systemTrayChk.Text = "Minimize to System Tray";
            this.systemTrayChk.UseVisualStyleBackColor = true;
            this.systemTrayChk.CheckedChanged += new System.EventHandler(this.SystemTrayChk_CheckedChanged);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.topPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topPanel.Controls.Add(this.minimizeBtn);
            this.topPanel.Controls.Add(this.exitButton);
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(266, 33);
            this.topPanel.TabIndex = 19;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            this.topPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseUp);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.minimizeBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.minimizeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.minimizeBtn.ForeColor = System.Drawing.Color.White;
            this.minimizeBtn.Location = new System.Drawing.Point(201, -25);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(31, 62);
            this.minimizeBtn.TabIndex = 21;
            this.minimizeBtn.Text = "_";
            this.minimizeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.minimizeBtn.UseVisualStyleBackColor = false;
            this.minimizeBtn.Click += new System.EventHandler(this.MinimizeBtn_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(234, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(31, 33);
            this.exitButton.TabIndex = 20;
            this.exitButton.Text = "X";
            this.exitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(3, 4);
            this.titleLabel.Name = "label1";
            this.titleLabel.Size = new System.Drawing.Size(132, 26);
            this.titleLabel.TabIndex = 20;
            this.titleLabel.Text = "osu! Escape";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 217);
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
            this.Name = "Form1";
            this.Text = "osu!Escape";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.CheckBox systemTrayChk;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button minimizeBtn;
    }
}

