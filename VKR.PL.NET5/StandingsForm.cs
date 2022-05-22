using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Entities.NET5;
using VKR.BLL.NET5;

namespace VKR.PL.NET5
{
    public partial class StandingsForm : Form
    {
        private readonly TeamsBL _teamsBl = new();
        private readonly MatchBL _matchBL = new();
        private List<Team> _teams;
        private readonly Team? _homeTeam;
        private readonly Team? _awayTeam;

        public StandingsForm(Team home, Team away) : this()
        {
            _homeTeam = home;
            _awayTeam = away;
        }

        public StandingsForm()
        {
            InitializeComponent();
            Program.MatchDate = _matchBL.GetMaxDateForAllMatches();
            dtpStandingsDate.Value = Program.MatchDate;
            cbFilter.Text = "League";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e) => GetNewTable(cbFilter);

        private void GetStandingsForThisGroup(string group, int groupNumber, bool isWildCard = false)
        {
            _teams = isWildCard ? _teamsBl.GetWCStandings(group, dtpStandingsDate.Value) : _teamsBl.GetStandings(group, dtpStandingsDate.Value);

            var teamsInGroup = _teams.Count;
            dgvStandings.Rows.Add("", group, "W", "L", "GB", "PCT", "STREAK", "RS", "RA", "DIFF", "HOME", "AWAY");
            dgvStandings.Rows[^1].DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvStandings.Rows[^1].DefaultCellStyle.Font = new Font(dgvStandings.DefaultCellStyle.Font, FontStyle.Bold);

            dgvStandings.Rows[^1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dgvStandings.Rows[^1].DefaultCellStyle.SelectionForeColor = Color.White;

            for (var i = 0; i < teamsInGroup; i++)
            {
                var gamesBehind = Math.Abs(_teams[i].GamesBehind).ToString("0.0", new CultureInfo("en-US"));
                
                if (_teams[i].GamesBehind < 0) gamesBehind = $"+{gamesBehind}";

                dgvStandings.Rows.Add("", _teams[i].TeamTitle, _teams[i].Wins, _teams[i].Losses, gamesBehind, _teams[i].Pct.ToString("#.000", new CultureInfo("en-US")),
                                                _teams[i].StreakString, _teams[i].RunsScored, _teams[i].RunsAllowed, _teams[i].RunDifferential, _teams[i].HomeBalance, _teams[i].AwayBalance);

                if ((_homeTeam != null && _homeTeam.TeamTitle == (string)dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].Cells[1].Value) ||
                    (_awayTeam != null && _awayTeam.TeamTitle == (string)dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].Cells[1].Value))
                {
                    dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].DefaultCellStyle.ForeColor = Color.Black;
                    dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
                    dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].Cells[0].Style.BackColor = _teams[i].TeamColor[0];
                dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].Cells[0].Style.SelectionBackColor = _teams[i].TeamColor[0];
            }
            
            Height = Math.Min(97 + dgvStandings.RowTemplate.Height * (teamsInGroup + 1), Screen.PrimaryScreen.Bounds.Height);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) => GetNewTable(cbFilter);

        private void GetNewTable(ListControl comboBox)
        {
            dgvStandings.Rows.Clear();
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    GetStandingsForThisGroup("MLB", 0);
                    break;
                case 1:
                    GetStandingsForThisGroup("AL", 0);
                    GetStandingsForThisGroup("NL", 1);
                    break;
                case 2:
                    GetStandingsForThisGroup("AL East", 0);
                    GetStandingsForThisGroup("AL Central", 1);
                    GetStandingsForThisGroup("AL West", 2);
                    GetStandingsForThisGroup("NL East", 3);
                    GetStandingsForThisGroup("NL Central", 4);
                    GetStandingsForThisGroup("NL West", 5);
                    break;
                case 3:
                    GetStandingsForThisGroup("AL", 0, true);
                    GetStandingsForThisGroup("NL", 1, true);
                    break;
            }
        }
    }
}