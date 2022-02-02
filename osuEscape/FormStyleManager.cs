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
        }
    }
}
