namespace osuEscape
{
    partial class SettingForm
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
            this.materialCheckbox_runAtStartup = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialCheckbox_minimizeToSystemTray = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialCheckbox_toggleWithSound = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialCheckbox_submitIfFC = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialCheckbox_hideData = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialCheckbox_topMost = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialCheckbox_autoDisconnect = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialLabel_apiNeeded = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton_back = new MaterialSkin.Controls.MaterialButton();
            this.panel_top = new System.Windows.Forms.Panel();
            this.label_title = new System.Windows.Forms.Label();
            this.panel_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCheckbox_runAtStartup
            // 
            this.materialCheckbox_runAtStartup.AutoSize = true;
            this.materialCheckbox_runAtStartup.Depth = 0;
            this.materialCheckbox_runAtStartup.Location = new System.Drawing.Point(9, 85);
            this.materialCheckbox_runAtStartup.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox_runAtStartup.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox_runAtStartup.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox_runAtStartup.Name = "materialCheckbox_runAtStartup";
            this.materialCheckbox_runAtStartup.ReadOnly = false;
            this.materialCheckbox_runAtStartup.Ripple = true;
            this.materialCheckbox_runAtStartup.Size = new System.Drawing.Size(137, 37);
            this.materialCheckbox_runAtStartup.TabIndex = 1;
            this.materialCheckbox_runAtStartup.Text = "Run at Startup";
            this.materialCheckbox_runAtStartup.UseVisualStyleBackColor = true;
            this.materialCheckbox_runAtStartup.CheckedChanged += new System.EventHandler(this.materialCheckbox_runAtStartup_CheckedChanged);
            // 
            // materialCheckbox_minimizeToSystemTray
            // 
            this.materialCheckbox_minimizeToSystemTray.AutoSize = true;
            this.materialCheckbox_minimizeToSystemTray.Depth = 0;
            this.materialCheckbox_minimizeToSystemTray.Location = new System.Drawing.Point(9, 122);
            this.materialCheckbox_minimizeToSystemTray.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox_minimizeToSystemTray.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox_minimizeToSystemTray.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox_minimizeToSystemTray.Name = "materialCheckbox_minimizeToSystemTray";
            this.materialCheckbox_minimizeToSystemTray.ReadOnly = false;
            this.materialCheckbox_minimizeToSystemTray.Ripple = true;
            this.materialCheckbox_minimizeToSystemTray.Size = new System.Drawing.Size(211, 37);
            this.materialCheckbox_minimizeToSystemTray.TabIndex = 1;
            this.materialCheckbox_minimizeToSystemTray.Text = "Minimize to System Tray";
            this.materialCheckbox_minimizeToSystemTray.UseVisualStyleBackColor = true;
            this.materialCheckbox_minimizeToSystemTray.CheckedChanged += new System.EventHandler(this.materialCheckbox_minimizeToSystemTray_CheckedChanged);
            // 
            // materialCheckbox_toggleWithSound
            // 
            this.materialCheckbox_toggleWithSound.AutoSize = true;
            this.materialCheckbox_toggleWithSound.Depth = 0;
            this.materialCheckbox_toggleWithSound.Location = new System.Drawing.Point(9, 159);
            this.materialCheckbox_toggleWithSound.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox_toggleWithSound.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox_toggleWithSound.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox_toggleWithSound.Name = "materialCheckbox_toggleWithSound";
            this.materialCheckbox_toggleWithSound.ReadOnly = false;
            this.materialCheckbox_toggleWithSound.Ripple = true;
            this.materialCheckbox_toggleWithSound.Size = new System.Drawing.Size(168, 37);
            this.materialCheckbox_toggleWithSound.TabIndex = 2;
            this.materialCheckbox_toggleWithSound.Text = "Toggle with Sound";
            this.materialCheckbox_toggleWithSound.UseVisualStyleBackColor = true;
            this.materialCheckbox_toggleWithSound.CheckedChanged += new System.EventHandler(this.materialCheckbox_toggleWithSound_CheckedChanged);
            // 
            // materialCheckbox_submitIfFC
            // 
            this.materialCheckbox_submitIfFC.AutoSize = true;
            this.materialCheckbox_submitIfFC.Depth = 0;
            this.materialCheckbox_submitIfFC.Location = new System.Drawing.Point(9, 269);
            this.materialCheckbox_submitIfFC.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox_submitIfFC.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox_submitIfFC.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox_submitIfFC.Name = "materialCheckbox_submitIfFC";
            this.materialCheckbox_submitIfFC.ReadOnly = false;
            this.materialCheckbox_submitIfFC.Ripple = true;
            this.materialCheckbox_submitIfFC.Size = new System.Drawing.Size(253, 37);
            this.materialCheckbox_submitIfFC.TabIndex = 5;
            this.materialCheckbox_submitIfFC.Text = "Submit FC score with accuracy";
            this.materialCheckbox_submitIfFC.UseVisualStyleBackColor = true;
            this.materialCheckbox_submitIfFC.CheckedChanged += new System.EventHandler(this.materialCheckbox_submitIfFC_CheckedChanged);
            // 
            // materialCheckbox_hideData
            // 
            this.materialCheckbox_hideData.AutoSize = true;
            this.materialCheckbox_hideData.Depth = 0;
            this.materialCheckbox_hideData.Location = new System.Drawing.Point(9, 232);
            this.materialCheckbox_hideData.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox_hideData.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox_hideData.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox_hideData.Name = "materialCheckbox_hideData";
            this.materialCheckbox_hideData.ReadOnly = false;
            this.materialCheckbox_hideData.Ripple = true;
            this.materialCheckbox_hideData.Size = new System.Drawing.Size(105, 37);
            this.materialCheckbox_hideData.TabIndex = 4;
            this.materialCheckbox_hideData.Text = "Hide Data";
            this.materialCheckbox_hideData.UseVisualStyleBackColor = true;
            this.materialCheckbox_hideData.CheckedChanged += new System.EventHandler(this.materialCheckbox_hideData_CheckedChanged);
            // 
            // materialCheckbox_topMost
            // 
            this.materialCheckbox_topMost.AutoSize = true;
            this.materialCheckbox_topMost.Depth = 0;
            this.materialCheckbox_topMost.Location = new System.Drawing.Point(9, 195);
            this.materialCheckbox_topMost.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox_topMost.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox_topMost.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox_topMost.Name = "materialCheckbox_topMost";
            this.materialCheckbox_topMost.ReadOnly = false;
            this.materialCheckbox_topMost.Ripple = true;
            this.materialCheckbox_topMost.Size = new System.Drawing.Size(136, 37);
            this.materialCheckbox_topMost.TabIndex = 3;
            this.materialCheckbox_topMost.Text = "Always at Top";
            this.materialCheckbox_topMost.UseVisualStyleBackColor = true;
            this.materialCheckbox_topMost.CheckedChanged += new System.EventHandler(this.materialCheckbox_topMost_CheckedChanged);
            // 
            // materialCheckbox_autoDisconnect
            // 
            this.materialCheckbox_autoDisconnect.AutoSize = true;
            this.materialCheckbox_autoDisconnect.Depth = 0;
            this.materialCheckbox_autoDisconnect.Location = new System.Drawing.Point(9, 341);
            this.materialCheckbox_autoDisconnect.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox_autoDisconnect.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox_autoDisconnect.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox_autoDisconnect.Name = "materialCheckbox_autoDisconnect";
            this.materialCheckbox_autoDisconnect.ReadOnly = false;
            this.materialCheckbox_autoDisconnect.Ripple = true;
            this.materialCheckbox_autoDisconnect.Size = new System.Drawing.Size(304, 37);
            this.materialCheckbox_autoDisconnect.TabIndex = 6;
            this.materialCheckbox_autoDisconnect.Text = "Automatically disconnect after upload";
            this.materialCheckbox_autoDisconnect.UseVisualStyleBackColor = true;
            this.materialCheckbox_autoDisconnect.CheckedChanged += new System.EventHandler(this.materialCheckbox_autoDisconnect_CheckedChanged);
            // 
            // materialLabel_apiNeeded
            // 
            this.materialLabel_apiNeeded.AutoSize = true;
            this.materialLabel_apiNeeded.Depth = 0;
            this.materialLabel_apiNeeded.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_apiNeeded.Location = new System.Drawing.Point(12, 315);
            this.materialLabel_apiNeeded.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_apiNeeded.Name = "materialLabel_apiNeeded";
            this.materialLabel_apiNeeded.Size = new System.Drawing.Size(153, 19);
            this.materialLabel_apiNeeded.TabIndex = 0;
            this.materialLabel_apiNeeded.Text = "API Needed functions";
            // 
            // materialButton_back
            // 
            this.materialButton_back.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton_back.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton_back.Depth = 0;
            this.materialButton_back.HighEmphasis = true;
            this.materialButton_back.Icon = null;
            this.materialButton_back.Location = new System.Drawing.Point(12, 43);
            this.materialButton_back.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton_back.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton_back.Name = "materialButton_back";
            this.materialButton_back.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton_back.Size = new System.Drawing.Size(123, 36);
            this.materialButton_back.TabIndex = 1;
            this.materialButton_back.Text = "Back to Main";
            this.materialButton_back.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialButton_back.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton_back.UseAccentColor = false;
            this.materialButton_back.UseVisualStyleBackColor = true;
            this.materialButton_back.Click += new System.EventHandler(this.MaterialButton_back_Click);
            // 
            // panel_top
            // 
            this.panel_top.AllowDrop = true;
            this.panel_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.panel_top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_top.Controls.Add(this.label_title);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(426, 38);
            this.panel_top.TabIndex = 7;
            this.panel_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_top_MouseDown);
            this.panel_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_top_MouseMove);
            this.panel_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel_top_MouseUp);
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
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 387);
            this.ControlBox = false;
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.materialButton_back);
            this.Controls.Add(this.materialLabel_apiNeeded);
            this.Controls.Add(this.materialCheckbox_autoDisconnect);
            this.Controls.Add(this.materialCheckbox_submitIfFC);
            this.Controls.Add(this.materialCheckbox_hideData);
            this.Controls.Add(this.materialCheckbox_topMost);
            this.Controls.Add(this.materialCheckbox_toggleWithSound);
            this.Controls.Add(this.materialCheckbox_minimizeToSystemTray);
            this.Controls.Add(this.materialCheckbox_runAtStartup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_runAtStartup;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_minimizeToSystemTray;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_toggleWithSound;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_submitIfFC;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_hideData;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_topMost;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_autoDisconnect;
        private MaterialSkin.Controls.MaterialLabel materialLabel_apiNeeded;
        private MaterialSkin.Controls.MaterialButton materialButton_back;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Label label_title;
    }
}