using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.Entities.NET5;

namespace VKR.PL.NET5
{
    public partial class MainMenuForm : Form
    {
        private readonly ManBL _manBL = new();
        private readonly TeamsBL _teamsBL = new();
        private readonly MatchBL _matchBL = new();
        private int _matchNumberForDelete;

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

        private void MainMenuForm_Load(object sender, EventArgs e) => GetListOfPeopleWithBirthdayToday();

        private void GetListOfPeopleWithBirthdayToday()
        {
            Visible = true;
            var men = _manBL.GetListOfPeopleWithBirthdayToday();
            var teamsList = _teamsBL.GetAllTeams();
            dgvBirthDays.Rows.Clear();

            foreach (var man in men) dgvBirthDays.Rows.Add("", man.Team, man.FullName, man.Age);

            for (var i = 0; i < men.Count; i++)
            {
                if (men[i].Team != "")
                {
                    var manTeam = teamsList.First(team => team.TeamAbbreviation == men[i].Team);
                    dgvBirthDays.Rows[i].Cells[0].Style.BackColor = manTeam.TeamColor[0];
                    dgvBirthDays.Rows[i].Cells[0].Style.SelectionBackColor = manTeam.TeamColor[0];
                }
                else
                {
                    dgvBirthDays.Rows[i].Cells[0].Style.BackColor = Color.FromArgb(220, 220, 220);
                    dgvBirthDays.Rows[i].Cells[0].Style.SelectionBackColor = Color.FromArgb(220, 220, 220);
                }
            }
            panel1.Visible = dgvBirthDays.Rows.Count > 0;

            if (dgvBirthDays.Rows.Count != 0) return;
            Width -= panel1.Width;
        }

        private void btn_StartNewMatch_Click(object sender, EventArgs e)
        {
            Program.MatchDate = _matchBL.GetDateForNextMatch();
            var match = new Match(Program.MatchDate, false);

            using (var form = new TeamsSelectForm(match))
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.Yes)
                {
                    _matchNumberForDelete = form.MatchNumberForDelete;
                    _matchBL.DeleteThisMatch(_matchNumberForDelete);
                }
            }

            GetListOfPeopleWithBirthdayToday();
        }

        private void btnStandings_Click(object sender, EventArgs e)
        {
            using (var form = new StandingsForm())
            {
                Visible = false;
                form.ShowDialog();
            }

            GetListOfPeopleWithBirthdayToday();
        }

        private void btnPlayerStats_Click(object sender, EventArgs e)
        {
            using (var form = new StatsMenuForm())
            {
                Visible = false;
                form.ShowDialog();
            }

            GetListOfPeopleWithBirthdayToday();
        }

        private void btnLineups_Click(object sender, EventArgs e)
        {
            using (var form = new RostersMenuForm())
            {
                Visible = false;
                form.ShowDialog();
            }

            GetListOfPeopleWithBirthdayToday();
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            using (var form = new MatchResultsMenuForm())
            {
                Visible = false;
                form.ShowDialog();
            }
            GetListOfPeopleWithBirthdayToday();
        }

        private void btnNewMatch_Click(object sender, EventArgs e)
        {
            var match = new Match(DateTime.Now, true);
            Visible = false;

            using (var form = new TeamsSelectForm(match))
            {
                form.ShowDialog();

                if (form.DialogResult == DialogResult.Yes)
                {
                    _matchNumberForDelete = form.MatchNumberForDelete;
                    form.Dispose();
                    _matchBL.DeleteThisMatch(_matchNumberForDelete);
                }
            }

            GetListOfPeopleWithBirthdayToday();
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}