using System;
using System.Collections.Generic;

namespace Entities
{
    public class GameSituation
    {
        public int Id;
        public int InningNumber;
        public Team Offense;
        public Pitch.PitchResult Result;
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

        public GameSituation(Team offenseTeam)
        {
            Id = 0;
            InningNumber = 1;
            Offense = offenseTeam;
            Result = Pitch.PitchResult.Null;
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

        public GameSituation(int id, int inning, Team offense, Pitch.PitchResult result, int balls, int strikes, int outs, Runner runnerOn1, Runner runnerOn2, Runner runnerOn3, int awayRuns, int homeRuns, int batterAway, int batterHome, int pitcherId)
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
            NumberOfBatterFromHomeTeam = batterAway;
            NumberOfBatterFromAwayTeam = batterHome;
            PitcherID = pitcherId;
        }

        public int NumberOfBallsDetrmining(Pitch.PitchResult result, GameSituation situation)
        {
            switch (result)
            {
                case Pitch.PitchResult.Ball:
                    {
                        return situation.Balls == 3 ? 0 : situation.Balls + 1;
                    }
                case Pitch.PitchResult.Foul:
                    {
                        return situation.Balls;
                    }
                case Pitch.PitchResult.Strike:
                    {
                        return situation.Strikes == 2 ? 0 : situation.Balls;
                    }
                case Pitch.PitchResult.HitByPitch:
                case Pitch.PitchResult.Groundout:
                case Pitch.PitchResult.Popout:
                case Pitch.PitchResult.Flyout:
                case Pitch.PitchResult.Single:
                case Pitch.PitchResult.Double:
                case Pitch.PitchResult.Triple:
                case Pitch.PitchResult.HomeRun:
                case Pitch.PitchResult.SacrificeFly:
                case Pitch.PitchResult.SacrificeBunt:
                case Pitch.PitchResult.DoublePlay:
                    {
                        return 0;
                    }
                default:
                    {
                        return situation.Balls;
                    }
            }
        }

        public int NumberOfStrikesDetermining(Pitch.PitchResult result, GameSituation situation)
        {
            switch (result)
            {
                case Pitch.PitchResult.Ball:
                    {
                        return situation.Balls == 3 ? 0 : situation.Strikes;
                    }
                case Pitch.PitchResult.Foul:
                    {
                        return situation.Strikes < 2 ? situation.Strikes + 1 : situation.Strikes;
                    }
                case Pitch.PitchResult.Strike:
                    {
                        return situation.Strikes == 2 ? 0 : situation.Strikes + 1;
                    }
                case Pitch.PitchResult.HitByPitch:
                case Pitch.PitchResult.Groundout:
                case Pitch.PitchResult.Popout:
                case Pitch.PitchResult.Flyout:
                case Pitch.PitchResult.Single:
                case Pitch.PitchResult.Double:
                case Pitch.PitchResult.GroundRuleDouble:
                case Pitch.PitchResult.Triple:
                case Pitch.PitchResult.HomeRun:
                case Pitch.PitchResult.SacrificeFly:
                case Pitch.PitchResult.SacrificeBunt:
                case Pitch.PitchResult.DoublePlay:
                case Pitch.PitchResult.DoublePlayOnFlyout:
                    {
                        return 0;
                    }
                default:
                    {
                        return situation.Strikes;
                    }
            }
        }

        public int NumberOfOutsDetermining(Pitch.PitchResult result, GameSituation situation, int strikes)
        {
            if ((result == Pitch.PitchResult.Strike && strikes == 0) ||
                (result == Pitch.PitchResult.Groundout) ||
                (result == Pitch.PitchResult.Popout) ||
                (result == Pitch.PitchResult.Flyout) ||
                (result == Pitch.PitchResult.SacrificeFly) ||
                (result == Pitch.PitchResult.SacrificeBunt) ||
                (result == Pitch.PitchResult.CaughtStealingOnSecond) ||
                (result == Pitch.PitchResult.CaughtStealingOnThird))
            {
                return situation.Outs + 1;
            }
            else if (result == Pitch.PitchResult.DoublePlay || 
                     result == Pitch.PitchResult.DoublePlayOnFlyout)
            {
                return situation.Outs + 2;
            }
            else return situation.Outs;
        }

