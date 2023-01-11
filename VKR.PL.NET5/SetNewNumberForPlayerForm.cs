using System;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities.Tables;
using VKR.PL.Utils.NET5;

namespace VKR.PL.NET5
{
    public partial class SetNewNumberForPlayerForm : Form
    {
        private readonly TeamsBL _teamsBl = new();
        private readonly PlayerBL _playerBl = new();

        private readonly Team _team;
        private readonly Player? _player;
        private byte _newNumber;

        public SetNewNumberForPlayerForm(Team team, Player? player)
        {
            InitializeComponent();
            _team = team;
            _player = player;

            txtTeam.Value = _team.FullTeamName;
            txtPlayer.Value = _player.FullName;

            panel1.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/TeamLogoForMenu/{_team.TeamAbbreviation}.png");
        }

        private async void SetNewNumberForPlayerForm_Load(object sender, EventArgs e)
        {
            var availableNumbers = await _teamsBl.GetAvailableNumbers(_team);
            domainUpDown1.Items.AddRange(availableNumbers);
            domainUpDown1.SelectedItem = _player.PlayerNumber;
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            await _playerBl.SetNewNumberForPlayerAsync(_player, _newNumber);
            DialogResult = DialogResult.OK;
        }

        private void domainUpDown1_Validated(object sender, EventArgs e) => _newNumber = (byte)domainUpDown1.SelectedItem;
    }
}