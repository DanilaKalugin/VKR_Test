using System;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    public partial class ErrorForm : Form
    {
        public ErrorForm() => InitializeComponent();

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}