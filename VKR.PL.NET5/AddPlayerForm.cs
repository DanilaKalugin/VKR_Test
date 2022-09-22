using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;

namespace VKR.PL.NET5
{
    public partial class AddPlayerForm : Form
    {
        private readonly CitiesBL _citiesBL = new();
        private readonly PlayerPositionsBL _playerPositionsBl = new();
        private readonly PlayerBL _playersBl = new();

        private List<City> _cities = new();
        private readonly List<PlayerPosition> _positions = new();
        private Player? _player;
        private readonly bool _addingPlayer;

        private AddPlayerForm()
        {
            InitializeComponent();

            _cities = _citiesBL.GetAllCities();
            cbPlaceOfBirth.DataSource = _cities;
            cbPlaceOfBirth.DisplayMember = "CityLocation";

            _positions = _playerPositionsBl.GetAvailablePlayerPositions();
            lbRewards.DataSource = _positions;
            lbRewards.DisplayMember = "FullTitle";

            dtpBirthDate.MaxDate = DateTime.Today.AddYears(-16);
            dtpBirthDate.MinDate = DateTime.Today.AddYears(-100);
        }

        public AddPlayerForm(Player player) : this()
        {
            _player = player;
            txtFirstName.Text = player.FirstName;
            txtLastName.Text = player.SecondName;
            dtpBirthDate.Value = player.DateOfBirth;
            numPlayerNumber.Value = player.PlayerNumber;

            cbPlaceOfBirth.SelectedItem = _cities.First(city => city.Id == _player.City.Id);

            foreach (var index in _player.Positions.Select(pp => _positions.FindIndex(position => position.Number == pp.Number)))
                lbRewards.SetItemChecked(index, true);

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
                Id = _playersBl.GetIdForNewPlayer(),
                Positions = new List<PlayerPosition>()
            };
            _addingPlayer = true;
        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e) => TextBoxValidating(txtFirstName, e);

        private void txtFirstName_Validated(object sender, EventArgs e) => _player.FirstName = txtFirstName.Text.Trim();

        private void cbThrowLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (cbThrowLeft.Checked) _player.PlayerPitchingHand = PitchingHandEnum.Left;
        }

        private void cbThrowRight_CheckedChanged(object sender, EventArgs e)
        {
            if (cbThrowRight.Checked) _player.PlayerPitchingHand = PitchingHandEnum.Right;
        }

        private void cbBattingLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBattingLeft.Checked) _player.PlayerBattingHand = BattingHandEnum.Left;
        }

        private void cbBattingRight_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBattingRight.Checked) _player.PlayerBattingHand = BattingHandEnum.Right;
        }

        private void cbBattingSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBattingSwitch.Checked) _player.PlayerBattingHand = BattingHandEnum.Switch;
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

        private void cbPlaceOfBirth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_player is null) return;
            _player.City = cbPlaceOfBirth.SelectedItem as City;
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

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) return;

            if (_addingPlayer)
                _playersBl.AddPlayer(_player);
            else _playersBl.UpdatePlayer(_player);
            DialogResult = DialogResult.OK;
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e) => TextBoxValidating(txtLastName, e);

        private static void TextBoxValidating(Control control, System.ComponentModel.CancelEventArgs e)
        {
            var text = control.Text.Trim();

            if (string.IsNullOrWhiteSpace(text) || text.Any(char.IsDigit))
            {
                control.BackColor = Color.DarkRed;
                e.Cancel = true;
            }
            else
            {
                control.BackColor = Color.WhiteSmoke;
                e.Cancel = false;
            }
        }

        private void txtLastName_Validated(object sender, EventArgs e) => _player.SecondName = txtLastName.Text.Trim();

        private void AddPlayerForm_Load(object sender, EventArgs e)
        {
            Text = _addingPlayer ? "Adding new player" : $"Updating {_player?.FullName}";
            txtId.Text = _player?.Id.ToString();
            btnCheck.Text = _addingPlayer ? "ADD" : "UPDATE";
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            Visible = false;

            using (var form = new AddCityForm())
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    _cities = _citiesBL.GetAllCities();
                    cbPlaceOfBirth.DataSource = _cities;
                }
            }

            Visible = true;
        }

        private void cbPlaceOfBirth_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_player?.City is null)
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
    }
}