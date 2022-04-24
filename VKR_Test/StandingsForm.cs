﻿using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class StandingsForm : Form
    {
        private readonly TeamsBL _teamsBl;
        private readonly MatchBL _matchBL;
        List<Team> _teams;
        private Team _homeTeam;
        private Team _awayTeam;

        public StandingsForm(Team home, Team away) : this()
        {
            _homeTeam = home;
            _awayTeam = away;
        }

        public StandingsForm()
        {
            InitializeComponent();
            _teamsBl = new TeamsBL();
            _matchBL = new MatchBL();
            Program.MatchDate = _matchBL.GetMaxDateForAllMatches();
            dtpStandingsDate.Value = Program.MatchDate;
            cbFilter.Text = "League";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            GetNewTable(cbFilter);
        }

        private void GetStandingsForThisGroup(string group, int groupNumber, bool isWC = false)
        {
            if (isWC)
            {
                _teams = _teamsBl.GetWCStandings(group, dtpStandingsDate.Value);
            }
            else
            {
                _teams = _teamsBl.GetStandings(group, dtpStandingsDate.Value);
            }

            var teamsInGroup = _teams.Count;
            dgvStandings.Rows.Add("", group, "W", "L", "GB", "PCT", "RS", "RA", "DIFF", "HOME", "AWAY");
            dgvStandings.Rows[dgvStandings.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvStandings.Rows[dgvStandings.Rows.Count - 1].DefaultCellStyle.Font = new Font(dgvStandings.DefaultCellStyle.Font, FontStyle.Bold);

            dgvStandings.Rows[dgvStandings.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dgvStandings.Rows[dgvStandings.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.White;

            for (var i = 0; i < _teams.Count; i++)
            {
                var gamesBehind = Math.Abs(_teams[i].GamesBehind).ToString("0.0", new CultureInfo("en-US"));
                if (_teams[i].GamesBehind < 0)
                {
                    gamesBehind = $"+{gamesBehind}";
                }

                dgvStandings.Rows.Add("", _teams[i].TeamTitle, _teams[i].Wins, _teams[i].Losses, gamesBehind, _teams[i].PCT.ToString("#.000", new CultureInfo("en-US")), _teams[i].RunsScored, _teams[i].RunsAllowed, _teams[i].RunDifferential, _teams[i].HomeBalance, _teams[i].AwayBalance);

                if ((_homeTeam != null && _homeTeam.TeamTitle == (string)dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].Cells[1].Value) ||
                    (_awayTeam != null && _awayTeam.TeamTitle == (string)dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].Cells[1].Value))
                {
                    dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].DefaultCellStyle.ForeColor = Color.Black;
                    dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
                    dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].Cells[0].Style.BackColor = _teams[i].TeamColor[0];
                dgvStandings.Rows[i + 1 + (teamsInGroup + 1) * groupNumber].Cells[0].Style.SelectionBackColor = _teams[i].TeamColor[0];
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GetNewTable(cbFilter);
        }

        private void GetNewTable(ComboBox comboBox)
        {
            dgvStandings.Rows.Clear();
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    {
                        GetStandingsForThisGroup("MLB", 0);
                        break;
                    }
                case 1:
                    {
                        GetStandingsForThisGroup("AL", 0);
                        GetStandingsForThisGroup("NL", 1);
                        break;
                    }
                case 2:
                    {
                        GetStandingsForThisGroup("AL East", 0);
                        GetStandingsForThisGroup("AL Central", 1);
                        GetStandingsForThisGroup("AL West", 2);
                        GetStandingsForThisGroup("NL East", 3);
                        GetStandingsForThisGroup("NL Central", 4);
                        GetStandingsForThisGroup("NL West", 5);
                        break;
                    }
                case 3:
                    {
                        GetStandingsForThisGroup("AL", 0, true);
                        GetStandingsForThisGroup("NL", 1, true);
                        break;
                    }
            }

            if (dgvStandings.RowCount < Screen.PrimaryScreen.Bounds.Size.Height)
            {
                Height = 97 + dgvStandings.RowTemplate.Height * dgvStandings.RowCount;
            }
            else
            {
                Height = 97 + ((Screen.PrimaryScreen.Bounds.Size.Height - 97) / dgvStandings.RowTemplate.Height) * dgvStandings.RowTemplate.Height;
            }
        }
    }
}