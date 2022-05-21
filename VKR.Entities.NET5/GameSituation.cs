using System.Collections.Generic;

namespace Entities.NET5
{
    public class GameSituation
    {
        public int Id;
        public int InningNumber;
        public Team Offense;
        public PitchResult Result;
        public int Balls;
        public int Strikes;
        public int Outs;
        public Runner RunnerOnFirst;
        public Runner RunnerOnSecond;
        public Runner RunnerOnThird;
        public int AwayTeamRuns;
        public int HomeTeamRuns;
        public int NumberOfBatterFromHomeTeam;
        public int NumberOfBatterFromAwayTeam;
        public List<Runner> RunsByThisPitch;
        public int PitcherID;

        public static List<PitchResult> AtBatEndingConditions = new List<PitchResult>
        {
            PitchResult.HitByPitch,
            PitchResult.Groundout,
            PitchResult.Popout,
            PitchResult.Flyout,
            PitchResult.Single,
            PitchResult.Double,
            PitchResult.GroundRuleDouble,
            PitchResult.Triple,
            PitchResult.HomeRun,
            PitchResult.DoublePlay,
            PitchResult.SacrificeFly,
            PitchResult.SacrificeBunt,
            PitchResult.DoublePlayOnFlyout
        };

        public static List<PitchResult> BaseStealingResults = new List<PitchResult>
        {
            PitchResult.SecondBaseStolen,
            PitchResult.CaughtStealingOnSecond,
            PitchResult.ThirdBaseStolen,
            PitchResult.CaughtStealingOnThird
        };

        public GameSituation(Team offenseTeam)
        {
            Id = 0;
            InningNumber = 1;
            Offense = offenseTeam;
            Result = PitchResult.Null;
            Balls = 0;
            Strikes = 0;
            Outs = 0;
            RunnerOnFirst = new Runner();
            RunnerOnSecond = new Runner();
            RunnerOnThird = new Runner();
            AwayTeamRuns = 0;
            HomeTeamRuns = 0;
            NumberOfBatterFromHomeTeam = 1;
            NumberOfBatterFromAwayTeam = 1;
            PitcherID = -1;
        }

        public GameSituation(int id, int inning, Team offense, PitchResult result, int balls, int strikes, int outs, Runner runnerOn1, Runner runnerOn2, Runner runnerOn3, int awayRuns, int homeRuns, int batterAway, int batterHome, int pitcherId)
        {
            Id = id;
            InningNumber = inning;
            Offense = offense;
            Result = result;
            Balls = balls;
            Strikes = strikes;
            Outs = outs;
            RunnerOnFirst = runnerOn1;
            RunnerOnSecond = runnerOn2;
            RunnerOnThird = runnerOn3;
            AwayTeamRuns = awayRuns;
            HomeTeamRuns = homeRuns;
            NumberOfBatterFromAwayTeam = batterAway;
            NumberOfBatterFromHomeTeam = batterHome;
            PitcherID = pitcherId;
        }

        public int NumberOfBallsDetrmining(PitchResult result, GameSituation situation)
        {
            switch (result)
            {
                case PitchResult.Ball:
                    return situation.Balls == 3 ? 0 : situation.Balls + 1;
                case PitchResult.Strike:
                    return situation.Strikes == 2 ? 0 : situation.Balls;
            }

            return AtBatEndingConditions.Contains(result) ? 0 : situation.Balls;
        }

        public int NumberOfStrikesDetermining(PitchResult result, GameSituation situation)
        {
            switch (result)
            {
                case PitchResult.Ball:
                    return situation.Balls == 3 ? 0 : situation.Strikes;
                case PitchResult.Foul:
                    return situation.Strikes < 2 ? situation.Strikes + 1 : situation.Strikes;
                case PitchResult.Strike:
                    return situation.Strikes == 2 ? 0 : situation.Strikes + 1;
            }

            return AtBatEndingConditions.Contains(result) ? 0 : situation.Strikes;
        }

