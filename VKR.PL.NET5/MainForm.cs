﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;
using VKR.EF.Entities.RandomGenerators;
using VKR.PL.Controls.NET5;
using VKR.PL.Utils.NET5;

namespace VKR.PL.NET5
{
    public partial class MainForm : Form
    {
        private readonly Match _currentMatch;
        private GameSituation _newGameSituation;
        private GameSituation _previousSituation;
        private readonly MatchBL _matchBl = new();
        private readonly PlayerBL _playerBl = new();
        private readonly SubstitutionBL _substitutionBl = new();
        public bool DeleteThisMatch;
        private bool _isAutoSimulation;
        private readonly BuntGenerator _buntGenerator = new();
        private readonly NormalPitchGenerator _normalPitchGenerator = new();
        private readonly PitchBeforeBaseStealingGenerator _pitchBeforeBaseStealingGenerator = new();
        private readonly BaseStealingGenerator _baseStealingGenerator = new();

        public MainForm(Match match)
        {
            InitializeComponent();

            _currentMatch = match;

            BatterInfo.SetMatch(_currentMatch);

            using (var lineup = new StartingLineupForm(_currentMatch.AwayTeam))
                lineup.ShowDialog();
            using (var defense = new DefenseForm(_currentMatch.HomeTeam))
                defense.ShowDialog();

            _previousSituation = _currentMatch.GameSituations.Last();
            _newGameSituation = new GameSituation(match.AwayTeam);

            PrepareForThisTeam(_currentMatch.AwayTeam, AwayTeam_Abbreviation, AwayTeam_RunsScored, label18, panel11, label22, _currentMatch, AwayTeamNextBatters, away_DueUP);
            PrepareForThisTeam(_currentMatch.HomeTeam, HomeTeam_Abbreviation, HomeTeam_RunsScored, label19, panel12, label23, _currentMatch, homeTeamNextBatters, home_DueUP);
            _ = DisplayingCurrentSituation(match.GameSituations.Last());

            DisplayNextBatters(_currentMatch, _currentMatch.AwayTeam, _currentMatch.GameSituations.Last(), awayNextBatter1, awayNextBatter2, awayNextBatter3);
            DisplayNextBatters(_currentMatch, _currentMatch.HomeTeam, _currentMatch.GameSituations.Last(), homeNextBatter1, homeNextBatter2, homeNextBatter3);
            pb_stamina.Value = (int)_currentMatch.HomeTeam.CurrentPitcher.RemainingStamina;
            SimulationModeChanged(!match.IsQuickMatch);
        }

        private static void PrepareForThisTeam(Team team, Control teamAbbreviation, Control runsScored, Control teamTitle, Control TeamLogo, Control teamBalance, Match match, Control NextBatters, Control NextBattersHeader)
        {
            teamAbbreviation.Text = team.TeamAbbreviation;
            teamAbbreviation.BackColor = team.TeamColorForThisMatch;
            runsScored.BackColor = Color.FromArgb((int)(team.TeamColorForThisMatch.R * 0.9), (int)(team.TeamColorForThisMatch.G * 0.9), (int)(team.TeamColorForThisMatch.B * 0.9));
            teamTitle.Text = team.TeamName.ToUpper();
            teamTitle.BackColor = team.TeamColorForThisMatch;
            TeamLogo.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/SmallTeamLogos/{team.TeamAbbreviation}.png");
            teamBalance.Text = $@"{team.Wins}-{team.Losses}";
            teamBalance.BackColor = team.TeamColorForThisMatch;
            teamBalance.Visible = !match.IsQuickMatch;
            NextBatters.BackColor = team.TeamColorForThisMatch;
            NextBattersHeader.Text = $"{team.TeamName.ToUpper()} - DUE UP";
        }

        private void DisplayNextBatters(MatchBaseClass currentMatch, Team team, GameSituation situation, params BatterInfo[] batters)
        {
            int GetNextNumber(int previousNumber) => previousNumber < 9 ? previousNumber + 1 : 1;

            var number = currentMatch.AwayTeam == team ? situation.NumberOfBatterFromAwayTeam : situation.NumberOfBatterFromHomeTeam;

            if (situation.Offense != team) number--;

            foreach (var batterInfo in batters)
            {
                var nextNumber = GetNextNumber(number);

                batterInfo.Batter = team.BattingLineup[nextNumber - 1];
                number = nextNumber;
            }
        }

