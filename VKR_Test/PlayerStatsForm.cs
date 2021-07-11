using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class PlayerStatsForm : Form
    {
        private readonly PlayerBL playersBL;
        private readonly TeamsBL teamsBL;
        private List<Team> teams;
        List<Batter> batters;
        List<Pitcher> pitchers;
        List<Team> teamBattingStats, teamPitchingStats;
        private enum SortMode { Ascending, Descending };
        private enum PlayerType { Pitchers, Batters };
        private enum StatsType { Standard, Expanded };
        public enum SortingObjects { Players, Teams };
        private SortMode[][] sortModes;
        private PlayerType playerType;
        private StatsType statsType;
        private SortingObjects objects;
        private int lastBattingSort = 11;
        private int lastPitchingSort = 2;

        public PlayerStatsForm(SortingObjects sortingObject)
        {
            InitializeComponent();

            playersBL = new PlayerBL();
            teamsBL = new TeamsBL();
            teams = teamsBL.GetAllTeams().ToList();
            objects = sortingObject;
            sortModes = new SortMode[2][];
            sortModes[0] = new SortMode[dataGridView1.ColumnCount - 3 + dataGridView2.ColumnCount - 3];
            sortModes[1] = new SortMode[dataGridView3.ColumnCount - 3 + dataGridView4.ColumnCount - 3];
            sortModes[0][11] = SortMode.Descending;
        }

        private void ShowNewStats(PlayerType playerType, StatsType statsType)
        {
            panelStandardBatterStats.Visible = playerType == PlayerType.Batters && statsType == StatsType.Standard;
            panelExpandedBatterStats.Visible = playerType == PlayerType.Batters && statsType == StatsType.Expanded;
            panelStandardPitcherStats.Visible = playerType == PlayerType.Pitchers && statsType == StatsType.Standard;
            panelExpandedPitcherStats.Visible = playerType == PlayerType.Pitchers && statsType == StatsType.Expanded;

            btnExpandedStats.BackColor = statsType == StatsType.Expanded ? Color.LightGray : Color.DarkGray;
            btnStandardStats.BackColor = statsType == StatsType.Standard ? Color.LightGray : Color.DarkGray;
            btnHitting.BackColor = playerType == PlayerType.Batters ? Color.LightGray : Color.DarkGray;
            btnPitching.BackColor = playerType == PlayerType.Pitchers ? Color.LightGray : Color.DarkGray;
            cbPositions.Visible = playerType == PlayerType.Batters && objects == SortingObjects.Players;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                sortModes[0][e.ColumnIndex - 3] = sortModes[0][e.ColumnIndex - 3] == SortMode.Ascending ? SortMode.Descending : SortMode.Ascending;
                lastBattingSort = e.ColumnIndex - 3;
            }
            GetSortedListsBySortingCodes(lastBattingSort, lastPitchingSort);
        }

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                sortModes[0][dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3] = sortModes[0][dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3] == SortMode.Ascending ? SortMode.Descending : SortMode.Ascending;
                lastBattingSort = dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3;
            }
            GetSortedListsBySortingCodes(lastBattingSort, lastPitchingSort);
        }

        private void GetSortedListsBySortingCodes(int batting, int pitching)
        {
            switch (batting)
            {
                case 0:
                    {
                        if (sortModes[0][0] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.Games);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.TGP);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.Games);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.TGP);
                        }
                        break;
                    }
                case 1:
                    {
                        if (sortModes[0][1] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.AtBats);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.AtBats);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.AtBats);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.AtBats);
                        }
                        break;
                    }
                case 2:
                    {
                        if (sortModes[0][2] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.Runs);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.Runs);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.Runs);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.Runs);
                        }
                        break;
                    }
                case 3:
                    {
                        if (sortModes[0][3] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.Hits);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.Hits);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.Hits);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.Hits);
                        }
                        break;
                    }
                case 4:
                    {
                        if (sortModes[0][4] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.Doubles);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.Doubles);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.Doubles);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.Doubles);
                        }
                        break;
                    }
                case 5:
                    {
                        if (sortModes[0][5] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.Triples);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.Triples);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.Triples);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.Triples);
                        }
                        break;
                    }
                case 6:
                    {
                        if (sortModes[0][6] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.HomeRuns);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.HomeRuns);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.HomeRuns);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.HomeRuns);
                        }
                        break;
                    }
                case 7:
                    {
                        if (sortModes[0][7] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.RBI);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.RBI);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.RBI);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.RBI);
                        }
                        break;
                    }
                case 8:
                    {
                        if (sortModes[0][8] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.Walks);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.Walks);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.Walks);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.Walks);
                        }
                        break;
                    }
                case 9:
                    {
                        if (sortModes[0][9] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.StolenBases);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.StolenBases);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.StolenBases);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.StolenBases);
                        }
                        break;
                    }
                case 10:
                    {
                        if (sortModes[0][10] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.CaughtStealing);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.CaughtStealing);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.CaughtStealing);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.CaughtStealing);
                        }
                        break;
                    }
                case 11:
                    {
                        if (sortModes[0][11] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.AVG);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.AVG);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.AVG);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.AVG);
                        }
                        break;
                    }
                case 12:
                    {
                        if (sortModes[0][12] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.OBP);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.OBP);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.OBP);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.OBP);
                        }
                        break;
                    }
                case 13:
                    {
                        if (sortModes[0][13] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.SLG);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.SLG);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.SLG);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.SLG);
                        }
                        break;
                    }
                case 14:
                    {
                        if (sortModes[0][14] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.OPS);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.OPS);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.OPS);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.OPS);
                        }
                        break;
                    }
                case 15:
                    {
                        if (sortModes[0][15] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.PA);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.PA);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.PA);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.PA);
                        }
                        break;
                    }
                case 16:
                    {
                        if (sortModes[0][16] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.HitByPitch);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.HitByPitch);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.HitByPitch);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.HitByPitch);
                        }
                        break;
                    }
                case 17:
                    {
                        if (sortModes[0][17] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.SacrificeBunts);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.SacrificeBunts);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.SacrificeBunts);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.SacrificeBunts);
                        }
                        break;
                    }
                case 18:
                    {
                        if (sortModes[0][18] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.SacrificeFlies);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.SacrificeFlies);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.SacrificeFlies);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.SacrificeFlies);
                        }
                        break;
                    }
                case 19:
                    {
                        if (sortModes[0][19] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.DoublePlay);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.DoublePlay);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.DoublePlay);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.DoublePlay);
                        }
                        break;
                    }
                case 20:
                    {
                        if (sortModes[0][20] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.GOtoAO);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.GOtoAO);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.GOtoAO);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.GOtoAO);
                        }
                        break;
                    }
                case 21:
                    {
                        if (sortModes[0][21] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.XBH);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.XBH);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.XBH);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.XBH);
                        }
                        break;
                    }
                case 22:
                    {
                        if (sortModes[0][22] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.TotalBases);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.TotalBases);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.TotalBases);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.TotalBases);
                        }
                        break;
                    }
                case 23:
                    {
                        if (sortModes[0][23] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.ISO);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.ISO);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.ISO);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.ISO);
                        }
                        break;
                    }
                case 24:
                    {
                        if (sortModes[0][24] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.ABperHR);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.ABperHR);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.ABperHR);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.ABperHR);
                        }
                        break;
                    }
                case 25:
                    {
                        if (sortModes[0][25] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.WalkToStrikeout);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.WalkToStrikeout);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.WalkToStrikeout);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.WalkToStrikeout);
                        }
                        break;
                    }
                case 26:
                    {
                        if (sortModes[0][26] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.WalkPercentage);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.WalkPercentage);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.WalkPercentage);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.WalkPercentage);
                        }
                        break;
                    }
                case 27:
                    {
                        if (sortModes[0][27] == SortMode.Descending)
                        {
                            batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.StrikeoutPercentage);
                            teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.StrikeoutPercentage);
                        }
                        else
                        {
                            batters = playersBL.GetSortedBattersStats(batters, batter => batter.StrikeoutPercentage);
                            teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.StrikeoutPercentage);
                        }
                        break;
                    }
            }
            switch (pitching)
            {
                case 0:
                    {
                        if (sortModes[1][0] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.Wins);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.Wins);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.Wins);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.Wins);
                        }
                        break;
                    }
                case 1:
                    {
                        if (sortModes[1][1] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.Losses);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.Losses);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.Losses);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.Losses);
                        }
                        break;
                    }
                case 2:
                    {
                        if (sortModes[1][2] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.ERA);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.ERA);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.ERA);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.ERA);
                        }
                        break;
                    }
                case 3:
                    {
                        if (sortModes[1][3] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.Games);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.TGP);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.Games);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.TGP);
                        }
                        break;
                    }
                case 4:
                    {
                        if (sortModes[1][4] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.CompleteGames);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.CompleteGames);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.CompleteGames);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.CompleteGames);
                        }
                        break;
                    }
                case 5:
                    {
                        if (sortModes[1][5] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.Shutouts);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.Shutouts);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.Shutouts);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.Shutouts);
                        }
                        break;
                    }
                case 6:
                    {
                        if (sortModes[1][6] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.IP);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.IP);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.IP);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.IP);
                        }
                        break;
                    }
                case 7:
                    {
                        if (sortModes[1][7] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.HitsAllowed);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.HitsAllowed);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.HitsAllowed);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.HitsAllowed);
                        }
                        break;
                    }
                case 8:
                    {
                        if (sortModes[1][8] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.RunsAllowed);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.RunsAllowed);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.RunsAllowed);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.RunsAllowed);
                        }
                        break;
                    }
                case 9:
                    {
                        if (sortModes[1][9] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.HomeRunsAllowed);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.HomeRunsAllowed);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.HomeRunsAllowed);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.HomeRunsAllowed);
                        }
                        break;
                    }
                case 10:
                    {
                        if (sortModes[1][10] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.HitByPitch);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.HitByPitch);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.HitByPitch);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.HitByPitch);
                        }
                        break;
                    }
                case 11:
                    {
                        if (sortModes[1][11] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.WalksAllowed);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.WalksAllowed);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.WalksAllowed);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.WalksAllowed);
                        }
                        break;
                    }
                case 12:
                    {
                        if (sortModes[1][12] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.Strikeouts);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.Strikeouts);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.Strikeouts);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.Strikeouts);
                        }
                        break;
                    }
                case 13:
                    {
                        if (sortModes[1][13] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.WHIP);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.WHIP);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.WHIP);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.WHIP);
                        }
                        break;
                    }
                case 14:
                    {
                        if (sortModes[1][14] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.BAA);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.BAA);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.BAA);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.BAA);
                        }
                        break;
                    }
                case 15:
                    {
                        if (sortModes[1][15] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.TotalBattersFaced);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.TotalBattersFaced);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.TotalBattersFaced);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.TotalBattersFaced);
                        }
                        break;
                    }
                case 16:
                    {
                        if (sortModes[1][16] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.QualityStarts);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.QualityStarts);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.QualityStarts);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.QualityStarts);
                        }
                        break;
                    }
                case 17:
                    {
                        if (sortModes[1][17] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.DoublePlays);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.DoublePlays);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.DoublePlays);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.DoublePlays);
                        }
                        break;
                    }
                case 18:
                    {
                        if (sortModes[1][18] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.GOtoAO);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.GOtoAO);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.GOtoAO);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.GOtoAO);
                        }
                        break;
                    }
                case 19:
                    {
                        if (sortModes[1][19] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.KperNineInnings);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.KperNineInnings);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.KperNineInnings);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.KperNineInnings);
                        }
                        break;
                    }
                case 20:
                    {
                        if (sortModes[1][20] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.BBperNineInnings);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.BBperNineInnings);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.BBperNineInnings);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.BBperNineInnings);
                        }
                        break;
                    }
                case 21:
                    {
                        if (sortModes[1][21] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.KperBB);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.KperBB);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.KperBB);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.KperBB);
                        }
                        break;
                    }
                case 22:
                    {
                        if (sortModes[1][22] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.StolenBasesAllowed);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.StolenBasesAllowed);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.StolenBasesAllowed);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.StolenBasesAllowed);
                        }
                        break;
                    }
                case 23:
                    {
                        if (sortModes[1][23] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.CaughtStealing);
                            teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.CaughtStealing);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.CaughtStealing);
                            teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.CaughtStealing);
                        }
                        break;
                    }
            }
            FillBattersAndPitchersTable(batters, pitchers, teamBattingStats, teamPitchingStats);
        }

        private void dataGridView4_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                sortModes[1][dataGridView3.ColumnCount - 3 + e.ColumnIndex - 3] = sortModes[0][dataGridView3.ColumnCount - 3 + e.ColumnIndex - 3] == SortMode.Ascending ? SortMode.Descending : SortMode.Ascending;
                lastPitchingSort = dataGridView3.ColumnCount - 3 + e.ColumnIndex - 3;
            }
            GetSortedListsBySortingCodes(lastBattingSort, lastPitchingSort);
        }

        private void dataGridView3_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                sortModes[1][e.ColumnIndex - 3] = sortModes[1][e.ColumnIndex - 3] == SortMode.Ascending ? SortMode.Descending : SortMode.Ascending;
                lastPitchingSort = e.ColumnIndex - 3;
            }
            GetSortedListsBySortingCodes(lastBattingSort, lastPitchingSort);
        }

        private void btnHitting_Click(object sender, EventArgs e)
        {
            playerType = PlayerType.Batters;
            ShowNewStats(playerType, statsType);
        }

        private void btnPitching_Click(object sender, EventArgs e)
        {
            playerType = PlayerType.Pitchers;
            ShowNewStats(playerType, statsType);
        }

        private void btnStandardStats_Click(object sender, EventArgs e)
        {
            statsType = StatsType.Standard;
            ShowNewStats(playerType, statsType);
        }

        private void btnExpandedStats_Click(object sender, EventArgs e)
        {
            statsType = StatsType.Expanded;
            ShowNewStats(playerType, statsType);
        }

        private void FillBattersAndPitchersTable(List<Batter> batters, List<Pitcher> pitchers, List<Team> teamBatting, List<Team> teamPitching)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            if (objects == SortingObjects.Players)
            {
                for (int i = 0; i < batters.Count; i++)
                {
                    dataGridView1.Rows.Add(i + 1,
                                            "",
                                            batters[i].FullName,
                                            batters[i].Games,
                                            batters[i].AtBats,
                                            batters[i].Runs,
                                            batters[i].Hits,
                                            batters[i].Doubles,
                                            batters[i].Triples,
                                            batters[i].HomeRuns,
                                            batters[i].RBI,
                                            batters[i].Walks,
                                            batters[i].StolenBases,
                                            batters[i].CaughtStealing,
                                            batters[i].AVG.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].OBP.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].SLG.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].OPS.ToString("#.000", new CultureInfo("en-US")));

                    GetCorrectColorForCell(dataGridView1, i, batters[i].Team);
                    dataGridView2.Rows.Add(i + 1,
                                            "",
                                            batters[i].FullName,
                                            batters[i].PA,
                                            batters[i].HitByPitch,
                                            batters[i].SacrificeBunts,
                                            batters[i].SacrificeFlies,
                                            batters[i].DoublePlay,
                                            batters[i].GOtoAO.ToString("0.00", new CultureInfo("en-US")),
                                            batters[i].XBH,
                                            batters[i].TotalBases,
                                            batters[i].ISO.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].ABperHR.ToString("0.00", new CultureInfo("en-US")),
                                            batters[i].WalkToStrikeout.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].WalkPercentage.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].StrikeoutPercentage.ToString("#.000", new CultureInfo("en-US")));
                    GetCorrectColorForCell(dataGridView2, i, batters[i].Team);
                }
                for (int i = 0; i < pitchers.Count; i++)
                {
                    dataGridView3.Rows.Add(i + 1,
                                            "",
                                            pitchers[i].FullName,
                                            pitchers[i].Wins,
                                            pitchers[i].Losses,
                                            pitchers[i].ERA.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].Games,
                                            pitchers[i].CompleteGames,
                                            pitchers[i].Shutouts,
                                            pitchers[i].IP.ToString("0.0", new CultureInfo("en-US")),
                                            pitchers[i].HitsAllowed,
                                            pitchers[i].RunsAllowed,
                                            pitchers[i].HomeRunsAllowed,
                                            pitchers[i].HitByPitch,
                                            pitchers[i].WalksAllowed,
                                            pitchers[i].Strikeouts,
                                            pitchers[i].WHIP.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].BAA.ToString("#.000", new CultureInfo("en-US")));
                    GetCorrectColorForCell(dataGridView3, i, pitchers[i].Team);

                    dataGridView4.Rows.Add(i + 1,
                                            "",
                                            pitchers[i].FullName,
                                            pitchers[i].TotalBattersFaced,
                                            pitchers[i].QualityStarts,
                                            pitchers[i].DoublePlays,
                                            pitchers[i].GOtoAO.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].KperNineInnings.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].BBperNineInnings.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].KperBB.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].StolenBasesAllowed,
                                            pitchers[i].CaughtStealing);
                    GetCorrectColorForCell(dataGridView4, i, pitchers[i].Team);
                }
            }
            else
            {
                for (int i = 0; i < teamBatting.Count; i++)
                {
                    dataGridView1.Rows.Add(i + 1,
                                            "",
                                            teamBatting[i].TeamTitle,
                                            teamBatting[i].TGP,
                                            teamBatting[i].AtBats,
                                            teamBatting[i].Runs,
                                            teamBatting[i].Hits,
                                            teamBatting[i].Doubles,
                                            teamBatting[i].Triples,
                                            teamBatting[i].HomeRuns,
                                            teamBatting[i].RBI,
                                            teamBatting[i].Walks,
                                            teamBatting[i].StolenBases,
                                            teamBatting[i].CaughtStealing,
                                            teamBatting[i].AVG.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].OBP.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].SLG.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].OPS.ToString("#.000", new CultureInfo("en-US")));
                    dataGridView1.Rows[i].Cells[1].Style.BackColor = teamBatting[i].TeamColor[0];
                    dataGridView1.Rows[i].Cells[1].Style.SelectionBackColor = teamBatting[i].TeamColor[0];
                    dataGridView2.Rows.Add(i + 1,
                                            "",
                                            teamBatting[i].TeamTitle,
                                            teamBatting[i].PA,
                                            teamBatting[i].HitByPitch,
                                            teamBatting[i].SacrificeBunts,
                                            teamBatting[i].SacrificeFlies,
                                            teamBatting[i].DoublePlay,
                                            teamBatting[i].GOtoAO.ToString("0.00", new CultureInfo("en-US")),
                                            teamBatting[i].XBH,
                                            teamBatting[i].TotalBases,
                                            teamBatting[i].ISO.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].ABperHR.ToString("0.00", new CultureInfo("en-US")),
                                            teamBatting[i].WalkToStrikeout.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].WalkPercentage.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].StrikeoutPercentage.ToString("#.000", new CultureInfo("en-US")));
                    dataGridView2.Rows[i].Cells[1].Style.BackColor = teamBatting[i].TeamColor[0];
                    dataGridView2.Rows[i].Cells[1].Style.SelectionBackColor = teamBatting[i].TeamColor[0];
                }
                for (int i = 0; i < teamPitching.Count; i++)
                {
                    dataGridView3.Rows.Add(i + 1,
                                            "",
                                            teamPitching[i].TeamTitle,
                                            teamPitching[i].Wins,
                                            teamPitching[i].Losses,
                                            teamPitching[i].ERA.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].TGP,
                                            teamPitching[i].CompleteGames,
                                            teamPitching[i].Shutouts,
                                            teamPitching[i].IP.ToString("0.0", new CultureInfo("en-US")),
                                            teamPitching[i].HitsAllowed,
                                            teamPitching[i].RunsAllowed,
                                            teamPitching[i].HomeRunsAllowed,
                                            teamPitching[i].HitByPitch,
                                            teamPitching[i].WalksAllowed,
                                            teamPitching[i].Strikeouts,
                                            teamPitching[i].WHIP.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].BAA.ToString("#.000", new CultureInfo("en-US")));
                    dataGridView3.Rows[i].Cells[1].Style.BackColor = teamPitching[i].TeamColor[0];
                    dataGridView3.Rows[i].Cells[1].Style.SelectionBackColor = teamPitching[i].TeamColor[0];
                    dataGridView4.Rows.Add(i + 1,
                                            "",
                                            teamPitching[i].TeamTitle,
                                            teamPitching[i].TotalBattersFaced,
                                            teamPitching[i].QualityStarts,
                                            teamPitching[i].DoublePlays,
                                            teamPitching[i].GOtoAO.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].KperNineInnings.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].BBperNineInnings.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].KperBB.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].StolenBasesAllowed,
                                            teamPitching[i].CaughtStealing);
                    dataGridView4.Rows[i].Cells[1].Style.BackColor = teamPitching[i].TeamColor[0];
                    dataGridView4.Rows[i].Cells[1].Style.SelectionBackColor = teamPitching[i].TeamColor[0];
                }
            }
        }


        private void GetCorrectColorForCell(DataGridView dgv, int RowNumber, string TeamForThisPlayer)
        {
            if (TeamForThisPlayer != "")
            {
                dgv.Rows[RowNumber].Cells[1].Style.BackColor = teams.Where(team => team.TeamAbbreviation == TeamForThisPlayer).First().TeamColor[0];
                dgv.Rows[RowNumber].Cells[1].Style.SelectionBackColor = teams.Where(team => team.TeamAbbreviation == TeamForThisPlayer).First().TeamColor[0];
            }
            else
            {
                dgv.Rows[RowNumber].Cells[1].Style.BackColor = Color.FromArgb(220, 220, 220);
                dgv.Rows[RowNumber].Cells[1].Style.SelectionBackColor = Color.FromArgb(220, 220, 220);
            }
        }

        private void dataGridView4_CellStyleChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor;
        }

        private void PlayerStatsForm_Load(object sender, EventArgs e)
        {
            batters = playersBL.GetBattersStats();
            pitchers = playersBL.GetPitchersStats();
            teamBattingStats = teamsBL.GetTeamBattingStats();
            teamPitchingStats = teamsBL.GetTeamPitchingStats();

            playerType = PlayerType.Batters;
            statsType = StatsType.Standard;
            cbPlayers.DataSource = cbPlayers.Items;
            ShowNewStats(playerType, statsType);
            List<string> teamsInComboBox = new List<string>
            {
                "MLB"
            };
            teamsInComboBox.AddRange(teams.Select(team => team.TeamTitle).ToList());
            cbTeams.DataSource = teamsInComboBox;

            cbPositions.DataSource = playersBL.GetPlayerPositions();
            cbPositions.DisplayMember = "FullTitle";
            cbPositions.ValueMember = "ShortTitle";

            cbPlayers.Visible = objects == SortingObjects.Players;
            cbTeams.Visible = objects == SortingObjects.Players;
            cbPositions.Visible = objects == SortingObjects.Players;

            Text = objects == SortingObjects.Players ? "Player statistics" : "Team statistics";
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTeams.Items != null && cbPositions.DataSource != null)
            {
                if (cbPositions.SelectedValue is PlayerPosition)
                {
                    batters = playersBL.GetBattersStats(cbTeams.SelectedValue.ToString(), cbPlayers.Text, (cbPositions.SelectedValue as PlayerPosition).ShortTitle);
                }
                else
                {
                    batters = playersBL.GetBattersStats(cbTeams.SelectedValue.ToString(), cbPlayers.Text, cbPositions.SelectedValue.ToString());
                }
                pitchers = playersBL.GetPitchersStats(cbTeams.Text, cbPlayers.Text);
                GetSortedListsBySortingCodes(lastBattingSort, lastPitchingSort);
            }
        }
    }
}