        public int NumberOfOutsDetermining(PitchResult result, GameSituation situation, int strikes)
        {
            switch (result)
            {
                case PitchResult.Strike when strikes == 0:
                case PitchResult.Groundout:
                case PitchResult.Popout:
                case PitchResult.Flyout:
                case PitchResult.SacrificeFly:
                case PitchResult.SacrificeBunt:
                case PitchResult.CaughtStealingOnSecond:
                case PitchResult.CaughtStealingOnThird:
                    return situation.Outs + 1;
                case PitchResult.DoublePlay:
                case PitchResult.DoublePlayOnFlyout:
                    return situation.Outs + 2;
                default:
                    return situation.Outs;
            }
        }

        private Runner ReturnNewRunner(Match match)
        {
            if (Offense == match.AwayTeam)
            {
                var batter = match.AwayTeam.BattingLineup[NumberOfBatterFromAwayTeam - 1];
                var pitcher = match.HomeTeam.CurrentPitcher;
                return new Runner(batter, pitcher);
            }
            else
            {
                var batter = match.HomeTeam.BattingLineup[NumberOfBatterFromHomeTeam - 1];
                var pitcher = match.AwayTeam.CurrentPitcher;
                return new Runner(batter, pitcher);
            }
        }

        public Runner HavingARunnerOnFirstBase(PitchResult result, GameSituation situation, Match match, int balls)
        {
            switch (result)
            {
                case PitchResult.Ball when balls == 0:
                case PitchResult.HitByPitch:
                case PitchResult.Single:
                    return ReturnNewRunner(match);
                case PitchResult.HomeRun:
                case PitchResult.Double:
                case PitchResult.Triple:
                case PitchResult.GroundRuleDouble:
                case PitchResult.DoublePlay:
                case PitchResult.SacrificeBunt when !situation.RunnerOnSecond.IsBaseNotEmpty:
                case PitchResult.SecondBaseStolen:
                case PitchResult.CaughtStealingOnSecond:
                    return new Runner();
                default:
                    return new Runner(situation.RunnerOnFirst);
            }
        }

        public Runner HavingARunnerOnSecondBase(PitchResult result, GameSituation situation, Match match, int balls)
        {
            if ((((result == PitchResult.Ball && balls == 0) ||
                result == PitchResult.HitByPitch) && situation.RunnerOnFirst.IsBaseNotEmpty) ||
                result == PitchResult.Single ||
                (result == PitchResult.SacrificeBunt && Outs < 3 && !situation.RunnerOnSecond.IsBaseNotEmpty) ||
                result == PitchResult.SecondBaseStolen)
            {
                return new Runner(situation.RunnerOnFirst);
            }

            if (result is PitchResult.Double or PitchResult.GroundRuleDouble)
            {
                return ReturnNewRunner(match);
            }

            if (result == PitchResult.HomeRun ||
                    result == PitchResult.Triple ||
                    (result == PitchResult.SacrificeFly && !situation.RunnerOnThird.IsBaseNotEmpty) ||
                    ((result == PitchResult.SacrificeBunt || result is PitchResult.Groundout or PitchResult.DoublePlay) && Outs < 3 && !situation.RunnerOnThird.IsBaseNotEmpty) ||
                    result == PitchResult.Popout ||
                    result == PitchResult.ThirdBaseStolen ||
                    result == PitchResult.CaughtStealingOnSecond ||
                    result == PitchResult.CaughtStealingOnThird)

            {
                return new Runner();
            }

            return new Runner(situation.RunnerOnSecond);
        }

