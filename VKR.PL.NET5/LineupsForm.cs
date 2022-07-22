﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;

namespace VKR.PL.NET5
{
    public partial class LineupsForm : Form
    {
        public enum RosterType { StartingLineups, Reserves, FreeAgents }
        private readonly RosterType _rosterType;

        private readonly PlayerBL _players = new();
        private readonly TeamsBL _teamsBL = new();
        private readonly MatchBL _matchBL = new();

        private readonly List<List<List<PlayerInLineupViewModel>>> _teamsLineups;
        private readonly List<List<List<PlayerInLineupViewModel>>> _teamsBench;
        private readonly List<Team> _teams;
        private int _teamNumber;
        private int _lineupNumber;
        private readonly string[] _typesOfLineups = { "RH W/ DH", "RH NO DH", "LH W/ DH", "LH NO DH", "ROTATION" };
        private bool _lineupChanged;
        private DateTime _matchDate;

        public LineupsForm(RosterType rosterType)
        {
            InitializeComponent();

            _rosterType = rosterType;
            _teams = _teamsBL.GetAllTeams();
            _matchDate = _matchBL.GetMaxDateForAllMatches();

            switch (_rosterType)
            {
                case RosterType.StartingLineups:
                    _teamsLineups = _players.GetRoster(PlayerBL.TypeOfRoster.Starters);
                    _teamsBench = _players.GetRoster(PlayerBL.TypeOfRoster.Bench);
                    base.Text = "Starting lineups";
                    break;
                case RosterType.Reserves:
                    _teamsLineups = _players.GetRoster(PlayerBL.TypeOfRoster.ActivePlayers);
                    _teamsBench = _players.GetRoster(PlayerBL.TypeOfRoster.Reserve);
                    base.Text = "Reserves";
                    break;
                case RosterType.FreeAgents:
                    _teamsLineups = _players.GetRoster(PlayerBL.TypeOfRoster.ActiveAndReserve);
                    _teamsBench = _players.GetFreeAgents();
                    Text = "Free Agents";
                    break;
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
            lbTeamtitle.Text = _teams[teamNumber].TeamName.ToUpper();
            lbTeamtitle.BackColor = _teams[teamNumber].TeamColors[0].Color;
            lbTeamtitle.ForeColor = Color.White;
            dgvLineup.DefaultCellStyle.SelectionBackColor = _teams[teamNumber].TeamColors[0].Color;
            dgvLineup.DefaultCellStyle.SelectionForeColor = Color.White;

            label4.ForeColor = _teams[teamNumber].TeamColors[0].Color;
            label5.ForeColor = _teams[teamNumber].TeamColors[0].Color;
            label6.ForeColor = _teams[teamNumber].TeamColors[0].Color;
            btnIncreaseTeamNumberBy1.ForeColor = _teams[teamNumber].TeamColors[0].Color;
            btnDecreaseTeamNumberBy1.ForeColor = _teams[teamNumber].TeamColors[0].Color;
            btnIncLineupTypeNumberBy1.ForeColor = _teams[teamNumber].TeamColors[0].Color;
            btnDecLineupTypeNumberBy1.ForeColor = _teams[teamNumber].TeamColors[0].Color;
            lbLineUpType.ForeColor = _teams[teamNumber].TeamColors[0].Color;
            lbPlayerName.ForeColor = _teams[teamNumber].TeamColors[0].Color;

            lbPlayerNumber.ForeColor = Color.FromArgb((int)(_teams[teamNumber].TeamColors[0].Color.R * 0.7), (int)(_teams[teamNumber].TeamColors[0].Color.G * 0.7), (int)(_teams[teamNumber].TeamColors[0].Color.B * 0.7));
            dgvBench.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb((int)(_teams[teamNumber].TeamColors[0].Color.R * 0.65), (int)(_teams[teamNumber].TeamColors[0].Color.G * 0.65), (int)(_teams[teamNumber].TeamColors[0].Color.B * 0.65));

            lbl_LineupHeader.ForeColor = _teams[teamNumber].TeamColors[0].Color;
            DisplayRoster(teamNumber, _lineupNumber);
        }

        private void DisplayRoster(int teamNumber, int lineupNumber)
        {
            dgvLineup.Rows.Clear();
            switch (_rosterType)
            {
                case RosterType.StartingLineups:
                    {
                        foreach (var player in _teamsLineups[teamNumber][lineupNumber])
                            dgvLineup.Rows.Add(player.NumberInLineup, player.PositionInLineup, $"{player.FirstName[0]}. {player.SecondName}");
                        dgvBench.Columns[0].HeaderText = lineupNumber != 4 ? "BENCH" : "BULLPEN";
                        break;
                    }
                case RosterType.Reserves:
                    {
                        foreach (var player in _teamsLineups[teamNumber][lineupNumber])
                            dgvLineup.Rows.Add("", player.PositionInLineup, $"{player.FirstName[0]}. {player.SecondName}");
                        dgvBench.Columns[0].HeaderText = "RESERVE";
                        dgvLineup.Columns[0].Visible = false;
                        break;
                    }
                case RosterType.FreeAgents:
                    {
                        foreach (var player in _teamsLineups[teamNumber][lineupNumber])
                            dgvLineup.Rows.Add("", player.PositionInLineup, $"{player.FirstName[0]}. {player.SecondName}");
                        dgvBench.Columns[0].HeaderText = "FREE AGENTS";
                        dgvLineup.Columns[0].Visible = false;
                        break;
                    }
            }
            lbLineUpType.Text = _typesOfLineups[lineupNumber];
            dgvBench.Rows.Clear();

            var bench = _rosterType == RosterType.FreeAgents ? _teamsBench[0][0] : _teamsBench[teamNumber][lineupNumber];

            foreach (var player in bench)
                dgvBench.Rows.Add($"{player.FirstName[0]}. {player.SecondName}");

            _lineupChanged = true;
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
                ShowNewPlayer(dgvLineup, dgvBench, _teamsLineups[_teamNumber][_lineupNumber][dgvLineup.SelectedRows[0].Index]);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) => ShowNewPlayer(dgvLineup, dgvBench, _teamsLineups[_teamNumber][_lineupNumber][dgvLineup.SelectedRows[0].Index]);

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _lineupChanged = false;
            var player = _rosterType == RosterType.FreeAgents
                ? _teamsBench[0][0][dgvBench.SelectedRows[0].Index]
                : _teamsBench[_teamNumber][_lineupNumber][dgvBench.SelectedRows[0].Index];
            ShowNewPlayer(dgvBench, dgvLineup, player);
        }

