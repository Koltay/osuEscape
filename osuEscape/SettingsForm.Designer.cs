namespace osuEscape
{
    partial class SettingsForm
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
            this.materialCheckbox_isFullCombo = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialTextBox_apiInput = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialButton_checkApi = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel_apiNeeded = new MaterialSkin.Controls.MaterialLabel();
            this.materialSwitch_autoDisconnect = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitch_submitIfFC = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitch_topMost = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitch_toggleWithSound = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitch_minimizeToSystemTray = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitch_runAtStartup = new MaterialSkin.Controls.MaterialSwitch();
            this.materialLabel_focus = new MaterialSkin.Controls.MaterialLabel();
            this.materialSlider_Accuracy = new MaterialSkin.Controls.MaterialSlider();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.materialSwitch_sniping = new MaterialSkin.Controls.MaterialSwitch();
            this.materialTextBox_userId = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialButton_sniping = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // materialCheckbox_isFullCombo
            // 
            this.materialCheckbox_isFullCombo.AutoSize = true;
            this.materialCheckbox_isFullCombo.Depth = 0;
            this.materialCheckbox_isFullCombo.Location = new System.Drawing.Point(366, 92);
            this.materialCheckbox_isFullCombo.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox_isFullCombo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox_isFullCombo.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox_isFullCombo.Name = "materialCheckbox_isFullCombo";
            this.materialCheckbox_isFullCombo.ReadOnly = false;
            this.materialCheckbox_isFullCombo.Ripple = true;
            this.materialCheckbox_isFullCombo.Size = new System.Drawing.Size(116, 37);
            this.materialCheckbox_isFullCombo.TabIndex = 47;
            this.materialCheckbox_isFullCombo.TabStop = false;
            this.materialCheckbox_isFullCombo.Text = "Full Combo";
            this.materialCheckbox_isFullCombo.UseVisualStyleBackColor = true;
            this.materialCheckbox_isFullCombo.CheckedChanged += new System.EventHandler(this.materialCheckbox_isFullCombo_CheckedChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.materialLabel2.Location = new System.Drawing.Point(231, 76);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(66, 19);
            this.materialLabel2.TabIndex = 45;
            this.materialLabel2.Text = "Accuracy";
            this.materialLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.materialTextBox_apiInput.Location = new System.Drawing.Point(11, 28);
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
            this.materialTextBox_apiInput.TabIndex = 42;
            this.materialTextBox_apiInput.TabStop = false;
            this.materialTextBox_apiInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox_apiInput.TrailingIcon = null;
            this.materialTextBox_apiInput.UseSystemPasswordChar = true;
            this.materialTextBox_apiInput.UseTallSize = false;
            // 
            // materialButton_checkApi
            // 
            this.materialButton_checkApi.AutoSize = false;
            this.materialButton_checkApi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton_checkApi.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton_checkApi.Depth = 0;
            this.materialButton_checkApi.HighEmphasis = true;
            this.materialButton_checkApi.Icon = null;
            this.materialButton_checkApi.Location = new System.Drawing.Point(426, 30);
            this.materialButton_checkApi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton_checkApi.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton_checkApi.Name = "materialButton_checkApi";
            this.materialButton_checkApi.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton_checkApi.Size = new System.Drawing.Size(56, 34);
            this.materialButton_checkApi.TabIndex = 41;
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
            this.materialLabel_apiNeeded.Location = new System.Drawing.Point(12, 2);
            this.materialLabel_apiNeeded.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_apiNeeded.Name = "materialLabel_apiNeeded";
            this.materialLabel_apiNeeded.Size = new System.Drawing.Size(124, 17);
            this.materialLabel_apiNeeded.TabIndex = 34;
            this.materialLabel_apiNeeded.Text = "API required option";
            // 
            // materialSwitch_autoDisconnect
            // 
            this.materialSwitch_autoDisconnect.AutoSize = true;
            this.materialSwitch_autoDisconnect.Depth = 0;
            this.materialSwitch_autoDisconnect.Enabled = false;
            this.materialSwitch_autoDisconnect.Location = new System.Drawing.Point(1, 130);
            this.materialSwitch_autoDisconnect.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_autoDisconnect.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_autoDisconnect.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_autoDisconnect.Name = "materialSwitch_autoDisconnect";
            this.materialSwitch_autoDisconnect.Ripple = true;
            this.materialSwitch_autoDisconnect.Size = new System.Drawing.Size(296, 37);
            this.materialSwitch_autoDisconnect.TabIndex = 40;
            this.materialSwitch_autoDisconnect.TabStop = false;
            this.materialSwitch_autoDisconnect.Text = "Auto Disconnection (API required)";
            this.materialSwitch_autoDisconnect.UseVisualStyleBackColor = true;
            this.materialSwitch_autoDisconnect.CheckedChanged += new System.EventHandler(this.materialSwitch_autoDisconnect_CheckedChanged);
            // 
            // materialSwitch_submitIfFC
            // 
            this.materialSwitch_submitIfFC.AutoSize = true;
            this.materialSwitch_submitIfFC.Depth = 0;
            this.materialSwitch_submitIfFC.Location = new System.Drawing.Point(1, 90);
            this.materialSwitch_submitIfFC.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_submitIfFC.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_submitIfFC.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_submitIfFC.Name = "materialSwitch_submitIfFC";
            this.materialSwitch_submitIfFC.Ripple = true;
            this.materialSwitch_submitIfFC.Size = new System.Drawing.Size(175, 37);
            this.materialSwitch_submitIfFC.TabIndex = 39;
            this.materialSwitch_submitIfFC.TabStop = false;
            this.materialSwitch_submitIfFC.Text = "Auto Connection";
            this.materialSwitch_submitIfFC.UseVisualStyleBackColor = true;
            this.materialSwitch_submitIfFC.CheckedChanged += new System.EventHandler(this.materialSwitch_submitIfFC_CheckedChanged);
            // 
            // materialSwitch_topMost
            // 
            this.materialSwitch_topMost.AutoSize = true;
            this.materialSwitch_topMost.Depth = 0;
            this.materialSwitch_topMost.Location = new System.Drawing.Point(1, 210);
            this.materialSwitch_topMost.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_topMost.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_topMost.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_topMost.Name = "materialSwitch_topMost";
            this.materialSwitch_topMost.Ripple = true;
            this.materialSwitch_topMost.Size = new System.Drawing.Size(159, 37);
            this.materialSwitch_topMost.TabIndex = 38;
            this.materialSwitch_topMost.TabStop = false;
            this.materialSwitch_topMost.Text = "Always at Top";
            this.materialSwitch_topMost.UseVisualStyleBackColor = true;
            this.materialSwitch_topMost.CheckedChanged += new System.EventHandler(this.materialSwitch_topMost_CheckedChanged);
            // 
            // materialSwitch_toggleWithSound
            // 
            this.materialSwitch_toggleWithSound.AutoSize = true;
            this.materialSwitch_toggleWithSound.Depth = 0;
            this.materialSwitch_toggleWithSound.Location = new System.Drawing.Point(1, 170);
            this.materialSwitch_toggleWithSound.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_toggleWithSound.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_toggleWithSound.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_toggleWithSound.Name = "materialSwitch_toggleWithSound";
            this.materialSwitch_toggleWithSound.Ripple = true;
            this.materialSwitch_toggleWithSound.Size = new System.Drawing.Size(191, 37);
            this.materialSwitch_toggleWithSound.TabIndex = 37;
            this.materialSwitch_toggleWithSound.TabStop = false;
            this.materialSwitch_toggleWithSound.Text = "Toggle with Sound";
            this.materialSwitch_toggleWithSound.UseVisualStyleBackColor = true;
            this.materialSwitch_toggleWithSound.CheckedChanged += new System.EventHandler(this.materialSwitch_toggleWithSound_CheckedChanged);
            // 
            // materialSwitch_minimizeToSystemTray
            // 
            this.materialSwitch_minimizeToSystemTray.AutoSize = true;
            this.materialSwitch_minimizeToSystemTray.Depth = 0;
            this.materialSwitch_minimizeToSystemTray.Location = new System.Drawing.Point(1, 290);
            this.materialSwitch_minimizeToSystemTray.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_minimizeToSystemTray.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_minimizeToSystemTray.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_minimizeToSystemTray.Name = "materialSwitch_minimizeToSystemTray";
            this.materialSwitch_minimizeToSystemTray.Ripple = true;
            this.materialSwitch_minimizeToSystemTray.Size = new System.Drawing.Size(234, 37);
            this.materialSwitch_minimizeToSystemTray.TabIndex = 35;
            this.materialSwitch_minimizeToSystemTray.TabStop = false;
            this.materialSwitch_minimizeToSystemTray.Text = "Minimize to System Tray";
            this.materialSwitch_minimizeToSystemTray.UseVisualStyleBackColor = true;
            this.materialSwitch_minimizeToSystemTray.CheckedChanged += new System.EventHandler(this.materialSwitch_minimizeToSystemTray_CheckedChanged);
            // 
            // materialSwitch_runAtStartup
            // 
            this.materialSwitch_runAtStartup.AutoSize = true;
            this.materialSwitch_runAtStartup.Depth = 0;
            this.materialSwitch_runAtStartup.Location = new System.Drawing.Point(1, 250);
            this.materialSwitch_runAtStartup.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_runAtStartup.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_runAtStartup.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_runAtStartup.Name = "materialSwitch_runAtStartup";
            this.materialSwitch_runAtStartup.Ripple = true;
            this.materialSwitch_runAtStartup.Size = new System.Drawing.Size(160, 37);
            this.materialSwitch_runAtStartup.TabIndex = 36;
            this.materialSwitch_runAtStartup.TabStop = false;
            this.materialSwitch_runAtStartup.Text = "Run at Startup";
            this.materialSwitch_runAtStartup.UseVisualStyleBackColor = true;
            // 
            // materialLabel_focus
            // 
            this.materialLabel_focus.AutoSize = true;
            this.materialLabel_focus.Depth = 0;
            this.materialLabel_focus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel_focus.Location = new System.Drawing.Point(441, 38);
            this.materialLabel_focus.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel_focus.Name = "materialLabel_focus";
            this.materialLabel_focus.Size = new System.Drawing.Size(41, 19);
            this.materialLabel_focus.TabIndex = 43;
            this.materialLabel_focus.Text = "focus";
            // 
            // materialSlider_Accuracy
            // 
            this.materialSlider_Accuracy.Depth = 0;
            this.materialSlider_Accuracy.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialSlider_Accuracy.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            this.materialSlider_Accuracy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialSlider_Accuracy.Location = new System.Drawing.Point(201, 90);
            this.materialSlider_Accuracy.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSlider_Accuracy.Name = "materialSlider_Accuracy";
            this.materialSlider_Accuracy.Size = new System.Drawing.Size(146, 40);
            this.materialSlider_Accuracy.TabIndex = 46;
            this.materialSlider_Accuracy.TabStop = false;
            this.materialSlider_Accuracy.Text = "";
            this.materialSlider_Accuracy.UseAccentColor = true;
            this.materialSlider_Accuracy.Value = 0;
            this.materialSlider_Accuracy.ValueMax = 100;
            this.materialSlider_Accuracy.ValueSuffix = "%";
            this.materialSlider_Accuracy.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.materialSlider_Accuracy_onValueChanged);
            // 
            // materialSwitch_sniping
            // 
            this.materialSwitch_sniping.AutoSize = true;
            this.materialSwitch_sniping.Depth = 0;
            this.materialSwitch_sniping.Location = new System.Drawing.Point(1, 327);
            this.materialSwitch_sniping.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_sniping.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_sniping.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_sniping.Name = "materialSwitch_sniping";
            this.materialSwitch_sniping.Ripple = true;
            this.materialSwitch_sniping.Size = new System.Drawing.Size(256, 37);
            this.materialSwitch_sniping.TabIndex = 48;
            this.materialSwitch_sniping.TabStop = false;
            this.materialSwitch_sniping.Text = "Sniping Mode (API required)";
            this.materialSwitch_sniping.UseVisualStyleBackColor = true;
            this.materialSwitch_sniping.CheckedChanged += new System.EventHandler(this.materialSwitch_sniping_CheckedChanged);
            // 
            // materialTextBox_userId
            // 
            this.materialTextBox_userId.AnimateReadOnly = false;
            this.materialTextBox_userId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox_userId.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox_userId.Depth = 0;
            this.materialTextBox_userId.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox_userId.HideSelection = true;
            this.materialTextBox_userId.LeadingIcon = null;
            this.materialTextBox_userId.Location = new System.Drawing.Point(262, 327);
            this.materialTextBox_userId.MaxLength = 255;
            this.materialTextBox_userId.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox_userId.Name = "materialTextBox_userId";
            this.materialTextBox_userId.PasswordChar = '\0';
            this.materialTextBox_userId.PrefixSuffixText = null;
            this.materialTextBox_userId.ReadOnly = false;
            this.materialTextBox_userId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox_userId.SelectedText = "";
            this.materialTextBox_userId.SelectionLength = 0;
            this.materialTextBox_userId.SelectionStart = 0;
            this.materialTextBox_userId.ShortcutsEnabled = true;
            this.materialTextBox_userId.Size = new System.Drawing.Size(150, 36);
            this.materialTextBox_userId.TabIndex = 49;
            this.materialTextBox_userId.TabStop = false;
            this.materialTextBox_userId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox_userId.TrailingIcon = null;
            this.materialTextBox_userId.UseSystemPasswordChar = false;
            this.materialTextBox_userId.UseTallSize = false;
            // 
            // materialButton_sniping
            // 
            this.materialButton_sniping.AutoSize = false;
            this.materialButton_sniping.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton_sniping.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton_sniping.Depth = 0;
            this.materialButton_sniping.Enabled = false;
            this.materialButton_sniping.HighEmphasis = true;
            this.materialButton_sniping.Icon = null;
            this.materialButton_sniping.Location = new System.Drawing.Point(426, 329);
            this.materialButton_sniping.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton_sniping.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton_sniping.Name = "materialButton_sniping";
            this.materialButton_sniping.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton_sniping.Size = new System.Drawing.Size(56, 34);
            this.materialButton_sniping.TabIndex = 50;
            this.materialButton_sniping.TabStop = false;
            this.materialButton_sniping.Text = "Check";
            this.materialButton_sniping.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton_sniping.UseAccentColor = true;
            this.materialButton_sniping.UseVisualStyleBackColor = true;
            this.materialButton_sniping.Click += new System.EventHandler(this.materialButton_sniping_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(499, 381);
            this.Controls.Add(this.materialButton_sniping);
            this.Controls.Add(this.materialTextBox_userId);
            this.Controls.Add(this.materialSwitch_sniping);
            this.Controls.Add(this.materialCheckbox_isFullCombo);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialTextBox_apiInput);
            this.Controls.Add(this.materialButton_checkApi);
            this.Controls.Add(this.materialLabel_apiNeeded);
            this.Controls.Add(this.materialSwitch_autoDisconnect);
            this.Controls.Add(this.materialSwitch_submitIfFC);
            this.Controls.Add(this.materialSwitch_topMost);
            this.Controls.Add(this.materialSwitch_toggleWithSound);
            this.Controls.Add(this.materialSwitch_minimizeToSystemTray);
            this.Controls.Add(this.materialSwitch_runAtStartup);
            this.Controls.Add(this.materialLabel_focus);
            this.Controls.Add(this.materialSlider_Accuracy);
            this.Name = "SettingsForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_isFullCombo;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox_apiInput;
        private MaterialSkin.Controls.MaterialButton materialButton_checkApi;
        private MaterialSkin.Controls.MaterialLabel materialLabel_apiNeeded;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_autoDisconnect;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_submitIfFC;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_topMost;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_toggleWithSound;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_minimizeToSystemTray;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_runAtStartup;
        private MaterialSkin.Controls.MaterialLabel materialLabel_focus;
        private MaterialSkin.Controls.MaterialSlider materialSlider_Accuracy;
        private System.Windows.Forms.ToolTip toolTips;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_sniping;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox_userId;
        private MaterialSkin.Controls.MaterialButton materialButton_sniping;
    }
}