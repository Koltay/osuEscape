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

namespace osuEscape
{
    public partial class Form1 : Form


    {

        private int toggle = 1; //1: Block Firewall; -1: Allow Firewall
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "netsh";
            cmd.StartInfo.Arguments =
                "advfirewall firewall set rule name=\"osu block\" new enable=yes";
            cmd.StartInfo.Verb = "runas";
            cmd.Start();
            textBox1.Text = "Blocked! No more submission hehe";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "netsh";
            cmd.StartInfo.Arguments =
                "advfirewall firewall set rule name=\"osu block\" new enable=no";
            cmd.StartInfo.Verb = "runas";
            cmd.Start();
            textBox1.Text = "Done! You can now submit your score";
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void toggleFirewall()
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                toggleFirewall();
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
