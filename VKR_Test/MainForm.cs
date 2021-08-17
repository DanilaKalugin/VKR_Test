using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Entities;
using VKR.BLL;

namespace VKR_Test
{
    public partial class MainForm : Form
    {
        int runs;
        public Match currentMatch;
        GameSituation newGameSituation;
        GameSituation previousSituation;
        private readonly TeamsBL teamsBL;
        private readonly MatchBL matchBL;
        private readonly PlayerBL playerBL;
        public bool DeleteThisMatch;
        private bool IsAutoSimulation;

        public MainForm(Match match)
        {
            InitializeComponent();
            teamsBL = new TeamsBL();
            matchBL = new MatchBL();
            playerBL = new PlayerBL();
            currentMatch = match;
            IsAutoSimulation = false;
            StartingLineupForm lineup = new StartingLineupForm(currentMatch.AwayTeam);
            lineup.ShowDialog();
            previousSituation = currentMatch.gameSituations.Last();
            newGameSituation = new GameSituation(match.AwayTeam);

            PrepareForThisTeam(match.AwayTeam, AwayTeam_Abbreviation, AwayTeam_RunsScored, label18, panel11, label22, currentMatch, AwayTeamNextBatters, away_DueUP);
            PrepareForThisTeam(match.HomeTeam, HomeTeam_Abbreviation, HomeTeam_RunsScored, label19, panel12, label23, currentMatch, homeTeamNextBatters, home_DueUP);
            DisplayingCurrentSituation(match.gameSituations.Last());

            DisplayNextBatters(AwayNext1, AwayNext2, AwayNext3, AwayNextNumber1, AwayNextNumber2, AwayNextNumber3, currentMatch, currentMatch.AwayTeam, AwayNext1Stats, AwayNext2Stats, AwayNext3Stats, currentMatch.gameSituations.Last());
            DisplayNextBatters(homeNext1, homeNext2, homeNext3, homeNextNumber1, homeNextNumber2, homeNextNumber3, currentMatch, currentMatch.HomeTeam, HomeNext1Stats, HomeNext2Stats, HomeNext3Stats, currentMatch.gameSituations.Last());
        }

        private void PrepareForThisTeam(Team team, Label teamAbbreviation, Label RunsScored, Label teamTitle, Panel TeamLogo, Label teamBalance, Match match, Panel NextBatters, Label NextBattersHeader)
        {
            teamAbbreviation.Text = team.TeamAbbreviation;
            teamAbbreviation.BackColor = team.TeamColorForThisMatch;
            RunsScored.BackColor = Color.FromArgb((int)(team.TeamColorForThisMatch.R * 0.9), (int)(team.TeamColorForThisMatch.G * 0.9), (int)(team.TeamColorForThisMatch.B * 0.9));
            teamTitle.Text = team.TeamTitle.ToUpper();
            teamTitle.BackColor = team.TeamColorForThisMatch;
            TeamLogo.BackgroundImage = Image.FromFile($"SmallTeamLogos/{team.TeamAbbreviation}.png");
            teamBalance.Text = $"{team.Wins}-{team.Losses}";
            teamBalance.BackColor = team.TeamColorForThisMatch;
            teamBalance.Visible = !match.IsQuickMatch;
            NextBatters.BackColor = team.TeamColorForThisMatch;
            NextBattersHeader.Text = $"{team.TeamTitle.ToUpper()} - DUE UP";
        }

        private void DisplayNextBatters(Label awayNext1, Label awayNext2, Label awayNext3, Label awayNextNumber1, Label awayNextNumber2, Label awayNextNumber3, Match currentMatch, Team team, Label Next1Stats, Label Next2Stats, Label Next3Stats, GameSituation situation)
        {
            int Number;
            if (currentMatch.AwayTeam == team)
            {
                Number = situation.BatterNumber_AwayTeam;
            }
            else
            {
                Number = situation.BatterNumber_HomeTeam;
            }

            if (situation.offense != team)
            {
                Number--;
            }

            if (Number <= 6)
            {
                awayNextNumber1.Text = (Number + 1).ToString() + ".";
                awayNextNumber2.Text = (Number + 2).ToString() + ".";
                awayNextNumber3.Text = (Number + 3).ToString() + ".";
            }
            else if (Number <= 7)
            {
                awayNextNumber1.Text = (Number + 1).ToString() + ".";
                awayNextNumber2.Text = (Number + 2).ToString() + ".";
                awayNextNumber3.Text = 1.ToString() + ".";
            }
            else if (Number <= 8)
            {
                awayNextNumber1.Text = (Number + 1).ToString() + ".";
                awayNextNumber2.Text = 1.ToString() + ".";
                awayNextNumber3.Text = 2.ToString() + ".";
            }
            else
            {
                awayNextNumber1.Text = 1.ToString() + ".";
                awayNextNumber2.Text = 2.ToString() + ".";
                awayNextNumber3.Text = 3.ToString() + ".";
            }

            awayNext1.Text = team.BattingLineup[int.Parse(awayNextNumber1.Text[0].ToString()) - 1].SecondName;
            awayNext2.Text = team.BattingLineup[int.Parse(awayNextNumber2.Text[0].ToString()) - 1].SecondName;
            awayNext3.Text = team.BattingLineup[int.Parse(awayNextNumber3.Text[0].ToString()) - 1].SecondName;

            ShowBatterStats(team.BattingLineup[int.Parse(awayNextNumber1.Text[0].ToString()) - 1], Next1Stats);
            ShowBatterStats(team.BattingLineup[int.Parse(awayNextNumber2.Text[0].ToString()) - 1], Next2Stats);
            ShowBatterStats(team.BattingLineup[int.Parse(awayNextNumber3.Text[0].ToString()) - 1], Next3Stats);
        }

