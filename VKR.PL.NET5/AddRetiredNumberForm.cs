using System;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;
using VKR.PL.Utils.NET5;

namespace VKR.PL.NET5
{
    public partial class AddRetiredNumberForm : Form
    {
        private readonly TeamsBL _teamsBl = new();
        private readonly Team _team;
        private readonly RetiredNumber _newRetiredNumber;

        public AddRetiredNumberForm(Team team)
        {
            InitializeComponent();
            _team = team;
            _newRetiredNumber = new RetiredNumber
            {
                TeamId = team.TeamAbbreviation
            };
            dtpRetirementDate.MaxDate = DateTime.Today;
            panel1.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/TeamLogoForMenu/{_team.TeamAbbreviation}.png");
            txtTeam.Value = _team.FullTeamName;
        }

        private async void AddRetiredNumberForm_Load(object sender, EventArgs e)
        {
            var availableNumbers = await _teamsBl.GetAvailableNumbers(_team);
            numRetiredNumber.Items.AddRange(availableNumbers);
            numRetiredNumber.SelectedItem = availableNumbers.Min();
        }

        private void textPerson_Validated(object sender, EventArgs e) => _newRetiredNumber.Person = textPerson.Value;

        private void numRetiredNumber_SelectedItemChanged(object sender, EventArgs e) => _newRetiredNumber.Number = (byte)numRetiredNumber.SelectedItem;

        private void dtpRetirementDate_Validated(object sender, EventArgs e) => _newRetiredNumber.Date = dtpRetirementDate.Value;

        private async void btnAddRetiredNumber_Click(object sender, EventArgs e)
        {
            await _teamsBl.AddNewRetiredNumberAsync(_newRetiredNumber);
            DialogResult = DialogResult.OK;
        }
    }
}