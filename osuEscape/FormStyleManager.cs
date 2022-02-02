using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace osuEscape
{
    class FormStyleManager
    {
        public static MaterialSkinManager materialSkinManager;
        public static void AddFormToManage (MaterialForm f)
        {
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(f);
            materialSkinManager.ColorScheme = Properties.Settings.Default.isAllowConnection ?
            new ColorScheme(
                    Primary.Grey800,
                    Primary.Grey900,
                    Primary.Grey500,
                    Accent.Green700,
                    TextShade.WHITE)
            :
            new ColorScheme(
                    Primary.Grey800,
                    Primary.Grey900,
                    Primary.Grey500,
                    Accent.Red400,
                    TextShade.WHITE);
        }
    }
}
