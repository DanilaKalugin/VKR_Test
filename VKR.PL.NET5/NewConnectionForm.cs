using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.PL.DBHelper;

namespace VKR.PL.NET5
{
    public partial class NewConnectionForm : Form
    {
        private readonly NewConnectionBL _newConnectionBL = new();

        public NewConnectionForm() => InitializeComponent();

        private void cb_IntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = !cb_IntegratedSecurity.Checked;
            txtLogin.Clear();
            txtPassword.Clear();
        }

        private void txtLogin_Validating(object sender, CancelEventArgs e)
        {
            if (!cb_IntegratedSecurity.Checked) txt_Validating(txtLogin, e, ServerLoginErrorText, "Login");
        }


        private void txt_Validating(Control txt, CancelEventArgs e, Control l, string header)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.BackColor = Color.DarkRed;
                e.Cancel = true;
                l.Text = $"Field \"{header}\" cannot be empty";
                l.ForeColor = Color.Red;
            }
            else
            {
                txt.BackColor = Color.FromArgb(40, 40, 40);
                e.Cancel = false;
                l.Text = "";
                l.ForeColor = Color.Green;
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!cb_IntegratedSecurity.Checked) txt_Validating(txtPassword, e, ServerPasswordErrorText, "Password");
        }

        private void cb_Servers_TextChanged(object sender, EventArgs e) => lbConnectionStringTitle.Text = $"{cb_Servers.Text.Replace("\u005c", "_").ToLower()}ConnectionString";

        private void NewConnectionForm_Load(object sender, EventArgs e) => cb_Servers.DataSource = ServersHelper.GetAvailableServers();

        private void btnDeployBaseOnNewServer_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) return;

            int result;
            string message;
            if (!cb_IntegratedSecurity.Checked) 
                _newConnectionBL.DeployDatabase(lbConnectionStringTitle.Text, cb_Servers.Text, cb_IntegratedSecurity.Checked, out result, out message);
            else _newConnectionBL.DeployDatabase(lbConnectionStringTitle.Text, cb_Servers.Text, cb_IntegratedSecurity.Checked, out result, out message, txtLogin.Text, txtPassword.Text);
            var deploymentResult = result == 0;

            using var form = new DBDeploymentResultForm(deploymentResult, message);
            Visible = false;
            form.ShowDialog();
        }

        private void NewConnectionForm_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();
    }
}