using System.Collections.Generic;
using VKR.EF.Entities.Enums;

namespace VKR.EF.Entities
{
    public class GameSituation
    {
        public int Id;
        public byte InningNumber;
        public Team Offense;
        public PitchResult Result;
        public int Balls;
        public int Strikes;
        public byte Outs;
        public Runner RunnerOnFirst;
        public Runner RunnerOnSecond;
        public Runner RunnerOnThird;
        public int AwayTeamRuns;
        public int HomeTeamRuns;
        public int NumberOfBatterFromHomeTeam;
        public int NumberOfBatterFromAwayTeam;
        public List<Runner> RunsByThisPitch;
        public uint PitcherID;

        public static List<PitchResult> AtBatEndingConditions = new()
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

        public static List<PitchResult> BaseStealingResults = new()
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
            PitcherID = 0;
        }

        public GameSituation(int id, byte inning, Team offense, PitchResult result, int balls, int strikes, byte outs, Runner runnerOn1, Runner runnerOn2, Runner runnerOn3, int awayRuns, int homeRuns, int batterAway, int batterHome, uint pitcherId)
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

        public int NumberOfBallsDetermining(PitchResult result, GameSituation situation) =>
            result switch
            {
                PitchResult.Ball => situation.Balls == 3 ? 0 : situation.Balls + 1,
                PitchResult.Strike => situation.Strikes == 2 ? 0 : situation.Balls,
                _ => AtBatEndingConditions.Contains(result) ? 0 : situation.Balls
            };

        public int NumberOfStrikesDetermining(PitchResult result, GameSituation situation)
        {
            return result switch
            {
                PitchResult.Ball => situation.Balls == 3 ? 0 : situation.Strikes,
                PitchResult.Foul => situation.Strikes < 2 ? situation.Strikes + 1 : situation.Strikes,
                PitchResult.Strike => situation.Strikes == 2 ? 0 : situation.Strikes + 1,
                _ => AtBatEndingConditions.Contains(result) ? 0 : situation.Strikes
            };
        }

        public byte NumberOfOutsDetermining(PitchResult result, GameSituation situation, int strikes)
        {
            switch (result)
            {
                case PitchResult.Strike when strikes == 0:
                case PitchResult.Groundout or PitchResult.Popout
                    or PitchResult.Flyout or PitchResult.SacrificeFly
                    or PitchResult.SacrificeBunt or PitchResult.CaughtStealingOnSecond
                    or PitchResult.CaughtStealingOnThird:
                    return (byte)(situation.Outs + 1);
                case PitchResult.DoublePlay or PitchResult.DoublePlayOnFlyout:
                    return (byte)(situation.Outs + 2);
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
                return new Runner(batter, pitcher, true);
            }
            else
            {
                var batter = match.HomeTeam.BattingLineup[NumberOfBatterFromHomeTeam - 1];
                var pitcher = match.AwayTeam.CurrentPitcher;
                return new Runner(batter, pitcher, true);
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
                case PitchResult.HomeRun or PitchResult.Double or PitchResult.Triple or PitchResult.GroundRuleDouble or PitchResult.DoublePlay:
                case PitchResult.SacrificeBunt when !situation.RunnerOnSecond.IsBaseNotEmpty:
                case PitchResult.SecondBaseStolen or PitchResult.CaughtStealingOnSecond:
                    return new Runner();
                default:
                    return new Runner(situation.RunnerOnFirst);
            }
        }

        public Runner HavingARunnerOnSecondBase(PitchResult result, GameSituation situation, Match match, int balls)
        {
            if ((result == PitchResult.Ball && balls == 0 || result == PitchResult.HitByPitch) && situation.RunnerOnFirst.IsBaseNotEmpty ||
                result == PitchResult.Single ||
                result == PitchResult.SacrificeBunt && Outs < 3 && !situation.RunnerOnSecond.IsBaseNotEmpty ||
                result == PitchResult.SecondBaseStolen)
                return new Runner(situation.RunnerOnFirst);

            switch (result)
            {
                case PitchResult.Double or PitchResult.GroundRuleDouble:
                    return ReturnNewRunner(match);
                case PitchResult.HomeRun or PitchResult.Triple:
                case PitchResult.SacrificeFly when !situation.RunnerOnThird.IsBaseNotEmpty:
                case PitchResult.SacrificeBunt or PitchResult.Groundout or PitchResult.DoublePlay when
                    (Outs < 3 && !situation.RunnerOnThird.IsBaseNotEmpty):
                case PitchResult.Popout:
                case PitchResult.ThirdBaseStolen or PitchResult.CaughtStealingOnSecond or PitchResult.CaughtStealingOnThird:
                    return new Runner();
                default:
                    return new Runner(situation.RunnerOnSecond);
            }
        }

        public Runner HavingARunnerOnThirdBase(PitchResult result, GameSituation situation, Match match, int balls)
        {
            if (result == PitchResult.Triple)
                return ReturnNewRunner(match);

            if ((result == PitchResult.Ball && balls == 0 || result == PitchResult.HitByPitch) && situation.RunnerOnFirst.IsBaseNotEmpty && situation.RunnerOnSecond.IsBaseNotEmpty ||
                result == PitchResult.Single ||
                result == PitchResult.SacrificeFly && !situation.RunnerOnThird.IsBaseNotEmpty ||
                result == PitchResult.Popout ||
                result is PitchResult.Groundout or PitchResult.DoublePlay or PitchResult.SacrificeBunt && Outs < 3 && !situation.RunnerOnThird.IsBaseNotEmpty ||
                result == PitchResult.ThirdBaseStolen)
            {
                return new Runner(situation.RunnerOnSecond);
            }

            switch (result)
            {
                case PitchResult.Double or PitchResult.GroundRuleDouble:
                    return new Runner(situation.RunnerOnFirst);
                case PitchResult.HomeRun:
                case PitchResult.CaughtStealingOnThird:
                case PitchResult.SacrificeBunt or PitchResult.DoublePlay or PitchResult.Groundout when Outs < 3 && situation.RunnerOnThird.IsBaseNotEmpty:
                case PitchResult.SacrificeFly when situation.RunnerOnThird.IsBaseNotEmpty:
                case PitchResult.DoublePlayOnFlyout when situation.RunnerOnThird.IsBaseNotEmpty:
                    return new Runner();
                default:
                    return new Runner(situation.RunnerOnThird);
            }
        }

