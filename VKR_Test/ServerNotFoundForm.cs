using System;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class ServerNotFoundForm : Form
    {
        public ServerNotFoundForm() => InitializeComponent();

        private void btnDeployingAccepted_Click(object sender, EventArgs e)
        {
            var form = new NewConnectionForm();
            Visible = false;
            form.ShowDialog();
        }

        private void btnDeployingDenied_Click(object sender, EventArgs e) => Application.Exit();

        private void ServerNotFoundForm_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();
    }
}