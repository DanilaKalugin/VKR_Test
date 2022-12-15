using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;
using VKR.PL.Utils.NET5;

namespace VKR.PL.NET5
{
    public partial class LineupsForm : Form
    {
        public enum RosterType { StartingLineups, Reserves, FreeAgents }
        private readonly RosterType _rosterType;

        private readonly PlayerBL _playersBl = new();
        private readonly TeamsBL _teamsBl = new();
        private readonly MatchBL _matchBl = new();
        private readonly RostersBL _rostersBl = new();
        private readonly PlayerMovesBL _playerMovesBl = new();

        private List<List<List<PlayerInLineupViewModel>>> _teamsLineups;
        private List<List<List<PlayerInLineupViewModel>>> _teamsBench;
        private List<Team> _teams;
        private int _teamNumber;
        private int _lineupNumber;
        private readonly string[] _typesOfLineups = { "RH W/ DH", "RH NO DH", "LH W/ DH", "LH NO DH", "ROTATION" };
        private bool _lineupChanged;
        private DateTime _matchDate;
        private bool _isAdmin;
        private PlayerInLineupViewModel _player;

        public LineupsForm(RosterType rosterType, bool isAdmin)
        {
            InitializeComponent();

            _rosterType = rosterType;
            _isAdmin = isAdmin;

            btnMoveToLowerRoster.Visible = _isAdmin;
            btnMoveToUpperRoster.Visible = _isAdmin;
            btnUpdatePlayer.Visible = _isAdmin;
            Opacity = 0;
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
            panelTeamLogo.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/TeamLogoForMenu/{_teams[teamNumber].TeamAbbreviation}.png");
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

            btnMoveToLowerRoster.Enabled = _teamsLineups[teamNumber][lineupNumber].Count > 0;
            btnMoveToUpperRoster.Enabled = bench.Count > 0;

            _lineupChanged = true;
        }

        private void btnIncLineupTypeNumberBy1_Click(object sender, EventArgs e)
        {
            _lineupNumber = _lineupNumber < _teamsLineups[_teamNumber].Count - 1 ? _lineupNumber + 1 : 0;
            DisplayRoster(_teamNumber, _lineupNumber);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLineup.SelectedRows.Count == 0) return;

