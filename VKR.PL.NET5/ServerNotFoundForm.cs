using System;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    public partial class ServerNotFoundForm : Form
    {
        public ServerNotFoundForm() => InitializeComponent();

        private void btnDeployingAccepted_Click(object sender, EventArgs e)
        {
            Visible = false;
            using var form = new NewConnectionForm();
            form.ShowDialog();
        }

        private void btnDeployingDenied_Click(object sender, EventArgs e) => Application.Exit();

        private void ServerNotFoundForm_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();
    }
}