        public Runner HavingARunnerOnThirdBase(PitchResult result, GameSituation situation, Match match, int balls)
        {
            if (result == PitchResult.Triple)
            {
                return ReturnNewRunner(match);
            }

            if ((((result == PitchResult.Ball && balls == 0) || result == PitchResult.HitByPitch) && situation.RunnerOnFirst.IsBaseNotEmpty && situation.RunnerOnSecond.IsBaseNotEmpty) ||
                     result == PitchResult.Single ||
                    (result == PitchResult.SacrificeFly && !situation.RunnerOnThird.IsBaseNotEmpty) ||
                     result == PitchResult.Popout ||
                    ((result == PitchResult.Groundout || result == PitchResult.DoublePlay || result == PitchResult.SacrificeBunt) && Outs < 3 && !situation.RunnerOnThird.IsBaseNotEmpty) ||
                    result == PitchResult.ThirdBaseStolen)
            {
                return new Runner(situation.RunnerOnSecond);
            }

            if (result is PitchResult.Double or PitchResult.GroundRuleDouble)
            {
                return new Runner(situation.RunnerOnFirst);
            }

            if (result == PitchResult.HomeRun ||
                    result == PitchResult.CaughtStealingOnThird ||
                    ((result == PitchResult.SacrificeBunt || result == PitchResult.DoublePlay || result == PitchResult.Groundout) && Outs < 3 && situation.RunnerOnThird.IsBaseNotEmpty) ||
                    (result == PitchResult.SacrificeFly && situation.RunnerOnThird.IsBaseNotEmpty) ||
                    (result == PitchResult.DoublePlayOnFlyout && situation.RunnerOnThird.IsBaseNotEmpty))
            {
                return new Runner();
            }

            return new Runner(situation.RunnerOnThird);
        }

        public List<Runner> GetListOfRunnersInHomeByThisPitch(PitchResult result, GameSituation situation, int balls, Match match)
        {
            var runners = new List<Runner>();
            if (result == PitchResult.Single ||
               (result == PitchResult.SacrificeFly && Outs < 3) ||
               ((result == PitchResult.HitByPitch || (result == PitchResult.Ball && balls == 0)) && situation.RunnerOnFirst.IsBaseNotEmpty && situation.RunnerOnSecond.IsBaseNotEmpty && situation.RunnerOnThird.IsBaseNotEmpty) ||
               (result == PitchResult.Groundout && Outs < 3) ||
               (result == PitchResult.DoublePlay && Outs < 3) ||
               (result == PitchResult.Popout && Outs < 3) ||
               (result == PitchResult.SacrificeBunt && Outs < 3))
            {
                if (situation.RunnerOnThird.IsBaseNotEmpty) runners.Add(situation.RunnerOnThird);
            }

            switch (result)
            {
                case PitchResult.Double:
                case PitchResult.GroundRuleDouble:
                    {
                        if (situation.RunnerOnThird.IsBaseNotEmpty) runners.Add(situation.RunnerOnThird);

                        if (situation.RunnerOnSecond.IsBaseNotEmpty) runners.Add(situation.RunnerOnSecond);

                        break;
                    }
                case PitchResult.Triple:
                    {
                        if (situation.RunnerOnThird.IsBaseNotEmpty) runners.Add(situation.RunnerOnThird);

                        if (situation.RunnerOnSecond.IsBaseNotEmpty) runners.Add(situation.RunnerOnSecond);

                        if (situation.RunnerOnFirst.IsBaseNotEmpty) runners.Add(situation.RunnerOnFirst);

                        break;
                    }
                case PitchResult.HomeRun:
                    {
                        if (situation.RunnerOnThird.IsBaseNotEmpty) runners.Add(situation.RunnerOnThird);

                        if (situation.RunnerOnSecond.IsBaseNotEmpty) runners.Add(situation.RunnerOnSecond);

                        if (situation.RunnerOnFirst.IsBaseNotEmpty) runners.Add(situation.RunnerOnFirst);

                        runners.Add(ReturnNewRunner(match));
                        break;
                    }
            }

            return runners;
        }

