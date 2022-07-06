using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.Entities.NET5;

namespace VKR.PL.NET5
{
    public partial class StandingsForm : Form
    {
        private readonly TeamsBL _teamsBl = new();
        private readonly MatchBL _matchBL = new();
        private readonly EF.Entities.Team? _homeTeam;
        private readonly EF.Entities.Team? _awayTeam;

        public StandingsForm(Team home, Team away) : this()
        {
            //_homeTeam = home;
            //_awayTeam = away;
        }

        public StandingsForm()
        {
            InitializeComponent();
            //Program.MatchDate = _matchBL.GetMaxDateForAllMatches();
            dtpStandingsDate.Value = new DateTime(2021, 10, 1);
            cbFilter.Text = "MLB";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e) => GetNewTable(cbFilter.SelectedIndex);

        private void GetStandingsForThisGroup(IList<EF.Entities.Team> teams, string group)
        {
            var teamsInGroup = teams.Count;
            dgvStandings.Rows.Add("", group, "W", "L", "GB", "PCT", "STREAK", "RS", "RA", "DIFF", "HOME", "AWAY");
            dgvStandings.Rows[^1].DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvStandings.Rows[^1].DefaultCellStyle.Font = new Font(dgvStandings.DefaultCellStyle.Font, FontStyle.Bold);

            dgvStandings.Rows[^1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dgvStandings.Rows[^1].DefaultCellStyle.SelectionForeColor = Color.White;

            for (var i = 0; i < teamsInGroup; i++)
            {
                var gamesBehind = Math.Abs(teams[i].GamesBehind).ToString("0.0", new CultureInfo("en-US"));

                if (teams[i].GamesBehind < 0) gamesBehind = $"+{gamesBehind}";

                var row = new DataGridViewRow();
                row.CreateCells(dgvStandings);
                row.Cells[0].Style.BackColor = teams[i].TeamColors[0].Color;
                row.Cells[0].Style.SelectionBackColor = teams[i].TeamColors[0].Color;
                row.Cells[1].Value = teams[i].TeamName;
                row.Cells[2].Value = teams[i].Wins;
                row.Cells[3].Value = teams[i].Losses;
                row.Cells[4].Value = gamesBehind;
                row.Cells[5].Value = teams[i].Pct.ToString("#.000", new CultureInfo("en-US"));
                row.Cells[6].Value = teams[i].StreakString;
                //row.Cells[7].Value = teams[i].RunsScored;
                //row.Cells[8].Value = teams[i].RunsAllowed;
                //row.Cells[9].Value = teams[i].RunDifferential;
                row.Cells[10].Value = teams[i].HomeBalance;
                row.Cells[11].Value = teams[i].AwayBalance;


                dgvStandings.Rows.Add(row);

                //if ((_homeTeam != null && _homeTeam.TeamName == (string)dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].Cells[1].Value) ||
                //    (_awayTeam != null && _awayTeam.TeamName == (string)dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].Cells[1].Value))
                //{
                //    dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                //    dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].DefaultCellStyle.ForeColor = Color.Black;
                //    dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
                //    dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].DefaultCellStyle.SelectionForeColor = Color.Black;
                //}
                //dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].Cells[0].Style.BackColor = _teams[i].TeamColors[0].Color;
                //dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].Cells[0].Style.SelectionBackColor = _teams[i].TeamColors[0].Color;
            }

            Height = Math.Min(97 + dgvStandings.RowTemplate.Height * (teamsInGroup + 1), Screen.PrimaryScreen.Bounds.Height);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) => GetNewTable(cbFilter.SelectedIndex);

        private void GetNewTable(int groupingTypeNumber)
        {
            dgvStandings.Rows.Clear();

            List<string> DefineGroupsForTable(int groupingType)
            {
                return groupingType switch
                {
                    0 => new List<string> { "MLB" },
                    1 or 3 => new List<string> { "AL", "NL" },
                    2 => new List<string>
                {
                    "AL East",
                    "AL Central",
                    "AL West",
                    "NL East",
                    "NL Central",
                    "NL West"
                },
                    _ => new List<string>()
                };
            }

            var groups = DefineGroupsForTable(groupingTypeNumber);

            Func<string, DateTime, List<EF.Entities.Team>> teamFunc =
                groupingTypeNumber == 3 ? _teamsBl.GetWCStandings : _teamsBl.GetStandings;

            var teamsGroups = GetStandingsForEachGroup(groups, teamFunc);

            for (var index = 0; index < teamsGroups.Count; index++)
                GetStandingsForThisGroup(teamsGroups[index], groups[index]);
        }

        private List<List<EF.Entities.Team>> GetStandingsForEachGroup(IReadOnlyList<string> groups, Func<string, DateTime, List<EF.Entities.Team>> teamFunc)
        {
            var teamsGroups = new List<List<EF.Entities.Team>>(groups.Count);
            teamsGroups.AddRange(Enumerable.Repeat(new List<EF.Entities.Team>(), groups.Count));

            Parallel.For(0, groups.Count, index =>
            {
                teamsGroups[index] = teamFunc(groups[index], dtpStandingsDate.Value);
            });
            return teamsGroups;
        }
    }
}