        public List<Runner> GetListOfRunnersInHomeByThisPitch(PitchResult result, GameSituation situation, int balls, Match match)
        {
            var runners = new List<Runner>();

            if ((result is PitchResult.Single or PitchResult.Double or PitchResult.GroundRuleDouble or PitchResult.Triple or PitchResult.HomeRun || 
                (result == PitchResult.HitByPitch || result == PitchResult.Ball && balls == 0) && situation.RunnerOnFirst.IsBaseNotEmpty && situation.RunnerOnSecond.IsBaseNotEmpty && situation.RunnerOnThird.IsBaseNotEmpty ||
                 (result is PitchResult.Groundout or PitchResult.DoublePlay or PitchResult.Popout or PitchResult.SacrificeFly or PitchResult.SacrificeBunt && Outs < 3)) && situation.RunnerOnThird.IsBaseNotEmpty)
            {
                runners.Add(situation.RunnerOnThird);
            }

            if (result is PitchResult.Double or PitchResult.GroundRuleDouble or PitchResult.Triple or PitchResult.HomeRun && situation.RunnerOnSecond.IsBaseNotEmpty) 
                runners.Add(situation.RunnerOnSecond);

            if (result is PitchResult.Triple or PitchResult.HomeRun && situation.RunnerOnFirst.IsBaseNotEmpty)
                runners.Add(situation.RunnerOnFirst);

            if (result is PitchResult.HomeRun) 
                runners.Add(ReturnNewRunner(match));

            return runners;
        }

        public void PrepareForNextPitch(GameSituation gameSituation, Team awayTeam, Team homeTeam, int matchLength)
        {
            if (gameSituation.Result == PitchResult.Ball && gameSituation.Balls == 0 ||
                gameSituation.Result == PitchResult.Strike && gameSituation.Strikes == 0 ||
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
                    InningNumber = (byte)(gameSituation.InningNumber + 1);
                    RunnerOnSecond = InningNumber > matchLength ? new Runner(Offense.BattingLineup[(gameSituation.NumberOfBatterFromAwayTeam == 1 ? 9 : gameSituation.NumberOfBatterFromAwayTeam - 1) - 1], homeTeam.CurrentPitcher, false) : new Runner();
                }
                else
                {
                    Offense = homeTeam;
                    InningNumber = gameSituation.InningNumber;
                    RunnerOnSecond = InningNumber > matchLength ? new Runner(Offense.BattingLineup[(gameSituation.NumberOfBatterFromHomeTeam == 1 ? 9 : gameSituation.NumberOfBatterFromHomeTeam - 1) - 1], awayTeam.CurrentPitcher, false) : new Runner();
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

        public GameSituation Clone() => new(Id, InningNumber, Offense, Result, Balls, Strikes, Outs, RunnerOnFirst, RunnerOnSecond, RunnerOnThird, AwayTeamRuns, HomeTeamRuns, NumberOfBatterFromAwayTeam, NumberOfBatterFromHomeTeam, PitcherID);

        public GameSituation(Pitch pitch, GameSituation previousSituation, Match currentMatch)
        {
            Id = previousSituation.Id + 1;
            Result = pitch.NewPitchResult;
            InningNumber = previousSituation.InningNumber;
            Offense = previousSituation.Offense;
            NumberOfBatterFromAwayTeam = previousSituation.NumberOfBatterFromAwayTeam;
            NumberOfBatterFromHomeTeam = previousSituation.NumberOfBatterFromHomeTeam;
            Balls = NumberOfBallsDetermining(Result, previousSituation);
            Strikes = NumberOfStrikesDetermining(Result, previousSituation);
            Outs = NumberOfOutsDetermining(Result, previousSituation, Strikes);
            RunnerOnFirst = HavingARunnerOnFirstBase(Result, previousSituation, currentMatch, Balls);
            RunnerOnSecond = HavingARunnerOnSecondBase(Result, previousSituation, currentMatch, Balls);
            RunnerOnThird = HavingARunnerOnThirdBase(Result, previousSituation, currentMatch, Balls);
            RunsByThisPitch = GetListOfRunnersInHomeByThisPitch(Result, previousSituation, Balls, currentMatch);
            PitcherID = Offense == currentMatch.AwayTeam ? currentMatch.HomeTeam.CurrentPitcher.PitcherId : currentMatch.AwayTeam.CurrentPitcher.PitcherId;

            if (Offense == currentMatch.AwayTeam)
            {
                AwayTeamRuns = previousSituation.AwayTeamRuns + RunsByThisPitch.Count;
                HomeTeamRuns = previousSituation.HomeTeamRuns;
            }
            else
            {
                HomeTeamRuns = previousSituation.HomeTeamRuns + RunsByThisPitch.Count;
                AwayTeamRuns = previousSituation.AwayTeamRuns;
            }
        }
    }
}