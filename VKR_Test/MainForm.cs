using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
        TeamsBL teamsBL;
        MatchBL matchBL;
        public bool DeleteThisMatch;

        public MainForm(Match match)
        {
            InitializeComponent();
            teamsBL = new TeamsBL();
            matchBL = new MatchBL();
            currentMatch = match;
            StartingLineupForm lineup = new StartingLineupForm(currentMatch.AwayTeam);
            lineup.ShowDialog();
            previousSituation = currentMatch.gameSituations.Last();
            newGameSituation = new GameSituation(match.AwayTeam);
            AwayTeam_Abbreviation.Text = match.AwayTeam.TeamAbbreviation;
            HomeTeam_Abbreviation.Text = match.HomeTeam.TeamAbbreviation;
            AwayTeam_Abbreviation.BackColor = match.AwayTeam.TeamColorForThisMatch;
            HomeTeam_Abbreviation.BackColor = match.HomeTeam.TeamColorForThisMatch;
            AwayTeam_RunsScored.BackColor = Color.FromArgb((int)(match.AwayTeam.TeamColorForThisMatch.R * 0.9), (int)(match.AwayTeam.TeamColorForThisMatch.G * 0.9), (int)(match.AwayTeam.TeamColorForThisMatch.B * 0.9));
            HomeTeam_RunsScored.BackColor = Color.FromArgb((int)(match.HomeTeam.TeamColorForThisMatch.R * 0.9), (int)(match.HomeTeam.TeamColorForThisMatch.G * 0.9), (int)(match.HomeTeam.TeamColorForThisMatch.B * 0.9));
            panel4.BackColor = match.AwayTeam.TeamColorForThisMatch;
            panel5.BackColor = match.HomeTeam.TeamColorForThisMatch;

            label18.BackColor = match.AwayTeam.TeamColorForThisMatch;
            label18.Text = match.AwayTeam.TeamTitle.ToUpper();
            panel11.BackgroundImage = Image.FromFile($"BigTeamLogos/{match.AwayTeam.TeamAbbreviation}.png");
            panel12.BackgroundImage = Image.FromFile($"BigTeamLogos/{match.HomeTeam.TeamAbbreviation}.png");
            label19.Text = match.HomeTeam.TeamTitle.ToUpper();
            label19.BackColor = match.HomeTeam.TeamColorForThisMatch;

            label22.Text = $"{currentMatch.AwayTeam.Wins}-{currentMatch.AwayTeam.Losses}";
            label22.BackColor = match.AwayTeam.TeamColorForThisMatch;
            label23.Text = $"{currentMatch.HomeTeam.Wins}-{currentMatch.HomeTeam.Losses}";
            label23.BackColor = match.HomeTeam.TeamColorForThisMatch;

            AwayTeamNextBatters.BackColor = match.AwayTeam.TeamColorForThisMatch;
            away_DueUP.Text = $"{match.AwayTeam.TeamTitle.ToUpper()} - DUE UP";

            homeTeamNextBatters.BackColor = match.HomeTeam.TeamColorForThisMatch;
            home_DueUP.Text = $"{match.HomeTeam.TeamTitle.ToUpper()} - DUE UP";
            DisplayingCurrentSituation(match.gameSituations.Last());

            DisplayNextPitchers(AwayNext1, AwayNext2, AwayNext3, AwayNextNumber1, AwayNextNumber2, AwayNextNumber3, currentMatch, currentMatch.AwayTeam, AwayNext1Stats, AwayNext2Stats, AwayNext3Stats, currentMatch.gameSituations.Last());
            DisplayNextPitchers(homeNext1, homeNext2, homeNext3, homeNextNumber1, homeNextNumber2, homeNextNumber3, currentMatch, currentMatch.HomeTeam, HomeNext1Stats, HomeNext2Stats, HomeNext3Stats, currentMatch.gameSituations.Last());
        }

        private void DisplayNextPitchers(Label awayNext1, Label awayNext2, Label awayNext3, Label awayNextNumber1, Label awayNextNumber2, Label awayNextNumber3, Match currentMatch, Team team, Label Next1Stats, Label Next2Stats, Label Next3Stats, GameSituation situation)
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
            int CurrentPitcherId = gameSituation.offense.TeamAbbreviation == currentMatch.AwayTeam.TeamAbbreviation ? currentMatch.HomeTeam.CurrentPitcher.id : currentMatch.AwayTeam.CurrentPitcher.id;

            lbPitchCountForThisPitcher.Text = currentMatch.gameSituations.Where(situation => situation.PitcherID == CurrentPitcherId &&
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
            panel6.Visible = gameSituation.strikes == 0 && gameSituation.balls == 0;
            panel7.BackgroundImage = Image.FromFile($"BigTeamLogos/{gameSituation.offense.TeamAbbreviation}.png");
            panel8.BackColor = gameSituation.offense.TeamColorForThisMatch;
            Batter NextBatter = GetBatterByGameSituation(gameSituation);
            NewBatterDisplaying(NextBatter);
            DisplayNextPitchers(AwayNext1, AwayNext2, AwayNext3, AwayNextNumber1, AwayNextNumber2, AwayNextNumber3, currentMatch, currentMatch.AwayTeam, AwayNext1Stats, AwayNext2Stats, AwayNext3Stats, gameSituation);
            DisplayNextPitchers(homeNext1, homeNext2, homeNext3, homeNextNumber1, homeNextNumber2, homeNextNumber3, currentMatch, currentMatch.HomeTeam, HomeNext1Stats, HomeNext2Stats, HomeNext3Stats, gameSituation);
            DisplayPitcherStats();
            Text = $"{currentMatch.AwayTeam.TeamAbbreviation} {gameSituation.AwayTeamRuns} - {gameSituation.HomeTeamRuns} {currentMatch.HomeTeam.TeamAbbreviation} @ {currentMatch.stadium.StadiumTitle}";
            lb_Runner1_Name.ForeColor = Color.Gainsboro;
            lb_Runner2_Name.ForeColor = Color.Gainsboro;

            lb10thInning.Text = gameSituation.inningNumber <= 10 ? 10.ToString() : gameSituation.inningNumber.ToString();
            lb9thInning.Text = (int.Parse(lb10thInning.Text) - 1).ToString();
            lb8thInning.Text = (int.Parse(lb9thInning.Text) - 1).ToString();
            lb7thInning.Text = (int.Parse(lb8thInning.Text) - 1).ToString();
            lb6thInning.Text = (int.Parse(lb7thInning.Text) - 1).ToString();
            lb5thInning.Text = (int.Parse(lb6thInning.Text) - 1).ToString();
            lb4thInning.Text = (int.Parse(lb5thInning.Text) - 1).ToString();
            lb3rdInning.Text = (int.Parse(lb4thInning.Text) - 1).ToString();
            lb2ndInning.Text = (int.Parse(lb3rdInning.Text) - 1).ToString();
            lb1stInning.Text = (int.Parse(lb2ndInning.Text) - 1).ToString();

            UpdateScoreboard(away1, away2, away3, away4, away5, away6, away7, away8, away9, away10, awayRuns, awayHits, currentMatch, currentMatch.AwayTeam);
            UpdateScoreboard(home1, home2, home3, home4, home5, home6, home7, home8, home9, home10, homeRuns, homeHits, currentMatch, currentMatch.HomeTeam);
        }

        public void DisplayCurrentRunners(GameSituation situation)
        {
            panel1Base.Visible = situation.RunnerOnFirst.IsBaseNotEmpty;
            panel2Base.Visible = situation.RunnerOnSecond.IsBaseNotEmpty;
            panel3Base.Visible = situation.RunnerOnThird.IsBaseNotEmpty;

            panel1Base.BackColor = situation.offense.TeamColorForThisMatch;
            panel2Base.BackColor = situation.offense.TeamColorForThisMatch;
            panel3Base.BackColor = situation.offense.TeamColorForThisMatch;

            RunnerOn1Photo.BackgroundImage = situation.RunnerOnFirst.IsBaseNotEmpty ? Image.FromFile($"PlayerPhotos/Player{situation.RunnerOnFirst.runnerID:0000}.jpg") : null;
            RunnerOn2Photo.BackgroundImage = situation.RunnerOnSecond.IsBaseNotEmpty ? Image.FromFile($"PlayerPhotos/Player{situation.RunnerOnSecond.runnerID:0000}.jpg") : null;
            RunnerOn3Photo.BackgroundImage = situation.RunnerOnThird.IsBaseNotEmpty ? Image.FromFile($"PlayerPhotos/Player{situation.RunnerOnThird.runnerID:0000}.jpg") : null;

            if (situation.RunnerOnFirst.IsBaseNotEmpty)
            {
                Batter runneron1St = situation.offense.BattingLineup.Where(Batter => Batter.id == situation.RunnerOnFirst.runnerID).First();
                lb_Runner1_Name.Text = (runneron1St.FirstName + " " + runneron1St.SecondName).ToUpper();
            }

            if (situation.RunnerOnSecond.IsBaseNotEmpty)
            {
                Batter runneron2nd = situation.offense.BattingLineup.Where(Batter => Batter.id == situation.RunnerOnSecond.runnerID).First();
                lb_Runner2_Name.Text = (runneron2nd.FirstName + " " + runneron2nd.SecondName).ToUpper();
            }

            if (situation.RunnerOnThird.IsBaseNotEmpty)
            {
                Batter runneron3rd = situation.offense.BattingLineup.Where(Batter => Batter.id == situation.RunnerOnThird.runnerID).First();
                lb_Runner3_Name.Text = (runneron3rd.FirstName + " " + runneron3rd.SecondName).ToUpper();
            }

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
                BatterStats.Text = Hits + " for " + AtBats;
            }
            else if (currentMatch.atBats.Where(atBat => atBat.Batter == batter.id && (atBat.AtBatResult == AtBat.AtBatType.HitByPitch)).Count() > 0)
            {
                BatterStats.Text = "HBP";
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

            panel10.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{batter.id.ToString("0000")}.jpg");
            lblPlayerPosition.Text = batter.PositionForThisMatch;
            lblPlayerNumber.Text = batter.PlayerNumber.ToString();
            lblPlayerName.Text = batter.FirstName.ToUpper() + " " + batter.SecondName.ToUpper();
            label6.Text = batter.AVG.ToString("#.000", new CultureInfo("en-US"));
            label9.Text = batter.HomeRuns.ToString("N0", CultureInfo.InvariantCulture);
            label11.Text = batter.RBI.ToString("N0", CultureInfo.InvariantCulture);
            label13.Text = batter.StolenBases.ToString("N0", CultureInfo.InvariantCulture);
            label15.Text = batter.Runs.ToString("N0", CultureInfo.InvariantCulture);
            label17.Text = batter.OPS.ToString("#.000", new CultureInfo("en-US"));
        }

        private void IsHomeRun(Pitch pitch, int runs)
        {
            if (pitch.pitchResult == Pitch.PitchResult.HomeRun)
            {
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
                HomeRunCelebrationForm hr = new HomeRunCelebrationForm(newGameSituation.offense, title, GetBatterByGameSituation(newGameSituation));
                hr.ShowDialog();
            }
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
                    matchBL.AddNewAtBat(runForDB);
                }
                currentMatch.AwayTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(currentMatch.AwayTeam.TeamAbbreviation, currentMatch.MatchID);
                currentMatch.HomeTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(currentMatch.HomeTeam.TeamAbbreviation, currentMatch.MatchID);

                teamsBL.UpdateStatsForThisPitcher(currentMatch.AwayTeam.CurrentPitcher);
                teamsBL.UpdateStatsForThisPitcher(currentMatch.HomeTeam.CurrentPitcher);

                UpdateScoreboard(away1, away2, away3, away4, away5, away6, away7, away8, away9, away10, awayRuns, awayHits, currentMatch, currentMatch.AwayTeam);
                UpdateScoreboard(home1, home2, home3, home4, home5, home6, home7, home8, home9, home10, homeRuns, homeHits, currentMatch, currentMatch.HomeTeam);
            }
            newGameSituation.PrepareForNextPitch(currentMatch.gameSituations.Last(), currentMatch.AwayTeam, currentMatch.HomeTeam);
            if (currentMatch.gameSituations.Last().offense == currentMatch.AwayTeam && currentMatch.gameSituations.Last().outs == 3 && currentMatch.gameSituations.Last().inningNumber == 1)
            {
                StartingLineupForm form = new StartingLineupForm(currentMatch.HomeTeam);
                form.ShowDialog();
                DisplayPitcherStats();
            }

            DisplayingCurrentSituation(newGameSituation);
            DisplayCurrentRunners(newGameSituation);
            IsFinishOfMatch(currentMatch);
            label32.Visible = currentMatch.atBats.Count > 0;
            label44.Visible = currentMatch.atBats.Count > 0;
            if (currentMatch.atBats.Count > 0)
            {
                label44.Text = currentMatch.atBats.Where(atbat => atbat.AtBatResult != AtBat.AtBatType.Run).Last().ToString();
            }
            previousSituation = new GameSituation(newGameSituation.id, newGameSituation.inningNumber, newGameSituation.offense, newGameSituation.result, newGameSituation.balls, newGameSituation.strikes, newGameSituation.outs, newGameSituation.RunnerOnFirst, newGameSituation.RunnerOnSecond, newGameSituation.RunnerOnThird, newGameSituation.AwayTeamRuns, newGameSituation.HomeTeamRuns, newGameSituation.BatterNumber_AwayTeam, newGameSituation.BatterNumber_HomeTeam, newGameSituation.PitcherID);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Pitch pitch;
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
                            break;
                        }
                    case 2:
                        {
                            Pitch stealingThirdBaseAttempt = new Pitch(newGameSituation, Pitch.StealingType.OnlyThirdBase);
                            AddnewGameSituation(stealingThirdBaseAttempt);
                            break;
                        }
                    case 3:
                        {
                            Pitch stealingThirdBaseAttemptBeforeSecond = new Pitch(newGameSituation, Pitch.StealingType.ThirdBaseBeforeSecond);
                            AddnewGameSituation(stealingThirdBaseAttemptBeforeSecond);
                            if (currentMatch.gameSituations.Last().outs != 3)
                            {
                                Pitch stealingSecondBaseAfterThird = new Pitch(newGameSituation, Pitch.StealingType.SecondBaseAfterThird);
                                AddnewGameSituation(stealingSecondBaseAfterThird);
                            }
                            break;
                        }
                }
            }
        }

        private void IsFinishOfMatch(Match currentMatch)
        {
            if ((currentMatch.gameSituations.Last().offense == currentMatch.AwayTeam && currentMatch.gameSituations.Last().outs == 3 && currentMatch.gameSituations.Last().AwayTeamRuns < currentMatch.gameSituations.Last().HomeTeamRuns && currentMatch.gameSituations.Last().inningNumber == 9) ||
                (currentMatch.gameSituations.Last().offense == currentMatch.HomeTeam && currentMatch.gameSituations.Last().outs == 3 && currentMatch.gameSituations.Last().AwayTeamRuns > currentMatch.gameSituations.Last().HomeTeamRuns && currentMatch.gameSituations.Last().inningNumber >= 9) ||
                (currentMatch.gameSituations.Last().offense == currentMatch.HomeTeam && currentMatch.gameSituations.Last().AwayTeamRuns < currentMatch.gameSituations.Last().HomeTeamRuns && currentMatch.gameSituations.Last().inningNumber >= 9))
            {
                MatchEndingForm form = new MatchEndingForm(currentMatch);
                matchBL.FinishMatch(currentMatch);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
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
            ExtraInnings.ForeColor = newGameSituation.inningNumber > int.Parse(lb10thInning.Text) || newGameSituation.inningNumber == int.Parse(lb10thInning.Text) && DisplayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);

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
                (situation.result == Pitch.PitchResult.Ball && situation.balls == 0) ||
                (situation.result == Pitch.PitchResult.Strike && situation.strikes == 0))
            {
                switch (situation.result)
                {
                    case Pitch.PitchResult.SecondBaseStolen:
                        {
                            AtBat atBat = new AtBat(currentMatch, situation.RunnerOnSecond.runnerID, false);
                            currentMatch.atBats.Add(atBat);
                            matchBL.AddNewAtBat(atBat);
                            break;
                        }
                    case Pitch.PitchResult.ThirdBaseStolen:
                        {
                            AtBat atBat = new AtBat(currentMatch, situation.RunnerOnThird.runnerID, true);
                            currentMatch.atBats.Add(atBat);
                            matchBL.AddNewAtBat(atBat);
                            break;
                        }
                    case Pitch.PitchResult.CaughtStealingOnSecond:
                        {
                            AtBat atBat = new AtBat(currentMatch, currentMatch.gameSituations[currentMatch.gameSituations.Count - 2].RunnerOnFirst.runnerID, true);
                            currentMatch.atBats.Add(atBat);
                            matchBL.AddNewAtBat(atBat);
                            break;
                        }
                    case Pitch.PitchResult.CaughtStealingOnThird:
                        {
                            AtBat atBat = new AtBat(currentMatch, currentMatch.gameSituations[currentMatch.gameSituations.Count - 2].RunnerOnSecond.runnerID, true);
                            currentMatch.atBats.Add(atBat);
                            matchBL.AddNewAtBat(atBat);
                            break;
                        }
                    default:
                        {
                            AtBat LastAtBat = new AtBat(currentMatch, runs);
                            currentMatch.atBats.Add(LastAtBat);
                            matchBL.AddNewAtBat(LastAtBat);
                            break;
                        }
                }
                currentMatch.AwayTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(currentMatch.AwayTeam.TeamAbbreviation, currentMatch.MatchID);
                currentMatch.HomeTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(currentMatch.HomeTeam.TeamAbbreviation, currentMatch.MatchID);

                teamsBL.UpdateStatsForThisPitcher(currentMatch.AwayTeam.CurrentPitcher);
                teamsBL.UpdateStatsForThisPitcher(currentMatch.HomeTeam.CurrentPitcher);

                UpdateScoreboard(away1, away2, away3, away4, away5, away6, away7, away8, away9, away10, awayRuns, awayHits, currentMatch, currentMatch.AwayTeam);
                UpdateScoreboard(home1, home2, home3, home4, home5, home6, home7, home8, home9, home10, homeRuns, homeHits, currentMatch, currentMatch.HomeTeam);
            }
        }

        private void DisplayPitcherStats()
        {
            Team Defense = newGameSituation.offense == currentMatch.AwayTeam ? currentMatch.HomeTeam : currentMatch.AwayTeam;

            PitchingTeamColor.BackColor = Defense.TeamColorForThisMatch;
            PitchingTeam.BackgroundImage = Image.FromFile($"BigTeamLogos/{Defense.TeamAbbreviation}.png");
            PitcherPhoto.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{Defense.CurrentPitcher.id.ToString("0000")}.jpg");
            PitcherName.Text = Defense.CurrentPitcher.FirstName.ToUpper() + " " + Defense.CurrentPitcher.SecondName.ToUpper();
            PitcherGames.Text = Defense.CurrentPitcher.Games.ToString();
            PitcherBAA.Text = Defense.CurrentPitcher.BAA.ToString("#.000", new CultureInfo("en-US"));
            PitcherERA.Text = Defense.CurrentPitcher.ERA.ToString("##0.00", new CultureInfo("en-US"));
            PitcherIP.Text = Defense.CurrentPitcher.IP.ToString("0.0", new CultureInfo("en-US"));
            PitcherHomeRuns.Text = Defense.CurrentPitcher.HomeRunsAllowed.ToString();
            PitcherStrikeouts.Text = Defense.CurrentPitcher.Strikeouts.ToString();
            PitcherWalks.Text = Defense.CurrentPitcher.WalksAllowed.ToString();
            PitcherWHIP.Text = Defense.CurrentPitcher.WHIP.ToString("0.00", new CultureInfo("en-US"));

            int OutsToday = currentMatch.atBats.Where(atBat => atBat.Pitcher == Defense.CurrentPitcher.id).Select(atBat => atBat.outs).Sum();
            int StrikeoutsToday = currentMatch.atBats.Where(atBat => atBat.Pitcher == Defense.CurrentPitcher.id && atBat.AtBatResult == AtBat.AtBatType.Strikeout).Count();
            int WalksToday = currentMatch.atBats.Where(atBat => atBat.Pitcher == Defense.CurrentPitcher.id && atBat.AtBatResult == AtBat.AtBatType.Walk).Count();
            int HRToday = currentMatch.atBats.Where(atBat => atBat.Pitcher == Defense.CurrentPitcher.id && atBat.AtBatResult == AtBat.AtBatType.HomeRun).Count();

            PitcherIPToday.Text = Math.Round(OutsToday / 3 + (double)(OutsToday % 3) / 10, 1).ToString("0.0", new CultureInfo("en-US"));
            PitcherStrikeoutsToday.Text = StrikeoutsToday.ToString();
            PitcherWalksToday.Text = WalksToday.ToString();
            PitcherHomeRunsToday.Text = HRToday.ToString();
        }

        private void btnBuntAttempt_Click(object sender, EventArgs e)
        {
            Pitch pitch = new Pitch(newGameSituation, currentMatch.AwayTeam);
            AddnewGameSituation(pitch);
        }

        private void lb_Runner1_Name_Click(object sender, EventArgs e)
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

        private void lb_Runner2_Name_Click(object sender, EventArgs e)
        {
            if (!lb_Runner3_Name.Visible)
            {
                lb_Runner2_Name.ForeColor = lb_Runner2_Name.ForeColor == Color.DarkGoldenrod ? Color.Gainsboro : Color.DarkGoldenrod;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
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
            StandingsForm form = new StandingsForm(currentMatch.HomeTeam, currentMatch.AwayTeam);
            form.ShowDialog();
        }

        private void btnShowAvailablePitchers_Click(object sender, EventArgs e)
        {
            Team Defense = newGameSituation.offense == currentMatch.AwayTeam ? currentMatch.HomeTeam : currentMatch.AwayTeam;
            List<Pitcher> pitchers = teamsBL.GetAvailablePitchers(currentMatch, Defense);
            PitcherSubstitutionForm form = new PitcherSubstitutionForm(Defense, pitchers);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                teamsBL.SubstitutePitcher(currentMatch, Defense, form.newPitcherForThisTeam);
                currentMatch.AwayTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(currentMatch.AwayTeam.TeamAbbreviation, currentMatch.MatchID);
                currentMatch.HomeTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(currentMatch.HomeTeam.TeamAbbreviation, currentMatch.MatchID);

                teamsBL.UpdateStatsForThisPitcher(currentMatch.AwayTeam.CurrentPitcher);
                teamsBL.UpdateStatsForThisPitcher(currentMatch.HomeTeam.CurrentPitcher);



                Defense.PitchersPlayedInMatch.Add(form.newPitcherForThisTeam);
                DisplayingCurrentSituation(newGameSituation);
                DisplayPitcherStats();

            }
        }
    }
}