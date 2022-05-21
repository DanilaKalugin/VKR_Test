using System.Collections.Generic;
using System.Linq;

namespace Entities.NET5
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
                case PitchResult.Single:
                    return AtBatType.Single;
                case PitchResult.Double:
                case PitchResult.GroundRuleDouble:
                    return AtBatType.Double;
                case PitchResult.Triple:
                    return AtBatType.Triple;
                case PitchResult.HomeRun:
                    return AtBatType.HomeRun;
                case PitchResult.Groundout:
                case PitchResult.DoublePlay:
                    return AtBatType.Groundout;
                case PitchResult.Flyout:
                case PitchResult.DoublePlayOnFlyout:
                    return AtBatType.Flyout;
                case PitchResult.HitByPitch:
                    return AtBatType.HitByPitch;
                case PitchResult.Popout:
                    return AtBatType.Popout;
                case PitchResult.SacrificeFly:
                    return AtBatType.SacrificeFly;
                case PitchResult.Ball:
                    return situation.Balls == 0 ? AtBatType.Walk : AtBatType.NoResult;
                case PitchResult.Strike when situation.Strikes == 0:
                    return AtBatType.Strikeout;
                case PitchResult.Strike:
                    return AtBatType.NoResult;
                case PitchResult.SacrificeBunt:
                    return AtBatType.SacrificeBunt;
                case PitchResult.SecondBaseStolen:
                case PitchResult.ThirdBaseStolen:
                    return AtBatType.StolenBase;
                case PitchResult.CaughtStealingOnSecond:
                case PitchResult.CaughtStealingOnThird:
                    return AtBatType.CaughtStealing;
                default:
                    return AtBatType.NoResult;
            }
        }

        public override string ToString()
        {
            var atBatResultsDictionary = new Dictionary<AtBatType, string>
            {
                {AtBatType.HitByPitch, "Hit-by-Pitch" },
                {AtBatType.HomeRun, "Home Run" },
                {AtBatType.StolenBase, "Stolen Base" },
                {AtBatType.CaughtStealing, "Caught Stealing" },
                {AtBatType.SacrificeBunt, "Sacrifice Bunt" },
                {AtBatType.SacrificeFly, "Sacrifice Fly"},
                {AtBatType.Strikeout, "Strikeout" },
                {AtBatType.Walk, "Walk"},
                {AtBatType.Single, "Single" },
                {AtBatType.Double, "Double" },
                {AtBatType.Triple, "Triple" },
                {AtBatType.Flyout, "Flyout" },
                {AtBatType.Popout, "Popout" },
                {AtBatType.Groundout, "Groundout" },
            };

            return atBatResultsDictionary.TryGetValue(AtBatResult, out var value) ? value : string.Empty;
        }

        public int OutsForThisAtBat(GameSituation lastSituation, GameSituation previousSituation)
        {
            if (lastSituation.Offense.TeamAbbreviation == previousSituation.Offense.TeamAbbreviation)
                return lastSituation.Outs - previousSituation.Outs;
            return lastSituation.Outs;
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
                Batter = currentMatch.AwayTeam.BattingLineup[currentMatch.GameSituations.Last().NumberOfBatterFromAwayTeam - 1].Id;
                Pitcher = currentMatch.HomeTeam.CurrentPitcher.Id;
            }
            else
            {
                Batter = currentMatch.HomeTeam.BattingLineup[currentMatch.GameSituations.Last().NumberOfBatterFromHomeTeam - 1].Id;
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
            Batter = runner.RunnerId;
            Pitcher = runner.PitcherId;

            Outs = 0;
            RBI = 0;
            Inning = currentMatch.GameSituations.Last().InningNumber;
        }

        /// <summary>
        /// Base stealing result
        /// </summary>
        public AtBat(Match currentMatch, int runnerId, bool isBaseStealingAttempt)
        {
            AtBatResult = TypeDefinitionForLastAtBat(currentMatch.GameSituations.Last());
            MatchId = currentMatch.MatchID;
            Offense = currentMatch.GameSituations.Last().Offense.TeamAbbreviation;
            Defense = currentMatch.GameSituations.Last().Offense == currentMatch.AwayTeam ? currentMatch.HomeTeam.TeamAbbreviation : currentMatch.AwayTeam.TeamAbbreviation;

            if (currentMatch.GameSituations.Last().Offense == currentMatch.AwayTeam)
            {
                Batter = runnerId;
                Pitcher = currentMatch.HomeTeam.CurrentPitcher.Id;
            }
            else
            {
                Batter = runnerId;
                Pitcher = currentMatch.AwayTeam.CurrentPitcher.Id;
            }

            Outs = OutsForThisAtBat(currentMatch.GameSituations.Last(), currentMatch.GameSituations[currentMatch.GameSituations.Count - 2]);
            RBI = 0;
            Inning = currentMatch.GameSituations.Last().InningNumber;
        }
    }
}