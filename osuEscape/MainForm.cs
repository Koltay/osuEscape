using System;
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
using System.Timers;

namespace osuEscape
{
    public partial class MainForm : Form
    { 

        private int toggle = -1; //1: Allow Firewall; -1: Block Firewall

        public const int WM_HOTKEY_MSG_ID = 0x0312;

        private bool isLocationExist = false;

        //Global Hotkey
        private KeyHandler ghk;

        private static System.Timers.Timer aTimer;

        private Process osuProcess;

        public MainForm()
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
            topMostChk.Checked = Properties.Settings.Default.isTopMost;

            // UI fixed size 
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void FindLocationButton_Click(object sender, EventArgs e) // select osu!.exe
        {
            FindLocation();
        }

        private void FindLocation()
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
                    // run again until user finds osu.exe or user cancelled the action
                    FindLocation();
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

        private void MainForm_Load(object sender, EventArgs e)
        {             
            // avoid opening twice
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

            // open the app at the previous location 
            this.Location = Properties.Settings.Default.appLocation;

            // getting osu! directory from running process
            string str = GetOsuPath(); 

            if (str != "")
            {
                Properties.Settings.Default.osuLocation = Process.GetProcessesByName("osu!").FirstOrDefault().MainModule.FileName;

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
                    FindLocation(); // trigger select folder function since there is no any record
                }
            }

            osuEscapeNotifyIcon.Visible = false;         
        }

        private void UpdateContextMenuStrip()
        {
            osuEscapeNotifyIcon.ContextMenuStrip = osuCMS;           

            //Status Update
            osuCMS.Items[0].Text = "Status: " + toggleButton.Text;

            osuCMS.Items[1].Click += new EventHandler(QuitLabel_Click);
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
                    rk.SetValue("osu!Escape", "\"" + path + "\" --hide");                  
                else
                    rk.DeleteValue("osu!Escape", false);

                rk.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void OsuEscapeNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {            
            this.WindowState = FormWindowState.Normal;
            ToggleSystemTray(false);

            // Re-enable Hotkey
            ghk.Unregiser();
            ghk = new KeyHandler(Keys.F6, this);
            ghk.Register();
        }

        private void StartUpChk_CheckedChanged(object sender, EventArgs e)
        {        
            SetRunAtStartup(startUpChk.Checked);

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
            // save the last position of the application
            if (this.WindowState != FormWindowState.Minimized)
                Properties.Settings.Default.appLocation = this.Location;

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

        // Make dragging also usable for label
        private void TitleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void TitleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void TitleLabel_MouseUp(object sender, MouseEventArgs e)
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

            if (systemTrayChk.Checked)
            {
                ToggleSystemTray(true);
                UpdateContextMenuStrip();
            }
        }

        private void ToggleSystemTray(bool enabled)
        {
            osuEscapeNotifyIcon.Visible = enabled;
            this.ShowInTaskbar = !enabled;
        }

        private void TopMostChk_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTopMost = topMostChk.Checked;
            this.TopMost = topMostChk.Checked;                
        }

        private void OpenOsuButton_Click(object sender, EventArgs e)
        {
            // kill the process, then re-open osu! using cmd command line
            Process[] prs = Process.GetProcesses();

            foreach (Process process in prs)
            {
                if (process.ProcessName == "osu!")
                {
                    process.Kill();
                    toggleOsuTextBox.Text = "Closed!";
                    break;
                }
            }

            // allow connection to avoid no login
            toggle = -1;
            ChangeConnection(true);

            // start osu! process
            osuProcess = Process.Start(Properties.Settings.Default.osuLocation);

            toggleOsuTextBox.Text = "Opening osu!...";

            OpenOsuSetTimer(5000);                           
        }

        private void OpenOsuSetTimer(int time)
        {
            aTimer = new System.Timers.Timer(time);

            aTimer.Elapsed += OpenOsuOnTimedEvent;

            aTimer.AutoReset = false;

            aTimer.Enabled = true;
        }

        private void OpenOsuOnTimedEvent(Object source, ElapsedEventArgs e)
        {
            try
            {
                if (Process.GetProcessesByName("osu!").Count() >= 1)
                    SetText("Opened!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.toggleOsuTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.toggleOsuTextBox.Text = text;
            }
        }

        private void CloseOsuButton_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("osu!").Count() == 0)
                toggleOsuTextBox.Text = "You have not opened any osu!";
            else
            {               
                Process[] prs = Process.GetProcesses();

                foreach (Process process in prs)
                {
                    if (process.ProcessName == "osu!")
                    {
                        process.Kill();
                        toggleOsuTextBox.Text = "Closed!";
                        break;
                    }                        
                }
            }
        }
    }
}