        private Runner ReturnNewRunner(Match match)
        {
            if (Offense == match.AwayTeam)
            {
                Batter batter = match.AwayTeam.BattingLineup[NumberOfBatterFromHomeTeam - 1];
                Pitcher pitcher = match.HomeTeam.CurrentPitcher;
                return new Runner(batter, pitcher);
            }
            else
            {
                Batter batter = match.HomeTeam.BattingLineup[NumberOfBatterFromAwayTeam - 1];
                Pitcher pitcher = match.AwayTeam.CurrentPitcher;
                return new Runner(batter, pitcher);
            }
        }

        public Runner HavingARunnerOnFirstBase(Pitch.PitchResult result, GameSituation situation, Match match, int balls)
        {
            if ((result == Pitch.PitchResult.Ball && balls == 0) ||
                (result == Pitch.PitchResult.HitByPitch) ||
                (result == Pitch.PitchResult.Single))
            {
                return ReturnNewRunner(match);
            }
            else if ((result == Pitch.PitchResult.HomeRun) ||
                    (result == Pitch.PitchResult.Double) ||
                    (result == Pitch.PitchResult.Triple) ||
                    (result == Pitch.PitchResult.GroundRuleDouble) ||
                    (result == Pitch.PitchResult.DoublePlay) ||
                    (result == Pitch.PitchResult.SacrificeBunt && !situation.RunnerOnSecond.IsBaseNotEmpty) ||
                    (result == Pitch.PitchResult.SecondBaseStolen) ||
                    (result == Pitch.PitchResult.CaughtStealingOnSecond))
            {
                return new Runner();
            }
            else
            {
                return new Runner(situation.RunnerOnFirst);
            }
        }

        public Runner HavingARunnerOnSecondBase(Pitch.PitchResult result, GameSituation situation, Match match, int balls)
        {
            if ((((result == Pitch.PitchResult.Ball && balls == 0) ||
                (result == Pitch.PitchResult.HitByPitch)) && situation.RunnerOnFirst.IsBaseNotEmpty) ||
                (result == Pitch.PitchResult.Single) ||
                (result == Pitch.PitchResult.SacrificeBunt && Outs < 3 && !situation.RunnerOnSecond.IsBaseNotEmpty) ||
                (result == Pitch.PitchResult.SecondBaseStolen))
            {
                return new Runner(situation.RunnerOnFirst);
            }
            else if (result == Pitch.PitchResult.Double || result == Pitch.PitchResult.GroundRuleDouble)
            {
                return ReturnNewRunner(match);
            }
            else if ((result == Pitch.PitchResult.HomeRun) ||
                    (result == Pitch.PitchResult.Triple) ||
                    (result == Pitch.PitchResult.SacrificeFly && !situation.RunnerOnThird.IsBaseNotEmpty) ||
                    ((result == Pitch.PitchResult.SacrificeBunt || result == Pitch.PitchResult.Groundout || result == Pitch.PitchResult.DoublePlay) && Outs < 3 && !situation.RunnerOnThird.IsBaseNotEmpty) ||
                    (result == Pitch.PitchResult.Popout) ||
                    (result == Pitch.PitchResult.ThirdBaseStolen) ||
                    (result == Pitch.PitchResult.CaughtStealingOnSecond) ||
                    (result == Pitch.PitchResult.CaughtStealingOnThird))

            {
                return new Runner();
            }
            else
            {
                return new Runner(situation.RunnerOnSecond);
            }
        }

