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

        public TeamInformationForm() => InitializeComponent();

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

            ShowManager(team.Manager);
        }

        private void ShowManager(Manager? teamManager)
        {
            lbManager.Text = teamManager?.FullName ?? string.Empty;
            lbManagerDateOfBirth.Text = teamManager?.DateOfBirth.ToShortDateString() ?? string.Empty;
            lbManagerPlaceOfBirth.Text = teamManager?.City.CityLocation ?? string.Empty;
            pbManagerPhoto.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/Managers/Manager{teamManager?.Id:000}.jpg");
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
            Visible = false;
            var team = _teams[_teamNumber];

            using (var form = new EditTeamForm(team))
                form.ShowDialog();

            Visible = true;
        }

        private async Task FillTeamsAndColors()
        {
            var teamsTask = _teamsBl.GetTeamsWithInfoAsync();
            var primaryColorsTask = _primaryTeamColorBl.GetPrimaryTeamColorsAsync();

            await Task.WhenAll(teamsTask, primaryColorsTask);

            (_teams, _primaryColor) = (teamsTask.Result, primaryColorsTask.Result);
        }

        private async void TeamInformationForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;

            await FillTeamsAndColors();
            ShowTeam();
        }
    }
}