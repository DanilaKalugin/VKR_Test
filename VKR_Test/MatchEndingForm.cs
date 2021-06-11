using Entities;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class MatchEndingForm : Form
    {
        Match endedmatch;
        private readonly MatchBL matchBL;

        public MatchEndingForm(Match match)
        {
            InitializeComponent();
            matchBL = new MatchBL();
            endedmatch = match;
        }

        private void UpdateScoreboard(Label FirstInning, Label SecondInning, Label ThirdInning, Label FourthInning, Label FifthInning, Label SixthInning, Label SeventhInning, Label EigthInning, Label NinthInning, Label ExtraInnings, Label Runs, Label Hits, Match match, Team team)
        {
            FirstInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb1stInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            SecondInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb2ndInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            ThirdInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb3rdInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            FourthInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb4thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            FifthInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb5thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            SixthInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb6thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            SeventhInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb7thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            EigthInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb8thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            NinthInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb9thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            ExtraInnings.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb10thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();

            bool DisplayingCriterion = team == endedmatch.AwayTeam ? (endedmatch.gameSituations.Last().offense == endedmatch.AwayTeam || endedmatch.gameSituations.Last().offense == endedmatch.HomeTeam) : endedmatch.gameSituations.Last().offense == endedmatch.HomeTeam;

            FirstInning.ForeColor = endedmatch.gameSituations.Last().inningNumber > int.Parse(lb1stInning.Text) || endedmatch.gameSituations.Last().inningNumber == int.Parse(lb1stInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            SecondInning.ForeColor = endedmatch.gameSituations.Last().inningNumber > int.Parse(lb2ndInning.Text) || endedmatch.gameSituations.Last().inningNumber == int.Parse(lb2ndInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            ThirdInning.ForeColor = endedmatch.gameSituations.Last().inningNumber > int.Parse(lb3rdInning.Text) || endedmatch.gameSituations.Last().inningNumber == int.Parse(lb3rdInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            FourthInning.ForeColor = endedmatch.gameSituations.Last().inningNumber > int.Parse(lb4thInning.Text) || endedmatch.gameSituations.Last().inningNumber == int.Parse(lb4thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            FifthInning.ForeColor = endedmatch.gameSituations.Last().inningNumber > int.Parse(lb5thInning.Text) || endedmatch.gameSituations.Last().inningNumber == int.Parse(lb5thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            SixthInning.ForeColor = endedmatch.gameSituations.Last().inningNumber > int.Parse(lb6thInning.Text) || endedmatch.gameSituations.Last().inningNumber == int.Parse(lb6thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            SeventhInning.ForeColor = endedmatch.gameSituations.Last().inningNumber > int.Parse(lb7thInning.Text) || endedmatch.gameSituations.Last().inningNumber == int.Parse(lb7thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            EigthInning.ForeColor = endedmatch.gameSituations.Last().inningNumber > int.Parse(lb8thInning.Text) || endedmatch.gameSituations.Last().inningNumber == int.Parse(lb8thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            NinthInning.ForeColor = endedmatch.gameSituations.Last().inningNumber > int.Parse(lb9thInning.Text) || endedmatch.gameSituations.Last().inningNumber == int.Parse(lb9thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            ExtraInnings.ForeColor = endedmatch.gameSituations.Last().inningNumber > int.Parse(lb10thInning.Text) || endedmatch.gameSituations.Last().inningNumber == int.Parse(lb10thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);

            Runs.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation).Select(atBat => atBat.RBI).Sum().ToString();
            Hits.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && (atBat.AtBatResult == AtBat.AtBatType.Single || atBat.AtBatResult == AtBat.AtBatType.Double || atBat.AtBatResult == AtBat.AtBatType.Triple || atBat.AtBatResult == AtBat.AtBatType.HomeRun)).Count().ToString();
        }

        private void NumberOfLastInningDefinition(Match match)
        {
            lb10thInning.Text = match.gameSituations.Last().inningNumber <= 10 ? 10.ToString() : match.gameSituations.Last().inningNumber.ToString();
            lb9thInning.Text = (int.Parse(lb10thInning.Text) - 1).ToString();
            lb8thInning.Text = (int.Parse(lb9thInning.Text) - 1).ToString();
            lb7thInning.Text = (int.Parse(lb8thInning.Text) - 1).ToString();
            lb6thInning.Text = (int.Parse(lb7thInning.Text) - 1).ToString();
            lb5thInning.Text = (int.Parse(lb6thInning.Text) - 1).ToString();
            lb4thInning.Text = (int.Parse(lb5thInning.Text) - 1).ToString();
            lb3rdInning.Text = (int.Parse(lb4thInning.Text) - 1).ToString();
            lb2ndInning.Text = (int.Parse(lb3rdInning.Text) - 1).ToString();
            lb1stInning.Text = (int.Parse(lb2ndInning.Text) - 1).ToString();
        }

        private void MatchEndingForm_Load(object sender, EventArgs e)
        {
            NumberOfLastInningDefinition(endedmatch);

            GetInformationAboutTeam(endedmatch.AwayTeam, lbAwayTeamAbbreviation, AwayTeamSmallLogo, lbAwayBalance, pbAwayLogo);
            GetInformationAboutTeam(endedmatch.HomeTeam, lbHomeTeamAbbreviation, HomeTeamSmallLogo, lbHomeBalance, pbHomeLogo);

            lbAwayRuns.Text = endedmatch.gameSituations.Last().AwayTeamRuns.ToString();
            lbHomeRuns.Text = endedmatch.gameSituations.Last().HomeTeamRuns.ToString();

            UpdateScoreboard(away1, away2, away3, away4, away5, away6, away7, away8, away9, away10, awayRuns, awayHits, endedmatch, endedmatch.AwayTeam);
            UpdateScoreboard(home1, home2, home3, home4, home5, home6, home7, home8, home9, home10, homeRuns, homeHits, endedmatch, endedmatch.HomeTeam);

            MatchResultForPitcherAnalysis(endedmatch, endedmatch.AwayTeam);
            MatchResultForPitcherAnalysis(endedmatch, endedmatch.HomeTeam);
        }

        private void GetInformationAboutTeam(Team team, Label Abbreviation, Panel panelSmallLogo, Label Balance, Panel panelBigLogo)
        {
            Abbreviation.BackColor = team.TeamColorForThisMatch;
            Abbreviation.Text = team.TeamAbbreviation.ToUpper();
            panelSmallLogo.BackgroundImage = Image.FromFile($"SmallTeamLogos/{team.TeamAbbreviation}.png");
            Balance.Text = $"{team.Wins}-{team.Losses}";
            Balance.ForeColor = team.TeamColorForThisMatch;
            panelBigLogo.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{team.TeamAbbreviation}.png");
            panelBigLogo.BackColor = Color.FromArgb((int)(team.TeamColorForThisMatch.R * 0.85), (int)(team.TeamColorForThisMatch.G * 0.85), (int)(team.TeamColorForThisMatch.B * 0.85));
        }

        private void MatchResultForPitcherAnalysis(Match endedmatch, Team awayTeam)
        {
            int RunsForThisPitcher = endedmatch.atBats.Count(atBat => atBat.AtBatResult == AtBat.AtBatType.Run && atBat.Pitcher == awayTeam.PitchersPlayedInMatch[0].id);
            int OutsPlayedForThisTeam = endedmatch.atBats.Where(atBat => atBat.Defense == awayTeam.TeamAbbreviation).Select(atBat => atBat.outs).Sum();
            int OutsPlayedForThisPitcher = endedmatch.atBats.Where(atBat => atBat.Pitcher == awayTeam.PitchersPlayedInMatch[0].id).Select(atBat => atBat.outs).Sum();

            bool IsQS = RunsForThisPitcher <= 3 && OutsPlayedForThisPitcher / 3 >= 6;
            bool IsCG = OutsPlayedForThisPitcher == OutsPlayedForThisTeam;
            bool IsSHO = IsCG && RunsForThisPitcher == 0;

            matchBL.AddMatchResultForThisPitcher(new PitcherResults(awayTeam.PitchersPlayedInMatch[0].id, awayTeam.TeamAbbreviation, endedmatch.MatchID, IsQS, IsCG, IsSHO));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void BackColorChanging_label(object sender, EventArgs e)
        {
            Label l = sender as Label;
            l.ForeColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(l.BackColor, false);
        }
    }
}