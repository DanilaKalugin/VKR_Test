using Entities;
using System;
using System.Collections.Generic;
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
        private readonly TeamsBL teamsBL;

        public MatchEndingForm(Match match)
        {
            InitializeComponent();
            matchBL = new MatchBL();
            teamsBL = new TeamsBL();
            endedmatch = match;
        }

        private void UpdateScoreboard(Label FirstInning, Label SecondInning, Label ThirdInning, Label FourthInning, Label FifthInning, Label SixthInning, Label SeventhInning, Label EigthInning, Label NinthInning, Label ExtraInnings, Label Runs, Label Hits, Label LeftOnBase, Match match, Team team)
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

            int LeftOnFirstBase = match.gameSituations.Where(gs => gs.outs == 3 && gs.offense.TeamAbbreviation == team.TeamAbbreviation && gs.RunnerOnFirst.IsBaseNotEmpty).Count();
            int LeftOnSecondBase = match.gameSituations.Where(gs => gs.outs == 3 && gs.offense.TeamAbbreviation == team.TeamAbbreviation && gs.RunnerOnSecond.IsBaseNotEmpty).Count();
            int LeftOnThirdBase = match.gameSituations.Where(gs => gs.outs == 3 && gs.offense.TeamAbbreviation == team.TeamAbbreviation && gs.RunnerOnThird.IsBaseNotEmpty).Count();

            LeftOnBase.Text = (LeftOnFirstBase + LeftOnSecondBase + LeftOnThirdBase).ToString();

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

            teamsBL.UpdateTeamBalance(endedmatch.AwayTeam);
            teamsBL.UpdateTeamBalance(endedmatch.HomeTeam);

            GetInformationAboutTeam(endedmatch.AwayTeam, lbAwayTeamAbbreviation, AwayTeamSmallLogo, lbAwayBalance, pbAwayLogo);
            GetInformationAboutTeam(endedmatch.HomeTeam, lbHomeTeamAbbreviation, HomeTeamSmallLogo, lbHomeBalance, pbHomeLogo);

            lbAwayRuns.Text = endedmatch.gameSituations.Last().AwayTeamRuns.ToString();
            lbHomeRuns.Text = endedmatch.gameSituations.Last().HomeTeamRuns.ToString();

            UpdateScoreboard(away1, away2, away3, away4, away5, away6, away7, away8, away9, away10, awayRuns, awayHits, awayLOB, endedmatch, endedmatch.AwayTeam);
            UpdateScoreboard(home1, home2, home3, home4, home5, home6, home7, home8, home9, home10, homeRuns, homeHits, homeLOB, endedmatch, endedmatch.HomeTeam);

            MatchResultForPitcherAnalysis(endedmatch, endedmatch.AwayTeam);
            MatchResultForPitcherAnalysis(endedmatch, endedmatch.HomeTeam);
        }

        private void GetInformationAboutTeam(Team team, Label Abbreviation, Panel panelSmallLogo, Label Balance, Panel panelBigLogo)
        {
            Abbreviation.BackColor = team.TeamColorForThisMatch;
            Abbreviation.Text = team.TeamAbbreviation.ToUpper();
            panelSmallLogo.BackgroundImage = Image.FromFile($"SmallTeamLogos/{team.TeamAbbreviation}.png");
            Balance.Visible = !endedmatch.IsQuickMatch;
            Balance.Text = $"{team.Wins}-{team.Losses}";
            Balance.ForeColor = team.TeamColorForThisMatch;
            panelBigLogo.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{team.TeamAbbreviation}.png");
            panelBigLogo.BackColor = Color.FromArgb((int)(team.TeamColorForThisMatch.R * 0.85), (int)(team.TeamColorForThisMatch.G * 0.85), (int)(team.TeamColorForThisMatch.B * 0.85));
        }

        private void MatchResultForPitcherAnalysis(Match endedmatch, Team awayTeam)
        {
            List<PitcherResults> results = new List<PitcherResults>();
            Team WinningTeam = endedmatch.gameSituations.Last().AwayTeamRuns > endedmatch.gameSituations.Last().HomeTeamRuns ? endedmatch.AwayTeam : endedmatch.HomeTeam;
            for (int i = 0; i < awayTeam.PitchersPlayedInMatch.Count; i++)
            {
                results.Add(new PitcherResults(awayTeam.PitchersPlayedInMatch[i].id, awayTeam.TeamAbbreviation, endedmatch.MatchID));
            }

            int RunsForThisPitcher = endedmatch.atBats.Count(atBat => atBat.AtBatResult == AtBat.AtBatType.Run && atBat.Pitcher == awayTeam.PitchersPlayedInMatch[0].id);
            int OutsPlayedForThisTeam = endedmatch.atBats.Where(atBat => atBat.Defense == awayTeam.TeamAbbreviation).Select(atBat => atBat.outs).Sum();
            int OutsPlayedForThisPitcher = endedmatch.atBats.Where(atBat => atBat.Pitcher == awayTeam.PitchersPlayedInMatch[0].id).Select(atBat => atBat.outs).Sum();

            results[0].IsQualityStart = RunsForThisPitcher <= 3 && OutsPlayedForThisPitcher / 3 >= 6;
            results[0].IsCompleteGame = OutsPlayedForThisPitcher == OutsPlayedForThisTeam;
            results[0].IsShutout = results[0].IsCompleteGame && RunsForThisPitcher == 0;

            if (awayTeam.PitchersPlayedInMatch.Count == 1)
            {
                if (awayTeam.TeamAbbreviation == WinningTeam.TeamAbbreviation)
                {
                    results[0].matchResult = results[0].IsCompleteGame ? PitcherResults.MatchResultForPitcher.Win: PitcherResults.MatchResultForPitcher.NoDecision;
                    WinningPitcher.Text = $"{awayTeam.PitchersPlayedInMatch[0].FullName} ({awayTeam.PitchersPlayedInMatch[0].Wins + 1} - {awayTeam.PitchersPlayedInMatch[0].Losses})";
                    WinningPitcher.BackColor = awayTeam.TeamColorForThisMatch;
                    PitcherWithSave.Text = "-";
                    PitcherWithSave.BackColor = awayTeam.TeamColorForThisMatch;
                }
                else
                {
                    results[0].matchResult = results[0].IsCompleteGame ? PitcherResults.MatchResultForPitcher.Loss : PitcherResults.MatchResultForPitcher.NoDecision;
                    LosingPitcher.Text = $"{awayTeam.PitchersPlayedInMatch[0].FullName} ({awayTeam.PitchersPlayedInMatch[0].Wins} - {awayTeam.PitchersPlayedInMatch[0].Losses + 1})";
                    LosingPitcher.BackColor = awayTeam.TeamColorForThisMatch;
                }
            }
            else
            {
                List<string> LeadersAfyerEachAtBat = endedmatch.GetMatchLeaderAfterEachPitch();
                int winningPitchID = Array.FindLastIndex(LeadersAfyerEachAtBat.ToArray(), leader => leader != WinningTeam.TeamAbbreviation);
                GameSituation winningPitch = endedmatch.gameSituations[winningPitchID + 1];
                int LosingPitcherID = winningPitch.PitcherID;
                if (awayTeam.TeamAbbreviation == WinningTeam.TeamAbbreviation)
                {
                    int InningNumber = winningPitch.inningNumber;
                    int WinningPitcherID = endedmatch.gameSituations.Where(gs => gs.inningNumber == InningNumber && gs.offense.TeamAbbreviation != awayTeam.TeamAbbreviation && gs.id > 0).First().PitcherID;
                    int WinningPitcherIndex = awayTeam.PitchersPlayedInMatch.IndexOf(awayTeam.PitchersPlayedInMatch.Where(pitcher => pitcher.id == WinningPitcherID).First());
                    if (WinningPitcherIndex != -1)
                    {
                        for (int i = 0; i < WinningPitcherIndex; i++)
                        {
                            results[i].matchResult = PitcherResults.MatchResultForPitcher.NoDecision;
                        }
                        results[WinningPitcherIndex].matchResult = PitcherResults.MatchResultForPitcher.Win;
                        WinningPitcher.Text = $"{awayTeam.PitchersPlayedInMatch[WinningPitcherIndex].FullName} ({awayTeam.PitchersPlayedInMatch[WinningPitcherIndex].Wins + 1} - {awayTeam.PitchersPlayedInMatch[0].Losses})";
                        WinningPitcher.BackColor = awayTeam.TeamColorForThisMatch;

                        if (WinningPitcherIndex < awayTeam.PitchersPlayedInMatch.Count - 1)
                        {
                            results[awayTeam.PitchersPlayedInMatch.Count - 1].matchResult = PitcherResults.MatchResultForPitcher.Save;
                            PitcherWithSave.Text = $"{awayTeam.PitchersPlayedInMatch[awayTeam.PitchersPlayedInMatch.Count - 1].FullName} ({awayTeam.PitchersPlayedInMatch[awayTeam.PitchersPlayedInMatch.Count - 1].Saves + 1})";
                        }
                        else
                        {
                            PitcherWithSave.Text = "-";
                        }
                        PitcherWithSave.BackColor = awayTeam.TeamColorForThisMatch;

                        for (int i = WinningPitcherIndex + 1; i < awayTeam.PitchersPlayedInMatch.Count - 1; i++)
                        {
                            results[i].matchResult = PitcherResults.MatchResultForPitcher.Hold;
                        }
                    }
                }
                else
                {
                    int LosingPitcherIndex = awayTeam.PitchersPlayedInMatch.IndexOf(awayTeam.PitchersPlayedInMatch.Where(pitcher => pitcher.id == LosingPitcherID).First());
                    if (LosingPitcherIndex != -1)
                    {
                        results[LosingPitcherIndex].matchResult = PitcherResults.MatchResultForPitcher.Loss;
                        LosingPitcher.Text = $"{awayTeam.PitchersPlayedInMatch[LosingPitcherIndex].FullName} ({awayTeam.PitchersPlayedInMatch[LosingPitcherIndex].Wins} - {awayTeam.PitchersPlayedInMatch[LosingPitcherIndex].Losses + 1})";
                        LosingPitcher.BackColor = awayTeam.TeamColorForThisMatch;
                        for (int i = 0; i < awayTeam.PitchersPlayedInMatch.Count; i++)
                        {
                            if (i != LosingPitcherIndex)
                            {
                                results[i].matchResult = PitcherResults.MatchResultForPitcher.NoDecision;
                            }
                        }
                    }
                }
            }
            for (int j = 0; j < awayTeam.PitchersPlayedInMatch.Count; j++)
            {
                matchBL.AddMatchResultForThisPitcher(results[j], endedmatch);
            }
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