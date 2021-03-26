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
            dateTimePicker1.Value = Program.MatchDate;
            comboBox1.Text = "MLB";
        }

        public StandingsForm(Team Home, Team Away)
        {
            InitializeComponent();
            teamsBl = new TeamsBL();
            matchBL = new MatchBL();
            Program.MatchDate = matchBL.GetMaxDateForAllMatches();
            dateTimePicker1.Value = Program.MatchDate;
            HomeTeam = Home;
            AwayTeam = Away;
            comboBox1.Text = "MLB";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            GetNewTable(comboBox1);
        }

        private void GetStandingsForThisGroup(string group, int TeamsInGroup, int GroupNumber, Team _Home, Team _Away)
        {
            teams = teamsBl.GetStandings(group, dateTimePicker1.Value);
            dataGridView1.Rows.Add("", group, "W", "L", "GB", "PCT", "RS", "RA", "DIFF");
            dataGridView1.Rows[(TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dataGridView1.Rows[(TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);

            dataGridView1.Rows[(TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dataGridView1.Rows[(TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.SelectionForeColor = Color.White;

            for (int i = 0; i < teams.Count; i++)
            {
                dataGridView1.Rows.Add("", teams[i].TeamTitle, teams[i].Wins, teams[i].Losses, teams[i].GamesBehind.ToString("0.0", new CultureInfo("en-US")), teams[i].PCT.ToString("#.000", new CultureInfo("en-US")), teams[i].RunsScored, teams[i].RunsAllowed, teams[i].RunDifferential);
                if ((HomeTeam != null && HomeTeam.TeamTitle == (string)dataGridView1.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].Cells[1].Value) ||
                    (AwayTeam != null && AwayTeam.TeamTitle == (string)dataGridView1.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].Cells[1].Value))
                {
                    dataGridView1.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    dataGridView1.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.ForeColor = Color.Black;
                    dataGridView1.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
                    dataGridView1.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                dataGridView1.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].Cells[0].Style.BackColor = teams[i].TeamColor[0];
                dataGridView1.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].Cells[0].Style.SelectionBackColor = teams[i].TeamColor[0];
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GetNewTable(comboBox1);
        }

        private void GetNewTable(ComboBox comboBox)
        {
            dataGridView1.Rows.Clear();
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    {
                        GetStandingsForThisGroup("MLB", 30, 0, HomeTeam, AwayTeam);
                        break;
                    }
                case 1:
                    {
                        GetStandingsForThisGroup("AL", 15, 0, HomeTeam, AwayTeam);
                        GetStandingsForThisGroup("NL", 15, 1, HomeTeam, AwayTeam);
                        break;
                    }
                case 2:
                    {
                        GetStandingsForThisGroup("AL East", 5, 0, HomeTeam, AwayTeam);
                        GetStandingsForThisGroup("AL Central", 5, 1, HomeTeam, AwayTeam);
                        GetStandingsForThisGroup("AL West", 5, 2, HomeTeam, AwayTeam);
                        GetStandingsForThisGroup("NL East", 5, 3, HomeTeam, AwayTeam);
                        GetStandingsForThisGroup("NL Central", 5, 4, HomeTeam, AwayTeam);
                        GetStandingsForThisGroup("NL West", 5, 5, HomeTeam, AwayTeam);
                        break;
                    }
            }
            Height = 97 + dataGridView1.RowTemplate.Height * dataGridView1.RowCount;
        }
    }
}