using Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VKR.BLL;
using System.Linq;
using System.Globalization;
using System.Drawing;

namespace VKR_Test
{
    public partial class StatsMenuForm : Form
    {
        private readonly PlayerBL playersBL;
        private readonly TeamsBL teamsBL;
        private List<Batter> batters;
        private List<Pitcher> pitchers;
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

        private TKey ReturnMaxStatsValueForBatter<TKey>(Func<Batter, TKey> key)
        {
            return batters.Select(key).Max();
        }

        private TKey ReturnMaxStatsValueForPitcher<TKey>(Func<Pitcher, TKey> key)
        {
            return pitchers.Select(key).Max();
        }

        private TKey ReturnMinStatsValueForPitcher<TKey>(Func<Pitcher, TKey> key)
        {
            return pitchers.Select(key).Min();
        }

        private TKey ReturnMaxStatsValueForPitcher<TKey>(Func<Pitcher, TKey> key, string Qualyfing)
        {
            List<Pitcher> pitchers = playersBL.GetPitchersStats(Qualyfing);
            return pitchers.Select(key).Max();
        }

        private string GetFullNameOfLeaderForThisBattingParameter(Func<Batter, bool> key)
        {
            int countOfBattersWithThisAVG = batters.Where(key).Count();
            if (countOfBattersWithThisAVG == 1)
            {
                return batters.Where(key).Select(batter => batter.FullName).First();
            }
            else
            {
                return "Tied";
            }
        }

        private string GetFullNameOfLeaderForThisPitchingParameter(Func<Pitcher, bool> key)
        {
            int countOfBattersWithThisAVG = pitchers.Where(key).Count();
            if (countOfBattersWithThisAVG == 0)
            {
                List<Pitcher> pitchers = playersBL.GetPitchersStats("All Players");
                countOfBattersWithThisAVG = pitchers.Where(key).Count();
                if (countOfBattersWithThisAVG == 1)
                {
                    return pitchers.Where(key).Select(pitcher => pitcher.FullName).First();
                }
                else
                {
                    return "Tied";
                }
            }
            else if (countOfBattersWithThisAVG == 1)
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
            dgvBattingLeaders.Rows.Add("AVG", "", GetFullNameOfLeaderForThisBattingParameter(batter => batter.AVG == ReturnMaxStatsValueForBatter(batter1 => batter1.AVG)), ReturnMaxStatsValueForBatter(batter1 => batter1.AVG).ToString("#.000", new CultureInfo("en-US")));
            dgvBattingLeaders.Rows.Add("HR", "", GetFullNameOfLeaderForThisBattingParameter(batter => batter.HomeRuns == ReturnMaxStatsValueForBatter(batter1 => batter1.HomeRuns)), ReturnMaxStatsValueForBatter(batter1 => batter1.HomeRuns));
            dgvBattingLeaders.Rows.Add("RBI", "", GetFullNameOfLeaderForThisBattingParameter(batter => batter.RBI == ReturnMaxStatsValueForBatter(batter1 => batter1.RBI)), ReturnMaxStatsValueForBatter(batter1 => batter1.RBI));
            dgvBattingLeaders.Rows.Add("SB", "", GetFullNameOfLeaderForThisBattingParameter(batter => batter.StolenBases == ReturnMaxStatsValueForBatter(batter1 => batter1.StolenBases)), ReturnMaxStatsValueForBatter(batter1 => batter1.StolenBases));
            dgvBattingLeaders.Rows.Add("R", "", GetFullNameOfLeaderForThisBattingParameter(batter => batter.Runs == ReturnMaxStatsValueForBatter(batter1 => batter1.Runs)), ReturnMaxStatsValueForBatter(batter1 => batter1.Runs));
            for (int i = 0; i < dgvBattingLeaders.RowCount; i++)
            {
                if (dgvBattingLeaders.Rows[i].Cells[2].Value.ToString() != "Tied")
                {
                    Batter currentbatter = batters.Where(batter => batter.FullName == dgvBattingLeaders.Rows[i].Cells[2].Value.ToString()).First();
                    Team ManTeam = teams.Where(team => team.TeamAbbreviation == currentbatter.Team).First();
                    dgvBattingLeaders.Rows[i].Cells[1].Style.BackColor = ManTeam.TeamColor[0];
                    dgvBattingLeaders.Rows[i].Cells[1].Style.SelectionBackColor = ManTeam.TeamColor[0];
                }
                else
                {
                    dgvBattingLeaders.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(220, 220, 220);
                    dgvBattingLeaders.Rows[i].Cells[1].Style.SelectionBackColor = Color.FromArgb(220, 220, 220);
                }
            }

            dgvPitchingLeaders.Rows.Clear();

            int maxSaves = ReturnMaxStatsValueForPitcher(batter1 => batter1.Saves, "All Players");

            dgvPitchingLeaders.Rows.Add("W", "", GetFullNameOfLeaderForThisPitchingParameter(batter => batter.Wins == ReturnMaxStatsValueForPitcher(batter1 => batter1.Wins)), ReturnMaxStatsValueForPitcher(batter1 => batter1.Wins));
            dgvPitchingLeaders.Rows.Add("SV", "", GetFullNameOfLeaderForThisPitchingParameter(batter => batter.Saves == maxSaves), maxSaves);
            dgvPitchingLeaders.Rows.Add("ERA", "", GetFullNameOfLeaderForThisPitchingParameter(batter => batter.ERA == ReturnMinStatsValueForPitcher(batter1 => batter1.ERA)), ReturnMinStatsValueForPitcher(batter1 => batter1.ERA).ToString("0.00", new CultureInfo("en-US")));
            dgvPitchingLeaders.Rows.Add("SO", "", GetFullNameOfLeaderForThisPitchingParameter(batter => batter.Strikeouts == ReturnMaxStatsValueForPitcher(batter1 => batter1.Strikeouts)), ReturnMaxStatsValueForPitcher(batter1 => batter1.Strikeouts));
            dgvPitchingLeaders.Rows.Add("WHIP", "", GetFullNameOfLeaderForThisPitchingParameter(batter => batter.WHIP == ReturnMinStatsValueForPitcher(batter1 => batter1.WHIP)), ReturnMinStatsValueForPitcher(batter1 => batter1.WHIP).ToString("0.00", new CultureInfo("en-US")));
            for (int i = 0; i < dgvPitchingLeaders.RowCount; i++)
            {
                if (dgvPitchingLeaders.Rows[i].Cells[2].Value.ToString() != "Tied")
                {
                    List<Pitcher> pitchersWithThisValue = pitchers.Where(batter => batter.FullName == dgvPitchingLeaders.Rows[i].Cells[2].Value.ToString()).ToList();
                    Pitcher currentbatter;
                    if (pitchersWithThisValue.Count == 0)
                    {
                        List<Pitcher> allPitchers = playersBL.GetPitchersStats("All Players").ToList();
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