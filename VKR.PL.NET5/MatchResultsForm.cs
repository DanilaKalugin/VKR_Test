using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;

namespace VKR.PL.NET5
{
    public partial class MatchResultsForm : Form
    {
        private readonly MatchScheduleBL _scheduleBL = new();
        private readonly TeamsBL _teamsBL = new();
        private readonly List<Team> _teams;
        private List<MatchScheduleViewModel> _matches;
        private readonly MatchScheduleBL.TableType _tableType;

        private MatchResultsForm() => InitializeComponent();

        public MatchResultsForm(MatchScheduleBL.TableType tableType) : this()
        {
            _tableType = tableType;
            _teams = _teamsBL.GetAllTeams().ToList();
            var teamsInComboBox = _teams.Select(team => team.TeamName).ToList();
            cbTeam.DataSource = teamsInComboBox;
            panel2.Visible = false;
        }

        public MatchResultsForm(DateTime dateTime, bool isCurrentDayResults, MatchScheduleBL.TableType tableType) : this()
        {
            _tableType = tableType;
            dtpMatchDate.Value = dateTime;
            FillResultsTable(dgvMatches, _matches);
            panel1.Visible = false;
            panel2.Visible = !isCurrentDayResults;
        }

        public MatchResultsForm(Team homeTeam, Team awayTeam, MatchScheduleBL.TableType tableType) : this()
        {
            _tableType = tableType;

            _matches = _scheduleBL.GetMatchesFromThisSeries(_tableType, homeTeam.TeamAbbreviation, awayTeam.TeamAbbreviation).ToList();
            FillResultsTable(dgvMatches, _matches);

            panel1.Visible = false;
            panel2.Visible = false;
        }

        public MatchResultsForm(Team team1, MatchScheduleBL.TableType tableType) : this()
        {
            _tableType = tableType;
            _matches = _scheduleBL.GetMatchesForSelectedTeam(_tableType, team1.TeamAbbreviation).Take(10).ToList();
            FillResultsTable(dgvMatches, _matches);
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void MatchResultsForm_Load(object sender, EventArgs e) => lbHeader.Text = _tableType == MatchScheduleBL.TableType.Results ? "MATCH RESULTS" : "SCHEDULE";

        private void cbTeam_SelectedValueChanged(object sender, EventArgs e)
        {
            _matches = _scheduleBL.GetMatchesForSelectedTeam(_tableType, _teams[cbTeam.SelectedIndex].TeamAbbreviation).ToList();
            FillResultsTable(dgvMatches, _matches);
        }

        private static void FillResultsTable(DataGridView dgv, List<MatchScheduleViewModel> matches)
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
                                       $"{match.StadiumName} - {match.StadiumLocation}");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            _matches = _tableType == MatchScheduleBL.TableType.Results ? _scheduleBL.GetResultsForAllMatches().Where(match => match.MatchDate == dtpMatchDate.Value).ToList() 
                                                               : _scheduleBL.GetSchedule().Where(match => match.MatchDate == dtpMatchDate.Value).ToList();
            FillResultsTable(dgvMatches, _matches);
        }
    }
}