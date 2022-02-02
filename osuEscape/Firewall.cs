using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace osuEscape
{
    class Firewall
    {
        public static void AllowConnection(bool isAllow)
        {
            Process cmd = new();
            cmd.StartInfo.FileName = "netsh";
            cmd.StartInfo.Arguments =
                  @"advfirewall firewall set rule name=""osu block"" new enable=" + (isAllow ? "no" : "yes");
            cmd.StartInfo.Verb = "runas";
            cmd.StartInfo.UseShellExecute = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.Start();
        }

        public static void ToggleFirewall()
        {
            if (Properties.Settings.Default.osuLocation == "")
            {
                MainFunction.ShowMessageBox("ERROR: Invalid Location!");
            }
            else
            {
                AllowConnection(Properties.Settings.Default.isAllowConnection);

                Audio.ToggleSound(Properties.Settings.Default.isToggleSound);

                /*Invoke_FormRefresh();*/
            }
        }

        async public static void RuleSetUp(string filename)
        {
            await Task.Run(async () =>
            {
                if (filename.Contains("osu!.exe"))
                {


                    Properties.Settings.Default.osuLocation = filename;

                    // UpdateOsuLocationText
                    // osuPath: osuLocation without osu.exe at the end
                    string osuPath = String.Join("\\", Properties.Settings.Default.osuLocation.Split('\\').Reverse().Skip(1).Reverse()) + "\\";
                    Properties.Settings.Default.osuPath = osuPath;

                    /*materialLabel_osuPath.Invoke(new MethodInvoker(delegate
                    {
                        materialLabel_osuPath.Text = "osu! Path: " + osuPath;
                    }));*/

                    // create cmd
                    Process cmd = new();
                    cmd.StartInfo.FileName = "netsh";
                    cmd.StartInfo.Verb = "runas";
                    cmd.StartInfo.UseShellExecute = true;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    // delete the rules if the users used this application before
                    cmd.StartInfo.Arguments =
                        "advfirewall firewall delete rule name=\"osu block\"";
                    cmd.Start();

                    await Task.Delay(500);

                    // add blocking rule into advanced firewall 
                    cmd.StartInfo.Arguments =
                        "advfirewall firewall add rule name=\"osu block\" dir=out action=block program=" + filename;
                    cmd.Start();

                    await Task.Delay(500);

                    Debug.WriteLine("Connection status: " + Properties.Settings.Default.isAllowConnection);
                }
            });
        }
    }
}
