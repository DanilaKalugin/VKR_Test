using System;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    public partial class RostersMenuForm : Form
    {
        public RostersMenuForm() => InitializeComponent();

        private void btnCloseResultsMenu_Click(object sender, EventArgs e) => Close();

        private void btnLineups_Click(object sender, EventArgs e) => OpenLineupsForm(LineupsForm.RosterType.StartingLineups);

        private void btnReserves_Click(object sender, EventArgs e) => OpenLineupsForm(LineupsForm.RosterType.Reserves);

        private void button1_Click(object sender, EventArgs e) => OpenLineupsForm(LineupsForm.RosterType.FreeAgents);

        private void OpenLineupsForm(LineupsForm.RosterType rosterType)
        {
            Visible = false;
            using (var form = new LineupsForm(rosterType)) form.ShowDialog();
            Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Visible = false;
            using (var form = new ChangePlayerTeamForm()) form.ShowDialog();
            Visible = true;
        }
    }
}