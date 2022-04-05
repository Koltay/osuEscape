namespace osuEscape
{
    partial class UploadedScoresForm
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup_Beatmap", System.Windows.Forms.HorizontalAlignment.Center);
            this.materialListView_uploadedScores = new MaterialSkin.Controls.MaterialListView();
            this.Beatmap = new System.Windows.Forms.ColumnHeader();
            this.Score = new System.Windows.Forms.ColumnHeader();
            this.Accuracy = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // materialListView_uploadedScores
            // 
            this.materialListView_uploadedScores.AutoSizeTable = false;
            this.materialListView_uploadedScores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialListView_uploadedScores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialListView_uploadedScores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Beatmap,
            this.Score,
            this.Accuracy});
            this.materialListView_uploadedScores.Depth = 0;
            this.materialListView_uploadedScores.FullRowSelect = true;
            listViewGroup1.CollapsedState = System.Windows.Forms.ListViewGroupCollapsedState.Expanded;
            listViewGroup1.FooterAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup1.Header = "ListViewGroup_Beatmap";
            listViewGroup1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup1.Name = "Beatmap";
            this.materialListView_uploadedScores.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.materialListView_uploadedScores.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.materialListView_uploadedScores.HideSelection = false;
            this.materialListView_uploadedScores.LabelWrap = false;
            this.materialListView_uploadedScores.Location = new System.Drawing.Point(5, 4);
            this.materialListView_uploadedScores.MaximumSize = new System.Drawing.Size(540, 335);
            this.materialListView_uploadedScores.MinimumSize = new System.Drawing.Size(540, 335);
            this.materialListView_uploadedScores.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialListView_uploadedScores.MouseState = MaterialSkin.MouseState.OUT;
            this.materialListView_uploadedScores.MultiSelect = false;
            this.materialListView_uploadedScores.Name = "materialListView_uploadedScores";
            this.materialListView_uploadedScores.OwnerDraw = true;
            this.materialListView_uploadedScores.Scrollable = false;
            this.materialListView_uploadedScores.ShowGroups = false;
            this.materialListView_uploadedScores.Size = new System.Drawing.Size(540, 335);
            this.materialListView_uploadedScores.TabIndex = 4;
            this.materialListView_uploadedScores.UseCompatibleStateImageBehavior = false;
            this.materialListView_uploadedScores.View = System.Windows.Forms.View.Details;
            // 
            // Beatmap
            // 
            this.Beatmap.Text = "Beatmap";
            this.Beatmap.Width = 340;
            // 
            // Score
            // 
            this.Score.Text = "Score";
            this.Score.Width = 120;
            // 
            // Accuracy
            // 
            this.Accuracy.Text = "Accuracy";
            this.Accuracy.Width = 100;
            // 
            // UploadedScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.materialListView_uploadedScores);
            this.Name = "UploadedScoresForm";
            this.Text = "UploadedScoresForm";
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialListView materialListView_uploadedScores;
        private System.Windows.Forms.ColumnHeader Beatmap;
        private System.Windows.Forms.ColumnHeader Score;
        private System.Windows.Forms.ColumnHeader Accuracy;
    }
}