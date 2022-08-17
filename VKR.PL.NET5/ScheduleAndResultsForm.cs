using System;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;

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
            team1Header.Text = _currentMatch.AwayTeam.TeamName;
            team2Header.Text = _currentMatch.HomeTeam.TeamName;
        }

        private void btnSeriesHistory_Click(object sender, EventArgs e)
        {
            _form = new MatchResultsForm(_currentMatch.AwayTeam, _currentMatch.HomeTeam, MatchScheduleBL.TableType.Results);
            Visible = false;
            _form.ShowDialog();
            Visible = true;
        }

        private void btnSeriesNextMatches_Click(object sender, EventArgs e)
        {
            _form = new MatchResultsForm(_currentMatch.AwayTeam, _currentMatch.HomeTeam, MatchScheduleBL.TableType.Schedule);
            Visible = false;
            _form.ShowDialog();
            Visible = true;
        }

        private void btnMatchDayResults_Click(object sender, EventArgs e)
        {
            _form = new MatchResultsForm(_currentMatch.MatchDate, true, MatchScheduleBL.TableType.Results);
            Visible = false;
            _form.ShowDialog();
            Visible = true;
        }

        private void btnMatchDayUpcomingMatches_Click(object sender, EventArgs e)
        {
            _form = new MatchResultsForm(_currentMatch.MatchDate, true, MatchScheduleBL.TableType.Schedule);
            Visible = false;
            _form.ShowDialog();
            Visible = true;
        }

        private void btnTeam1Last10Matches_Click(object sender, EventArgs e)
        {
            _form = new MatchResultsForm(_currentMatch.AwayTeam, MatchScheduleBL.TableType.Results);
            Visible = false;
            _form.ShowDialog();
            Visible = true;
        }

        private void btnTeam1Next10Matches_Click(object sender, EventArgs e)
        {
            _form = new MatchResultsForm(_currentMatch.AwayTeam, MatchScheduleBL.TableType.Schedule);
            Visible = false;
            _form.ShowDialog();
            Visible = true;
        }

        private void btnTeam2Last10Matches_Click(object sender, EventArgs e)
        {
            _form = new MatchResultsForm(_currentMatch.HomeTeam, MatchScheduleBL.TableType.Results);
            Visible = false;
            _form.ShowDialog();
            Visible = true;
        }

        private void btnTeam2Next10Matches_Click(object sender, EventArgs e)
        {
            _form = new MatchResultsForm(_currentMatch.HomeTeam, MatchScheduleBL.TableType.Schedule);
            Visible = false;
            _form.ShowDialog();
            Visible = true;
        }
    }
}