        private void ShowNewPlayer(DataGridView dgv1, DataGridView dgv2, Player player)
        {
            dgv2.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dgv2.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgv2.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv2.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;

            dgv1.DefaultCellStyle.SelectionBackColor = _teams[_teamNumber].TeamColors[0].Color;
            dgv1.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv1.AlternatingRowsDefaultCellStyle.SelectionBackColor = _teams[_teamNumber].TeamColors[0].Color;
            dgv1.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;

            label4.Text = player.CanPlayAsPitcher ? "ERA" : "AVG";
            label5.Text = player.CanPlayAsPitcher ? "SO" : "HR";
            label6.Text = player.CanPlayAsPitcher ? "WHIP" : "RBI";

            if (!player.CanPlayAsPitcher)
            {
                player.BattingStats = _players.GetBattingStatsByCode(player.Id, _matchDate.Year);
                label1.Text = player.BattingStats.AVG.ToString("#.000", new CultureInfo("en-US"));
                label2.Text = player.BattingStats.HomeRuns.ToString();
                label3.Text = player.BattingStats.RBI.ToString();
            }
            else
            {
                player.PitchingStats = _players.GetPitchingStatsByCode(player.Id, _matchDate.Year);
                label1.Text = player.PitchingStats.ERA.ToString("0.00", new CultureInfo("en-US"));
                label2.Text = player.PitchingStats.Strikeouts.ToString();
                label3.Text = player.PitchingStats.WHIP.ToString("0.00", new CultureInfo("en-US"));
            }

            label7.Text = $@"Positions: {string.Join(", ", player.Positions.Select(position => position.ShortTitle))}";

            if (dgv1.SelectedRows.Count <= 0) return;

            var imagePath = $"PlayerPhotos/Player{player.Id:0000}.png";
            var image = File.Exists(imagePath) ? Image.FromFile(imagePath) : null;
            pbPlayerPhoto.BackgroundImage = image;

            lbPlayerNumber.Text = $@"#{player.PlayerNumber}";
            lbPlayerName.Text = player.FullName.ToUpper();
            lbPlayerPlace_and_DateOfBirth.Text = $@"{player.City.CityLocation.ToUpper()} / {player.DateOfBirth.ToShortDateString().ToUpper()}";
            playerHands.Text = $@"B/T: {player.BattingHand.Description[0]}/{player.PitchingHand.Description[0]}".ToUpper();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBench.SelectedRows.Count <= 0 || _lineupChanged) return;

            var player = _rosterType == RosterType.FreeAgents
                ? _teamsBench[0][0][dgvBench.SelectedRows[0].Index]
                : _teamsBench[_teamNumber][_lineupNumber][dgvBench.SelectedRows[0].Index];
            ShowNewPlayer(dgvBench, dgvLineup, player);
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