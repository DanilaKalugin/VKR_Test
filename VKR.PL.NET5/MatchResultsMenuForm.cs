using System;
using System.Windows.Forms;
using VKR.BLL.NET5;

namespace VKR.PL.NET5
{
    public partial class MatchResultsMenuForm : Form
    {
        private readonly MatchBL _matchBL = new();

        public MatchResultsMenuForm() => InitializeComponent();

        private async void btnResultsByDate_Click(object sender, EventArgs e)
        {
            var matchDate = await _matchBL.GetMaxDateForAllMatchesAsync(); 
            OpenMatchResultsForm(new MatchResultsForm(matchDate, false, MatchScheduleBL.TableType.Results));
        }

        private void btnResults_Click(object sender, EventArgs e) => 
            OpenMatchResultsForm(new MatchResultsForm(MatchScheduleBL.TableType.Results));

        private void btnScheduleByTeam_Click(object sender, EventArgs e) => 
            OpenMatchResultsForm(new MatchResultsForm(MatchScheduleBL.TableType.Schedule));

        private async void btnScheduleByDate_Click(object sender, EventArgs e)
        {
            var matchDate = await _matchBL.GetMaxDateForAllMatchesAsync();
            OpenMatchResultsForm(new MatchResultsForm(matchDate, false, MatchScheduleBL.TableType.Schedule));
        }

        private void OpenMatchResultsForm(MatchResultsForm form)
        {
            Visible = false;
            using (form)
                form.ShowDialog();
            Visible = true;
        }
    }
}