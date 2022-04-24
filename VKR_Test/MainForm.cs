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
        private readonly MatchBL matchBL;
        private readonly PlayerBL playerBL;
        public bool DeleteThisMatch;
        private bool IsAutoSimulation;

        public MainForm(Match match)
        {
            InitializeComponent();
            matchBL = new MatchBL();
            playerBL = new PlayerBL();
            currentMatch = match;

            StartingLineupForm lineup = new StartingLineupForm(currentMatch.AwayTeam);
            lineup.ShowDialog();
            DefenseForm defense = new DefenseForm(currentMatch.HomeTeam);
            defense.ShowDialog();

            previousSituation = currentMatch.GameSituations.Last();
            newGameSituation = new GameSituation(match.AwayTeam);

            PrepareForThisTeam(match.AwayTeam, AwayTeam_Abbreviation, AwayTeam_RunsScored, label18, panel11, label22, currentMatch, AwayTeamNextBatters, away_DueUP);
            PrepareForThisTeam(match.HomeTeam, HomeTeam_Abbreviation, HomeTeam_RunsScored, label19, panel12, label23, currentMatch, homeTeamNextBatters, home_DueUP);
            DisplayingCurrentSituation(match.GameSituations.Last());

            DisplayNextBatters(AwayNext1, AwayNext2, AwayNext3, AwayNextNumber1, AwayNextNumber2, AwayNextNumber3, currentMatch, currentMatch.AwayTeam, AwayNext1Stats, AwayNext2Stats, AwayNext3Stats, currentMatch.GameSituations.Last());
            DisplayNextBatters(homeNext1, homeNext2, homeNext3, homeNextNumber1, homeNextNumber2, homeNextNumber3, currentMatch, currentMatch.HomeTeam, HomeNext1Stats, HomeNext2Stats, HomeNext3Stats, currentMatch.GameSituations.Last());
            pb_stamina.Value = (int)currentMatch.HomeTeam.CurrentPitcher.RemainingStamina;
            SimulationModeChanged(!match.IsQuickMatch);
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
                Number = situation.NumberOfBatterFromHomeTeam;
            }
            else
            {
                Number = situation.NumberOfBatterFromAwayTeam;
            }

            if (situation.Offense != team)
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
            if (gameSituation.Offense == currentMatch.AwayTeam)
            {
                label1.Text = "▲";
            }
            else
            {
                label1.Text = "▼";
            }
            label2.Text = gameSituation.InningNumber.ToString();
            label3.Text = gameSituation.Outs.ToString();
            label4.Text = gameSituation.Outs <= 1 ? "Out" : "Outs";
            label5.Text = $"{gameSituation.Balls}-{gameSituation.Strikes}";
            lbPitcherSecondName.Text = gameSituation.Offense == currentMatch.AwayTeam ? currentMatch.HomeTeam.CurrentPitcher.SecondName : currentMatch.AwayTeam.CurrentPitcher.SecondName;
            Pitcher CurrentPitcher = gameSituation.Offense.TeamAbbreviation == currentMatch.AwayTeam.TeamAbbreviation ? currentMatch.HomeTeam.CurrentPitcher : currentMatch.AwayTeam.CurrentPitcher;

            lbPitchCountForThisPitcher.Text = currentMatch.GameSituations.Where(situation => situation.PitcherID == CurrentPitcher.Id &&
                                                                                               !(situation.Result == Pitch.PitchResult.CaughtStealingOnSecond || situation.Result == Pitch.PitchResult.CaughtStealingOnThird ||
                                                                                                 situation.Result == Pitch.PitchResult.SecondBaseStolen || situation.Result == Pitch.PitchResult.ThirdBaseStolen)).Count().ToString();

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

            panelCurrentBatter.Visible = gameSituation.Strikes == 0 && gameSituation.Balls == 0;

            panel8.BackColor = gameSituation.Offense.TeamColorForThisMatch;
            btnChangeBatter.BackColor = Color.FromArgb((int)(gameSituation.Offense.TeamColorForThisMatch.R * 0.9), (int)(gameSituation.Offense.TeamColorForThisMatch.G * 0.9), (int)(gameSituation.Offense.TeamColorForThisMatch.B * 0.9));

            pbCurrentOffenseLogo.BackgroundImage = Image.FromFile($"SmallTeamLogos/{newGameSituation.Offense.TeamAbbreviation}.png");
            Batter NextBatter = GetBatterByGameSituation(gameSituation);
            NewBatterDisplaying(NextBatter);
            DisplayNextBatters(AwayNext1, AwayNext2, AwayNext3, AwayNextNumber1, AwayNextNumber2, AwayNextNumber3, currentMatch, currentMatch.AwayTeam, AwayNext1Stats, AwayNext2Stats, AwayNext3Stats, gameSituation);
            DisplayNextBatters(homeNext1, homeNext2, homeNext3, homeNextNumber1, homeNextNumber2, homeNextNumber3, currentMatch, currentMatch.HomeTeam, HomeNext1Stats, HomeNext2Stats, HomeNext3Stats, gameSituation);
            DisplayPitcherStats();
            Text = $"{currentMatch.AwayTeam.TeamAbbreviation} {gameSituation.AwayTeamRuns} - {gameSituation.HomeTeamRuns} {currentMatch.HomeTeam.TeamAbbreviation} @ {currentMatch.Stadium.StadiumTitle}";

            lb9thInning.Text = gameSituation.InningNumber <= 9 ? 9.ToString() : gameSituation.InningNumber.ToString();
            lb8thInning.Text = (int.Parse(lb9thInning.Text) - 1).ToString();
            lb7thInning.Text = (int.Parse(lb8thInning.Text) - 1).ToString();
            lb6thInning.Text = (int.Parse(lb7thInning.Text) - 1).ToString();
            lb5thInning.Text = (int.Parse(lb6thInning.Text) - 1).ToString();
            lb4thInning.Text = (int.Parse(lb5thInning.Text) - 1).ToString();
            lb3rdInning.Text = (int.Parse(lb4thInning.Text) - 1).ToString();
            lb2ndInning.Text = (int.Parse(lb3rdInning.Text) - 1).ToString();
            lb1stInning.Text = (int.Parse(lb2ndInning.Text) - 1).ToString();

            UpdateScoreboard(away2, away3, away4, away5, away6, away7, away8, away9, away10, awayLOB, awayRuns, awayHits, currentMatch, currentMatch.AwayTeam);
            UpdateScoreboard(home2, home3, home4, home5, home6, home7, home8, home9, home10, homeLOB, homeRuns, homeHits, currentMatch, currentMatch.HomeTeam);
        }

        public void DisplayCurrentRunners(GameSituation situation)
        {
            RunnerOnBase_Displaying(situation.RunnerOnFirst, lb_Runner1_Name, RunnerOn1Photo, situation.Offense, situation, panel1Base, lb1stBase);
            RunnerOnBase_Displaying(situation.RunnerOnSecond, lb_Runner2_Name, RunnerOn2Photo, situation.Offense, situation, panel2Base, lb2ndBase);
            RunnerOnBase_Displaying(situation.RunnerOnThird, lb_Runner3_Name, RunnerOn3Photo, situation.Offense, situation, panel3Base, lb3rdBase);
        }

        private void RunnerOnBase_Displaying(Runner runner, Label RunnerName, Panel RunnerPhoto, Team offense, GameSituation situation, Panel basePanel, Label panelHeader)
        {
            basePanel.Visible = runner.IsBaseNotEmpty;
            panelHeader.BackColor = situation.Offense.TeamColorForThisMatch;
            if (runner.IsBaseNotEmpty)
            {
                Batter runneron3rd = offense.BattingLineup.Where(Batter => Batter.Id == runner.RunnerID).First();
                RunnerName.Text = runneron3rd.FullName.ToUpper();
                if (File.Exists($"PlayerPhotos/Player{runner.RunnerID:0000}.png"))
                {
                    RunnerPhoto.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{runner.RunnerID:0000}.png");
                }
                else RunnerPhoto.BackgroundImage = null;
                RunnerName.ForeColor = runner.IsBaseStealingAttempt ? Color.Goldenrod : Color.Gainsboro;
            }
            else RunnerPhoto.BackgroundImage = null;
        }

        private Batter GetBatterByGameSituation(GameSituation gameSituation)
        {
            if (gameSituation.Offense == currentMatch.AwayTeam)
            {
                return currentMatch.AwayTeam.BattingLineup[gameSituation.NumberOfBatterFromHomeTeam - 1];
            }
            else
            {
                return currentMatch.HomeTeam.BattingLineup[gameSituation.NumberOfBatterFromAwayTeam - 1];
            }
        }

        private void ShowBatterStats(Batter batter, Label BatterStats)
        {
            if (currentMatch.AtBats.Where(atBat => atBat.Batter == batter.Id && (atBat.AtBatResult == AtBat.AtBatType.Double ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Triple ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.HomeRun ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Single ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Popout ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Strikeout ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Flyout ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Groundout)).Count() > 0)
            {
                int Hits = currentMatch.AtBats.Where(atBat => atBat.Batter == batter.Id && (atBat.AtBatResult == AtBat.AtBatType.Double ||
                                                                               atBat.AtBatResult == AtBat.AtBatType.Triple ||
                                                                               atBat.AtBatResult == AtBat.AtBatType.HomeRun ||
                                                                               atBat.AtBatResult == AtBat.AtBatType.Single)).Count();
                int AtBats = currentMatch.AtBats.Where(atBat => atBat.Batter == batter.Id && (atBat.AtBatResult == AtBat.AtBatType.Double ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Triple ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.HomeRun ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Single ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Popout ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Strikeout ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Flyout ||
                                                                              atBat.AtBatResult == AtBat.AtBatType.Groundout)).Count();
                BatterStats.Text = Hits + " FOR " + AtBats;
            }
            else if (currentMatch.AtBats.Where(atBat => atBat.Batter == batter.Id && (atBat.AtBatResult == AtBat.AtBatType.HitByPitch)).Count() > 0)
            {
                BatterStats.Text = "HBP";
            }
            else if (currentMatch.AtBats.Where(atBat => atBat.Batter == batter.Id && atBat.AtBatResult == AtBat.AtBatType.Walk).Count() > 0)
            {
                if (currentMatch.AtBats.Where(atBat => atBat.Batter == batter.Id && atBat.AtBatResult == AtBat.AtBatType.Walk).Count() == 1)
                {
                    BatterStats.Text = "WALK";
                }
                else
                {
                    BatterStats.Text = $"{currentMatch.AtBats.Where(atBat => atBat.Batter == batter.Id && atBat.AtBatResult == AtBat.AtBatType.Walk).Count()} WALKS";
                }
            }
            else if (currentMatch.AtBats.Where(atBat => atBat.Batter == batter.Id && atBat.AtBatResult == AtBat.AtBatType.SacrificeFly).Count() > 0)
            {
                BatterStats.Text = "SAC FLY";
            }
            else
            {
                BatterStats.Text = batter.battingStats.AVG.ToString("#.000", new CultureInfo("en-US"));
            }
        }

        private void NewBatterDisplaying(Batter batter)
        {
            lbBatterNumber.Text = batter.NumberInBattingLineup.ToString() + ".";
            lbBatterSecondName.Text = batter.SecondName;

            ShowBatterStats(batter, BatterStats);
            ShowStatsForThisMatch(batter, lbTodayStats);

            if (File.Exists($"PlayerPhotos/Player{batter.Id:0000}.png"))
            {
                pbCurrentBatterPhoto.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{batter.Id:0000}.png");
            }
            else
            {
                pbCurrentBatterPhoto.BackgroundImage = null;
            }
            lblPlayerPosition.Text = batter.PositionForThisMatch;
            lblPlayerNumber.Text = batter.PlayerNumber.ToString();
            lblPlayerName.Text = batter.FullName.ToUpper();
            label6.Text = batter.battingStats.AVG.ToString("#.000", new CultureInfo("en-US"));
            label9.Text = batter.battingStats.HomeRuns.ToString("N0", CultureInfo.InvariantCulture);
            label11.Text = batter.battingStats.RBI.ToString("N0", CultureInfo.InvariantCulture);
            label13.Text = batter.battingStats.StolenBases.ToString("N0", CultureInfo.InvariantCulture);
            label15.Text = batter.battingStats.Runs.ToString("N0", CultureInfo.InvariantCulture);
            label17.Text = batter.battingStats.OPS.ToString("#.000", new CultureInfo("en-US"));
        }

        private void ShowStatsForThisMatch(Batter batter, Label lbTodayStats)
        {
            List<AtBat> atBatsForThisBatter = currentMatch.AtBats.Where(atBat => atBat.Batter == batter.Id).ToList();
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
            if (pitch.NewPitchResult == Pitch.PitchResult.HomeRun)
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
                if (newGameSituation.InningNumber >= 9 && newGameSituation.Offense == currentMatch.HomeTeam && newGameSituation.AwayTeamRuns < newGameSituation.HomeTeamRuns)
                {
                    title = "Walk-off " + title.ToLower();
                }
                HomeRunCelebrationForm hr = new HomeRunCelebrationForm(newGameSituation.Offense, title, GetBatterByGameSituation(newGameSituation), currentMatch.AtBats, currentMatch.IsQuickMatch);
                hr.ShowDialog();
                if (IsAutoSimulation)
                {
                    timer1.Start();
                }
            }
        }

        private void GetCurrentStatsForThisMatch()
        {
            currentMatch.AwayTeam.BattingLineup = playerBL.GetCurrentLineupForThisMatch(currentMatch.AwayTeam.TeamAbbreviation, currentMatch.MatchID);
            currentMatch.HomeTeam.BattingLineup = playerBL.GetCurrentLineupForThisMatch(currentMatch.HomeTeam.TeamAbbreviation, currentMatch.MatchID);

            playerBL.UpdateStatsForThisPitcher(currentMatch.AwayTeam.CurrentPitcher, currentMatch);
            playerBL.UpdateStatsForThisPitcher(currentMatch.HomeTeam.CurrentPitcher, currentMatch);

            UpdateScoreboard(away2, away3, away4, away5, away6, away7, away8, away9, away10, awayLOB, awayRuns, awayHits, currentMatch, currentMatch.AwayTeam);
            UpdateScoreboard(home2, home3, home4, home5, home6, home7, home8, home9, home10, homeLOB, homeRuns, homeHits, currentMatch, currentMatch.HomeTeam);
        }


        private void AddnewGameSituation(Pitch pitch)
        {
            newGameSituation.Id = previousSituation.Id + 1;
            newGameSituation.Result = pitch.NewPitchResult;
            newGameSituation.Balls = newGameSituation.NumberOfBallsDetrmining(newGameSituation.Result, previousSituation);
            newGameSituation.Strikes = newGameSituation.NumberOfStrikesDetermining(newGameSituation.Result, previousSituation);
            newGameSituation.Outs = newGameSituation.NumberOfOutsDetermining(newGameSituation.Result, previousSituation, newGameSituation.Strikes);
            newGameSituation.RunnerOnFirst = newGameSituation.HavingARunnerOnFirstBase(newGameSituation.Result, previousSituation, currentMatch, newGameSituation.Balls);
            newGameSituation.RunnerOnSecond = newGameSituation.HavingARunnerOnSecondBase(newGameSituation.Result, previousSituation, currentMatch, newGameSituation.Balls);
            newGameSituation.RunnerOnThird = newGameSituation.HavingARunnerOnThirdBase(newGameSituation.Result, previousSituation, currentMatch, newGameSituation.Balls);
            runs = newGameSituation.NumberOfRunsScoredForLastPitch(newGameSituation.Result, previousSituation, newGameSituation.Balls);
            newGameSituation.RunsByThisPitch = newGameSituation.GetListOfRunnersInHomeByThisPitch(newGameSituation.Result, previousSituation, newGameSituation.Balls, currentMatch);
            newGameSituation.PitcherID = newGameSituation.Offense == currentMatch.AwayTeam ? currentMatch.HomeTeam.CurrentPitcher.Id : currentMatch.AwayTeam.CurrentPitcher.Id;
            if (newGameSituation.Offense == currentMatch.AwayTeam)
            {
                newGameSituation.AwayTeamRuns += runs;
            }
            else
            {
                newGameSituation.HomeTeamRuns += runs;
            }
            currentMatch.GameSituations.Add(new GameSituation(newGameSituation.Id, newGameSituation.InningNumber, newGameSituation.Offense, newGameSituation.Result, newGameSituation.Balls, newGameSituation.Strikes, newGameSituation.Outs, newGameSituation.RunnerOnFirst, newGameSituation.RunnerOnSecond, newGameSituation.RunnerOnThird, newGameSituation.AwayTeamRuns, newGameSituation.HomeTeamRuns, newGameSituation.NumberOfBatterFromHomeTeam, newGameSituation.NumberOfBatterFromAwayTeam, newGameSituation.PitcherID));
            IsHomeRun(pitch, runs);
            IsAtBatFinished(currentMatch.GameSituations.Last());

            if (newGameSituation.RunsByThisPitch.Count != 0)
            {
                foreach (Runner runner in newGameSituation.RunsByThisPitch)
                {
                    AtBat runForDB = new AtBat(runner, currentMatch);
                    currentMatch.AtBats.Add(runForDB);
                    matchBL.AddNewAtBat(runForDB, currentMatch);
                }
                GetCurrentStatsForThisMatch();
            }
            newGameSituation.PrepareForNextPitch(currentMatch.GameSituations.Last(), currentMatch.AwayTeam, currentMatch.HomeTeam, currentMatch.MatchLength);
            if (currentMatch.GameSituations.Last().Offense == currentMatch.AwayTeam && currentMatch.GameSituations.Last().Outs == 3 && currentMatch.GameSituations.Last().InningNumber == 1)
            {
                timer1.Stop();
                StartingLineupForm form = new StartingLineupForm(currentMatch.HomeTeam);
                form.ShowDialog();
                DefenseForm defense = new DefenseForm(currentMatch.AwayTeam);
                defense.ShowDialog();
                DisplayPitcherStats();
                if (IsAutoSimulation)
                {
                    timer1.Start();
                }
            }

            DisplayingCurrentSituation(newGameSituation);
            if (newGameSituation.Strikes == 0 && newGameSituation.Balls == 0)
            {
                DisplayCurrentRunners(newGameSituation);
            }

            IsFinishOfMatch(currentMatch);

            panelLastAtBat.Visible = currentMatch.AtBats.Count > 0;

            if (currentMatch.AtBats.Count > 0)
            {
                var LastAtBatOffense = currentMatch.AtBats.Where(atbat => atbat.AtBatResult != AtBat.AtBatType.Run).Last().Offense;
                label27.BackColor = LastAtBatOffense == currentMatch.AwayTeam.TeamAbbreviation ? currentMatch.AwayTeam.TeamColorForThisMatch : currentMatch.HomeTeam.TeamColorForThisMatch;
                panel15.BackgroundImage = Image.FromFile($"SmallTeamLogos/{LastAtBatOffense}.png");

                var lastBatter = playerBL.GetPlayerByCode(currentMatch.AtBats.Where(atbat => atbat.AtBatResult != AtBat.AtBatType.Run).Last().Batter);
                label27.Text = Width >= 960 ? lastBatter.FullName : $"{lastBatter.FirstName[0]}. {lastBatter.SecondName}";
                label44.Text = currentMatch.AtBats.Where(atbat => atbat.AtBatResult != AtBat.AtBatType.Run).Last().ToString();
            }

            previousSituation = new GameSituation(newGameSituation.Id, newGameSituation.InningNumber, newGameSituation.Offense, newGameSituation.Result, newGameSituation.Balls, newGameSituation.Strikes, newGameSituation.Outs, newGameSituation.RunnerOnFirst, newGameSituation.RunnerOnSecond, newGameSituation.RunnerOnThird, newGameSituation.AwayTeamRuns, newGameSituation.HomeTeamRuns, newGameSituation.NumberOfBatterFromHomeTeam, newGameSituation.NumberOfBatterFromAwayTeam, newGameSituation.PitcherID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateNewPitch();
        }

        private void BasesStealingAttempt_Definition()
        {
            RandomGenerators.StealingAttempt thirdBaseStealingAttempt, secondBaseStealingAttempt;
            if (newGameSituation.RunnerOnSecond.IsBaseNotEmpty && !newGameSituation.RunnerOnThird.IsBaseNotEmpty)
            {
                thirdBaseStealingAttempt = RandomGenerators.stealingAttempt_Definition(RandomGenerators.BaseNumberForStealing.Third, newGameSituation, currentMatch.AwayTeam);
                if (thirdBaseStealingAttempt == RandomGenerators.StealingAttempt.Attempt)
                {
                    newGameSituation.RunnerOnSecond.IsBaseStealingAttempt = true;
                    if (newGameSituation.RunnerOnFirst.IsBaseNotEmpty && newGameSituation.RunnerOnSecond.IsBaseNotEmpty)
                    {
                        secondBaseStealingAttempt = RandomGenerators.stealingAttempt_Definition(RandomGenerators.BaseNumberForStealing.Second, newGameSituation, currentMatch.AwayTeam);
                        if (secondBaseStealingAttempt == RandomGenerators.StealingAttempt.Attempt)
                        {
                            newGameSituation.RunnerOnFirst.IsBaseStealingAttempt = true;
                        }
                    }
                }
            }
            if (newGameSituation.RunnerOnFirst.IsBaseNotEmpty && !newGameSituation.RunnerOnSecond.IsBaseNotEmpty)
            {
                secondBaseStealingAttempt = RandomGenerators.stealingAttempt_Definition(RandomGenerators.BaseNumberForStealing.Second, newGameSituation, currentMatch.AwayTeam);
                if (secondBaseStealingAttempt == RandomGenerators.StealingAttempt.Attempt)
                {
                    newGameSituation.RunnerOnFirst.IsBaseStealingAttempt = true;
                }
            }
        }

        private bool BuntAttemptDefinition()
        {
            RandomGenerators.BuntAttempt buntAttempt = RandomGenerators.BuntAttempt_Definition(newGameSituation, currentMatch.AwayTeam, currentMatch.AtBats);
            return buntAttempt == RandomGenerators.BuntAttempt.Attempt;
        }

        private void GenerateNewPitch()
        {
            Pitch pitch;
            bool StealingAttempt = newGameSituation.RunnerOnFirst.IsBaseStealingAttempt || newGameSituation.RunnerOnSecond.IsBaseStealingAttempt;
            int CountOfAtBats = currentMatch.AtBats.Count();
            int TypeOfStealing = 0;
            if (StealingAttempt)
            {
                pitch = new Pitch(newGameSituation, currentMatch.GameSituations, currentMatch.HomeTeam, currentMatch.AwayTeam);
                if (newGameSituation.RunnerOnFirst.IsBaseStealingAttempt)
                {
                    if (newGameSituation.RunnerOnSecond.IsBaseStealingAttempt)
                    {
                        TypeOfStealing = 3;
                    }
                    else
                    {
                        TypeOfStealing = 1;
                    }
                }
                else if (newGameSituation.RunnerOnSecond.IsBaseStealingAttempt)
                {
                    TypeOfStealing = 2;
                }
            }
            else
            {
                pitch = new Pitch(newGameSituation, currentMatch);
            }
            AddnewGameSituation(pitch);
            int NewCountOfAtBats = currentMatch.AtBats.Count();
            if (StealingAttempt && CountOfAtBats == NewCountOfAtBats)
            {
                switch (TypeOfStealing)
                {
                    case 1:
                        {
                            BaseStealing(Pitch.StealingType.OnlySecondBase);
                            break;
                        }
                    case 2:
                        {
                            BaseStealing(Pitch.StealingType.OnlyThirdBase);
                            break;
                        }
                    case 3:
                        {
                            BaseStealing(Pitch.StealingType.ThirdBaseBeforeSecond);
                            if (currentMatch.GameSituations.Last().Outs != 3)
                            {
                                BaseStealing(Pitch.StealingType.SecondBaseAfterThird);
                            }
                            break;
                        }
                }
            }
        }

        private void BaseStealing(Pitch.StealingType stealingType)
        {
            Pitch pitch = new Pitch(newGameSituation, stealingType);
            AddnewGameSituation(pitch);
            DisplayCurrentRunners(newGameSituation);
        }

        private void IsFinishOfMatch(Match currentMatch)
        {
            if ((currentMatch.GameSituations.Last().Offense == currentMatch.AwayTeam && currentMatch.GameSituations.Last().Outs == 3 && currentMatch.GameSituations.Last().AwayTeamRuns < currentMatch.GameSituations.Last().HomeTeamRuns && currentMatch.GameSituations.Last().InningNumber == currentMatch.MatchLength) ||
                (currentMatch.GameSituations.Last().Offense == currentMatch.HomeTeam && currentMatch.GameSituations.Last().Outs == 3 && currentMatch.GameSituations.Last().AwayTeamRuns > currentMatch.GameSituations.Last().HomeTeamRuns && currentMatch.GameSituations.Last().InningNumber >= currentMatch.MatchLength) ||
                (currentMatch.GameSituations.Last().Offense == currentMatch.HomeTeam && currentMatch.GameSituations.Last().AwayTeamRuns < currentMatch.GameSituations.Last().HomeTeamRuns && currentMatch.GameSituations.Last().InningNumber >= currentMatch.MatchLength))
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

        private void UpdateScoreboard(Label FirstInning, Label SecondInning, Label ThirdInning, Label FourthInning, Label FifthInning, Label SixthInning, Label SeventhInning, Label EigthInning, Label NinthInning, Label LeftOnBase, Label Runs, Label Hits, Match match, Team team)
        {
            FirstInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb1stInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            SecondInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb2ndInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            ThirdInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb3rdInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            FourthInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb4thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            FifthInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb5thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            SixthInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb6thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            SeventhInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb7thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            EigthInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb8thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();
            NinthInning.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && atBat.Inning == int.Parse(lb9thInning.Text)).Select(atBat => atBat.RBI).Sum().ToString();

            int LeftOnFirstBase = match.GameSituations.Where(gs => gs.Outs == 3 && gs.Offense.TeamAbbreviation == team.TeamAbbreviation && gs.RunnerOnFirst.IsBaseNotEmpty).Count();
            int LeftOnSecondBase = match.GameSituations.Where(gs => gs.Outs == 3 && gs.Offense.TeamAbbreviation == team.TeamAbbreviation && gs.RunnerOnSecond.IsBaseNotEmpty).Count();
            int LeftOnThirdBase = match.GameSituations.Where(gs => gs.Outs == 3 && gs.Offense.TeamAbbreviation == team.TeamAbbreviation && gs.RunnerOnThird.IsBaseNotEmpty).Count();

            LeftOnBase.Text = (LeftOnFirstBase + LeftOnSecondBase + LeftOnThirdBase).ToString();

            bool DisplayingCriterion = team == currentMatch.AwayTeam ? (newGameSituation.Offense == currentMatch.AwayTeam || newGameSituation.Offense == currentMatch.HomeTeam) : newGameSituation.Offense == currentMatch.HomeTeam;

            FirstInning.ForeColor = newGameSituation.InningNumber > int.Parse(lb1stInning.Text) || newGameSituation.InningNumber == int.Parse(lb1stInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            SecondInning.ForeColor = newGameSituation.InningNumber > int.Parse(lb2ndInning.Text) || newGameSituation.InningNumber == int.Parse(lb2ndInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            ThirdInning.ForeColor = newGameSituation.InningNumber > int.Parse(lb3rdInning.Text) || newGameSituation.InningNumber == int.Parse(lb3rdInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            FourthInning.ForeColor = newGameSituation.InningNumber > int.Parse(lb4thInning.Text) || newGameSituation.InningNumber == int.Parse(lb4thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            FifthInning.ForeColor = newGameSituation.InningNumber > int.Parse(lb5thInning.Text) || newGameSituation.InningNumber == int.Parse(lb5thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            SixthInning.ForeColor = newGameSituation.InningNumber > int.Parse(lb6thInning.Text) || newGameSituation.InningNumber == int.Parse(lb6thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            SeventhInning.ForeColor = newGameSituation.InningNumber > int.Parse(lb7thInning.Text) || newGameSituation.InningNumber == int.Parse(lb7thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            EigthInning.ForeColor = newGameSituation.InningNumber > int.Parse(lb8thInning.Text) || newGameSituation.InningNumber == int.Parse(lb8thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            NinthInning.ForeColor = newGameSituation.InningNumber > int.Parse(lb9thInning.Text) || newGameSituation.InningNumber == int.Parse(lb9thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);

            Runs.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation).Select(atBat => atBat.RBI).Sum().ToString();
            Hits.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation && (atBat.AtBatResult == AtBat.AtBatType.Single || atBat.AtBatResult == AtBat.AtBatType.Double || atBat.AtBatResult == AtBat.AtBatType.Triple || atBat.AtBatResult == AtBat.AtBatType.HomeRun)).Count().ToString();
        }

        private void IsAtBatFinished(GameSituation situation)
        {
            if (situation.Result == Pitch.PitchResult.Single ||
                situation.Result == Pitch.PitchResult.Double ||
                situation.Result == Pitch.PitchResult.Triple ||
                situation.Result == Pitch.PitchResult.HomeRun ||
                situation.Result == Pitch.PitchResult.HitByPitch ||
                situation.Result == Pitch.PitchResult.Popout ||
                situation.Result == Pitch.PitchResult.Groundout ||
                situation.Result == Pitch.PitchResult.Flyout ||
                situation.Result == Pitch.PitchResult.SacrificeFly ||
                situation.Result == Pitch.PitchResult.SacrificeBunt ||
                situation.Result == Pitch.PitchResult.DoublePlay ||
                situation.Result == Pitch.PitchResult.CaughtStealingOnSecond ||
                situation.Result == Pitch.PitchResult.CaughtStealingOnThird ||
                situation.Result == Pitch.PitchResult.SecondBaseStolen ||
                situation.Result == Pitch.PitchResult.ThirdBaseStolen ||
                situation.Result == Pitch.PitchResult.GroundRuleDouble ||
                situation.Result == Pitch.PitchResult.DoublePlayOnFlyout ||
                (situation.Result == Pitch.PitchResult.Ball && situation.Balls == 0) ||
                (situation.Result == Pitch.PitchResult.Strike && situation.Strikes == 0))
            {
                switch (situation.Result)
                {
                    case Pitch.PitchResult.SecondBaseStolen:
                        {
                            AtBat atBat = new AtBat(currentMatch, situation.RunnerOnSecond.RunnerID, false);
                            currentMatch.AtBats.Add(atBat);
                            matchBL.AddNewAtBat(atBat, currentMatch);
                            break;
                        }
                    case Pitch.PitchResult.ThirdBaseStolen:
                        {
                            AtBat atBat = new AtBat(currentMatch, situation.RunnerOnThird.RunnerID, true);
                            currentMatch.AtBats.Add(atBat);
                            matchBL.AddNewAtBat(atBat, currentMatch);
                            break;
                        }
                    case Pitch.PitchResult.CaughtStealingOnSecond:
                        {
                            AtBat atBat = new AtBat(currentMatch, currentMatch.GameSituations[currentMatch.GameSituations.Count - 2].RunnerOnFirst.RunnerID, true);
                            currentMatch.AtBats.Add(atBat);
                            matchBL.AddNewAtBat(atBat, currentMatch);
                            break;
                        }
                    case Pitch.PitchResult.CaughtStealingOnThird:
                        {
                            AtBat atBat = new AtBat(currentMatch, currentMatch.GameSituations[currentMatch.GameSituations.Count - 2].RunnerOnSecond.RunnerID, true);
                            currentMatch.AtBats.Add(atBat);
                            matchBL.AddNewAtBat(atBat, currentMatch);
                            break;
                        }
                    default:
                        {
                            AtBat LastAtBat = new AtBat(currentMatch, runs);
                            currentMatch.AtBats.Add(LastAtBat);
                            matchBL.AddNewAtBat(LastAtBat, currentMatch);
                            break;
                        }
                }
                GetCurrentStatsForThisMatch();
            }
        }

        private void DisplayPitcherStats()
        {
            Team Defense = newGameSituation.Offense == currentMatch.AwayTeam ? currentMatch.HomeTeam : currentMatch.AwayTeam;
            PitchingTeamColor.BackColor = Defense.TeamColorForThisMatch;
            btnShowAvailablePitchers.BackColor = Defense.TeamColorForThisMatch;
            PitchingTeam.BackgroundImage = Image.FromFile($"SmallTeamLogos/{Defense.TeamAbbreviation}.png");
            if (File.Exists($"PlayerPhotos/Player{Defense.CurrentPitcher.Id:0000}.png"))
            {
                PitcherPhoto.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{Defense.CurrentPitcher.Id:0000}.png");
            }
            else
            {
                PitcherPhoto.BackgroundImage = null;
            }
            PitcherName.Text = Defense.CurrentPitcher.FullName.ToUpper();

            PitcherGames.Visible = Defense.PitchersPlayedInMatch.Count > 1;
            labelGames.Visible = Defense.PitchersPlayedInMatch.Count > 1;
            PitcherGames.Text = Defense.CurrentPitcher.pitchingStats.GamesPlayed.ToString();
            if (Defense.PitchersPlayedInMatch.Count == 1)
            {
                labelGS.Text = "STARTS";
                PitcherGS.Text = $"{Defense.CurrentPitcher.pitchingStats.GamesStarted}";
                labelRecord.Text = "RECORD";
                PitcherRecord.Text = $"{Defense.CurrentPitcher.pitchingStats.Wins}-{Defense.CurrentPitcher.pitchingStats.Losses}";
            }
            else
            {
                labelGS.Text = "RECORD";
                PitcherGS.Text = $"{Defense.CurrentPitcher.pitchingStats.Wins}-{Defense.CurrentPitcher.pitchingStats.Losses}";
                labelRecord.Text = "SAVES";
                PitcherRecord.Text = $"{Defense.CurrentPitcher.pitchingStats.Saves}";
            }

            PitcherBAA.Text = Defense.CurrentPitcher.pitchingStats.BAA.ToString("#.000", new CultureInfo("en-US"));
            PitcherERA.Text = Defense.CurrentPitcher.pitchingStats.ERA.ToString("##0.00", new CultureInfo("en-US"));
            PitcherIP.Text = Defense.CurrentPitcher.pitchingStats.IP.ToString("0.0", new CultureInfo("en-US"));
            PitcherHomeRuns.Text = Defense.CurrentPitcher.pitchingStats.HomeRunsAllowed.ToString();
            PitcherStrikeouts.Text = Defense.CurrentPitcher.pitchingStats.Strikeouts.ToString();
            PitcherWalks.Text = Defense.CurrentPitcher.pitchingStats.WalksAllowed.ToString();
            PitcherWHIP.Text = Defense.CurrentPitcher.pitchingStats.WHIP.ToString("0.00", new CultureInfo("en-US"));

            Defense.CurrentPitcher.RemainingStamina = playerBL.ReturnNumberOfOutsPlayedByThisPitcherInLast5Days(Defense.CurrentPitcher);

            pb_stamina.MainColor = Defense.CurrentPitcher.RemainingStamina < (45 - 1E-5) ? Color.Maroon : Defense.TeamColorForThisMatch;

            if (Defense.CurrentPitcher.RemainingStamina < 5 - 1E-5)
            {
                pb_stamina.Value = 5;
            }
            else
            {
                pb_stamina.Value = (int)Defense.CurrentPitcher.RemainingStamina;
            }

            int OutsToday = currentMatch.AtBats.Where(atBat => atBat.Pitcher == Defense.CurrentPitcher.Id).Select(atBat => atBat.Outs).Sum();
            int StrikeoutsToday = currentMatch.AtBats.Where(atBat => atBat.Pitcher == Defense.CurrentPitcher.Id && atBat.AtBatResult == AtBat.AtBatType.Strikeout).Count();
            int WalksToday = currentMatch.AtBats.Where(atBat => atBat.Pitcher == Defense.CurrentPitcher.Id && atBat.AtBatResult == AtBat.AtBatType.Walk).Count();
            int HRToday = currentMatch.AtBats.Where(atBat => atBat.Pitcher == Defense.CurrentPitcher.Id && atBat.AtBatResult == AtBat.AtBatType.HomeRun).Count();

            PitcherIPToday.Text = Math.Round(OutsToday / 3 + (double)(OutsToday % 3) / 10, 1).ToString("0.0", new CultureInfo("en-US"));
            PitcherStrikeoutsToday.Text = StrikeoutsToday.ToString();
            PitcherWalksToday.Text = WalksToday.ToString();
            PitcherHomeRunsToday.Text = HRToday.ToString();

            int TBFinThisMatch = currentMatch.AtBats.Where(atBat => atBat.AtBatResult != AtBat.AtBatType.CaughtStealing && atBat.AtBatResult != AtBat.AtBatType.StolenBase && atBat.AtBatResult != AtBat.AtBatType.CaughtStealing && atBat.Pitcher == Defense.CurrentPitcher.Id).Count();
            btnShowAvailablePitchers.Visible = !IsAutoSimulation && TBFinThisMatch >= 3 && newGameSituation.Balls == 0 && newGameSituation.Strikes == 0;

            if (Defense.CurrentPitcher.IsPinchHitter && newGameSituation.Outs == 0 && newGameSituation.Balls == 0 && newGameSituation.Strikes == 0)
            {
                timer1.Stop();
                if (MessageBox.Show("The player on mound is not a pitcher.\nWould you like to replace him?", "New pitcher", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    PitcherSubstitution();
                }
            }
        }

        private void btnBuntAttempt_Click(object sender, EventArgs e)
        {
            GenerateNewBunt();
        }

        private void lb_Runner1_Name_Click(object sender, EventArgs e)
        {
            if (!IsAutoSimulation)
            {
                if (!(lb_Runner3_Name.Visible && lb_Runner2_Name.Visible))
                {
                    newGameSituation.RunnerOnFirst.IsBaseStealingAttempt = !newGameSituation.RunnerOnFirst.IsBaseStealingAttempt;

                    if (lb_Runner2_Name.Visible)
                    {
                        newGameSituation.RunnerOnSecond.IsBaseStealingAttempt = true;
                    }
                }
            }
            lb_Runner1_Name.ForeColor = newGameSituation.RunnerOnFirst.IsBaseStealingAttempt ? Color.DarkGoldenrod : Color.Gainsboro;
            lb_Runner2_Name.ForeColor = newGameSituation.RunnerOnSecond.IsBaseStealingAttempt ? Color.DarkGoldenrod : Color.Gainsboro;
        }

        private void lb_Runner2_Name_Click(object sender, EventArgs e)
        {
            if (!IsAutoSimulation)
            {
                if (!lb_Runner3_Name.Visible)
                {
                    newGameSituation.RunnerOnSecond.IsBaseStealingAttempt = !newGameSituation.RunnerOnSecond.IsBaseStealingAttempt;
                }
            }
            lb_Runner2_Name.ForeColor = newGameSituation.RunnerOnSecond.IsBaseStealingAttempt ? Color.DarkGoldenrod : Color.Gainsboro;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK && !DeleteThisMatch)
            {
                e.Cancel = true;
                if (MessageBox.Show("Do you want to close this window?\nThis match will be deleted from database", "Graduation paper", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DeleteThisMatch = true;
                    Dispose();
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
            PitcherSubstitution();
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
            BatterSubstitution();
        }

        private void BatterSubstitution()
        {
            timer1.Stop();
            Team Offense = newGameSituation.Offense;
            var batters = playerBL.GetAvailableBatters(currentMatch, Offense, GetBatterByGameSituation(newGameSituation));
            if (batters.Count > 0)
            {
                SubstitutionForm form = new SubstitutionForm(Offense, batters);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    Batter oldBatter = GetBatterByGameSituation(newGameSituation);
                    playerBL.SubstituteBatter(currentMatch, Offense, oldBatter, form.NewBatterForThisTeam);
                    currentMatch.AwayTeam.BattingLineup = playerBL.GetCurrentLineupForThisMatch(Offense.TeamAbbreviation, currentMatch.MatchID);
                    if (!currentMatch.DHRule && oldBatter.NumberInBattingLineup == 9)
                    {
                        Pitcher newPitcher = (Pitcher)playerBL.GetPlayerByCode(form.NewBatterForThisTeam.Id);
                        Offense.PitchersPlayedInMatch.Add(newPitcher);
                    }
                    playerBL.UpdateStatsForThisPitcher(Offense.CurrentPitcher, currentMatch);
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
            panel1Base.Location = new Point(ClientSize.Width - 211, ClientSize.Height / 2 - 30);
            RunnerOn1Photo.Location = new Point(ClientSize.Width - 278, ClientSize.Height / 2 - 30);

            panel3Base.Location = new Point(79, ClientSize.Height / 2 - 30);
            RunnerOn3Photo.Location = new Point(12, ClientSize.Height / 2 - 30);

            RunnerOn2Photo.Location = new Point(ClientSize.Width / 2 - 132, 144);
            panel2Base.Location = new Point(ClientSize.Width / 2 - 65, 144);

            btnNewPitch.Location = new Point(panel1.Width / 2 - 303, 10);
            btnBuntAttempt.Location = new Point(panel1.Width / 2 + 3, 10);
            btnManualMode.Location = new Point(ClientSize.Width / 2 - 298, ClientSize.Height - 291);
            btnAutoMode.Location = new Point(ClientSize.Width / 2 + 8, ClientSize.Height - 291);

            label28.Visible = ClientSize.Width > 1480;
            awayLOB.Visible = ClientSize.Width > 1480;
            homeLOB.Visible = ClientSize.Width > 1480;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool IsBunt;
            Team Defense = newGameSituation.Offense == currentMatch.AwayTeam ? currentMatch.HomeTeam : currentMatch.AwayTeam;
            if (IsAutoSimulation)
            {
                int TBFinThisMatch = currentMatch.AtBats.Where(atBat => atBat.AtBatResult != AtBat.AtBatType.CaughtStealing && atBat.AtBatResult != AtBat.AtBatType.StolenBase && atBat.AtBatResult != AtBat.AtBatType.CaughtStealing && atBat.Pitcher == Defense.CurrentPitcher.Id).Count();
                if (TBFinThisMatch >= 3 && newGameSituation.Balls == 0 && newGameSituation.Strikes == 0)
                {
                    PitcherSubstion_Definition(Defense.CurrentPitcher);
                }
                BasesStealingAttempt_Definition();
                if (!newGameSituation.RunnerOnFirst.IsBaseStealingAttempt && !newGameSituation.RunnerOnSecond.IsBaseStealingAttempt &&
                    (newGameSituation.RunnerOnFirst.IsBaseNotEmpty || newGameSituation.RunnerOnSecond.IsBaseNotEmpty || newGameSituation.RunnerOnThird.IsBaseNotEmpty))
                {
                    IsBunt = BuntAttemptDefinition();
                }
                else
                {
                    IsBunt = false;
                }
                if (IsBunt)
                {
                    GenerateNewBunt();
                }
                else
                {
                    GenerateNewPitch();
                }
            }
        }

        private void PitcherSubstion_Definition(Pitcher pitcher)
        {
            RandomGenerators.PitcherSubstitution pitcherSubstion = RandomGenerators.PitcherSubstitution_Definition(pitcher, currentMatch.AtBats);
            if (pitcherSubstion == RandomGenerators.PitcherSubstitution.Substitution)
            {
                PitcherSubstitution(IsAutoSimulation);
            }
        }

        private void btnAutoMode_Click(object sender, EventArgs e)
        {
            SimulationModeChanged(true);
        }

        private void SimulationModeChanged(bool isAutoSim)
        {
            IsAutoSimulation = isAutoSim;
            timer1.Enabled = isAutoSim;
            btnNewPitch.Enabled = !isAutoSim;
            btnBuntAttempt.Enabled = !isAutoSim;
            btnManualMode.BackColor = IsAutoSimulation ? Color.DimGray : Color.Gainsboro;
            btnAutoMode.BackColor = !IsAutoSimulation ? Color.DimGray : Color.Gainsboro;
            panel1.Visible = !IsAutoSimulation;
        }

        private void GenerateNewBunt()
        {
            Pitch pitch = new Pitch(newGameSituation, currentMatch.AwayTeam, currentMatch.HomeTeam);
            AddnewGameSituation(pitch);
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            Color borderColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(panel9.BackColor, false);
            ControlPaint.DrawBorder(e.Graphics, panel9.ClientRectangle, borderColor, ButtonBorderStyle.Solid);
        }

        private void btnManualMode_Click(object sender, EventArgs e)
        {
            SimulationModeChanged(false);
        }

        private void PitcherSubstitution()
        {
            Team Defense = newGameSituation.Offense == currentMatch.AwayTeam ? currentMatch.HomeTeam : currentMatch.AwayTeam;
            var pitchers = playerBL.GetAvailablePitchers(currentMatch, Defense);
            if (pitchers.Count > 0)
            {
                PitcherSubstitutionForm form = new PitcherSubstitutionForm(Defense, pitchers);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    playerBL.SubstitutePitcher(currentMatch, Defense, form.NewPitcherForThisTeam);
                    if (Defense.TeamAbbreviation == currentMatch.AwayTeamAbbreviation)
                    {
                        currentMatch.AwayTeam.BattingLineup = playerBL.GetCurrentLineupForThisMatch(currentMatch.AwayTeam.TeamAbbreviation, currentMatch.MatchID);
                        playerBL.UpdateStatsForThisPitcher(currentMatch.AwayTeam.CurrentPitcher, currentMatch);
                    }
                    else
                    {
                        currentMatch.HomeTeam.BattingLineup = playerBL.GetCurrentLineupForThisMatch(currentMatch.HomeTeam.TeamAbbreviation, currentMatch.MatchID);
                        playerBL.UpdateStatsForThisPitcher(currentMatch.HomeTeam.CurrentPitcher, currentMatch);
                    }
                    Defense.PitchersPlayedInMatch.Add(form.NewPitcherForThisTeam);
                    DisplayingCurrentSituation(newGameSituation);
                    DisplayPitcherStats();
                    if (IsAutoSimulation)
                    {
                        SimulationModeChanged(pb_stamina.Value > 25 && int.Parse(lbPitchCountForThisPitcher.Text) < 105);
                    }
                }
            }
            else
            {
                ErrorForm form = new ErrorForm();
                form.ShowDialog();
            }
        }

        private void PitcherSubstitution(bool isAutoSimulation)
        {
            timer1.Stop();
            Team Defense = newGameSituation.Offense == currentMatch.AwayTeam ? currentMatch.HomeTeam : currentMatch.AwayTeam;
            var pitchers = playerBL.GetAvailablePitchers(currentMatch, Defense);
            if (pitchers.Count > 0)
            {
                var closer = pitchers.Where(pitcher => pitcher.pitchingStats.Saves == pitchers.Max(pitcher1 => pitcher1.pitchingStats.Saves)).First();
                Pitcher newPitcher;
                if (pitchers.Count > 1)
                {
                    if (newGameSituation.InningNumber < 9)
                    {
                        newPitcher = pitchers.Where(pitcher => pitcher.RemainingStamina == pitchers.Min(pitcher1 => pitcher1.RemainingStamina)).First();
                    }
                    else
                    {
                        newPitcher = closer;
                    }
                }
                else
                {
                    newPitcher = closer;
                }
                playerBL.SubstitutePitcher(currentMatch, Defense, newPitcher);
                if (Defense.TeamAbbreviation == currentMatch.AwayTeamAbbreviation)
                {
                    currentMatch.AwayTeam.BattingLineup = playerBL.GetCurrentLineupForThisMatch(currentMatch.AwayTeam.TeamAbbreviation, currentMatch.MatchID);
                    playerBL.UpdateStatsForThisPitcher(currentMatch.AwayTeam.CurrentPitcher, currentMatch);
                }
                else
                {
                    currentMatch.HomeTeam.BattingLineup = playerBL.GetCurrentLineupForThisMatch(currentMatch.HomeTeam.TeamAbbreviation, currentMatch.MatchID);
                    playerBL.UpdateStatsForThisPitcher(currentMatch.HomeTeam.CurrentPitcher, currentMatch);
                }
                Defense.PitchersPlayedInMatch.Add(newPitcher);
                DisplayingCurrentSituation(newGameSituation);
                DisplayPitcherStats();
                SimulationModeChanged(pb_stamina.Value > 25 && int.Parse(lbPitchCountForThisPitcher.Text) < 105);
            }
            timer1.Start();
        }
    }
}