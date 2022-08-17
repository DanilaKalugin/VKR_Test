﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;
using VKR.PL.Utils.NET5;

namespace VKR.PL.NET5
{
    public partial class ChangePlayerTeamForm : Form
    {
        private readonly TeamsBL _teamsBL = new();
        private readonly RostersBL _rostersBl = new();
        private readonly PlayerMovesBL _playerMoves = new();

        private List<List<List<PlayerInLineupViewModel>>> _teamsLineups;
        private List<PlayerInLineupViewModel> _allPlayers;
        private List<PlayerInLineupViewModel> _players = new();
        private readonly List<Team> _teams;

        private int _teamNumber;


        public ChangePlayerTeamForm()
        {
            InitializeComponent();

            _teams = _teamsBL.GetAllTeams();

            _teamNumber = 0;
            FillTables();
        }

        private void btnDecreaseTeamNumberBy1_Click(object sender, EventArgs e)
        {
            _teamNumber = _teamNumber > 0 ? _teamNumber - 1 : _teams.Count - 1;
            TeamChanged(_teamNumber);
        }

        private void TeamChanged(int teamNumber)
        {
            lbTeamtitle.Text = _teams[teamNumber].TeamName.ToUpper();
            lbTeamtitle.BackColor = _teams[teamNumber].TeamColors[0].Color;
            lbTeamtitle.ForeColor = Color.White;
            dgvLineup.DefaultCellStyle.SelectionBackColor = _teams[teamNumber].TeamColors[0].Color;
            dgvLineup.DefaultCellStyle.SelectionForeColor = Color.White;

            btnIncreaseTeamNumberBy1.ForeColor = _teams[teamNumber].TeamColors[0].Color;
            btnDecreaseTeamNumberBy1.ForeColor = _teams[teamNumber].TeamColors[0].Color;
            btnAssignTo.Text = $"Assign to {_teams[teamNumber].TeamName}";
            DisplayRoster(teamNumber, dgvLineup);
        }

        private void DisplayRoster(int teamNumber, DataGridView dgv)
        {
            dgvLineup.DefaultCellStyle.SelectionBackColor = _teams[teamNumber].TeamColors[0].Color;
            dgvLineup.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = _teams[teamNumber].TeamColors[0].Color;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvLineup.Rows.Clear();
            foreach (var player in _teamsLineups[teamNumber][0])
                dgvLineup.Rows.Add("", player.PositionInLineup, $"{player.FirstName[0]}. {player.SecondName}");
            dgvLineup.Columns[0].Visible = false;
        }

        private void btnIncreaseTeamNumberBy1_Click(object sender, EventArgs e)
        {
            _teamNumber = _teamNumber < _teams.Count - 1 ? _teamNumber + 1 : 0;
            TeamChanged(_teamNumber);
        }

        private void dgvLineup_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLineup.SelectedRows.Count <= 0) return;
            var player = _teamsLineups[_teamNumber][0][dgvLineup.SelectedRows[0].Index];
            ShowNewPlayer(player);
        }

        private void ShowNewPlayer(Player player)
        {
            label7.Text = $@"Positions: {string.Join(", ", player.Positions.Select(position => position.ShortTitle))}";

            pbPlayerPhoto.BackgroundImage = ImageHelper.ShowImageIfExists($"PlayerPhotos/Player{player.Id:0000}.png");

            lbPlayerNumber.Text = $@"#{player.PlayerNumber}";
            lbPlayerName.Text = player.FullName.ToUpper();
            lbPlayerPlace_and_DateOfBirth.Text = $@"{player.City.CityLocation.ToUpper()} / {player.DateOfBirth.ToShortDateString().ToUpper()}";
            playerHands.Text = $@"B/T: {player.BattingHand.Description[0]}/{player.PitchingHand.Description[0]}".ToUpper();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0 || _players.Count == 0) return;

            var player = _players[dataGridView1.SelectedRows[0].Index];
            ShowNewPlayer(player);
        }

        private void btnAssignTo_Click(object sender, EventArgs e)
        {
            var player = _players[dataGridView1.SelectedRows[0].Index];
            var team = _teams[_teamNumber];

            _playerMoves.MovePlayerToNewTeam(player, team);

            FillTables();
        }

        private void FillTables()
        {
            _teamsLineups = _rostersBl.GetRoster(RostersBL.TypeOfRoster.ActiveAndReserve);
            _allPlayers = _playerMoves.GetAllPlayers();
            TeamChanged(_teamNumber);
            FillSecondTable(_allPlayers);
        }

        private void FillSecondTable(IEnumerable<PlayerInLineupViewModel> players)
        {
            dataGridView1.Rows.Clear();
            foreach (var player in players)
                dataGridView1.Rows.Add("", player.PositionInLineup, $"{player.FullName}", player.TeamAbbreviation);
            dataGridView1.Columns[0].Visible = false;
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            var input = txtLastName.Text.Trim();
            _players = _allPlayers.Where(player => player.SecondName.Contains(input)).ToList();
            FillSecondTable(_players);
        }
    }
}