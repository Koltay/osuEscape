using System;
using System.Linq;
using System.Windows.Forms;

namespace osuEscape
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Root(args.FirstOrDefault()));
        }
    }
}
