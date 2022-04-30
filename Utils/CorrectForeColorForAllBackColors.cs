using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace VKR.PL.Utils
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
    }
}