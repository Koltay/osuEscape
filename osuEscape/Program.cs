using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace osuEscape
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using Mutex singleInstanceMutex = new(true, @"Local\osuEscape", out bool createdNew);
            if (!createdNew)
            {
                MessageBox.Show("osu! Escape is already running.", "osu! Escape", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (_, exceptionArgs) =>
                MessageBox.Show(exceptionArgs.Exception.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            AppDomain.CurrentDomain.UnhandledException += (_, exceptionArgs) =>
            {
                if (exceptionArgs.ExceptionObject is Exception exception)
                {
                    MessageBox.Show(exception.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            Application.Run(new Root(args.FirstOrDefault()));
        }
    }
}
