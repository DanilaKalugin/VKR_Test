﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.Entities.NET5;

namespace VKR.PL.NET5
{
    public partial class MatchResultsForm : Form
    {
        private readonly MatchBL _matchBL = new();
        private readonly TeamsBL _teamsBL = new();
        private readonly List<Team> _teams;
        private List<Match> _matches;
        public enum TableType { Results, Schedule }
        private readonly TableType _tableType;

        private MatchResultsForm() => InitializeComponent();

        public MatchResultsForm(TableType tableType) : this()
        {
            _tableType = tableType;
            _teams = _teamsBL.GetAllTeams().ToList();
            var teamsInComboBox = _teams.Select(team => team.TeamTitle).ToList();
            cbTeam.DataSource = teamsInComboBox;
            panel2.Visible = false;
        }

        public MatchResultsForm(DateTime dateTime, bool isCurrentDayResults, TableType tableType): this()
        {
            _tableType = tableType;
            dtpMatchDate.Value = dateTime;
            FillResultsTable(dgvMatches, _matches);
            panel1.Visible = false;
            panel2.Visible = !isCurrentDayResults;
        }

        public MatchResultsForm(Team homeTeam, Team AwayTeam, TableType tableType): this()
        {
            _tableType = tableType;
            if (_tableType == TableType.Results)
                _matches = _matchBL.GetResultsForAllMatches().Where(match =>
                        (match.AwayTeamAbbreviation == AwayTeam.TeamAbbreviation || match.HomeTeamAbbreviation == AwayTeam.TeamAbbreviation) &&
                        (match.AwayTeamAbbreviation == homeTeam.TeamAbbreviation || match.HomeTeamAbbreviation == homeTeam.TeamAbbreviation)).OrderBy(match => match.MatchDate).ToList();
            else
                _matches = _matchBL.GetSchedule().Where(match =>
                        (match.AwayTeamAbbreviation == AwayTeam.TeamAbbreviation || match.HomeTeamAbbreviation == AwayTeam.TeamAbbreviation) &&
                        (match.AwayTeamAbbreviation == homeTeam.TeamAbbreviation || match.HomeTeamAbbreviation == homeTeam.TeamAbbreviation)).OrderBy(match => match.MatchDate).ToList();

            FillResultsTable(dgvMatches, _matches);
            panel1.Visible = false;
            panel2.Visible = false;
        }

        public MatchResultsForm(Team team1, TableType tableType): this()
        {
            _tableType = tableType;
            if (_tableType == TableType.Results)
                _matches = _matchBL.GetResultsForAllMatches()
                                   .Where(match => match.AwayTeamAbbreviation == team1.TeamAbbreviation || match.HomeTeamAbbreviation == team1.TeamAbbreviation)
                                   .OrderByDescending(match => match.MatchDate).Take(10).ToList();
            else
                _matches = _matchBL.GetSchedule().Where(match =>
                        match.AwayTeamAbbreviation == team1.TeamAbbreviation ||
                        match.HomeTeamAbbreviation == team1.TeamAbbreviation)
                    .OrderBy(match => match.MatchDate).Take(10).ToList();
            FillResultsTable(dgvMatches, _matches);
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void MatchResultsForm_Load(object sender, EventArgs e) => lbHeader.Text = _tableType == TableType.Results ? "MATCH RESULTS" : "SCHEDULE";

        private void cbTeam_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_tableType == TableType.Results)
            {
                _matches = _matchBL.GetResultsForAllMatches(_teams[cbTeam.SelectedIndex].TeamAbbreviation);
                _matches = _matches.OrderByDescending(match => match.MatchDate).ToList();
            }
            else
            {
                _matches = _matchBL.GetSchedule(_teams[cbTeam.SelectedIndex].TeamAbbreviation);
                _matches = _matches.OrderBy(match => match.MatchDate).ToList();
            }
            FillResultsTable(dgvMatches, _matches);
        }

        private static void FillResultsTable(DataGridView dgv, List<Match> matches)
        {
            for (var i = 0; i < dgv.RowCount; i++)
            {
                dgv.Rows[i].Cells[1].Value = null;
                dgv.Rows[i].Cells[6].Value = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            dgv.Rows.Clear();
            foreach (var match in matches)
            {
                dgv.Rows.Add(match.MatchDate.ToString("dd-MM"),
                    Image.FromFile($"SmallTeamLogos/{match.AwayTeamAbbreviation}.png"),
                                       match.AwayTeamAbbreviation,
                                       match.AwayTeamRuns,
                                       match.HomeTeamRuns,
                                       match.HomeTeamAbbreviation,
                                       Image.FromFile($"SmallTeamLogos/{match.HomeTeamAbbreviation}.png"),
                                       match.MatchStatus,
                                       $"{match.Stadium.StadiumTitle} - {match.Stadium.StadiumLocation}");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            _matches = _tableType == TableType.Results ? _matchBL.GetResultsForAllMatches().Where(match => match.MatchDate == dtpMatchDate.Value).ToList() 
                                                       : _matchBL.GetSchedule().Where(match => match.MatchDate == dtpMatchDate.Value).ToList();
            FillResultsTable(dgvMatches, _matches);
        }
    }
}