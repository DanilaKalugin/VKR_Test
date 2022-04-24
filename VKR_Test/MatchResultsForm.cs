using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VKR.BLL;
using Entities;
using System.Linq;

namespace VKR_Test
{
    public partial class MatchResultsForm : Form
    {
        private readonly MatchBL _matchBL;
        private readonly TeamsBL _teamsBL;
        private readonly List<Team> _teams;
        private List<Match> _matches;
        public enum TableType { Results, Schedule };
        private TableType _tableType;

        private MatchResultsForm()
        {
            InitializeComponent();
            _matchBL = new MatchBL();
            _teamsBL = new TeamsBL();
        }



        public MatchResultsForm(TableType tableType) : this()
        {
            _tableType = tableType;
            _teams = _teamsBL.GetAllTeams().ToList();
            List<string> teamsInComboBox = _teams.Select(team => team.TeamTitle).ToList();
            cbTeam.DataSource = teamsInComboBox;
            panel2.Visible = false;
        }

        public MatchResultsForm(DateTime dateTime, bool IsCurrentDayResults, TableType tableType)
        {
            _tableType = tableType;
            dtpMatchDate.Value = dateTime;
            FillResultsTable(dgvMatches, _matches);
            panel1.Visible = false;
            panel2.Visible = !IsCurrentDayResults;
        }

        public MatchResultsForm(Team homeTeam, Team AwayTeam, TableType tableType)
        {
            _tableType = tableType;
            if (_tableType == TableType.Results)
            {
                _matches = _matchBL.GetResultsForallMatches().Where(match => (match.AwayTeamAbbreviation == AwayTeam.TeamAbbreviation || match.HomeTeamAbbreviation == AwayTeam.TeamAbbreviation) &&
                                                                           (match.AwayTeamAbbreviation == homeTeam.TeamAbbreviation || match.HomeTeamAbbreviation == homeTeam.TeamAbbreviation)).
                                                                           OrderBy(match => match.MatchDate).ToList();
            }
            else
            {
                _matches = _matchBL.GetSchedule().Where(match => (match.AwayTeamAbbreviation == AwayTeam.TeamAbbreviation || match.HomeTeamAbbreviation == AwayTeam.TeamAbbreviation) &&
                                                               (match.AwayTeamAbbreviation == homeTeam.TeamAbbreviation || match.HomeTeamAbbreviation == homeTeam.TeamAbbreviation)).
                                                               OrderBy(match => match.MatchDate).ToList();
            }
            FillResultsTable(dgvMatches, _matches);
            panel1.Visible = false;
            panel2.Visible = false;
        }

        public MatchResultsForm(Team team1, TableType tableType)
        {
            _tableType = tableType;
            if (_tableType == TableType.Results)
            {
                _matches = _matchBL.GetResultsForallMatches().Where(match => match.AwayTeamAbbreviation == team1.TeamAbbreviation || match.HomeTeamAbbreviation == team1.TeamAbbreviation).OrderByDescending(match => match.MatchDate).Take(10).ToList();
            }
            else
            {
                _matches = _matchBL.GetSchedule().Where(match => match.AwayTeamAbbreviation == team1.TeamAbbreviation || match.HomeTeamAbbreviation == team1.TeamAbbreviation).OrderBy(match => match.MatchDate).Take(10).ToList();
            }
            FillResultsTable(dgvMatches, _matches);
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void MatchResultsForm_Load(object sender, EventArgs e)
        {
            lbHeader.Text = _tableType == TableType.Results ? "MATCH RESULTS" : "SCHEDULE";
        }

        private void cbTeam_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_tableType == TableType.Results)
            {
                _matches = _matchBL.GetResultsForallMatches(_teams[cbTeam.SelectedIndex].TeamAbbreviation);
                _matches = _matches.OrderByDescending(match => match.MatchDate).ToList();
            }
            else
            {
                _matches = _matchBL.GetSchedule(_teams[cbTeam.SelectedIndex].TeamAbbreviation);
                _matches = _matches.OrderBy(match => match.MatchDate).ToList();
            }
            FillResultsTable(dgvMatches, _matches);
        }

        private void FillResultsTable(DataGridView dgv, List<Match> matches)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                dgv.Rows[i].Cells[1].Value = null;
                dgv.Rows[i].Cells[6].Value = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            dgv.Rows.Clear();
            foreach (Match match in matches)
            {
                dgv.Rows.Add(match.MatchDate.ToString("dd-MM"),
                    Image.FromFile($"SmallTeamLogos/{match.AwayTeamAbbreviation}.png"),
                                       match.AwayTeamAbbreviation,
                                       match.AwayTeamRuns,
                                       match.HomeTeamRuns,
                                       match.HomeTeamAbbreviation,
                                       Image.FromFile($"SmallTeamLogos/{match.HomeTeamAbbreviation}.png"),
                                       match.MatchStatus,
                                       $"{match.Stadium.StadiumTitle} - {match.Stadium.StadiumLocation}");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (_tableType == TableType.Results)
            {
                _matches = _matchBL.GetResultsForallMatches().Where(match => match.MatchDate == dtpMatchDate.Value).ToList();
            }
            else
            {
                _matches = _matchBL.GetSchedule().Where(match => match.MatchDate == dtpMatchDate.Value).ToList();
            }
            FillResultsTable(dgvMatches, _matches);
        }
    }
}