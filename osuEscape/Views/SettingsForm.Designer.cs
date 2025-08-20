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
            components = new System.ComponentModel.Container();
            materialCheckbox_isCheckingFullCombo = new MaterialSkin.Controls.MaterialCheckbox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialTextBox_apiInput = new MaterialSkin.Controls.MaterialTextBox2();
            materialButton_checkApi = new MaterialSkin.Controls.MaterialButton();
            materialLabel_apiNeeded = new MaterialSkin.Controls.MaterialLabel();
            materialSwitch_isAutoDisconnect = new MaterialSkin.Controls.MaterialSwitch();
            materialSwitch_isSubmitIfFC = new MaterialSkin.Controls.MaterialSwitch();
            materialSwitch_isTopMost = new MaterialSkin.Controls.MaterialSwitch();
            materialSwitch_isToggleSound = new MaterialSkin.Controls.MaterialSwitch();
            materialSwitch_isSystemTray = new MaterialSkin.Controls.MaterialSwitch();
            materialSwitch_isStartup = new MaterialSkin.Controls.MaterialSwitch();
            materialLabel_focus = new MaterialSkin.Controls.MaterialLabel();
            materialSlider_Accuracy = new MaterialSkin.Controls.MaterialSlider();
            toolTips = new System.Windows.Forms.ToolTip(components);
            materialSwitch_isSnipeMode = new MaterialSkin.Controls.MaterialSwitch();
            materialTextBox_userId = new MaterialSkin.Controls.MaterialTextBox2();
            materialButton_isSnipeMode = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // materialCheckbox_isCheckingFullCombo
            // 
            materialCheckbox_isCheckingFullCombo.AutoSize = true;
            materialCheckbox_isCheckingFullCombo.Depth = 0;
            materialCheckbox_isCheckingFullCombo.Location = new System.Drawing.Point(366, 92);
            materialCheckbox_isCheckingFullCombo.Margin = new System.Windows.Forms.Padding(0);
            materialCheckbox_isCheckingFullCombo.MouseLocation = new System.Drawing.Point(-1, -1);
            materialCheckbox_isCheckingFullCombo.MouseState = MaterialSkin.MouseState.HOVER;
            materialCheckbox_isCheckingFullCombo.Name = "materialCheckbox_isCheckingFullCombo";
            materialCheckbox_isCheckingFullCombo.ReadOnly = false;
            materialCheckbox_isCheckingFullCombo.Ripple = true;
            materialCheckbox_isCheckingFullCombo.Size = new System.Drawing.Size(116, 37);
            materialCheckbox_isCheckingFullCombo.TabIndex = 47;
            materialCheckbox_isCheckingFullCombo.TabStop = false;
            materialCheckbox_isCheckingFullCombo.Text = "Full Combo";
            materialCheckbox_isCheckingFullCombo.UseVisualStyleBackColor = true;
            materialCheckbox_isCheckingFullCombo.CheckedChanged += materialSwitch_grouped_CheckedChanged;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            materialLabel2.Location = new System.Drawing.Point(201, 78);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new System.Drawing.Size(66, 19);
            materialLabel2.TabIndex = 45;
            materialLabel2.Text = "Accuracy";
            materialLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialTextBox_apiInput
            // 
            materialTextBox_apiInput.AnimateReadOnly = false;
            materialTextBox_apiInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            materialTextBox_apiInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            materialTextBox_apiInput.Depth = 0;
            materialTextBox_apiInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            materialTextBox_apiInput.HideSelection = true;
            materialTextBox_apiInput.LeadingIcon = null;
            materialTextBox_apiInput.Location = new System.Drawing.Point(11, 28);
            materialTextBox_apiInput.MaxLength = 255;
            materialTextBox_apiInput.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox_apiInput.Name = "materialTextBox_apiInput";
            materialTextBox_apiInput.PasswordChar = '●';
            materialTextBox_apiInput.PrefixSuffixText = null;
            materialTextBox_apiInput.ReadOnly = false;
            materialTextBox_apiInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            materialTextBox_apiInput.SelectedText = "";
            materialTextBox_apiInput.SelectionLength = 0;
            materialTextBox_apiInput.SelectionStart = 0;
            materialTextBox_apiInput.ShortcutsEnabled = true;
            materialTextBox_apiInput.Size = new System.Drawing.Size(399, 36);
            materialTextBox_apiInput.TabIndex = 42;
            materialTextBox_apiInput.TabStop = false;
            materialTextBox_apiInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            materialTextBox_apiInput.TrailingIcon = null;
            materialTextBox_apiInput.UseSystemPasswordChar = true;
            materialTextBox_apiInput.UseTallSize = false;
            // 
            // materialButton_checkApi
            // 
            materialButton_checkApi.AutoSize = false;
            materialButton_checkApi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            materialButton_checkApi.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_checkApi.Depth = 0;
            materialButton_checkApi.HighEmphasis = true;
            materialButton_checkApi.Icon = null;
            materialButton_checkApi.Location = new System.Drawing.Point(426, 30);
            materialButton_checkApi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            materialButton_checkApi.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_checkApi.Name = "materialButton_checkApi";
            materialButton_checkApi.NoAccentTextColor = System.Drawing.Color.Empty;
            materialButton_checkApi.Size = new System.Drawing.Size(56, 34);
            materialButton_checkApi.TabIndex = 41;
            materialButton_checkApi.TabStop = false;
            materialButton_checkApi.Text = "Verify";
            materialButton_checkApi.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton_checkApi.UseAccentColor = true;
            materialButton_checkApi.UseVisualStyleBackColor = true;
            materialButton_checkApi.Click += materialButton_checkApi_Click;
            // 
            // materialLabel_apiNeeded
            // 
            materialLabel_apiNeeded.AutoSize = true;
            materialLabel_apiNeeded.Depth = 0;
            materialLabel_apiNeeded.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            materialLabel_apiNeeded.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            materialLabel_apiNeeded.Location = new System.Drawing.Point(12, 2);
            materialLabel_apiNeeded.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel_apiNeeded.Name = "materialLabel_apiNeeded";
            materialLabel_apiNeeded.Size = new System.Drawing.Size(124, 17);
            materialLabel_apiNeeded.TabIndex = 34;
            materialLabel_apiNeeded.Text = "API required option";
            // 
            // materialSwitch_isAutoDisconnect
            // 
            materialSwitch_isAutoDisconnect.AutoSize = true;
            materialSwitch_isAutoDisconnect.Depth = 0;
            materialSwitch_isAutoDisconnect.Enabled = false;
            materialSwitch_isAutoDisconnect.Location = new System.Drawing.Point(1, 130);
            materialSwitch_isAutoDisconnect.Margin = new System.Windows.Forms.Padding(0);
            materialSwitch_isAutoDisconnect.MouseLocation = new System.Drawing.Point(-1, -1);
            materialSwitch_isAutoDisconnect.MouseState = MaterialSkin.MouseState.HOVER;
            materialSwitch_isAutoDisconnect.Name = "materialSwitch_isAutoDisconnect";
            materialSwitch_isAutoDisconnect.Ripple = true;
            materialSwitch_isAutoDisconnect.Size = new System.Drawing.Size(296, 37);
            materialSwitch_isAutoDisconnect.TabIndex = 40;
            materialSwitch_isAutoDisconnect.TabStop = false;
            materialSwitch_isAutoDisconnect.Text = "Auto Disconnection (API required)";
            materialSwitch_isAutoDisconnect.UseVisualStyleBackColor = true;
            materialSwitch_isAutoDisconnect.CheckedChanged += materialSwitch_grouped_CheckedChanged;
            // 
            // materialSwitch_isSubmitIfFC
            // 
            materialSwitch_isSubmitIfFC.AutoSize = true;
            materialSwitch_isSubmitIfFC.Depth = 0;
            materialSwitch_isSubmitIfFC.Location = new System.Drawing.Point(1, 90);
            materialSwitch_isSubmitIfFC.Margin = new System.Windows.Forms.Padding(0);
            materialSwitch_isSubmitIfFC.MouseLocation = new System.Drawing.Point(-1, -1);
            materialSwitch_isSubmitIfFC.MouseState = MaterialSkin.MouseState.HOVER;
            materialSwitch_isSubmitIfFC.Name = "materialSwitch_isSubmitIfFC";
            materialSwitch_isSubmitIfFC.Ripple = true;
            materialSwitch_isSubmitIfFC.Size = new System.Drawing.Size(175, 37);
            materialSwitch_isSubmitIfFC.TabIndex = 39;
            materialSwitch_isSubmitIfFC.TabStop = false;
            materialSwitch_isSubmitIfFC.Text = "Auto Connection";
            materialSwitch_isSubmitIfFC.UseVisualStyleBackColor = true;
            materialSwitch_isSubmitIfFC.CheckedChanged += materialSwitch_grouped_CheckedChanged;
            // 
            // materialSwitch_isTopMost
            // 
            materialSwitch_isTopMost.AutoSize = true;
            materialSwitch_isTopMost.Depth = 0;
            materialSwitch_isTopMost.Location = new System.Drawing.Point(1, 210);
            materialSwitch_isTopMost.Margin = new System.Windows.Forms.Padding(0);
            materialSwitch_isTopMost.MouseLocation = new System.Drawing.Point(-1, -1);
            materialSwitch_isTopMost.MouseState = MaterialSkin.MouseState.HOVER;
            materialSwitch_isTopMost.Name = "materialSwitch_isTopMost";
            materialSwitch_isTopMost.Ripple = true;
            materialSwitch_isTopMost.Size = new System.Drawing.Size(159, 37);
            materialSwitch_isTopMost.TabIndex = 38;
            materialSwitch_isTopMost.TabStop = false;
            materialSwitch_isTopMost.Text = "Always at Top";
            materialSwitch_isTopMost.UseVisualStyleBackColor = true;
            materialSwitch_isTopMost.CheckedChanged += materialSwitch_grouped_CheckedChanged;
            // 
            // materialSwitch_isToggleSound
            // 
            materialSwitch_isToggleSound.AutoSize = true;
            materialSwitch_isToggleSound.Depth = 0;
            materialSwitch_isToggleSound.Location = new System.Drawing.Point(1, 170);
            materialSwitch_isToggleSound.Margin = new System.Windows.Forms.Padding(0);
            materialSwitch_isToggleSound.MouseLocation = new System.Drawing.Point(-1, -1);
            materialSwitch_isToggleSound.MouseState = MaterialSkin.MouseState.HOVER;
            materialSwitch_isToggleSound.Name = "materialSwitch_isToggleSound";
            materialSwitch_isToggleSound.Ripple = true;
            materialSwitch_isToggleSound.Size = new System.Drawing.Size(191, 37);
            materialSwitch_isToggleSound.TabIndex = 37;
            materialSwitch_isToggleSound.TabStop = false;
            materialSwitch_isToggleSound.Text = "Toggle with Sound";
            materialSwitch_isToggleSound.UseVisualStyleBackColor = true;
            materialSwitch_isToggleSound.CheckedChanged += materialSwitch_grouped_CheckedChanged;
            // 
            // materialSwitch_isSystemTray
            // 
            materialSwitch_isSystemTray.AutoSize = true;
            materialSwitch_isSystemTray.Depth = 0;
            materialSwitch_isSystemTray.Location = new System.Drawing.Point(1, 290);
            materialSwitch_isSystemTray.Margin = new System.Windows.Forms.Padding(0);
            materialSwitch_isSystemTray.MouseLocation = new System.Drawing.Point(-1, -1);
            materialSwitch_isSystemTray.MouseState = MaterialSkin.MouseState.HOVER;
            materialSwitch_isSystemTray.Name = "materialSwitch_isSystemTray";
            materialSwitch_isSystemTray.Ripple = true;
            materialSwitch_isSystemTray.Size = new System.Drawing.Size(234, 37);
            materialSwitch_isSystemTray.TabIndex = 35;
            materialSwitch_isSystemTray.TabStop = false;
            materialSwitch_isSystemTray.Text = "Minimize to System Tray";
            materialSwitch_isSystemTray.UseVisualStyleBackColor = true;
            materialSwitch_isSystemTray.CheckedChanged += materialSwitch_grouped_CheckedChanged;
            // 
            // materialSwitch_isStartup
            // 
            materialSwitch_isStartup.AutoSize = true;
            materialSwitch_isStartup.Depth = 0;
            materialSwitch_isStartup.Location = new System.Drawing.Point(1, 250);
            materialSwitch_isStartup.Margin = new System.Windows.Forms.Padding(0);
            materialSwitch_isStartup.MouseLocation = new System.Drawing.Point(-1, -1);
            materialSwitch_isStartup.MouseState = MaterialSkin.MouseState.HOVER;
            materialSwitch_isStartup.Name = "materialSwitch_isStartup";
            materialSwitch_isStartup.Ripple = true;
            materialSwitch_isStartup.Size = new System.Drawing.Size(160, 37);
            materialSwitch_isStartup.TabIndex = 36;
            materialSwitch_isStartup.TabStop = false;
            materialSwitch_isStartup.Text = "Run at Startup";
            materialSwitch_isStartup.UseVisualStyleBackColor = true;
            // 
            // materialLabel_focus
            // 
            materialLabel_focus.AutoSize = true;
            materialLabel_focus.Depth = 0;
            materialLabel_focus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            materialLabel_focus.Location = new System.Drawing.Point(441, 38);
            materialLabel_focus.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel_focus.Name = "materialLabel_focus";
            materialLabel_focus.Size = new System.Drawing.Size(41, 19);
            materialLabel_focus.TabIndex = 43;
            materialLabel_focus.Text = "focus";
            // 
            // materialSlider_Accuracy
            // 
            materialSlider_Accuracy.Depth = 0;
            materialSlider_Accuracy.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            materialSlider_Accuracy.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            materialSlider_Accuracy.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            materialSlider_Accuracy.Location = new System.Drawing.Point(201, 90);
            materialSlider_Accuracy.MouseState = MaterialSkin.MouseState.HOVER;
            materialSlider_Accuracy.Name = "materialSlider_Accuracy";
            materialSlider_Accuracy.Size = new System.Drawing.Size(162, 40);
            materialSlider_Accuracy.TabIndex = 46;
            materialSlider_Accuracy.TabStop = false;
            materialSlider_Accuracy.Text = "";
            materialSlider_Accuracy.UseAccentColor = true;
            materialSlider_Accuracy.Value = 0;
            materialSlider_Accuracy.ValueMax = 100;
            materialSlider_Accuracy.ValueSuffix = "%";
            materialSlider_Accuracy.onValueChanged += materialSlider_Accuracy_onValueChanged;
            // 
            // materialSwitch_isSnipeMode
            // 
            materialSwitch_isSnipeMode.AutoSize = true;
            materialSwitch_isSnipeMode.Depth = 0;
            materialSwitch_isSnipeMode.Location = new System.Drawing.Point(1, 327);
            materialSwitch_isSnipeMode.Margin = new System.Windows.Forms.Padding(0);
            materialSwitch_isSnipeMode.MouseLocation = new System.Drawing.Point(-1, -1);
            materialSwitch_isSnipeMode.MouseState = MaterialSkin.MouseState.HOVER;
            materialSwitch_isSnipeMode.Name = "materialSwitch_isSnipeMode";
            materialSwitch_isSnipeMode.Ripple = true;
            materialSwitch_isSnipeMode.Size = new System.Drawing.Size(256, 37);
            materialSwitch_isSnipeMode.TabIndex = 48;
            materialSwitch_isSnipeMode.TabStop = false;
            materialSwitch_isSnipeMode.Text = "Sniping Mode (API required)";
            materialSwitch_isSnipeMode.UseVisualStyleBackColor = true;
            materialSwitch_isSnipeMode.CheckedChanged += materialSwitch_grouped_CheckedChanged;
            // 
            // materialTextBox_userId
            // 
            materialTextBox_userId.AnimateReadOnly = false;
            materialTextBox_userId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            materialTextBox_userId.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            materialTextBox_userId.Depth = 0;
            materialTextBox_userId.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            materialTextBox_userId.HideSelection = true;
            materialTextBox_userId.LeadingIcon = null;
            materialTextBox_userId.Location = new System.Drawing.Point(262, 327);
            materialTextBox_userId.MaxLength = 255;
            materialTextBox_userId.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox_userId.Name = "materialTextBox_userId";
            materialTextBox_userId.PasswordChar = '\0';
            materialTextBox_userId.PrefixSuffixText = null;
            materialTextBox_userId.ReadOnly = false;
            materialTextBox_userId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            materialTextBox_userId.SelectedText = "";
            materialTextBox_userId.SelectionLength = 0;
            materialTextBox_userId.SelectionStart = 0;
            materialTextBox_userId.ShortcutsEnabled = true;
            materialTextBox_userId.Size = new System.Drawing.Size(150, 36);
            materialTextBox_userId.TabIndex = 49;
            materialTextBox_userId.TabStop = false;
            materialTextBox_userId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            materialTextBox_userId.TrailingIcon = null;
            materialTextBox_userId.UseSystemPasswordChar = false;
            materialTextBox_userId.UseTallSize = false;
            // 
            // materialButton_isSnipeMode
            // 
            materialButton_isSnipeMode.AutoSize = false;
            materialButton_isSnipeMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            materialButton_isSnipeMode.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_isSnipeMode.Depth = 0;
            materialButton_isSnipeMode.Enabled = false;
            materialButton_isSnipeMode.HighEmphasis = true;
            materialButton_isSnipeMode.Icon = null;
            materialButton_isSnipeMode.Location = new System.Drawing.Point(426, 329);
            materialButton_isSnipeMode.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            materialButton_isSnipeMode.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_isSnipeMode.Name = "materialButton_isSnipeMode";
            materialButton_isSnipeMode.NoAccentTextColor = System.Drawing.Color.Empty;
            materialButton_isSnipeMode.Size = new System.Drawing.Size(56, 34);
            materialButton_isSnipeMode.TabIndex = 50;
            materialButton_isSnipeMode.TabStop = false;
            materialButton_isSnipeMode.Text = "Check";
            materialButton_isSnipeMode.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton_isSnipeMode.UseAccentColor = true;
            materialButton_isSnipeMode.UseVisualStyleBackColor = true;
            materialButton_isSnipeMode.Click += materialButton_isSnipeMode_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(45, 52, 54);
            ClientSize = new System.Drawing.Size(499, 381);
            Controls.Add(materialButton_isSnipeMode);
            Controls.Add(materialTextBox_userId);
            Controls.Add(materialSwitch_isSnipeMode);
            Controls.Add(materialCheckbox_isCheckingFullCombo);
            Controls.Add(materialLabel2);
            Controls.Add(materialTextBox_apiInput);
            Controls.Add(materialButton_checkApi);
            Controls.Add(materialLabel_apiNeeded);
            Controls.Add(materialSwitch_isAutoDisconnect);
            Controls.Add(materialSwitch_isSubmitIfFC);
            Controls.Add(materialSwitch_isTopMost);
            Controls.Add(materialSwitch_isToggleSound);
            Controls.Add(materialSwitch_isSystemTray);
            Controls.Add(materialSwitch_isStartup);
            Controls.Add(materialLabel_focus);
            Controls.Add(materialSlider_Accuracy);
            Name = "SettingsForm";
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();

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