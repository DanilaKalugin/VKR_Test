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
        private readonly PlayerBL players;

        public MainMenuForm()
        {
            InitializeComponent();
            manBL = new ManBL();
            teams = new TeamsBL();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            GetListOfPeopleWithBirthdayToday();
        }

        private void GetListOfPeopleWithBirthdayToday()
        {
            List<ManInTeam> men = manBL.GetListOfPeopleWithBirthdayToday();
            List<Team> teamsList = teams.GetAllTeams(); 
            foreach (ManInTeam man in men)
            {
                dataGridView1.Rows.Add("", man.Team, man.FullName, man.Age);
            }

            for (int i = 0; i < men.Count; i++)
            {
                Team ManTeam = teamsList.Where(team => team.TeamAbbreviation == men[i].Team).First();
                dataGridView1.Rows[i].Cells[0].Style.BackColor = ManTeam.TeamColor[0];
                dataGridView1.Rows[i].Cells[0].Style.SelectionBackColor = ManTeam.TeamColor[0];
            }
        }

        private void btn_StartNewMatch_Click(object sender, EventArgs e)
        {
            TeamsSelectForm form = new TeamsSelectForm();
            form.ShowDialog();
        }

        private void btnStandings_Click(object sender, EventArgs e)
        {
            StandingsForm form = new StandingsForm();
            form.ShowDialog();
        }

        private void btnPlayerStats_Click(object sender, EventArgs e)
        {
            PlayerStatsForm form = new PlayerStatsForm();
            form.ShowDialog();
        }

        private void btnLineups_Click(object sender, EventArgs e)
        {
            LineupsForm form = new LineupsForm();
            form.ShowDialog();
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            MatchResultsForm form = new MatchResultsForm();
            form.ShowDialog();
        }
    }
}