        private void DisplayingCurrentSituation(GameSituation gameSituation)
        {
            if (gameSituation.offense == currentMatch.AwayTeam)
            {
                label1.Text = "▲";
            }
            else
            {
                label1.Text = "▼";
            }
            label2.Text = gameSituation.inningNumber.ToString();
            label3.Text = gameSituation.outs.ToString();
            label4.Text = gameSituation.outs <= 1 ? "Out" : "Outs";
            label5.Text = $"{gameSituation.balls}-{gameSituation.strikes}";
            lbPitcherSecondName.Text = gameSituation.offense == currentMatch.AwayTeam ? currentMatch.HomeTeam.CurrentPitcher.SecondName : currentMatch.AwayTeam.CurrentPitcher.SecondName;
            Pitcher CurrentPitcher = gameSituation.offense.TeamAbbreviation == currentMatch.AwayTeam.TeamAbbreviation ? currentMatch.HomeTeam.CurrentPitcher : currentMatch.AwayTeam.CurrentPitcher;

            lbPitchCountForThisPitcher.Text = currentMatch.gameSituations.Where(situation => situation.PitcherID == CurrentPitcher.id &&
                                                                                               !(situation.result == Pitch.PitchResult.CaughtStealingOnSecond || situation.result == Pitch.PitchResult.CaughtStealingOnThird ||
                                                                                                 situation.result == Pitch.PitchResult.SecondBaseStolen || situation.result == Pitch.PitchResult.ThirdBaseStolen)).Count().ToString();

            switch (Convert.ToInt32(gameSituation.RunnerOnFirst.IsBaseNotEmpty) + Convert.ToInt32(gameSituation.RunnerOnSecond.IsBaseNotEmpty) * 2 + Convert.ToInt32(gameSituation.RunnerOnThird.IsBaseNotEmpty) * 4)
            {
                case 0:
                    {
                        panel3.BackgroundImage = Properties.Resources._000;
                        break;
                    }
                case 1:
                    {
                        panel3.BackgroundImage = Properties.Resources._100;
                        break;
                    }
                case 2:
                    {
                        panel3.BackgroundImage = Properties.Resources._020;
                        break;
                    }
                case 3:
                    {
                        panel3.BackgroundImage = Properties.Resources._120;
                        break;
                    }
                case 4:
                    {
                        panel3.BackgroundImage = Properties.Resources._003;
                        break;
                    }
                case 5:
                    {
                        panel3.BackgroundImage = Properties.Resources._103;
                        break;
                    }
                case 6:
                    {
                        panel3.BackgroundImage = Properties.Resources._023;
                        break;
                    }
                case 7:
                    {
                        panel3.BackgroundImage = Properties.Resources._123;
                        break;
                    }
            }
            AwayTeam_RunsScored.Text = gameSituation.AwayTeamRuns.ToString();
            HomeTeam_RunsScored.Text = gameSituation.HomeTeamRuns.ToString();

            panelCurrentBatter.Visible = gameSituation.strikes == 0 && gameSituation.balls == 0;

            panel8.BackColor = gameSituation.offense.TeamColorForThisMatch;
            btnChangeBatter.BackColor = Color.FromArgb((int)(gameSituation.offense.TeamColorForThisMatch.R * 0.9), (int)(gameSituation.offense.TeamColorForThisMatch.G * 0.9), (int)(gameSituation.offense.TeamColorForThisMatch.B * 0.9));

            pbCurrentOffenseLogo.BackgroundImage = Image.FromFile($"SmallTeamLogos/{newGameSituation.offense.TeamAbbreviation}.png");
            Batter NextBatter = GetBatterByGameSituation(gameSituation);
            NewBatterDisplaying(NextBatter);
            DisplayNextBatters(AwayNext1, AwayNext2, AwayNext3, AwayNextNumber1, AwayNextNumber2, AwayNextNumber3, currentMatch, currentMatch.AwayTeam, AwayNext1Stats, AwayNext2Stats, AwayNext3Stats, gameSituation);
            DisplayNextBatters(homeNext1, homeNext2, homeNext3, homeNextNumber1, homeNextNumber2, homeNextNumber3, currentMatch, currentMatch.HomeTeam, HomeNext1Stats, HomeNext2Stats, HomeNext3Stats, gameSituation);
            DisplayPitcherStats();
            Text = $"{currentMatch.AwayTeam.TeamAbbreviation} {gameSituation.AwayTeamRuns} - {gameSituation.HomeTeamRuns} {currentMatch.HomeTeam.TeamAbbreviation} @ {currentMatch.stadium.StadiumTitle}";
            lb_Runner1_Name.ForeColor = Color.Gainsboro;
            lb_Runner2_Name.ForeColor = Color.Gainsboro;

            lb9thInning.Text = gameSituation.inningNumber <= 9 ? 9.ToString() : gameSituation.inningNumber.ToString();
            lb8thInning.Text = (int.Parse(lb9thInning.Text) - 1).ToString();
            lb7thInning.Text = (int.Parse(lb8thInning.Text) - 1).ToString();
            lb6thInning.Text = (int.Parse(lb7thInning.Text) - 1).ToString();
            lb5thInning.Text = (int.Parse(lb6thInning.Text) - 1).ToString();
            lb4thInning.Text = (int.Parse(lb5thInning.Text) - 1).ToString();
            lb3rdInning.Text = (int.Parse(lb4thInning.Text) - 1).ToString();
            lb2ndInning.Text = (int.Parse(lb3rdInning.Text) - 1).ToString();
            lb1stInning.Text = (int.Parse(lb2ndInning.Text) - 1).ToString();

            UpdateScoreboard(away2, away3, away4, away5, away6, away7, away8, away9, away10, awayRuns, awayHits, currentMatch, currentMatch.AwayTeam);
            UpdateScoreboard(home2, home3, home4, home5, home6, home7, home8, home9, home10, homeRuns, homeHits, currentMatch, currentMatch.HomeTeam);
        }

        public void DisplayCurrentRunners(GameSituation situation)
        {
            panel1Base.Visible = situation.RunnerOnFirst.IsBaseNotEmpty;
            panel2Base.Visible = situation.RunnerOnSecond.IsBaseNotEmpty;
            panel3Base.Visible = situation.RunnerOnThird.IsBaseNotEmpty;

            lb1stBase.BackColor = situation.offense.TeamColorForThisMatch;
            lb2ndBase.BackColor = situation.offense.TeamColorForThisMatch;
            lb3rdBase.BackColor = situation.offense.TeamColorForThisMatch;

            if (situation.RunnerOnFirst.IsBaseNotEmpty)
            {
                Batter runneron1St = situation.offense.BattingLineup.Where(Batter => Batter.id == situation.RunnerOnFirst.runnerID).First();
                lb_Runner1_Name.Text = runneron1St.FullName.ToUpper();
                if (File.Exists($"PlayerPhotos/Player{situation.RunnerOnFirst.runnerID:0000}.png"))
                {
                    RunnerOn1Photo.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{situation.RunnerOnFirst.runnerID:0000}.png");
                }
                else RunnerOn1Photo.BackgroundImage = null;
            }
            else RunnerOn1Photo.BackgroundImage = null;

            if (situation.RunnerOnSecond.IsBaseNotEmpty)
            {
                Batter runneron2nd = situation.offense.BattingLineup.Where(Batter => Batter.id == situation.RunnerOnSecond.runnerID).First();
                lb_Runner2_Name.Text = runneron2nd.FullName.ToUpper();
                if (File.Exists($"PlayerPhotos/Player{situation.RunnerOnSecond.runnerID:0000}.png"))
                {
                    RunnerOn2Photo.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{situation.RunnerOnSecond.runnerID:0000}.png");
                }
                else RunnerOn2Photo.BackgroundImage = null;
            }
            else RunnerOn2Photo.BackgroundImage = null;

            if (situation.RunnerOnThird.IsBaseNotEmpty)
            {
                Batter runneron3rd = situation.offense.BattingLineup.Where(Batter => Batter.id == situation.RunnerOnThird.runnerID).First();
                lb_Runner3_Name.Text = runneron3rd.FullName.ToUpper();
                if (File.Exists($"PlayerPhotos/Player{situation.RunnerOnThird.runnerID:0000}.png"))
                {
                    RunnerOn3Photo.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{situation.RunnerOnThird.runnerID:0000}.png");
                }
                else RunnerOn3Photo.BackgroundImage = null;
            }
            else RunnerOn3Photo.BackgroundImage = null;
        }

