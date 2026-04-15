using MaterialSkin.Controls;
using NetFwTypeLib;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osuEscape.Models
{
    public class Firewall
    {
        // Method to allow or block connection based on the isAllow flag
        private static Task AllowConnectionAsync(bool isAllow)
        {
            return ExecuteCommandLineAsync(@$"advfirewall firewall set rule name=""osu block"" new enable={(isAllow ? "no" : "yes")}");
        }

        // Method to execute a command line instruction
        private static async Task ExecuteCommandLineAsync(string line)
        {
            using Process cmd = new()
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

            if (!cmd.Start())
            {
                throw new InvalidOperationException("Failed to start netsh.");
            }

            await cmd.WaitForExitAsync().ConfigureAwait(false);

            if (cmd.ExitCode != 0)
            {
                throw new InvalidOperationException($"Firewall command failed with exit code {cmd.ExitCode}.");
            }
        }

        // Method to toggle firewall settings and update UI
        public static async Task ToggleFirewallSettingsAsync()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.osuLocation))
            {
                MainFunction.ShowMessageBox("ERROR: Invalid Location!");
                return;
            }

            await AllowConnectionAsync(Properties.Settings.Default.isAllowConnection).ConfigureAwait(false);
            Audio.ToggleSound(Properties.Settings.Default.isToggleSound);
            Debug.WriteLine("Toggle Firewall; Connection status: " + Properties.Settings.Default.isAllowConnection);
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
            ExecuteCommandLineAsync(@$"advfirewall firewall add rule name=""{RuleName}"" dir=out action=block program=""{filename}""").GetAwaiter().GetResult();
        }
        public static async Task SetUpFirewallRulesAsync(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename) || !File.Exists(filename))
            {
                throw new FileNotFoundException("Could not locate osu!.exe.", filename);
            }

            RemoveFirewallRules("osu block");
            await ExecuteCommandLineAsync(@$"advfirewall firewall add rule name=""osu block"" dir=out action=block program=""{filename}""").ConfigureAwait(false);

            Debug.WriteLine("Setup Firewall; Connection status: " + Properties.Settings.Default.isAllowConnection);

            // Reference MainForm's osu connection switch and toggle its checked status
            MainFunction.ToggleOsuConnectionSwitch();
        }
    }
}
