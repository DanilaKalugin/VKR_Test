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
        List<Batter> batters;
        List<Pitcher> pitchers;
        private enum SortMode { Ascending, Descending };
        private enum PlayerType { Pitchers, Batters };
        private enum StatsType { Standard, Expanded };

        private SortMode[] sortModes;
        private PlayerType playerType;
        private StatsType statsType;

        public PlayerStatsForm()
        {
            InitializeComponent();
            playersBL = new PlayerBL();
            sortModes = new SortMode[9];
            playerType = PlayerType.Batters;
            statsType = StatsType.Standard;
            ShowNewStats(playerType, statsType);
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

        private void PlayerStatsForm_Load(object sender, EventArgs e)
        {
            batters = playersBL.GetBattersStats().ToList();
            for (int i = 0; i < batters.Count; i++)
            {
                dataGridView1.Rows.Add(i + 1,
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
                dataGridView2.Rows.Add(i + 1,
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
            }
            pitchers = playersBL.GetPitchersStats().ToList();
            for (int i = 0; i < pitchers.Count; i++)
            {
                dataGridView3.Rows.Add(i + 1,
                                        pitchers[i].FullName,
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

                dataGridView4.Rows.Add(i + 1,
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
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < batters.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 7:
                    {
                        if (sortModes[5] == SortMode.Ascending)
                        {
                            batters = batters.OrderByDescending(batter => batter.GOtoAO).ToList();
                            sortModes[5] = SortMode.Descending;
                        }
                        else
                        {
                            batters = batters.OrderBy(batter => batter.GOtoAO).ToList();
                            sortModes[5] = SortMode.Ascending;
                        }
                        break;
                    }
                case 11:
                    {
                        if (sortModes[6] == SortMode.Ascending)
                        {
                            batters = batters.OrderByDescending(batter => batter.ABperHR).ToList();
                            sortModes[6] = SortMode.Descending;
                        }
                        else
                        {
                            batters = batters.OrderBy(batter => batter.ABperHR).ToList();
                            sortModes[6] = SortMode.Ascending;
                        }
                        break;
                    }
            }
            if (e.ColumnIndex == 7 || e.ColumnIndex == 11)
            {
                dataGridView2.Rows.Clear();
                {
                    for (int i = 0; i < batters.Count; i++)
                    {
                        dataGridView2.Rows.Add(i + 1,
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
                    }
                }
            }
            else
            {
                for (int i = 0; i < batters.Count; i++)
                {
                    dataGridView2.Rows[i].Cells[0].Value = (i + 1).ToString();
                }
            }
        }

        private void dataGridView4_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 6:
                    {
                        if (sortModes[7] == SortMode.Ascending)
                        {
                            pitchers = pitchers.OrderByDescending(pitcher => pitcher.KperNineInnings).ToList();
                            sortModes[7] = SortMode.Descending;
                        }
                        else
                        {
                            pitchers = pitchers.OrderBy(pitcher => pitcher.KperNineInnings).ToList();
                            sortModes[7] = SortMode.Ascending;
                        }
                        break;
                    }
                case 7:
                    {
                        if (sortModes[8] == SortMode.Ascending)
                        {
                            pitchers = pitchers.OrderByDescending(pitcher => pitcher.BBperNineInnings).ToList();
                            sortModes[8] = SortMode.Descending;
                        }
                        else
                        {
                            pitchers = pitchers.OrderBy(pitcher => pitcher.BBperNineInnings).ToList();
                            sortModes[8] = SortMode.Ascending;
                        }
                        break;
                    }
                case 8:
                    {
                        if (sortModes[4] == SortMode.Ascending)
                        {
                            pitchers = pitchers.OrderByDescending(pitcher => pitcher.KperBB).ToList();
                            sortModes[4] = SortMode.Descending;
                        }
                        else
                        {
                            pitchers = pitchers.OrderBy(pitcher => pitcher.KperBB).ToList();
                            sortModes[4] = SortMode.Ascending;
                        }
                        break;
                    }
            }
            if (e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8)
            {
                dataGridView4.Rows.Clear();
                for (int i = 0; i < pitchers.Count; i++)
                {
                    dataGridView4.Rows.Add(i + 1,
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
                }
            }
            else
            {
                for (int i = 0; i < pitchers.Count; i++)
                {
                    dataGridView4.Rows[i].Cells[0].Value = (i + 1).ToString();
                }
            }

        }

        private void dataGridView3_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 2:
                    {
                        if (sortModes[0] == SortMode.Ascending)
                        {
                            pitchers = pitchers.OrderByDescending(pitcher => pitcher.ERA).ToList();
                            sortModes[0] = SortMode.Descending;
                        }
                        else
                        {
                            pitchers = pitchers.OrderBy(pitcher => pitcher.ERA).ToList();
                            sortModes[0] = SortMode.Ascending;
                        }
                        break;
                    }
                case 6:
                    {
                        if (sortModes[1] == SortMode.Ascending)
                        {
                            pitchers = pitchers.OrderByDescending(pitcher => pitcher.IP).ToList();
                            sortModes[1] = SortMode.Descending;
                        }
                        else
                        {
                            pitchers = pitchers.OrderBy(pitcher => pitcher.IP).ToList();
                            sortModes[1] = SortMode.Ascending;
                        }
                        break;
                    }
                case 13:
                    {
                        if (sortModes[2] == SortMode.Ascending)
                        {
                            pitchers = pitchers.OrderByDescending(pitcher => pitcher.WHIP).ToList();
                            sortModes[2] = SortMode.Descending;
                        }
                        else
                        {
                            pitchers = pitchers.OrderBy(pitcher => pitcher.WHIP).ToList();
                            sortModes[2] = SortMode.Ascending;
                        }
                        break;
                    }
                case 14:
                    {
                        if (sortModes[3] == SortMode.Ascending)
                        {
                            pitchers = pitchers.OrderByDescending(pitcher => pitcher.BAA).ToList();
                            sortModes[3] = SortMode.Descending;
                        }
                        else
                        {
                            pitchers = pitchers.OrderBy(pitcher => pitcher.BAA).ToList();
                            sortModes[3] = SortMode.Ascending;
                        }
                        break;
                    }
            }
            if (e.ColumnIndex == 2 || e.ColumnIndex == 6 || e.ColumnIndex == 13 || e.ColumnIndex == 14)
            {
                dataGridView3.Rows.Clear();
                for (int i = 0; i < pitchers.Count; i++)
                {
                    dataGridView3.Rows.Add(i + 1,
                                            pitchers[i].FullName,
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
                }
            }
            else
            {
                for (int i = 0; i < pitchers.Count; i++)
                {
                    dataGridView3.Rows[i].Cells[0].Value = (i + 1).ToString();
                }
            }

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
    }
}