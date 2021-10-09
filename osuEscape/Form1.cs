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
        private int toggle = 1; //1: Block Firewall; -1: Allow Firewall
        private string Key = "S";
        public const int WM_HOTKEY_MSG_ID = 0x0312;

        //Global Hotkeys
        private KeyHandler ghk; 
        private KeyHandler ghk2;


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
            ToggleFirewall();
        }
    }


}
