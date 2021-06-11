using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class StandingsForm : Form
    {
        private readonly TeamsBL teamsBl;
        private readonly MatchBL matchBL;
        List<Team> teams;
        private Team HomeTeam;
        private Team AwayTeam;

        public StandingsForm()
        {
            InitializeComponent();
            teamsBl = new TeamsBL();
            matchBL = new MatchBL();
            Program.MatchDate = matchBL.GetMaxDateForAllMatches();
            dtpStandingsDate.Value = Program.MatchDate;
            cbFilter.Text = "MLB";
        }

        public StandingsForm(Team Home, Team Away)
        {
            InitializeComponent();
            teamsBl = new TeamsBL();
            matchBL = new MatchBL();
            Program.MatchDate = matchBL.GetMaxDateForAllMatches();
            dtpStandingsDate.Value = Program.MatchDate;
            HomeTeam = Home;
            AwayTeam = Away;
            cbFilter.Text = "MLB";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            GetNewTable(cbFilter);
        }

        private void GetStandingsForThisGroup(string group, int TeamsInGroup, int GroupNumber)
        {
            teams = teamsBl.GetStandings(group, dtpStandingsDate.Value);
            dgvStandings.Rows.Add("", group, "W", "L", "GB", "PCT", "RS", "RA", "DIFF");
            dgvStandings.Rows[(TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvStandings.Rows[(TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.Font = new Font(dgvStandings.DefaultCellStyle.Font, FontStyle.Bold);

            dgvStandings.Rows[(TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dgvStandings.Rows[(TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.SelectionForeColor = Color.White;

            for (int i = 0; i < teams.Count; i++)
            {
                dgvStandings.Rows.Add("", teams[i].TeamTitle, teams[i].Wins, teams[i].Losses, teams[i].GamesBehind.ToString("0.0", new CultureInfo("en-US")), teams[i].PCT.ToString("#.000", new CultureInfo("en-US")), teams[i].RunsScored, teams[i].RunsAllowed, teams[i].RunDifferential);
                if ((HomeTeam != null && HomeTeam.TeamTitle == (string)dgvStandings.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].Cells[1].Value) ||
                    (AwayTeam != null && AwayTeam.TeamTitle == (string)dgvStandings.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].Cells[1].Value))
                {
                    dgvStandings.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    dgvStandings.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.ForeColor = Color.Black;
                    dgvStandings.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
                    dgvStandings.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                dgvStandings.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].Cells[0].Style.BackColor = teams[i].TeamColor[0];
                dgvStandings.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].Cells[0].Style.SelectionBackColor = teams[i].TeamColor[0];
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GetNewTable(cbFilter);
        }

        private void GetNewTable(ComboBox comboBox)
        {
            dgvStandings.Rows.Clear();
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    {
                        GetStandingsForThisGroup("MLB", 30, 0);
                        break;
                    }
                case 1:
                    {
                        GetStandingsForThisGroup("AL", 15, 0);
                        GetStandingsForThisGroup("NL", 15, 1);
                        break;
                    }
                case 2:
                    {
                        GetStandingsForThisGroup("AL East", 5, 0);
                        GetStandingsForThisGroup("AL Central", 5, 1);
                        GetStandingsForThisGroup("AL West", 5, 2);
                        GetStandingsForThisGroup("NL East", 5, 3);
                        GetStandingsForThisGroup("NL Central", 5, 4);
                        GetStandingsForThisGroup("NL West", 5, 5);
                        break;
                    }
            }
            Height = 97 + dgvStandings.RowTemplate.Height * dgvStandings.RowCount;
        }
    }
}