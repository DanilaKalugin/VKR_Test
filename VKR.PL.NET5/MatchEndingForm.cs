using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;
using VKR.PL.Utils.NET5;

namespace VKR.PL.NET5
{
    public partial class MatchEndingForm : Form
    {
        private readonly Match _endedMatch;
        private readonly MatchBL _matchBL = new();
        private readonly TeamsBL _teamsBL = new();

        public MatchEndingForm(Match match)
        {
            InitializeComponent();
            _endedMatch = match;
        }

        private void UpdateScoreboard(Label firstInning, Label secondInning, Label thirdInning, Label fourthInning, Label fifthInning, Label sixthInning, Label seventhInning, Label eigthInning, Label ninthInning, Label extraInnings, Label Runs, Label Hits, Label LeftOnBase, Match match, Team team)
        {
            firstInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb1stInning.Text)).Sum(atBat => atBat.RBI).ToString();
            secondInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb2ndInning.Text)).Sum(atBat => atBat.RBI).ToString();
            thirdInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb3rdInning.Text)).Sum(atBat => atBat.RBI).ToString();
            fourthInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb4thInning.Text)).Sum(atBat => atBat.RBI).ToString();
            fifthInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb5thInning.Text)).Sum(atBat => atBat.RBI).ToString();
            sixthInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb6thInning.Text)).Sum(atBat => atBat.RBI).ToString();
            seventhInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb7thInning.Text)).Sum(atBat => atBat.RBI).ToString();
            eigthInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb8thInning.Text)).Sum(atBat => atBat.RBI).ToString();
            ninthInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb9thInning.Text)).Sum(atBat => atBat.RBI).ToString();

            var LeftOnFirstBase = match.GameSituations.Count(gs => gs.Outs == 3 && gs.Offense.TeamAbbreviation == team.TeamAbbreviation && gs.RunnerOnFirst.IsBaseNotEmpty);
            var LeftOnSecondBase = match.GameSituations.Count(gs => gs.Outs == 3 && gs.Offense.TeamAbbreviation == team.TeamAbbreviation && gs.RunnerOnSecond.IsBaseNotEmpty);
            var LeftOnThirdBase = match.GameSituations.Count(gs => gs.Outs == 3 && gs.Offense.TeamAbbreviation == team.TeamAbbreviation && gs.RunnerOnThird.IsBaseNotEmpty);

            LeftOnBase.Text = (LeftOnFirstBase + LeftOnSecondBase + LeftOnThirdBase).ToString();

            var displayingCriterion = team == match.AwayTeam ? match.GameSituations.Last().Offense == match.AwayTeam || match.GameSituations.Last().Offense == match.HomeTeam : match.GameSituations.Last().Offense == match.HomeTeam;

            firstInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb1stInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb1stInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            secondInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb2ndInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb2ndInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            thirdInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb3rdInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb3rdInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            fourthInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb4thInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb4thInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            fifthInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb5thInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb5thInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            sixthInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb6thInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb6thInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            seventhInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb7thInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb7thInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            eigthInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb8thInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb8thInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            ninthInning.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb9thInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb9thInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            extraInnings.ForeColor = match.GameSituations.Last().InningNumber > int.Parse(lb10thInning.Text) || match.GameSituations.Last().InningNumber == int.Parse(lb10thInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);

            Runs.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation).Sum(atBat => atBat.RBI).ToString();
            Hits.Text = match.AtBats.Count(atBat => atBat.Offense == team.TeamAbbreviation && atBat.AtBatType is AtBatType.Single or AtBatType.Double or AtBatType.Triple or AtBatType.HomeRun).ToString();
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

            _teamsBL.UpdateTeamBalance(_endedMatch.AwayTeam, _endedMatch);
            _teamsBL.UpdateTeamBalance(_endedMatch.HomeTeam, _endedMatch);

            GetInformationAboutTeam(_endedMatch.AwayTeam, lbAwayTeamAbbreviation, AwayTeamSmallLogo, lbAwayBalance, pbAwayLogo_border, pbAwayLogo);
            GetInformationAboutTeam(_endedMatch.HomeTeam, lbHomeTeamAbbreviation, HomeTeamSmallLogo, lbHomeBalance, pbHomeLogo_border, pbHomeLogo);

            lbAwayRuns.Text = _endedMatch.GameSituations.Last().AwayTeamRuns.ToString();
            lbHomeRuns.Text = _endedMatch.GameSituations.Last().HomeTeamRuns.ToString();

            UpdateScoreboard(away1, away2, away3, away4, away5, away6, away7, away8, away9, away10, awayRuns, awayHits, awayLOB, _endedMatch, _endedMatch.AwayTeam);
            UpdateScoreboard(home1, home2, home3, home4, home5, home6, home7, home8, home9, home10, homeRuns, homeHits, homeLOB, _endedMatch, _endedMatch.HomeTeam);

            MatchResultForPitcherAnalysis(_endedMatch, _endedMatch.AwayTeam);
            MatchResultForPitcherAnalysis(_endedMatch, _endedMatch.HomeTeam);
        }

        private void GetInformationAboutTeam(Team team, Label abbreviation, Panel panelSmallLogo, Label Balance, Panel panelBorder, Panel BigLogo)
        {
            abbreviation.BackColor = team.TeamColorForThisMatch;
            abbreviation.Text = team.TeamAbbreviation.ToUpper();
            panelSmallLogo.BackgroundImage = ImageHelper.ShowImageIfExists($"SmallTeamLogos/{team.TeamAbbreviation}.png");
            Balance.Visible = !_endedMatch.IsQuickMatch;
            Balance.Text = $"{team.Wins}-{team.Losses}";
            Balance.ForeColor = team.TeamColorForThisMatch;
            BigLogo.BackgroundImage = ImageHelper.ShowImageIfExists($"TeamLogoForMenu/{team.TeamAbbreviation}.png");
            BigLogo.BackColor = Color.FromArgb((int)(team.TeamColorForThisMatch.R * 0.85), (int)(team.TeamColorForThisMatch.G * 0.85), (int)(team.TeamColorForThisMatch.B * 0.85));
            panelBorder.BackColor = Color.FromArgb((int)(team.TeamColorForThisMatch.R * 0.85), (int)(team.TeamColorForThisMatch.G * 0.85), (int)(team.TeamColorForThisMatch.B * 0.85));
        }

        private void MatchResultForPitcherAnalysis(Match endedMatch, Team awayTeam)
        {
            var winningTeam = endedMatch.GameSituations.Last().AwayTeamRuns > endedMatch.GameSituations.Last().HomeTeamRuns ? endedMatch.AwayTeam : endedMatch.HomeTeam;

            var results = awayTeam.PitchersPlayedInMatch.Select(pitcher => new PitcherResults
            {
                PitcherId = pitcher.Id,
                MatchId = endedMatch.Id
            }).ToList();

            var runsForThisPitcher = endedMatch.AtBats.Count(atBat => atBat.AtBatType == AtBatType.Run && atBat.PitcherId == awayTeam.PitchersPlayedInMatch[0].Id);
            var outsPlayedForThisTeam = endedMatch.AtBats.Where(atBat => atBat.Defense == awayTeam.TeamAbbreviation).Sum(atBat => atBat.Outs);
            var outsPlayedForThisPitcher = endedMatch.AtBats.Where(atBat => atBat.PitcherId == awayTeam.PitchersPlayedInMatch[0].Id).Sum(atBat => atBat.Outs);

            results[0].IsQualityStart = runsForThisPitcher <= 3 && outsPlayedForThisPitcher / 3 >= 6;
            results[0].IsCompleteGame = outsPlayedForThisPitcher == outsPlayedForThisTeam;
            results[0].IsShutout = results[0].IsCompleteGame && runsForThisPitcher == 0;

            if (awayTeam.PitchersPlayedInMatch.Count == 1)
            {
                results[0].MatchResultId = awayTeam.TeamAbbreviation == winningTeam.TeamAbbreviation ? PitcherResultEnum.Win : PitcherResultEnum.Loss;

                if (awayTeam.TeamAbbreviation == winningTeam.TeamAbbreviation)
                {
                    WinningPitcher.Text = $"{awayTeam.PitchersPlayedInMatch[0].FullName} ({awayTeam.PitchersPlayedInMatch[0].PitchingStats.Wins + 1} - {awayTeam.PitchersPlayedInMatch[0].PitchingStats.Losses})";
                    WinningPitcher.BackColor = awayTeam.TeamColorForThisMatch;
                    PitcherWithSave.Text = "-";
                    PitcherWithSave.BackColor = awayTeam.TeamColorForThisMatch;
                }
                else
                {
                    LosingPitcher.Text = $"{awayTeam.PitchersPlayedInMatch[0].FullName} ({awayTeam.PitchersPlayedInMatch[0].PitchingStats.Wins} - {awayTeam.PitchersPlayedInMatch[0].PitchingStats.Losses + 1})";
                    LosingPitcher.BackColor = awayTeam.TeamColorForThisMatch;
                }
            }
            else
            {
                var leadersAfterEachAtBat = endedMatch.GetMatchLeaderAfterEachPitch();
                var winningPitchId = Array.FindLastIndex(leadersAfterEachAtBat.ToArray(), leader => leader != winningTeam.TeamAbbreviation);
                var winningPitch = endedMatch.GameSituations[winningPitchId + 1];
                var losingPitcherId = winningPitch.PitcherID;

                if (awayTeam.TeamAbbreviation == winningTeam.TeamAbbreviation)
                {
                    var inningNumber = winningPitch.InningNumber;
                    var winningPitcherId = endedMatch.GameSituations.First(gs => gs.InningNumber == inningNumber && gs.Offense.TeamAbbreviation != awayTeam.TeamAbbreviation && gs.Id > 0).PitcherID;
                    var winningPitcherIndex = awayTeam.PitchersPlayedInMatch.IndexOf(awayTeam.PitchersPlayedInMatch.First(pitcher => pitcher.Id == winningPitcherId));

                    if (winningPitcherIndex != -1)
                    {
                        for (var i = 0; i < winningPitcherIndex; i++)
                            results[i].MatchResultId = PitcherResultEnum.NoDecision;

                        results[winningPitcherIndex].MatchResultId = PitcherResultEnum.Win;
                        WinningPitcher.Text = $"{awayTeam.PitchersPlayedInMatch[winningPitcherIndex].FullName} ({awayTeam.PitchersPlayedInMatch[winningPitcherIndex].PitchingStats.Wins + 1} - {awayTeam.PitchersPlayedInMatch[0].PitchingStats.Losses})";
                        WinningPitcher.BackColor = awayTeam.TeamColorForThisMatch;

                        if (winningPitcherIndex < awayTeam.PitchersPlayedInMatch.Count - 1)
                        {
                            results[awayTeam.PitchersPlayedInMatch.Count - 1].MatchResultId = PitcherResultEnum.Save;
                            PitcherWithSave.Text = $"{awayTeam.PitchersPlayedInMatch[awayTeam.PitchersPlayedInMatch.Count - 1].FullName} ({awayTeam.PitchersPlayedInMatch[awayTeam.PitchersPlayedInMatch.Count - 1].PitchingStats.Saves + 1})";
                        }
                        else PitcherWithSave.Text = "-";

                        PitcherWithSave.BackColor = awayTeam.TeamColorForThisMatch;

                        for (var i = winningPitcherIndex + 1; i < awayTeam.PitchersPlayedInMatch.Count - 1; i++)
                            results[i].MatchResultId = PitcherResultEnum.Hold;
                    }
                }
                else if (awayTeam.PitchersPlayedInMatch.Contains(awayTeam.PitchersPlayedInMatch.First(pitcher => pitcher.Id == losingPitcherId)))
                {
                    var losingPitcherIndex = awayTeam.PitchersPlayedInMatch.IndexOf(awayTeam.PitchersPlayedInMatch.First(pitcher => pitcher.Id == losingPitcherId));
                    results[losingPitcherIndex].MatchResultId = PitcherResultEnum.Loss;
                    LosingPitcher.Text = $"{awayTeam.PitchersPlayedInMatch[losingPitcherIndex].FullName} ({awayTeam.PitchersPlayedInMatch[losingPitcherIndex].PitchingStats.Wins} - {awayTeam.PitchersPlayedInMatch[losingPitcherIndex].PitchingStats.Losses + 1})";
                    LosingPitcher.BackColor = awayTeam.TeamColorForThisMatch;

                    for (var i = 0; i < awayTeam.PitchersPlayedInMatch.Count; i++)
                        if (i != losingPitcherIndex) 
                            results[i].MatchResultId = PitcherResultEnum.NoDecision;
                }
            }
            
            for (var j = 0; j < awayTeam.PitchersPlayedInMatch.Count; j++)
                _matchBL.AddMatchResultForThisPitcher(results[j]);
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