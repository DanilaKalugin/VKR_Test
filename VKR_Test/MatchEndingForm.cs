﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Entities;
using VKR.BLL;

namespace VKR_Test
{
    public partial class MatchEndingForm : Form
    {
        private readonly Match _endedMatch;
        private readonly MatchBL _matchBL;
        private readonly TeamsBL _teamsBL;

        public MatchEndingForm(Match match)
        {
            InitializeComponent();
            _matchBL = new MatchBL();
            _teamsBL = new TeamsBL();
            _endedMatch = match;
        }

        private void UpdateScoreboard(Label firstInning, Label secondInning, Label thirdInning, Label fourthInning, Label fifthInning, Label sixthInning, Label seventhInning, Label eigthInning, Label ninthInning, Label extraInnings, Label Runs, Label Hits, Label LeftOnBase, Match match, Team team)
        {
            firstInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb1stInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            secondInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb2ndInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            thirdInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb3rdInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            fourthInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb4thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            fifthInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb5thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            sixthInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb6thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            seventhInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb7thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            eigthInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb8thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            ninthInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb9thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            extraInnings.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb10thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();

            var LeftOnFirstBase = match.GameSituations.Count(gs => gs.Outs == 3 && gs.Offense.TeamAbbreviation == team.TeamAbbreviation && gs.RunnerOnFirst.IsBaseNotEmpty);
            var LeftOnSecondBase = match.GameSituations.Count(gs => gs.Outs == 3 && gs.Offense.TeamAbbreviation == team.TeamAbbreviation && gs.RunnerOnSecond.IsBaseNotEmpty);
            var LeftOnThirdBase = match.GameSituations.Count(gs => gs.Outs == 3 && gs.Offense.TeamAbbreviation == team.TeamAbbreviation && gs.RunnerOnThird.IsBaseNotEmpty);

            LeftOnBase.Text = (LeftOnFirstBase + LeftOnSecondBase + LeftOnThirdBase).ToString();

            var DisplayingCriterion = team == match.AwayTeam ? match.GameSituations.Last().Offense == match.AwayTeam || match.GameSituations.Last().Offense == match.HomeTeam : match.GameSituations.Last().Offense == match.HomeTeam;

            firstInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb1stInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb1stInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            secondInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb2ndInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb2ndInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            thirdInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb3rdInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb3rdInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            fourthInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb4thInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb4thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            fifthInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb5thInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb5thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            sixthInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb6thInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb6thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            seventhInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb7thInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb7thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            eigthInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb8thInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb8thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            ninthInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb9thInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb9thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            extraInnings.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb10thInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb10thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);

