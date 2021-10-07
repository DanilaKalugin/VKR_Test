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
                sortModes[0][e.ColumnIndex - 3] = (sortModes[0][e.ColumnIndex - 3] == SortMode.Descending && lastBattingSort == e.ColumnIndex - 3) ? SortMode.Ascending : SortMode.Descending;
                lastBattingSort = e.ColumnIndex - 3;
            }
            GetSortedListsBySortingCodes(lastBattingSort, lastPitchingSort, objects);
        }

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                if (e.ColumnIndex == 8 || e.ColumnIndex == 12 || e.ColumnIndex == 15)
                {
                    sortModes[0][dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3] = (sortModes[0][dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3] == SortMode.Ascending && lastBattingSort == dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3) ? SortMode.Descending : SortMode.Ascending;
                }
                else
                {
                    sortModes[0][dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3] = (sortModes[0][dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3] == SortMode.Descending && lastBattingSort == dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3) ? SortMode.Ascending : SortMode.Descending;
                }
                lastBattingSort = dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3;
            }
            GetSortedListsBySortingCodes(lastBattingSort, lastPitchingSort, objects);
        }

        private void GetSortedListsBySortingCodes(int batting, int pitching, SortingObjects obj)
        {
            if (obj == SortingObjects.Players)
            {
                switch (batting)
                {
                    case 0:
                        {
                            if (sortModes[0][0] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.Games);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.Games);
                            }
                            break;
                        }
                    case 1:
                        {
                            if (sortModes[0][1] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.AtBats);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.AtBats);
                            }
                            break;
                        }
                    case 2:
                        {
                            if (sortModes[0][2] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.Runs);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.Runs);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (sortModes[0][3] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.Hits);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.Hits);
                            }
                            break;
                        }
                    case 4:
                        {
                            if (sortModes[0][4] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.Doubles);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.Doubles);
                            }
                            break;
                        }
                    case 5:
                        {
                            if (sortModes[0][5] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.Triples);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.Triples);
                            }
                            break;
                        }
                    case 6:
                        {
                            if (sortModes[0][6] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.HomeRuns);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.HomeRuns);
                            }
                            break;
                        }
                    case 7:
                        {
                            if (sortModes[0][7] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.RBI);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.RBI);
                            }
                            break;
                        }
                    case 8:
                        {
                            if (sortModes[0][8] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.Walks);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.Walks);
                            }
                            break;
                        }
                    case 9:
                        {
                            if (sortModes[0][9] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.StolenBases);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.StolenBases);
                            }
                            break;
                        }
                    case 10:
                        {
                            if (sortModes[0][10] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.CaughtStealing);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.CaughtStealing);
                            }
                            break;
                        }
                    case 11:
                        {
                            if (sortModes[0][11] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.AVG);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.AVG);
                            }
                            break;
                        }
                    case 12:
                        {
                            if (sortModes[0][12] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.OBP);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.OBP);
                            }
                            break;
                        }
                    case 13:
                        {
                            if (sortModes[0][13] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.SLG);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.SLG);
                            }
                            break;
                        }
                    case 14:
                        {
                            if (sortModes[0][14] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.OPS);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.OPS);
                            }
                            break;
                        }
                    case 15:
                        {
                            if (sortModes[0][15] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.PA);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.PA);
                            }
                            break;
                        }
                    case 16:
                        {
                            if (sortModes[0][16] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.HitByPitch);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.HitByPitch);
                            }
                            break;
                        }
                    case 17:
                        {
                            if (sortModes[0][17] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.SacrificeBunts);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.SacrificeBunts);
                            }
                            break;
                        }
                    case 18:
                        {
                            if (sortModes[0][18] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.SacrificeFlies);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.SacrificeFlies);
                            }
                            break;
                        }
                    case 19:
                        {
                            if (sortModes[0][19] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.DoublePlay);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.DoublePlay);
                            }
                            break;
                        }
                    case 20:
                        {
                            if (sortModes[0][20] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.GOtoAO);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.GOtoAO);
                            }
                            break;
                        }
                    case 21:
                        {
                            if (sortModes[0][21] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.XBH);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.XBH);
                            }
                            break;
                        }
                    case 22:
                        {
                            if (sortModes[0][22] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.TotalBases);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.TotalBases);
                            }
                            break;
                        }
                    case 23:
                        {
                            if (sortModes[0][23] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.ISO);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.ISO);
                            }
                            break;
                        }
                    case 24:
                        {
                            if (sortModes[0][24] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.ABperHR);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.ABperHR);
                            }
                            break;
                        }
                    case 25:
                        {
                            if (sortModes[0][25] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.WalkToStrikeout);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.WalkToStrikeout);
                            }
                            break;
                        }
                    case 26:
                        {
                            if (sortModes[0][26] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.WalkPercentage);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.WalkPercentage);
                            }
                            break;
                        }
                    case 27:
                        {
                            if (sortModes[0][27] == SortMode.Descending)
                            {
                                batters = playersBL.GetSortedBattersStatsDesc(batters, batter => batter.StrikeoutPercentage);
                            }
                            else
                            {
                                batters = playersBL.GetSortedBattersStats(batters, batter => batter.StrikeoutPercentage);
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
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.Wins);
                            }
                            break;
                        }
                    case 1:
                        {
                            if (sortModes[1][1] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.Losses);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.Losses);
                            }
                            break;
                        }
                    case 2:
                        {
                            if (sortModes[1][2] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.ERA);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.ERA);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (sortModes[1][3] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.Games);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.Games);
                            }
                            break;
                        }
                    case 4:
                        {
                            if (sortModes[1][3] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.GamesStarted);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.GamesStarted);
                            }
                            break;
                        }
                    case 5:
                        {
                            if (sortModes[1][5] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.CompleteGames);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.CompleteGames);
                            }
                            break;
                        }
                    case 6:
                        {
                            if (sortModes[1][6] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.Shutouts);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.Shutouts);
                            }
                            break;
                        }
                    case 7:
                        {
                            if (sortModes[1][7] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.Saves);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.Saves);
                            }
                            break;
                        }
                    case 8:
                        {
                            if (sortModes[1][8] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.IP);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.IP);
                            }
                            break;
                        }
                    case 9:
                        {
                            if (sortModes[1][9] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.HitsAllowed);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.HitsAllowed);
                            }
                            break;
                        }
                    case 10:
                        {
                            if (sortModes[1][10] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.RunsAllowed);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.RunsAllowed);
                            }
                            break;
                        }
                    case 11:
                        {
                            if (sortModes[1][11] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.HomeRunsAllowed);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.HomeRunsAllowed);
                            }
                            break;
                        }
                    case 12:
                        {
                            if (sortModes[1][12] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.HitByPitch);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.HitByPitch);
                            }
                            break;
                        }
                    case 13:
                        {
                            if (sortModes[1][13] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.WalksAllowed);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.WalksAllowed);
                            }
                            break;
                        }
                    case 14:
                        {
                            if (sortModes[1][14] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.Strikeouts);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.Strikeouts);
                            }
                            break;
                        }
                    case 15:
                        {
                            if (sortModes[1][15] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.WHIP);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.WHIP);
                            }
                            break;
                        }
                    case 16:
                        {
                            if (sortModes[1][16] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.BAA);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.BAA);
                            }
                            break;
                        }
                    case 17:
                        {
                            if (sortModes[1][17] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.TotalBattersFaced);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.TotalBattersFaced);
                            }
                            break;
                        }
                    case 18:
                        {
                            if (sortModes[1][18] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.QualityStarts);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.QualityStarts);
                            }
                            break;
                        }
                    case 19:
                        {
                            if (sortModes[1][19] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.Holds);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.Holds);
                            }
                            break;
                        }
                    case 20:
                        {
                            if (sortModes[1][20] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.DoublePlays);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.DoublePlays);
                            }
                            break;
                        }
                    case 21:
                        {
                            if (sortModes[1][21] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.GOtoAO);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.GOtoAO);
                            }
                            break;
                        }
                    case 22:
                        {
                            if (sortModes[1][22] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.KperNineInnings);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.KperNineInnings);
                            }
                            break;
                        }
                    case 23:
                        {
                            if (sortModes[1][23] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.BBperNineInnings);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.BBperNineInnings);
                            }
                            break;
                        }
                    case 24:
                        {
                            if (sortModes[1][24] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.KperBB);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.KperBB);
                            }
                            break;
                        }
                    case 25:
                        {
                            if (sortModes[1][25] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.StolenBasesAllowed);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.StolenBasesAllowed);
                            }
                            break;
                        }
                    case 26:
                        {
                            if (sortModes[1][26] == SortMode.Descending)
                            {
                                pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.CaughtStealing);
                            }
                            else
                            {
                                pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.CaughtStealing);
                            }
                            break;
                        }
                }
            }
            else
            {
                switch (batting)
                {
                    case 0:
                        {
                            if (sortModes[0][0] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.TGP);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.TGP);
                            }
                            break;
                        }
                    case 1:
                        {
                            if (sortModes[0][1] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.AtBats);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.AtBats);
                            }
                            break;
                        }
                    case 2:
                        {
                            if (sortModes[0][2] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.Runs);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.Runs);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (sortModes[0][3] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.Hits);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.Hits);
                            }
                            break;
                        }
                    case 4:
                        {
                            if (sortModes[0][4] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.Doubles);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.Doubles);
                            }
                            break;
                        }
                    case 5:
                        {
                            if (sortModes[0][5] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.Triples);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.Triples);
                            }
                            break;
                        }
                    case 6:
                        {
                            if (sortModes[0][6] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.HomeRuns);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.HomeRuns);
                            }
                            break;
                        }
                    case 7:
                        {
                            if (sortModes[0][7] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.RBI);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.RBI);
                            }
                            break;
                        }
                    case 8:
                        {
                            if (sortModes[0][8] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.Walks);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.Walks);
                            }
                            break;
                        }
                    case 9:
                        {
                            if (sortModes[0][9] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.StolenBases);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.StolenBases);
                            }
                            break;
                        }
                    case 10:
                        {
                            if (sortModes[0][10] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.CaughtStealing);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.CaughtStealing);
                            }
                            break;
                        }
                    case 11:
                        {
                            if (sortModes[0][11] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.AVG);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.AVG);
                            }
                            break;
                        }
                    case 12:
                        {
                            if (sortModes[0][12] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.OBP);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.OBP);
                            }
                            break;
                        }
                    case 13:
                        {
                            if (sortModes[0][13] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.SLG);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.SLG);
                            }
                            break;
                        }
                    case 14:
                        {
                            if (sortModes[0][14] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.OPS);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.OPS);
                            }
                            break;
                        }
                    case 15:
                        {
                            if (sortModes[0][15] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.PA);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.PA);
                            }
                            break;
                        }
                    case 16:
                        {
                            if (sortModes[0][16] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.HitByPitch);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.HitByPitch);
                            }
                            break;
                        }
                    case 17:
                        {
                            if (sortModes[0][17] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.SacrificeBunts);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.SacrificeBunts);
                            }
                            break;
                        }
                    case 18:
                        {
                            if (sortModes[0][18] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.SacrificeFlies);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.SacrificeFlies);
                            }
                            break;
                        }
                    case 19:
                        {
                            if (sortModes[0][19] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.DoublePlay);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.DoublePlay);
                            }
                            break;
                        }
                    case 20:
                        {
                            if (sortModes[0][20] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.GOtoAO);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.GOtoAO);
                            }
                            break;
                        }
                    case 21:
                        {
                            if (sortModes[0][21] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.XBH);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.XBH);
                            }
                            break;
                        }
                    case 22:
                        {
                            if (sortModes[0][22] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.TotalBases);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.TotalBases);
                            }
                            break;
                        }
                    case 23:
                        {
                            if (sortModes[0][23] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.ISO);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.ISO);
                            }
                            break;
                        }
                    case 24:
                        {
                            if (sortModes[0][24] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.ABperHR);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.ABperHR);
                            }
                            break;
                        }
                    case 25:
                        {
                            if (sortModes[0][25] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.WalkToStrikeout);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.WalkToStrikeout);
                            }
                            break;
                        }
                    case 26:
                        {
                            if (sortModes[0][26] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.WalkPercentage);
                            }
                            else
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStats(teamBattingStats, team => team.WalkPercentage);
                            }
                            break;
                        }
                    case 27:
                        {
                            if (sortModes[0][27] == SortMode.Descending)
                            {
                                teamBattingStats = teamsBL.GetSortedTeamStatsDesc(teamBattingStats, team => team.StrikeoutPercentage);
                            }
                            else
                            {
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
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.Wins);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.Wins);
                            }
                            break;
                        }
                    case 1:
                        {
                            if (sortModes[1][1] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.Losses);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.Losses);
                            }
                            break;
                        }
                    case 2:
                        {
                            if (sortModes[1][2] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.ERA);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.ERA);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (sortModes[1][3] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.TGP);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.TGP);
                            }
                            break;
                        }
                    case 4:
                        {
                            if (sortModes[1][3] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.TGP);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.TGP);
                            }
                            break;
                        }
                    case 5:
                        {
                            if (sortModes[1][5] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.CompleteGames);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.CompleteGames);
                            }
                            break;
                        }
                    case 6:
                        {
                            if (sortModes[1][6] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.Shutouts);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.Shutouts);
                            }
                            break;
                        }
                    case 7:
                        {
                            if (sortModes[1][7] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.Saves);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.Saves);
                            }
                            break;
                        }
                    case 8:
                        {
                            if (sortModes[1][8] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.IP);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.IP);
                            }
                            break;
                        }
                    case 9:
                        {
                            if (sortModes[1][9] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.HitsAllowed);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.HitsAllowed);
                            }
                            break;
                        }
                    case 10:
                        {
                            if (sortModes[1][10] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.RunsAllowed);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.RunsAllowed);
                            }
                            break;
                        }
                    case 11:
                        {
                            if (sortModes[1][11] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.HomeRunsAllowed);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.HomeRunsAllowed);
                            }
                            break;
                        }
                    case 12:
                        {
                            if (sortModes[1][12] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.HitByPitch);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.HitByPitch);
                            }
                            break;
                        }
                    case 13:
                        {
                            if (sortModes[1][13] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.WalksAllowed);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.WalksAllowed);
                            }
                            break;
                        }
                    case 14:
                        {
                            if (sortModes[1][14] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.Strikeouts);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.Strikeouts);
                            }
                            break;
                        }
                    case 15:
                        {
                            if (sortModes[1][15] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.WHIP);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.WHIP);
                            }
                            break;
                        }
                    case 16:
                        {
                            if (sortModes[1][16] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.BAA);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.BAA);
                            }
                            break;
                        }
                    case 17:
                        {
                            if (sortModes[1][17] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.TotalBattersFaced);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.TotalBattersFaced);
                            }
                            break;
                        }
                    case 18:
                        {
                            if (sortModes[1][18] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.QualityStarts);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.QualityStarts);
                            }
                            break;
                        }
                    case 19:
                        {
                            if (sortModes[1][19] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.Holds);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.Holds);
                            }
                            break;
                        }
                    case 20:
                        {
                            if (sortModes[1][20] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.DoublePlays);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.DoublePlays);
                            }
                            break;
                        }
                    case 21:
                        {
                            if (sortModes[1][21] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.GOtoAO);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.GOtoAO);
                            }
                            break;
                        }
                    case 22:
                        {
                            if (sortModes[1][22] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.KperNineInnings);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.KperNineInnings);
                            }
                            break;
                        }
                    case 23:
                        {
                            if (sortModes[1][23] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.BBperNineInnings);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.BBperNineInnings);
                            }
                            break;
                        }
                    case 24:
                        {
                            if (sortModes[1][24] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.KperBB);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.KperBB);
                            }
                            break;
                        }
                    case 25:
                        {
                            if (sortModes[1][25] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.StolenBasesAllowed);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.StolenBasesAllowed);
                            }
                            break;
                        }
                    case 26:
                        {
                            if (sortModes[1][26] == SortMode.Descending)
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStatsDesc(teamPitchingStats, team => team.CaughtStealing);
                            }
                            else
                            {
                                teamPitchingStats = teamsBL.GetSortedTeamStats(teamPitchingStats, team => team.CaughtStealing);
                            }
                            break;
                        }
                }
            }
            FillBattersAndPitchersTable(batters, pitchers, teamBattingStats, teamPitchingStats);
        }

        private void dataGridView4_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                sortModes[1][dataGridView3.ColumnCount - 3 + e.ColumnIndex - 3] = (sortModes[1][dataGridView3.ColumnCount - 3 + e.ColumnIndex - 3] == SortMode.Descending && lastPitchingSort == dataGridView3.ColumnCount - 3 + e.ColumnIndex - 3) ? SortMode.Ascending : SortMode.Descending;
                lastPitchingSort = dataGridView3.ColumnCount - 3 + e.ColumnIndex - 3;
            }
            GetSortedListsBySortingCodes(lastBattingSort, lastPitchingSort, objects);
        }

        private void dataGridView3_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                if (e.ColumnIndex == 5)
                {
                    sortModes[1][e.ColumnIndex - 3] = (sortModes[1][e.ColumnIndex - 3] == SortMode.Ascending && lastPitchingSort == e.ColumnIndex - 3) ? SortMode.Descending : SortMode.Ascending;
                }
                else
                {
                    sortModes[1][e.ColumnIndex - 3] = (sortModes[1][e.ColumnIndex - 3] == SortMode.Descending && lastPitchingSort == e.ColumnIndex - 3) ? SortMode.Ascending : SortMode.Descending;
                }
                lastPitchingSort = e.ColumnIndex - 3;
            }
            GetSortedListsBySortingCodes(lastBattingSort, lastPitchingSort, objects);
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
                                            pitchers[i].GamesStarted,
                                            pitchers[i].CompleteGames,
                                            pitchers[i].Shutouts,
                                            pitchers[i].Saves,
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
                                            pitchers[i].Holds,
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
                    GetCorrectColorForCell(dataGridView1, i, teamBatting[i].TeamAbbreviation);

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
                    GetCorrectColorForCell(dataGridView2, i, teamBatting[i].TeamAbbreviation);
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
                                            teamPitching[i].TGP,
                                            teamPitching[i].CompleteGames,
                                            teamPitching[i].Shutouts,
                                            teamPitching[i].Saves,
                                            teamPitching[i].IP.ToString("0.0", new CultureInfo("en-US")),
                                            teamPitching[i].HitsAllowed,
                                            teamPitching[i].RunsAllowed,
                                            teamPitching[i].HomeRunsAllowed,
                                            teamPitching[i].HitByPitch,
                                            teamPitching[i].WalksAllowed,
                                            teamPitching[i].Strikeouts,
                                            teamPitching[i].WHIP.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].BAA.ToString("#.000", new CultureInfo("en-US")));
                    GetCorrectColorForCell(dataGridView3, i, teamPitching[i].TeamAbbreviation);

                    dataGridView4.Rows.Add(i + 1,
                                            "",
                                            teamPitching[i].TeamTitle,
                                            teamPitching[i].TotalBattersFaced,
                                            teamPitching[i].QualityStarts,
                                            teamPitching[i].Holds,
                                            teamPitching[i].DoublePlays,
                                            teamPitching[i].GOtoAO.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].KperNineInnings.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].BBperNineInnings.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].KperBB.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].StolenBasesAllowed,
                                            teamPitching[i].CaughtStealing);
                    GetCorrectColorForCell(dataGridView4, i, teamPitching[i].TeamAbbreviation);
                }
            }
        }

        private void GetCorrectColorForCell(DataGridView dgv, int RowNumber, string TeamForThisPlayer)
        {
            dgv.Rows[RowNumber].Cells[1].Style.BackColor = teams.Where(team => team.TeamAbbreviation == TeamForThisPlayer).First().TeamColor[0];
            dgv.Rows[RowNumber].Cells[1].Style.SelectionBackColor = teams.Where(team => team.TeamAbbreviation == TeamForThisPlayer).First().TeamColor[0];
        }

        private void dataGridView4_CellStyleChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor;
        }

        private void PlayerStatsForm_Load(object sender, EventArgs e)
        {
            if (objects == SortingObjects.Players)
            {
                batters = playersBL.GetBattersStats();
                pitchers = playersBL.GetPitchersStats();
            }
            else
            {
                teamBattingStats = teamsBL.GetTeamBattingStats();
                teamPitchingStats = teamsBL.GetTeamPitchingStats();
            }
            playerType = PlayerType.Batters;
            statsType = StatsType.Standard;
            cbPlayers.DataSource = cbPlayers.Items;
            ShowNewStats(playerType, statsType);
            List<string> teamsInComboBox = new List<string>
            {
                "MLB",
                "AL",
                "NL"
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
            cbTeams.Visible = cbPlayers.Text != "Free Agents";
            if (cbTeams.Items != null && cbPositions.DataSource != null)
            {
                if (objects == SortingObjects.Players)
                {
                    pitchers = playersBL.GetPitchersStats(cbPlayers.Text, cbTeams.SelectedValue.ToString());
                    if (cbPositions.SelectedValue is PlayerPosition)
                    {
                        batters = playersBL.GetBattersStats(cbTeams.SelectedValue.ToString(), cbPlayers.Text, (cbPositions.SelectedValue as PlayerPosition).ShortTitle);
                    }
                    else
                    {
                        batters = playersBL.GetBattersStats(cbTeams.SelectedValue.ToString(), cbPlayers.Text, cbPositions.SelectedValue.ToString());
                    }
                }
                GetSortedListsBySortingCodes(lastBattingSort, lastPitchingSort, objects);
            }
        }
    }
}