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
        InputSimulator sim = new InputSimulator();

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

            /*
            Process[] localByName = System.Diagnostics.Process.GetProcessesByName("osu!");
            if(localByName.Length == 1)
            {
                Process osu = localByName[0];
                BringProcessToFront(osu);
            }*/
        }
        public static void BringProcessToFront(Process process)
        {
            IntPtr handle = process.MainWindowHandle;
            SetForegroundWindow(handle);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "netsh";
            cmd.StartInfo.Arguments =
                "advfirewall firewall set rule name=\"osu block\" new enable=yes";
            cmd.StartInfo.Verb = "runas";
            cmd.Start();
            textBox3.Text = "Blocked";
            textBox3.ForeColor = Color.Red;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "netsh";
            cmd.StartInfo.Arguments =
                "advfirewall firewall set rule name=\"osu block\" new enable=no";
            cmd.StartInfo.Verb = "runas";
            cmd.Start();
            textBox3.Text = "Connecting";
            textBox3.ForeColor = Color.Green;
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
            //1: Block Firewall; -1: Allow Firewall
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
            ToggleFirewall();

            this.TopMost = true;

            if (checkBox1.Checked)
                AltTab(); 
            else
                BringMainWindowToFront();
             
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
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {        

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }


}