            Runs.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation).Select(atBat => atBat.RBI).Sum().ToString();
            Hits.Text = match.AtBats.Count(atBat => atBat.Offense == team.TeamAbbreviation && (atBat.AtBatResult == AtBat.AtBatType.Single || atBat.AtBatResult == AtBat.AtBatType.Double || atBat.AtBatResult == AtBat.AtBatType.Triple || atBat.AtBatResult == AtBat.AtBatType.HomeRun)).ToString();
        }

        private void NumberOfLastInningDefinition(Match match)
        {
            lb10thInning.Text = match.GameSituations.Last().InningNumber <= 10 ? 10.ToString() : match.GameSituations.Last().InningNumber.ToString();
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
            NumberOfLastInningDefinition(_endedMatch);

            _teamsBL.UpdateTeamBalance(_endedMatch.AwayTeam);
            _teamsBL.UpdateTeamBalance(_endedMatch.HomeTeam);

            GetInformationAboutTeam(_endedMatch.AwayTeam, lbAwayTeamAbbreviation, AwayTeamSmallLogo, lbAwayBalance, pbAwayLogo_border, pbAwayLogo);
            GetInformationAboutTeam(_endedMatch.HomeTeam, lbHomeTeamAbbreviation, HomeTeamSmallLogo, lbHomeBalance, pbHomeLogo_border, pbHomeLogo);

            lbAwayRuns.Text = _endedMatch.GameSituations.Last().AwayTeamRuns.ToString();
            lbHomeRuns.Text = _endedMatch.GameSituations.Last().HomeTeamRuns.ToString();

            UpdateScoreboard(away1, away2, away3, away4, away5, away6, away7, away8, away9, away10, awayRuns, awayHits, awayLOB, _endedMatch, _endedMatch.AwayTeam);
            UpdateScoreboard(home1, home2, home3, home4, home5, home6, home7, home8, home9, home10, homeRuns, homeHits, homeLOB, _endedMatch, _endedMatch.HomeTeam);

            MatchResultForPitcherAnalysis(_endedMatch, _endedMatch.AwayTeam);
            MatchResultForPitcherAnalysis(_endedMatch, _endedMatch.HomeTeam);
        }

        private void GetInformationAboutTeam(Team team, Label Abbreviation, Panel panelSmallLogo, Label Balance, Panel panelBorder, Panel BigLogo)
        {
            Abbreviation.BackColor = team.TeamColorForThisMatch;
            Abbreviation.Text = team.TeamAbbreviation.ToUpper();
            panelSmallLogo.BackgroundImage = Image.FromFile($"SmallTeamLogos/{team.TeamAbbreviation}.png");
            Balance.Visible = !_endedMatch.IsQuickMatch;
            Balance.Text = $"{team.Wins}-{team.Losses}";
            Balance.ForeColor = team.TeamColorForThisMatch;
            BigLogo.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{team.TeamAbbreviation}.png");
            BigLogo.BackColor = Color.FromArgb((int)(team.TeamColorForThisMatch.R * 0.85), (int)(team.TeamColorForThisMatch.G * 0.85), (int)(team.TeamColorForThisMatch.B * 0.85));
            panelBorder.BackColor = Color.FromArgb((int)(team.TeamColorForThisMatch.R * 0.85), (int)(team.TeamColorForThisMatch.G * 0.85), (int)(team.TeamColorForThisMatch.B * 0.85));
        }

        private void MatchResultForPitcherAnalysis(Match endedmatch, Team awayTeam)
        {
            var WinningTeam = endedmatch.GameSituations.Last().AwayTeamRuns > endedmatch.GameSituations.Last().HomeTeamRuns ? endedmatch.AwayTeam : endedmatch.HomeTeam;

            var results = awayTeam.PitchersPlayedInMatch.Select(pitcher => new PitcherResults(pitcher.Id, awayTeam.TeamAbbreviation, endedmatch.MatchID)).ToList();

            var RunsForThisPitcher = endedmatch.AtBats.Count(atBat => atBat.AtBatResult == AtBat.AtBatType.Run && atBat.Pitcher == awayTeam.PitchersPlayedInMatch[0].Id);
            var OutsPlayedForThisTeam = endedmatch.AtBats.Where(atBat => atBat.Defense == awayTeam.TeamAbbreviation).Select(atBat => atBat.Outs).Sum();
            var OutsPlayedForThisPitcher = endedmatch.AtBats.Where(atBat => atBat.Pitcher == awayTeam.PitchersPlayedInMatch[0].Id).Select(atBat => atBat.Outs).Sum();

            results[0].IsQualityStart = RunsForThisPitcher <= 3 && OutsPlayedForThisPitcher / 3 >= 6;
            results[0].IsCompleteGame = OutsPlayedForThisPitcher == OutsPlayedForThisTeam;
            results[0].IsShutout = results[0].IsCompleteGame && RunsForThisPitcher == 0;

            if (awayTeam.PitchersPlayedInMatch.Count == 1)
            {
                if (awayTeam.TeamAbbreviation == WinningTeam.TeamAbbreviation)
                {
                    results[0].MatchResult = results[0].IsCompleteGame ? PitcherResults.MatchResultForPitcher.Win : PitcherResults.MatchResultForPitcher.NoDecision;
                    WinningPitcher.Text = $"{awayTeam.PitchersPlayedInMatch[0].FullName} ({awayTeam.PitchersPlayedInMatch[0].PitchingStats.Wins + 1} - {awayTeam.PitchersPlayedInMatch[0].PitchingStats.Losses})";
                    WinningPitcher.BackColor = awayTeam.TeamColorForThisMatch;
                    PitcherWithSave.Text = "-";
                    PitcherWithSave.BackColor = awayTeam.TeamColorForThisMatch;
                }
                else
                {
                    results[0].MatchResult = results[0].IsCompleteGame ? PitcherResults.MatchResultForPitcher.Loss : PitcherResults.MatchResultForPitcher.NoDecision;
                    LosingPitcher.Text = $"{awayTeam.PitchersPlayedInMatch[0].FullName} ({awayTeam.PitchersPlayedInMatch[0].PitchingStats.Wins} - {awayTeam.PitchersPlayedInMatch[0].PitchingStats.Losses + 1})";
                    LosingPitcher.BackColor = awayTeam.TeamColorForThisMatch;
                }
            }
            else
            {
                var leadersAfyerEachAtBat = endedmatch.GetMatchLeaderAfterEachPitch();
                var winningPitchId = Array.FindLastIndex(leadersAfyerEachAtBat.ToArray(), leader => leader != WinningTeam.TeamAbbreviation);
                var winningPitch = endedmatch.GameSituations[winningPitchId + 1];
                var losingPitcherId = winningPitch.PitcherID;

                if (awayTeam.TeamAbbreviation == WinningTeam.TeamAbbreviation)
                {
                    var InningNumber = winningPitch.InningNumber;
                    var WinningPitcherID = endedmatch.GameSituations.First(gs => gs.InningNumber == InningNumber && gs.Offense.TeamAbbreviation != awayTeam.TeamAbbreviation && gs.Id > 0).PitcherID;
                    var WinningPitcherIndex = awayTeam.PitchersPlayedInMatch.IndexOf(awayTeam.PitchersPlayedInMatch.First(pitcher => pitcher.Id == WinningPitcherID));
                    if (WinningPitcherIndex != -1)
                    {
                        for (var i = 0; i < WinningPitcherIndex; i++)
                            results[i].MatchResult = PitcherResults.MatchResultForPitcher.NoDecision;

                        results[WinningPitcherIndex].MatchResult = PitcherResults.MatchResultForPitcher.Win;
                        WinningPitcher.Text = $"{awayTeam.PitchersPlayedInMatch[WinningPitcherIndex].FullName} ({awayTeam.PitchersPlayedInMatch[WinningPitcherIndex].PitchingStats.Wins + 1} - {awayTeam.PitchersPlayedInMatch[0].PitchingStats.Losses})";
                        WinningPitcher.BackColor = awayTeam.TeamColorForThisMatch;

                        if (WinningPitcherIndex < awayTeam.PitchersPlayedInMatch.Count - 1)
                        {
                            results[awayTeam.PitchersPlayedInMatch.Count - 1].MatchResult = PitcherResults.MatchResultForPitcher.Save;
                            PitcherWithSave.Text = $"{awayTeam.PitchersPlayedInMatch[awayTeam.PitchersPlayedInMatch.Count - 1].FullName} ({awayTeam.PitchersPlayedInMatch[awayTeam.PitchersPlayedInMatch.Count - 1].PitchingStats.Saves + 1})";
                        }
                        else PitcherWithSave.Text = "-";

                        PitcherWithSave.BackColor = awayTeam.TeamColorForThisMatch;

                        for (var i = WinningPitcherIndex + 1; i < awayTeam.PitchersPlayedInMatch.Count - 1; i++)
                            results[i].MatchResult = PitcherResults.MatchResultForPitcher.Hold;
                    }
                }
                else
                {
                    if (awayTeam.PitchersPlayedInMatch.Contains(awayTeam.PitchersPlayedInMatch.First(pitcher => pitcher.Id == losingPitcherId)))
                    {
                        var LosingPitcherIndex = awayTeam.PitchersPlayedInMatch.IndexOf(awayTeam.PitchersPlayedInMatch.First(pitcher => pitcher.Id == losingPitcherId));
                        results[LosingPitcherIndex].MatchResult = PitcherResults.MatchResultForPitcher.Loss;
                        LosingPitcher.Text = $"{awayTeam.PitchersPlayedInMatch[LosingPitcherIndex].FullName} ({awayTeam.PitchersPlayedInMatch[LosingPitcherIndex].PitchingStats.Wins} - {awayTeam.PitchersPlayedInMatch[LosingPitcherIndex].PitchingStats.Losses + 1})";
                        LosingPitcher.BackColor = awayTeam.TeamColorForThisMatch;
                        for (var i = 0; i < awayTeam.PitchersPlayedInMatch.Count; i++)
                        {
                            if (i != LosingPitcherIndex)
                                results[i].MatchResult = PitcherResults.MatchResultForPitcher.NoDecision;
                        }
                    }
                }
            }

            for (var j = 0; j < awayTeam.PitchersPlayedInMatch.Count; j++)
                _matchBL.AddMatchResultForThisPitcher(results[j], endedmatch);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void BackColorChanging_label(object sender, EventArgs e)
        {
            if (sender is Label l)
                l.ForeColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(l.BackColor, false);
        }
    }
}