        public Runner HavingARunnerOnThirdBase(Pitch.PitchResult result, GameSituation situation, Match match, int balls)
        {
            if (result == Pitch.PitchResult.Triple)
            {
                return ReturnNewRunner(match);
            }
            else if ((((result == Pitch.PitchResult.Ball && balls == 0) || (result == Pitch.PitchResult.HitByPitch)) && situation.RunnerOnFirst.IsBaseNotEmpty && situation.RunnerOnSecond.IsBaseNotEmpty) ||
                     result == Pitch.PitchResult.Single ||
                    (result == Pitch.PitchResult.SacrificeFly && !situation.RunnerOnThird.IsBaseNotEmpty) ||
                     result == Pitch.PitchResult.Popout ||
                    ((result == Pitch.PitchResult.Groundout || result == Pitch.PitchResult.DoublePlay || result == Pitch.PitchResult.SacrificeBunt) && Outs < 3 && !situation.RunnerOnThird.IsBaseNotEmpty) ||
                    (result == Pitch.PitchResult.ThirdBaseStolen))
            {
                return new Runner(situation.RunnerOnSecond);
            }
            else if (result == Pitch.PitchResult.Double || result == Pitch.PitchResult.GroundRuleDouble)
            {
                return new Runner(situation.RunnerOnFirst);
            }
            else if ((result == Pitch.PitchResult.HomeRun) ||
                    (result == Pitch.PitchResult.CaughtStealingOnThird) ||
                    ((result == Pitch.PitchResult.SacrificeBunt || result == Pitch.PitchResult.DoublePlay || result == Pitch.PitchResult.Groundout) && Outs < 3 && situation.RunnerOnThird.IsBaseNotEmpty) ||
                    (result == Pitch.PitchResult.SacrificeFly && situation.RunnerOnThird.IsBaseNotEmpty) ||
                    (result == Pitch.PitchResult.DoublePlayOnFlyout && situation.RunnerOnThird.IsBaseNotEmpty))
            {
                return new Runner();
            }
            else
            {
                return new Runner(situation.RunnerOnThird);
            }
        }

        public int NumberOfRunsScoredForLastPitch(Pitch.PitchResult result, GameSituation situation, int balls)
        {
            if (result == Pitch.PitchResult.Single ||
               (result == Pitch.PitchResult.SacrificeFly && Outs < 3) ||
               ((result == Pitch.PitchResult.HitByPitch || (result == Pitch.PitchResult.Ball && balls == 0)) && situation.RunnerOnFirst.IsBaseNotEmpty && situation.RunnerOnSecond.IsBaseNotEmpty && situation.RunnerOnThird.IsBaseNotEmpty) ||
               (result == Pitch.PitchResult.Groundout && Outs < 3) ||
               (result == Pitch.PitchResult.DoublePlay && Outs < 3) ||
               (result == Pitch.PitchResult.Popout && Outs < 3) ||
               (result == Pitch.PitchResult.SacrificeBunt && Outs < 3))
            {
                return Convert.ToInt32(situation.RunnerOnThird.IsBaseNotEmpty);
            }
            else if (result == Pitch.PitchResult.Double || result == Pitch.PitchResult.GroundRuleDouble)
            {
                return Convert.ToInt32(situation.RunnerOnSecond.IsBaseNotEmpty) + Convert.ToInt32(situation.RunnerOnThird.IsBaseNotEmpty);
            }
            else if (result == Pitch.PitchResult.Triple)
            {
                return Convert.ToInt32(situation.RunnerOnFirst.IsBaseNotEmpty) + Convert.ToInt32(situation.RunnerOnSecond.IsBaseNotEmpty) + Convert.ToInt32(situation.RunnerOnThird.IsBaseNotEmpty);
            }
            else if (result == Pitch.PitchResult.HomeRun)
            {
                return Convert.ToInt32(situation.RunnerOnFirst.IsBaseNotEmpty) + Convert.ToInt32(situation.RunnerOnSecond.IsBaseNotEmpty) + Convert.ToInt32(situation.RunnerOnThird.IsBaseNotEmpty) + 1;
            }
            else
            {
                return 0;
            }
        }

