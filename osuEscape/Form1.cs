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

namespace osuEscape
{
    public partial class Form1 : Form


    {
        readonly InputSimulator sim = new InputSimulator();

        private int toggle = 1; //1: Block Firewall; -1: Allow Firewall

        public const int WM_HOTKEY_MSG_ID = 0x0312;

        //Global Hotkey
        private readonly KeyHandler ghk;


        public Form1()
        {
            InitializeComponent();

            ghk = new KeyHandler(Keys.F6, this);
            ghk.Register();

        }
        public static void BringProcessToFront(Process process)
        {
            IntPtr handle = process.MainWindowHandle;
            SetForegroundWindow(handle);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BlockConnection();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            AllowConnection();            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RuleResetAndSetUp(ofd.FileName);
            }
            else
            {
                MessageBox.Show("This is not osu! dumbass");
            }
        }

        private void ToggleFirewall()
        {
            //1: Block Firewall; -1: Allow Firewall
            if (toggle == 1)
            {
                BlockConnection();
                toggle *= -1;
            }
            else
            {
                AllowConnection();
                toggle *= -1;
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            checkBox1.Visible = false;
            // check if user is playing osu!, then get the directory

            string str = string.Empty;
            if (Process.GetProcessesByName("osu!").Count() != 0)
                str = Process.GetProcessesByName("osu!").FirstOrDefault().MainModule.FileName;

            if (str.Contains("osu!"))
            {
                Properties.Settings.Default.osuLocation = Process.GetProcessesByName("osu!").FirstOrDefault().MainModule.FileName;
                Properties.Settings.Default.Save();

                RuleResetAndSetUp(Properties.Settings.Default.osuLocation);

                //textBox4.Text = "not normal";
            }
            else
            {
                // if there is no user settings saved, initialize it
                if (!Properties.Settings.Default.osuLocation.Contains("osu!"))
                {
                    button3.PerformClick();
                }
                else
                {                
                    RuleResetAndSetUp(Properties.Settings.Default.osuLocation);

                    //textBox4.Text = "normal";
                }
            }            
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

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

            //this.TopMost = true;

            /*
            if (checkBox1.Checked)
                AltTab(); 
            else
                BringMainWindowToFront(); 
            */
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        private enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
            Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
            Restore = 9, ShowDefault = 10, ForceMinimized = 11
        };
       
        /*
        private void BringMainWindowToFront()
        {
            // get the process
            Process bProcess = System.Diagnostics.Process.GetProcessesByName("osu!").FirstOrDefault();

            // check if the process is running
            if (bProcess != null)
            { 
                
                // check if the window is hidden / minimized
                if (bProcess.MainWindowHandle == IntPtr.Zero)
                {
                    // the window is hidden so try to restore it before setting focus.
                    ShowWindow(bProcess.Handle, ShowWindowEnum.ShowNormal);
                }

                // set user the focus to the window
                SetForegroundWindow(bProcess.MainWindowHandle);
            }
        }

        private void AltTab()
        {
            //reset keypress
            sim.Keyboard.KeyPress(VirtualKeyCode.RMENU);
            sim.Keyboard.Sleep(50);
            sim.Keyboard.KeyPress(VirtualKeyCode.TAB);
            sim.Keyboard.Sleep(50);

            sim.Keyboard.Sleep(100);

            sim.Keyboard.KeyDown(VirtualKeyCode.RMENU);
            sim.Keyboard.KeyDown(VirtualKeyCode.TAB);
            sim.Keyboard.Sleep(100);
            sim.Keyboard.KeyUp(VirtualKeyCode.RMENU);
            sim.Keyboard.KeyUp(VirtualKeyCode.TAB);
            sim.Keyboard.Sleep(10);

            sim.Keyboard.KeyDown(VirtualKeyCode.RMENU);
            sim.Keyboard.KeyDown(VirtualKeyCode.TAB);
            sim.Keyboard.Sleep(100);
            sim.Keyboard.KeyUp(VirtualKeyCode.RMENU);
            sim.Keyboard.KeyUp(VirtualKeyCode.TAB);
            sim.Keyboard.Sleep(10);

        }
        */

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {        

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BlockConnection()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "netsh";
            cmd.StartInfo.Arguments =
                "advfirewall firewall set rule name=\"osu block\" new enable=yes";
            cmd.StartInfo.Verb = "runas";
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.Start();
            textBox3.Text = "Blocked";
            textBox3.ForeColor = Color.Red;
        }

        private void AllowConnection()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "netsh";
            cmd.StartInfo.Arguments =
                "advfirewall firewall set rule name=\"osu block\" new enable=no";
            cmd.StartInfo.Verb = "runas";
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.Start();
            textBox3.Text = "Connecting";
            textBox3.ForeColor = Color.Green;
        }

        private void RuleResetAndSetUp(string filename)
        {
            if (filename.Contains("osu!.exe"))
            {
                textBox1.Text = "lol you got hacked gn";
                Properties.Settings.Default.osuLocation = filename;
                Properties.Settings.Default.Save();
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

                textBox3.Text = "Connecting";
                textBox3.ForeColor = Color.Green;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }


}