        private async Task DisplayingCurrentSituation(GameSituation gameSituation)
        {
            label1.Text = gameSituation.Offense == _currentMatch.AwayTeam ? "▲" : "▼";

            label2.Text = gameSituation.InningNumber.ToString();
            label3.Text = gameSituation.Outs.ToString();
            label4.Text = gameSituation.Outs <= 1 ? "Out" : "Outs";
            label5.Text = $"{gameSituation.Balls}-{gameSituation.Strikes}";
            lbPitcherSecondName.Text = gameSituation.Offense == _currentMatch.AwayTeam ? _currentMatch.HomeTeam.CurrentPitcher.SecondName : _currentMatch.AwayTeam.CurrentPitcher.SecondName;
            var currentPitcher = gameSituation.Offense.TeamAbbreviation == _currentMatch.AwayTeam.TeamAbbreviation ? _currentMatch.HomeTeam.CurrentPitcher : _currentMatch.AwayTeam.CurrentPitcher;

            lbPitchCountForThisPitcher.Text = _currentMatch.GameSituations.Count(situation => situation.PitcherID == currentPitcher.PitcherId &&
                !GameSituation.BaseStealingResults.Contains(situation.Result)).ToString();

            var basesImagesDictionary = new Dictionary<int, Image>
            {
                {0, Properties.Resources._000},
                {1, Properties.Resources._100 },
                {2, Properties.Resources._020 },
                {3, Properties.Resources._120 },
                {4, Properties.Resources._003 },
                {5, Properties.Resources._103 },
                {6, Properties.Resources._023 },
                {7, Properties.Resources._123 },
            };

            var currentSituationOnBases = Convert.ToInt32(gameSituation.RunnerOnFirst.IsBaseNotEmpty) + Convert.ToInt32(gameSituation.RunnerOnSecond.IsBaseNotEmpty) * 2 + Convert.ToInt32(gameSituation.RunnerOnThird.IsBaseNotEmpty) * 4;
            panel3.BackgroundImage = basesImagesDictionary[currentSituationOnBases];

            AwayTeam_RunsScored.Text = gameSituation.AwayTeamRuns.ToString();
            HomeTeam_RunsScored.Text = gameSituation.HomeTeamRuns.ToString();

            panelCurrentBatter.Visible = gameSituation.Strikes == 0 && gameSituation.Balls == 0;

            panel8.BackColor = gameSituation.Offense.TeamColorForThisMatch;
            btnChangeBatter.BackColor = Color.FromArgb((int)(gameSituation.Offense.TeamColorForThisMatch.R * 0.9), (int)(gameSituation.Offense.TeamColorForThisMatch.G * 0.9), (int)(gameSituation.Offense.TeamColorForThisMatch.B * 0.9));

            pbCurrentOffenseLogo.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/SmallTeamLogos/{_newGameSituation.Offense.TeamAbbreviation}.png");
            var nextBatter = GetBatterByGameSituation(gameSituation);
            NewBatterDisplaying(nextBatter);

            DisplayNextBatters(_currentMatch, _currentMatch.AwayTeam, gameSituation, awayNextBatter1, awayNextBatter2, awayNextBatter3);
            DisplayNextBatters(_currentMatch, _currentMatch.HomeTeam, gameSituation, homeNextBatter1, homeNextBatter2, homeNextBatter3);

            await DisplayPitcherStats();
            Text = $"{_currentMatch.AwayTeam.TeamAbbreviation} {gameSituation.AwayTeamRuns} - {gameSituation.HomeTeamRuns} {_currentMatch.HomeTeam.TeamAbbreviation} @ {_currentMatch.Stadium.StadiumTitle}";

            lb9thInning.Text = gameSituation.InningNumber <= 9 ? 9.ToString() : gameSituation.InningNumber.ToString();
            lb8thInning.Text = (int.Parse(lb9thInning.Text) - 1).ToString();
            lb7thInning.Text = (int.Parse(lb8thInning.Text) - 1).ToString();
            lb6thInning.Text = (int.Parse(lb7thInning.Text) - 1).ToString();
            lb5thInning.Text = (int.Parse(lb6thInning.Text) - 1).ToString();
            lb4thInning.Text = (int.Parse(lb5thInning.Text) - 1).ToString();
            lb3rdInning.Text = (int.Parse(lb4thInning.Text) - 1).ToString();
            lb2ndInning.Text = (int.Parse(lb3rdInning.Text) - 1).ToString();
            lb1stInning.Text = (int.Parse(lb2ndInning.Text) - 1).ToString();

            UpdateScoreboard(away2, away3, away4, away5, away6, away7, away8, away9, away10, awayLOB, awayRuns, awayHits, _currentMatch, _currentMatch.AwayTeam);
            UpdateScoreboard(home2, home3, home4, home5, home6, home7, home8, home9, home10, homeLOB, homeRuns, homeHits, _currentMatch, _currentMatch.HomeTeam);
        }

        public void DisplayCurrentRunners(GameSituation situation)
        {
            RunnerOnBase_Displaying(situation.RunnerOnFirst, lb_Runner1_Name, RunnerOn1Photo, situation.Offense, situation, panel1Base, lb1stBase);
            RunnerOnBase_Displaying(situation.RunnerOnSecond, lb_Runner2_Name, RunnerOn2Photo, situation.Offense, situation, panel2Base, lb2ndBase);
            RunnerOnBase_Displaying(situation.RunnerOnThird, lb_Runner3_Name, RunnerOn3Photo, situation.Offense, situation, panel3Base, lb3rdBase);
        }

        private static void RunnerOnBase_Displaying(Runner runner, Label RunnerName, Panel RunnerPhoto, Team offense, GameSituation situation, Panel basePanel, Label panelHeader)
        {
            basePanel.Visible = runner.IsBaseNotEmpty;
            panelHeader.BackColor = situation.Offense.TeamColorForThisMatch;
            if (runner.IsBaseNotEmpty)
            {
                var runneron3rd = offense.BattingLineup.First(batter => batter.BatterId == runner.RunnerId);
                RunnerName.Text = runneron3rd.FullName.ToUpper();

                RunnerPhoto.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/PlayerPhotos/Player{runneron3rd.Id:0000}.png");
                RunnerName.ForeColor = runner.IsBaseStealingAttempt ? Color.Goldenrod : Color.Gainsboro;
            }
            else RunnerPhoto.BackgroundImage = null;
        }

        private Batter GetBatterByGameSituation(GameSituation gameSituation)
        {
            return gameSituation.Offense == _currentMatch.AwayTeam
                ? _currentMatch.AwayTeam.BattingLineup[gameSituation.NumberOfBatterFromAwayTeam - 1]
                : _currentMatch.HomeTeam.BattingLineup[gameSituation.NumberOfBatterFromHomeTeam - 1];
        }

