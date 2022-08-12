﻿using System;
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
        private readonly MatchBL _matchBL = new();
        private readonly PrimaryTeamColorBL _teamColorBl = new();

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

        private async void MainMenuForm_Load(object sender, EventArgs e) => await UpdateBirthDayTable();

        private async Task UpdateBirthDayTable()
        {
            var man = await _manBL.GetListOfPeopleWithBirthdayTodayAsync();
            var primaryTeamColors = _teamColorBl.GetPrimaryTeamColors();
            dgvBirthDays.Invoke((Action<List<ManInTeam>>)FillBirthDayTable, man);
            dgvBirthDays.Invoke((Action<List<TeamColor>, List<ManInTeam>>)FillColors, primaryTeamColors, man);
        }

        private void FillColors(List<TeamColor> teams, List<ManInTeam> men)
        {
            if (men.Count == 0) return;

            for (var i = 0; i < men.Count; i++)
            {
                var rowColor = men[i].TeamName != null
                    ? teams.First(team => team.TeamName == men[i].TeamName).Color
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
            panel1.Visible = false;
            Width = 1554 - panel1.Width;
        }

        private void btn_StartNewMatch_Click(object sender, EventArgs e)
        {
            var matchDate = _matchBL.GetDateForNextMatch(TypeOfMatchEnum.RegularSeason);
            StartNewMatch(matchDate, TypeOfMatchEnum.RegularSeason);
        }

        private void btnStandings_Click(object sender, EventArgs e)
        {
            Visible = false;
            using (var form = new StandingsForm())
                form.ShowDialog();
            Visible = true;
        }

        private void btnPlayerStats_Click(object sender, EventArgs e)
        {
            Visible = false;
            using (var form = new StatsMenuForm())
                form.ShowDialog();
            Visible = true;
        }

        private void btnLineups_Click(object sender, EventArgs e)
        {
            Visible = false;
            using (var form = new RostersMenuForm())
                form.ShowDialog();
            Visible = true;
        }

        private async void btnResults_Click(object sender, EventArgs e)
        {
            Visible = false;
            using (var form = new MatchResultsMenuForm())
                form.ShowDialog();
            Visible = true;
            await UpdateBirthDayTable();
        }

        private void btnNewMatch_Click(object sender, EventArgs e) => StartNewMatch(DateTime.Now, TypeOfMatchEnum.QuickMatch);

        private void StartNewMatch(DateTime matchDate, TypeOfMatchEnum matchType)
        {
            var match = new Match(matchDate, matchType);

            Visible = false;
            using (var form = new TeamsSelectForm(match))
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.Yes) 
                    _matchBL.DeleteThisMatch(form.MatchNumberForDelete);
            }
            Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private async void MainMenuForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible) await UpdateBirthDayTable();
        }
    }
}