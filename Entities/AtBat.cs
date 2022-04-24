using System.Linq;

namespace Entities
{
    public class AtBat
    {
        public enum AtBatType { Strikeout, Walk, HitByPitch, Flyout, Groundout, Popout, Single, Double, Triple, HomeRun, StolenBase, CaughtStealing, Run, SacrificeFly, SacrificeBunt, NoResult }

        public int MatchId;
        public string Offense;
        public int Batter;
        public AtBatType AtBatResult;
        public string Defense;
        public int Pitcher;
        public int Outs;
        public int RBI;
        public int Inning;

        public AtBatType TypeDefinitionForLastAtBat(GameSituation situation)
        {
            switch (situation.Result)
            {
                case Pitch.PitchResult.Single:
                    {
                        return AtBatType.Single;
                    }
                case Pitch.PitchResult.Double:
                case Pitch.PitchResult.GroundRuleDouble:
                    {
                        return AtBatType.Double;
                    }
                case Pitch.PitchResult.Triple:
                    {
                        return AtBatType.Triple;
                    }
                case Pitch.PitchResult.HomeRun:
                    {
                        return AtBatType.HomeRun;
                    }
                case Pitch.PitchResult.Groundout:
                case Pitch.PitchResult.DoublePlay:
                    {
                        return AtBatType.Groundout;
                    }
                case Pitch.PitchResult.Flyout:
                case Pitch.PitchResult.DoublePlayOnFlyout:
                    {
                        return AtBatType.Flyout;
                    }
                case Pitch.PitchResult.HitByPitch:
                    {
                        return AtBatType.HitByPitch;
                    }
                case Pitch.PitchResult.Popout:
                    {
                        return AtBatType.Popout;
                    }
                case Pitch.PitchResult.SacrificeFly:
                    {
                        return AtBatType.SacrificeFly;
                    }
                case Pitch.PitchResult.Ball:
                    {
                        if (situation.Balls == 0)
                        {
                            return AtBatType.Walk;
                        }
                        return AtBatType.NoResult;
                    }
                case Pitch.PitchResult.Strike:
                    {
                        if (situation.Strikes == 0)
                        {
                            return AtBatType.Strikeout;
                        }
                        return AtBatType.NoResult;
                    }
                case Pitch.PitchResult.SacrificeBunt:
                    {
                        return AtBatType.SacrificeBunt;
                    }
                case Pitch.PitchResult.SecondBaseStolen:
                case Pitch.PitchResult.ThirdBaseStolen:
                    {
                        return AtBatType.StolenBase;
                    }
                case Pitch.PitchResult.CaughtStealingOnSecond:
                case Pitch.PitchResult.CaughtStealingOnThird:
                    {
                        return AtBatType.CaughtStealing;
                    }
                default:
                    {
                        return AtBatType.NoResult;
                    }
            }
        }

