using System;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    public partial class ExitForm : Form
    {
        public ExitForm() => InitializeComponent();

        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}