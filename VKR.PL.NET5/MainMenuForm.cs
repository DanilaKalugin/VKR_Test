using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;

namespace VKR.PL.NET5
{
    public partial class MainMenuForm : Form
    {
        private readonly ManBL _manBL = new();
        private readonly TeamsBL _teamsBL = new();
        private readonly MatchBL _matchBL = new();

        public MainMenuForm()
        {
            try
            {
                InitializeComponent();

                using var title = new TitleForm();
                title.ShowDialog();
            }
            catch (SqlException)
            {
                ShowInTaskbar = false;
                using var form = new ServerNotFoundForm();
                form.ShowDialog();
                Application.Exit();
            }
        }

        private async void MainMenuForm_Load(object sender, EventArgs e)
        {
            await UpdateBirthDayTable();
        }

        private async Task UpdateBirthDayTable()
        {
            var man = await _manBL.GetListOfPeopleWithBirthdayToday();
            var teams = await _teamsBL.GetAllTeams();
            dgvBirthDays.Invoke((Action<List<ManInTeam>>)FillBirthDayTable, man);
            dgvBirthDays.Invoke((Action<List<Team>, List<ManInTeam>>)FillColors, teams, man);
        }

        private void FillColors(List<Team> teams, List<ManInTeam> men)
        {
            if (men.Count == 0) return;

            for (var i = 0; i < men.Count; i++)
            {
                var rowColor = men[i].TeamName != "" 
                    ? teams.First(team => team.TeamAbbreviation == men[i].TeamName).TeamColors[0].Color 
                    : Color.FromArgb(220, 220, 220);

                dgvBirthDays.Rows[i].Cells[0].Style.BackColor = rowColor;
                dgvBirthDays.Rows[i].Cells[0].Style.SelectionBackColor = rowColor;
            }
        }

        private void FillBirthDayTable(IList<ManInTeam> men)
        {
            dgvBirthDays.Rows.Clear();
            foreach (var man in men) dgvBirthDays.Rows.Add("", man.TeamName, man.FullName, man.Age);

            if (men.Count != 0) return;
            Width -= panel1.Width;
        }

        private async void btn_StartNewMatch_Click(object sender, EventArgs e)
        {
            Program.MatchDate = _matchBL.GetDateForNextMatch();
            var match = new Match(Program.MatchDate, TypeOfMatchEnum.RegularSeason);

            using (var form = new TeamsSelectForm(match))
            {
                form.ShowDialog();
                if (form.DialogResult != DialogResult.Yes) return;

                var matchNumberForDelete = form.MatchNumberForDelete;
                _matchBL.DeleteThisMatch(matchNumberForDelete);
            }

            await UpdateBirthDayTable();
        }

        private async void btnStandings_Click(object sender, EventArgs e)
        {
            using (var form = new StandingsForm())
            {
                Visible = false;
                form.ShowDialog();
            }
            Visible = true;

            await UpdateBirthDayTable();
        }

        private async void btnPlayerStats_Click(object sender, EventArgs e)
        {
            using (var form = new StatsMenuForm())
            {
                Visible = false;
                form.ShowDialog();
            }

            await UpdateBirthDayTable();
        }

        private async void btnLineups_Click(object sender, EventArgs e)
        {
            using (var form = new RostersMenuForm())
            {
                Visible = false;
                form.ShowDialog();
            }

            await UpdateBirthDayTable();
        }

        private async void btnResults_Click(object sender, EventArgs e)
        {
            using (var form = new MatchResultsMenuForm())
            {
                Visible = false;
                form.ShowDialog();
            }
            await UpdateBirthDayTable();
        }

        private async void btnNewMatch_Click(object sender, EventArgs e)
        {
            var match = new Match(DateTime.Now, TypeOfMatchEnum.QuickMatch);
            Visible = false;

            using (var form = new TeamsSelectForm(match))
            {
                form.ShowDialog();

                if (form.DialogResult != DialogResult.Yes) return;

                var matchNumberForDelete = form.MatchNumberForDelete;
                form.Dispose();
                _matchBL.DeleteThisMatch(matchNumberForDelete);
            }

            await UpdateBirthDayTable();
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}