        public override string ToString()
        {
            switch (AtBatResult)
            {
                case AtBatType.HitByPitch:
                    {
                        return "Hit-by-Pitch";
                    }
                case AtBatType.HomeRun:
                    {
                        return "Home Run";
                    }
                case AtBatType.StolenBase:
                    {
                        return "Stolen Base";
                    }
                case AtBatType.CaughtStealing:
                    {
                        return "Caught Stealing";
                    }
                case AtBatType.SacrificeBunt:
                    {
                        return "Sacrifice Bunt";
                    }
                case AtBatType.SacrificeFly:
                    {
                        return "Sacrifice Fly";
                    }
                case AtBatType.Strikeout:
                    {
                        return "Strikeout";
                    }
                case AtBatType.Walk:
                    {
                        return "Walk";
                    }
                case AtBatType.Single:
                    {
                        return "Single";
                    }
                case AtBatType.Double:
                    {
                        return "Double";
                    }
                case AtBatType.Triple:
                    {
                        return "Triple";
                    }
                case AtBatType.Flyout:
                    {
                        return "Flyout";
                    }
                case AtBatType.Popout:
                    {
                        return "Popout";
                    }
                case AtBatType.Groundout:
                    {
                        return "Groundout";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        public int OutsForThisAtBat(GameSituation LastSituation, GameSituation previousSituation)
        {
            if (LastSituation.Offense.TeamAbbreviation == previousSituation.Offense.TeamAbbreviation)
            {
                return LastSituation.Outs - previousSituation.Outs;
            }
            return LastSituation.Outs;
        }

        /// <summary>
        /// Normal At-Bat without runs
        /// </summary>
        public AtBat(Match currentMatch, int runs)
        {
            AtBatResult = TypeDefinitionForLastAtBat(currentMatch.GameSituations.Last());
            MatchId = currentMatch.MatchID;
            Offense = currentMatch.GameSituations.Last().Offense.TeamAbbreviation;
            Defense = currentMatch.GameSituations.Last().Offense == currentMatch.AwayTeam ? currentMatch.HomeTeam.TeamAbbreviation : currentMatch.AwayTeam.TeamAbbreviation;

            if (currentMatch.GameSituations.Last().Offense == currentMatch.AwayTeam)
            {
                Batter = currentMatch.AwayTeam.BattingLineup[currentMatch.GameSituations.Last().NumberOfBatterFromHomeTeam - 1].Id;
                Pitcher = currentMatch.HomeTeam.CurrentPitcher.Id;
            }
            else
            {
                Batter = currentMatch.HomeTeam.BattingLineup[currentMatch.GameSituations.Last().NumberOfBatterFromAwayTeam - 1].Id;
                Pitcher = currentMatch.AwayTeam.CurrentPitcher.Id;
            }

            Outs = OutsForThisAtBat(currentMatch.GameSituations.Last(), currentMatch.GameSituations[currentMatch.GameSituations.Count - 2]);
            RBI = runs;
            Inning = currentMatch.GameSituations.Last().InningNumber;
        }

        /// <summary>
        /// New run
        /// </summary>
        public AtBat(Runner runner, Match currentMatch)
        {
            AtBatResult = AtBatType.Run;
            MatchId = currentMatch.MatchID;
            Offense = currentMatch.GameSituations.Last().Offense.TeamAbbreviation;
            Defense = currentMatch.GameSituations.Last().Offense == currentMatch.AwayTeam ? currentMatch.HomeTeam.TeamAbbreviation : currentMatch.AwayTeam.TeamAbbreviation;
            Batter = runner.RunnerID;
            Pitcher = runner.PitcherID;

            Outs = 0;
            RBI = 0;
            Inning = currentMatch.GameSituations.Last().InningNumber;
        }

        /// <summary>
        /// Base stealing result
        /// </summary>
        public AtBat(Match currentMatch, int runnerID, bool isBaseStealingAttempt)
        {
            AtBatResult = TypeDefinitionForLastAtBat(currentMatch.GameSituations.Last());
            MatchId = currentMatch.MatchID;
            Offense = currentMatch.GameSituations.Last().Offense.TeamAbbreviation;
            Defense = currentMatch.GameSituations.Last().Offense == currentMatch.AwayTeam ? currentMatch.HomeTeam.TeamAbbreviation : currentMatch.AwayTeam.TeamAbbreviation;

            if (currentMatch.GameSituations.Last().Offense == currentMatch.AwayTeam)
            {
                Batter = runnerID;
                Pitcher = currentMatch.HomeTeam.CurrentPitcher.Id;
            }
            else
            {
                Batter = runnerID;
                Pitcher = currentMatch.AwayTeam.CurrentPitcher.Id;
            }

            Outs = OutsForThisAtBat(currentMatch.GameSituations.Last(), currentMatch.GameSituations[currentMatch.GameSituations.Count - 2]);
            RBI = 0;
            Inning = currentMatch.GameSituations.Last().InningNumber;
        }
    }
}