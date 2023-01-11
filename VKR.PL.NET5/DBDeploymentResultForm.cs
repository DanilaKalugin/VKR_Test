using System;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    public partial class DBDeploymentResultForm : Form
    {
        public DBDeploymentResultForm(bool isSuccessful, string message)
        {
            InitializeComponent();
            pbResult.Visible = !isSuccessful;
            lbMessage.Text = message;
        }

        private void btnOK_Click(object sender, EventArgs e) => Application.Exit();

        private void DBDeploymentResultForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = true;
    }
}