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
        //private void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            materialSlider_refreshRate = new MaterialSkin.Controls.MaterialSlider();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialButton_findOsuLocation = new MaterialSkin.Controls.MaterialButton();
            materialLabel_globalToggleHotkey = new MaterialSkin.Controls.MaterialLabel();
            materialLabel_osuPath = new MaterialSkin.Controls.MaterialLabel();
            materialSwitch_osuConnection = new MaterialSkin.Controls.MaterialSwitch();
            materialLabel_submissionStatus = new MaterialSkin.Controls.MaterialLabel();
            materialButton_changeToggleHotkey = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // materialSlider_refreshRate
            // 
            materialSlider_refreshRate.Depth = 0;
            materialSlider_refreshRate.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            materialSlider_refreshRate.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            materialSlider_refreshRate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            materialSlider_refreshRate.Location = new System.Drawing.Point(340, 153);
            materialSlider_refreshRate.MouseState = MaterialSkin.MouseState.HOVER;
            materialSlider_refreshRate.Name = "materialSlider_refreshRate";
            materialSlider_refreshRate.RangeMax = 1000;
            materialSlider_refreshRate.RangeMin = 50;
            materialSlider_refreshRate.Size = new System.Drawing.Size(146, 40);
            materialSlider_refreshRate.TabIndex = 39;
            materialSlider_refreshRate.TabStop = false;
            materialSlider_refreshRate.Text = "";
            materialSlider_refreshRate.UseAccentColor = true;
            materialSlider_refreshRate.ValueMax = 1000;
            materialSlider_refreshRate.ValueSuffix = "ms";
            materialSlider_refreshRate.onValueChanged += materialSlider_refreshRate_onValueChanged;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            materialLabel3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            materialLabel3.Location = new System.Drawing.Point(365, 135);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new System.Drawing.Size(86, 19);
            materialLabel3.TabIndex = 38;
            materialLabel3.Text = "Refresh rate";
            materialLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialButton_findOsuLocation
            // 
            materialButton_findOsuLocation.AutoSize = false;
            materialButton_findOsuLocation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            materialButton_findOsuLocation.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_findOsuLocation.Depth = 0;
            materialButton_findOsuLocation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            materialButton_findOsuLocation.HighEmphasis = true;
            materialButton_findOsuLocation.Icon = null;
            materialButton_findOsuLocation.Location = new System.Drawing.Point(293, 73);
            materialButton_findOsuLocation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            materialButton_findOsuLocation.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_findOsuLocation.Name = "materialButton_findOsuLocation";
            materialButton_findOsuLocation.NoAccentTextColor = System.Drawing.Color.Empty;
            materialButton_findOsuLocation.Size = new System.Drawing.Size(193, 50);
            materialButton_findOsuLocation.TabIndex = 36;
            materialButton_findOsuLocation.TabStop = false;
            materialButton_findOsuLocation.Text = "find osu!.exe location";
            materialButton_findOsuLocation.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton_findOsuLocation.UseAccentColor = false;
            materialButton_findOsuLocation.UseVisualStyleBackColor = true;
            materialButton_findOsuLocation.Click += materialButton_findOsuLocation_Click;
            // 
            // materialLabel_globalToggleHotkey
            // 
            materialLabel_globalToggleHotkey.AutoSize = true;
            materialLabel_globalToggleHotkey.Depth = 0;
            materialLabel_globalToggleHotkey.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            materialLabel_globalToggleHotkey.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            materialLabel_globalToggleHotkey.Location = new System.Drawing.Point(13, 49);
            materialLabel_globalToggleHotkey.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel_globalToggleHotkey.Name = "materialLabel_globalToggleHotkey";
            materialLabel_globalToggleHotkey.Size = new System.Drawing.Size(161, 19);
            materialLabel_globalToggleHotkey.TabIndex = 35;
            materialLabel_globalToggleHotkey.Text = "Global Toggle Hotkey: ";
            // 
            // materialLabel_osuPath
            // 
            materialLabel_osuPath.AutoEllipsis = true;
            materialLabel_osuPath.AutoSize = true;
            materialLabel_osuPath.Depth = 0;
            materialLabel_osuPath.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            materialLabel_osuPath.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            materialLabel_osuPath.Location = new System.Drawing.Point(13, 111);
            materialLabel_osuPath.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel_osuPath.Name = "materialLabel_osuPath";
            materialLabel_osuPath.Size = new System.Drawing.Size(76, 19);
            materialLabel_osuPath.TabIndex = 1;
            materialLabel_osuPath.Text = "osu! Path: ";
            // 
            // materialSwitch_osuConnection
            // 
            materialSwitch_osuConnection.AutoSize = true;
            materialSwitch_osuConnection.Depth = 0;
            materialSwitch_osuConnection.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            materialSwitch_osuConnection.Location = new System.Drawing.Point(3, 3);
            materialSwitch_osuConnection.Margin = new System.Windows.Forms.Padding(0);
            materialSwitch_osuConnection.MouseLocation = new System.Drawing.Point(-1, -1);
            materialSwitch_osuConnection.MouseState = MaterialSkin.MouseState.HOVER;
            materialSwitch_osuConnection.Name = "materialSwitch_osuConnection";
            materialSwitch_osuConnection.Ripple = true;
            materialSwitch_osuConnection.Size = new System.Drawing.Size(215, 37);
            materialSwitch_osuConnection.TabIndex = 33;
            materialSwitch_osuConnection.TabStop = false;
            materialSwitch_osuConnection.Text = "Block osu! Connection";
            materialSwitch_osuConnection.UseVisualStyleBackColor = true;
            materialSwitch_osuConnection.CheckedChanged += materialSwitch_osuConnection_CheckedChanged;
            // 
            // materialLabel_submissionStatus
            // 
            materialLabel_submissionStatus.AutoSize = true;
            materialLabel_submissionStatus.Depth = 0;
            materialLabel_submissionStatus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            materialLabel_submissionStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            materialLabel_submissionStatus.Location = new System.Drawing.Point(13, 174);
            materialLabel_submissionStatus.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel_submissionStatus.Name = "materialLabel_submissionStatus";
            materialLabel_submissionStatus.Size = new System.Drawing.Size(143, 19);
            materialLabel_submissionStatus.TabIndex = 32;
            materialLabel_submissionStatus.Text = "Submission Status: ";
            // 
            // materialButton_changeToggleHotkey
            // 
            materialButton_changeToggleHotkey.AutoSize = false;
            materialButton_changeToggleHotkey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            materialButton_changeToggleHotkey.BackColor = System.Drawing.Color.DeepSkyBlue;
            materialButton_changeToggleHotkey.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_changeToggleHotkey.Depth = 0;
            materialButton_changeToggleHotkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            materialButton_changeToggleHotkey.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            materialButton_changeToggleHotkey.HighEmphasis = true;
            materialButton_changeToggleHotkey.Icon = null;
            materialButton_changeToggleHotkey.Location = new System.Drawing.Point(293, 11);
            materialButton_changeToggleHotkey.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            materialButton_changeToggleHotkey.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_changeToggleHotkey.Name = "materialButton_changeToggleHotkey";
            materialButton_changeToggleHotkey.NoAccentTextColor = System.Drawing.Color.Empty;
            materialButton_changeToggleHotkey.Size = new System.Drawing.Size(193, 50);
            materialButton_changeToggleHotkey.TabIndex = 37;
            materialButton_changeToggleHotkey.TabStop = false;
            materialButton_changeToggleHotkey.Text = "Change Toggle Hotkey";
            materialButton_changeToggleHotkey.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            materialButton_changeToggleHotkey.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton_changeToggleHotkey.UseAccentColor = false;
            materialButton_changeToggleHotkey.UseVisualStyleBackColor = false;
            materialButton_changeToggleHotkey.Click += materialButton_changeToggleHotkey_Click;
            materialButton_changeToggleHotkey.KeyDown += MainForm_KeyDown;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            ClientSize = new System.Drawing.Size(503, 214);
            Controls.Add(materialLabel_osuPath);
            Controls.Add(materialSlider_refreshRate);
            Controls.Add(materialLabel3);
            Controls.Add(materialButton_findOsuLocation);
            Controls.Add(materialLabel_globalToggleHotkey);
            Controls.Add(materialSwitch_osuConnection);
            Controls.Add(materialLabel_submissionStatus);
            Controls.Add(materialButton_changeToggleHotkey);
            ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            Name = "MainForm";
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialSlider materialSlider_refreshRate;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton materialButton_findOsuLocation;
        private MaterialSkin.Controls.MaterialLabel materialLabel_globalToggleHotkey;
        private MaterialSkin.Controls.MaterialLabel materialLabel_osuPath;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_osuConnection;
        private MaterialSkin.Controls.MaterialLabel materialLabel_submissionStatus;
        private MaterialSkin.Controls.MaterialButton materialButton_changeToggleHotkey;
    }
}