        private Batter GetBatterByGameSituation(GameSituation gameSituation)
        {
            if (gameSituation.offense == currentMatch.AwayTeam)
            {
                return currentMatch.AwayTeam.BattingLineup[gameSituation.BatterNumber_AwayTeam - 1];
            }
            else
            {
                return currentMatch.HomeTeam.BattingLineup[gameSituation.BatterNumber_HomeTeam - 1];
            }
        }

        private void ShowBatterStats(Batter batter, Label BatterStats)
        {
            if (currentMatch.atBats.Where(atBat => atBat.Batter == batter.id && (atBat.AtBatResult == AtBat.AtBatType.Double ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Triple ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.HomeRun ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Single ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Popout ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Strikeout ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Flyout ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Groundout)).Count() > 0)
            {
                int Hits = currentMatch.atBats.Where(atBat => atBat.Batter == batter.id && (atBat.AtBatResult == AtBat.AtBatType.Double ||
                                                                               atBat.AtBatResult == AtBat.AtBatType.Triple ||
                                                                               atBat.AtBatResult == AtBat.AtBatType.HomeRun ||
                                                                               atBat.AtBatResult == AtBat.AtBatType.Single)).Count();
                int AtBats = currentMatch.atBats.Where(atBat => atBat.Batter == batter.id && (atBat.AtBatResult == AtBat.AtBatType.Double ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Triple ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.HomeRun ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Single ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Popout ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Strikeout ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Flyout ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Groundout)).Count();
                BatterStats.Text = Hits + " FOR " + AtBats;
            }
            else if (currentMatch.atBats.Where(atBat => atBat.Batter == batter.id && (atBat.AtBatResult == AtBat.AtBatType.HitByPitch)).Count() > 0)
            {
                BatterStats.Text = "HBP";
            }
            else if (currentMatch.atBats.Where(atBat => atBat.Batter == batter.id && atBat.AtBatResult == AtBat.AtBatType.Walk).Count() > 0)
            {
                if (currentMatch.atBats.Where(atBat => atBat.Batter == batter.id && atBat.AtBatResult == AtBat.AtBatType.Walk).Count() == 1)
                {
                    BatterStats.Text = "WALK";
                }
                else
                {
                    BatterStats.Text = $"{currentMatch.atBats.Where(atBat => atBat.Batter == batter.id && atBat.AtBatResult == AtBat.AtBatType.Walk).Count()} WALKS";
                }
            }
            else if (currentMatch.atBats.Where(atBat => atBat.Batter == batter.id && atBat.AtBatResult == AtBat.AtBatType.SacrificeFly).Count() > 0)
            {
                BatterStats.Text = "SAC FLY";
            }
            else
            {
                BatterStats.Text = batter.AVG.ToString("#.000", new CultureInfo("en-US"));
            }
        }

        private void NewBatterDisplaying(Batter batter)
        {
            lbBatterNumber.Text = batter.NumberInBattingLineup.ToString() + ".";
            lbBatterSecondName.Text = batter.SecondName;

            ShowBatterStats(batter, BatterStats);
            ShowStatsForThisMatch(batter, lbTodayStats);

            if (File.Exists($"PlayerPhotos/Player{batter.id:0000}.png"))
            {
                pbCurrentBatterPhoto.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{batter.id:0000}.png");
            }
            else
            {
                pbCurrentBatterPhoto.BackgroundImage = null;
            }
            lblPlayerPosition.Text = batter.PositionForThisMatch;
            lblPlayerNumber.Text = batter.PlayerNumber.ToString();
            lblPlayerName.Text = batter.FullName.ToUpper();
            label6.Text = batter.AVG.ToString("#.000", new CultureInfo("en-US"));
            label9.Text = batter.HomeRuns.ToString("N0", CultureInfo.InvariantCulture);
            label11.Text = batter.RBI.ToString("N0", CultureInfo.InvariantCulture);
            label13.Text = batter.StolenBases.ToString("N0", CultureInfo.InvariantCulture);
            label15.Text = batter.Runs.ToString("N0", CultureInfo.InvariantCulture);
            label17.Text = batter.OPS.ToString("#.000", new CultureInfo("en-US"));
        }

