using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VKR.PL.Utils.NET5
{
    public static class ControlValidator
    {
        public static void ValidateComboBox(this ComboBox cb, CancelEventArgs e)
        {
            if (cb.SelectedValue is null)
            {
                cb.BackColor = Color.DarkRed;
                e.Cancel = true;
            }
            else
            {
                cb.BackColor = Color.WhiteSmoke;
                e.Cancel = false;
            }
        }
    }
}