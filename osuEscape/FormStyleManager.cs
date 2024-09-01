using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace osuEscape
{
    class FormStyleManager
    {
        // Singleton instance of MaterialSkinManager
        private static readonly MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        // Method to add a form to be managed by MaterialSkinManager
        public static void AddFormToManage(MaterialForm form)
        {
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(form);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        }

        // Method to update the color scheme of the MaterialSkinManager
        public static void ColorSchemeUpdate(MaterialForm form)
        {
            form.Invoke(new MethodInvoker(() =>
            {
                materialSkinManager.ColorScheme = Properties.Settings.Default.isAllowConnection
                    ? new ColorScheme(
                        Primary.Grey800,
                        Primary.Grey900,
                        Primary.Grey500,
                        Accent.Green700,
                        TextShade.WHITE)
                    : new ColorScheme(
                        Primary.Grey800,
                        Primary.Grey900,
                        Primary.Grey500,
                        Accent.Red400,
                        TextShade.WHITE);
            }));
        }

        // Method to refresh all open forms
        public static void Refresh()
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Invoke(new MethodInvoker(form.Refresh));
            }
        }
    }
}
