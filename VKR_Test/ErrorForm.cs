using System;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class ErrorForm : Form
    {
        public ErrorForm() => InitializeComponent();

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}