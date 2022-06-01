using System;
using System.Windows.Forms;
using VKR.Entities.NET5;

namespace VKR.PL.NET5
{
    public partial class ScheduleAndResultsForm : Form
    {
        private readonly Match _currentMatch;
        private MatchResultsForm _form;

        public ScheduleAndResultsForm(Match match)
        {
            InitializeComponent();
            _currentMatch = match;
            seriesHeader.Text = $"{_currentMatch.AwayTeam.TeamAbbreviation} - {_currentMatch.HomeTeam.TeamAbbreviation} series";
            team1Header.Text = _currentMatch.AwayTeam.TeamTitle;
            team2Header.Text = _currentMatch.HomeTeam.TeamTitle;
        }

        private void btnSeriesHistory_Click(object sender, EventArgs e)
        {
            _form = new MatchResultsForm(_currentMatch.AwayTeam, _currentMatch.HomeTeam, MatchResultsForm.TableType.Results);
            Visible = false;
            _form.ShowDialog();
            Visible = true;
        }

        private void btnSeriesNextMatches_Click(object sender, EventArgs e)
        {
            _form = new MatchResultsForm(_currentMatch.AwayTeam, _currentMatch.HomeTeam, MatchResultsForm.TableType.Schedule);
            Visible = false;
            _form.ShowDialog();
            Visible = true;
        }

        private void btnMatchDayResults_Click(object sender, EventArgs e)
        {
            _form = new MatchResultsForm(_currentMatch.MatchDate, true, MatchResultsForm.TableType.Results);
            Visible = false;
            _form.ShowDialog();
            Visible = true;
        }

        private void btnMatchDayUpcomingMatches_Click(object sender, EventArgs e)
        {
            _form = new MatchResultsForm(_currentMatch.MatchDate, true, MatchResultsForm.TableType.Schedule);
            Visible = false;
            _form.ShowDialog();
            Visible = true;
        }

        private void btnTeam1Last10Matches_Click(object sender, EventArgs e)
        {
            _form = new MatchResultsForm(_currentMatch.AwayTeam, MatchResultsForm.TableType.Results);
            Visible = false;
            _form.ShowDialog();
            Visible = true;
        }

        private void btnTeam1Next10Matches_Click(object sender, EventArgs e)
        {
            _form = new MatchResultsForm(_currentMatch.AwayTeam, MatchResultsForm.TableType.Schedule);
            Visible = false;
            _form.ShowDialog();
            Visible = true;
        }

        private void btnTeam2Last10Matches_Click(object sender, EventArgs e)
        {
            _form = new MatchResultsForm(_currentMatch.HomeTeam, MatchResultsForm.TableType.Results);
            Visible = false;
            _form.ShowDialog();
            Visible = true;
        }

        private void btnTeam2Next10Matches_Click(object sender, EventArgs e)
        {
            _form = new MatchResultsForm(_currentMatch.HomeTeam, MatchResultsForm.TableType.Schedule);
            Visible = false;
            _form.ShowDialog();
            Visible = true;
        }
    }
}