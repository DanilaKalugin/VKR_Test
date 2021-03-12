using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VKR.BLL;
using Entities;
using System.Linq;
using System.Collections;

namespace VKR_Test
{
    public partial class MatchResultsForm : Form
    {
        private readonly MatchBL matchBL;
        private readonly TeamsBL teamsBL;
        IList<Team> teams;
        public MatchResultsForm()
        {
            InitializeComponent();
            matchBL = new MatchBL();
            teamsBL = new TeamsBL();
            teams = teamsBL.GetAllTeams().ToList();
            List<string> teamsInComboBox = teams.Select(team => team.TeamTitle).ToList();
            teamsInComboBox.Add("ALL");
            cbTeam.DataSource = teamsInComboBox;
        }

        private void MatchResultsForm_Load(object sender, EventArgs e)
        {
            List<Match> matches = matchBL.GetResultsForallMatches();
            foreach (Match match in matches)
            {
                dataGridView1.Rows.Add(Image.FromFile($"BigTeamLogos/{match.AwayTeamAbbreviation}.png"),
                    match.AwayTeamAbbreviation,
                                       match.AwayTeamRuns,
                                       match.HomeTeamRuns,
                                       match.HomeTeamAbbreviation,
                                       Image.FromFile($"BigTeamLogos/{match.HomeTeamAbbreviation}.png"),
                                       match.MatchStatus,
                                       $"{match.stadium.StadiumTitle} - {match.stadium.stadiumLocation}");
            }
            cbTeam.Text = "ALL";
        }

        private void cbTeam_SelectedValueChanged(object sender, EventArgs e)
        {
            List<Match> matches = matchBL.GetResultsForallMatches();
            if (cbTeam.Text == "ALL")
            {
                matches = matchBL.GetResultsForallMatches();
            }
            else
            {
                matches = matchBL.GetResultsForallMatches(teams[cbTeam.SelectedIndex].TeamAbbreviation);
            }
            dataGridView1.Rows.Clear();
            foreach (Match match in matches)
            {
                dataGridView1.Rows.Add(Image.FromFile($"BigTeamLogos/{match.AwayTeamAbbreviation}.png"),
                    match.AwayTeamAbbreviation,
                                       match.AwayTeamRuns,
                                       match.HomeTeamRuns,
                                       match.HomeTeamAbbreviation,
                                       Image.FromFile($"BigTeamLogos/{match.HomeTeamAbbreviation}.png"),
                                       match.MatchStatus,
                                       $"{match.stadium.StadiumTitle} - {match.stadium.stadiumLocation}");
            }
        }
    }
}
