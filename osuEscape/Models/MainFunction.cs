using System.Windows.Forms;

namespace osuEscape.Models;

public static class MainFunction
{
    public static DialogResult ShowMessageBox(string message, string caption = "Error", MessageBoxIcon icon = MessageBoxIcon.Error, MessageBoxButtons buttons = MessageBoxButtons.OK)
    {
        Audio.ToggleSound(Properties.Settings.Default.isToggleSound);
        return MessageBox.Show(message, caption, buttons, icon);
    }
    public static void InvokeFormRefresh()
    {
    }
}
