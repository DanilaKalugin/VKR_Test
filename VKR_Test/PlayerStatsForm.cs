using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private SortMode[] sortingStandardPitchers;

        public PlayerStatsForm()
        {
            InitializeComponent();
            playersBL = new PlayerBL();
            sortingStandardPitchers = new SortMode[4];
            sortingStandardPitchers[0] = SortMode.Ascending;
        }

        private void PlayerStatsForm_Load(object sender, EventArgs e)
        {
            batters = playersBL.GetBattersStats().ToList();
            for (int i = 0; i < batters.Count; i++)
            {
                dataGridView1.Rows.Add(i + 1,
                                        $"{batters[i].FirstName} {batters[i].SecondName}",
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
                                        $"{batters[i].FirstName} {batters[i].SecondName}",
                                        batters[i].PA,
                                        batters[i].HitByPitch,
                                        batters[i].SacrificeBunts,
                                        batters[i].SacrificeFlies,
                                        batters[i].DoublePlay,
                                        batters[i].XBH,
                                        batters[i].TotalBases,
                                        batters[i].ISO.ToString("#.000", new CultureInfo("en-US")));
            }
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView3.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView4.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            pitchers = playersBL.GetPitchersStats().ToList();
            for (int i = 0; i < pitchers.Count; i++)
            {
                dataGridView3.Rows.Add(i + 1,
                                        $"{pitchers[i].FirstName} {pitchers[i].SecondName}",
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
                                        $"{pitchers[i].FirstName} {pitchers[i].SecondName}",
                                        pitchers[i].TotalBattersFaced,
                                        pitchers[i].QualityStarts,
                                        pitchers[i].DoublePlays,
                                        pitchers[i].StolenBasesAllowed,
                                        pitchers[i].CaughtStealing);
            }

            Height = 120 + 25 * 20;
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
            for (int i = 0; i < batters.Count; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }

        private void dataGridView4_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < pitchers.Count; i++)
            {
                dataGridView4.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }

        private void dataGridView3_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 2:
                    {
                        if (sortingStandardPitchers[0] == SortMode.Ascending)
                        {
                            pitchers = pitchers.OrderByDescending(pitcher => pitcher.ERA).ToList();
                            sortingStandardPitchers[0] = SortMode.Descending;
                        }
                        else
                        {
                            pitchers = pitchers.OrderBy(pitcher => pitcher.ERA).ToList();
                            sortingStandardPitchers[0] = SortMode.Ascending;
                        }
                        break;
                    }
                case 6:
                    {
                        if (sortingStandardPitchers[1] == SortMode.Ascending)
                        {
                            pitchers = pitchers.OrderByDescending(pitcher => pitcher.IP).ToList();
                            sortingStandardPitchers[1] = SortMode.Descending;
                        }
                        else
                        {
                            pitchers = pitchers.OrderBy(pitcher => pitcher.IP).ToList();
                            sortingStandardPitchers[1] = SortMode.Ascending;
                        }
                        break;
                    }
                case 13:
                    {
                        if (sortingStandardPitchers[2] == SortMode.Ascending)
                        {
                            pitchers = pitchers.OrderByDescending(pitcher => pitcher.WHIP).ToList();
                            sortingStandardPitchers[2] = SortMode.Descending;
                        }
                        else
                        {
                            pitchers = pitchers.OrderBy(pitcher => pitcher.WHIP).ToList();
                            sortingStandardPitchers[2] = SortMode.Ascending;
                        }
                        break;
                    }
                case 14:
                    {
                        if (sortingStandardPitchers[3] == SortMode.Ascending)
                        {
                            pitchers = pitchers.OrderByDescending(pitcher => pitcher.BAA).ToList();
                            sortingStandardPitchers[3] = SortMode.Descending;
                        }
                        else
                        {
                            pitchers = pitchers.OrderBy(pitcher => pitcher.BAA).ToList();
                            sortingStandardPitchers[3] = SortMode.Ascending;
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
                                            $"{pitchers[i].FirstName} {pitchers[i].SecondName}",
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
    }
}