using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;

namespace VKR.PL.NET5
{
    public partial class AddPlayerForm : Form
    {
        private readonly CitiesBL _citiesBl = new();
        private readonly PlayerPositionsBL _playerPositionsBl = new();
        private readonly PlayerBL _playersBl = new();

        private List<City> _cities = new();
        private List<PlayerPosition> _positions = new();
        private readonly Player? _player;
        private readonly bool _addingPlayer;
        private readonly int _cityId;

        private AddPlayerForm()
        {
            InitializeComponent();

            dtpBirthDate.MaxDate = DateTime.Today.AddYears(-16);
            dtpBirthDate.MinDate = DateTime.Today.AddYears(-100);
        }

        public AddPlayerForm(Player player) : this()
        {
            _player = player;
            _cityId = player.City.Id;
            txtFirstName.Value = player.FirstName;
            txtLastName.Value = player.SecondName;
            dtpBirthDate.Value = player.DateOfBirth;
            numPlayerNumber.Value = player.PlayerNumber;

            cbThrowLeft.Checked = _player.PitchingHand.PitchingHandId == PitchingHandEnum.Left;
            cbThrowRight.Checked = _player.PitchingHand.PitchingHandId == PitchingHandEnum.Right;

            cbBattingLeft.Checked = _player.BattingHand.BattingHandId == BattingHandEnum.Left;
            cbBattingRight.Checked = _player.BattingHand.BattingHandId == BattingHandEnum.Right;
            cbBattingSwitch.Checked = _player.BattingHand.BattingHandId == BattingHandEnum.Switch;
            _addingPlayer = false;
        }

        public AddPlayerForm(bool addingPlayer) : this()
        {
            _player = new Player
            {
                Positions = new List<PlayerPosition>(),
                CurrentPlayerStatus = PlayerStatusEnum.FreeAgent
            };
            _addingPlayer = true;
        }

        private void cbThrowLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbThrowLeft.Checked) return;
            _player.PlayerPitchingHand = PitchingHandEnum.Left;
        }

        private void cbThrowRight_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbThrowRight.Checked) return;
            _player.PlayerPitchingHand = PitchingHandEnum.Right;
        }

        private void cbBattingLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbBattingLeft.Checked) return;
            _player.PlayerBattingHand = BattingHandEnum.Left;
        }

        private void cbBattingRight_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbBattingRight.Checked) return;
            _player.PlayerBattingHand = BattingHandEnum.Right;
        }

        private void cbBattingSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbBattingSwitch.Checked) return;
            _player.PlayerBattingHand = BattingHandEnum.Switch;
        }

        private void numPlayerNumber_ValueChanged(object sender, EventArgs e)
        {
            if (_player is null) return;
            _player.PlayerNumber = (byte)numPlayerNumber.Value;
        }

        private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            if (_player is null) return;
            _player.DateOfBirth = dtpBirthDate.Value;
        }

        private void lbRewards_Validated(object sender, EventArgs e)
        {
            _player?.Positions.Clear();
            for (var index = 0; index < lbRewards.CheckedItems.Count; index++)
            {
                var item = lbRewards.CheckedIndices[index];
                _player?.Positions.Add(_positions[item]);
            }
        }

        private async void btnCheck_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) return;

            if (_addingPlayer)
                await _playersBl.AddPlayer(_player);
            else await _playersBl.UpdatePlayer(_player);

            DialogResult = DialogResult.OK;
        }

        private async void AddPlayerForm_Load(object sender, EventArgs e)
        {
            await FillCitiesTable();

            _positions = await _playerPositionsBl.GetAvailablePlayerPositions();
            lbRewards.DataSource = _positions;
            lbRewards.DisplayMember = "FullTitle";

            foreach (var index in _player?.Positions.Select(pp => _positions.FindIndex(position => position.Number == pp.Number))!)
                lbRewards.SetItemChecked(index, true);

            if (!_addingPlayer)
                cbPlaceOfBirth.SelectedItem = _cities.First(city => city.Id == _cityId);
            else _player.Id = await _playersBl.GetIdForNewPlayer();

            Text = _addingPlayer ? "Adding new player" : $"Updating {_player?.FullName}";
            txtId.Value = _player?.Id.ToString();
            btnCheck.Text = _addingPlayer ? "ADD" : "UPDATE";
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            Visible = false;

            using (var form = new AddCityForm()) 
                form.ShowDialog();

            Visible = true;
        }

        private void cbPlaceOfBirth_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cbPlaceOfBirth.SelectedValue is null)
            {
                cbPlaceOfBirth.BackColor = Color.DarkRed;
                e.Cancel = true;
            }
            else
            {
                cbPlaceOfBirth.BackColor = Color.WhiteSmoke;
                e.Cancel = false;
            }
        }

        private void dtpBirthDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_player?.DateOfBirth.Year == 1)
            {
                dtpBirthDate.BackColor = Color.DarkRed;
                e.Cancel = true;
            }
            else
            {
                dtpBirthDate.BackColor = Color.WhiteSmoke;
                e.Cancel = false;
            }
        }

        private async Task FillCitiesTable()
        {
            _cities = await _citiesBl.GetAllCitiesAsync();
            cbPlaceOfBirth.DataSource = _cities;
            cbPlaceOfBirth.DisplayMember = "CityLocation";
            cbPlaceOfBirth.ValueMember = "Id";
        }

        private void txtFirstName_Validated(object sender, EventArgs e) => _player.FirstName = txtFirstName.Value;

        private void txtLastName_Validated(object sender, EventArgs e) => _player.SecondName = txtLastName.Value;

        private async void AddPlayerForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;
            await FillCitiesTable();
        }

        private void cbPlaceOfBirth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_player is null) return; 
            _player.PlaceOfBirth = (short)cbPlaceOfBirth.SelectedValue;
        }
    }
}