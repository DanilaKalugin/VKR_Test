using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class NewConnectionForm : Form
    {
        private readonly NewConnectionBL newConnectionBL;
        public NewConnectionForm()
        {
            InitializeComponent();
            newConnectionBL = new NewConnectionBL();
        }

        private void cb_IntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = !cb_IntegratedSecurity.Checked;
            txtLogin.Clear();
            txtPassword.Clear();
        }

        private void txtLogin_Validating(object sender, CancelEventArgs e)
        {
            if (!cb_IntegratedSecurity.Checked)
            {
                txt_Validating(txtLogin, e, ServerLoginErrorText, "Login");
            }
        }


        private void txt_Validating(TextBox txt, CancelEventArgs e, Label l, string header)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.BackColor = Color.DarkRed;
                e.Cancel = true;
                l.Text = "Field \"" + header + "\" cannot be empty";
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
            if (!cb_IntegratedSecurity.Checked)
            {
                txt_Validating(txtPassword, e, ServerPasswordErrorText, "Password");
            }
        }

        private void cb_Servers_TextChanged(object sender, EventArgs e)
        {
            lbConnectionStringTitle.Text = cb_Servers.Text.Replace("\u005c", "_").ToLower() + "ConnectionString";
        }

        private void NewConnectionForm_Load(object sender, EventArgs e)
        {
            DataTable table = SqlDataSourceEnumerator.Instance.GetDataSources();
            List<string> servers = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                servers.Add(row[table.Columns[0]] + @"\" + row[table.Columns[1]]);
            }
            cb_Servers.DataSource = servers;
        }

        private void btnDeployBaseOnNewServer_Click(object sender, EventArgs e)
        {
            int result;
            string message;
            if (ValidateChildren())
            {
                if (!cb_IntegratedSecurity.Checked)
                {
                    newConnectionBL.DeployDatabase(lbConnectionStringTitle.Text, cb_Servers.Text, cb_IntegratedSecurity.Checked, out result, out message);
                }
                else
                {
                    newConnectionBL.DeployDatabase(lbConnectionStringTitle.Text, cb_Servers.Text, cb_IntegratedSecurity.Checked, out result, out message, txtLogin.Text, txtPassword.Text);
                }
                bool DeploymentResult = result == 0;
                DBDeploymentResultForm form = new DBDeploymentResultForm(DeploymentResult, message);
                Visible = false;
                form.ShowDialog();
            }
        }

        private void NewConnectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
