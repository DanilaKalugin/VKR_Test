using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;
using VKR.PL.Utils.NET5;

namespace VKR.PL.NET5
{
    public partial class MatchResultsForm : Form
    {
        private enum FormType
        {
            DailySchedule,
            DailyResults,
            TeamSchedule,
            TeamResults,
            SeriesSchedule,
            SeriesResults,
            LastTenMatches,
            NextTenMatches
        }

        private readonly MatchScheduleBL _scheduleBL = new();
        private readonly TeamsBL _teamsBL = new();
        private readonly SeasonBL _seasonBL = new();

        private List<Team>? _teams;
        private List<Season>? _seasons;
        private List<MatchScheduleViewModel>? _matches;
        private readonly MatchScheduleBL.TableType _tableType;
        private readonly Dictionary<string, Image?> _teamLogos = new();
        private Season? _season;

        private readonly FormType _formType;
        private readonly DateTime _matchDate;
        private readonly List<string> _teamAbbreviations = new();

        private MatchResultsForm()
        {
            InitializeComponent();
        }

        public MatchResultsForm(MatchScheduleBL.TableType tableType) : this()
        {
            _tableType = tableType;
            panel2.Visible = false;

            _formType = _tableType == MatchScheduleBL.TableType.Results
                ? FormType.TeamResults
                : FormType.TeamSchedule;
        }

        public MatchResultsForm(DateTime dateTime, bool isCurrentDayResults, MatchScheduleBL.TableType tableType) : this()
        {
            _tableType = tableType;
            _matchDate = dateTime;

            panel1.Visible = false;
            panel2.Visible = !isCurrentDayResults;

            _formType = _tableType == MatchScheduleBL.TableType.Results
                ? FormType.DailyResults
                : FormType.DailySchedule;
        }

        public MatchResultsForm(Team homeTeam, Team awayTeam, MatchScheduleBL.TableType tableType) : this()
        {
            _tableType = tableType;
            _teamAbbreviations.AddRange(new[]
            {homeTeam.TeamAbbreviation, awayTeam.TeamAbbreviation});

            panel1.Visible = false;
            panel2.Visible = false;

            _formType = _tableType == MatchScheduleBL.TableType.Results
                            ? FormType.SeriesResults
                            : FormType.SeriesSchedule;
        }

        public MatchResultsForm(Team team1, MatchScheduleBL.TableType tableType) : this()
        {
            _tableType = tableType;
            _teamAbbreviations.Add(team1.TeamAbbreviation);
            panel1.Visible = false;
            panel2.Visible = false;

            _formType = _tableType == MatchScheduleBL.TableType.Results
                                        ? FormType.LastTenMatches
                                        : FormType.NextTenMatches;
        }

        private async void MatchResultsForm_Load(object sender, EventArgs e)
        {
            _teams = await _teamsBL.GetListAsync();

            foreach (var team in _teams)
            {
                var teamAbbreviation = team.TeamAbbreviation;
                var teamLogo = ImageHelper.ShowImageIfExists($"SmallTeamLogos/{teamAbbreviation}.png");
                _teamLogos.Add(teamAbbreviation, teamLogo);
            }

            _seasons = await _seasonBL.GetAllSeasonsAsync();
            cbSeasons.DataSource = _seasons;
            cbSeasons.DisplayMember = "Year";

            _season = await _seasonBL.GetCurrentSeason();

            cbSeasons.SelectedItem = _seasons.FirstOrDefault(season => season.Year == _season.Year);

            var seasonInfo = await _seasonBL.GetLeagueSeasonInfo(_season.Year);
            ChangeMaxAndMinDateForThisSeason(seasonInfo);

            switch (_formType)
            {
                case FormType.DailySchedule:
                case FormType.DailyResults:
                    dtpMatchDate.Value = _matchDate;
                    break;
                case FormType.SeriesSchedule:
                case FormType.SeriesResults:
                    _matches = await _scheduleBL.GetMatchesFromThisSeries(_tableType, TypeOfMatchEnum.RegularSeason, _season, _teamAbbreviations[0], _teamAbbreviations[1]);
                    FillResultsTable();
                    break;
                case FormType.LastTenMatches:
                case FormType.NextTenMatches:
                    var matchesList = await _scheduleBL.GetMatchesForSelectedTeam(TypeOfMatchEnum.RegularSeason, _season, _tableType, _teamAbbreviations.First());
                    _matches = matchesList.Take(10).ToList();
                    FillResultsTable();
                    break;
                case FormType.TeamResults:
                case FormType.TeamSchedule:
                    var teamsInComboBox = _teams.Select(team => team.TeamName).ToList();
                    cbTeam.DataSource = teamsInComboBox;
                    break;
            }

            lbHeader.Text = _tableType == MatchScheduleBL.TableType.Results ? "MATCH RESULTS" : "SCHEDULE";
        }

        private async void cbTeam_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_season is null) return;

            _matches = await _scheduleBL.GetMatchesForSelectedTeam(TypeOfMatchEnum.RegularSeason, _season, _tableType, _teams?[cbTeam.SelectedIndex].TeamAbbreviation);
            FillResultsTable();
        }

        private void FillResultsTable()
        {
            dgvMatches.Rows.Clear();
            foreach (var match in _matches!)
                dgvMatches.Rows.Add(match.MatchDate.ToString("dd-MM"),
                    _teamLogos[match.AwayTeamAbbreviation],
                    match.AwayTeamAbbreviation,
                    match.AwayTeamRuns,
                    match.HomeTeamRuns,
                    match.HomeTeamAbbreviation,
                    _teamLogos[match.HomeTeamAbbreviation],
                    match.MatchStatus,
                    $"{match.StadiumName} - {match.StadiumLocation}");
        }

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Func<TypeOfMatchEnum, Season, Task<List<MatchScheduleViewModel>>> matchFunc =
                _tableType == MatchScheduleBL.TableType.Results
                    ? _scheduleBL.GetResultsForAllMatches
                    : _scheduleBL.GetSchedule;

            if (_season is null) return;

            var matches = await matchFunc(TypeOfMatchEnum.RegularSeason, _season);
            _matches = matches.Where(match => match.MatchDate == dtpMatchDate.Value).ToList();

            FillResultsTable();
        }

        private async void cbSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSeasons.Items.Count == 0 || cbTeam.Items.Count == 0) return;

            var year = cbSeasons.SelectedItem is Season season ? season.Year : 0;

            _season = cbSeasons.SelectedItem as Season;

            var seasonInfo = await _seasonBL.GetLeagueSeasonInfo(year);

            switch (_formType)
            {
                case FormType.DailyResults or FormType.DailySchedule:
                {
                    ChangeMaxAndMinDateForThisSeason(seasonInfo);
                    break;
                }
                case FormType.TeamResults or FormType.TeamSchedule:

                    _matches = await _scheduleBL.GetMatchesForSelectedTeam(TypeOfMatchEnum.RegularSeason, _season, _tableType, _teams?[cbTeam.SelectedIndex].TeamAbbreviation);
                    FillResultsTable();
                    break;
            }
        }

        private void ChangeMaxAndMinDateForThisSeason(LeagueSeason season)
        {
            if (season.SeasonEnd < dtpMatchDate.MinDate)
            {
                dtpMatchDate.MinDate = season.SeasonStart;
                dtpMatchDate.MaxDate = season.SeasonEnd;
            }

            dtpMatchDate.MaxDate = season.SeasonEnd;
            dtpMatchDate.MinDate = season.SeasonStart;
        }
    }
}