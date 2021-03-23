using System;
using System.Collections.Generic;

namespace Entities
{
    public class GameSituation
    {
        public int id;
        public int inningNumber;
        public Team offense;
        public Pitch.PitchResult result;
        public int balls;
        public int strikes;
        public int outs;
        public Runner RunnerOnFirst;
        public Runner RunnerOnSecond;
        public Runner RunnerOnThird;
        public int AwayTeamRuns;
        public int HomeTeamRuns;
        public int BatterNumber_AwayTeam;
        public int BatterNumber_HomeTeam;
        public List<Runner> RunsByThisPitch;
        public int PitcherID;

        public GameSituation()
        {
        }

        public GameSituation(Team offenseTeam)
        {
            id = 0;
            inningNumber = 1;
            offense = offenseTeam;
            result = Pitch.PitchResult.Null;
            balls = 0;
            strikes = 0;
            outs = 0;
            RunnerOnFirst = new Runner();
            RunnerOnSecond = new Runner();
            RunnerOnThird = new Runner();
            AwayTeamRuns = 0;
            HomeTeamRuns = 0;
            BatterNumber_AwayTeam = 1;
            BatterNumber_HomeTeam = 1;
            PitcherID = -1;
        }

        public GameSituation(int _id, int _inning, Team _offense, Pitch.PitchResult _result, int _balls, int _strikes, int _outs, Runner _RunnerOn1, Runner _RunnerOn2, Runner _RunnerOn3, int _AwayRuns, int _HomeRuns, int _Batter_Away, int _Batter_Home, int _Pitcher)
        {
            id = _id;
            inningNumber = _inning;
            offense = _offense;
            result = _result;
            balls = _balls;
            strikes = _strikes;
            outs = _outs;
            RunnerOnFirst = _RunnerOn1;
            RunnerOnSecond = _RunnerOn2;
            RunnerOnThird = _RunnerOn3;
            AwayTeamRuns = _AwayRuns;
            HomeTeamRuns = _HomeRuns;
            BatterNumber_AwayTeam = _Batter_Away;
            BatterNumber_HomeTeam = _Batter_Home;
            PitcherID = _Pitcher;
        }

        public int NumberOfBallsDetrmining(Pitch.PitchResult result, GameSituation situation)
        {
            switch (result)
            {
                case Pitch.PitchResult.Ball:
                    {
                        return situation.balls == 3 ? 0 : situation.balls + 1;
                    }
                case Pitch.PitchResult.Foul:
                    {
                        return situation.balls;
                    }
                case Pitch.PitchResult.Strike:
                    {
                        return situation.strikes == 2 ? 0 : situation.balls;
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
                        return situation.balls;
                    }
            }
        }

