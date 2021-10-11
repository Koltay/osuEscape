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

namespace osuEscape
{
    public partial class Form1 : Form
    {
        //readonly InputSimulator sim = new InputSimulator();

        private int toggle = -1; //1: Allow Firewall; -1: Block Firewall

        public const int WM_HOTKEY_MSG_ID = 0x0312;

        private bool isLocationExist = false;

        //Global Hotkey
        private readonly KeyHandler ghk;


        public Form1()
        {
            InitializeComponent();

            ghk = new KeyHandler(Keys.F6, this);
            ghk.Register();
        }

        private void Button3_Click(object sender, EventArgs e) // select osu!.exe
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.Contains("osu!"))
                {
                    RuleResetAndSetUp(ofd.FileName);
                }
                else
                {
                    MessageBox.Show("You need to rename the osu to osu!.exe");
                }
            }
        }

        private void ToggleFirewall()
        {
            ChangeConnection(toggle == 1); // isAllow
            toggle *= -1; // Check declaration
        }

        private string getOsuPath ()
        {
            return (Process.GetProcessesByName("osu!").Count() == 0 ? "" : Process.GetProcessesByName("osu!").FirstOrDefault().MainModule.FileName);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // check if user is playing osu!, then get the directory

            string str = getOsuPath(); // when you already execute osu!.exe

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
                    button3.PerformClick(); // trigger select folder function since there is no any record
                }
            }
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

            button4.Text = isAllow ? "Connecting" : "Blocked";
            button4.ForeColor = isAllow ? Color.Green : Color.Red;
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

                /* rewrite attempt
                Process p = new Process();
                ProcessStartInfo info = new ProcessStartInfo("cmd.exe");
                info.RedirectStandardInput = true;
                info.UseShellExecute = false;
                info.Verb = "runas";
                info.CreateNoWindow = false;
                info.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo = info;
                p.Start();

                using (StreamWriter sw = p.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        // reset the rules if the users used this application before
                        sw.WriteLine("netsh advfirewall firewall delete rule name=\"osu block\"");

                        // add rule to advfirewall
                        sw.WriteLine("netsh advfirewall firewall add rule name=\"osu block\" dir=out action=block program=" + filename);

                        // disable at first to avoid unneeded disconnection
                        sw.WriteLine("netsh advfirewall firewall set rule name=\"osu block\" new enable=no");

                        textBox1.Text = "working";
                    }
                }
                */

                button4.Text = "Connecting";
                button4.ForeColor = Color.Green;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
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
            textBox6.Text = "osu! Path: " + String.Join("\\", Properties.Settings.Default.osuLocation.Split('\\').Reverse().Skip(1).Reverse()) + "\\";
        }
    }
}