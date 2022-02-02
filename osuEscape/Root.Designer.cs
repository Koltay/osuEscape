namespace osuEscape
{
    partial class Root
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Root));
            this.materialTabControl_menu = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage_main = new System.Windows.Forms.TabPage();
            this.tabPage_settings = new System.Windows.Forms.TabPage();
            this.tabPage_uploadedScores = new System.Windows.Forms.TabPage();
            this.contextMenuStrip_osu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon_osuEscape = new System.Windows.Forms.NotifyIcon(this.components);
            this.materialTabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.materialTabControl_menu.SuspendLayout();
            this.contextMenuStrip_osu.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl_menu
            // 
            this.materialTabControl_menu.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.materialTabControl_menu.Controls.Add(this.tabPage_main);
            this.materialTabControl_menu.Controls.Add(this.tabPage_settings);
            this.materialTabControl_menu.Controls.Add(this.tabPage_uploadedScores);
            this.materialTabControl_menu.Depth = 0;
            this.materialTabControl_menu.Location = new System.Drawing.Point(-1, 98);
            this.materialTabControl_menu.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl_menu.Multiline = true;
            this.materialTabControl_menu.Name = "materialTabControl_menu";
            this.materialTabControl_menu.Padding = new System.Drawing.Point(0, 0);
            this.materialTabControl_menu.SelectedIndex = 0;
            this.materialTabControl_menu.Size = new System.Drawing.Size(554, 393);
            this.materialTabControl_menu.TabIndex = 0;
            this.materialTabControl_menu.Selected += new System.Windows.Forms.TabControlEventHandler(this.materialTabControl_menu_Selected);
            // 
            // tabPage_main
            // 
            this.tabPage_main.BackColor = System.Drawing.Color.White;
            this.tabPage_main.ImageKey = "Home_32.png";
            this.tabPage_main.Location = new System.Drawing.Point(4, 27);
            this.tabPage_main.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_main.Name = "tabPage_main";
            this.tabPage_main.Size = new System.Drawing.Size(546, 362);
            this.tabPage_main.TabIndex = 0;
            this.tabPage_main.Text = "Main";
            // 
            // tabPage_settings
            // 
            this.tabPage_settings.BackColor = System.Drawing.Color.White;
            this.tabPage_settings.ImageKey = "Setting_32.png";
            this.tabPage_settings.Location = new System.Drawing.Point(4, 27);
            this.tabPage_settings.Name = "tabPage_settings";
            this.tabPage_settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings.Size = new System.Drawing.Size(546, 362);
            this.tabPage_settings.TabIndex = 1;
            this.tabPage_settings.Text = "Settings";
            // 
            // tabPage_uploadedScores
            // 
            this.tabPage_uploadedScores.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage_uploadedScores.Location = new System.Drawing.Point(4, 27);
            this.tabPage_uploadedScores.Name = "tabPage_uploadedScores";
            this.tabPage_uploadedScores.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_uploadedScores.Size = new System.Drawing.Size(546, 362);
            this.tabPage_uploadedScores.TabIndex = 2;
            this.tabPage_uploadedScores.Text = "Uploaded Scores";
            // 
            // contextMenuStrip_osu
            // 
            this.contextMenuStrip_osu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextMenuStrip_osu.Name = "contextMenuStrip_osu";
            this.contextMenuStrip_osu.Size = new System.Drawing.Size(113, 48);
            this.contextMenuStrip_osu.Text = "osu!Escape";
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.statusToolStripMenuItem.Text = "Status: ";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // notifyIcon_osuEscape
            // 
            this.notifyIcon_osuEscape.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_osuEscape.Icon")));
            this.notifyIcon_osuEscape.Text = "osu!Escape";
            this.notifyIcon_osuEscape.Visible = true;
            this.notifyIcon_osuEscape.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_osuEscape_MouseDoubleClick);
            // 
            // materialTabSelector
            // 
            this.materialTabSelector.BaseTabControl = this.materialTabControl_menu;
            this.materialTabSelector.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            this.materialTabSelector.Depth = 0;
            this.materialTabSelector.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTabSelector.Location = new System.Drawing.Point(0, 64);
            this.materialTabSelector.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.materialTabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector.Name = "materialTabSelector";
            this.materialTabSelector.Size = new System.Drawing.Size(553, 35);
            this.materialTabSelector.TabIndex = 1;
            this.materialTabSelector.TabStop = false;
            // 
            // Root
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(553, 497);
            this.Controls.Add(this.materialTabSelector);
            this.Controls.Add(this.materialTabControl_menu);
            this.DrawerShowIconsWhenHidden = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Root";
            this.Text = "osu! Escape";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosing_RootForm);
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.materialTabControl_menu.ResumeLayout(false);
            this.contextMenuStrip_osu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl_menu;
        private System.Windows.Forms.TabPage tabPage_main;
        private System.Windows.Forms.TabPage tabPage_settings;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_osu;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon_osuEscape;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.TabPage tabPage_uploadedScores;
        private MaterialSkin.Controls.MaterialListView materialListView_uploadedScores;
        private System.Windows.Forms.ColumnHeader Beatmap;
        private System.Windows.Forms.ColumnHeader Score;
        private System.Windows.Forms.ColumnHeader Accuracy;
    }
}