        private void NewBatterDisplaying(Batter batter)
        {
            currentBatter.Batter = batter;

            ShowStatsForThisMatch(batter, lbTodayStats);
            pbCurrentBatterPhoto.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/PlayerPhotos/Player{batter.Id:0000}.png");

            lblPlayerPosition.Text = batter.PositionForThisMatch;
            lblPlayerNumber.Text = batter.PlayerNumber.ToString();
            lblPlayerName.Text = batter.FullName.ToUpper();
            label6.Text = batter.BattingStats.AVG.ToString("#.000", new CultureInfo("en-US"));
            label9.Text = batter.BattingStats.HomeRuns.ToString("N0", CultureInfo.InvariantCulture);
            label11.Text = batter.BattingStats.RBI.ToString("N0", CultureInfo.InvariantCulture);
            label13.Text = batter.BattingStats.StolenBases.ToString("N0", CultureInfo.InvariantCulture);
            label15.Text = batter.BattingStats.Runs.ToString("N0", CultureInfo.InvariantCulture);
            batterOPSValue.Text = batter.BattingStats.OPS.ToString("#.000", new CultureInfo("en-US"));
        }

        private void ShowStatsForThisMatch(Batter batter, Control lbTodayStats)
        {
            void AddNewStatsForTodayStatsLabel(int value, string text, Control lb)
            {
                if (value <= 0) return;

                var valueWithText = value > 1 ? $"{value} {text}" : $"{text}";

                lb.Text += lb.Text == "►TODAY: " ? $"{valueWithText}" : $", {valueWithText}";
            }

            var atBatsForThisBatter = _currentMatch.AtBats.Where(atBat => atBat.BatterId == batter.Id).ToList();

            var HBPs = atBatsForThisBatter.Count(atBat => atBat.AtBatType == AtBatType.HitByPitch);
            var BBs = atBatsForThisBatter.Count(atBat => atBat.AtBatType == AtBatType.Walk);
            var SFs = atBatsForThisBatter.Count(atBat => atBat.AtBatType == AtBatType.SacrificeFly);
            var SACs = atBatsForThisBatter.Count(atBat => atBat.AtBatType == AtBatType.SacrificeBunt);
            var Rs = atBatsForThisBatter.Count(atBat => atBat.AtBatType == AtBatType.Run);
            var HRs = atBatsForThisBatter.Count(atBat => atBat.AtBatType == AtBatType.HomeRun);
            var Ks = atBatsForThisBatter.Count(atBat => atBat.AtBatType == AtBatType.Strikeout);
            var RBIs = atBatsForThisBatter.Sum(atBat => atBat.RBI);
            var SBs = atBatsForThisBatter.Count(atBat => atBat.AtBatType == AtBatType.StolenBase);
            lbTodayStats.Text = "►TODAY: ";

            var hitsForAtBats = HitsForAtBatsHelper.GetHitsForAtBats(batter, _currentMatch);

            if (!string.IsNullOrEmpty(hitsForAtBats)) lbTodayStats.Text += hitsForAtBats;

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
        }

        private void IsHomeRun(int runs)
        {
            timer1.Stop();

            var title = runs switch
            {
                1 => "Solo home run",
                4 => "Grand Slam",
                _ => $"{runs}-run Home Run"
            };

            if (_newGameSituation.InningNumber >= 9 && _newGameSituation.Offense == _currentMatch.HomeTeam && _newGameSituation.AwayTeamRuns < _newGameSituation.HomeTeamRuns)
                title = "Walk-off " + title.ToLower();

            using (var hr = new HomeRunCelebrationForm(_newGameSituation.Offense, title, GetBatterByGameSituation(_newGameSituation), _currentMatch.AtBats, _currentMatch.IsQuickMatch))
                hr.ShowDialog();

            if (_isAutoSimulation) timer1.Start();
        }

        private async Task GetCurrentStatsForThisMatch()
        {
            var awayTeamLineupTask = _playerBl.GetCurrentLineupForThisMatch(_currentMatch.AwayTeam, _currentMatch);
            var homeTeamLineupTask = _playerBl.GetCurrentLineupForThisMatch(_currentMatch.HomeTeam, _currentMatch);

            await Task.WhenAll(awayTeamLineupTask, homeTeamLineupTask);
            (_currentMatch.AwayTeam.BattingLineup, _currentMatch.HomeTeam.BattingLineup) =
                (awayTeamLineupTask.Result, homeTeamLineupTask.Result);

            var awayTeamPitcherTask = _playerBl.UpdateStatsForThisPitcher(_currentMatch.AwayTeam.CurrentPitcher, _currentMatch);
            var homeTeamPitcherTask = _playerBl.UpdateStatsForThisPitcher(_currentMatch.HomeTeam.CurrentPitcher, _currentMatch);

            await Task.WhenAll(awayTeamPitcherTask, homeTeamPitcherTask);

            UpdateScoreboard(away2, away3, away4, away5, away6, away7, away8, away9, away10, awayLOB, awayRuns, awayHits, _currentMatch, _currentMatch.AwayTeam);
            UpdateScoreboard(home2, home3, home4, home5, home6, home7, home8, home9, home10, homeLOB, homeRuns, homeHits, _currentMatch, _currentMatch.HomeTeam);
        }

