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
        private readonly TeamsBL teamsBL;
        private readonly MatchBL matchBL;
        List<Team> teams;
        List<Match> matches;
        int CurrentHomeColor;
        int CurrentAwayColor;
        int AwayTeamNumber;
        int HomeTeamNumber;
        public bool ExitFromCurrentMatch;
        public int MatchNumberForDelete;

        public TeamsSelectForm()
        {
            InitializeComponent();
            teamsBL = new TeamsBL();
            matchBL = new MatchBL();
            Program.MatchDate = matchBL.GetMaxDateForAllMatches();
            matches = matchBL.GetMatchesForThisDay(Program.MatchDate);
            if (matches.Count == 0)
            {
                Program.MatchDate = Program.MatchDate.AddDays(1);
                matches = matchBL.GetMatchesForThisDay(Program.MatchDate);
            }
            teams = teamsBL.GetAllTeams().ToList();
            AwayTeamNumber = teams.FindIndex(team => team.TeamAbbreviation == matches[0].AwayTeamAbbreviation);
            HomeTeamNumber = teams.FindIndex(team => team.TeamAbbreviation == matches[0].HomeTeamAbbreviation);
        }

        private void TeamsSelectForm_Load(object sender, EventArgs e)
        {
            DisplayTeam(AwayTeamNumber, numericUpDown1, label1, label2, panel1, CurrentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnDecreaseAwayTeamNumberBy1, btnIncreaseAwayTeamNumberBy1, AwayTeamBalance);
            DisplayTeam(HomeTeamNumber, numericUpDown2, label8, label7, panel2, CurrentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnDecreaseHomeTeamNumberBy1, btnIncreaseHomeTeamNumberBy1, HomeTeamBalance);
        }

        private void DisplayTeam(int TeamNumber, NumericUpDown teamColorsForMatch, Label teamCity, Label teamTitle, Panel teamLogo, int teamColorNumber, Label TeamColorHeader,
                                 CircularProgressBar.CircularProgressBar Overall, CircularProgressBar.CircularProgressBar Defense, CircularProgressBar.CircularProgressBar Offense,
                                 Button increaseNumber, Button DecreaseNumber, Label Balance)
        {
            teamColorsForMatch.Maximum = teams[TeamNumber].TeamColor.Count - 1;
            teamCity.Text = teams[TeamNumber].TeamCity.ToUpper();
            teamTitle.Text = teams[TeamNumber].TeamTitle.ToUpper();
            teamLogo.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{teams[TeamNumber].TeamAbbreviation}.png");
            Balance.Text = $"{teams[TeamNumber].Wins}-{teams[TeamNumber].Losses}";

            teamColorNumber = 0;
            teamColorsForMatch.Value = 0;

            RatingChanged(Overall, teams[TeamNumber].OverallRating, teams[TeamNumber].TeamColor[0]);
            RatingChanged(Defense, teams[TeamNumber].NormalizedDefensiveRating, teams[TeamNumber].TeamColor[0]);
            RatingChanged(Offense, teams[TeamNumber].NormalizedOffensiveRating, teams[TeamNumber].TeamColor[0]);
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
            teamCity.BackColor = teams[teamNumber].TeamColor[teamColorNumber];
            teamTitle.BackColor = teams[teamNumber].TeamColor[teamColorNumber];
            increaseBtn.BackColor = teams[teamNumber].TeamColor[teamColorNumber];
            decreaseBtn.BackColor = teams[teamNumber].TeamColor[teamColorNumber];
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CurrentAwayColor = (int)numericUpDown1.Value;
            CurrentTeamColorChanged(AwayTeamNumber, CurrentAwayColor, label1, label2, label4, btnIncreaseAwayTeamNumberBy1, btnDecreaseAwayTeamNumberBy1);
        }

        private void btnIncreaseAwayTeamNumberBy1_Click(object sender, EventArgs e)
        {
            AwayTeamNumber = AwayTeamNumber == teams.Count - 1 ? 0 : AwayTeamNumber + 1;
            if (AwayTeamNumber == HomeTeamNumber)
            {
                AwayTeamNumber = AwayTeamNumber == teams.Count - 1 ? 0 : AwayTeamNumber + 1;
            }
            DisplayTeam(AwayTeamNumber, numericUpDown1, label1, label2, panel1, CurrentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnIncreaseAwayTeamNumberBy1, btnDecreaseAwayTeamNumberBy1, AwayTeamBalance);
        }

        private void btnIncreaseHomeTeamNumberBy1_Click(object sender, EventArgs e)
        {
            HomeTeamNumber = HomeTeamNumber == teams.Count - 1 ? 0 : HomeTeamNumber + 1;
            if (AwayTeamNumber == HomeTeamNumber)
            {
                HomeTeamNumber = HomeTeamNumber == teams.Count - 1 ? 0 : HomeTeamNumber + 1;
            }
            DisplayTeam(HomeTeamNumber, numericUpDown2, label8, label7, panel2, CurrentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnIncreaseHomeTeamNumberBy1, btnDecreaseHomeTeamNumberBy1, HomeTeamBalance);
        }

        private void btnDecreaseHomeTeamNumberBy1_Click(object sender, EventArgs e)
        {
            HomeTeamNumber = HomeTeamNumber == 0 ? teams.Count - 1 : HomeTeamNumber - 1;
            if (AwayTeamNumber == HomeTeamNumber)
            {
                HomeTeamNumber = HomeTeamNumber == 0 ? teams.Count - 1 : HomeTeamNumber - 1;
            }
            DisplayTeam(HomeTeamNumber, numericUpDown2, label8, label7, panel2, CurrentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnIncreaseHomeTeamNumberBy1, btnDecreaseHomeTeamNumberBy1, HomeTeamBalance);
        }

        private void btnDecreaseAwayTeamNumberBy1_Click(object sender, EventArgs e)
        {
            AwayTeamNumber = AwayTeamNumber == 0 ? teams.Count - 1 : AwayTeamNumber - 1;
            if (AwayTeamNumber == HomeTeamNumber)
            {
                AwayTeamNumber = AwayTeamNumber == 0 ? teams.Count - 1 : AwayTeamNumber - 1;
            }
            DisplayTeam(AwayTeamNumber, numericUpDown1, label1, label2, panel1, CurrentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnIncreaseAwayTeamNumberBy1, btnDecreaseAwayTeamNumberBy1, AwayTeamBalance);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            CurrentHomeColor = (int)numericUpDown2.Value;
            CurrentTeamColorChanged(HomeTeamNumber, CurrentHomeColor, label8, label7, label5, btnIncreaseHomeTeamNumberBy1, btnDecreaseHomeTeamNumberBy1);
        }

        private void btnAcceptTeamsSelection_Click(object sender, EventArgs e)
        {
            Team HomeTeam = teams[HomeTeamNumber];
            Team AwayTeam = teams[AwayTeamNumber];
            HomeTeam.TeamColorForThisMatch = HomeTeam.TeamColor[CurrentHomeColor];
            AwayTeam.TeamColorForThisMatch = AwayTeam.TeamColor[CurrentAwayColor];
            StadiumSelectionForm stadiumSelection = new StadiumSelectionForm(HomeTeam, AwayTeam);
            stadiumSelection.ShowDialog();

            if (stadiumSelection.DialogResult == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (stadiumSelection.DialogResult == DialogResult.Yes)
            {
                ExitFromCurrentMatch = stadiumSelection.ExitFromCurrentMatch;
                MatchNumberForDelete = stadiumSelection.MatchNumberForDelete;
                stadiumSelection.Dispose();
                Hide();
                DialogResult = DialogResult.Yes;
            }
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            int Buf = AwayTeamNumber;
            AwayTeamNumber = HomeTeamNumber;
            HomeTeamNumber = Buf;

            DisplayTeam(AwayTeamNumber, numericUpDown1, label1, label2, panel1, CurrentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnDecreaseAwayTeamNumberBy1, btnIncreaseAwayTeamNumberBy1, AwayTeamBalance);
            DisplayTeam(HomeTeamNumber, numericUpDown2, label8, label7, panel2, CurrentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnDecreaseHomeTeamNumberBy1, btnIncreaseHomeTeamNumberBy1, HomeTeamBalance);
        }
    }
}