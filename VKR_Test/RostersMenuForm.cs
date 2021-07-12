using System;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class RostersMenuForm : Form
    {
        public RostersMenuForm()
        {
            InitializeComponent();
        }

        private void btnCloseResultsMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLineups_Click(object sender, EventArgs e)
        {
            LineupsForm form = new LineupsForm(LineupsForm.RosterType.StartingLineups);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private void btnReserves_Click(object sender, EventArgs e)
        {
            LineupsForm form = new LineupsForm(LineupsForm.RosterType.Reserves);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LineupsForm form = new LineupsForm(LineupsForm.RosterType.FreeAgents);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }
    }
}
