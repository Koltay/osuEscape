using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;

namespace osuEscape
{
    public class Firewall
    {        
        private static void AllowConnection(bool isAllow)
        {
            Process cmd = new();
            cmd.StartInfo.FileName = "netsh";
            cmd.StartInfo.Verb = "runas";
            cmd.StartInfo.Arguments =
                  @"advfirewall firewall set rule name=""osu block"" new enable=" + (isAllow ? "no" : "yes");
            cmd.StartInfo.UseShellExecute = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.Start();
        }
        public static void Toggle()
        {
            if (Properties.Settings.Default.osuLocation == "")
            {
                MainFunction.ShowMessageBox("ERROR: Invalid Location!");
            }
            else
            {
                AllowConnection(Properties.Settings.Default.isAllowConnection);

                Audio.ToggleSound(Properties.Settings.Default.isToggleSound);
            }

            ((Root)Application.OpenForms[0]).ContextMenuStripUpdate();

            FormStyleManager.ColorSchemeUpdate((MaterialForm)Application.OpenForms[0]);

            FormStyleManager.Refresh();
        }

        async public static void RuleSetUp(string filename)
        {
            await Task.Run(async () =>
            {
                // create cmd
                Process cmd = new();
                cmd.StartInfo.FileName = "netsh";
                cmd.StartInfo.Verb = "runas";
                cmd.StartInfo.UseShellExecute = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                // firstly, delete the rules if the users used this application before
                cmd.StartInfo.Arguments =
                    "advfirewall firewall delete rule name=\"osu block\"";
                cmd.Start();

                await Task.Delay(500);

                // then, add blocking rule into the advanced firewall 
                cmd.StartInfo.Arguments =
                    "advfirewall firewall add rule name=\"osu block\" dir=out action=block program=" + filename;
                cmd.Start();

                await Task.Delay(500);

                Debug.WriteLine("Connection status: " + Properties.Settings.Default.isAllowConnection);

                Toggle();
            });
        }
    }
}