        private void ShowStatsForThisMatch(Batter batter, Label lbTodayStats)
        {
            List<AtBat> atBatsForThisBatter = currentMatch.atBats.Where(atBat => atBat.Batter == batter.id).ToList();
            int Hits = atBatsForThisBatter.Where(atBat => atBat.AtBatResult == AtBat.AtBatType.Double ||
                                                                               atBat.AtBatResult == AtBat.AtBatType.Triple ||
                                                                               atBat.AtBatResult == AtBat.AtBatType.HomeRun ||
                                                                               atBat.AtBatResult == AtBat.AtBatType.Single).Count();
            int AtBats = atBatsForThisBatter.Where(atBat => atBat.AtBatResult == AtBat.AtBatType.Double ||
                                                                          atBat.AtBatResult == AtBat.AtBatType.Triple ||
                                                                          atBat.AtBatResult == AtBat.AtBatType.HomeRun ||
                                                                          atBat.AtBatResult == AtBat.AtBatType.Single ||
                                                                          atBat.AtBatResult == AtBat.AtBatType.Popout ||
                                                                          atBat.AtBatResult == AtBat.AtBatType.Strikeout ||
                                                                          atBat.AtBatResult == AtBat.AtBatType.Flyout ||
                                                                          atBat.AtBatResult == AtBat.AtBatType.Groundout).Count();
            int HBPs = atBatsForThisBatter.Where(atBat => atBat.AtBatResult == AtBat.AtBatType.HitByPitch).Count();
            int BBs = atBatsForThisBatter.Where(atBat => atBat.AtBatResult == AtBat.AtBatType.Walk).Count();
            int SFs = atBatsForThisBatter.Where(atBat => atBat.AtBatResult == AtBat.AtBatType.SacrificeFly).Count();
            int SACs = atBatsForThisBatter.Where(atBat => atBat.AtBatResult == AtBat.AtBatType.SacrificeBunt).Count();
            int Rs = atBatsForThisBatter.Where(atBat => atBat.AtBatResult == AtBat.AtBatType.Run).Count();
            int HRs = atBatsForThisBatter.Where(atBat => atBat.AtBatResult == AtBat.AtBatType.HomeRun).Count();
            int Ks = atBatsForThisBatter.Where(atBat => atBat.AtBatResult == AtBat.AtBatType.Strikeout).Count();
            int RBIs = atBatsForThisBatter.Sum(atBat => atBat.RBI);
            int SBs = atBatsForThisBatter.Where(atBat => atBat.AtBatResult == AtBat.AtBatType.StolenBase).Count();
            lbTodayStats.Text = "►TODAY: ";

            if (AtBats > 0)
            {
                lbTodayStats.Text += $"{Hits} for {AtBats}";
            }
            AddNewStatsForTodayStatsLabel(HRs, "HR", lbTodayStats);
            AddNewStatsForTodayStatsLabel(RBIs, "RBI", lbTodayStats);
            AddNewStatsForTodayStatsLabel(Rs, "R", lbTodayStats);
            AddNewStatsForTodayStatsLabel(SBs, "SB", lbTodayStats);
            AddNewStatsForTodayStatsLabel(HBPs, "HBP", lbTodayStats);
            AddNewStatsForTodayStatsLabel(BBs, "BB", lbTodayStats);
            AddNewStatsForTodayStatsLabel(SFs, "SF", lbTodayStats);
            AddNewStatsForTodayStatsLabel(SACs, "SAC", lbTodayStats);
            AddNewStatsForTodayStatsLabel(Ks, "SO", lbTodayStats);
            lbTodayStats.Visible = lbTodayStats.Text != "►TODAY: " && panelCurrentBatter.Visible;

            panelCurrentBatter.Height = lbTodayStats.Text != "►TODAY: " ? 110 : 140;
            pbCurrentOffenseLogo.Width = lbTodayStats.Text != "►TODAY: " ? 110 : 140;
            pbCurrentOffenseLogo.Height = lbTodayStats.Text != "►TODAY: " ? 110 : 140;
            pbCurrentOffenseLogo.Left = lbTodayStats.Text != "►TODAY: " ? 88 : 58;
        }

        private void AddNewStatsForTodayStatsLabel(int value, string text, Label lb)
        {
            if (value > 0)
            {
                string valueWithText;
                if (value > 1)
                {
                    valueWithText = $"{value} {text}";
                }
                else
                {
                    valueWithText = $"{text}";
                }

                if (lb.Text == "►TODAY: ")
                {
                    lb.Text += $"{valueWithText}";
                }
                else
                {
                    lb.Text += $", {valueWithText}";
                }
            }
        }

        private void IsHomeRun(Pitch pitch, int runs)
        {
            if (pitch.pitchResult == Pitch.PitchResult.HomeRun)
            {
                timer1.Stop();
                string title;
                if (runs == 1)
                {
                    title = "Solo home run";
                }
                else if (runs == 4)
                {
                    title = "Grand Slam";
                }
                else
                {
                    title = $"{runs}-run Home Run";
                }
                if (newGameSituation.inningNumber >= 9 && newGameSituation.offense == currentMatch.HomeTeam && newGameSituation.AwayTeamRuns < newGameSituation.HomeTeamRuns)
                {
                    title = "Walk-off " + title.ToLower();
                }
                HomeRunCelebrationForm hr = new HomeRunCelebrationForm(newGameSituation.offense, title, GetBatterByGameSituation(newGameSituation), currentMatch.atBats, currentMatch.IsQuickMatch);
                hr.ShowDialog();
                if (IsAutoSimulation)
                {
                    timer1.Start();
                }
            }
        }

        private void GetCurrentStatsForThisMatch()
        {
            currentMatch.AwayTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(currentMatch.AwayTeam.TeamAbbreviation, currentMatch.MatchID);
            currentMatch.HomeTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(currentMatch.HomeTeam.TeamAbbreviation, currentMatch.MatchID);

            teamsBL.UpdateStatsForThisPitcher(currentMatch.AwayTeam.CurrentPitcher, currentMatch);
            teamsBL.UpdateStatsForThisPitcher(currentMatch.HomeTeam.CurrentPitcher, currentMatch);

            UpdateScoreboard(away2, away3, away4, away5, away6, away7, away8, away9, away10, awayRuns, awayHits, currentMatch, currentMatch.AwayTeam);
            UpdateScoreboard(home2, home3, home4, home5, home6, home7, home8, home9, home10, homeRuns, homeHits, currentMatch, currentMatch.HomeTeam);
        }