            _player = _teamsLineups[_teamNumber][_lineupNumber][dgvLineup.SelectedRows[0].Index];
            ShowNewPlayer(dgvLineup, dgvBench, _player);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) => ShowNewPlayer(dgvLineup, dgvBench, _teamsLineups[_teamNumber][_lineupNumber][dgvLineup.SelectedRows[0].Index]);

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _lineupChanged = false;
            _player = _rosterType == RosterType.FreeAgents
                ? _teamsBench[0][0][dgvBench.SelectedRows[0].Index]
                : _teamsBench[_teamNumber][_lineupNumber][dgvBench.SelectedRows[0].Index];
            ShowNewPlayer(dgvBench, dgvLineup, _player);
        }

        private async void ShowNewPlayer(DataGridView dgv1, DataGridView dgv2, Player player)
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
                player.BattingStats = await _playersBl.GetBattingStatsByCode(player.Id, _matchDate.Year);
                lbFirstValue.Text = player.BattingStats.AVG.ToString("#.000", new CultureInfo("en-US"));
                lbSecondValue.Text = player.BattingStats.HomeRuns.ToString();
                lbThirdValue.Text = player.BattingStats.RBI.ToString();
            }
            else
            {
                player.PitchingStats = await _playersBl.GetPitchingStatsByCode(player.Id, _matchDate.Year);
                lbFirstValue.Text = player.PitchingStats.ERA.ToString("0.00", new CultureInfo("en-US"));
                lbSecondValue.Text = player.PitchingStats.Strikeouts.ToString();
                lbThirdValue.Text = player.PitchingStats.WHIP.ToString("0.00", new CultureInfo("en-US"));
            }
            
            label7.Text = $@"Positions: {string.Join(", ", player.Positions.Select(position => position.ShortTitle))}";

            if (dgv1.SelectedRows.Count <= 0) return;

            pbPlayerPhoto.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/PlayerPhotos/Player{player.Id:0000}.png");

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

        private async void LineupsForm_Load(object sender, EventArgs e)
        {
            var teamsTask = _teamsBl.GetListAsync();
            var matchDateTask = _matchBl.GetMaxDateForAllMatchesAsync();

            await Task.WhenAll(teamsTask, matchDateTask);

            (_teams, _matchDate) = (teamsTask.Result, matchDateTask.Result);
            await FillTables();

            lbl_LineupHeader.Visible = _rosterType == RosterType.StartingLineups;
            btnDecLineupTypeNumberBy1.Visible = _rosterType == RosterType.StartingLineups;
            btnIncLineupTypeNumberBy1.Visible = _rosterType == RosterType.StartingLineups;
            lbLineUpType.Visible = _rosterType == RosterType.StartingLineups;
        }

        private async void btnAssignTo_Click(object sender, EventArgs e)
        {
            _player = _teamsLineups[_teamNumber][_lineupNumber][dgvLineup.SelectedRows[0].Index];
            var team = _teams[_teamNumber];

            switch (_rosterType)
            {
                case RosterType.StartingLineups:
                    await _playerMovesBl.RemoveFromStartingLineup(_player, team, (byte)(_lineupNumber + 1));
                    break;
                case RosterType.Reserves:
                    await _playerMovesBl.ChangePlayerInTeamStatus(_player, team, InTeamStatusEnum.Reserve);
                    break;
                case RosterType.FreeAgents:
                    await _playerMovesBl.ReleasePlayer(_player);
                    break;
            }

            await FillTables();
        }

        private async Task FillTables()
        {
            var f = new LoadingForm();
            f.TopMost = true;
            f.Show();

            switch (_rosterType)
            {
                case RosterType.StartingLineups:
                    var lineupsTask = _rostersBl.GetRoster(RostersBL.TypeOfRoster.Starters);
                    var benchTask = _rostersBl.GetRoster(RostersBL.TypeOfRoster.Bench);
                    await Task.WhenAll(lineupsTask, benchTask);
                    (_teamsLineups, _teamsBench) = (lineupsTask.Result, benchTask.Result);
                    break;
                case RosterType.Reserves:
                    var activePlayersTask = _rostersBl.GetRoster(RostersBL.TypeOfRoster.ActivePlayers);
                    var reservePlayersTask = _rostersBl.GetRoster(RostersBL.TypeOfRoster.Reserve);
                    await Task.WhenAll(activePlayersTask, reservePlayersTask);
                    (_teamsLineups, _teamsBench) = (activePlayersTask.Result, reservePlayersTask.Result);
                    break;
                case RosterType.FreeAgents:
                    var allPlayersTask = _rostersBl.GetRoster(RostersBL.TypeOfRoster.ActiveAndReserve);
                    var freeAgentsTask = _rostersBl.GetFreeAgents();
                    await Task.WhenAll(allPlayersTask, freeAgentsTask);
                    (_teamsLineups, _teamsBench) = (allPlayersTask.Result, freeAgentsTask.Result);
                    break;
            }
            TeamChanged(_teamNumber);
            Opacity = 1;
            f.Dispose();
        }

        private void btnDecLineupTypeNumberBy1_Click(object sender, EventArgs e)
        {
            _lineupNumber = _lineupNumber > 0 ? _lineupNumber - 1 : _teamsLineups[_teamNumber].Count - 1;
            DisplayRoster(_teamNumber, _lineupNumber);
        }

        private async void MoveToActiveRoster_Click(object sender, EventArgs e)
        {
            _player = _rosterType == RosterType.FreeAgents
                ? _teamsBench[0][0][dgvBench.SelectedRows[0].Index]
                : _teamsBench[_teamNumber][_lineupNumber][dgvBench.SelectedRows[0].Index];

            var team = _teams[_teamNumber];

            switch (_rosterType)
            {
                case RosterType.StartingLineups:
                    {
                        var position = GetPlayerPositionForPlayer(_player);
                        if (position is not null)
                            await _playerMovesBl.AssignPlayerToStartingLineup(_player, team, (byte)(_lineupNumber + 1), position, (byte)(_teamsLineups[_teamNumber][_lineupNumber].Count + 1));
                        break;
                    }
                case RosterType.Reserves:
                    await _playerMovesBl.ChangePlayerInTeamStatus(_player, team, InTeamStatusEnum.ActiveRoster);
                    break;
                case RosterType.FreeAgents:
                    await _playerMovesBl.MovePlayerToNewTeam(_player, team);
                    break;
            }

            await FillTables();
        }

        private PlayerPosition? GetPlayerPositionForPlayer(Player player)
        {
            var filledPositionsInLineup = _teamsLineups[_teamNumber][_lineupNumber].Select(p => p.PositionInLineup).ToList();
            var positions = player.Positions.ToList();

            if (_lineupNumber % 2 == 0)
                positions.Add(new PlayerPosition
                {
                    Number = 10,
                    ShortTitle = "DH",
                    FullTitle = "Designated Hitter"
                });

            var availablePositions = positions.Where(pp => !filledPositionsInLineup.Contains(pp.ShortTitle)).ToList();

            if (availablePositions.Count <= 1) 
                return availablePositions.First();

            var form = new SelectPlayerPositionForm(player, availablePositions, _typesOfLineups[_lineupNumber]);
            form.ShowDialog();
            return form.DialogResult == DialogResult.OK ? form.Position : null;
        }

        private void btnUpdatePlayer_Click(object sender, EventArgs e)
        {
            Visible = false;

            using (var form = new AddPlayerForm(_player)) 
                form.ShowDialog();

            Visible = true;
        }

        private async void LineupsForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;
            await FillTables();
        }
    }
}