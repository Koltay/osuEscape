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
            this.materialSlider_refreshRate = new MaterialSkin.Controls.MaterialSlider();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton_findOsuLocation = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel_globalToggleHotkey = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel_osuPath = new MaterialSkin.Controls.MaterialLabel();
            this.materialSwitch_osuConnection = new MaterialSkin.Controls.MaterialSwitch();
            this.materialLabel_submissionStatus = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton_changeToggleHotkey = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // materialSlider_refreshRate
            // 
            this.materialSlider_refreshRate.Depth = 0;
            this.materialSlider_refreshRate.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialSlider_refreshRate.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            this.materialSlider_refreshRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialSlider_refreshRate.Location = new System.Drawing.Point(346, 159);
            this.materialSlider_refreshRate.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSlider_refreshRate.Name = "materialSlider_refreshRate";
            this.materialSlider_refreshRate.RangeMax = 1000;
            this.materialSlider_refreshRate.RangeMin = 50;
            this.materialSlider_refreshRate.Size = new System.Drawing.Size(146, 40);
            this.materialSlider_refreshRate.TabIndex = 39;
            this.materialSlider_refreshRate.TabStop = false;
            this.materialSlider_refreshRate.Text = "";
            this.materialSlider_refreshRate.UseAccentColor = true;
            this.materialSlider_refreshRate.ValueMax = 1000;
            this.materialSlider_refreshRate.ValueSuffix = "ms";
            this.materialSlider_refreshRate.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.materialSlider_refreshRate_onValueChanged);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.materialLabel3.Location = new System.Drawing.Point(371, 141);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(86, 19);
            this.materialLabel3.TabIndex = 38;
            this.materialLabel3.Text = "Refresh rate";
            this.materialLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialButton_findOsuLocation
            // 
            this.materialButton_findOsuLocation.AutoSize = false;
            this.materialButton_findOsuLocation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton_findOsuLocation.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton_findOsuLocation.Depth = 0;
            this.materialButton_findOsuLocation.HighEmphasis = true;
            this.materialButton_findOsuLocation.Icon = null;
            this.materialButton_findOsuLocation.Location = new System.Drawing.Point(299, 79);
            this.materialButton_findOsuLocation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton_findOsuLocation.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton_findOsuLocation.Name = "materialButton_findOsuLocation";
            this.materialButton_findOsuLocation.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton_findOsuLocation.Size = new System.Drawing.Size(193, 50);
            this.materialButton_findOsuLocation.TabIndex = 36;
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
            this.materialLabel_globalToggleHotkey.Location = new System.Drawing.Point(19, 55);
            this.materialLabel_globalToggleHotkey.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_globalToggleHotkey.Name = "materialLabel_globalToggleHotkey";
            this.materialLabel_globalToggleHotkey.Size = new System.Drawing.Size(161, 19);
            this.materialLabel_globalToggleHotkey.TabIndex = 35;
            this.materialLabel_globalToggleHotkey.Text = "Global Toggle Hotkey: ";
            // 
            // materialLabel_osuPath
            // 
            this.materialLabel_osuPath.AutoSize = true;
            this.materialLabel_osuPath.Depth = 0;
            this.materialLabel_osuPath.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_osuPath.Location = new System.Drawing.Point(19, 117);
            this.materialLabel_osuPath.MaximumSize = new System.Drawing.Size(200, 0);
            this.materialLabel_osuPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_osuPath.Name = "materialLabel_osuPath";
            this.materialLabel_osuPath.Size = new System.Drawing.Size(72, 19);
            this.materialLabel_osuPath.TabIndex = 34;
            this.materialLabel_osuPath.Text = "osu! Path:";
            // 
            // materialSwitch_osuConnection
            // 
            this.materialSwitch_osuConnection.AutoSize = true;
            this.materialSwitch_osuConnection.Depth = 0;
            this.materialSwitch_osuConnection.Location = new System.Drawing.Point(9, 9);
            this.materialSwitch_osuConnection.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_osuConnection.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_osuConnection.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_osuConnection.Name = "materialSwitch_osuConnection";
            this.materialSwitch_osuConnection.Ripple = true;
            this.materialSwitch_osuConnection.Size = new System.Drawing.Size(215, 37);
            this.materialSwitch_osuConnection.TabIndex = 33;
            this.materialSwitch_osuConnection.TabStop = false;
            this.materialSwitch_osuConnection.Text = "Block osu! Connection";
            this.materialSwitch_osuConnection.UseVisualStyleBackColor = true;
            this.materialSwitch_osuConnection.CheckedChanged += new System.EventHandler(this.materialSwitch_osuConnection_CheckedChanged);
            // 
            // materialLabel_submissionStatus
            // 
            this.materialLabel_submissionStatus.AutoSize = true;
            this.materialLabel_submissionStatus.Depth = 0;
            this.materialLabel_submissionStatus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_submissionStatus.Location = new System.Drawing.Point(19, 180);
            this.materialLabel_submissionStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_submissionStatus.Name = "materialLabel_submissionStatus";
            this.materialLabel_submissionStatus.Size = new System.Drawing.Size(143, 19);
            this.materialLabel_submissionStatus.TabIndex = 32;
            this.materialLabel_submissionStatus.Text = "Submission Status: ";
            // 
            // materialButton_changeToggleHotkey
            // 
            this.materialButton_changeToggleHotkey.AutoSize = false;
            this.materialButton_changeToggleHotkey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton_changeToggleHotkey.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.materialButton_changeToggleHotkey.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton_changeToggleHotkey.Depth = 0;
            this.materialButton_changeToggleHotkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton_changeToggleHotkey.HighEmphasis = true;
            this.materialButton_changeToggleHotkey.Icon = null;
            this.materialButton_changeToggleHotkey.Location = new System.Drawing.Point(299, 17);
            this.materialButton_changeToggleHotkey.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton_changeToggleHotkey.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton_changeToggleHotkey.Name = "materialButton_changeToggleHotkey";
            this.materialButton_changeToggleHotkey.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton_changeToggleHotkey.Size = new System.Drawing.Size(193, 50);
            this.materialButton_changeToggleHotkey.TabIndex = 37;
            this.materialButton_changeToggleHotkey.TabStop = false;
            this.materialButton_changeToggleHotkey.Text = "Change Toggle Hotkey";
            this.materialButton_changeToggleHotkey.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.materialButton_changeToggleHotkey.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton_changeToggleHotkey.UseAccentColor = false;
            this.materialButton_changeToggleHotkey.UseVisualStyleBackColor = false;
            this.materialButton_changeToggleHotkey.Click += new System.EventHandler(this.materialButton_changeToggleHotkey_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 316);
            this.Controls.Add(this.materialSlider_refreshRate);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialButton_findOsuLocation);
            this.Controls.Add(this.materialLabel_globalToggleHotkey);
            this.Controls.Add(this.materialLabel_osuPath);
            this.Controls.Add(this.materialSwitch_osuConnection);
            this.Controls.Add(this.materialLabel_submissionStatus);
            this.Controls.Add(this.materialButton_changeToggleHotkey);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

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