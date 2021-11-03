namespace OsuMemoryDataProviderTester
{
    partial class OsuMemoryDataProviderForm
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
            this.textBox_mapId = new System.Windows.Forms.TextBox();
            this.textBox_strings = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Status = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_CurrentPlayData = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_readDelay = new System.Windows.Forms.NumericUpDown();
            this.textBox_time = new System.Windows.Forms.TextBox();
            this.button_ResetReadTimeMinMax = new System.Windows.Forms.Button();
            this.checkBox_OsuBase = new System.Windows.Forms.CheckBox();
            this.checkBox_Mods = new System.Windows.Forms.CheckBox();
            this.checkBox_CurrentSkinData = new System.Windows.Forms.CheckBox();
            this.checkBox_PlayContainer = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_readDelay)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_mapId
            // 
            this.textBox_mapId.Location = new System.Drawing.Point(13, 63);
            this.textBox_mapId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_mapId.Multiline = true;
            this.textBox_mapId.Name = "textBox_mapId";
            this.textBox_mapId.Size = new System.Drawing.Size(116, 48);
            this.textBox_mapId.TabIndex = 0;
            // 
            // textBox_strings
            // 
            this.textBox_strings.Location = new System.Drawing.Point(202, 32);
            this.textBox_strings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_strings.Multiline = true;
            this.textBox_strings.Name = "textBox_strings";
            this.textBox_strings.Size = new System.Drawing.Size(394, 136);
            this.textBox_strings.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "mapId";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Strings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Status";
            // 
            // textBox_Status
            // 
            this.textBox_Status.Location = new System.Drawing.Point(13, 145);
            this.textBox_Status.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Status.Name = "textBox_Status";
            this.textBox_Status.Size = new System.Drawing.Size(116, 23);
            this.textBox_Status.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.No;
            this.label4.Location = new System.Drawing.Point(18, 182);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "CurrentPlay (available when playing)";
            // 
            // textBox_CurrentPlayData
            // 
            this.textBox_CurrentPlayData.Location = new System.Drawing.Point(16, 201);
            this.textBox_CurrentPlayData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_CurrentPlayData.Multiline = true;
            this.textBox_CurrentPlayData.Name = "textBox_CurrentPlayData";
            this.textBox_CurrentPlayData.Size = new System.Drawing.Size(279, 103);
            this.textBox_CurrentPlayData.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(318, 184);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Read delay in ms (set 0 for no delay):";
            // 
            // numericUpDown_readDelay
            // 
            this.numericUpDown_readDelay.Location = new System.Drawing.Point(321, 202);
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
            // textBox_time
            // 
            this.textBox_time.Location = new System.Drawing.Point(13, 10);
            this.textBox_time.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_time.Name = "textBox_time";
            this.textBox_time.Size = new System.Drawing.Size(116, 23);
            this.textBox_time.TabIndex = 13;
            // 
            // button_ResetReadTimeMinMax
            // 
            this.button_ResetReadTimeMinMax.Location = new System.Drawing.Point(318, 231);
            this.button_ResetReadTimeMinMax.Name = "button_ResetReadTimeMinMax";
            this.button_ResetReadTimeMinMax.Size = new System.Drawing.Size(75, 23);
            this.button_ResetReadTimeMinMax.TabIndex = 17;
            this.button_ResetReadTimeMinMax.Text = "Reset";
            this.button_ResetReadTimeMinMax.UseVisualStyleBackColor = true;
            this.button_ResetReadTimeMinMax.Click += new System.EventHandler(this.Button_ResetReadTimeMinMax_Click);
            // 
            // checkBox_OsuBase
            // 
            this.checkBox_OsuBase.AutoSize = true;
            this.checkBox_OsuBase.Checked = true;
            this.checkBox_OsuBase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_OsuBase.Location = new System.Drawing.Point(6, 21);
            this.checkBox_OsuBase.Name = "checkBox_OsuBase";
            this.checkBox_OsuBase.Size = new System.Drawing.Size(71, 19);
            this.checkBox_OsuBase.TabIndex = 0;
            this.checkBox_OsuBase.Tag = "OsuBase";
            this.checkBox_OsuBase.Text = "OsuBase";
            this.checkBox_OsuBase.UseVisualStyleBackColor = true;
            this.checkBox_OsuBase.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox_Mods
            // 
            this.checkBox_Mods.AutoSize = true;
            this.checkBox_Mods.Checked = true;
            this.checkBox_Mods.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Mods.Location = new System.Drawing.Point(89, 21);
            this.checkBox_Mods.Name = "checkBox_Mods";
            this.checkBox_Mods.Size = new System.Drawing.Size(56, 19);
            this.checkBox_Mods.TabIndex = 2;
            this.checkBox_Mods.Tag = "Mods";
            this.checkBox_Mods.Text = "Mods";
            this.checkBox_Mods.UseVisualStyleBackColor = true;
            this.checkBox_Mods.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox_CurrentSkinData
            // 
            this.checkBox_CurrentSkinData.AutoSize = true;
            this.checkBox_CurrentSkinData.Checked = true;
            this.checkBox_CurrentSkinData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_CurrentSkinData.Location = new System.Drawing.Point(157, 21);
            this.checkBox_CurrentSkinData.Name = "checkBox_CurrentSkinData";
            this.checkBox_CurrentSkinData.Size = new System.Drawing.Size(112, 19);
            this.checkBox_CurrentSkinData.TabIndex = 3;
            this.checkBox_CurrentSkinData.Tag = "CurrentSkinData";
            this.checkBox_CurrentSkinData.Text = "CurrentSkinData";
            this.checkBox_CurrentSkinData.UseVisualStyleBackColor = true;
            this.checkBox_CurrentSkinData.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox_PlayContainer
            // 
            this.checkBox_PlayContainer.AutoSize = true;
            this.checkBox_PlayContainer.Checked = true;
            this.checkBox_PlayContainer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_PlayContainer.Location = new System.Drawing.Point(6, 46);
            this.checkBox_PlayContainer.Name = "checkBox_PlayContainer";
            this.checkBox_PlayContainer.Size = new System.Drawing.Size(208, 19);
            this.checkBox_PlayContainer.TabIndex = 5;
            this.checkBox_PlayContainer.Tag = "PlayContainer";
            this.checkBox_PlayContainer.Text = "PlayContainer (only when playing)";
            this.checkBox_PlayContainer.UseVisualStyleBackColor = true;
            this.checkBox_PlayContainer.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_PlayContainer);
            this.groupBox1.Controls.Add(this.checkBox_CurrentSkinData);
            this.groupBox1.Controls.Add(this.checkBox_Mods);
            this.groupBox1.Controls.Add(this.checkBox_OsuBase);
            this.groupBox1.Location = new System.Drawing.Point(302, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 75);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enabled Patterns";
            // 
            // OsuMemoryDataProviderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 342);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_ResetReadTimeMinMax);
            this.Controls.Add(this.textBox_time);
            this.Controls.Add(this.numericUpDown_readDelay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_CurrentPlayData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_strings);
            this.Controls.Add(this.textBox_mapId);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "OsuMemoryDataProviderForm";
            this.Text = "OsuMemoryDataProvider Form";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_readDelay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_mapId;
        private System.Windows.Forms.TextBox textBox_strings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_CurrentPlayData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown_readDelay;


        private System.Windows.Forms.TextBox textBox_time;

        private System.Windows.Forms.Button button_ResetReadTimeMinMax;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_OsuBase;
        private System.Windows.Forms.CheckBox checkBox_Mods;
        private System.Windows.Forms.CheckBox checkBox_CurrentSkinData;
        private System.Windows.Forms.CheckBox checkBox_PlayContainer;

    }
}

