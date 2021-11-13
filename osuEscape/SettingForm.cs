using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace osuEscape
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void materialCheckbox_autoDisconnect_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isAutoDisconnect = materialCheckbox_autoDisconnect.Checked;
        }

        private void materialCheckbox_submitIfFC_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isSubmitIfFC = materialCheckbox_submitIfFC.Checked;
        }

        private void materialCheckbox_hideData_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isHideData = materialCheckbox_hideData.Checked;

            //hide data set at uiupdate?
        }

        private void materialCheckbox_topMost_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTopMost = materialCheckbox_topMost.Checked;
            this.TopMost = materialCheckbox_topMost.Checked;
        }

        private void materialCheckbox_toggleWithSound_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isToggleSound = materialCheckbox_toggleWithSound.Checked;
        }

        private void materialCheckbox_minimizeToSystemTray_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isSystemTray = materialCheckbox_minimizeToSystemTray.Checked;
        }

        private void materialCheckbox_runAtStartup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isStartup = materialCheckbox_runAtStartup.Checked;

            MainForm.SetRunAtStartup(materialCheckbox_runAtStartup.Checked);
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            //this.Location = osuEscape.Location;
        }

        private void MaterialButton_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Panel Dragging

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Panel_top_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Panel_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Panel_top_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        // Make dragging also usable for label
        private void Label_title_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Label_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Label_title_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        #endregion
    }
}
