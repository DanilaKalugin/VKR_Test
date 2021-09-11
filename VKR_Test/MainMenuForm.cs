using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            try
            {
                InitializeComponent();
                manBL = new ManBL();
                teams = new TeamsBL();
                matchBL = new MatchBL();
                TitleForm title = new TitleForm();
                title.ShowDialog();
            }
            catch (SqlException)
            {
                ShowInTaskbar = false;
                ServerNotFoundForm form = new ServerNotFoundForm();
                form.ShowDialog();
                Environment.Exit(0);
            }
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
                if (men[i].Team != "")
                {
                    Team ManTeam = teamsList.Where(team => team.TeamAbbreviation == men[i].Team).First();
                    dgvBirthDays.Rows[i].Cells[0].Style.BackColor = ManTeam.TeamColor[0];
                    dgvBirthDays.Rows[i].Cells[0].Style.SelectionBackColor = ManTeam.TeamColor[0];
                }
                else
                {
                    dgvBirthDays.Rows[i].Cells[0].Style.BackColor = Color.FromArgb(220, 220, 220);
                    dgvBirthDays.Rows[i].Cells[0].Style.SelectionBackColor = Color.FromArgb(220, 220, 220);
                }
            }
            panel1.Visible = dgvBirthDays.Rows.Count > 0;
            Width = dgvBirthDays.Rows.Count > 0 ? 1554 : 1204;
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
            StatsMenuForm form = new StatsMenuForm();
            Visible = false;
            form.ShowDialog();
            GetListOfPeopleWithBirthdayToday();
        }

        private void btnLineups_Click(object sender, EventArgs e)
        {
            RostersMenuForm form = new RostersMenuForm();
            Visible = false;
            form.ShowDialog();
            GetListOfPeopleWithBirthdayToday();
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            MatchResultsMenuForm form = new MatchResultsMenuForm();
            Visible = false;
            form.ShowDialog();
            GetListOfPeopleWithBirthdayToday();
        }

        private void btnNewMatch_Click(object sender, EventArgs e)
        {
            Match match = new Match(DateTime.Now, true);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}