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
        public int outs;
        public int RBI;
        public int Inning;

        public AtBatType TypeDefinitionForLastAtBat(GameSituation situation)
        {
            switch (situation.result)
            {
                case Pitch.PitchResult.Single:
                    {
                        return AtBatType.Single;
                    }
                case Pitch.PitchResult.Double:
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
                        if (situation.balls == 0)
                        {
                            return AtBatType.Walk;
                        }
                        else
                        {
                            return AtBatType.NoResult;
                        }
                    }
                case Pitch.PitchResult.Strike:
                    {
                        if (situation.strikes == 0)
                        {
                            return AtBatType.Strikeout;
                        }
                        else
                        {
                            return AtBatType.NoResult;
                        }
                    }
                default:
                    {
                        return AtBatType.NoResult;
                    }
            }
        }

        public int OutsForThisAtBat(GameSituation LastSituation, GameSituation previousSituation)
        {
            if (LastSituation.offense.TeamAbbreviation == previousSituation.offense.TeamAbbreviation)
            {
                return LastSituation.outs - previousSituation.outs;
            }
            else return LastSituation.outs;
        }

        public int RBIForThisAtBat(Match currentMatch)
        {
            if (currentMatch.gameSituations.Last().offense == currentMatch.AwayTeam)
            {
                return currentMatch.gameSituations.Last().AwayTeamRuns - currentMatch.gameSituations[currentMatch.gameSituations.Count() - 2].AwayTeamRuns;
            }
            else
            {
                return currentMatch.gameSituations.Last().HomeTeamRuns - currentMatch.gameSituations[currentMatch.gameSituations.Count() - 2].HomeTeamRuns;
            }
        }

        public AtBat(Match currentMatch, int runs)
        {
            AtBatResult = TypeDefinitionForLastAtBat(currentMatch.gameSituations.Last());
            MatchId = currentMatch.MatchID;
            Offense = currentMatch.gameSituations.Last().offense.TeamAbbreviation;
            Defense = currentMatch.gameSituations.Last().offense == currentMatch.AwayTeam ? currentMatch.HomeTeam.TeamAbbreviation : currentMatch.AwayTeam.TeamAbbreviation;

            if (currentMatch.gameSituations.Last().offense == currentMatch.AwayTeam)
            {
                Batter = currentMatch.AwayTeam.BattingLineup[currentMatch.gameSituations.Last().BatterNumber_AwayTeam - 1].id;
                Pitcher = currentMatch.HomeTeam.CurrentPitcher.id;
            }
            else
            {
                Batter = currentMatch.HomeTeam.BattingLineup[currentMatch.gameSituations.Last().BatterNumber_HomeTeam - 1].id;
                Pitcher = currentMatch.AwayTeam.CurrentPitcher.id;
            }

            outs = OutsForThisAtBat(currentMatch.gameSituations.Last(), currentMatch.gameSituations[currentMatch.gameSituations.Count - 2]);
            RBI = runs;
            Inning = currentMatch.gameSituations.Last().inningNumber;
        }

        public AtBat(Runner runner, Match currentMatch)
        {
            AtBatResult = AtBatType.Run;
            MatchId = currentMatch.MatchID;
            Offense = currentMatch.gameSituations.Last().offense.TeamAbbreviation;
            Defense = currentMatch.gameSituations.Last().offense == currentMatch.AwayTeam ? currentMatch.HomeTeam.TeamAbbreviation : currentMatch.AwayTeam.TeamAbbreviation;
            Batter = runner.runnerID;
            Pitcher = runner.pitcherID;

            outs = 0;
            RBI = 0;
            Inning = currentMatch.gameSituations.Last().inningNumber;
        }
    }
}