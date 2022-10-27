using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;

namespace VKR.PL.NET5
{
    public partial class EditTeamForm : Form
    {
        private readonly ManagerBL _managerBl = new();
        private readonly DivisionBL _divisionBl = new();
        private readonly TeamsBL _teamsBl = new();

        private List<Division> _divisions;
        private List<Manager> _managers;

        private readonly Team _team;
        private readonly uint? _teamManager;

        public EditTeamForm(Team team)
        {
            InitializeComponent();
            _team = new Team
            {
                TeamAbbreviation = team.TeamAbbreviation,
                TeamName = team.TeamName,
                TeamCity = team.TeamCity,
                DivisionId = team.DivisionId,
                TeamManager = team.TeamManager,
                FoundationYear = team.FoundationYear
            };
            _teamManager = team.TeamManager;
            numFoundationYear.Maximum = DateTime.Today.Year;
            btnFireManager.Enabled = team.TeamManager is not null;
            Text = $"Updating {team.TeamCity} {team.TeamName}";
        }

        private async void EditTeamForm_Load(object sender, EventArgs e)
        {
            await FillLists();
            ShowTeamInfo();
        }

        private void ShowTeamInfo()
        {
            txtId.Text = _team.TeamAbbreviation;
            txtRegion.Text = _team.TeamCity;
            txtTeamName.Text = _team.TeamName;

            var division = _divisions.FirstOrDefault(d => d.Id == _team.DivisionId);
            cbDivision.SelectedItem = division;
            lbLeague.Text = division?.League.LeagueTitle;

            var manager = _managers.FirstOrDefault(m => m.Id == _teamManager);
            cbManager.SelectedItem = manager;

            numFoundationYear.Value = (decimal?)_team.FoundationYear ?? 1850;
        }

        private async Task FillLists()
        {
            var _divisionsTask = _divisionBl.GetAllDivisionsAsync();
            var _managersTask = _managerBl.GetAllManagersAsync();

            await Task.WhenAll(_divisionsTask, _managersTask);

            (_divisions, _managers) = (_divisionsTask.Result, _managersTask.Result);

            cbDivision.DataSource = _divisions;
            cbDivision.DisplayMember = "DivisionTitle";

            cbManager.DataSource = _managers;
            cbManager.DisplayMember = "FullName";
        }

        private void cbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            var division = cbDivision.SelectedItem as Division;
            _team.Division = division;
            lbLeague.Text = division?.League.LeagueTitle;
        }

        private void cbManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            _team.Manager = cbManager.SelectedItem as Manager;
        }

        private void btnFireManager_Click(object sender, EventArgs e)
        {
            _team.TeamManager = null;
            cbManager.SelectedItem = null;
        }

        private async void btnCheck_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) return;

            var updateTask = _teamsBl.UpdateTeam(_team);
            await Task.WhenAll(updateTask);
            btnClose.Visible = true;
        }

        private void txtRegion_Validating(object sender, CancelEventArgs e) => ControlValidator.TextBoxValidating(txtRegion, e);

        private void txtTeamName_Validating(object sender, CancelEventArgs e) => ControlValidator.TextBoxValidating(txtTeamName, e);

        private void txtRegion_Validated(object sender, EventArgs e)
        {
            _team.TeamCity = txtRegion.Text.Trim();
            btnClose.Visible = false;
        }

        private void txtTeamName_Validated(object sender, EventArgs e)
        {
            _team.TeamName = txtTeamName.Text.Trim();
            btnClose.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void numFoundationYear_ValueChanged(object sender, EventArgs e)
        {
            if (_team is null)
                return;

            _team.FoundationYear = (ushort)numFoundationYear.Value;
            btnClose.Visible = false;
        }
    }
}