using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    public static class ControlValidator
    {
        public static void TextBoxValidating(Control control, System.ComponentModel.CancelEventArgs e)
        {
            var text = control.Text.Trim();

            if (string.IsNullOrWhiteSpace(text) || text.Any(char.IsDigit))
            {
                control.BackColor = Color.DarkRed;
                e.Cancel = true;
            }
            else
            {
                control.BackColor = Color.WhiteSmoke;
                e.Cancel = false;
            }
        }
    }
}