        private void AddnewGameSituation(Pitch pitch)
        {
            newGameSituation.id = previousSituation.id + 1;
            newGameSituation.result = pitch.pitchResult;
            newGameSituation.balls = newGameSituation.NumberOfBallsDetrmining(newGameSituation.result, previousSituation);
            newGameSituation.strikes = newGameSituation.NumberOfStrikesDetermining(newGameSituation.result, previousSituation);
            newGameSituation.outs = newGameSituation.NumberOfOutsDetermining(newGameSituation.result, previousSituation, newGameSituation.strikes);
            newGameSituation.RunnerOnFirst = newGameSituation.HavingARunnerOnFirstBase(newGameSituation.result, previousSituation, currentMatch, newGameSituation.balls);
            newGameSituation.RunnerOnSecond = newGameSituation.HavingARunnerOnSecondBase(newGameSituation.result, previousSituation, currentMatch, newGameSituation.balls);
            newGameSituation.RunnerOnThird = newGameSituation.HavingARunnerOnThirdBase(newGameSituation.result, previousSituation, currentMatch, newGameSituation.balls);
            runs = newGameSituation.NumberOfRunsScoredForLastPitch(newGameSituation.result, previousSituation, newGameSituation.balls);
            newGameSituation.RunsByThisPitch = newGameSituation.GetListOfRunnersInHomeByThisPitch(newGameSituation.result, previousSituation, newGameSituation.balls, currentMatch);
            newGameSituation.PitcherID = newGameSituation.offense == currentMatch.AwayTeam ? currentMatch.HomeTeam.CurrentPitcher.id : currentMatch.AwayTeam.CurrentPitcher.id;
            if (newGameSituation.offense == currentMatch.AwayTeam)
            {
                newGameSituation.AwayTeamRuns += runs;
            }
            else
            {
                newGameSituation.HomeTeamRuns += runs;
            }
            currentMatch.gameSituations.Add(new GameSituation(newGameSituation.id, newGameSituation.inningNumber, newGameSituation.offense, newGameSituation.result, newGameSituation.balls, newGameSituation.strikes, newGameSituation.outs, newGameSituation.RunnerOnFirst, newGameSituation.RunnerOnSecond, newGameSituation.RunnerOnThird, newGameSituation.AwayTeamRuns, newGameSituation.HomeTeamRuns, newGameSituation.BatterNumber_AwayTeam, newGameSituation.BatterNumber_HomeTeam, newGameSituation.PitcherID));
            IsHomeRun(pitch, runs);
            IsAtBatFinished(currentMatch.gameSituations.Last());

            if (newGameSituation.RunsByThisPitch.Count != 0)
            {
                foreach (Runner runner in newGameSituation.RunsByThisPitch)
                {
                    AtBat runForDB = new AtBat(runner, currentMatch);
                    currentMatch.atBats.Add(runForDB);
                    matchBL.AddNewAtBat(runForDB, currentMatch);
                }
                GetCurrentStatsForThisMatch();
            }
            newGameSituation.PrepareForNextPitch(currentMatch.gameSituations.Last(), currentMatch.AwayTeam, currentMatch.HomeTeam, currentMatch.MatchLength);
            if (currentMatch.gameSituations.Last().offense == currentMatch.AwayTeam && currentMatch.gameSituations.Last().outs == 3 && currentMatch.gameSituations.Last().inningNumber == 1)
            {
                timer1.Stop();
                StartingLineupForm form = new StartingLineupForm(currentMatch.HomeTeam);
                form.ShowDialog();
                DisplayPitcherStats();
                if (IsAutoSimulation)
                {
                    timer1.Start();
                }
            }

            DisplayingCurrentSituation(newGameSituation);
            if (newGameSituation.strikes == 0 && newGameSituation.balls == 0)
            {
                DisplayCurrentRunners(newGameSituation);
            }

            IsFinishOfMatch(currentMatch);

            panelLastAtBat.Visible = currentMatch.atBats.Count > 0;

            if (currentMatch.atBats.Count > 0)
            {
                string LastAtBatOffense = currentMatch.atBats.Where(atbat => atbat.AtBatResult != AtBat.AtBatType.Run).Last().Offense;
                label27.BackColor = LastAtBatOffense == currentMatch.AwayTeam.TeamAbbreviation ? currentMatch.AwayTeam.TeamColorForThisMatch : currentMatch.HomeTeam.TeamColorForThisMatch;
                panel15.BackgroundImage = Image.FromFile($"SmallTeamLogos/{LastAtBatOffense}.png");

                if (ClientSize.Width > 1920)
                {
                    label27.Text = playerBL.GetFullPlayerNameByID(currentMatch.atBats.Where(atbat => atbat.AtBatResult != AtBat.AtBatType.Run).Last().Batter);
                }
                else
                {
                    label27.Text = playerBL.GetPlayerNameByID(currentMatch.atBats.Where(atbat => atbat.AtBatResult != AtBat.AtBatType.Run).Last().Batter);
                }
                label44.Text = currentMatch.atBats.Where(atbat => atbat.AtBatResult != AtBat.AtBatType.Run).Last().ToString();
            }

            previousSituation = new GameSituation(newGameSituation.id, newGameSituation.inningNumber, newGameSituation.offense, newGameSituation.result, newGameSituation.balls, newGameSituation.strikes, newGameSituation.outs, newGameSituation.RunnerOnFirst, newGameSituation.RunnerOnSecond, newGameSituation.RunnerOnThird, newGameSituation.AwayTeamRuns, newGameSituation.HomeTeamRuns, newGameSituation.BatterNumber_AwayTeam, newGameSituation.BatterNumber_HomeTeam, newGameSituation.PitcherID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateNewPitch();
        }

        private void BasesStealingAttempt_Definition()
        {
            Pitch.StealingAttempt thirdBaseStealingAttempt, secondBaseStealingAttempt;
            if (newGameSituation.RunnerOnSecond.IsBaseNotEmpty && !newGameSituation.RunnerOnThird.IsBaseNotEmpty)
            {
                thirdBaseStealingAttempt = Pitch.stealingAttempt_Definition(Pitch.BaseNumberForStealing.Third, newGameSituation, currentMatch.AwayTeam);
                if (thirdBaseStealingAttempt == Pitch.StealingAttempt.Attempt)
                {
                    lb_Runner2_Name.ForeColor = Color.DarkGoldenrod;
                    if (newGameSituation.RunnerOnFirst.IsBaseNotEmpty && newGameSituation.RunnerOnSecond.IsBaseNotEmpty)
                    {
                        secondBaseStealingAttempt = Pitch.stealingAttempt_Definition(Pitch.BaseNumberForStealing.Second, newGameSituation, currentMatch.AwayTeam);
                        if (secondBaseStealingAttempt == Pitch.StealingAttempt.Attempt)
                        {
                            lb_Runner1_Name.ForeColor = Color.DarkGoldenrod;
                        }
                    }
                }
            }
            if (newGameSituation.RunnerOnFirst.IsBaseNotEmpty && !newGameSituation.RunnerOnSecond.IsBaseNotEmpty)
            {
                secondBaseStealingAttempt = Pitch.stealingAttempt_Definition(Pitch.BaseNumberForStealing.Second, newGameSituation, currentMatch.AwayTeam);
                if (secondBaseStealingAttempt == Pitch.StealingAttempt.Attempt)
                {
                    lb_Runner1_Name.ForeColor = Color.DarkGoldenrod;
                }
            }
        }

        private void GenerateNewPitch()
        {
            Pitch pitch;
            BasesStealingAttempt_Definition();
            bool StealingAttempt = lb_Runner1_Name.ForeColor == Color.DarkGoldenrod || lb_Runner2_Name.ForeColor == Color.DarkGoldenrod;
            int CountOfAtBats = currentMatch.atBats.Count();
            int TypeOfStealing = 0;
            if (StealingAttempt)
            {
                pitch = new Pitch(newGameSituation, currentMatch.gameSituations, currentMatch.HomeTeam, currentMatch.AwayTeam);
                if (lb_Runner1_Name.ForeColor == Color.DarkGoldenrod)
                {
                    if (lb_Runner2_Name.ForeColor == Color.DarkGoldenrod)
                    {
                        TypeOfStealing = 3;
                    }
                    else
                    {
                        TypeOfStealing = 1;
                    }
                }
                else if (lb_Runner2_Name.ForeColor == Color.DarkGoldenrod)
                {
                    TypeOfStealing = 2;
                }
            }
            else
            {
                pitch = new Pitch(newGameSituation, currentMatch.gameSituations, currentMatch.HomeTeam, currentMatch.AwayTeam, currentMatch.stadium);
            }
            AddnewGameSituation(pitch);
            int NewCountOfAtBats = currentMatch.atBats.Count();
            if (StealingAttempt && CountOfAtBats == NewCountOfAtBats)
            {
                switch (TypeOfStealing)
                {
                    case 1:
                        {
                            Pitch stealingSecondBaseAttempt = new Pitch(newGameSituation, Pitch.StealingType.OnlySecondBase);
                            AddnewGameSituation(stealingSecondBaseAttempt);
                            DisplayCurrentRunners(newGameSituation);
                            break;
                        }
                    case 2:
                        {
                            Pitch stealingThirdBaseAttempt = new Pitch(newGameSituation, Pitch.StealingType.OnlyThirdBase);
                            AddnewGameSituation(stealingThirdBaseAttempt);
                            DisplayCurrentRunners(newGameSituation);
                            break;
                        }
                    case 3:
                        {
                            Pitch stealingThirdBaseAttemptBeforeSecond = new Pitch(newGameSituation, Pitch.StealingType.ThirdBaseBeforeSecond);
                            AddnewGameSituation(stealingThirdBaseAttemptBeforeSecond);
                            DisplayCurrentRunners(newGameSituation);
                            if (currentMatch.gameSituations.Last().outs != 3)
                            {
                                Pitch stealingSecondBaseAfterThird = new Pitch(newGameSituation, Pitch.StealingType.SecondBaseAfterThird);
                                AddnewGameSituation(stealingSecondBaseAfterThird);
                                DisplayCurrentRunners(newGameSituation);
                            }
                            break;
                        }
                }

            }
        }

        private void IsFinishOfMatch(Match currentMatch)
        {
            if ((currentMatch.gameSituations.Last().offense == currentMatch.AwayTeam && currentMatch.gameSituations.Last().outs == 3 && currentMatch.gameSituations.Last().AwayTeamRuns < currentMatch.gameSituations.Last().HomeTeamRuns && currentMatch.gameSituations.Last().inningNumber == currentMatch.MatchLength) ||
                (currentMatch.gameSituations.Last().offense == currentMatch.HomeTeam && currentMatch.gameSituations.Last().outs == 3 && currentMatch.gameSituations.Last().AwayTeamRuns > currentMatch.gameSituations.Last().HomeTeamRuns && currentMatch.gameSituations.Last().inningNumber >= currentMatch.MatchLength) ||
                (currentMatch.gameSituations.Last().offense == currentMatch.HomeTeam && currentMatch.gameSituations.Last().AwayTeamRuns < currentMatch.gameSituations.Last().HomeTeamRuns && currentMatch.gameSituations.Last().inningNumber >= currentMatch.MatchLength))
            {
                MatchEndingForm form = new MatchEndingForm(currentMatch);
                matchBL.FinishMatch(currentMatch);
                timer1.Dispose();
                Visible = false;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    form.Dispose();
                    DialogResult = DialogResult.OK;
                    Hide();
                }
            }
        }

