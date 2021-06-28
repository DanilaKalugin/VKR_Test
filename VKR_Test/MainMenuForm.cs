using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class MainMenuForm : Form
    {
        private readonly ManBL manBL;
        private readonly TeamsBL teams;
        private readonly MatchBL matchBL;
        private int MatchNumberForDelete;

        public MainMenuForm()
        {
            InitializeComponent();
            manBL = new ManBL();
            teams = new TeamsBL();
            matchBL = new MatchBL();
            TitleForm title = new TitleForm();
            title.ShowDialog();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            GetListOfPeopleWithBirthdayToday();
        }

        private void GetListOfPeopleWithBirthdayToday()
        {
            Visible = true;
            List<ManInTeam> men = manBL.GetListOfPeopleWithBirthdayToday();
            List<Team> teamsList = teams.GetAllTeams();
            dgvBirthDays.Rows.Clear();
            foreach (ManInTeam man in men)
            {
                dgvBirthDays.Rows.Add("", man.Team, man.FullName, man.Age);
            }

            for (int i = 0; i < men.Count; i++)
            {
                Team ManTeam = teamsList.Where(team => team.TeamAbbreviation == men[i].Team).First();
                dgvBirthDays.Rows[i].Cells[0].Style.BackColor = ManTeam.TeamColor[0];
                dgvBirthDays.Rows[i].Cells[0].Style.SelectionBackColor = ManTeam.TeamColor[0];
            }
        }

        private void btn_StartNewMatch_Click(object sender, EventArgs e)
        {
            Program.MatchDate = matchBL.GetDateForNextMatch();
            Match match = new Match(Program.MatchDate, false);
            TeamsSelectForm form = new TeamsSelectForm(match);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Yes)
            {
                MatchNumberForDelete = form.MatchNumberForDelete;
                matchBL.DeleteThisMatch(MatchNumberForDelete);
            }
            form.Dispose();
            GetListOfPeopleWithBirthdayToday();
        }

        private void btnStandings_Click(object sender, EventArgs e)
        {
            StandingsForm form = new StandingsForm();
            Visible = false;
            form.ShowDialog();
            GetListOfPeopleWithBirthdayToday();
        }

        private void btnPlayerStats_Click(object sender, EventArgs e)
        {
            PlayerStatsForm form = new PlayerStatsForm();
            Visible = false;
            form.ShowDialog();
            GetListOfPeopleWithBirthdayToday();
        }

        private void btnLineups_Click(object sender, EventArgs e)
        {
            LineupsForm form = new LineupsForm();
            Visible = false;
            form.ShowDialog();
            GetListOfPeopleWithBirthdayToday();
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            MatchResultsForm form = new MatchResultsForm();
            Visible = false;
            form.ShowDialog();
            GetListOfPeopleWithBirthdayToday();
        }

        private void btnNewMatch_Click(object sender, EventArgs e)
        {
            Program.MatchDate = matchBL.GetDateForNextMatch();
            Match match = new Match(Program.MatchDate, true);
            Visible = false;
            TeamsSelectForm form = new TeamsSelectForm(match);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Yes)
            {
                MatchNumberForDelete = form.MatchNumberForDelete;
                form.Dispose();
                matchBL.DeleteThisMatch(MatchNumberForDelete);
            }
            GetListOfPeopleWithBirthdayToday();
        }

        private void btnResultsByDate_Click(object sender, EventArgs e)
        {
            MatchResultsForm form = new MatchResultsForm(matchBL.GetMaxDateForAllMatches(), false);
            Visible = false;
            form.ShowDialog();
            GetListOfPeopleWithBirthdayToday();
        }
    }
}