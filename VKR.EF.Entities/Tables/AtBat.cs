using System.Collections.Generic;
using System.Linq;
using VKR.EF.Entities.Enums;

namespace VKR.EF.Entities
{
    public class AtBat
    {
        public long Id { get; set; }
        public Match Match { get; set; }
        public int MatchId { get; set; }
        public PlayerInTeam Batter { get; set; }
        public uint BatterId { get; set; }
        public AtBatResult AtBatResult { get; set; }
        public AtBatType AtBatType { get; set; }
        public PlayerInTeam Pitcher { get; set; }
        public uint PitcherId { get; set; }
        public byte Outs { get; set; }
        public byte RBI { get; set; }
        public byte Inning { get; set; }

        public string Offense;
        public string Defense;

        public AtBat()
        {

        }

        public AtBatType TypeDefinitionForLastAtBat(GameSituation situation)
        {
            return situation.Result switch
            {
                PitchResult.Single => AtBatType.Single,
                PitchResult.Double => AtBatType.Double,
                PitchResult.GroundRuleDouble => AtBatType.Double,
                PitchResult.Triple => AtBatType.Triple,
                PitchResult.HomeRun => AtBatType.HomeRun,
                PitchResult.Groundout => AtBatType.Groundout,
                PitchResult.DoublePlay => AtBatType.Groundout,
                PitchResult.Flyout => AtBatType.Flyout,
                PitchResult.DoublePlayOnFlyout => AtBatType.Flyout,
                PitchResult.HitByPitch => AtBatType.HitByPitch,
                PitchResult.Popout => AtBatType.Popout,
                PitchResult.SacrificeFly => AtBatType.SacrificeFly,
                PitchResult.Ball when situation.Balls == 0 => AtBatType.Walk,
                PitchResult.Ball => AtBatType.NoResult,
                PitchResult.Strike when situation.Strikes == 0 => AtBatType.Strikeout,
                PitchResult.Strike => AtBatType.NoResult,
                PitchResult.SacrificeBunt => AtBatType.SacrificeBunt,
                PitchResult.SecondBaseStolen => AtBatType.StolenBase,
                PitchResult.ThirdBaseStolen => AtBatType.StolenBase,
                PitchResult.CaughtStealingOnSecond => AtBatType.CaughtStealing,
                PitchResult.CaughtStealingOnThird => AtBatType.CaughtStealing,
                _ => AtBatType.NoResult
            };
        }

        public byte OutsForThisAtBat(GameSituation lastSituation, GameSituation previousSituation)
        {
            if (lastSituation.Offense.TeamAbbreviation == previousSituation.Offense.TeamAbbreviation)
                return (byte)(lastSituation.Outs - previousSituation.Outs);

            return lastSituation.Outs;
        }

        /// <summary>
        /// Normal At-Bat without runs
        /// </summary>
        public AtBat(Match currentMatch, byte runs)
        {
            AtBatType = TypeDefinitionForLastAtBat(currentMatch.GameSituations.Last());
            MatchId = currentMatch.Id;
            Offense = currentMatch.GameSituations.Last().Offense.TeamAbbreviation;
            Defense = currentMatch.GameSituations.Last().Offense == currentMatch.AwayTeam ? currentMatch.HomeTeam.TeamAbbreviation : currentMatch.AwayTeam.TeamAbbreviation;

            if (currentMatch.GameSituations.Last().Offense == currentMatch.AwayTeam)
            {
                BatterId = currentMatch.AwayTeam.BattingLineup[currentMatch.GameSituations.Last().NumberOfBatterFromAwayTeam - 1].BatterId;
                PitcherId = currentMatch.HomeTeam.CurrentPitcher.PitcherId;
            }
            else
            {
                BatterId = currentMatch.HomeTeam.BattingLineup[currentMatch.GameSituations.Last().NumberOfBatterFromHomeTeam - 1].BatterId;
                PitcherId = currentMatch.AwayTeam.CurrentPitcher.PitcherId;
            }

            Outs = (byte)OutsForThisAtBat(currentMatch.GameSituations.Last(), currentMatch.GameSituations[^2]);
            RBI = runs;
            Inning = currentMatch.GameSituations.Last().InningNumber;
        }

        /// <summary>
        /// Base stealing result
        /// </summary>
        public AtBat(Match currentMatch, uint runnerId, bool isBaseStealingAttempt)
        {
            AtBatType = TypeDefinitionForLastAtBat(currentMatch.GameSituations.Last());
            MatchId = currentMatch.Id;
            Offense = currentMatch.GameSituations.Last().Offense.TeamAbbreviation;
            Defense = currentMatch.GameSituations.Last().Offense == currentMatch.AwayTeam ? currentMatch.HomeTeam.TeamAbbreviation : currentMatch.AwayTeam.TeamAbbreviation;

            if (currentMatch.GameSituations.Last().Offense == currentMatch.AwayTeam)
            {
                BatterId = runnerId;
                PitcherId = currentMatch.HomeTeam.CurrentPitcher.PitcherId;
            }
            else
            {
                BatterId = runnerId;
                PitcherId = currentMatch.AwayTeam.CurrentPitcher.PitcherId;
            }

            Outs = (byte)OutsForThisAtBat(currentMatch.GameSituations.Last(), currentMatch.GameSituations[^2]);
            RBI = 0;
            Inning = currentMatch.GameSituations.Last().InningNumber;
        }

        public override string ToString()
        {
            var atBatResultsDictionary = new Dictionary<AtBatType, string>
            {
                { AtBatType.HitByPitch, "Hit-by-Pitch" },
                { AtBatType.HomeRun, "Home Run" },
                { AtBatType.StolenBase, "Stolen Base" },
                { AtBatType.CaughtStealing, "Caught Stealing" },
                { AtBatType.SacrificeBunt, "Sacrifice Bunt" },
                { AtBatType.SacrificeFly, "Sacrifice Fly" },
                { AtBatType.Strikeout, "Strikeout" },
                { AtBatType.Walk, "Walk" },
                { AtBatType.Single, "Single" },
                { AtBatType.Double, "Double" },
                { AtBatType.Triple, "Triple" },
                { AtBatType.Flyout, "Flyout" },
                { AtBatType.Popout, "Popout" },
                { AtBatType.Groundout, "Groundout" }
            };

            return atBatResultsDictionary.TryGetValue(AtBatType, out var value) ? value : string.Empty;
        }
    }
}