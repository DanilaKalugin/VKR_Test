﻿using Entities;
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
        bool IsStandardStats;
        public PlayerStatsForm()
        {
            InitializeComponent();
            playersBL = new PlayerBL();
        }

        private void PlayerStatsForm_Load(object sender, EventArgs e)
        {
            batters = playersBL.GetBattersStats().ToList();
            for (int i = 0; i < batters.Count; i++)
            {
                dataGridView1.Rows.Add(i + 1,
                                        Image.FromFile($"PlayerPhotos/Player{batters[i].id.ToString("0000")}.jpg"),
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
                                        Image.FromFile($"PlayerPhotos/Player{batters[i].id.ToString("0000")}.jpg"),
                                        $"{batters[i].FirstName} {batters[i].SecondName}",
                                        batters[i].PA,
                                        batters[i].HitByPitch,
                                        batters[i].SacrificeBunts,
                                        batters[i].SacrificeFlies,
                                        batters[i].XBH,
                                        batters[i].TotalBases,
                                        batters[i].ISO.ToString("#.000", new CultureInfo("en-US")));
            }

            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Height = 128 + 45 * 16;
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
    }
}
