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
        Match newMatch;
        int matchNumber = 0;

        public TeamsSelectForm(Match match)
        {
            InitializeComponent();
            newMatch = match;
            teamsBL = new TeamsBL();
            matchBL = new MatchBL();

            btnDecreaseAwayTeamNumberBy1.Visible = match.IsQuickMatch;
            btnIncreaseAwayTeamNumberBy1.Visible = match.IsQuickMatch;
            btnDecreaseHomeTeamNumberBy1.Visible = match.IsQuickMatch;
            btnIncreaseHomeTeamNumberBy1.Visible = match.IsQuickMatch;

            AwayTeamBalance.Visible = !match.IsQuickMatch;
            HomeTeamBalance.Visible = !match.IsQuickMatch;

            matches = matchBL.GetMatchesForThisDay(Program.MatchDate);
            teams = teamsBL.GetAllTeams().ToList();

            if (match.IsQuickMatch)
            {
                AwayTeamNumber = 0;
                HomeTeamNumber = 1;
            }
            else
            {
                matchNumber = 0;
                AwayTeamNumber = teams.FindIndex(team => team.TeamAbbreviation == matches[0].AwayTeamAbbreviation);
                HomeTeamNumber = teams.FindIndex(team => team.TeamAbbreviation == matches[0].HomeTeamAbbreviation);
                dataGridView1.Rows.Clear();
                for (int i = 0; i < matches.Count; i++)
                {
                    dataGridView1.Rows.Add(Image.FromFile($"TeamLogosForSubstitution/{matches[i].AwayTeamAbbreviation}.png"), Image.FromFile($"TeamLogosForSubstitution/{matches[i].HomeTeamAbbreviation}.png"));
                }

            }
            btnSwap.Visible = match.IsQuickMatch;
            dataGridView1.Visible = !match.IsQuickMatch;
        }

        private void TeamsSelectForm_Load(object sender, EventArgs e)
        {
            DisplayTeam(AwayTeamNumber, numAwayTeamColor, lbAwayCity, lbAwayTitle, pbAwayLogo, CurrentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnDecreaseAwayTeamNumberBy1, btnIncreaseAwayTeamNumberBy1, AwayTeamBalance);
            DisplayTeam(HomeTeamNumber, numHomeTeamColor, lbHomeCity, lbHomeTitle, pbHomeLogo, CurrentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnDecreaseHomeTeamNumberBy1, btnIncreaseHomeTeamNumberBy1, HomeTeamBalance);
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
            CurrentAwayColor = (int)numAwayTeamColor.Value;
            CurrentTeamColorChanged(AwayTeamNumber, CurrentAwayColor, lbAwayCity, lbAwayTitle, label4, btnIncreaseAwayTeamNumberBy1, btnDecreaseAwayTeamNumberBy1);
        }

        private void btnIncreaseAwayTeamNumberBy1_Click(object sender, EventArgs e)
        {
            AwayTeamNumber = AwayTeamNumber == teams.Count - 1 ? 0 : AwayTeamNumber + 1;
            if (AwayTeamNumber == HomeTeamNumber)
            {
                AwayTeamNumber = AwayTeamNumber == teams.Count - 1 ? 0 : AwayTeamNumber + 1;
            }
            DisplayTeam(AwayTeamNumber, numAwayTeamColor, lbAwayCity, lbAwayTitle, pbAwayLogo, CurrentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnIncreaseAwayTeamNumberBy1, btnDecreaseAwayTeamNumberBy1, AwayTeamBalance);
        }

        private void btnIncreaseHomeTeamNumberBy1_Click(object sender, EventArgs e)
        {
            HomeTeamNumber = HomeTeamNumber == teams.Count - 1 ? 0 : HomeTeamNumber + 1;
            if (AwayTeamNumber == HomeTeamNumber)
            {
                HomeTeamNumber = HomeTeamNumber == teams.Count - 1 ? 0 : HomeTeamNumber + 1;
            }
            DisplayTeam(HomeTeamNumber, numHomeTeamColor, lbHomeCity, lbHomeTitle, pbHomeLogo, CurrentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnIncreaseHomeTeamNumberBy1, btnDecreaseHomeTeamNumberBy1, HomeTeamBalance);
        }

        private void btnDecreaseHomeTeamNumberBy1_Click(object sender, EventArgs e)
        {
            HomeTeamNumber = HomeTeamNumber == 0 ? teams.Count - 1 : HomeTeamNumber - 1;
            if (AwayTeamNumber == HomeTeamNumber)
            {
                HomeTeamNumber = HomeTeamNumber == 0 ? teams.Count - 1 : HomeTeamNumber - 1;
            }
            DisplayTeam(HomeTeamNumber, numHomeTeamColor, lbHomeCity, lbHomeTitle, pbHomeLogo, CurrentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnIncreaseHomeTeamNumberBy1, btnDecreaseHomeTeamNumberBy1, HomeTeamBalance);
        }

        private void btnDecreaseAwayTeamNumberBy1_Click(object sender, EventArgs e)
        {
            AwayTeamNumber = AwayTeamNumber == 0 ? teams.Count - 1 : AwayTeamNumber - 1;
            if (AwayTeamNumber == HomeTeamNumber)
            {
                AwayTeamNumber = AwayTeamNumber == 0 ? teams.Count - 1 : AwayTeamNumber - 1;
            }
            DisplayTeam(AwayTeamNumber, numAwayTeamColor, lbAwayCity, lbAwayTitle, pbAwayLogo, CurrentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnIncreaseAwayTeamNumberBy1, btnDecreaseAwayTeamNumberBy1, AwayTeamBalance);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            CurrentHomeColor = (int)numHomeTeamColor.Value;
            CurrentTeamColorChanged(HomeTeamNumber, CurrentHomeColor, lbHomeCity, lbHomeTitle, label5, btnIncreaseHomeTeamNumberBy1, btnDecreaseHomeTeamNumberBy1);
        }

        private void btnAcceptTeamsSelection_Click(object sender, EventArgs e)
        {
            StartNewMatch();
        }


        private void StartNewMatch()
        {
            Team HomeTeam = teams[HomeTeamNumber];
            Team AwayTeam = teams[AwayTeamNumber];
            HomeTeam.TeamColorForThisMatch = HomeTeam.TeamColor[CurrentHomeColor];
            AwayTeam.TeamColorForThisMatch = AwayTeam.TeamColor[CurrentAwayColor];
            newMatch.HomeTeam = HomeTeam;
            newMatch.AwayTeam = AwayTeam;
            StadiumSelectionForm stadiumSelection = new StadiumSelectionForm(newMatch);
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
            int Buf = AwayTeamNumber;
            AwayTeamNumber = HomeTeamNumber;
            HomeTeamNumber = Buf;

            DisplayTeam(AwayTeamNumber, numAwayTeamColor, lbAwayCity, lbAwayTitle, pbAwayLogo, CurrentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnDecreaseAwayTeamNumberBy1, btnIncreaseAwayTeamNumberBy1, AwayTeamBalance);
            DisplayTeam(HomeTeamNumber, numHomeTeamColor, lbHomeCity, lbHomeTitle, pbHomeLogo, CurrentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnDecreaseHomeTeamNumberBy1, btnIncreaseHomeTeamNumberBy1, HomeTeamBalance);
        }

        private void BackColorChanging_label(object sender, EventArgs e)
        {
            Label l = sender as Label;
            l.ForeColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(l.BackColor, false);
        }

        private void BackColorChanging_button(object sender, EventArgs e)
        {
            Button l = sender as Button;
            l.ForeColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(l.BackColor, false);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                matchNumber = dataGridView1.SelectedRows[0].Index;
                AwayTeamNumber = teams.FindIndex(team => team.TeamAbbreviation == matches[matchNumber].AwayTeamAbbreviation);
                HomeTeamNumber = teams.FindIndex(team => team.TeamAbbreviation == matches[matchNumber].HomeTeamAbbreviation);
                DisplayTeam(AwayTeamNumber, numAwayTeamColor, lbAwayCity, lbAwayTitle, pbAwayLogo, CurrentAwayColor, label4, AwayOverallRating, AwayDefensiveRating, AwayOffensiveRating, btnDecreaseAwayTeamNumberBy1, btnIncreaseAwayTeamNumberBy1, AwayTeamBalance);
                DisplayTeam(HomeTeamNumber, numHomeTeamColor, lbHomeCity, lbHomeTitle, pbHomeLogo, CurrentHomeColor, label5, HomeOverallRating, HomeDefensiveRating, HomeOffensiveRating, btnDecreaseHomeTeamNumberBy1, btnIncreaseHomeTeamNumberBy1, HomeTeamBalance);
            }
        }

        private void TeamsSelectForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    {
                        if (!newMatch.IsQuickMatch)
                        {
                            Program.MatchDate = matchBL.GetDateForNextMatch();
                            matches = matchBL.GetMatchesForThisDay(Program.MatchDate);
                            matchNumber = 0;
                            AwayTeamNumber = teams.FindIndex(team => team.TeamAbbreviation == matches[0].AwayTeamAbbreviation);
                            HomeTeamNumber = teams.FindIndex(team => team.TeamAbbreviation == matches[0].HomeTeamAbbreviation);
                            dataGridView1.Rows.Clear();
                            for (int i = 0; i < matches.Count; i++)
                            {
                                dataGridView1.Rows.Add(Image.FromFile($"TeamLogosForSubstitution/{matches[i].AwayTeamAbbreviation}.png"), Image.FromFile($"TeamLogosForSubstitution/{matches[i].HomeTeamAbbreviation}.png"));
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