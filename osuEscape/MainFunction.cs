using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osuEscape
{
    class MainFunction
    {
        public static void ShowMessageBox(string message)
        {
            Audio.ToggleSound(Properties.Settings.Default.isToggleSound);

            MessageBox.Show(message);
        }
        public static void Invoke_FormRefresh()
        {
            /*this.Invoke(new MethodInvoker(delegate ()
            {
                //Access your controls
                materialSwitch_osuConnection.Checked = !Properties.Settings.Default.isAllowConnection;

                this.Refresh();
            }));*/
        }
    }
}
