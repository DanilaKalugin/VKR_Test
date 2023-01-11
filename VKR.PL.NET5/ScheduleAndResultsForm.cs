using System;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities.Tables;
using VKR.PL.Utils.NET5;

namespace VKR.PL.NET5
{
    public partial class ScheduleAndResultsForm : Form
    {
        private readonly Match _currentMatch;

        public ScheduleAndResultsForm(Match match)
        {
            InitializeComponent();
            _currentMatch = match;
            seriesHeader.Text = $"{_currentMatch.AwayTeam.TeamAbbreviation} - {_currentMatch.HomeTeam.TeamAbbreviation} series";
            team1Header.Text = _currentMatch.AwayTeam.TeamName;
            team2Header.Text = _currentMatch.HomeTeam.TeamName;

            team1SeriesImage.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/TeamLogoForMenu/{_currentMatch.AwayTeam.TeamAbbreviation}.png");
            team2SeriesImage.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/TeamLogoForMenu/{_currentMatch.HomeTeam.TeamAbbreviation}.png");
            team1Image.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/TeamLogoForMenu/{_currentMatch.AwayTeam.TeamAbbreviation}.png");
            team2Image.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/TeamLogoForMenu/{_currentMatch.HomeTeam.TeamAbbreviation}.png");
        }

        private void btnSeriesHistory_Click(object sender, EventArgs e) => 
            OpenMatchResultsForm(new MatchResultsForm(_currentMatch.AwayTeam, _currentMatch.HomeTeam, MatchScheduleBL.TableType.Results));

        private void btnSeriesNextMatches_Click(object sender, EventArgs e) => 
            OpenMatchResultsForm(new MatchResultsForm(_currentMatch.AwayTeam, _currentMatch.HomeTeam, MatchScheduleBL.TableType.Schedule));

        private void btnMatchDayResults_Click(object sender, EventArgs e) => 
            OpenMatchResultsForm(new MatchResultsForm(_currentMatch.MatchDate, true, MatchScheduleBL.TableType.Results));

        private void btnMatchDayUpcomingMatches_Click(object sender, EventArgs e) => 
            OpenMatchResultsForm(new MatchResultsForm(_currentMatch.MatchDate, true, MatchScheduleBL.TableType.Schedule));

        private void btnTeam1Last10Matches_Click(object sender, EventArgs e) => 
            OpenMatchResultsForm(new MatchResultsForm(_currentMatch.AwayTeam, MatchScheduleBL.TableType.Results));

        private void btnTeam1Next10Matches_Click(object sender, EventArgs e) => 
            OpenMatchResultsForm(new MatchResultsForm(_currentMatch.AwayTeam, MatchScheduleBL.TableType.Schedule));

        private void btnTeam2Last10Matches_Click(object sender, EventArgs e) => 
            OpenMatchResultsForm(new MatchResultsForm(_currentMatch.HomeTeam, MatchScheduleBL.TableType.Results));

        private void btnTeam2Next10Matches_Click(object sender, EventArgs e) => 
            OpenMatchResultsForm(new MatchResultsForm(_currentMatch.HomeTeam, MatchScheduleBL.TableType.Schedule));

        private void OpenMatchResultsForm(Form form)
        {
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }
    }
}