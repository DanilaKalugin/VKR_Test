using System;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    public partial class RostersMenuForm : Form
    {
        private bool _isAdMin;
        public RostersMenuForm(bool b)
        {
            _isAdMin = b;
            InitializeComponent();
            button2.Visible = _isAdMin;
        }

        private void btnCloseResultsMenu_Click(object sender, EventArgs e) => Close();

        private void btnLineups_Click(object sender, EventArgs e) => OpenLineupsForm(LineupsForm.RosterType.StartingLineups);

        private void btnReserves_Click(object sender, EventArgs e) => OpenLineupsForm(LineupsForm.RosterType.Reserves);

        private void button1_Click(object sender, EventArgs e) => OpenLineupsForm(LineupsForm.RosterType.FreeAgents);

        private void OpenLineupsForm(LineupsForm.RosterType rosterType)
        {
            Visible = false;
            using (var form = new LineupsForm(rosterType, _isAdMin)) 
                form.ShowDialog();
            Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Visible = false;
            using (var form = new ChangePlayerTeamForm()) 
                form.ShowDialog();
            Visible = true;
        }
    }
}