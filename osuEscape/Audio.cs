using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuEscape
{
    class Audio
    {
        public static void ToggleSound(bool enabled)
        {
            if (enabled)
            {
                System.Media.SystemSounds.Asterisk.Play();
            }
                
        }
    }
}