        public void PrepareForNextPitch(GameSituation gameSituation, Team awayTeam, Team homeTeam, int matchLength)
        {
            if ((gameSituation.Result == PitchResult.Ball && gameSituation.Balls == 0) ||
                (gameSituation.Result == PitchResult.Strike && gameSituation.Strikes == 0) ||
                AtBatEndingConditions.Contains(gameSituation.Result))
            {
                if (gameSituation.Offense == awayTeam)
                {
                    NumberOfBatterFromAwayTeam = gameSituation.NumberOfBatterFromAwayTeam == 9
                                            ? 1
                                            : gameSituation.NumberOfBatterFromAwayTeam + 1;
                    NumberOfBatterFromHomeTeam = gameSituation.NumberOfBatterFromHomeTeam;
                }

                else
                {
                    NumberOfBatterFromHomeTeam = gameSituation.NumberOfBatterFromHomeTeam == 9
                        ? 1
                        : gameSituation.NumberOfBatterFromHomeTeam + 1;
                    NumberOfBatterFromAwayTeam = gameSituation.NumberOfBatterFromAwayTeam;
                }
            }
            else
            {
                NumberOfBatterFromAwayTeam = gameSituation.NumberOfBatterFromAwayTeam;
                NumberOfBatterFromHomeTeam = gameSituation.NumberOfBatterFromHomeTeam;
            }

            AwayTeamRuns = gameSituation.AwayTeamRuns;
            HomeTeamRuns = gameSituation.HomeTeamRuns;

            if (gameSituation.Outs == 3)
            {
                if (gameSituation.Offense == homeTeam)
                {
                    Offense = awayTeam;
                    InningNumber = gameSituation.InningNumber + 1;
                    RunnerOnSecond = InningNumber > matchLength ? new Runner(Offense.BattingLineup[(gameSituation.NumberOfBatterFromAwayTeam == 1 ? 9 : gameSituation.NumberOfBatterFromAwayTeam - 1) - 1], homeTeam.CurrentPitcher) : new Runner();
                }
                else
                {
                    Offense = homeTeam;
                    InningNumber = gameSituation.InningNumber;
                    RunnerOnSecond = InningNumber > matchLength ? new Runner(Offense.BattingLineup[(gameSituation.NumberOfBatterFromHomeTeam == 1 ? 9 : gameSituation.NumberOfBatterFromHomeTeam - 1) - 1], awayTeam.CurrentPitcher) : new Runner();
                }
                Balls = 0;
                Strikes = 0;
                Outs = 0;
                RunnerOnFirst = new Runner();
                RunnerOnThird = new Runner();
            }
            else
            {
                Offense = gameSituation.Offense;
                InningNumber = gameSituation.InningNumber;
            }
        }

        public GameSituation Clone()
        {
            return new GameSituation(Id, InningNumber, Offense, Result, Balls, Strikes, Outs, RunnerOnFirst, RunnerOnSecond, RunnerOnThird, AwayTeamRuns, HomeTeamRuns, NumberOfBatterFromAwayTeam, NumberOfBatterFromHomeTeam, PitcherID);
        }

        public GameSituation(Pitch pitch, GameSituation _previousSituation, Match _currentMatch)
        {
            Id = _previousSituation.Id + 1;
            Result = pitch.NewPitchResult;
            InningNumber = _previousSituation.InningNumber;
            Offense = _previousSituation.Offense;
            NumberOfBatterFromAwayTeam = _previousSituation.NumberOfBatterFromAwayTeam;
            NumberOfBatterFromHomeTeam = _previousSituation.NumberOfBatterFromHomeTeam;
            Balls = NumberOfBallsDetrmining(Result, _previousSituation);
            Strikes = NumberOfStrikesDetermining(Result, _previousSituation);
            Outs = NumberOfOutsDetermining(Result, _previousSituation, Strikes);
            RunnerOnFirst = HavingARunnerOnFirstBase(Result, _previousSituation, _currentMatch, Balls);
            RunnerOnSecond = HavingARunnerOnSecondBase(Result, _previousSituation, _currentMatch, Balls);
            RunnerOnThird = HavingARunnerOnThirdBase(Result, _previousSituation, _currentMatch, Balls);
            RunsByThisPitch = GetListOfRunnersInHomeByThisPitch(Result, _previousSituation, Balls, _currentMatch);
            PitcherID = Offense == _currentMatch.AwayTeam ? _currentMatch.HomeTeam.CurrentPitcher.Id : _currentMatch.AwayTeam.CurrentPitcher.Id;

            if (Offense == _currentMatch.AwayTeam)
            {
                AwayTeamRuns = _previousSituation.AwayTeamRuns + RunsByThisPitch.Count;
                HomeTeamRuns = _previousSituation.HomeTeamRuns;
            }
            else
            {
                HomeTeamRuns = _previousSituation.HomeTeamRuns + RunsByThisPitch.Count;
                AwayTeamRuns = _previousSituation.AwayTeamRuns;
            }
        }
    }
}