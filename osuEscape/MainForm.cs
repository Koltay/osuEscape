using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;
using System.Timers;


namespace osuEscape
{

    
    public partial class MainForm : Form
    {
        private readonly string _osuWindowTitleHint;

        private int toggle = -1; //1: Allow Firewall; -1: Block Firewall

        public const int WM_HOTKEY_MSG_ID = 0x0312;

        private bool isLocationExist = false;

        //Global Hotkey
        private KeyHandler ghk;

        private static System.Timers.Timer aTimer;

        public MainForm(string osuWindowTitleHint)
        {
            _osuWindowTitleHint = osuWindowTitleHint;
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
            checkBox_startUp.Checked = Properties.Settings.Default.isStartUp;
            checkBox_toggleSound.Checked = Properties.Settings.Default.isToggleSound;
            checkBox_systemTray.Checked = Properties.Settings.Default.isSystemTray;
            checkBox_topMost.Checked = Properties.Settings.Default.isTopMost;

            // UI fixed size 
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void Button_findLocation_Click(object sender, EventArgs e) // select osu!.exe
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

            if (checkBox_toggleSound.Checked)
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

            notifyIcon_osuEscape.Visible = false;

            //lock (_patternsToSkip)
            //{
            //    // we store inverted state, easier since default is all on, so we can have a default of empty set to check :D
            //    _patternsToSkip.Add("OsuBase");
            //    _patternsToSkip.Add("PlayContainer");
            //    _patternsToSkip.Add("TourneyBase");
            //    _patternsToSkip.Add("Mods");
            //    _patternsToSkip.Add("IsReplay");
            //    _patternsToSkip.Add("CurrentSkinData");
            //}
        }

        private void ContextMenuStripUpdate()
        {
            notifyIcon_osuEscape.ContextMenuStrip = contextMenuStrip_osu;           

            //Status Update
            contextMenuStrip_osu.Items[0].Text = "Status: " + button_toggle.Text;

            contextMenuStrip_osu.Items[1].Click += new EventHandler(Item_quit_Click);

            notifyIcon_osuEscape.Icon = (button_toggle.Text == "Connecting") ? Properties.Resources.osuEscapeConnecting : Properties.Resources.osuEscapeBlocking;
        }
        private void Item_quit_Click(object sender, EventArgs e)
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

            ToggleButtonUpdate(isAllow);
            ContextMenuStripUpdate();
        }

        private void ToggleButtonUpdate(bool isAllow)
        {
            button_toggle.Text = isAllow ? "Connecting" : "Blocked";
            button_toggle.ForeColor = isAllow ? System.Drawing.Color.Green : System.Drawing.Color.Red;
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

                button_toggle.Text = "Connecting";
                button_toggle.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void Button_toggle_Click(object sender, EventArgs e)
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
            textBox_osuPath.Text = "osu! Path: " + String.Join("\\", Properties.Settings.Default.osuLocation.Split('\\').Reverse().Skip(1).Reverse()) + "\\";
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
        private void NotifyIcon_osuEscape_MouseDoubleClick(object sender, MouseEventArgs e)
        {            
            this.WindowState = FormWindowState.Normal;
            ToggleSystemTray(false);

            // Re-enable Hotkey
            GlobalHotkeyRegister();
        }

        private void GlobalHotkeyRegister()
        {
            if (ghk.Register() == true)
                ghk.Unregiser();

            ghk = new KeyHandler(Keys.F6, this);
            ghk.Register();
        }

        private void CheckBox_startUp_CheckedChanged(object sender, EventArgs e)
        {        
            SetRunAtStartup(checkBox_startUp.Checked);

            Properties.Settings.Default.isStartUp = checkBox_startUp.Checked;
        }

        private void CheckBox_toggleSound_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isToggleSound = checkBox_toggleSound.Checked;
        }

        private void CheckBox_systemTray_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isSystemTray = checkBox_systemTray.Checked;
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

        private void Button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            if (checkBox_systemTray.Checked)
            {
                ToggleSystemTray(checkBox_systemTray.Checked);
                ContextMenuStripUpdate();
            }

            GlobalHotkeyRegister();
        }

        private void ToggleSystemTray(bool enabled)
        {
            notifyIcon_osuEscape.Visible = enabled;
            this.ShowInTaskbar = !enabled;
        }

        private void CheckBox_topMost_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTopMost = checkBox_topMost.Checked;
            this.TopMost = checkBox_topMost.Checked;                
        }

        private void Button_reOpenOsu_Click(object sender, EventArgs e)
        {
            // kill the process, then re-open osu! using cmd command line
            Process[] prs = Process.GetProcesses();

            foreach (Process process in prs)
            {
                if (process.ProcessName == "osu!")
                {
                    process.Kill();
                    textBox_toggleOsu.Text = "Closed!";
                    break;
                }
            }

            // allow connection to avoid no login
            toggle = -1;
            ChangeConnection(true);

            // stop for 3s in order to let osu database save
            Thread.Sleep(3000);

            // start osu! process
            Process.Start(Properties.Settings.Default.osuLocation);

            textBox_toggleOsu.Text = "Opening osu!...";

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
            if (this.textBox_toggleOsu.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox_toggleOsu.Text = text;
            }
        }

        //private void CloseOsuButton_Click(object sender, EventArgs e)
        //{
        //    if (Process.GetProcessesByName("osu!").Count() == 0)
        //        textBox_toggleOsu.Text = "You have not opened any osu!";
        //    else
        //    {
        //        Process[] prs = Process.GetProcesses();

        //        foreach (Process process in prs)
        //        {
        //            if (process.ProcessName == "osu!")
        //            {
        //                process.Kill();
        //                textBox_toggleOsu.Text = "Closed!";
        //                break;
        //            }
        //        }
        //    }
        //}

        private void Button_showData_Click(object sender, EventArgs e)
        {
            OsuMemoryDataProviderTester.OsuMemoryDataProviderForm form = new OsuMemoryDataProviderTester.OsuMemoryDataProviderForm(_osuWindowTitleHint);
            form.Show();
        }
    }
}