﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WindowsInput;
using WindowsInput.Native;
using System.IO;
using Microsoft.Win32;
using System.Windows.Media;
using System.Reflection;
using System.Threading;
using AudioSwitcher.AudioApi.CoreAudio;

namespace osuEscape
{
    public partial class Form1 : Form
    {

        private int toggle = -1; //1: Allow Firewall; -1: Block Firewall

        public const int WM_HOTKEY_MSG_ID = 0x0312;

        private bool isLocationExist = false;

        //Global Hotkey
        private KeyHandler ghk;

        public Form1()
        {
            InitializeComponent();

            // check if osu!Escape is already opened
            if (Process.GetProcessesByName("osuEscape").Count() > 1)
                this.Close();            

            ghk = new KeyHandler(Keys.F6, this);
            ghk.Register();

            UIUpdate();
        }

        private void UIUpdate()
        {
            // UI Update with saved user settings
            startUpChk.Checked = Properties.Settings.Default.isStartUp;
            toggleSoundChk.Checked = Properties.Settings.Default.isToggleSound;
            systemTrayChk.Checked = Properties.Settings.Default.isSystemTray;

            // UI fixed size 
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void FindLocationButton_Click(object sender, EventArgs e) // select osu!.exe
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.Contains("osu!.exe"))
                {
                    RuleResetAndSetUp(ofd.FileName);
                }
                else
                {
                    // run until user finds osu.exe or user cancelled the action
                    findLocationButton.PerformClick();
                }
            }
        }

        private void ToggleFirewall()
        {
            ChangeConnection(toggle == 1); // isAllow
            toggle *= -1; // Check above for declaration 

            if (toggleSoundChk.Checked)
                System.Media.SystemSounds.Asterisk.Play();            
        }

        private string GetOsuPath()
        {
            return (Process.GetProcessesByName("osu!").Count() == 0 ? "" : Process.GetProcessesByName("osu!").FirstOrDefault().MainModule.FileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

            // check if user is playing osu!, then get the directory

            string str = GetOsuPath(); // when you already execute osu!.exe

            if (str != "")
            {
                Properties.Settings.Default.osuLocation = Process.GetProcessesByName("osu!").FirstOrDefault().MainModule.FileName;
                Properties.Settings.Default.Save();
                UpdateOsuLocationText();

                RuleResetAndSetUp(Properties.Settings.Default.osuLocation);
            }
            else
            {
                // if there is no user settings saved, initialize it
                if (Properties.Settings.Default.osuLocation.Contains("osu!"))
                {
                    RuleResetAndSetUp(Properties.Settings.Default.osuLocation);
                }
                else
                {
                    findLocationButton.PerformClick(); // trigger select folder function since there is no any record
                }
            }

            osuEscapeNotifyIcon.Visible = false;         
        }

        private void UpdateContextMenuStrip()
        {
            osuEscapeNotifyIcon.ContextMenuStrip = contextMenuStrip1;           

            //Status Update
            contextMenuStrip1.Items[0].Text = "Status: " + toggleButton.Text;

            //Quit function
            contextMenuStrip1.Items[1].Click += new EventHandler(QuitLabel_Click);    
        }
        private void QuitLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY_MSG_ID)
            {
                HandleHotkey();
            }                
           base.WndProc(ref m);
        }
        private void HandleHotkey()
        {
            ToggleFirewall();
        }

        private void ChangeConnection(bool isAllow)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "netsh";
            cmd.StartInfo.Arguments =
                "advfirewall firewall set rule name=\"osu block\" new enable=" + (isAllow ? "no" : "yes");
            cmd.StartInfo.Verb = "runas";
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.Start();

            toggleButton.Text = isAllow ? "Connecting" : "Blocked";
            toggleButton.ForeColor = isAllow ? System.Drawing.Color.Green : System.Drawing.Color.Red;
        }

        private void RuleResetAndSetUp(string filename) 
        {
            if (filename.Contains("osu!.exe"))
            {
                Properties.Settings.Default.osuLocation = filename;
                Properties.Settings.Default.Save();
                UpdateOsuLocationText();


                Process cmd = new Process();
                cmd.StartInfo.FileName = "netsh";
                cmd.StartInfo.Verb = "runas";
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;            

                // reset the rules if the users used this application before
                cmd.StartInfo.Arguments =
                    "advfirewall firewall delete rule name=\"osu block\"";
                cmd.Start();

                cmd.StartInfo.Arguments =
                    "advfirewall firewall add rule name=\"osu block\" dir=out action=block program=" + filename;
                cmd.Start();

                // disable at first to avoid unneeded disconnection
                cmd.StartInfo.Arguments =
                    "advfirewall firewall set rule name=\"osu block\" new enable=no"; ;
                cmd.Start();
                cmd.WaitForExit();

                toggleButton.Text = "Connecting";
                toggleButton.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void ToggleButton_Click(object sender, EventArgs e)
        {
            if (isLocationExist)
            {
                HandleHotkey();
            }
            else
            {
                MessageBox.Show("Invalid Location");
            }
        }

        private void UpdateOsuLocationText()
        {
            isLocationExist = true;
            pathTextBox.Text = "osu! Path: " + String.Join("\\", Properties.Settings.Default.osuLocation.Split('\\').Reverse().Skip(1).Reverse()) + "\\";
        }

        private void SetRunAtStartup(bool enabled)
        {
            try
            {
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);            

                if (enabled)
                {
                    rk.SetValue("osu!Escape", "\"" + path + "\" --hide");
                }                    
                else
                {
                    rk.DeleteValue("osu!Escape", false);
                }
                rk.Close();
            }
            catch (Exception)
            {
            }
        }
        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {            
            this.WindowState = FormWindowState.Normal;
            osuEscapeNotifyIcon.Visible = false;
            this.ShowInTaskbar = true;

            // Re-enable Hotkey
            ghk.Unregiser();
            ghk = new KeyHandler(Keys.F6, this);
            ghk.Register();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)
            
            if (systemTrayChk.Checked && this.WindowState == FormWindowState.Minimized)
            {
                osuEscapeNotifyIcon.Visible = true;
                this.ShowInTaskbar = false;
                UpdateContextMenuStrip();
            }
                
        }

        private void StartUpChk_CheckedChanged(object sender, EventArgs e)
        {
            if (startUpChk.Checked)
                SetRunAtStartup(true);
            else
                SetRunAtStartup(false);

            Properties.Settings.Default.isStartUp = startUpChk.Checked;
        }

        private void ToggleSoundChk_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isToggleSound = toggleSoundChk.Checked;
        }

        private void SystemTrayChk_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isSystemTray = systemTrayChk.Checked;
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}