        public List<Runner> GetListOfRunnersInHomeByThisPitch(Pitch.PitchResult result, GameSituation situation, int balls, Match match)
        {
            List<Runner> runners = new List<Runner>();
            if (result == Pitch.PitchResult.Single ||
               (result == Pitch.PitchResult.SacrificeFly && Outs < 3) ||
               ((result == Pitch.PitchResult.HitByPitch || (result == Pitch.PitchResult.Ball && balls == 0)) && situation.RunnerOnFirst.IsBaseNotEmpty && situation.RunnerOnSecond.IsBaseNotEmpty && situation.RunnerOnThird.IsBaseNotEmpty) ||
               (result == Pitch.PitchResult.Groundout && Outs < 3) ||
               (result == Pitch.PitchResult.DoublePlay && Outs < 3) ||
               (result == Pitch.PitchResult.Popout && Outs < 3) ||
               (result == Pitch.PitchResult.SacrificeBunt && Outs < 3))
            {
                if (situation.RunnerOnThird.IsBaseNotEmpty)
                {
                    runners.Add(situation.RunnerOnThird);
                }
            }
            else if (result == Pitch.PitchResult.Double || result == Pitch.PitchResult.GroundRuleDouble)
            {
                if (situation.RunnerOnThird.IsBaseNotEmpty)
                {
                    runners.Add(situation.RunnerOnThird);
                }
                if (situation.RunnerOnSecond.IsBaseNotEmpty)
                {
                    runners.Add(situation.RunnerOnSecond);
                }
            }
            else if (result == Pitch.PitchResult.Triple)
            {
                if (situation.RunnerOnThird.IsBaseNotEmpty)
                {
                    runners.Add(situation.RunnerOnThird);
                }
                if (situation.RunnerOnSecond.IsBaseNotEmpty)
                {
                    runners.Add(situation.RunnerOnSecond);
                }
                if (situation.RunnerOnFirst.IsBaseNotEmpty)
                {
                    runners.Add(situation.RunnerOnFirst);
                }
            }
            else if (result == Pitch.PitchResult.HomeRun)
            {
                if (situation.RunnerOnThird.IsBaseNotEmpty)
                {
                    runners.Add(situation.RunnerOnThird);
                }
                if (situation.RunnerOnSecond.IsBaseNotEmpty)
                {
                    runners.Add(situation.RunnerOnSecond);
                }
                if (situation.RunnerOnFirst.IsBaseNotEmpty)
                {
                    runners.Add(situation.RunnerOnFirst);
                }
                runners.Add(ReturnNewRunner(match));
            }
            return runners;
        }

        public void PrepareForNextPitch(GameSituation gameSituation, Team team1, Team team2, int matchLength)
        {
            if ((gameSituation.Result == Pitch.PitchResult.Ball && gameSituation.Balls == 0) ||
                (gameSituation.Result == Pitch.PitchResult.Strike && gameSituation.Strikes == 0) ||
                (gameSituation.Result == Pitch.PitchResult.HitByPitch) ||
                (gameSituation.Result == Pitch.PitchResult.Groundout) ||
                (gameSituation.Result == Pitch.PitchResult.Popout) ||
                (gameSituation.Result == Pitch.PitchResult.Flyout) ||
                (gameSituation.Result == Pitch.PitchResult.Single) ||
                (gameSituation.Result == Pitch.PitchResult.Double) ||
                (gameSituation.Result == Pitch.PitchResult.GroundRuleDouble) ||
                (gameSituation.Result == Pitch.PitchResult.Triple) ||
                (gameSituation.Result == Pitch.PitchResult.HomeRun) ||
                (gameSituation.Result == Pitch.PitchResult.DoublePlay) ||
                (gameSituation.Result == Pitch.PitchResult.SacrificeFly) ||
                (gameSituation.Result == Pitch.PitchResult.SacrificeBunt))
            {
                if (gameSituation.Offense == team1)
                {
                    NumberOfBatterFromHomeTeam = gameSituation.NumberOfBatterFromHomeTeam == 9 ? 1 : gameSituation.NumberOfBatterFromHomeTeam + 1;
                }
                else
                {
                    NumberOfBatterFromAwayTeam = gameSituation.NumberOfBatterFromAwayTeam == 9 ? 1 : gameSituation.NumberOfBatterFromAwayTeam + 1;
                }
            }
            else
            {
                NumberOfBatterFromAwayTeam = gameSituation.NumberOfBatterFromAwayTeam;
                NumberOfBatterFromHomeTeam = gameSituation.NumberOfBatterFromHomeTeam;
            }

            if (gameSituation.Outs == 3)
            {
                if (gameSituation.Offense == team2)
                {
                    Offense = team1;
                    InningNumber = gameSituation.InningNumber + 1;
                    RunnerOnSecond = InningNumber > matchLength ? new Runner(Offense.BattingLineup[(gameSituation.NumberOfBatterFromHomeTeam == 1 ? 9 : gameSituation.NumberOfBatterFromHomeTeam - 1) - 1], team2.CurrentPitcher) : new Runner();
                }
                else
                {
                    Offense = team2;
                    InningNumber = gameSituation.InningNumber;
                    RunnerOnSecond = InningNumber > matchLength ? new Runner(Offense.BattingLineup[(gameSituation.NumberOfBatterFromAwayTeam == 1 ? 9 : gameSituation.NumberOfBatterFromAwayTeam - 1) - 1], team1.CurrentPitcher) : new Runner();
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
    }
}