        private async Task AddNewGameSituation(Pitch pitch)
        {
            _newGameSituation = new GameSituation(pitch, _previousSituation, _currentMatch);

            _currentMatch.GameSituations.Add(_newGameSituation.Clone());

            if (pitch.NewPitchResult == EF.Entities.Enums.PitchResult.HomeRun) IsHomeRun(_newGameSituation.RunsByThisPitch.Count);

            await IsAtBatFinished(_currentMatch.GameSituations.Last());

            if (_newGameSituation.RunsByThisPitch.Count != 0)
            {
                foreach (var runForDB in _newGameSituation.RunsByThisPitch.Select(runner => new Run(runner, _currentMatch)))
                {
                    _currentMatch.Runs.Add(runForDB);
                    await _matchBl.AddNewRun(runForDB);
                }

                await GetCurrentStatsForThisMatch();
            }

            _newGameSituation.PrepareForNextPitch(_currentMatch.GameSituations.Last(), _currentMatch.AwayTeam, _currentMatch.HomeTeam, _currentMatch.MatchLength);

            if (_currentMatch.GameSituations.Last().Offense == _currentMatch.AwayTeam && _currentMatch.GameSituations.Last().Outs == 3 && _currentMatch.GameSituations.Last().InningNumber == 1)
            {
                timer1.Stop();
                var form = new StartingLineupForm(_currentMatch.HomeTeam);
                form.ShowDialog();
                var defense = new DefenseForm(_currentMatch.AwayTeam);
                defense.ShowDialog();
                await DisplayPitcherStats();

                if (_isAutoSimulation) timer1.Start();
            }

            await DisplayingCurrentSituation(_newGameSituation);

            if (_newGameSituation.Strikes == 0 && _newGameSituation.Balls == 0)
                DisplayCurrentRunners(_newGameSituation);

            await IsFinishOfMatch(_currentMatch);

            panelLastAtBat.Visible = _currentMatch.AtBats.Count > 0;

            if (_currentMatch.AtBats.Count > 0)
            {
                var lastAtBat = _currentMatch.AtBats.Last(atBat => atBat.AtBatType != AtBatType.Run);

                var lastAtBatOffense = lastAtBat.Offense;
                label27.BackColor = lastAtBatOffense == _currentMatch.AwayTeam.TeamAbbreviation ? _currentMatch.AwayTeam.TeamColorForThisMatch : _currentMatch.HomeTeam.TeamColorForThisMatch;
                panel15.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/SmallTeamLogos/{lastAtBatOffense}.png");

                var lastBatter = await _playerBl.GetPlayerByCode(lastAtBat.BatterId);
                label27.Text = Width >= 960 ? lastBatter.FullName : $"{lastBatter.FirstName[0]}. {lastBatter.SecondName}";
                label44.Text = lastAtBat.ToString();
            }

            _previousSituation = _newGameSituation.Clone();
        }

        private async void button1_Click(object sender, EventArgs e) => await GenerateNewPitch();

        private void BasesStealingAttempt_Definition()
        {
            BaseStealingGenerator.StealingAttempt secondBaseStealingAttempt;
            if (_newGameSituation.RunnerOnSecond.IsBaseNotEmpty && !_newGameSituation.RunnerOnThird.IsBaseNotEmpty)
            {
                var thirdBaseStealingAttempt = _baseStealingGenerator.StealingAttemptDefinition(BaseStealingGenerator.BaseNumberForStealing.Third, _newGameSituation, _currentMatch.AwayTeam);
                if (thirdBaseStealingAttempt == BaseStealingGenerator.StealingAttempt.Attempt)
                {
                    _newGameSituation.RunnerOnSecond.IsBaseStealingAttempt = true;
                    if (_newGameSituation.RunnerOnFirst.IsBaseNotEmpty && _newGameSituation.RunnerOnSecond.IsBaseNotEmpty)
                    {
                        secondBaseStealingAttempt = _baseStealingGenerator.StealingAttemptDefinition(BaseStealingGenerator.BaseNumberForStealing.Second, _newGameSituation, _currentMatch.AwayTeam);
                        if (secondBaseStealingAttempt == BaseStealingGenerator.StealingAttempt.Attempt)
                            _newGameSituation.RunnerOnFirst.IsBaseStealingAttempt = true;
                    }
                }
            }

            if (!_newGameSituation.RunnerOnFirst.IsBaseNotEmpty ||
                _newGameSituation.RunnerOnSecond.IsBaseNotEmpty) return;

            secondBaseStealingAttempt = _baseStealingGenerator.StealingAttemptDefinition(BaseStealingGenerator.BaseNumberForStealing.Second, _newGameSituation, _currentMatch.AwayTeam);

            if (secondBaseStealingAttempt == BaseStealingGenerator.StealingAttempt.Attempt)
                _newGameSituation.RunnerOnFirst.IsBaseStealingAttempt = true;
        }

        private bool BuntAttemptDefinition()
        {
            var buntAttempt = RandomGenerators.BuntAttempt_Definition(_newGameSituation, _currentMatch.AwayTeam, _currentMatch.AtBats);
            return buntAttempt == RandomGenerators.BuntAttempt.Attempt;
        }

        private async Task GenerateNewPitch()
        {
            Pitch pitch;

            var stealingAttempt = (_newGameSituation.RunnerOnFirst.IsBaseStealingAttempt || _newGameSituation.RunnerOnSecond.IsBaseStealingAttempt) && _newGameSituation.Outs < 2;
            var countOfAtBats = _currentMatch.AtBats.Count;
            var typeOfStealing = 0;

            if (stealingAttempt)
            {
                pitch = _pitchBeforeBaseStealingGenerator.CreatePitch(_newGameSituation, _currentMatch);

                if (_newGameSituation.RunnerOnFirst.IsBaseStealingAttempt)
                    typeOfStealing = _newGameSituation.RunnerOnSecond.IsBaseStealingAttempt ? 3 : 1;
                else if (_newGameSituation.RunnerOnSecond.IsBaseStealingAttempt) typeOfStealing = 2;
            }
            else pitch = _normalPitchGenerator.CreatePitch(_newGameSituation, _currentMatch);

            await AddNewGameSituation(pitch);
            var newCountOfAtBats = _currentMatch.AtBats.Count;

            if (!stealingAttempt || countOfAtBats != newCountOfAtBats) return;

            switch (typeOfStealing)
            {
                case 1:
                    await BaseStealing(BaseStealingGenerator.StealingType.OnlySecondBase);
                    break;
                case 2:
                    await BaseStealing(BaseStealingGenerator.StealingType.OnlyThirdBase);
                    break;
                case 3:
                    {
                        await BaseStealing(BaseStealingGenerator.StealingType.ThirdBaseBeforeSecond);
                        if (_currentMatch.GameSituations.Last().Outs != 3)
                            await BaseStealing(BaseStealingGenerator.StealingType.SecondBaseAfterThird);
                        break;
                    }
            }
        }

