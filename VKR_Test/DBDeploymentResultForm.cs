using System;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class DBDeploymentResultForm : Form
    {
        public DBDeploymentResultForm(bool IsSuccessful, string message)
        {
            InitializeComponent();
            pbResult.Visible = !IsSuccessful;
            lbMessage.Text = message;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DBDeploymentResultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}