        private void UpdateScoreboard(Label FirstInning, Label SecondInning, Label ThirdInning, Label FourthInning, Label FifthInning, Label SixthInning, Label SeventhInning, Label EigthInning, Label NinthInning, Label Runs, Label Hits, Match match, Team team)
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

            bool DisplayingCriterion = team == currentMatch.AwayTeam ? (newGameSituation.offense == currentMatch.AwayTeam || newGameSituation.offense == currentMatch.HomeTeam) : newGameSituation.offense == currentMatch.HomeTeam;

            FirstInning.ForeColor = newGameSituation.inningNumber > int.Parse(lb1stInning.Text) || newGameSituation.inningNumber == int.Parse(lb1stInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            SecondInning.ForeColor = newGameSituation.inningNumber > int.Parse(lb2ndInning.Text) || newGameSituation.inningNumber == int.Parse(lb2ndInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            ThirdInning.ForeColor = newGameSituation.inningNumber > int.Parse(lb3rdInning.Text) || newGameSituation.inningNumber == int.Parse(lb3rdInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            FourthInning.ForeColor = newGameSituation.inningNumber > int.Parse(lb4thInning.Text) || newGameSituation.inningNumber == int.Parse(lb4thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            FifthInning.ForeColor = newGameSituation.inningNumber > int.Parse(lb5thInning.Text) || newGameSituation.inningNumber == int.Parse(lb5thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            SixthInning.ForeColor = newGameSituation.inningNumber > int.Parse(lb6thInning.Text) || newGameSituation.inningNumber == int.Parse(lb6thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            SeventhInning.ForeColor = newGameSituation.inningNumber > int.Parse(lb7thInning.Text) || newGameSituation.inningNumber == int.Parse(lb7thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            EigthInning.ForeColor = newGameSituation.inningNumber > int.Parse(lb8thInning.Text) || newGameSituation.inningNumber == int.Parse(lb8thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            NinthInning.ForeColor = newGameSituation.inningNumber > int.Parse(lb9thInning.Text) || newGameSituation.inningNumber == int.Parse(lb9thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);

            Runs.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation).Select(atBat => atBat.RBI).Sum().ToString();
            Hits.Text = match.atBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && (atBat.AtBatResult == AtBat.AtBatType.Single || atBat.AtBatResult == AtBat.AtBatType.Double || atBat.AtBatResult == AtBat.AtBatType.Triple || atBat.AtBatResult == AtBat.AtBatType.HomeRun)).Count().ToString();
        }

        private void IsAtBatFinished(GameSituation situation)
        {
            if (situation.result == Pitch.PitchResult.Single ||
                situation.result == Pitch.PitchResult.Double ||
                situation.result == Pitch.PitchResult.Triple ||
                situation.result == Pitch.PitchResult.HomeRun ||
                situation.result == Pitch.PitchResult.HitByPitch ||
                situation.result == Pitch.PitchResult.Popout ||
                situation.result == Pitch.PitchResult.Groundout ||
                situation.result == Pitch.PitchResult.Flyout ||
                situation.result == Pitch.PitchResult.SacrificeFly ||
                situation.result == Pitch.PitchResult.SacrificeBunt ||
                situation.result == Pitch.PitchResult.DoublePlay ||
                situation.result == Pitch.PitchResult.CaughtStealingOnSecond ||
                situation.result == Pitch.PitchResult.CaughtStealingOnThird ||
                situation.result == Pitch.PitchResult.SecondBaseStolen ||
                situation.result == Pitch.PitchResult.ThirdBaseStolen ||
                situation.result == Pitch.PitchResult.GroundRuleDouble ||
                situation.result == Pitch.PitchResult.DoublePlayOnFlyout ||
                (situation.result == Pitch.PitchResult.Ball && situation.balls == 0) ||
                (situation.result == Pitch.PitchResult.Strike && situation.strikes == 0))
            {
                switch (situation.result)
                {
                    case Pitch.PitchResult.SecondBaseStolen:
                        {
                            AtBat atBat = new AtBat(currentMatch, situation.RunnerOnSecond.runnerID, false);
                            currentMatch.atBats.Add(atBat);
                            matchBL.AddNewAtBat(atBat, currentMatch);
                            break;
                        }
                    case Pitch.PitchResult.ThirdBaseStolen:
                        {
                            AtBat atBat = new AtBat(currentMatch, situation.RunnerOnThird.runnerID, true);
                            currentMatch.atBats.Add(atBat);
                            matchBL.AddNewAtBat(atBat, currentMatch);
                            break;
                        }
                    case Pitch.PitchResult.CaughtStealingOnSecond:
                        {
                            AtBat atBat = new AtBat(currentMatch, currentMatch.gameSituations[currentMatch.gameSituations.Count - 2].RunnerOnFirst.runnerID, true);
                            currentMatch.atBats.Add(atBat);
                            matchBL.AddNewAtBat(atBat, currentMatch);
                            break;
                        }
                    case Pitch.PitchResult.CaughtStealingOnThird:
                        {
                            AtBat atBat = new AtBat(currentMatch, currentMatch.gameSituations[currentMatch.gameSituations.Count - 2].RunnerOnSecond.runnerID, true);
                            currentMatch.atBats.Add(atBat);
                            matchBL.AddNewAtBat(atBat, currentMatch);
                            break;
                        }
                    default:
                        {
                            AtBat LastAtBat = new AtBat(currentMatch, runs);
                            currentMatch.atBats.Add(LastAtBat);
                            matchBL.AddNewAtBat(LastAtBat, currentMatch);
                            break;
                        }
                }
                GetCurrentStatsForThisMatch();
            }
        }

        private void DisplayPitcherStats()
        {
            Team Defense = newGameSituation.offense == currentMatch.AwayTeam ? currentMatch.HomeTeam : currentMatch.AwayTeam;

            PitchingTeamColor.BackColor = Defense.TeamColorForThisMatch;
            btnShowAvailablePitchers.BackColor = Defense.TeamColorForThisMatch;
            PitchingTeam.BackgroundImage = Image.FromFile($"SmallTeamLogos/{Defense.TeamAbbreviation}.png");
            if (File.Exists($"PlayerPhotos/Player{Defense.CurrentPitcher.id:0000}.png"))
            {
                PitcherPhoto.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{Defense.CurrentPitcher.id:0000}.png");
            }
            else
            {
                PitcherPhoto.BackgroundImage = null;
            }
            PitcherName.Text = Defense.CurrentPitcher.FullName.ToUpper();

            PitcherGames.Visible = Defense.PitchersPlayedInMatch.Count > 1;
            labelGames.Visible = Defense.PitchersPlayedInMatch.Count > 1;
            PitcherGames.Text = Defense.CurrentPitcher.Games.ToString();
            if (Defense.PitchersPlayedInMatch.Count == 1)
            {
                labelGS.Text = "STARTS";
                PitcherGS.Text = $"{Defense.CurrentPitcher.GamesStarted}";
                labelRecord.Text = "RECORD";
                PitcherRecord.Text = $"{Defense.CurrentPitcher.Wins}-{Defense.CurrentPitcher.Losses}";
            }
            else
            {
                labelGS.Text = "RECORD";
                PitcherGS.Text = $"{Defense.CurrentPitcher.Wins}-{Defense.CurrentPitcher.Losses}";
                labelRecord.Text = "SAVES";
                PitcherRecord.Text = $"{Defense.CurrentPitcher.Saves}";
            }

            PitcherBAA.Text = Defense.CurrentPitcher.BAA.ToString("#.000", new CultureInfo("en-US"));
            PitcherERA.Text = Defense.CurrentPitcher.ERA.ToString("##0.00", new CultureInfo("en-US"));
            PitcherIP.Text = Defense.CurrentPitcher.IP.ToString("0.0", new CultureInfo("en-US"));
            PitcherHomeRuns.Text = Defense.CurrentPitcher.HomeRunsAllowed.ToString();
            PitcherStrikeouts.Text = Defense.CurrentPitcher.Strikeouts.ToString();
            PitcherWalks.Text = Defense.CurrentPitcher.WalksAllowed.ToString();
            PitcherWHIP.Text = Defense.CurrentPitcher.WHIP.ToString("0.00", new CultureInfo("en-US"));

            Defense.CurrentPitcher.OutsPlayedInLast5Days = teamsBL.ReturnNumberOfOutsPlayedByThisPitcherInLast5Days(Defense.CurrentPitcher, currentMatch);

            pb_stamina.MainColor = Defense.CurrentPitcher.OutsPlayedInLast5Days > (16.5 - 1E-5) ? Color.Maroon : Defense.TeamColorForThisMatch;

            if (Defense.CurrentPitcher.OutsPlayedInLast5Days > 18 - 1E-5)
            {
                pb_stamina.Value = 5;
            }
            else
            {
                pb_stamina.Value = 180 - (int)(Defense.CurrentPitcher.OutsPlayedInLast5Days * 10);
            }

            int OutsToday = currentMatch.atBats.Where(atBat => atBat.Pitcher == Defense.CurrentPitcher.id).Select(atBat => atBat.outs).Sum();
            int StrikeoutsToday = currentMatch.atBats.Where(atBat => atBat.Pitcher == Defense.CurrentPitcher.id && atBat.AtBatResult == AtBat.AtBatType.Strikeout).Count();
            int WalksToday = currentMatch.atBats.Where(atBat => atBat.Pitcher == Defense.CurrentPitcher.id && atBat.AtBatResult == AtBat.AtBatType.Walk).Count();
            int HRToday = currentMatch.atBats.Where(atBat => atBat.Pitcher == Defense.CurrentPitcher.id && atBat.AtBatResult == AtBat.AtBatType.HomeRun).Count();

            PitcherIPToday.Text = Math.Round(OutsToday / 3 + (double)(OutsToday % 3) / 10, 1).ToString("0.0", new CultureInfo("en-US"));
            PitcherStrikeoutsToday.Text = StrikeoutsToday.ToString();
            PitcherWalksToday.Text = WalksToday.ToString();
            PitcherHomeRunsToday.Text = HRToday.ToString();

            int TBFinThisMatch = currentMatch.atBats.Where(atBat => atBat.AtBatResult != AtBat.AtBatType.CaughtStealing && atBat.AtBatResult != AtBat.AtBatType.StolenBase && atBat.AtBatResult != AtBat.AtBatType.CaughtStealing && atBat.Pitcher == Defense.CurrentPitcher.id).Count();
            btnShowAvailablePitchers.Visible = TBFinThisMatch >= 3 && newGameSituation.balls == 0 && newGameSituation.strikes == 0;
        }

        private void btnBuntAttempt_Click(object sender, EventArgs e)
        {
            Pitch pitch = new Pitch(newGameSituation, currentMatch.AwayTeam, currentMatch.HomeTeam);
            AddnewGameSituation(pitch);
        }

        private void lb_Runner1_Name_Click(object sender, EventArgs e)
        {
            if (!IsAutoSimulation)
            {
                if (!(lb_Runner3_Name.Visible && lb_Runner2_Name.Visible))
                {
                    lb_Runner1_Name.ForeColor = lb_Runner1_Name.ForeColor == Color.DarkGoldenrod ? Color.Gainsboro : Color.DarkGoldenrod;

                    if (lb_Runner2_Name.Visible)
                    {
                        lb_Runner2_Name.ForeColor = Color.DarkGoldenrod;
                    }
                }
            }
        }

        private void lb_Runner2_Name_Click(object sender, EventArgs e)
        {
            if (!IsAutoSimulation)
            {
                if (!lb_Runner3_Name.Visible)
                {
                    lb_Runner2_Name.ForeColor = lb_Runner2_Name.ForeColor == Color.DarkGoldenrod ? Color.Gainsboro : Color.DarkGoldenrod;
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                e.Cancel = true;
                if (MessageBox.Show("Do you want to close this window?\nThis match will be deleted from database", "Graduation paper", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DeleteThisMatch = true;
                    Hide();
                    DialogResult = DialogResult.Yes;
                }
            }
        }

        private void btnStandings_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            StandingsForm form = new StandingsForm(currentMatch.HomeTeam, currentMatch.AwayTeam);
            form.ShowDialog();
            if (IsAutoSimulation)
            {
                timer1.Start();
            }
        }

        private void btnShowAvailablePitchers_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Team Defense = newGameSituation.offense == currentMatch.AwayTeam ? currentMatch.HomeTeam : currentMatch.AwayTeam;
            List<Pitcher> pitchers = teamsBL.GetAvailablePitchers(currentMatch, Defense);
            if (pitchers.Count > 0)
            {
                SubstitutionForm form = new SubstitutionForm(Defense, pitchers);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    teamsBL.SubstitutePitcher(currentMatch, Defense, form.newPitcherForThisTeam);
                    currentMatch.AwayTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(currentMatch.AwayTeam.TeamAbbreviation, currentMatch.MatchID);
                    currentMatch.HomeTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(currentMatch.HomeTeam.TeamAbbreviation, currentMatch.MatchID);

                    teamsBL.UpdateStatsForThisPitcher(currentMatch.AwayTeam.CurrentPitcher, currentMatch);
                    teamsBL.UpdateStatsForThisPitcher(currentMatch.HomeTeam.CurrentPitcher, currentMatch);

                    Defense.PitchersPlayedInMatch.Add(form.newPitcherForThisTeam);
                    DisplayingCurrentSituation(newGameSituation);
                    DisplayPitcherStats();
                }
            }
            else
            {
                ErrorForm form = new ErrorForm();
                form.ShowDialog();
            }
            if (IsAutoSimulation)
            {
                timer1.Start();
            }
        }

        private void btnOtherResults_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            ScheduleAndResultsForm form = new ScheduleAndResultsForm(currentMatch);
            form.ShowDialog();
            if (IsAutoSimulation)
            {
                timer1.Start();
            }
        }

        private void btnPlayerStats_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            PlayerStatsForm form = new PlayerStatsForm(PlayerStatsForm.SortingObjects.Players);
            form.ShowDialog();
            if (IsAutoSimulation)
            {
                timer1.Start();
            }
        }

        private void panel6_VisibleChanged(object sender, EventArgs e)
        {
            pbCurrentOffenseLogo.Visible = panelCurrentBatter.Visible;
            pbCurrentBatterPhoto.Visible = panelCurrentBatter.Visible;
        }

        private void btnChangeBatter_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Team Offense = newGameSituation.offense;
            List<Batter> batters = teamsBL.GetAvailableBatters(currentMatch, Offense, GetBatterByGameSituation(newGameSituation));
            if (batters.Count > 0)
            {
                SubstitutionForm form = new SubstitutionForm(Offense, batters);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    Batter oldBatter = GetBatterByGameSituation(newGameSituation);
                    teamsBL.SubstituteBatter(currentMatch, Offense, oldBatter, form.newBatterForThisTeam);
                    currentMatch.AwayTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(currentMatch.AwayTeam.TeamAbbreviation, currentMatch.MatchID);
                    currentMatch.HomeTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(currentMatch.HomeTeam.TeamAbbreviation, currentMatch.MatchID);
                    if (!currentMatch.DHRule && oldBatter.NumberInBattingLineup == 9)
                    {
                        Pitcher newPitcher = teamsBL.GetPitcherByID(form.newBatterForThisTeam.id);
                        Offense.PitchersPlayedInMatch.Add(newPitcher);
                    }
                    teamsBL.UpdateStatsForThisPitcher(currentMatch.AwayTeam.CurrentPitcher, currentMatch);
                    teamsBL.UpdateStatsForThisPitcher(currentMatch.HomeTeam.CurrentPitcher, currentMatch);
                    DisplayingCurrentSituation(newGameSituation);
                }
            }
            else
            {
                ErrorForm form = new ErrorForm();
                form.ShowDialog();
            }
            if (IsAutoSimulation)
            {
                timer1.Start();
            }
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

        private void btnTeamStats_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            PlayerStatsForm form = new PlayerStatsForm(PlayerStatsForm.SortingObjects.Teams);
            form.ShowDialog();
            if (IsAutoSimulation)
            {
                timer1.Start();
            }
        }

