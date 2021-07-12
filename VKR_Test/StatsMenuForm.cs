using System;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class StatsMenuForm : Form
    {
        public StatsMenuForm()
        {
            InitializeComponent();
        }

        private void btnPlayersStats_Click(object sender, EventArgs e)
        {
            OpenStats(PlayerStatsForm.SortingObjects.Players);
        }

        private void btnTeamsStats_Click(object sender, EventArgs e)
        {
            OpenStats(PlayerStatsForm.SortingObjects.Teams);
        }

        private void OpenStats(PlayerStatsForm.SortingObjects objects)
        {
            PlayerStatsForm form = new PlayerStatsForm(objects);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private void btnCloseResultsMenu_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
