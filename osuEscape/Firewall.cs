using MaterialSkin.Controls;
using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osuEscape
{
    public class Firewall
    {
        private static void AllowConnection(bool isAllow)
        {
            ExecuteCommandLine(@$"advfirewall firewall set rule name=""osu block"" new enable={(isAllow ? "no" : "yes")}");
        }

        private static void ExecuteCommandLine(string line)
        {
            Process cmd = new();
            cmd.StartInfo.FileName = "netsh";
            cmd.StartInfo.Verb = "runas";
            cmd.StartInfo.Arguments = line;
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
                // 1. delete the previous rules of "osu block"
                // 2. add a new "osu block" rule
                RemoveFirewallRules("osu block");

                await Task.Delay(500);

                CreateFirewallRule("osu block", filename);

                await Task.Delay(500);

                Debug.WriteLine("Connection status: " + Properties.Settings.Default.isAllowConnection);

                Toggle();
            });
        }

        public static void RemoveFirewallRules(string RuleName)
        {
            try
            {
                Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
                var currentProfiles = fwPolicy2.CurrentProfileTypes;

                List<INetFwRule> RuleList = new();

                foreach (INetFwRule rule in fwPolicy2.Rules)
                {
                    if (rule.Name.Contains(RuleName, StringComparison.CurrentCulture))
                    {
                        // Now add the rule
                        INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                        firewallPolicy.Rules.Remove(rule.Name);
                        Console.WriteLine(rule.Name + " has been deleted from Firewall Policy");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Error: Cannot delete the rule(s) from firewall: {ex.Message}");
            }
        }

        public static void CreateFirewallRule(string RuleName, string filename)
        {
            ExecuteCommandLine(@$"advfirewall firewall add rule name=""{RuleName}"" dir=out action=block program=""{filename}""");
        }
    }
}