        public int NumberOfStrikesDetermining(Pitch.PitchResult result, GameSituation situation)
        {
            switch (result)
            {
                case Pitch.PitchResult.Ball:
                    {
                        return situation.balls == 3 ? 0 : situation.strikes;
                    }
                case Pitch.PitchResult.Foul:
                    {
                        return situation.strikes < 2 ? situation.strikes + 1 : situation.strikes;
                    }
                case Pitch.PitchResult.Strike:
                    {
                        return situation.strikes == 2 ? 0 : situation.strikes + 1;
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
                        return situation.strikes;
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
                return situation.outs + 1;
            }
            else if (result == Pitch.PitchResult.DoublePlay)
            {
                return situation.outs + 2;
            }
            else return situation.outs;
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
                    (result == Pitch.PitchResult.DoublePlay) ||
                    (result == Pitch.PitchResult.SacrificeBunt) ||
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
            if ((((result == Pitch.PitchResult.Ball && balls == 0) || (result == Pitch.PitchResult.HitByPitch)) && situation.RunnerOnFirst.IsBaseNotEmpty) ||
                            (result == Pitch.PitchResult.Single) || (result == Pitch.PitchResult.SacrificeBunt && outs < 3) || (result == Pitch.PitchResult.SecondBaseStolen))
            {
                return new Runner(situation.RunnerOnFirst);
            }
            else if (result == Pitch.PitchResult.Double)
            {
                return ReturnNewRunner(match);
            }
            else if ((result == Pitch.PitchResult.HomeRun) ||
                    (result == Pitch.PitchResult.Triple) ||
                    (result == Pitch.PitchResult.SacrificeFly) ||
                    (result == Pitch.PitchResult.Popout) ||
                    ((result == Pitch.PitchResult.Groundout) && outs < 3) ||
                    ((result == Pitch.PitchResult.DoublePlay) && outs < 3) ||
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

        private Runner ReturnNewRunner(Match match)
        {
            if (offense == match.AwayTeam)
            {
                Batter batter = match.AwayTeam.BattingLineup[BatterNumber_AwayTeam - 1];
                Pitcher pitcher = match.HomeTeam.CurrentPitcher;
                return new Runner(batter, pitcher);
            }
            else
            {
                Batter batter = match.HomeTeam.BattingLineup[BatterNumber_HomeTeam - 1];
                Pitcher pitcher = match.AwayTeam.CurrentPitcher;
                return new Runner(batter, pitcher);
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
                     result == Pitch.PitchResult.SacrificeFly ||
                     result == Pitch.PitchResult.Popout ||
                    ((result == Pitch.PitchResult.Groundout) && outs < 3) ||
                    ((result == Pitch.PitchResult.DoublePlay) && outs < 3) || 
                    (result == Pitch.PitchResult.SacrificeBunt && outs < 3) ||
                    (result == Pitch.PitchResult.ThirdBaseStolen))
            {
                return new Runner(situation.RunnerOnSecond);
            }
            else if (result == Pitch.PitchResult.Double)
            {
                return new Runner(situation.RunnerOnFirst);
            }
            else if ((result == Pitch.PitchResult.HomeRun) ||
                    (result == Pitch.PitchResult.CaughtStealingOnThird))
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
               (result == Pitch.PitchResult.SacrificeFly && outs < 3) ||
               ((result == Pitch.PitchResult.HitByPitch || (result == Pitch.PitchResult.Ball && balls == 0)) && situation.RunnerOnFirst.IsBaseNotEmpty && situation.RunnerOnSecond.IsBaseNotEmpty && situation.RunnerOnThird.IsBaseNotEmpty) ||
               (result == Pitch.PitchResult.Groundout && outs < 3) ||
               (result == Pitch.PitchResult.DoublePlay && outs < 3) ||
               (result == Pitch.PitchResult.Popout && outs < 3) || 
               (result == Pitch.PitchResult.SacrificeBunt && outs < 3))
            {
                return Convert.ToInt32(situation.RunnerOnThird.IsBaseNotEmpty);
            }
            else if (result == Pitch.PitchResult.Double)
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
               (result == Pitch.PitchResult.SacrificeFly && outs < 3) ||
               ((result == Pitch.PitchResult.HitByPitch || (result == Pitch.PitchResult.Ball && balls == 0)) && situation.RunnerOnFirst.IsBaseNotEmpty && situation.RunnerOnSecond.IsBaseNotEmpty && situation.RunnerOnThird.IsBaseNotEmpty) ||
               (result == Pitch.PitchResult.Groundout && outs < 3) ||
               (result == Pitch.PitchResult.DoublePlay && outs < 3) ||
               (result == Pitch.PitchResult.Popout && outs < 3) || 
               (result == Pitch.PitchResult.SacrificeBunt && outs < 3))
            {
                if(situation.RunnerOnThird.IsBaseNotEmpty)
                {
                    runners.Add(situation.RunnerOnThird);
                }
            }
            else if (result == Pitch.PitchResult.Double)
            {
                if(situation.RunnerOnThird.IsBaseNotEmpty)
                {
                    runners.Add(situation.RunnerOnThird);
                }
                if(situation.RunnerOnSecond.IsBaseNotEmpty)
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

        public void PrepareForNextPitch(GameSituation gameSituation, Team team1, Team team2)
        {
            if ((gameSituation.result == Pitch.PitchResult.Ball && gameSituation.balls == 0) ||
                (gameSituation.result == Pitch.PitchResult.Strike && gameSituation.strikes == 0) ||
                (gameSituation.result == Pitch.PitchResult.HitByPitch) ||
                (gameSituation.result == Pitch.PitchResult.Groundout) ||
                (gameSituation.result == Pitch.PitchResult.Popout) ||
                (gameSituation.result == Pitch.PitchResult.Flyout) ||
                (gameSituation.result == Pitch.PitchResult.Single) ||
                (gameSituation.result == Pitch.PitchResult.Double) ||
                (gameSituation.result == Pitch.PitchResult.Triple) ||
                (gameSituation.result == Pitch.PitchResult.HomeRun) ||
                (gameSituation.result == Pitch.PitchResult.DoublePlay) ||
                (gameSituation.result == Pitch.PitchResult.SacrificeFly) || 
                (gameSituation.result == Pitch.PitchResult.SacrificeBunt))
            {
                if (gameSituation.offense == team1)
                {
                    BatterNumber_AwayTeam = gameSituation.BatterNumber_AwayTeam == 9 ? 1 : gameSituation.BatterNumber_AwayTeam + 1;
                }
                else
                {
                    BatterNumber_HomeTeam = gameSituation.BatterNumber_HomeTeam == 9 ? 1 : gameSituation.BatterNumber_HomeTeam + 1;
                }
            }
            else
            {
                BatterNumber_HomeTeam = gameSituation.BatterNumber_HomeTeam;
                BatterNumber_AwayTeam = gameSituation.BatterNumber_AwayTeam;
            }

            if (gameSituation.outs == 3)
            {
                if (gameSituation.offense == team2)
                {
                    offense = team1;
                    inningNumber = gameSituation.inningNumber + 1;
                }
                else
                {
                    offense = team2;
                    inningNumber = gameSituation.inningNumber;
                }
                balls = 0;
                strikes = 0;
                outs = 0;
                RunnerOnFirst = new Runner();
                RunnerOnSecond = new Runner();
                RunnerOnThird = new Runner();
            }
            else
            {
                offense = gameSituation.offense;
                inningNumber = gameSituation.inningNumber;
            }
        }
    }
}