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

namespace osuEscape
{
    public partial class Form1 : Form


    {

        private string osuLocation = null; //config needs to be used

        private int toggle = 1; //1: Block Firewall; -1: Allow Firewall

        public const int WM_HOTKEY_MSG_ID = 0x0312;

        //Global Hotkey
        private KeyHandler ghk; 


        public Form1()
        {
            InitializeComponent();

            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);

            ghk = new KeyHandler(Keys.F6, this);
            ghk.Register();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "netsh";
            cmd.StartInfo.Arguments =
                "advfirewall firewall set rule name=\"osu block\" new enable=yes";
            cmd.StartInfo.Verb = "runas";
            cmd.Start();
            textBox3.Text = "Status: Blocked";
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "netsh";
            cmd.StartInfo.Arguments =
                "advfirewall firewall set rule name=\"osu block\" new enable=no";
            cmd.StartInfo.Verb = "runas";
            cmd.Start();
            textBox3.Text = "Status: Connecting";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (ofd.FileName.Contains("osu!.exe"))
                {
                    textBox1.Text = "lol you got hacked gn";
                    osuLocation = ofd.FileName;
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = "netsh";
                    cmd.StartInfo.Verb = "runas";
                    cmd.StartInfo.Arguments =
                        "advfirewall firewall delete rule name=\"osu block\"";
                    cmd.Start();
                    cmd.StartInfo.Arguments =
                        "advfirewall firewall add rule name=\"osu block\" dir=out action=block program=" + ofd.FileName;
                    cmd.Start();
                }
                else
                {
                    MessageBox.Show("This is not osu! dumbass");
                }
            }
        }

        private void ToggleFirewall()
        {
            if (toggle == 1)
            {
                button1.PerformClick();
                toggle *= -1;
            }
            else
            {
                button2.PerformClick();
                toggle *= -1;
            }
        }

        /*
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control && String.Equals(ghk.ToString(),Key))
            if (e.Control && String.Equals("S", Key))
            {                
                ToggleFirewall();
            }
        }
        */

        private void Form1_Load_1(object sender, EventArgs e)
        {

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
            Process bProcess = Process.GetProcessesByName("osu").FirstOrDefault();
            ToggleFirewall();                    
            BringMainWindowToFront("1");
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

        public void BringMainWindowToFront(string processName)
        {
            // get the process
            Process[] localAll = Process.GetProcesses();
            //Process bProcess = Process.GetProcessesByName("osu").FirstOrDefault();
            Process bProcess = Process.GetProcessesByName("chrome").First();
            textBox1.Text = bProcess.ProcessName;

            // check if the process is running
            if (bProcess != null)
            {
                // check if the window is hidden / minimized
                if (bProcess.MainWindowHandle == IntPtr.Zero)
                {
                    // the window is hidden so try to restore it before setting focus.
                    ShowWindow(bProcess.Handle, ShowWindowEnum.ShowMaximized);
                }

                // set user the focus to the window
                SetForegroundWindow(bProcess.MainWindowHandle);
            }
            else
            {
                // the process is not running, so start it
                Process.Start(processName);
            }
        }
    }


}
