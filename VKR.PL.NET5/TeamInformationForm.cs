using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;
using VKR.PL.Utils.NET5;

namespace VKR.PL.NET5
{
    public partial class TeamInformationForm : Form
    {
        private readonly TeamsBL _teamsBl = new();
        private readonly PrimaryTeamColorBL _primaryTeamColorBl = new();

        private List<Team> _teams;
        private List<TeamColor> _primaryColor;
        private int _teamNumber;

        public TeamInformationForm()
        {
            InitializeComponent();
            _teamNumber = 0;
        }

        private async void TeamEditingForm_Load(object sender, EventArgs e)
        {
            await FillTeamsAndColors();
            ShowTeam();
        }

        private void btnIncreaseTeamNumberBy1_Click(object sender, EventArgs e)
        {
            _teamNumber = _teamNumber < _teams.Count - 1 ? _teamNumber + 1 : 0;

            ShowTeam();
        }

        private void ShowTeam()
        {
            var team = _teams[_teamNumber];

            ShowTeamStadiums(team);

            var teamColor = _primaryColor.FirstOrDefault(pc => pc.TeamName == team.TeamAbbreviation)!.Color;

            lbTeamTitle.BackColor = teamColor;
            btnIncreaseTeamNumberBy1.ForeColor = teamColor;
            btnDecreaseTeamNumberBy1.ForeColor = teamColor;
            dataGridView1.DefaultCellStyle.SelectionBackColor = teamColor;
            dataGridView1.AlternatingRowsDefaultCellStyle.SelectionBackColor = teamColor;
            lbManagerHeader.ForeColor = teamColor;

            lbTeamTitle.Text = team.TeamName;
            txtId.Text = team.TeamAbbreviation;
            lbRegion.Text = team.TeamCity;
            lbTeamName.Text = team.TeamName;
            lbDivision.Text = team.Division.DivisionTitle;
            lbLeague.Text = team.Division.League.LeagueTitle;

            pbTeamLogo.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/TeamLogoForMenu/{team.TeamAbbreviation}.png");
            pbCapLogo.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/SmallTeamLogos/{team.TeamAbbreviation}.png");
            pbSubstitutionLogo.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/TeamLogosForSubstitution/{team.TeamAbbreviation}.png");

            if (team.Manager is not null)
                ShowManager(team.Manager);
            else ShowManager();
        }

        private void ShowManager(Manager teamManager)
        {
            lbManager.Text = teamManager.FullName;
            lbManagerDateOfBirth.Text = teamManager.DateOfBirth.ToShortDateString().ToUpper();
            lbManagerPlaceOfBirth.Text = teamManager.City.CityLocation;
            pbManagerPhoto.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/Managers/Manager{teamManager.Id:000}.jpg");
        }

        private void ShowManager()
        {
            lbManager.Text = string.Empty;
            lbManagerDateOfBirth.Text = string.Empty;
            lbManagerPlaceOfBirth.Text = string.Empty;
            pbManagerPhoto.BackgroundImage = null;
        }

        private void ShowTeamStadiums(Team team)
        {
            dataGridView1.Rows.Clear();

            foreach (var stadium in team.StadiumsForMatchTypes)
                dataGridView1.Rows.Add(stadium.TypeOfMatchId, stadium.Stadium.StadiumTitle);
        }

        private void btnDecreaseTeamNumberBy1_Click(object sender, EventArgs e)
        {
            _teamNumber = _teamNumber > 0 ? _teamNumber - 1 : _teams.Count - 1;

            ShowTeam();
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private async void btnEditTeamMainInfo_Click(object sender, EventArgs e)
        {
            var team = _teams[_teamNumber];
            using var form = new EditTeamForm(team);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK) 
                await FillTeamsAndColors();
        }

        private async Task FillTeamsAndColors()
        {
            var teamsTask = _teamsBl.GetTeamsWithInfoAsync();
            var primaryColorsTask = _primaryTeamColorBl.GetPrimaryTeamColorsAsync();

            await Task.WhenAll(teamsTask, primaryColorsTask);

            (_teams, _primaryColor) = (teamsTask.Result, primaryColorsTask.Result);
            ShowTeam();
        }
    }
}