        private async Task BaseStealing(BaseStealingGenerator.StealingType stealingType)
        {
            var pitch = _baseStealingGenerator.CreateBaseStealing(_newGameSituation, stealingType);
            await AddNewGameSituation(pitch);
            DisplayCurrentRunners(_newGameSituation);
        }

        private async Task IsFinishOfMatch(Match currentMatch)
        {
            if (!currentMatch.MatchEndingCondition) return;

            using var form = new MatchEndingForm(currentMatch);
            await _matchBl.FinishMatch(currentMatch);
            timer1.Dispose();
            Visible = false;
            form.ShowDialog();

            if (form.DialogResult != DialogResult.OK) return;

            DialogResult = DialogResult.OK;
            Hide();
        }

        private void UpdateScoreboard(Label firstInning, Label secondInning, Label thirdInning, Label fourthInning, Label fifthInning, Label sixthInning, Label seventhInning, Label eigthInning, Label ninthInning, Label leftOnBase, Label runs, Label hits, Match match, Team team)
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

            var leftOnFirstBase = match.GameSituations.Count(gs => gs.Outs == 3 && gs.Offense.TeamAbbreviation == team.TeamAbbreviation && gs.RunnerOnFirst.IsBaseNotEmpty);
            var leftOnSecondBase = match.GameSituations.Count(gs => gs.Outs == 3 && gs.Offense.TeamAbbreviation == team.TeamAbbreviation && gs.RunnerOnSecond.IsBaseNotEmpty);
            var leftOnThirdBase = match.GameSituations.Count(gs => gs.Outs == 3 && gs.Offense.TeamAbbreviation == team.TeamAbbreviation && gs.RunnerOnThird.IsBaseNotEmpty);

            leftOnBase.Text = (leftOnFirstBase + leftOnSecondBase + leftOnThirdBase).ToString();

            var displayingCriterion = team == _currentMatch.AwayTeam ? _newGameSituation.Offense == _currentMatch.AwayTeam || _newGameSituation.Offense == _currentMatch.HomeTeam : _newGameSituation.Offense == _currentMatch.HomeTeam;

