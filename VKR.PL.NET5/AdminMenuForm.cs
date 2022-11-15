using System;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    public partial class AdminMenuForm : Form
    {
        public AdminMenuForm() => InitializeComponent();

        private void btnRostersAdminMenu_Click(object sender, EventArgs e) => OpenNewForm(new RostersMenuForm(true));

        private void btnAddPlayer_Click(object sender, EventArgs e) => OpenNewForm(new AddPlayerForm(true));

        private void btnAddCity_Click(object sender, EventArgs e) => OpenNewForm(new AddCityForm());

        private void btnEditTeam_Click(object sender, EventArgs e) => OpenNewForm(new TeamInformationForm(true));

        private void btnAddManager_Click(object sender, EventArgs e) => OpenNewForm(new AddManagerForm());

        private void addStadium_Click(object sender, EventArgs e) => OpenNewForm(new AddStadiumForm());

        private void OpenNewForm(Form form)
        {
            Visible = false;
            using (form)
                form.ShowDialog();

            Visible = true;
        }
    }
}