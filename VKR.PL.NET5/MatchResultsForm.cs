using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;
using VKR.PL.Utils.NET5;

namespace VKR.PL.NET5
{
    public partial class MatchResultsForm : Form
    {
        private readonly MatchScheduleBL _scheduleBL = new();
        private readonly TeamsBL _teamsBL = new();
        private readonly SeasonBL _seasonBL = new();

        private readonly List<Team> _teams;
        private List<MatchScheduleViewModel> _matches;
        private readonly MatchScheduleBL.TableType _tableType;
        private readonly Dictionary<string, Image?> _teamLogos = new();
        private Season? _season;


        private MatchResultsForm()
        {
            InitializeComponent();
            _teams = _teamsBL.GetAllTeams().ToList();
            cbSeasons.DataSource = _seasonBL.GetAllSeasons();
            cbSeasons.DisplayMember = "Year";

            foreach (var team in _teams)
            {
                var teamAbbreviation = team.TeamAbbreviation;
                var teamLogo = ImageHelper.ShowImageIfExists($"SmallTeamLogos/{teamAbbreviation}.png");
                _teamLogos.Add(teamAbbreviation, teamLogo);
            }
        }

        public MatchResultsForm(MatchScheduleBL.TableType tableType) : this()
        {
            _tableType = tableType;
            var teamsInComboBox = _teams.Select(team => team.TeamName).ToList();
            cbTeam.DataSource = teamsInComboBox;
            panel2.Visible = false;
        }

        public MatchResultsForm(DateTime dateTime, bool isCurrentDayResults, MatchScheduleBL.TableType tableType) : this()
        {
            _tableType = tableType;
            dtpMatchDate.Value = dateTime;
            FillResultsTable(dgvMatches);
            panel1.Visible = false;
            panel2.Visible = !isCurrentDayResults;
        }

        public MatchResultsForm(Team homeTeam, Team awayTeam, MatchScheduleBL.TableType tableType) : this()
        {
            _tableType = tableType;

            _matches = _scheduleBL.GetMatchesFromThisSeries(_tableType, TypeOfMatchEnum.RegularSeason, _season,homeTeam.TeamAbbreviation, awayTeam.TeamAbbreviation).ToList();
            FillResultsTable(dgvMatches);

            panel1.Visible = false;
            panel2.Visible = false;
        }

        public MatchResultsForm(Team team1, MatchScheduleBL.TableType tableType) : this()
        {
            _tableType = tableType;
            _matches = _scheduleBL.GetMatchesForSelectedTeam(TypeOfMatchEnum.RegularSeason, _season,_tableType, team1.TeamAbbreviation).Take(10).ToList();
            FillResultsTable(dgvMatches);
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void MatchResultsForm_Load(object sender, EventArgs e) => lbHeader.Text = _tableType == MatchScheduleBL.TableType.Results ? "MATCH RESULTS" : "SCHEDULE";

        private void cbTeam_SelectedValueChanged(object sender, EventArgs e)
        {
            _matches = _scheduleBL.GetMatchesForSelectedTeam(TypeOfMatchEnum.RegularSeason, _season, _tableType, _teams[cbTeam.SelectedIndex].TeamAbbreviation).ToList();
            FillResultsTable(dgvMatches);
        }

        private void FillResultsTable(DataGridView dgv)
        {
            dgv.Rows.Clear();
            foreach (var match in _matches)
                dgv.Rows.Add(match.MatchDate.ToString("dd-MM"),
                    _teamLogos[match.AwayTeamAbbreviation],
                    match.AwayTeamAbbreviation,
                    match.AwayTeamRuns,
                    match.HomeTeamRuns,
                    match.HomeTeamAbbreviation,
                    _teamLogos[match.HomeTeamAbbreviation],
                    match.MatchStatus,
                    $"{match.StadiumName} - {match.StadiumLocation}");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show(dtpMatchDate.Visible.ToString());

            Func<TypeOfMatchEnum, Season, List<MatchScheduleViewModel>> matchFunc =
                _tableType == MatchScheduleBL.TableType.Results
                    ? _scheduleBL.GetResultsForAllMatches
                    : _scheduleBL.GetSchedule;

            if (_season is null) return;

            _matches = matchFunc(TypeOfMatchEnum.RegularSeason, _season).Where(match => match.MatchDate == dtpMatchDate.Value).ToList();

            FillResultsTable(dgvMatches);
        }

        private void cbSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSeasons.Items.Count == 0) return;

            var year = cbSeasons.SelectedItem is Season season ? season.Year : 0;

            _season = cbSeasons.SelectedItem as Season;

            var seasonInfo = _seasonBL.GetLeagueSeasonInfo(year);

            if (seasonInfo.SeasonEnd < dtpMatchDate.MinDate)
            {
                dtpMatchDate.MinDate = seasonInfo.SeasonStart;
                dtpMatchDate.MaxDate = seasonInfo.SeasonEnd;
            }

            dtpMatchDate.MaxDate = seasonInfo.SeasonEnd;
            dtpMatchDate.MinDate = seasonInfo.SeasonStart;
        }
    }
}