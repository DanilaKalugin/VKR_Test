using Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VKR.BLL;
using System.Linq;
using System.Globalization;
using System.Drawing;
using System.Threading.Tasks;

namespace VKR_Test
{
    public partial class StatsMenuForm : Form
    {
        private readonly PlayerBL playersBL;
        private readonly TeamsBL teamsBL;
        private List<Player> batters;
        private List<Player> pitchers;
        private List<Team> teams;

        public StatsMenuForm()
        {
            InitializeComponent();
            playersBL = new PlayerBL();
            teamsBL = new TeamsBL();

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
            PlayerStatsForm form = new PlayerStatsForm(objects);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private TKey ReturnMaxStatsValueForBatter<TKey>(Func<Player, TKey> key)
        {
            return batters.Select(key).Max();
        }

        private TKey ReturnMaxStatsValueForPitcher<TKey>(Func<Player, TKey> key)
        {
            return pitchers.Select(key).Max();
        }

        private TKey ReturnMinStatsValueForPitcher<TKey>(Func<Player, TKey> key)
        {
            return pitchers.Select(key).Min();
        }

        private TKey ReturnMaxStatsValueForPitcher<TKey>(Func<Player, TKey> key, string Qualyfing)
        {
            var pitchers = playersBL.GetPitchersStats(Qualyfing);
            return pitchers.Select(key).Max();
        }

        private string GetFullNameOfLeaderForThisBattingParameter(Func<Player, bool> key)
        {
            int countOfBattersWithThisAVG = batters.Where(key).Count();

            if (countOfBattersWithThisAVG == 1)
            {
                return batters.Where(key).Select(batter => batter.FullName).First();
            }
            
            return "Tied";
        }

        private string GetFullNameOfLeaderForThisPitchingParameter(Func<Player, bool> key)
        {
            int countOfBattersWithThisAVG = pitchers.Where(key).Count();
            if (countOfBattersWithThisAVG == 0)
            {
                var pitchers = playersBL.GetPitchersStats("All Players");
                countOfBattersWithThisAVG = pitchers.Where(key).Count();

                if (countOfBattersWithThisAVG == 1)
                {
                    return pitchers.Where(key).Select(pitcher => pitcher.FullName).First();
                }

                return "Tied";
            }

            if (countOfBattersWithThisAVG == 1)
            {
                return pitchers.Where(key).Select(pitcher => pitcher.FullName).First();
            }
            else
            {
                return "Tied";
            }
        }

        private void GetBattingLeaders()
        {
            dgvBattingLeaders.Rows.Clear();
            var bestAVG = ReturnMaxStatsValueForBatter(batter1 => batter1.battingStats.AVG);
            var bestHR = ReturnMaxStatsValueForBatter(batter1 => batter1.battingStats.HomeRuns);
            var bestRBI = ReturnMaxStatsValueForBatter(batter1 => batter1.battingStats.RBI);
            var bestSB = ReturnMaxStatsValueForBatter(batter1 => batter1.battingStats.StolenBases);
            var bestR = ReturnMaxStatsValueForBatter(batter1 => batter1.battingStats.Runs);

            dgvBattingLeaders.Rows.Add("AVG", "", GetFullNameOfLeaderForThisBattingParameter(batter => batter.battingStats.AVG == bestAVG), bestAVG.ToString("#.000", new CultureInfo("en-US")));
            dgvBattingLeaders.Rows.Add("HR", "", GetFullNameOfLeaderForThisBattingParameter(batter => batter.battingStats.HomeRuns == bestHR), bestHR);
            dgvBattingLeaders.Rows.Add("RBI", "", GetFullNameOfLeaderForThisBattingParameter(batter => batter.battingStats.RBI == bestRBI), bestRBI);
            dgvBattingLeaders.Rows.Add("SB", "", GetFullNameOfLeaderForThisBattingParameter(batter => batter.battingStats.StolenBases == bestSB), bestSB);
            dgvBattingLeaders.Rows.Add("R", "", GetFullNameOfLeaderForThisBattingParameter(batter => batter.battingStats.Runs == bestR), bestR);

            for (int i = 0; i < dgvBattingLeaders.RowCount; i++)
            {
                if (dgvBattingLeaders.Rows[i].Cells[2].Value.ToString() == "Tied")
                {
                    dgvBattingLeaders.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(220, 220, 220);
                    dgvBattingLeaders.Rows[i].Cells[1].Style.SelectionBackColor = Color.FromArgb(220, 220, 220);
                }
                else
                {
                    var currentbatter = batters.Where(batter => batter.FullName == dgvBattingLeaders.Rows[i].Cells[2].Value.ToString()).First();
                    var ManTeam = teams.Where(team => team.TeamAbbreviation == currentbatter.Team).First();
                    dgvBattingLeaders.Rows[i].Cells[1].Style.BackColor = ManTeam.TeamColor[0];
                    dgvBattingLeaders.Rows[i].Cells[1].Style.SelectionBackColor = ManTeam.TeamColor[0];
                }
            }

            dgvPitchingLeaders.Rows.Clear();

            var maxSaves = ReturnMaxStatsValueForPitcher(batter1 => batter1.pitchingStats.Saves, "All Players");
            var maxWins = ReturnMaxStatsValueForPitcher(batter1 => batter1.pitchingStats.Wins);
            var bestERA = ReturnMinStatsValueForPitcher(batter1 => batter1.pitchingStats.ERA);
            var maxSO = ReturnMaxStatsValueForPitcher(batter1 => batter1.pitchingStats.Strikeouts);
            var bestWHIP = ReturnMinStatsValueForPitcher(batter1 => batter1.pitchingStats.WHIP);

            dgvPitchingLeaders.Rows.Add("W", "", GetFullNameOfLeaderForThisPitchingParameter(batter => batter.pitchingStats.Wins == maxWins), maxWins);
            dgvPitchingLeaders.Rows.Add("SV", "", GetFullNameOfLeaderForThisPitchingParameter(batter => batter.pitchingStats.Saves == maxSaves), maxSaves);
            dgvPitchingLeaders.Rows.Add("ERA", "", GetFullNameOfLeaderForThisPitchingParameter(batter => batter.pitchingStats.ERA == bestERA), bestERA.ToString("0.00", new CultureInfo("en-US")));
            dgvPitchingLeaders.Rows.Add("SO", "", GetFullNameOfLeaderForThisPitchingParameter(batter => batter.pitchingStats.Strikeouts == maxSO), maxSO);
            dgvPitchingLeaders.Rows.Add("WHIP", "", GetFullNameOfLeaderForThisPitchingParameter(batter => batter.pitchingStats.WHIP == bestWHIP), bestWHIP.ToString("0.00", new CultureInfo("en-US")));
            for (int i = 0; i < dgvPitchingLeaders.RowCount; i++)
            {
                if (dgvPitchingLeaders.Rows[i].Cells[2].Value.ToString() != "Tied")
                {
                    List<Player> pitchersWithThisValue = pitchers.Where(batter => batter.FullName == dgvPitchingLeaders.Rows[i].Cells[2].Value.ToString()).ToList();
                    Player currentbatter;
                    if (pitchersWithThisValue.Count == 0)
                    {
                        var allPitchers = playersBL.GetPitchersStats("All Players").ToList();
                        currentbatter = allPitchers.Where(batter => batter.FullName == dgvPitchingLeaders.Rows[i].Cells[2].Value.ToString()).First();
                    }
                    else
                    {
                        currentbatter = pitchersWithThisValue.First();
                    }
                    Team ManTeam = teams.Where(team => team.TeamAbbreviation == currentbatter.Team).First();
                    dgvPitchingLeaders.Rows[i].Cells[1].Style.BackColor = ManTeam.TeamColor[0];
                    dgvPitchingLeaders.Rows[i].Cells[1].Style.SelectionBackColor = ManTeam.TeamColor[0];
                }
                else
                {
                    dgvPitchingLeaders.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(220, 220, 220);
                    dgvPitchingLeaders.Rows[i].Cells[1].Style.SelectionBackColor = Color.FromArgb(220, 220, 220);
                }
            }
        }

        private void btnCloseResultsMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StatsMenuForm_Load(object sender, EventArgs e)
        {
            GetBattingLeaders();
        }
    }
}