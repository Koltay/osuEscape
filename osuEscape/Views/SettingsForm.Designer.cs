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
            this.materialCheckbox_isCheckingFullCombo = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialTextBox_apiInput = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialButton_checkApi = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel_apiNeeded = new MaterialSkin.Controls.MaterialLabel();
            this.materialSwitch_isAutoDisconnect = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitch_isSubmitIfFC = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitch_isTopMost = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitch_isToggleSound = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitch_isSystemTray = new MaterialSkin.Controls.MaterialSwitch();
            this.materialSwitch_isStartup = new MaterialSkin.Controls.MaterialSwitch();
            this.materialLabel_focus = new MaterialSkin.Controls.MaterialLabel();
            this.materialSlider_Accuracy = new MaterialSkin.Controls.MaterialSlider();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.materialSwitch_isSnipeMode = new MaterialSkin.Controls.MaterialSwitch();
            this.materialTextBox_userId = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialButton_isSnipeMode = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // materialCheckbox_isCheckingFullCombo
            // 
            this.materialCheckbox_isCheckingFullCombo.AutoSize = true;
            this.materialCheckbox_isCheckingFullCombo.Depth = 0;
            this.materialCheckbox_isCheckingFullCombo.Location = new System.Drawing.Point(366, 92);
            this.materialCheckbox_isCheckingFullCombo.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox_isCheckingFullCombo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox_isCheckingFullCombo.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox_isCheckingFullCombo.Name = "materialCheckbox_isCheckingFullCombo";
            this.materialCheckbox_isCheckingFullCombo.ReadOnly = false;
            this.materialCheckbox_isCheckingFullCombo.Ripple = true;
            this.materialCheckbox_isCheckingFullCombo.Size = new System.Drawing.Size(116, 37);
            this.materialCheckbox_isCheckingFullCombo.TabIndex = 47;
            this.materialCheckbox_isCheckingFullCombo.TabStop = false;
            this.materialCheckbox_isCheckingFullCombo.Text = "Full Combo";
            this.materialCheckbox_isCheckingFullCombo.UseVisualStyleBackColor = true;
            this.materialCheckbox_isCheckingFullCombo.CheckedChanged += new System.EventHandler(this.materialSwitch_grouped_CheckedChanged);
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
            // materialSwitch_isAutoDisconnect
            // 
            this.materialSwitch_isAutoDisconnect.AutoSize = true;
            this.materialSwitch_isAutoDisconnect.Depth = 0;
            this.materialSwitch_isAutoDisconnect.Enabled = false;
            this.materialSwitch_isAutoDisconnect.Location = new System.Drawing.Point(1, 130);
            this.materialSwitch_isAutoDisconnect.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_isAutoDisconnect.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_isAutoDisconnect.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_isAutoDisconnect.Name = "materialSwitch_isAutoDisconnect";
            this.materialSwitch_isAutoDisconnect.Ripple = true;
            this.materialSwitch_isAutoDisconnect.Size = new System.Drawing.Size(296, 37);
            this.materialSwitch_isAutoDisconnect.TabIndex = 40;
            this.materialSwitch_isAutoDisconnect.TabStop = false;
            this.materialSwitch_isAutoDisconnect.Text = "Auto Disconnection (API required)";
            this.materialSwitch_isAutoDisconnect.UseVisualStyleBackColor = true;
            this.materialSwitch_isAutoDisconnect.CheckedChanged += new System.EventHandler(this.materialSwitch_grouped_CheckedChanged);
            // 
            // materialSwitch_isSubmitIfFC
            // 
            this.materialSwitch_isSubmitIfFC.AutoSize = true;
            this.materialSwitch_isSubmitIfFC.Depth = 0;
            this.materialSwitch_isSubmitIfFC.Location = new System.Drawing.Point(1, 90);
            this.materialSwitch_isSubmitIfFC.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_isSubmitIfFC.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_isSubmitIfFC.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_isSubmitIfFC.Name = "materialSwitch_isSubmitIfFC";
            this.materialSwitch_isSubmitIfFC.Ripple = true;
            this.materialSwitch_isSubmitIfFC.Size = new System.Drawing.Size(175, 37);
            this.materialSwitch_isSubmitIfFC.TabIndex = 39;
            this.materialSwitch_isSubmitIfFC.TabStop = false;
            this.materialSwitch_isSubmitIfFC.Text = "Auto Connection";
            this.materialSwitch_isSubmitIfFC.UseVisualStyleBackColor = true;
            this.materialSwitch_isSubmitIfFC.CheckedChanged += new System.EventHandler(this.materialSwitch_grouped_CheckedChanged);
            // 
            // materialSwitch_isTopMost
            // 
            this.materialSwitch_isTopMost.AutoSize = true;
            this.materialSwitch_isTopMost.Depth = 0;
            this.materialSwitch_isTopMost.Location = new System.Drawing.Point(1, 210);
            this.materialSwitch_isTopMost.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_isTopMost.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_isTopMost.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_isTopMost.Name = "materialSwitch_isTopMost";
            this.materialSwitch_isTopMost.Ripple = true;
            this.materialSwitch_isTopMost.Size = new System.Drawing.Size(159, 37);
            this.materialSwitch_isTopMost.TabIndex = 38;
            this.materialSwitch_isTopMost.TabStop = false;
            this.materialSwitch_isTopMost.Text = "Always at Top";
            this.materialSwitch_isTopMost.UseVisualStyleBackColor = true;
            this.materialSwitch_isTopMost.CheckedChanged += new System.EventHandler(this.materialSwitch_grouped_CheckedChanged);
            // 
            // materialSwitch_isToggleSound
            // 
            this.materialSwitch_isToggleSound.AutoSize = true;
            this.materialSwitch_isToggleSound.Depth = 0;
            this.materialSwitch_isToggleSound.Location = new System.Drawing.Point(1, 170);
            this.materialSwitch_isToggleSound.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_isToggleSound.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_isToggleSound.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_isToggleSound.Name = "materialSwitch_isToggleSound";
            this.materialSwitch_isToggleSound.Ripple = true;
            this.materialSwitch_isToggleSound.Size = new System.Drawing.Size(191, 37);
            this.materialSwitch_isToggleSound.TabIndex = 37;
            this.materialSwitch_isToggleSound.TabStop = false;
            this.materialSwitch_isToggleSound.Text = "Toggle with Sound";
            this.materialSwitch_isToggleSound.UseVisualStyleBackColor = true;
            this.materialSwitch_isToggleSound.CheckedChanged += new System.EventHandler(this.materialSwitch_grouped_CheckedChanged);
            // 
            // materialSwitch_isSystemTray
            // 
            this.materialSwitch_isSystemTray.AutoSize = true;
            this.materialSwitch_isSystemTray.Depth = 0;
            this.materialSwitch_isSystemTray.Location = new System.Drawing.Point(1, 290);
            this.materialSwitch_isSystemTray.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_isSystemTray.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_isSystemTray.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_isSystemTray.Name = "materialSwitch_isSystemTray";
            this.materialSwitch_isSystemTray.Ripple = true;
            this.materialSwitch_isSystemTray.Size = new System.Drawing.Size(234, 37);
            this.materialSwitch_isSystemTray.TabIndex = 35;
            this.materialSwitch_isSystemTray.TabStop = false;
            this.materialSwitch_isSystemTray.Text = "Minimize to System Tray";
            this.materialSwitch_isSystemTray.UseVisualStyleBackColor = true;
            this.materialSwitch_isSystemTray.CheckedChanged += new System.EventHandler(this.materialSwitch_grouped_CheckedChanged);
            // 
            // materialSwitch_isStartup
            // 
            this.materialSwitch_isStartup.AutoSize = true;
            this.materialSwitch_isStartup.Depth = 0;
            this.materialSwitch_isStartup.Location = new System.Drawing.Point(1, 250);
            this.materialSwitch_isStartup.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_isStartup.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_isStartup.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_isStartup.Name = "materialSwitch_isStartup";
            this.materialSwitch_isStartup.Ripple = true;
            this.materialSwitch_isStartup.Size = new System.Drawing.Size(160, 37);
            this.materialSwitch_isStartup.TabIndex = 36;
            this.materialSwitch_isStartup.TabStop = false;
            this.materialSwitch_isStartup.Text = "Run at Startup";
            this.materialSwitch_isStartup.UseVisualStyleBackColor = true;
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
            // materialSwitch_isSnipeMode
            // 
            this.materialSwitch_isSnipeMode.AutoSize = true;
            this.materialSwitch_isSnipeMode.Depth = 0;
            this.materialSwitch_isSnipeMode.Location = new System.Drawing.Point(1, 327);
            this.materialSwitch_isSnipeMode.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch_isSnipeMode.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch_isSnipeMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch_isSnipeMode.Name = "materialSwitch_isSnipeMode";
            this.materialSwitch_isSnipeMode.Ripple = true;
            this.materialSwitch_isSnipeMode.Size = new System.Drawing.Size(256, 37);
            this.materialSwitch_isSnipeMode.TabIndex = 48;
            this.materialSwitch_isSnipeMode.TabStop = false;
            this.materialSwitch_isSnipeMode.Text = "Sniping Mode (API required)";
            this.materialSwitch_isSnipeMode.UseVisualStyleBackColor = true;
            this.materialSwitch_isSnipeMode.CheckedChanged += new System.EventHandler(this.materialSwitch_grouped_CheckedChanged);
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
            // materialButton_isSnipeMode
            // 
            this.materialButton_isSnipeMode.AutoSize = false;
            this.materialButton_isSnipeMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton_isSnipeMode.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton_isSnipeMode.Depth = 0;
            this.materialButton_isSnipeMode.Enabled = false;
            this.materialButton_isSnipeMode.HighEmphasis = true;
            this.materialButton_isSnipeMode.Icon = null;
            this.materialButton_isSnipeMode.Location = new System.Drawing.Point(426, 329);
            this.materialButton_isSnipeMode.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton_isSnipeMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton_isSnipeMode.Name = "materialButton_isSnipeMode";
            this.materialButton_isSnipeMode.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton_isSnipeMode.Size = new System.Drawing.Size(56, 34);
            this.materialButton_isSnipeMode.TabIndex = 50;
            this.materialButton_isSnipeMode.TabStop = false;
            this.materialButton_isSnipeMode.Text = "Check";
            this.materialButton_isSnipeMode.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton_isSnipeMode.UseAccentColor = true;
            this.materialButton_isSnipeMode.UseVisualStyleBackColor = true;
            this.materialButton_isSnipeMode.Click += new System.EventHandler(this.materialButton_isSnipeMode_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(499, 381);
            this.Controls.Add(this.materialButton_isSnipeMode);
            this.Controls.Add(this.materialTextBox_userId);
            this.Controls.Add(this.materialSwitch_isSnipeMode);
            this.Controls.Add(this.materialCheckbox_isCheckingFullCombo);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialTextBox_apiInput);
            this.Controls.Add(this.materialButton_checkApi);
            this.Controls.Add(this.materialLabel_apiNeeded);
            this.Controls.Add(this.materialSwitch_isAutoDisconnect);
            this.Controls.Add(this.materialSwitch_isSubmitIfFC);
            this.Controls.Add(this.materialSwitch_isTopMost);
            this.Controls.Add(this.materialSwitch_isToggleSound);
            this.Controls.Add(this.materialSwitch_isSystemTray);
            this.Controls.Add(this.materialSwitch_isStartup);
            this.Controls.Add(this.materialLabel_focus);
            this.Controls.Add(this.materialSlider_Accuracy);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_isCheckingFullCombo;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox_apiInput;
        private MaterialSkin.Controls.MaterialButton materialButton_checkApi;
        private MaterialSkin.Controls.MaterialLabel materialLabel_apiNeeded;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_isAutoDisconnect;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_isSubmitIfFC;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_isTopMost;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_isToggleSound;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_isSystemTray;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_isStartup;
        private MaterialSkin.Controls.MaterialLabel materialLabel_focus;
        private MaterialSkin.Controls.MaterialSlider materialSlider_Accuracy;
        private System.Windows.Forms.ToolTip toolTips;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_isSnipeMode;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox_userId;
        private MaterialSkin.Controls.MaterialButton materialButton_isSnipeMode;
    }
}