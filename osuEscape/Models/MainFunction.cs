using MaterialSkin.Controls;
using System.Windows.Forms;

namespace osuEscape.Models;

public static class MainFunction
{
    public static DialogResult ShowMessageBox(string message, string caption = "Error", MessageBoxIcon icon = MessageBoxIcon.Error, MessageBoxButtons buttons = MessageBoxButtons.OK)
    {
        // Replace the selected code block with a call to MainFunction.ToggleOsuConnectionSwitch()
        Audio.ToggleSound(Properties.Settings.Default.isToggleSound);
        return MessageBox.Show(message, caption, buttons, icon);
    }
    public static void InvokeFormRefresh()
    {
    }
    public static void ToggleOsuConnectionSwitch()
    {
        if (Application.OpenForms["MainForm"] is MainForm mainForm)
        {
            mainForm.Invoke(() =>
            {
                ((MaterialSwitch)mainForm.Controls["materialSwitch_osuConnection"]).Checked = !((MaterialSwitch)mainForm.Controls["materialSwitch_osuConnection"]).Checked;
            });
        }
    }
}
