﻿using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class LineupsForm : Form
    {
        public enum RosterType { StartingLineups, Reserves, FreeAgents };
        private RosterType _rosterType;

        private readonly PlayerBL _players;
        private readonly TeamsBL _teamsBL;
        private List<List<List<PlayerInLineup>>> _teamsLineups;
        private List<List<List<PlayerInLineup>>> _teamsBench;
        private List<Team> _teams;
        private int _teamNumber;
        private int _lineupNumber;
        private readonly string[] _typesOfLineups = { "RH W/ DH", "RH NO DH", "LH W/ DH", "LH NO DH", "ROTATION" };
        private bool _LineupChanged;

        public LineupsForm(RosterType rosterType)
        {
            InitializeComponent();

            _players = new PlayerBL();
            _teamsBL = new TeamsBL();
            _rosterType = rosterType;
            _teams = _teamsBL.GetAllTeams();
            switch (_rosterType)
            {
                case RosterType.StartingLineups:
                    {
                        _teamsLineups = _players.GetRoster("GetStartingLineups");
                        _teamsBench = _players.GetRoster("GetBench");
                        base.Text = "Starting lineups";
                        break;
                    }
                case RosterType.Reserves:
                    {
                        _teamsLineups = _players.GetRoster("GetActivePlayers");
                        _teamsBench = _players.GetRoster("GetReserves");
                        base.Text = "Reserves";
                        break;
                    }
                case RosterType.FreeAgents:
                    {
                        _teamsLineups = _players.GetRoster("GetReserves");
                        _teamsBench = _players.GetFreeAgents();
                        base.Text = "Free Agents";
                        break;
                    }
            }
            TeamChanged(_teamNumber);
        }

        private void btnIncreaseTeamNumberBy1_Click(object sender, EventArgs e)
        {
            _teamNumber = _teamNumber < _teams.Count - 1 ? _teamNumber + 1 : 0;
            TeamChanged(_teamNumber);
        }

        private void btnDecreaseTeamNumberBy1_Click(object sender, EventArgs e)
        {
            _teamNumber = _teamNumber > 0 ? _teamNumber - 1 : _teams.Count - 1;
            TeamChanged(_teamNumber);
        }

        private void TeamChanged(int teamNumber)
        {
            panelTeamLogo.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{_teams[teamNumber].TeamAbbreviation}.png");
            lbTeamtitle.Text = _teams[teamNumber].TeamTitle.ToUpper();
            lbTeamtitle.BackColor = _teams[teamNumber].TeamColor[0];
            lbTeamtitle.ForeColor = Color.White;
            dgvLineup.DefaultCellStyle.SelectionBackColor = _teams[teamNumber].TeamColor[0];
            dgvLineup.DefaultCellStyle.SelectionForeColor = Color.White;

            label4.ForeColor = _teams[teamNumber].TeamColor[0];
            label5.ForeColor = _teams[teamNumber].TeamColor[0];
            label6.ForeColor = _teams[teamNumber].TeamColor[0];
            btnIncreaseTeamNumberBy1.ForeColor = _teams[teamNumber].TeamColor[0];
            btnDecreaseTeamNumberBy1.ForeColor = _teams[teamNumber].TeamColor[0];
            btnIncLineupTypeNumberBy1.ForeColor = _teams[teamNumber].TeamColor[0];
            btnDecLineupTypeNumberBy1.ForeColor = _teams[teamNumber].TeamColor[0];
            lbLineUpType.ForeColor = _teams[teamNumber].TeamColor[0];
            lbPlayerName.ForeColor = _teams[teamNumber].TeamColor[0];

            lbPlayerNumber.ForeColor = Color.FromArgb((int)(_teams[teamNumber].TeamColor[0].R * 0.7), (int)(_teams[teamNumber].TeamColor[0].G * 0.7), (int)(_teams[teamNumber].TeamColor[0].B * 0.7));
            dgvBench.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb((int)(_teams[teamNumber].TeamColor[0].R * 0.65), (int)(_teams[teamNumber].TeamColor[0].G * 0.65), (int)(_teams[teamNumber].TeamColor[0].B * 0.65));

            lbl_LineupHeader.ForeColor = _teams[teamNumber].TeamColor[0];
            DisplayRoster(teamNumber, _lineupNumber);
        }

        private void DisplayRoster(int teamNumber, int lineupNumber)
        {
            dgvLineup.Rows.Clear();
            switch (_rosterType)
            {
                case RosterType.StartingLineups:
                    {
                        foreach (PlayerInLineup player in _teamsLineups[teamNumber][lineupNumber])
                        {
                            dgvLineup.Rows.Add(player.NumberInLineup, player.Position, $"{player.FirstName[0]}. {player.SecondName}");
                        }
                        dgvBench.Columns[0].HeaderText = lineupNumber != 4 ? "BENCH" : "BULLPEN";
                        break;
                    }
                case RosterType.Reserves:
                    {
                        foreach (PlayerInLineup player in _teamsLineups[teamNumber][lineupNumber])
                        {
                            dgvLineup.Rows.Add(player.NumberInLineup, player.PlayerPositions[0], $"{player.FirstName[0]}. {player.SecondName}");
                        }
                        dgvBench.Columns[0].HeaderText = "RESERVE";
                        dgvLineup.Columns[0].Visible = false;
                        break;
                    }
                case RosterType.FreeAgents:
                    {
                        foreach (PlayerInLineup player in _teamsLineups[teamNumber][lineupNumber])
                        {
                            dgvLineup.Rows.Add(player.NumberInLineup, player.PlayerPositions[0], $"{player.FirstName[0]}. {player.SecondName}");
                        }
                        dgvBench.Columns[0].HeaderText = "FREE AGENTS";
                        dgvLineup.Columns[0].Visible = false;
                        break;
                    }
            }
            lbLineUpType.Text = _typesOfLineups[lineupNumber];
            dgvBench.Rows.Clear();
            if (_rosterType == RosterType.FreeAgents)
            {
                foreach (PlayerInLineup player in _teamsBench[0][0])
                {
                    dgvBench.Rows.Add($"{player.FirstName[0]}. {player.SecondName}");
                }
            }
            else
            {
                foreach (PlayerInLineup player in _teamsBench[teamNumber][lineupNumber])
                {
                    dgvBench.Rows.Add($"{player.FirstName[0]}. {player.SecondName}");
                }
            }

            _LineupChanged = true;
        }

        private void btnIncLineupTypeNumberBy1_Click(object sender, EventArgs e)
        {
            _lineupNumber = _lineupNumber < _teamsLineups[_teamNumber].Count - 1 ? _lineupNumber + 1 : 0;
            DisplayRoster(_teamNumber, _lineupNumber);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _lineupNumber = _lineupNumber > 0 ? _lineupNumber - 1 : _teamsLineups[_teamNumber].Count - 1;
            DisplayRoster(_teamNumber, _lineupNumber);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLineup.SelectedRows.Count > 0)
            {
                ShowNewPlayer(dgvLineup, dgvBench, _teamsLineups[_teamNumber][_lineupNumber][dgvLineup.SelectedRows[0].Index]);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowNewPlayer(dgvLineup, dgvBench, _teamsLineups[_teamNumber][_lineupNumber][dgvLineup.SelectedRows[0].Index]);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _LineupChanged = false;
            if (_rosterType == RosterType.FreeAgents)
            {
                ShowNewPlayer(dgvBench, dgvLineup, _teamsBench[0][0][dgvBench.SelectedRows[0].Index]);
            }
            else
            {
                ShowNewPlayer(dgvBench, dgvLineup, _teamsBench[_teamNumber][_lineupNumber][dgvBench.SelectedRows[0].Index]);
            }
        }

        private void ShowNewPlayer(DataGridView dgv1, DataGridView dgv2, PlayerInLineup player)
        {
            dgv2.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dgv2.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgv2.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv2.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;

            dgv1.DefaultCellStyle.SelectionBackColor = _teams[_teamNumber].TeamColor[0];
            dgv1.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv1.AlternatingRowsDefaultCellStyle.SelectionBackColor = _teams[_teamNumber].TeamColor[0];
            dgv1.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;

            Player batter = _players.GetPlayerByCode(player.Id);
            if (player.PlayerPositions.IndexOf("P") == -1)
            {
                label4.Text = "AVG";
                label5.Text = "HR";
                label6.Text = "RBI";
                
                label1.Text = batter.battingStats.AVG.ToString("#.000", new CultureInfo("en-US"));
                label2.Text = batter.battingStats.HomeRuns.ToString();
                label3.Text = batter.battingStats.RBI.ToString();
            }
            else
            {
                label4.Text = "ERA";
                label5.Text = "SO";
                label6.Text = "WHIP";

                Pitcher pitcher = _players.GetPitcherByCode(player.Id);
                pitcher.RemainingStamina = _players.ReturnNumberOfOutsPlayedByThisPitcherInLast5Days(pitcher);

                label1.Text = pitcher.pitchingStats.ERA.ToString("0.00", new CultureInfo("en-US"));
                label2.Text = pitcher.pitchingStats.Strikeouts.ToString();
                label3.Text = pitcher.pitchingStats.WHIP.ToString("0.00", new CultureInfo("en-US"));
            }
            label7.Text = $"Positions: {string.Join(", ", player.PlayerPositions)}";

            if (dgv1.SelectedRows.Count > 0)
            {
                if (File.Exists($"PlayerPhotos/Player{player.Id:0000}.png"))
                {
                    pbPlayerPhoto.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{player.Id:0000}.png");
                }
                else
                {
                    pbPlayerPhoto.BackgroundImage = null;
                }
                lbPlayerNumber.Text = $"#{player.PlayerNumber}";
                lbPlayerName.Text = player.FullName.ToUpper();
                lbPlayerPlace_and_DateOfBirth.Text = $"{player.PlaceOfBirth.ToUpper()} / {player.DateOfBirth.ToShortDateString().ToUpper()}";
                playerHands.Text = $"B/T: {player.BattingHand[0]}/{player.PitchingHand[0]}".ToUpper();
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBench.SelectedRows.Count > 0 && !_LineupChanged)
            {
                if (_rosterType == RosterType.FreeAgents)
                {
                    ShowNewPlayer(dgvBench, dgvLineup, _teamsBench[0][0][dgvBench.SelectedRows[0].Index]);
                }
                else
                {
                    ShowNewPlayer(dgvBench, dgvLineup, _teamsBench[_teamNumber][_lineupNumber][dgvBench.SelectedRows[0].Index]);
                }
            }
        }

        private void LineupsForm_Load(object sender, EventArgs e)
        {
            lbl_LineupHeader.Visible = _rosterType == RosterType.StartingLineups;
            btnDecLineupTypeNumberBy1.Visible = _rosterType == RosterType.StartingLineups;
            btnIncLineupTypeNumberBy1.Visible = _rosterType == RosterType.StartingLineups;
            lbLineUpType.Visible = _rosterType == RosterType.StartingLineups;
        }
    }
}