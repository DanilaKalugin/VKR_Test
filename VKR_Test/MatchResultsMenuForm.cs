using System;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class MatchResultsMenuForm : Form
    {
        private readonly MatchBL _matchBL;

        public MatchResultsMenuForm()
        {
            InitializeComponent();
            _matchBL = new MatchBL();
        }

        private void btnResultsByDate_Click(object sender, EventArgs e)
        {
            var form = new MatchResultsForm(_matchBL.GetMaxDateForAllMatches(), false, MatchResultsForm.TableType.Results);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            var form = new MatchResultsForm(MatchResultsForm.TableType.Results);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private void btnCloseResultsMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnScheduleByTeam_Click(object sender, EventArgs e)
        {
            var form = new MatchResultsForm(MatchResultsForm.TableType.Schedule);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private void btnScheduleByDate_Click(object sender, EventArgs e)
        {
            var form = new MatchResultsForm(_matchBL.GetMaxDateForAllMatches(), false, MatchResultsForm.TableType.Schedule);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }
    }
}