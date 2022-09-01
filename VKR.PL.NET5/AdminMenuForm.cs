using System;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    public partial class AdminMenuForm : Form
    {
        public AdminMenuForm() => InitializeComponent();

        private void btnRostersAdminMenu_Click(object sender, EventArgs e)
        {
            Visible = false;
            using (var form = new RostersMenuForm(true))
                form.ShowDialog();

            Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            Visible = false;
            using (var form = new AddPlayerForm(true))
                form.ShowDialog();

            Visible = true;
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            Visible = false;
            using (var form = new AddCityForm())
                form.ShowDialog();

            Visible = true;
        }
    }
}