        private void MainForm_ClientSizeChanged(object sender, EventArgs e)
        {
            panel1Base.Location = new Point(ClientSize.Width - 211, ClientSize.Height / 2 - 50);
            RunnerOn1Photo.Location = new Point(ClientSize.Width - 278, ClientSize.Height / 2 - 50);

            panel3Base.Location = new Point(79, ClientSize.Height / 2 - 50);
            RunnerOn3Photo.Location = new Point(12, ClientSize.Height / 2 - 50);

            RunnerOn2Photo.Location = new Point(ClientSize.Width / 2 - 132, 144);
            panel2Base.Location = new Point(ClientSize.Width / 2 - 65, 144);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IsAutoSimulation = pb_stamina.Value > 15;
            SimulationModeChanged(IsAutoSimulation);
            if (IsAutoSimulation)
            {
                GenerateNewPitch();
            }
        }

        private void btnAutoMode_Click(object sender, EventArgs e)
        {
            IsAutoSimulation = !IsAutoSimulation;
            SimulationModeChanged(IsAutoSimulation);
        }

        private void SimulationModeChanged(bool isAutoSim)
        {
            timer1.Enabled = isAutoSim;
            btnNewPitch.Enabled = !isAutoSim;
            btnAutoMode.Text = isAutoSim ? "MANUAL" : "AUTOMATIC";
        }
    }
}