using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;

namespace VKR.PL.NET5
{
    public partial class StandingsForm : Form
    {
        private readonly MatchBL _matchBl = new();
        private readonly StandingsBL _standingsBl = new();
        private readonly PrimaryTeamColorBL _primaryColorBl = new();
        private readonly SeasonBL _seasonBl = new();

        private readonly Team? _homeTeam;
        private readonly Team? _awayTeam;
        private List<TeamColor> _teamsColors;
        private List<Season> _seasons;
        private Season _season;
        private LeagueSeason _leagueSeason;

        public StandingsForm(Team home, Team away) : this()
        {
            _homeTeam = home;
            _awayTeam = away;
        }

        public StandingsForm() => InitializeComponent();

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e) => GetNewTable(cbFilter.SelectedIndex);

        private void GetStandingsForThisGroup(IList<Team> teams, string group)
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

                row.Cells[1].Value = teams[i].TeamName;
                row.Cells[2].Value = teams[i].Wins;
                row.Cells[3].Value = teams[i].Losses;
                row.Cells[4].Value = gamesBehind;
                row.Cells[5].Value = teams[i].Pct.ToString("#.000", new CultureInfo("en-US"));
                row.Cells[6].Value = teams[i].StreakString;
                row.Cells[7].Value = teams[i].RunsScored;
                row.Cells[8].Value = teams[i].RunsAllowed;
                row.Cells[9].Value = teams[i].RunDifferential;
                row.Cells[10].Value = teams[i].HomeBalance;
                row.Cells[11].Value = teams[i].AwayBalance;

                if ((_homeTeam != null && _homeTeam.TeamName == teams[i].TeamName) ||
                    (_awayTeam != null && _awayTeam.TeamName == teams[i].TeamName))
                {
                    row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
                    row.DefaultCellStyle.SelectionForeColor = Color.Black;
                }

                var teamColor = _teamsColors.First(tc => tc.TeamName == teams[i].TeamAbbreviation).Color;
                row.Cells[0].Style.BackColor = teamColor;
                row.Cells[0].Style.SelectionBackColor = teamColor;
                dgvStandings.Rows.Add(row);
            }

            Height = Math.Min(97 + dgvStandings.RowTemplate.Height * (teamsInGroup + 1), Screen.PrimaryScreen.Bounds.Height);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) => GetNewTable(cbFilter.SelectedIndex);

        private void GetNewTable(int groupingTypeNumber)
        {
            dgvStandings.Rows.Clear();

            var groups = groupingTypeNumber switch
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

            Func<string, DateTime, List<Team>> teamFunc =
                groupingTypeNumber == 3 
                    ? _standingsBl.GetWildCardStandings 
                    : _standingsBl.GetStandings;

            var teamsGroups = GetStandingsForEachGroup(groups, teamFunc);

            for (var index = 0; index < teamsGroups.Count; index++)
                GetStandingsForThisGroup(teamsGroups[index], groups[index]);
        }

        private List<List<Team>> GetStandingsForEachGroup(IReadOnlyList<string> groups, Func<string, DateTime, List<Team>> teamFunc)
        {
            var teamsGroups = new List<List<Team>>(groups.Count);

            teamsGroups.AddRange(Enumerable.Repeat(new List<Team>(), groups.Count));

            Parallel.For(0, groups.Count, index => teamsGroups[index] = teamFunc(groups[index], dtpStandingsDate.Value));
            return teamsGroups;
        }

        private async void StandingsForm_Load(object sender, EventArgs e)
        {
            _seasons = await _seasonBl.GetAllSeasonsAsync();
            cbSeasons.DataSource = _seasons;
            cbSeasons.DisplayMember = "Year";

            _season = await _seasonBl.GetCurrentSeason();
            _leagueSeason = await _seasonBl.GetLeagueSeasonInfo(_season.Year);
            ChangeMaxAndMinDateForThisSeason(_leagueSeason);

            var matchDate = await _matchBl.GetMaxDateForAllMatchesAsync();
            cbSeasons.SelectedItem = _seasons.FirstOrDefault(year => year.Year == matchDate.Year);

            dtpStandingsDate.Value = matchDate;
            _teamsColors = await _primaryColorBl.GetPrimaryTeamColorsAsync();
            cbFilter.Text = "MLB";
        }

        private async void cbSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            var season = cbSeasons.SelectedValue as Season;
            var leagueSeason = await _seasonBl.GetLeagueSeasonInfo(season.Year);

            ChangeMaxAndMinDateForThisSeason(leagueSeason);
        }

        private void ChangeMaxAndMinDateForThisSeason(LeagueSeason season)
        {
            if (season.SeasonEnd < dtpStandingsDate.MinDate)
            {
                dtpStandingsDate.MinDate = season.SeasonStart;
                dtpStandingsDate.MaxDate = season.SeasonEnd;
            }

            dtpStandingsDate.MaxDate = season.SeasonEnd;
            dtpStandingsDate.MinDate = season.SeasonStart;
        }
    }
}