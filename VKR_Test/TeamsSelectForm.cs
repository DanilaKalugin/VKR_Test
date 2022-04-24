using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class TeamsSelectForm : Form
    {
        private readonly TeamsBL _teamsBL;
        private readonly MatchBL _matchBL;
        private readonly List<Team> _teams;
        private List<Match> _matches;
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
            _teamsBL = new TeamsBL();
            _matchBL = new MatchBL();

            btnDecreaseAwayTeamNumberBy1.Visible = match.IsQuickMatch;
            btnIncreaseAwayTeamNumberBy1.Visible = match.IsQuickMatch;
            btnDecreaseHomeTeamNumberBy1.Visible = match.IsQuickMatch;
            btnIncreaseHomeTeamNumberBy1.Visible = match.IsQuickMatch;

            AwayTeamBalance.Visible = !match.IsQuickMatch;
            HomeTeamBalance.Visible = !match.IsQuickMatch;

            _matches = _matchBL.GetMatchesForThisDay(Program.MatchDate);
            _teams = _teamsBL.GetAllTeams().ToList();

            if (match.IsQuickMatch)
            {
                _awayTeamNumber = 0;
                _homeTeamNumber = 1;
            }
            else
            {
                _matchNumber = 0;
                _awayTeamNumber = _teams.FindIndex(team => team.TeamAbbreviation == _matches[0].AwayTeamAbbreviation);
                _homeTeamNumber = _teams.FindIndex(team => team.TeamAbbreviation == _matches[0].HomeTeamAbbreviation);
                dataGridView1.Rows.Clear();

                for (int i = 0; i < _matches.Count; i++)
                {
                    dataGridView1.Rows.Add(Image.FromFile($"TeamLogosForSubstitution/{_matches[i].AwayTeamAbbreviation}.png"), Image.FromFile($"TeamLogosForSubstitution/{_matches[i].HomeTeamAbbreviation}.png"));
                }
            }
            btnSwap.Visible = match.IsQuickMatch;
            dataGridView1.Visible = !match.IsQuickMatch;
        }

        private void TeamsSelectForm_Load(object sender, EventArgs e)
        {
            DisplayTeam(_awayTeamNumber, numAwayTeamColor, lbAwayCity, lbAwayTitle, pbAwayLogo, _currentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnDecreaseAwayTeamNumberBy1, btnIncreaseAwayTeamNumberBy1, AwayTeamBalance);
            DisplayTeam(_homeTeamNumber, numHomeTeamColor, lbHomeCity, lbHomeTitle, pbHomeLogo, _currentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnDecreaseHomeTeamNumberBy1, btnIncreaseHomeTeamNumberBy1, HomeTeamBalance);
        }

        private void DisplayTeam(int TeamNumber, NumericUpDown teamColorsForMatch, Label teamCity, Label teamTitle, Panel teamLogo, int teamColorNumber, Label TeamColorHeader,
                                 CircularProgressBar.CircularProgressBar Overall, CircularProgressBar.CircularProgressBar Defense, CircularProgressBar.CircularProgressBar Offense,
                                 Button increaseNumber, Button DecreaseNumber, Label Balance)
        {
            teamColorsForMatch.Maximum = _teams[TeamNumber].TeamColor.Count - 1;
            teamCity.Text = _teams[TeamNumber].TeamCity.ToUpper();
            teamTitle.Text = _teams[TeamNumber].TeamTitle.ToUpper();
            teamLogo.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{_teams[TeamNumber].TeamAbbreviation}.png");
            Balance.Text = $"{_teams[TeamNumber].Wins}-{_teams[TeamNumber].Losses}";

            teamColorNumber = 0;
            teamColorsForMatch.Value = 0;

            RatingChanged(Overall, _teams[TeamNumber].OverallRating, _teams[TeamNumber].TeamColor[0]);
            RatingChanged(Defense, _teams[TeamNumber].NormalizedDefensiveRating, _teams[TeamNumber].TeamColor[0]);
            RatingChanged(Offense, _teams[TeamNumber].NormalizedOffensiveRating, _teams[TeamNumber].TeamColor[0]);
            CurrentTeamColorChanged(TeamNumber, teamColorNumber, teamCity, teamTitle, TeamColorHeader, increaseNumber, DecreaseNumber);
        }

        private void RatingChanged(CircularProgressBar.CircularProgressBar Rating, int RatingValue, Color TeamColor)
        {
            Rating.Value = RatingValue;
            Rating.Text = RatingValue.ToString();
            Rating.ProgressColor = TeamColor;
        }

        private void CurrentTeamColorChanged(int teamNumber, int teamColorNumber, Label teamCity, Label teamTitle, Label TeamColorHeader, Button increaseBtn, Button decreaseBtn)
        {
            TeamColorHeader.Text = $"Color #{teamColorNumber + 1}";
            teamCity.BackColor = _teams[teamNumber].TeamColor[teamColorNumber];
            teamTitle.BackColor = _teams[teamNumber].TeamColor[teamColorNumber];
            increaseBtn.BackColor = _teams[teamNumber].TeamColor[teamColorNumber];
            decreaseBtn.BackColor = _teams[teamNumber].TeamColor[teamColorNumber];
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _currentAwayColor = (int)numAwayTeamColor.Value;
            CurrentTeamColorChanged(_awayTeamNumber, _currentAwayColor, lbAwayCity, lbAwayTitle, label4, btnIncreaseAwayTeamNumberBy1, btnDecreaseAwayTeamNumberBy1);
        }

        private void btnIncreaseAwayTeamNumberBy1_Click(object sender, EventArgs e)
        {
            _awayTeamNumber = _awayTeamNumber == _teams.Count - 1 ? 0 : _awayTeamNumber + 1;
            if (_awayTeamNumber == _homeTeamNumber)
            {
                _awayTeamNumber = _awayTeamNumber == _teams.Count - 1 ? 0 : _awayTeamNumber + 1;
            }
            DisplayTeam(_awayTeamNumber, numAwayTeamColor, lbAwayCity, lbAwayTitle, pbAwayLogo, _currentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnIncreaseAwayTeamNumberBy1, btnDecreaseAwayTeamNumberBy1, AwayTeamBalance);
        }

        private void btnIncreaseHomeTeamNumberBy1_Click(object sender, EventArgs e)
        {
            _homeTeamNumber = _homeTeamNumber == _teams.Count - 1 ? 0 : _homeTeamNumber + 1;
            if (_awayTeamNumber == _homeTeamNumber)
            {
                _homeTeamNumber = _homeTeamNumber == _teams.Count - 1 ? 0 : _homeTeamNumber + 1;
            }
            DisplayTeam(_homeTeamNumber, numHomeTeamColor, lbHomeCity, lbHomeTitle, pbHomeLogo, _currentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnIncreaseHomeTeamNumberBy1, btnDecreaseHomeTeamNumberBy1, HomeTeamBalance);
        }

        private void btnDecreaseHomeTeamNumberBy1_Click(object sender, EventArgs e)
        {
            _homeTeamNumber = _homeTeamNumber == 0 ? _teams.Count - 1 : _homeTeamNumber - 1;
            if (_awayTeamNumber == _homeTeamNumber)
            {
                _homeTeamNumber = _homeTeamNumber == 0 ? _teams.Count - 1 : _homeTeamNumber - 1;
            }
            DisplayTeam(_homeTeamNumber, numHomeTeamColor, lbHomeCity, lbHomeTitle, pbHomeLogo, _currentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnIncreaseHomeTeamNumberBy1, btnDecreaseHomeTeamNumberBy1, HomeTeamBalance);
        }

        private void btnDecreaseAwayTeamNumberBy1_Click(object sender, EventArgs e)
        {
            _awayTeamNumber = _awayTeamNumber == 0 ? _teams.Count - 1 : _awayTeamNumber - 1;
            if (_awayTeamNumber == _homeTeamNumber)
            {
                _awayTeamNumber = _awayTeamNumber == 0 ? _teams.Count - 1 : _awayTeamNumber - 1;
            }
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
            homeTeam.TeamColorForThisMatch = homeTeam.TeamColor[_currentHomeColor];
            awayTeam.TeamColorForThisMatch = awayTeam.TeamColor[_currentAwayColor];
            _newMatch.HomeTeam = homeTeam;
            _newMatch.AwayTeam = awayTeam;
            StadiumSelectionForm stadiumSelection = new StadiumSelectionForm(_newMatch);
            Visible = false;
            stadiumSelection.ShowDialog();

            if (stadiumSelection.DialogResult == DialogResult.OK)
            {
                stadiumSelection.Dispose();
                DialogResult = DialogResult.OK;
                Hide();
            }
            else if (stadiumSelection.DialogResult == DialogResult.Yes)
            {
                ExitFromCurrentMatch = stadiumSelection.ExitFromCurrentMatch;
                MatchNumberForDelete = stadiumSelection.MatchNumberForDelete;
                stadiumSelection.Dispose();
                Hide();
                DialogResult = DialogResult.Yes;
            }
            else
            {
                Visible = true;
            }
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            int Buf = _awayTeamNumber;
            _awayTeamNumber = _homeTeamNumber;
            _homeTeamNumber = Buf;

            DisplayTeam(_awayTeamNumber, numAwayTeamColor, lbAwayCity, lbAwayTitle, pbAwayLogo, _currentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnDecreaseAwayTeamNumberBy1, btnIncreaseAwayTeamNumberBy1, AwayTeamBalance);
            DisplayTeam(_homeTeamNumber, numHomeTeamColor, lbHomeCity, lbHomeTitle, pbHomeLogo, _currentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnDecreaseHomeTeamNumberBy1, btnIncreaseHomeTeamNumberBy1, HomeTeamBalance);
        }

        private void BackColorChanging_label(object sender, EventArgs e)
        {
            Control l = sender as Control;
            l.ForeColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(l.BackColor, false);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _matchNumber = dataGridView1.SelectedRows[0].Index;
                _awayTeamNumber = _teams.FindIndex(team => team.TeamAbbreviation == _matches[_matchNumber].AwayTeamAbbreviation);
                _homeTeamNumber = _teams.FindIndex(team => team.TeamAbbreviation == _matches[_matchNumber].HomeTeamAbbreviation);
                DisplayTeam(_awayTeamNumber, numAwayTeamColor, lbAwayCity, lbAwayTitle, pbAwayLogo, _currentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnDecreaseAwayTeamNumberBy1, btnIncreaseAwayTeamNumberBy1, AwayTeamBalance);
                DisplayTeam(_homeTeamNumber, numHomeTeamColor, lbHomeCity, lbHomeTitle, pbHomeLogo, _currentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnDecreaseHomeTeamNumberBy1, btnIncreaseHomeTeamNumberBy1, HomeTeamBalance);
            }
        }

        private void TeamsSelectForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    {
                        if (!_newMatch.IsQuickMatch)
                        {
                            Program.MatchDate = _matchBL.GetDateForNextMatch();
                            _matches = _matchBL.GetMatchesForThisDay(Program.MatchDate);
                            _matchNumber = 0;
                            _awayTeamNumber = _teams.FindIndex(team => team.TeamAbbreviation == _matches[0].AwayTeamAbbreviation);
                            _homeTeamNumber = _teams.FindIndex(team => team.TeamAbbreviation == _matches[0].HomeTeamAbbreviation);
                            dataGridView1.Rows.Clear();
                            for (int i = 0; i < _matches.Count; i++)
                            {
                                dataGridView1.Rows.Add(Image.FromFile($"TeamLogosForSubstitution/{_matches[i].AwayTeamAbbreviation}.png"), Image.FromFile($"TeamLogosForSubstitution/{_matches[i].HomeTeamAbbreviation}.png"));
                            }
                        }
                        break;
                    }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            StartNewMatch();
        }
    }
}