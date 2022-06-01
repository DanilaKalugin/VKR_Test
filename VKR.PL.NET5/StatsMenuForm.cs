using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.Entities.NET5;

namespace VKR.PL.NET5
{
    public partial class StatsMenuForm : Form
    {
        private readonly PlayerBL playersBL = new();
        private readonly TeamsBL teamsBL = new();
        private readonly List<Player> batters;
        private readonly List<Player> pitchers;
        private readonly List<Team> teams;

        public StatsMenuForm()
        {
            InitializeComponent();

            batters = playersBL.GetBattersStats();
            pitchers = playersBL.GetPitchersStats();
            teams = teamsBL.GetAllTeams();
        }

        private void btnPlayersStats_Click(object sender, EventArgs e)
        {
            OpenStats(PlayerStatsForm.SortingObjects.Players);
        }

        private void btnTeamsStats_Click(object sender, EventArgs e)
        {
            OpenStats(PlayerStatsForm.SortingObjects.Teams);
        }

        private void OpenStats(PlayerStatsForm.SortingObjects objects)
        {
            var form = new PlayerStatsForm(objects);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private TKey? ReturnMaxStatsValueForBatter<TKey>(Func<Player, TKey> key) => batters.Select(key).Max();

        private TKey? ReturnMaxStatsValueForPitcher<TKey>(Func<Player, TKey> key) => pitchers.Select(key).Max();

        private TKey? ReturnMinStatsValueForPitcher<TKey>(Func<Player, TKey> key) => pitchers.Select(key).Min();

        private TKey? ReturnMaxStatsValueForPitcher<TKey>(Func<Player, TKey> key, string qualyfing)
        {
            var pitchers = playersBL.GetPitchersStats(qualyfing);
            return pitchers.Select(key).Max();
        }

        private string GetFullNameOfLeaderForThisBattingParameter(Func<Player, bool> key)
        {
            var countOfBattersWithThisAVG = batters.Where(key).Count();

            return countOfBattersWithThisAVG == 1 ? batters.Where(key).Select(batter => batter.FullName).First() : "Tied";
        }

        private string GetFullNameOfLeaderForThisPitchingParameter(Func<Player, bool> key)
        {
            var countOfBattersWithThisAVG = pitchers.Where(key).Count();

            switch (countOfBattersWithThisAVG)
            {
                case 0:
                {
                    var pitchers = playersBL.GetPitchersStats("All Players");
                    countOfBattersWithThisAVG = pitchers.Where(key).Count();

                    return countOfBattersWithThisAVG == 1 ? pitchers.Where(key).Select(pitcher => pitcher.FullName).First() : "Tied";
                }
                case 1:
                    return pitchers.Where(key).Select(pitcher => pitcher.FullName).First();
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
                    var currentBatter = batters.First(batter => batter.FullName == dgvBattingLeaders.Rows[i].Cells[2].Value.ToString());
                    var manTeam = teams.First(team => team.TeamAbbreviation == currentBatter.Team);
                    dgvBattingLeaders.Rows[i].Cells[1].Style.BackColor = manTeam.TeamColor[0];
                    dgvBattingLeaders.Rows[i].Cells[1].Style.SelectionBackColor = manTeam.TeamColor[0];
                }
            }

            dgvPitchingLeaders.Rows.Clear();

            var maxSaves = ReturnMaxStatsValueForPitcher(batter1 => batter1.PitchingStats.Saves, "All Players");
            var maxWins = ReturnMaxStatsValueForPitcher(batter1 => batter1.PitchingStats.Wins);
            var bestERA = ReturnMinStatsValueForPitcher(batter1 => batter1.PitchingStats.ERA);
            var maxSO = ReturnMaxStatsValueForPitcher(batter1 => batter1.PitchingStats.Strikeouts);
            var bestWHIP = ReturnMinStatsValueForPitcher(batter1 => batter1.PitchingStats.WHIP);

            dgvPitchingLeaders.Rows.Add("W", "", GetFullNameOfLeaderForThisPitchingParameter(batter => batter.PitchingStats.Wins == maxWins), maxWins);
            dgvPitchingLeaders.Rows.Add("SV", "", GetFullNameOfLeaderForThisPitchingParameter(batter => batter.PitchingStats.Saves == maxSaves), maxSaves);
            dgvPitchingLeaders.Rows.Add("ERA", "", GetFullNameOfLeaderForThisPitchingParameter(batter => batter.PitchingStats.ERA == bestERA), bestERA.ToString("0.00", new CultureInfo("en-US")));
            dgvPitchingLeaders.Rows.Add("SO", "", GetFullNameOfLeaderForThisPitchingParameter(batter => batter.PitchingStats.Strikeouts == maxSO), maxSO);
            dgvPitchingLeaders.Rows.Add("WHIP", "", GetFullNameOfLeaderForThisPitchingParameter(batter => batter.PitchingStats.WHIP == bestWHIP), bestWHIP.ToString("0.00", new CultureInfo("en-US")));
            for (var i = 0; i < dgvPitchingLeaders.RowCount; i++)
            {
                if (dgvPitchingLeaders.Rows[i].Cells[2].Value.ToString() != "Tied")
                {
                    var pitchersWithThisValue = pitchers.Where(batter => batter.FullName == dgvPitchingLeaders.Rows[i].Cells[2].Value.ToString()).ToList();
                    Player currentPlayer;
                    if (pitchersWithThisValue.Count == 0)
                    {
                        var allPitchers = playersBL.GetPitchersStats("All Players").ToList();
                        currentPlayer = allPitchers.First(batter => batter.FullName == dgvPitchingLeaders.Rows[i].Cells[2].Value.ToString());
                    }
                    else currentPlayer = pitchersWithThisValue.First();

                    var manTeam = teams.First(team => team.TeamAbbreviation == currentPlayer.Team);
                    dgvPitchingLeaders.Rows[i].Cells[1].Style.BackColor = manTeam.TeamColor[0];
                    dgvPitchingLeaders.Rows[i].Cells[1].Style.SelectionBackColor = manTeam.TeamColor[0];
                }
                else
                {
                    dgvPitchingLeaders.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(220, 220, 220);
                    dgvPitchingLeaders.Rows[i].Cells[1].Style.SelectionBackColor = Color.FromArgb(220, 220, 220);
                }
            }
        }

        private void btnCloseResultsMenu_Click(object sender, EventArgs e) => Close();

        private void StatsMenuForm_Load(object sender, EventArgs e) => GetBattingLeaders();
    }
}