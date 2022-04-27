using System;
using System.Windows.Forms;

namespace VKR_Test
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
            using (var form = new LineupsForm(rosterType))
            {
                Visible = false;
                form.ShowDialog();
            }

            Visible = true;
        }
    }
}