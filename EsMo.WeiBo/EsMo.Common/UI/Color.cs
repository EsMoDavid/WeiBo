using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Common.UI
{
    public class Color
    {
        public byte A { get; set; } = 255;
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public Color()
        {

        }
        public Color(byte r,byte g,byte b, byte a=255)
        {
            this.A = a;
            this.R = r;
            this.G = g;
            this.B = b;
        }
    }
}