            firstInning.ForeColor = _newGameSituation.InningNumber > int.Parse(lb1stInning.Text) || _newGameSituation.InningNumber == int.Parse(lb1stInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            secondInning.ForeColor = _newGameSituation.InningNumber > int.Parse(lb2ndInning.Text) || _newGameSituation.InningNumber == int.Parse(lb2ndInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            thirdInning.ForeColor = _newGameSituation.InningNumber > int.Parse(lb3rdInning.Text) || _newGameSituation.InningNumber == int.Parse(lb3rdInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            fourthInning.ForeColor = _newGameSituation.InningNumber > int.Parse(lb4thInning.Text) || _newGameSituation.InningNumber == int.Parse(lb4thInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            fifthInning.ForeColor = _newGameSituation.InningNumber > int.Parse(lb5thInning.Text) || _newGameSituation.InningNumber == int.Parse(lb5thInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            sixthInning.ForeColor = _newGameSituation.InningNumber > int.Parse(lb6thInning.Text) || _newGameSituation.InningNumber == int.Parse(lb6thInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            seventhInning.ForeColor = _newGameSituation.InningNumber > int.Parse(lb7thInning.Text) || _newGameSituation.InningNumber == int.Parse(lb7thInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            eigthInning.ForeColor = _newGameSituation.InningNumber > int.Parse(lb8thInning.Text) || _newGameSituation.InningNumber == int.Parse(lb8thInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);
            ninthInning.ForeColor = _newGameSituation.InningNumber > int.Parse(lb9thInning.Text) || _newGameSituation.InningNumber == int.Parse(lb9thInning.Text) && displayingCriterion ? Color.White : Color.FromArgb(48, 48, 48);

            runs.Text = match.AtBats.Where(atBat => atBat.Offense == team.TeamAbbreviation).Sum(atBat => atBat.RBI).ToString();
            hits.Text = match.AtBats.Count(atBat => atBat.Offense == team.TeamAbbreviation && atBat.AtBatType is AtBatType.Single or AtBatType.Double or AtBatType.Triple or AtBatType.HomeRun).ToString();
        }

        private async Task IsAtBatFinished(GameSituation situation)
        {
            if (!GameSituation.AtBatEndingConditions.Contains(situation.Result) &&
                !GameSituation.BaseStealingResults.Contains(situation.Result) &&
                (situation.Result != EF.Entities.Enums.PitchResult.Ball || situation.Balls != 0) &&
                (situation.Result != EF.Entities.Enums.PitchResult.Strike || situation.Strikes != 0)) return;

            var newAtBat = situation.Result switch
            {
                EF.Entities.Enums.PitchResult.SecondBaseStolen => new AtBat(_currentMatch, situation.RunnerOnSecond.RunnerId, true),
                EF.Entities.Enums.PitchResult.ThirdBaseStolen => new AtBat(_currentMatch, situation.RunnerOnThird.RunnerId, true),
                EF.Entities.Enums.PitchResult.CaughtStealingOnSecond => new AtBat(_currentMatch, _currentMatch.GameSituations[^2].RunnerOnFirst.RunnerId, true),
                EF.Entities.Enums.PitchResult.CaughtStealingOnThird => new AtBat(_currentMatch, _currentMatch.GameSituations[^2].RunnerOnSecond.RunnerId, true),
                _ => new AtBat(_currentMatch, (byte)_newGameSituation.RunsByThisPitch.Count)
            };

            _currentMatch.AtBats.Add(newAtBat);
            await _matchBl.AddNewAtBat(newAtBat);
            await GetCurrentStatsForThisMatch();
        }

        private async Task DisplayPitcherStats()
        {
            var defense = _newGameSituation.Offense == _currentMatch.AwayTeam ? _currentMatch.HomeTeam : _currentMatch.AwayTeam;
            PitchingTeamColor.BackColor = defense.TeamColorForThisMatch;
            btnShowAvailablePitchers.BackColor = defense.TeamColorForThisMatch;

            PitchingTeam.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/SmallTeamLogos/{defense.TeamAbbreviation}.png");
            PitcherPhoto.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/PlayerPhotos/Player{defense.CurrentPitcher.Id:0000}.png");

            PitcherName.Text = defense.CurrentPitcher.FullName.ToUpper();

            PitcherGames.Visible = defense.PitchersPlayedInMatch.Count > 1;
            labelGames.Visible = defense.PitchersPlayedInMatch.Count > 1;
            PitcherGames.Text = defense.CurrentPitcher.PitchingStats.GamesPlayed.ToString();

            if (defense.PitchersPlayedInMatch.Count == 1)
            {
                labelGS.Text = "STARTS";
                PitcherGS.Text = $"{defense.CurrentPitcher.PitchingStats.GamesStarted}";
                labelRecord.Text = "RECORD";
                PitcherRecord.Text = $"{defense.CurrentPitcher.PitchingStats.Wins}-{defense.CurrentPitcher.PitchingStats.Losses}";
            }
            else
            {
                labelGS.Text = "RECORD";
                PitcherGS.Text = $"{defense.CurrentPitcher.PitchingStats.Wins}-{defense.CurrentPitcher.PitchingStats.Losses}";
                labelRecord.Text = "SAVES";
                PitcherRecord.Text = $"{defense.CurrentPitcher.PitchingStats.Saves}";
            }

            PitcherBAA.Text = defense.CurrentPitcher.PitchingStats.BAA.ToString("#.000", new CultureInfo("en-US"));
            PitcherERA.Text = defense.CurrentPitcher.PitchingStats.ERA.ToString("##0.00", new CultureInfo("en-US"));
            PitcherIP.Text = defense.CurrentPitcher.PitchingStats.IP.ToString("0.0", new CultureInfo("en-US"));
            PitcherHomeRuns.Text = defense.CurrentPitcher.PitchingStats.HomeRunsAllowed.ToString();
            PitcherStrikeouts.Text = defense.CurrentPitcher.PitchingStats.Strikeouts.ToString();
            PitcherWalks.Text = defense.CurrentPitcher.PitchingStats.WalksAllowed.ToString();
            PitcherWHIP.Text = defense.CurrentPitcher.PitchingStats.WHIP.ToString("0.00", new CultureInfo("en-US"));

            defense.CurrentPitcher.RemainingStamina = await _playerBl.GetPitcherStamina(defense.CurrentPitcher, _currentMatch);

            pb_stamina.MainColor = defense.CurrentPitcher.RemainingStamina < 45 - 1E-5 ? Color.Maroon : defense.TeamColorForThisMatch;

            pb_stamina.Value = defense.CurrentPitcher.RemainingStamina < 5 - 1E-5 ? 5 : (int)defense.CurrentPitcher.RemainingStamina;

            var OutsToday = _currentMatch.AtBats.Where(atBat => atBat.PitcherId == defense.CurrentPitcher.PitcherId).Sum(atBat => atBat.Outs);
            var StrikeoutsToday = _currentMatch.AtBats.Count(atBat => atBat.PitcherId == defense.CurrentPitcher.PitcherId && atBat.AtBatType == AtBatType.Strikeout);
            var walksToday = _currentMatch.AtBats.Count(atBat => atBat.PitcherId == defense.CurrentPitcher.PitcherId && atBat.AtBatType == AtBatType.Walk);
            var HRToday = _currentMatch.AtBats.Count(atBat => atBat.PitcherId == defense.CurrentPitcher.PitcherId && atBat.AtBatType == AtBatType.HomeRun);

            PitcherIPToday.Text = Math.Round(OutsToday / 3 + (double)(OutsToday % 3) / 10, 1).ToString("0.0", new CultureInfo("en-US"));
            PitcherStrikeoutsToday.Text = StrikeoutsToday.ToString();
            PitcherWalksToday.Text = walksToday.ToString();
            PitcherHomeRunsToday.Text = HRToday.ToString();

            var TBFinThisMatch = _currentMatch.AtBats.Count(atBat => atBat.AtBatType != AtBatType.CaughtStealing && atBat.AtBatType != AtBatType.StolenBase && atBat.AtBatType != AtBatType.CaughtStealing && atBat.PitcherId == defense.CurrentPitcher.PitcherId);
            btnShowAvailablePitchers.Visible = !_isAutoSimulation && TBFinThisMatch >= 3 && _newGameSituation.Balls == 0 && _newGameSituation.Strikes == 0;

            if (!defense.CurrentPitcher.IsPinchHitter || _newGameSituation.Outs != 0 || _newGameSituation.Balls != 0 ||
                _newGameSituation.Strikes != 0) return;

            timer1.Stop();

            if (MessageBox.Show("The player on mound is not a pitcher.\nWould you like to replace him?", "New pitcher", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                await ChangePitcher(_isAutoSimulation);
        }

        private async void btnBuntAttempt_Click(object sender, EventArgs e) => await GenerateNewBunt();

        private void lb_Runner1_Name_Click(object sender, EventArgs e)
        {
            if (!_isAutoSimulation && !(lb_Runner3_Name.Visible && lb_Runner2_Name.Visible))
            {
                _newGameSituation.RunnerOnFirst.IsBaseStealingAttempt = !_newGameSituation.RunnerOnFirst.IsBaseStealingAttempt;

                if (lb_Runner2_Name.Visible)
                    _newGameSituation.RunnerOnSecond.IsBaseStealingAttempt = true;
            }

            lb_Runner1_Name.ForeColor = _newGameSituation.RunnerOnFirst.IsBaseStealingAttempt ? Color.DarkGoldenrod : Color.Gainsboro;
            lb_Runner2_Name.ForeColor = _newGameSituation.RunnerOnSecond.IsBaseStealingAttempt ? Color.DarkGoldenrod : Color.Gainsboro;
        }

        private void lb_Runner2_Name_Click(object sender, EventArgs e)
        {
            if (!_isAutoSimulation && !lb_Runner3_Name.Visible) _newGameSituation.RunnerOnSecond.IsBaseStealingAttempt = !_newGameSituation.RunnerOnSecond.IsBaseStealingAttempt;

            lb_Runner2_Name.ForeColor = _newGameSituation.RunnerOnSecond.IsBaseStealingAttempt ? Color.DarkGoldenrod : Color.Gainsboro;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK || DeleteThisMatch) return;

            timer1.Stop();

            e.Cancel = true;

            if (MessageBox.Show("Do you want to close this window?\nThis match will be deleted from database", "Graduation paper", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                timer1.Start();
                return;
            }

            DeleteThisMatch = true;
            Dispose();
        }

        private void btnStandings_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            using (var form = new StandingsForm(_currentMatch.HomeTeam, _currentMatch.AwayTeam))
                form.ShowDialog();

            if (_isAutoSimulation) timer1.Start();
        }

        private async void btnShowAvailablePitchers_Click(object sender, EventArgs e) => await ChangePitcher(_isAutoSimulation);

        private void btnOtherResults_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            using (var form = new ScheduleAndResultsForm(_currentMatch))
                form.ShowDialog();

            if (_isAutoSimulation) timer1.Start();
        }

        private void btnPlayerStats_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            using (var form = new PlayerStatsForm(PlayerStatsForm.SortingObjects.Players))
                form.ShowDialog();

            if (_isAutoSimulation) timer1.Start();
        }

        private void panel6_VisibleChanged(object sender, EventArgs e)
        {
            pbCurrentOffenseLogo.Visible = panelCurrentBatter.Visible;
            pbCurrentBatterPhoto.Visible = panelCurrentBatter.Visible;
        }

        private async void btnChangeBatter_Click(object sender, EventArgs e)
        {
            var offense = _newGameSituation.Offense;
            var batterNumber = offense.TeamAbbreviation == _currentMatch.AwayTeam.TeamAbbreviation 
                ? _newGameSituation.NumberOfBatterFromAwayTeam 
                : _newGameSituation.NumberOfBatterFromHomeTeam;
            await ChangeBatter(_isAutoSimulation, batterNumber);
        }

        private void BackColorChanging_label(object sender, EventArgs e)
        {
            if (sender is Control l)
                l.ForeColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(l.BackColor, false);
        }

        private void btnTeamStats_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            using (var form = new PlayerStatsForm(PlayerStatsForm.SortingObjects.Teams))
                form.ShowDialog();

            if (_isAutoSimulation) timer1.Start();
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

        private async void timer1_Tick(object sender, EventArgs e)
        {
            var defense = _newGameSituation.Offense == _currentMatch.AwayTeam ? _currentMatch.HomeTeam : _currentMatch.AwayTeam;

            if (!_isAutoSimulation) return;

            var TBFinThisMatch = _currentMatch.AtBats.Count(atBat => atBat.AtBatType != AtBatType.CaughtStealing && atBat.AtBatType != AtBatType.StolenBase && atBat.PitcherId == defense.CurrentPitcher.PitcherId);

            if (_newGameSituation.Balls == 0 && _newGameSituation.Strikes == 0)
            {
                var batterNumber = _newGameSituation.Offense == _currentMatch.AwayTeam ? _newGameSituation.NumberOfBatterFromAwayTeam : _newGameSituation.NumberOfBatterFromHomeTeam;
                await BatterSubstitution_Definition(_newGameSituation.Offense.BattingLineup[batterNumber - 1], batterNumber);

                if (TBFinThisMatch >= 3)
                    await PitcherSubstitution_Definition(defense.CurrentPitcher);
            }

            BasesStealingAttempt_Definition();
            bool isBunt;

            if (!_newGameSituation.RunnerOnFirst.IsBaseStealingAttempt && !_newGameSituation.RunnerOnSecond.IsBaseStealingAttempt &&
                (_newGameSituation.RunnerOnFirst.IsBaseNotEmpty || _newGameSituation.RunnerOnSecond.IsBaseNotEmpty || _newGameSituation.RunnerOnThird.IsBaseNotEmpty))
                isBunt = BuntAttemptDefinition();
            else isBunt = false;

            if (isBunt)
                await GenerateNewBunt();
            else await GenerateNewPitch();
        }

        private void btnAutoMode_Click(object sender, EventArgs e) => SimulationModeChanged(true);

        private void SimulationModeChanged(bool isAutoSim)
        {
            _isAutoSimulation = isAutoSim;
            timer1.Enabled = isAutoSim;
            btnNewPitch.Enabled = !isAutoSim;
            btnBuntAttempt.Enabled = !isAutoSim;
            btnManualMode.BackColor = _isAutoSimulation ? Color.DimGray : Color.Gainsboro;
            btnAutoMode.BackColor = !_isAutoSimulation ? Color.DimGray : Color.Gainsboro;
            panel1.Visible = !_isAutoSimulation;
        }

        private async Task GenerateNewBunt()
        {
            var pitch = _buntGenerator.CreatePitch(_newGameSituation, _currentMatch);
            await AddNewGameSituation(pitch);
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            var borderColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(panel9.BackColor, false);
            ControlPaint.DrawBorder(e.Graphics, panel9.ClientRectangle, borderColor, ButtonBorderStyle.Solid);
        }

        private void btnManualMode_Click(object sender, EventArgs e) => SimulationModeChanged(false);

        private void lbTodayStats_VisibleChanged(object sender, EventArgs e)
        {
            panelCurrentBatter.Height = lbTodayStats.Visible ? 110 : 140;
            pbCurrentOffenseLogo.Width = lbTodayStats.Visible ? 110 : 140;
            pbCurrentOffenseLogo.Height = lbTodayStats.Visible ? 110 : 140;
            pbCurrentOffenseLogo.Left = lbTodayStats.Visible ? 88 : 58;
        }

        #region BatterSubstitution
        private async Task BatterSubstitution_Definition(Batter batter, int batterNumber)
        {
            var batterSubstitution = RandomGenerators.BatterSubstitution_Definition(batter, _currentMatch.AtBats);

            if (batterSubstitution != RandomGenerators.BatterSubstitution.Substitution) return;
            await ChangeBatter(_isAutoSimulation, batterNumber);
        }

        private async Task ChangeBatter(bool isAutoSimulation, int batterNumber)
        {
            timer1.Stop();

            var offense = _newGameSituation.Offense;
            var batter = offense.BattingLineup[batterNumber - 1];
            var batters = await _substitutionBl.GetAvailableBatters(_currentMatch, offense, batter);

            if (batters.Count > 0)
            {
                Func<Team, List<Batter>, Batter?> newBatterFunc =
                    !isAutoSimulation ? GetBatterManual : GetBatterAutomatic;

                var newBatter = newBatterFunc(offense, batters);

                if (newBatter is null) return;

                await _substitutionBl.SubstituteBatter(_currentMatch, newBatter);
                offense.BattingLineup = await _playerBl.GetCurrentLineupForThisMatch(offense, _currentMatch);

                if (!_currentMatch.DHRule && batter.NumberInLineup == 9)
                {
                    var newPitcher = (Pitcher)await _playerBl.GetPlayerByCode(newBatter.Id);
                    offense.PitchersPlayedInMatch.Add(newPitcher);
                }

                await _playerBl.UpdateStatsForThisPitcher(offense.CurrentPitcher, _currentMatch);
                await DisplayingCurrentSituation(_newGameSituation);
            }
            else if (!isAutoSimulation)
            {
                using var form = new ErrorForm();
                form.ShowDialog();
            }

            if (isAutoSimulation) timer1.Start();
        }

        private Batter? GetBatterManual(Team offense, List<Batter> batters)
        {
            using var form = new SubstitutionForm(offense, batters);
            form.ShowDialog();
            return form.DialogResult == DialogResult.OK ? form.NewBatterForThisTeam : null;
        }

        private Batter? GetBatterAutomatic(Team offense, List<Batter> batters) => batters.FirstOrDefault();
        #endregion

        #region PitcherSubstitution
        private async Task PitcherSubstitution_Definition(Pitcher pitcher)
        {
            var pitcherSubstitution = RandomGenerators.PitcherSubstitution_Definition(pitcher, _currentMatch.Runs);

            if (pitcherSubstitution != RandomGenerators.PitcherSubstitution.Substitution) return;

            await ChangePitcher(_isAutoSimulation);
        }

        private async Task ChangePitcher(bool isAutoSimulation)
        {
            var defense = _newGameSituation.Offense == _currentMatch.AwayTeam ? _currentMatch.HomeTeam : _currentMatch.AwayTeam;
            var pitchers = await _substitutionBl.GetAvailablePitchers(_currentMatch, defense);
            if (pitchers.Count > 0)
            {
                Func<Team, List<Pitcher>, Pitcher?> newPitcherFunc =
                    !isAutoSimulation ? GetNewPitcherManual : GetNewPitcherAutomatic;

                var newPitcher = newPitcherFunc(defense, pitchers);

                if (newPitcher is null) return;

                await _substitutionBl.SubstitutePitcher(_currentMatch, newPitcher);

                defense.BattingLineup = await _playerBl.GetCurrentLineupForThisMatch(defense, _currentMatch);
                await _playerBl.UpdateStatsForThisPitcher(defense.CurrentPitcher, _currentMatch);

                defense.PitchersPlayedInMatch.Add(newPitcher);
                await DisplayingCurrentSituation(_newGameSituation);
                await DisplayPitcherStats();

                if (isAutoSimulation)
                    SimulationModeChanged(pb_stamina.Value > 25 && int.Parse(lbPitchCountForThisPitcher.Text) < 105);
            }
            else if (!_isAutoSimulation)
            {
                using var form = new ErrorForm();
                form.ShowDialog();
            }
        }

        private Pitcher? GetNewPitcherAutomatic(Team defense, IReadOnlyCollection<Pitcher?> pitchers)
        {
            var closer = pitchers.FirstOrDefault(pitcher => pitcher?.PitchingStats.Saves == pitchers.Max(pitcher1 => pitcher1?.PitchingStats.Saves));

            if (pitchers.Count > 1 && _newGameSituation.InningNumber < 9)
                return pitchers.FirstOrDefault(pitcher => pitcher?.RemainingStamina == pitchers.Min(pitcher1 => pitcher1?.RemainingStamina));

            return closer;
        }

        private Pitcher? GetNewPitcherManual(Team defense, List<Pitcher> pitchers)
        {
            using var form = new PitcherSubstitutionForm(defense, pitchers);
            form.ShowDialog();
            return form.DialogResult == DialogResult.OK ? form.NewPitcherForThisTeam : null;
        }
        #endregion
    }
}