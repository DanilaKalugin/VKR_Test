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
    public partial class StatsMenuForm : Form
    {
        private readonly StatsBL _statsBl = new();
        private readonly PrimaryTeamColorBL _primaryColorBl = new();
        private readonly SeasonBL _seasonBl = new();

        private Season _season;
        private List<Player> _batters;
        private List<Player> _pitchers;
        private List<TeamColor> _teamsColors;

        public StatsMenuForm()
        {
            InitializeComponent();
        }

        private void btnPlayersStats_Click(object sender, EventArgs e) => OpenStats(PlayerStatsForm.SortingObjects.Players);

        private void btnTeamsStats_Click(object sender, EventArgs e) => OpenStats(PlayerStatsForm.SortingObjects.Teams);

        private void OpenStats(PlayerStatsForm.SortingObjects objects)
        {
            var form = new PlayerStatsForm(objects);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private TKey? ReturnMaxStatsValueForBatter<TKey>(Func<Player, TKey> key) => _batters.Select(key).Max();

        private TKey? ReturnMaxStatsValueForPitcher<TKey>(Func<Player, TKey> key) => _pitchers.Select(key).Max();

        private TKey? ReturnMinStatsValueForPitcher<TKey>(Func<Player, TKey> key) => _pitchers.Select(key).Min();

        private async Task<TKey?> ReturnMaxStatsValueForPitcher<TKey>(Func<Player, TKey> key, string qualifying)
        {
            var pitchers = await _statsBl.GetPitchersStats(_season, qualifying);
            return pitchers.Select(key).Max();
        }

        private string GetFullNameOfLeaderForThisBattingParameter(Func<Player, bool> key)
        {
            var countOfBattersWithThisAVG = _batters.Where(key).Count();

            return countOfBattersWithThisAVG == 1 ? _batters.Where(key).Select(batter => batter.FullName).First() : "Tied";
        }

        private async Task<string> GetFullNameOfLeaderForThisPitchingParameter(Func<Player, bool> key)
        {
            var countOfBattersWithThisAVG = _pitchers.Where(key).Count();

            switch (countOfBattersWithThisAVG)
            {
                case 0:
                    {
                        var _pitchers = await _statsBl.GetPitchersStats(_season, "All Players");
                        countOfBattersWithThisAVG = _pitchers.Where(key).Count();
                        return countOfBattersWithThisAVG == 1 ? _pitchers.Where(key).Select(pitcher => pitcher.FullName).First() : "Tied";
                    }
                case 1:
                    return _pitchers.Where(key).Select(pitcher => pitcher.FullName).First();
                default:
                    return "Tied";
            }
        }

        private void GetBattingLeaders()
        {
            dgvBattingLeaders.Rows.Clear();
            var bestAVG = ReturnMaxStatsValueForBatter(batter1 => batter1.BattingStats.AVG);
            var bestHR = ReturnMaxStatsValueForBatter(batter1 => batter1.BattingStats.HomeRuns);
            var bestRBI = ReturnMaxStatsValueForBatter(batter1 => batter1.BattingStats.RBI);
            var bestSB = ReturnMaxStatsValueForBatter(batter1 => batter1.BattingStats.StolenBases);
            var bestR = ReturnMaxStatsValueForBatter(batter1 => batter1.BattingStats.Runs);

            dgvBattingLeaders.Rows.Add("AVG", "", GetFullNameOfLeaderForThisBattingParameter(batter => batter.BattingStats.AVG == bestAVG), bestAVG.ToString("#.000", new CultureInfo("en-US")));
            dgvBattingLeaders.Rows.Add("HR", "", GetFullNameOfLeaderForThisBattingParameter(batter => batter.BattingStats.HomeRuns == bestHR), bestHR);
            dgvBattingLeaders.Rows.Add("RBI", "", GetFullNameOfLeaderForThisBattingParameter(batter => batter.BattingStats.RBI == bestRBI), bestRBI);
            dgvBattingLeaders.Rows.Add("SB", "", GetFullNameOfLeaderForThisBattingParameter(batter => batter.BattingStats.StolenBases == bestSB), bestSB);
            dgvBattingLeaders.Rows.Add("R", "", GetFullNameOfLeaderForThisBattingParameter(batter => batter.BattingStats.Runs == bestR), bestR);

            for (var i = 0; i < dgvBattingLeaders.RowCount; i++)
            {
                if (dgvBattingLeaders.Rows[i].Cells[2].Value.ToString() == "Tied")
                {
                    dgvBattingLeaders.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(220, 220, 220);
                    dgvBattingLeaders.Rows[i].Cells[1].Style.SelectionBackColor = Color.FromArgb(220, 220, 220);
                }
                else
                {
                    var currentBatter = _batters.First(batter => batter.FullName == dgvBattingLeaders.Rows[i].Cells[2].Value.ToString());
                    var color = _teamsColors.First(team => team.TeamName == currentBatter.PlayersInTeam.First().TeamId).Color;
                    dgvBattingLeaders.Rows[i].Cells[1].Style.BackColor = color;
                    dgvBattingLeaders.Rows[i].Cells[1].Style.SelectionBackColor = color;
                }
            }
        }

        private async Task GetPitchingLeaders()
        {
            dgvPitchingLeaders.Rows.Clear();

            var maxSaves = await ReturnMaxStatsValueForPitcher(batter1 => batter1.PitchingStats.Saves, "All Players");
            var maxWins = ReturnMaxStatsValueForPitcher(batter1 => batter1.PitchingStats.Wins);
            var bestERA = ReturnMinStatsValueForPitcher(batter1 => batter1.PitchingStats.ERA);
            var maxSO = ReturnMaxStatsValueForPitcher(batter1 => batter1.PitchingStats.Strikeouts);
            var bestWHIP = ReturnMinStatsValueForPitcher(batter1 => batter1.PitchingStats.WHIP);

            var leaderWTask = GetFullNameOfLeaderForThisPitchingParameter(batter => batter.PitchingStats.Wins == maxWins);
            var leaderSVTask = GetFullNameOfLeaderForThisPitchingParameter(batter => batter.PitchingStats.Saves == maxSaves);
            var leaderERATask = GetFullNameOfLeaderForThisPitchingParameter(batter => batter.PitchingStats.ERA == bestERA);
            var leaderSOTask = GetFullNameOfLeaderForThisPitchingParameter(batter => batter.PitchingStats.Strikeouts == maxSO);
            var leaderWHIPTask = GetFullNameOfLeaderForThisPitchingParameter(batter => batter.PitchingStats.WHIP == bestWHIP);

            await Task.WhenAll(leaderWTask, leaderSVTask, leaderSOTask, leaderERATask, leaderWHIPTask);

            dgvPitchingLeaders.Rows.Add("W", "", leaderWTask.Result, maxWins);
            dgvPitchingLeaders.Rows.Add("SV", "", leaderSVTask.Result, maxSaves);
            dgvPitchingLeaders.Rows.Add("ERA", "", leaderERATask.Result, bestERA.ToString("0.00", new CultureInfo("en-US")));
            dgvPitchingLeaders.Rows.Add("SO", "", leaderSOTask.Result, maxSO);
            dgvPitchingLeaders.Rows.Add("WHIP", "", leaderWHIPTask.Result, bestWHIP.ToString("0.00", new CultureInfo("en-US")));

            for (var i = 0; i < dgvPitchingLeaders.RowCount; i++)
            {
                if (dgvPitchingLeaders.Rows[i].Cells[2].Value.ToString() != "Tied")
                {
                    var pitchersWithThisValue = _pitchers.Where(batter => batter.FullName == dgvPitchingLeaders.Rows[i].Cells[2].Value.ToString()).ToList();
                    Player currentPlayer;
                    if (pitchersWithThisValue.Count == 0)
                    {
                        var allPitchers = await _statsBl.GetPitchersStats(_season, "All Players");
                        currentPlayer = allPitchers.First(batter => batter.FullName == dgvPitchingLeaders.Rows[i].Cells[2].Value.ToString());
                    }
                    else currentPlayer = pitchersWithThisValue.First();

                    var color = _teamsColors.First(team => team.TeamName == currentPlayer.PlayersInTeam.First().TeamId).Color;
                    dgvPitchingLeaders.Rows[i].Cells[1].Style.BackColor = color;
                    dgvPitchingLeaders.Rows[i].Cells[1].Style.SelectionBackColor = color;
                }
                else
                {
                    dgvPitchingLeaders.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(220, 220, 220);
                    dgvPitchingLeaders.Rows[i].Cells[1].Style.SelectionBackColor = Color.FromArgb(220, 220, 220);
                }
            }
        }

        private void btnCloseResultsMenu_Click(object sender, EventArgs e) => Close();

        private async void StatsMenuForm_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            _season = await _seasonBl.GetCurrentSeason();
            _teamsColors = await _primaryColorBl.GetPrimaryTeamColorsAsync();

            var f = new LoadingForm();
            try
            {
                f.Show();
                f.TopMost = true;

                var battersTask = _statsBl.GetBattersStats(_season);
                var pitchersTask = _statsBl.GetPitchersStats(_season);
                

                await Task.WhenAll(battersTask, pitchersTask);
                (_batters, _pitchers) = (battersTask.Result, pitchersTask.Result);

                await GetPitchingLeaders();
                GetBattingLeaders();
            }
            finally
            {
                f.Close();
                Opacity = 1;
            }
        }
    }
}