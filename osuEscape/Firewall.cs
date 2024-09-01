using MaterialSkin.Controls;
using NetFwTypeLib;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osuEscape
{
    public class Firewall
    {
        // Method to allow or block connection based on the isAllow flag
        private static void AllowConnection(bool isAllow)
        {
            ExecuteCommandLine(@$"advfirewall firewall set rule name=""osu block"" new enable={(isAllow ? "no" : "yes")}");
        }

        // Method to execute a command line instruction
        private static void ExecuteCommandLine(string line)
        {
            Process cmd = new()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "netsh",
                    Verb = "runas",
                    Arguments = line,
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            cmd.Start();
        }

        // Method to toggle firewall settings and update UI
        public static void ToggleFirewallSettings()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.osuLocation))
            {
                MainFunction.ShowMessageBox("ERROR: Invalid Location!");
                return;
            }

            AllowConnection(Properties.Settings.Default.isAllowConnection);
            Audio.ToggleSound(Properties.Settings.Default.isToggleSound);

            var mainForm = (MaterialForm)Application.OpenForms[0];
            ((Root)mainForm).ContextMenuStripUpdate();
            FormStyleManager.ColorSchemeUpdate(mainForm);
            FormStyleManager.Refresh();
        }

        // Method to set up firewall rules asynchronously
        public static async Task RuleSetUp(string filename)
        {
            await Task.Run(async () =>
            {
                // Remove existing "osu block" rules
                RemoveFirewallRules("osu block");

                await Task.Delay(500);

                // Create a new "osu block" rule
                CreateFirewallRule("osu block", filename);

                await Task.Delay(500);

                Debug.WriteLine("Connection status: " + Properties.Settings.Default.isAllowConnection);

                // Toggle firewall settings and update UI
                ToggleFirewallSettings();
            });
        }

        // Method to remove firewall rules by name
        public static void RemoveFirewallRules(string RuleName)
        {
            try
            {
                Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);

                foreach (INetFwRule rule in fwPolicy2.Rules)
                {
                    if (rule.Name.Contains(RuleName, StringComparison.CurrentCulture))
                    {
                        fwPolicy2.Rules.Remove(rule.Name);
                        Console.WriteLine(rule.Name + " has been deleted from Firewall Policy");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Error: Cannot delete the rule(s) from firewall: {ex.Message}");
            }
        }

        // Method to create a new firewall rule
        public static void CreateFirewallRule(string RuleName, string filename)
        {
            ExecuteCommandLine(@$"advfirewall firewall add rule name=""{RuleName}"" dir=out action=block program=""{filename}""");
        }
    }
}
