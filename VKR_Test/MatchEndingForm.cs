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
            FirstInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == 1).Select(atBat => atBat.RBI).ToList().Sum().ToString();
            SecondInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == 2).Select(atBat => atBat.RBI).Sum().ToString();
            ThirdInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == 3).Select(atBat => atBat.RBI).Sum().ToString();
            FourthInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == 4).Select(atBat => atBat.RBI).Sum().ToString();
            FifthInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == 5).Select(atBat => atBat.RBI).Sum().ToString();
            SixthInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == 6).Select(atBat => atBat.RBI).Sum().ToString();
            SeventhInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == 7).Select(atBat => atBat.RBI).Sum().ToString();
            EigthInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == 8).Select(atBat => atBat.RBI).Sum().ToString();
            NinthInning.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == 9).Select(atBat => atBat.RBI).Sum().ToString();
            ExtraInnings.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning > 9).Select(atBat => atBat.RBI).Sum().ToString();

            Runs.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation).Select(atBat => atBat.RBI).Sum().ToString();
            Hits.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && (atBat.AtBatResult == AtBat.AtBatType.Single || atBat.AtBatResult == AtBat.AtBatType.Double || atBat.AtBatResult == AtBat.AtBatType.Triple || atBat.AtBatResult == AtBat.AtBatType.HomeRun)).Count().ToString();
        }

        private void MatchEndingForm_Load(object sender, EventArgs e)
        {
            label18.BackColor = endedmatch.AwayTeam.TeamColorForThisMatch;
            label18.Text = endedmatch.AwayTeam.TeamAbbreviation.ToUpper();
            panel11.BackgroundImage = Image.FromFile($"BigTeamLogos/{endedmatch.AwayTeam.TeamAbbreviation}.png");
            panel12.BackgroundImage = Image.FromFile($"BigTeamLogos/{endedmatch.HomeTeam.TeamAbbreviation}.png");
            label19.Text = endedmatch.HomeTeam.TeamAbbreviation.ToUpper();
            label19.BackColor = endedmatch.HomeTeam.TeamColorForThisMatch;

            panel1.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{endedmatch.AwayTeam.TeamAbbreviation}.png");
            panel2.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{endedmatch.HomeTeam.TeamAbbreviation}.png");

            label1.Text = endedmatch.gameSituations.Last().AwayTeamRuns.ToString();
            label2.Text = endedmatch.gameSituations.Last().HomeTeamRuns.ToString();

            UpdateScoreboard(away1, away2, away3, away4, away5, away6, away7, away8, away9, away10, awayRuns, awayHits, endedmatch, endedmatch.AwayTeam);
            UpdateScoreboard(home1, home2, home3, home4, home5, home6, home7, home8, home9, home10, homeRuns, homeHits, endedmatch, endedmatch.HomeTeam);

            MatchResultForPitcherAnalysis(endedmatch, endedmatch.AwayTeam);
            MatchResultForPitcherAnalysis(endedmatch, endedmatch.HomeTeam);
        }

        private void MatchResultForPitcherAnalysis(Match endedmatch, Team awayTeam)
        {
            int RunsForThisPitcher = endedmatch.atBats.Count(atBat => atBat.AtBatResult == AtBat.AtBatType.Run && atBat.Pitcher == awayTeam.PitchersPlayedInMatch[0].id);
            int OutsPlayedForThisTeam = endedmatch.atBats.Where(atBat => atBat.Defense == awayTeam.TeamAbbreviation).Select(atBat => atBat.outs).Sum();
            int OutsPlayedForThisPitcher = endedmatch.atBats.Where(atBat => atBat.Pitcher == awayTeam.PitchersPlayedInMatch[0].id).Select(atBat => atBat.outs).Sum();

            bool IsQS = (RunsForThisPitcher <= 3 && OutsPlayedForThisPitcher / 3 >= 6);
            bool IsCG = OutsPlayedForThisPitcher == OutsPlayedForThisTeam;
            bool IsSHO = IsCG && RunsForThisPitcher == 0;
            
            matchBL.AddMatchResultForThisPitcher(new PitcherResults(awayTeam.PitchersPlayedInMatch[0].id, awayTeam.TeamAbbreviation, endedmatch.MatchID, IsQS, IsCG, IsSHO));
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}