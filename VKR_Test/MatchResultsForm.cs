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
        private readonly MatchBL matchBL;
        private readonly TeamsBL teamsBL;
        IList<Team> teams;
        List<Match> matches;

        public MatchResultsForm()
        {
            InitializeComponent();
            matchBL = new MatchBL();
            teamsBL = new TeamsBL();
            teams = teamsBL.GetAllTeams().ToList();
            List<string> teamsInComboBox = teams.Select(team => team.TeamTitle).ToList();
            cbTeam.DataSource = teamsInComboBox;
            panel2.Visible = false;
        }

        public MatchResultsForm(DateTime dateTime, bool IsCurrentDayResults)
        {
            InitializeComponent();
            matchBL = new MatchBL();
            teamsBL = new TeamsBL();
            dtpMatchDate.Value = dateTime;
            FillResultsTable(dgvMatches, matches);
            panel1.Visible = false;
            panel2.Visible = !IsCurrentDayResults;
        }

        public MatchResultsForm(Team homeTeam, Team AwayTeam)
        {
            InitializeComponent();
            matchBL = new MatchBL();
            teamsBL = new TeamsBL();
            matches = matchBL.GetResultsForallMatches().Where(match => (match.AwayTeamAbbreviation == AwayTeam.TeamAbbreviation || match.HomeTeamAbbreviation == AwayTeam.TeamAbbreviation) &&
                                                                       (match.AwayTeamAbbreviation == homeTeam.TeamAbbreviation || match.HomeTeamAbbreviation == homeTeam.TeamAbbreviation)).ToList();
            FillResultsTable(dgvMatches, matches);
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void MatchResultsForm_Load(object sender, EventArgs e)
        {
            cbTeam.Text = "ALL";
        }

        private void cbTeam_SelectedValueChanged(object sender, EventArgs e)
        {
            matches = matchBL.GetResultsForallMatches(teams[cbTeam.SelectedIndex].TeamAbbreviation);
            FillResultsTable(dgvMatches, matches);
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
                                       $"{match.stadium.StadiumTitle} - {match.stadium.stadiumLocation}");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            matches = matchBL.GetResultsForallMatches().Where(match => match.MatchDate == dtpMatchDate.Value).ToList();
            FillResultsTable(dgvMatches, matches);
        }
    }
}