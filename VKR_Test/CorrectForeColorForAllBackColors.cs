using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace VKR_Test
{
    static class CorrectForeColorForAllBackColors
    {
        public static Color GetForeColorForThisSituation(Color color, bool standardColorIsBlack)
        {
            List<int> colorcomponents = new List<int> { color.R, color.G, color.B };
            if (standardColorIsBlack)
            {
                if (colorcomponents.Max() <= 60)
                {
                    return Color.WhiteSmoke;
                }
                else
                {
                    return Color.Black;
                }
            }
            else
            {
                if (colorcomponents.Min() >= 195)
                {
                    return Color.Black;
                }
                else
                {
                    return Color.White;
                }
            }
        }
    }
}