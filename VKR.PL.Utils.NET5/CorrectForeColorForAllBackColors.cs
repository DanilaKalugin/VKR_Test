using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace VKR.PL.Utils.NET5
{
    public static class CorrectForeColorForAllBackColors
    {
        public static Color GetForeColorForThisSituation(Color color, bool standardColorIsBlack)
        {
            var colorComponents = new List<int> { color.R, color.G, color.B };

            if (standardColorIsBlack)
                return colorComponents.Max() <= 60 ? Color.WhiteSmoke : Color.Black;

            return colorComponents.Min() >= 195 ? Color.Black : Color.White;
        }

        public static Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            var r = (double)color.R;
            var g = (double)color.G;
            var b = (double)color.B;

            if (correctionFactor >= 0)
            {
                r = (byte)((255 - r) * correctionFactor + r);
                g = (byte)((255 - g) * correctionFactor + g);
                b = (byte)((255 - b) * correctionFactor + b);
            }
            else
            {
                correctionFactor = 1 + correctionFactor;
                r *= correctionFactor;
                g *= correctionFactor;
                b *= correctionFactor;
            }

            return Color.FromArgb((byte)r, (byte)g, (byte)b);
        }
    }
}