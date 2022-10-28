using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VKR.PL.Utils.NET5
{
    public static class ControlValidator
    {
        public static void TextBoxValidating(Control? control, System.ComponentModel.CancelEventArgs e)
        {
            if (control is null) return;

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