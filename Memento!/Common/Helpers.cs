using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Memento_.Common
{
    public static class Helpers
    {
        public static Color GetRandColor()
        {
            var b = new byte[4];
            var rand = new Random();
            rand.NextBytes(b);


            return new Color() { R = b[0], G = b[1], B = b[2], A = b[3] };
        }
    }
}
