namespace osuEscape
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.materialTabControl_menu = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage_main = new System.Windows.Forms.TabPage();
            this.tabPage_settings = new System.Windows.Forms.TabPage();
            this.imageList_menu = new System.Windows.Forms.ImageList(this.components);
            this.materialTabControl_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl_menu
            // 
            this.materialTabControl_menu.Controls.Add(this.tabPage_main);
            this.materialTabControl_menu.Controls.Add(this.tabPage_settings);
            this.materialTabControl_menu.Depth = 0;
            this.materialTabControl_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl_menu.ImageList = this.imageList_menu;
            this.materialTabControl_menu.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl_menu.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl_menu.Multiline = true;
            this.materialTabControl_menu.Name = "materialTabControl_menu";
            this.materialTabControl_menu.SelectedIndex = 0;
            this.materialTabControl_menu.Size = new System.Drawing.Size(794, 383);
            this.materialTabControl_menu.TabIndex = 0;
            // 
            // tabPage_main
            // 
            this.tabPage_main.BackColor = System.Drawing.Color.White;
            this.tabPage_main.ImageKey = "Home_32.png";
            this.tabPage_main.Location = new System.Drawing.Point(4, 39);
            this.tabPage_main.Name = "tabPage_main";
            this.tabPage_main.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_main.Size = new System.Drawing.Size(786, 340);
            this.tabPage_main.TabIndex = 0;
            this.tabPage_main.Text = "Main";
            // 
            // tabPage_settings
            // 
            this.tabPage_settings.BackColor = System.Drawing.Color.White;
            this.tabPage_settings.ImageKey = "Setting_32.png";
            this.tabPage_settings.Location = new System.Drawing.Point(4, 39);
            this.tabPage_settings.Name = "tabPage_settings";
            this.tabPage_settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings.Size = new System.Drawing.Size(786, 340);
            this.tabPage_settings.TabIndex = 1;
            this.tabPage_settings.Text = "Settings";
            // 
            // imageList_menu
            // 
            this.imageList_menu.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList_menu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_menu.ImageStream")));
            this.imageList_menu.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_menu.Images.SetKeyName(0, "Home_32.png");
            this.imageList_menu.Images.SetKeyName(1, "Setting_32.png");
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.materialTabControl_menu);
            this.MaximizeBox = false;
            this.Name = "HomeForm";
            this.Text = "osu! Escape";
            this.materialTabControl_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl_menu;
        private System.Windows.Forms.TabPage tabPage_main;
        private System.Windows.Forms.TabPage tabPage_settings;
        private System.Windows.Forms.ImageList imageList_menu;
    }
}