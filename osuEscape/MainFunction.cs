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
                this.Refresh();
            }));*/
        }
    }
}
