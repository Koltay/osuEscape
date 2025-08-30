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
            materialLabel_accuracy = new MaterialSkin.Controls.MaterialLabel();
            materialButton_OAuth = new MaterialSkin.Controls.MaterialButton();
            materialLabel_apiNeeded = new MaterialSkin.Controls.MaterialLabel();
            materialSwitch_isAutoDisconnect = new MaterialSkin.Controls.MaterialSwitch();
            materialSwitch_isSubmitIfFC = new MaterialSkin.Controls.MaterialSwitch();
            materialSwitch_isTopMost = new MaterialSkin.Controls.MaterialSwitch();
            materialSwitch_isToggleSound = new MaterialSkin.Controls.MaterialSwitch();
            materialSwitch_isSystemTray = new MaterialSkin.Controls.MaterialSwitch();
            materialSwitch_isStartup = new MaterialSkin.Controls.MaterialSwitch();
            materialSlider_accuracy = new MaterialSkin.Controls.MaterialSlider();
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
            materialCheckbox_isCheckingFullCombo.Location = new System.Drawing.Point(317, 298);
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
            // materialLabel_accuracy
            // 
            materialLabel_accuracy.AutoSize = true;
            materialLabel_accuracy.Depth = 0;
            materialLabel_accuracy.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            materialLabel_accuracy.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            materialLabel_accuracy.Location = new System.Drawing.Point(63, 308);
            materialLabel_accuracy.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel_accuracy.Name = "materialLabel_accuracy";
            materialLabel_accuracy.Size = new System.Drawing.Size(66, 19);
            materialLabel_accuracy.TabIndex = 45;
            materialLabel_accuracy.Text = "Accuracy";
            materialLabel_accuracy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            materialLabel_accuracy.Click += materialLabel2_Click;
            // 
            // materialButton_OAuth
            // 
            materialButton_OAuth.AutoSize = false;
            materialButton_OAuth.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            materialButton_OAuth.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_OAuth.Depth = 0;
            materialButton_OAuth.HighEmphasis = true;
            materialButton_OAuth.Icon = null;
            materialButton_OAuth.Location = new System.Drawing.Point(9, 226);
            materialButton_OAuth.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            materialButton_OAuth.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_OAuth.Name = "materialButton_OAuth";
            materialButton_OAuth.NoAccentTextColor = System.Drawing.Color.Empty;
            materialButton_OAuth.Size = new System.Drawing.Size(270, 34);
            materialButton_OAuth.TabIndex = 41;
            materialButton_OAuth.TabStop = false;
            materialButton_OAuth.Text = "OAuth Verification";
            materialButton_OAuth.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton_OAuth.UseAccentColor = true;
            materialButton_OAuth.UseVisualStyleBackColor = true;
            materialButton_OAuth.Click += materialButton_OAuth_Click;
            // 
            // materialLabel_apiNeeded
            // 
            materialLabel_apiNeeded.AutoSize = true;
            materialLabel_apiNeeded.Depth = 0;
            materialLabel_apiNeeded.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            materialLabel_apiNeeded.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            materialLabel_apiNeeded.Location = new System.Drawing.Point(9, 203);
            materialLabel_apiNeeded.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel_apiNeeded.Name = "materialLabel_apiNeeded";
            materialLabel_apiNeeded.Size = new System.Drawing.Size(131, 17);
            materialLabel_apiNeeded.TabIndex = 34;
            materialLabel_apiNeeded.Text = "API required options";
            // 
            // materialSwitch_isAutoDisconnect
            // 
            materialSwitch_isAutoDisconnect.AutoSize = true;
            materialSwitch_isAutoDisconnect.Depth = 0;
            materialSwitch_isAutoDisconnect.Enabled = false;
            materialSwitch_isAutoDisconnect.Location = new System.Drawing.Point(7, 266);
            materialSwitch_isAutoDisconnect.Margin = new System.Windows.Forms.Padding(0);
            materialSwitch_isAutoDisconnect.MouseLocation = new System.Drawing.Point(-1, -1);
            materialSwitch_isAutoDisconnect.MouseState = MaterialSkin.MouseState.HOVER;
            materialSwitch_isAutoDisconnect.Name = "materialSwitch_isAutoDisconnect";
            materialSwitch_isAutoDisconnect.Ripple = true;
            materialSwitch_isAutoDisconnect.Size = new System.Drawing.Size(196, 37);
            materialSwitch_isAutoDisconnect.TabIndex = 40;
            materialSwitch_isAutoDisconnect.TabStop = false;
            materialSwitch_isAutoDisconnect.Text = "Auto Disconnection";
            materialSwitch_isAutoDisconnect.UseVisualStyleBackColor = true;
            materialSwitch_isAutoDisconnect.CheckedChanged += materialSwitch_grouped_CheckedChanged;
            // 
            // materialSwitch_isSubmitIfFC
            // 
            materialSwitch_isSubmitIfFC.AutoSize = true;
            materialSwitch_isSubmitIfFC.Depth = 0;
            materialSwitch_isSubmitIfFC.Location = new System.Drawing.Point(9, 10);
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
            materialSwitch_isTopMost.Location = new System.Drawing.Point(9, 86);
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
            materialSwitch_isToggleSound.Location = new System.Drawing.Point(9, 46);
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
            materialSwitch_isSystemTray.Location = new System.Drawing.Point(9, 166);
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
            materialSwitch_isStartup.Location = new System.Drawing.Point(9, 126);
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
            // materialSlider_accuracy
            // 
            materialSlider_accuracy.Depth = 0;
            materialSlider_accuracy.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            materialSlider_accuracy.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            materialSlider_accuracy.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            materialSlider_accuracy.Location = new System.Drawing.Point(135, 298);
            materialSlider_accuracy.MouseState = MaterialSkin.MouseState.HOVER;
            materialSlider_accuracy.Name = "materialSlider_accuracy";
            materialSlider_accuracy.Size = new System.Drawing.Size(162, 40);
            materialSlider_accuracy.TabIndex = 46;
            materialSlider_accuracy.TabStop = false;
            materialSlider_accuracy.Text = "";
            materialSlider_accuracy.UseAccentColor = true;
            materialSlider_accuracy.Value = 0;
            materialSlider_accuracy.ValueMax = 100;
            materialSlider_accuracy.ValueSuffix = "%";
            materialSlider_accuracy.onValueChanged += materialSlider_Accuracy_onValueChanged;
            materialSlider_accuracy.Click += materialSlider_accuracy_Click;
            // 
            // materialSwitch_isSnipeMode
            // 
            materialSwitch_isSnipeMode.AutoSize = true;
            materialSwitch_isSnipeMode.Depth = 0;
            materialSwitch_isSnipeMode.Location = new System.Drawing.Point(9, 338);
            materialSwitch_isSnipeMode.Margin = new System.Windows.Forms.Padding(0);
            materialSwitch_isSnipeMode.MouseLocation = new System.Drawing.Point(-1, -1);
            materialSwitch_isSnipeMode.MouseState = MaterialSkin.MouseState.HOVER;
            materialSwitch_isSnipeMode.Name = "materialSwitch_isSnipeMode";
            materialSwitch_isSnipeMode.Ripple = true;
            materialSwitch_isSnipeMode.Size = new System.Drawing.Size(255, 37);
            materialSwitch_isSnipeMode.TabIndex = 48;
            materialSwitch_isSnipeMode.TabStop = false;
            materialSwitch_isSnipeMode.Text = "Snipe user (Username or ID)";
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
            materialTextBox_userId.Location = new System.Drawing.Point(273, 339);
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
            materialButton_isSnipeMode.Location = new System.Drawing.Point(430, 341);
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
            Controls.Add(materialLabel_accuracy);
            Controls.Add(materialButton_OAuth);
            Controls.Add(materialLabel_apiNeeded);
            Controls.Add(materialSwitch_isAutoDisconnect);
            Controls.Add(materialSwitch_isSubmitIfFC);
            Controls.Add(materialSwitch_isTopMost);
            Controls.Add(materialSwitch_isToggleSound);
            Controls.Add(materialSwitch_isSystemTray);
            Controls.Add(materialSwitch_isStartup);
            Controls.Add(materialSlider_accuracy);
            Name = "SettingsForm";
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_isCheckingFullCombo;
        private MaterialSkin.Controls.MaterialLabel materialLabel_accuracy;
        private MaterialSkin.Controls.MaterialButton materialButton_OAuth;
        private MaterialSkin.Controls.MaterialLabel materialLabel_apiNeeded;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_isAutoDisconnect;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_isSubmitIfFC;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_isTopMost;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_isToggleSound;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_isSystemTray;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_isStartup;
        private MaterialSkin.Controls.MaterialSlider materialSlider_accuracy;
        private System.Windows.Forms.ToolTip toolTips;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_isSnipeMode;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox_userId;
        private MaterialSkin.Controls.MaterialButton materialButton_isSnipeMode;
    }
}