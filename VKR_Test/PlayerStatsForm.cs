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
        private enum SortMode { Ascending, Descending };
        private enum PlayerType { Pitchers, Batters };
        private enum StatsType { Standard, Expanded };

        private SortMode[][] sortModes;
        private PlayerType playerType;
        private StatsType statsType;
        private int lastBattingSort = 11;
        private int lastPitchingSort;

        public PlayerStatsForm()
        {
            InitializeComponent();

            playersBL = new PlayerBL();
            teamsBL = new TeamsBL();
            teams = teamsBL.GetAllTeams().ToList();


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
                        if (sortModes[1][4] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.CompleteGames);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.CompleteGames);
                        }
                        break;
                    }
                case 5:
                    {
                        if (sortModes[1][5] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.Shutouts);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.Shutouts);
                        }
                        break;
                    }
                case 6:
                    {
                        if (sortModes[1][6] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.IP);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.IP);
                        }
                        break;
                    }
                case 7:
                    {
                        if (sortModes[1][7] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.HitsAllowed);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.HitsAllowed);
                        }
                        break;
                    }
                case 8:
                    {
                        if (sortModes[1][8] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.RunsAllowed);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.RunsAllowed);
                        }
                        break;
                    }
                case 9:
                    {
                        if (sortModes[1][9] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.HomeRunsAllowed);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.HomeRunsAllowed);
                        }
                        break;
                    }
                case 10:
                    {
                        if (sortModes[1][10] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.HitByPitch);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.HitByPitch);
                        }
                        break;
                    }
                case 11:
                    {
                        if (sortModes[1][11] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.WalksAllowed);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.WalksAllowed);
                        }
                        break;
                    }
                case 12:
                    {
                        if (sortModes[1][12] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.Strikeouts);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.Strikeouts);
                        }
                        break;
                    }
                case 13:
                    {
                        if (sortModes[1][13] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.WHIP);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.WHIP);
                        }
                        break;
                    }
                case 14:
                    {
                        if (sortModes[1][14] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.BAA);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.BAA);
                        }
                        break;
                    }
                case 15:
                    {
                        if (sortModes[1][15] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.TotalBattersFaced);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.TotalBattersFaced);
                        }
                        break;
                    }
                case 16:
                    {
                        if (sortModes[1][16] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.QualityStarts);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.QualityStarts);
                        }
                        break;
                    }
                case 17:
                    {
                        if (sortModes[1][17] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.DoublePlays);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.DoublePlays);
                        }
                        break;
                    }
                case 18:
                    {
                        if (sortModes[1][18] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.GOtoAO);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.GOtoAO);
                        }
                        break;
                    }
                case 19:
                    {
                        if (sortModes[1][19] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.KperNineInnings);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.KperNineInnings);
                        }
                        break;
                    }
                case 20:
                    {
                        if (sortModes[1][20] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.BBperNineInnings);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.BBperNineInnings);
                        }
                        break;
                    }
                case 21:
                    {
                        if (sortModes[1][21] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.KperBB);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.KperBB);
                        }
                        break;
                    }
                case 22:
                    {
                        if (sortModes[1][22] == SortMode.Descending)
                        {
                            pitchers = playersBL.GetSortedPitchersStatsDesc(pitchers, batter => batter.StolenBasesAllowed);
                        }
                        else
                        {
                            pitchers = playersBL.GetSortedPitchersStats(pitchers, batter => batter.StolenBasesAllowed);
                        }
                        break;
                    }
                case 23:
                    {
                        if (sortModes[1][23] == SortMode.Descending)
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
            FillBattersAndPitchersTable(batters, pitchers);
        }

        private void dataGridView4_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                sortModes[0][e.ColumnIndex - 3] = sortModes[0][e.ColumnIndex - 3] == SortMode.Ascending ? SortMode.Descending : SortMode.Ascending;
                lastBattingSort = e.ColumnIndex - 3;
            }
            GetSortedListsBySortingCodes(lastBattingSort, lastPitchingSort);
        }

        private void dataGridView3_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                sortModes[1][dataGridView3.ColumnCount - 3 + e.ColumnIndex - 3] = sortModes[1][e.ColumnIndex - 3] == SortMode.Ascending ? SortMode.Descending : SortMode.Ascending;
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

        private void FillBattersAndPitchersTable(List<Batter> batters, List<Pitcher> pitchers)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
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
                dataGridView1.Rows[i].Cells[1].Style.BackColor = teams.Where(team => team.TeamAbbreviation == batters[i].Team).First().TeamColor[0];
                dataGridView1.Rows[i].Cells[1].Style.SelectionBackColor = teams.Where(team => team.TeamAbbreviation == batters[i].Team).First().TeamColor[0];
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
                dataGridView2.Rows[i].Cells[1].Style.BackColor = teams.Where(team => team.TeamAbbreviation == batters[i].Team).First().TeamColor[0];
                dataGridView2.Rows[i].Cells[1].Style.SelectionBackColor = teams.Where(team => team.TeamAbbreviation == batters[i].Team).First().TeamColor[0];
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
                dataGridView3.Rows[i].Cells[1].Style.BackColor = teams.Where(team => team.TeamAbbreviation == pitchers[i].Team).First().TeamColor[0];
                dataGridView3.Rows[i].Cells[1].Style.SelectionBackColor = teams.Where(team => team.TeamAbbreviation == pitchers[i].Team).First().TeamColor[0];

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
                dataGridView4.Rows[i].Cells[1].Style.BackColor = teams.Where(team => team.TeamAbbreviation == pitchers[i].Team).First().TeamColor[0];
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

        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            batters = playersBL.GetBattersStats(cbTeams.Text, cbPlayers.Text);
            pitchers = playersBL.GetPitchersStats(cbTeams.Text, cbPlayers.Text);
            GetSortedListsBySortingCodes(lastBattingSort, lastPitchingSort);
        }
    }
}