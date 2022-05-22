using System;
using System.Windows.Forms;
using VKR.BLL.NET5;

namespace VKR.PL.NET5
{
    public partial class MatchResultsMenuForm : Form
    {
        private readonly MatchBL _matchBL = new();

        public MatchResultsMenuForm() => InitializeComponent();

        private void btnResultsByDate_Click(object sender, EventArgs e)
        {
            using (var form = new MatchResultsForm(_matchBL.GetMaxDateForAllMatches(), false, MatchResultsForm.TableType.Results))
            {
                Visible = false;
                form.ShowDialog();
            }

            Visible = true;
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            using (var form = new MatchResultsForm(MatchResultsForm.TableType.Results))
            {
                Visible = false;
                form.ShowDialog();
            }

            Visible = true;
        }

        private void btnCloseResultsMenu_Click(object sender, EventArgs e) => Close();

        private void btnScheduleByTeam_Click(object sender, EventArgs e)
        {
            using (var form = new MatchResultsForm(MatchResultsForm.TableType.Schedule))
            {
                Visible = false;
                form.ShowDialog();
            }

            Visible = true;
        }

        private void btnScheduleByDate_Click(object sender, EventArgs e)
        {
            using (var form = new MatchResultsForm(_matchBL.GetMaxDateForAllMatches(), false, MatchResultsForm.TableType.Schedule))
            {
                Visible = false;
                form.ShowDialog();
            }

            Visible = true;
        }
    }
}