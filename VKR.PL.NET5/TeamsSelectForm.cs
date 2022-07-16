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
    public partial class TeamsSelectForm : Form
    {
        private readonly TeamsBL _teamsBL = new();
        private readonly MatchBL _matchBL = new();
        private readonly List<Team> _teams;
        private List<MatchFromSchedule> _matches;
        private int _currentHomeColor;
        private int _currentAwayColor;
        private int _awayTeamNumber;
        private int _homeTeamNumber;
        private Match _newMatch;
        private int _matchNumber;
        public bool ExitFromCurrentMatch;
        public int MatchNumberForDelete;

        public TeamsSelectForm(Match match)
        {
            InitializeComponent();
            _newMatch = match;

            btnDecreaseAwayTeamNumberBy1.Visible = match.MatchTypeId == TypeOfMatchEnum.QuickMatch;
            btnIncreaseAwayTeamNumberBy1.Visible = match.MatchTypeId == TypeOfMatchEnum.QuickMatch;
            btnDecreaseHomeTeamNumberBy1.Visible = match.MatchTypeId == TypeOfMatchEnum.QuickMatch;
            btnIncreaseHomeTeamNumberBy1.Visible = match.MatchTypeId == TypeOfMatchEnum.QuickMatch;

            AwayTeamBalance.Visible = match.MatchTypeId != TypeOfMatchEnum.QuickMatch;
            HomeTeamBalance.Visible = match.MatchTypeId != TypeOfMatchEnum.QuickMatch;
            _teams = _teamsBL.GetTeamsWithWLBalance(match.MatchDate.Year, match.MatchTypeId).ToList();


            if (match.MatchTypeId == TypeOfMatchEnum.QuickMatch)
            {
                _awayTeamNumber = 0;
                _homeTeamNumber = 1;
            }
            else FillScheduleForToday();

            btnSwap.Visible = match.MatchTypeId == TypeOfMatchEnum.QuickMatch;
            dataGridView1.Visible = match.MatchTypeId != TypeOfMatchEnum.QuickMatch;
        }

        private void TeamsSelectForm_Load(object sender, EventArgs e)
        {
            DisplayTeam(_awayTeamNumber, numAwayTeamColor, lbAwayCity, lbAwayTitle, pbAwayLogo, _currentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnDecreaseAwayTeamNumberBy1, btnIncreaseAwayTeamNumberBy1, AwayTeamBalance);
            DisplayTeam(_homeTeamNumber, numHomeTeamColor, lbHomeCity, lbHomeTitle, pbHomeLogo, _currentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnDecreaseHomeTeamNumberBy1, btnIncreaseHomeTeamNumberBy1, HomeTeamBalance);
        }

        private void DisplayTeam(int teamNumber, NumericUpDown teamColorsForMatch, Label teamCity, Label teamTitle, Panel teamLogo, int teamColorNumber, Label teamColorHeader,
                                 CircularProgressBar.CircularProgressBar overall, CircularProgressBar.CircularProgressBar defense, CircularProgressBar.CircularProgressBar offense,
                                 Button increaseNumber, Button decreaseNumber, Label balance)
        {
            teamColorsForMatch.Maximum = _teams[teamNumber].TeamColors.Count - 1;
            teamCity.Text = _teams[teamNumber].TeamCity.ToUpper();
            teamTitle.Text = _teams[teamNumber].TeamName.ToUpper();
            teamLogo.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{_teams[teamNumber].TeamAbbreviation}.png");
            balance.Text = $"{_teams[teamNumber].Wins}-{_teams[teamNumber].Losses}";

            teamColorNumber = 0;
            teamColorsForMatch.Value = 0;

            RatingChanged(overall, _teams[teamNumber].OverallRating, _teams[teamNumber].TeamColors[teamColorNumber].Color);
            RatingChanged(defense, _teams[teamNumber].NormalizedDefensiveRating, _teams[teamNumber].TeamColors[teamColorNumber].Color);
            RatingChanged(offense, _teams[teamNumber].NormalizedOffensiveRating, _teams[teamNumber].TeamColors[teamColorNumber].Color);
            CurrentTeamColorChanged(teamNumber, teamColorNumber, teamCity, teamTitle, teamColorHeader, increaseNumber, decreaseNumber);
        }

        private void RatingChanged(CircularProgressBar.CircularProgressBar rating, int ratingValue, Color teamColor)
        {
            rating.Value = ratingValue;
            rating.Text = ratingValue.ToString();
            rating.ProgressColor = teamColor;
        }

        private void CurrentTeamColorChanged(int teamNumber, int teamColorNumber, Control teamCity, Control teamTitle, Control teamColorHeader, Control increaseBtn, Control decreaseBtn)
        {
            teamColorHeader.Text = $"Color #{teamColorNumber + 1}";
            teamCity.BackColor = _teams[teamNumber].TeamColors[teamColorNumber].Color;
            teamTitle.BackColor = _teams[teamNumber].TeamColors[teamColorNumber].Color;
            increaseBtn.BackColor = _teams[teamNumber].TeamColors[teamColorNumber].Color;
            decreaseBtn.BackColor = _teams[teamNumber].TeamColors[teamColorNumber].Color;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _currentAwayColor = (int)numAwayTeamColor.Value;
            CurrentTeamColorChanged(_awayTeamNumber, _currentAwayColor, lbAwayCity, lbAwayTitle, label4, btnIncreaseAwayTeamNumberBy1, btnDecreaseAwayTeamNumberBy1);
        }

        private void btnIncreaseAwayTeamNumberBy1_Click(object sender, EventArgs e)
        {
            _awayTeamNumber = _awayTeamNumber == _teams.Count - 1 ? 0 : _awayTeamNumber + 1;

            if (_awayTeamNumber == _homeTeamNumber) _awayTeamNumber = _awayTeamNumber == _teams.Count - 1 ? 0 : _awayTeamNumber + 1;

            DisplayTeam(_awayTeamNumber, numAwayTeamColor, lbAwayCity, lbAwayTitle, pbAwayLogo, _currentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnIncreaseAwayTeamNumberBy1, btnDecreaseAwayTeamNumberBy1, AwayTeamBalance);
        }

        private void btnIncreaseHomeTeamNumberBy1_Click(object sender, EventArgs e)
        {
            _homeTeamNumber = _homeTeamNumber == _teams.Count - 1 ? 0 : _homeTeamNumber + 1;

            if (_awayTeamNumber == _homeTeamNumber) _homeTeamNumber = _homeTeamNumber == _teams.Count - 1 ? 0 : _homeTeamNumber + 1;

            DisplayTeam(_homeTeamNumber, numHomeTeamColor, lbHomeCity, lbHomeTitle, pbHomeLogo, _currentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnIncreaseHomeTeamNumberBy1, btnDecreaseHomeTeamNumberBy1, HomeTeamBalance);
        }

        private void btnDecreaseHomeTeamNumberBy1_Click(object sender, EventArgs e)
        {
            _homeTeamNumber = _homeTeamNumber == 0 ? _teams.Count - 1 : _homeTeamNumber - 1;

            if (_awayTeamNumber == _homeTeamNumber) _homeTeamNumber = _homeTeamNumber == 0 ? _teams.Count - 1 : _homeTeamNumber - 1;

            DisplayTeam(_homeTeamNumber, numHomeTeamColor, lbHomeCity, lbHomeTitle, pbHomeLogo, _currentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnIncreaseHomeTeamNumberBy1, btnDecreaseHomeTeamNumberBy1, HomeTeamBalance);
        }

        private void btnDecreaseAwayTeamNumberBy1_Click(object sender, EventArgs e)
        {
            _awayTeamNumber = _awayTeamNumber == 0 ? _teams.Count - 1 : _awayTeamNumber - 1;

            if (_awayTeamNumber == _homeTeamNumber) _awayTeamNumber = _awayTeamNumber == 0 ? _teams.Count - 1 : _awayTeamNumber - 1;

            DisplayTeam(_awayTeamNumber, numAwayTeamColor, lbAwayCity, lbAwayTitle, pbAwayLogo, _currentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnIncreaseAwayTeamNumberBy1, btnDecreaseAwayTeamNumberBy1, AwayTeamBalance);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            _currentHomeColor = (int)numHomeTeamColor.Value;
            CurrentTeamColorChanged(_homeTeamNumber, _currentHomeColor, lbHomeCity, lbHomeTitle, label5, btnIncreaseHomeTeamNumberBy1, btnDecreaseHomeTeamNumberBy1);
        }

        private void btnAcceptTeamsSelection_Click(object sender, EventArgs e)
        {
            StartNewMatch();
        }

        private void StartNewMatch()
        {
            var homeTeam = _teams[_homeTeamNumber];
            var awayTeam = _teams[_awayTeamNumber];
            homeTeam.TeamColorForThisMatch = homeTeam.TeamColors[_currentHomeColor].Color;
            awayTeam.TeamColorForThisMatch = awayTeam.TeamColors[_currentAwayColor].Color;
            _newMatch.HomeTeam = homeTeam;
            _newMatch.AwayTeam = awayTeam;

            using var stadiumSelection = new StadiumSelectionForm(_newMatch);
            Visible = false;
            stadiumSelection.ShowDialog();

            switch (stadiumSelection.DialogResult)
            {
                case DialogResult.OK:
                    DialogResult = DialogResult.OK;
                    Hide();
                    break;
                case DialogResult.Yes:
                    ExitFromCurrentMatch = stadiumSelection.ExitFromCurrentMatch;
                    MatchNumberForDelete = stadiumSelection.MatchNumberForDelete;
                    Hide();
                    DialogResult = DialogResult.Yes;
                    break;
                default:
                    Visible = true;
                    break;
            }
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            (_awayTeamNumber, _homeTeamNumber) = (_homeTeamNumber, _awayTeamNumber);

            DisplayTeam(_awayTeamNumber, numAwayTeamColor, lbAwayCity, lbAwayTitle, pbAwayLogo, _currentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnDecreaseAwayTeamNumberBy1, btnIncreaseAwayTeamNumberBy1, AwayTeamBalance);
            DisplayTeam(_homeTeamNumber, numHomeTeamColor, lbHomeCity, lbHomeTitle, pbHomeLogo, _currentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnDecreaseHomeTeamNumberBy1, btnIncreaseHomeTeamNumberBy1, HomeTeamBalance);
        }

        private void BackColorChanging_label(object sender, EventArgs e)
        {
            if (sender is Control l)
                l.ForeColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(l.BackColor, false);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0) return;

            _matchNumber = dataGridView1.SelectedRows[0].Index;
            _awayTeamNumber = _teams.FindIndex(team => team.TeamAbbreviation == _matches[_matchNumber].AwayTeamAbbreviation);
            _homeTeamNumber = _teams.FindIndex(team => team.TeamAbbreviation == _matches[_matchNumber].HomeTeamAbbreviation);
            DisplayTeam(_awayTeamNumber, numAwayTeamColor, lbAwayCity, lbAwayTitle, pbAwayLogo, _currentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnDecreaseAwayTeamNumberBy1, btnIncreaseAwayTeamNumberBy1, AwayTeamBalance);
            DisplayTeam(_homeTeamNumber, numHomeTeamColor, lbHomeCity, lbHomeTitle, pbHomeLogo, _currentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnDecreaseHomeTeamNumberBy1, btnIncreaseHomeTeamNumberBy1, HomeTeamBalance);
        }

        private void TeamsSelectForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.F5) return;

            if (!_newMatch.IsQuickMatch) FillScheduleForToday();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => StartNewMatch();

        private void FillScheduleForToday()
        {
            Program.MatchDate = _matchBL.GetDateForNextMatch();
            _matches = _matchBL.GetMatchesForThisDay(Program.MatchDate, _newMatch.MatchTypeId);
            _matchNumber = 0;
            _awayTeamNumber = _teams.FindIndex(team => team.TeamAbbreviation == _matches[0].AwayTeamAbbreviation);
            _homeTeamNumber = _teams.FindIndex(team => team.TeamAbbreviation == _matches[0].HomeTeamAbbreviation);
            dataGridView1.Rows.Clear();
            foreach (var match in _matches)
                dataGridView1.Rows.Add(Image.FromFile($"TeamLogosForSubstitution/{match.AwayTeamAbbreviation}.png"), Image.FromFile($"TeamLogosForSubstitution/{match.HomeTeamAbbreviation}.png"));
        }
    }
}