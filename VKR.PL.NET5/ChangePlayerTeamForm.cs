using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
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

        private List<PlayerInLineupViewModel> _allPlayers;
        private List<PlayerInLineupViewModel> _players = new();
        private List<Team> _teams;
        private PlayerInLineupViewModel? _currentPlayer;

        private int _teamNumber;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;

        public ChangePlayerTeamForm() => InitializeComponent();

        private void btnDecreaseTeamNumberBy1_Click(object sender, EventArgs e)
        {
            _teamNumber = _teamNumber > 0 ? _teamNumber - 1 : _teams.Count - 1;
            TeamChanged();
        }

        private void TeamChanged()
        {
            lbTeamtitle.Text = _teams[_teamNumber].TeamName.ToUpper();
            lbTeamtitle.BackColor = _teams[_teamNumber].TeamColors[0].Color;
            lbTeamtitle.ForeColor = Color.White;

            btnIncreaseTeamNumberBy1.ForeColor = _teams[_teamNumber].TeamColors[0].Color;
            btnDecreaseTeamNumberBy1.ForeColor = _teams[_teamNumber].TeamColors[0].Color;

            dgvPlayers.DefaultCellStyle.SelectionBackColor = _teams[_teamNumber].TeamColors[0].Color;

            btnAssignTo.Text = $"Assign to {_teams[_teamNumber].TeamName}";
        }

        private void btnIncreaseTeamNumberBy1_Click(object sender, EventArgs e)
        {
            _teamNumber = _teamNumber < _teams.Count - 1 ? _teamNumber + 1 : 0;
            TeamChanged();
        }

        private void ShowNewPlayer(PlayerInLineupViewModel? player)
        {
            label7.Text = $@"Positions: {string.Join(", ", player?.Positions.Select(position => position.ShortTitle) ?? Array.Empty<string>())}";

            pbPlayerPhoto.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/PlayerPhotos/Player{player?.Id:0000}.png");

            lbPlayerNumber.Text = $@"#{player?.PlayerNumber}";
            lbPlayerName.Text = player?.FullName.ToUpper();
            lbPlayerPlace_and_DateOfBirth.Text = $@"{player?.City.CityLocation.ToUpper()} / {player?.DateOfBirth.ToShortDateString().ToUpper()}";
            playerHands.Text = $@"B/T: {player?.BattingHand.Description[0]}/{player?.PitchingHand.Description[0]}".ToUpper();

            btnAssignTo.Enabled = player?.TeamAbbreviation != _teams[_teamNumber].TeamAbbreviation;

            label7.Visible = player is not null;
            lbPlayerNumber.Visible = player is not null;
            lbPlayerPlace_and_DateOfBirth.Visible = player is not null;
            playerHands.Visible = player is not null;
            btnUpdatePlayer.Visible = player is not null;
        }

        private void dgvPlayers_SelectionChanged(object sender, EventArgs e)
        {
            _currentPlayer = dgvPlayers.SelectedRows.Count > 0 ? _players[dgvPlayers.SelectedRows[0].Index] : null;

            ShowNewPlayer(_currentPlayer);
        }

        private async void btnAssignTo_Click(object sender, EventArgs e)
        {
            var team = _teams[_teamNumber];

            Visible = false;
            using (var form = new SetNewNumberForPlayerForm(team, _currentPlayer))
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK) 
                    await _playerMoves.MovePlayerToNewTeam(_currentPlayer, team);
            }

            Visible = true;


            await FillTables();
        }

        private async Task FillTables()
        {
            Opacity = 0;
            var f = new LoadingForm();
            f.TopMost = true;
            f.Show();
            _allPlayers = await _rostersBl.GetAllPlayers();
            _players = _allPlayers.ToList();

            txtLastName.Clear();
            txtFirstName.Clear();

            TeamChanged();
            FillSecondTable(_allPlayers);
            Opacity = 1;
            f.Dispose();
        }

        private void FillSecondTable(IEnumerable<PlayerInLineupViewModel> players)
        {
            dgvPlayers.Rows.Clear();
            foreach (var player in players)
                dgvPlayers.Rows.Add("", player.PositionInLineup, $"{player.FullName}", player.TeamAbbreviation);
            dgvPlayers.Columns[0].Visible = false;
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            _lastName = txtLastName.Text.Trim();

            _players = GetFilteredPlayers(_firstName, _lastName);
            btnAddPlayer.Visible = _players.Count == 0;
            btnAssignTo.Enabled = _players.Count > 0;
            FillSecondTable(_players);
        }

        private void btnUpdatePlayer_Click(object sender, EventArgs e)
        {
            Visible = false;
            using (var form = new AddPlayerForm(_currentPlayer))
                form.ShowDialog();
            Visible = true;
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            Visible = false;
            using (var form = new AddPlayerForm(true))
                form.ShowDialog();
            Visible = true;
        }

        private List<PlayerInLineupViewModel> GetFilteredPlayers(string firstName = "", string lastName = "")
        {
            var players = _allPlayers.ToList();

            if (firstName != string.Empty)
                players = players.Where(player => player.FirstName.StartsWith(firstName)).ToList();

            if (lastName != string.Empty)
                players = players.Where(player => player.SecondName.StartsWith(lastName)).ToList();

            return players;
        }


        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            _firstName = txtFirstName.Text.Trim();

            _players = GetFilteredPlayers(_firstName, _lastName);
            btnAddPlayer.Visible = _players.Count == 0;
            btnAssignTo.Enabled = _players.Count > 0;
            FillSecondTable(_players);
        }

        private async void ChangePlayerTeamForm_Load(object sender, EventArgs e) => _teams = await _teamsBL.GetListAsync();

        private async void ChangePlayerTeamForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;
            await FillTables();
        }
    }
}