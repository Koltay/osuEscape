using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuEscape
{
    class KV
    {
        public int key { get; set; }
        public int value { get; set; }
        public KV(int k, int v)
        {
            key = k;
            value = v;
        }
    }
}
