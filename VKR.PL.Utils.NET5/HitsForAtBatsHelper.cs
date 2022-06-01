using System.Globalization;
using System.Linq;
using VKR.Entities.NET5;

namespace VKR.PL.Utils.NET5
{
    public class HitsForAtBatsHelper
    {
        public static string GetDailyStats(Batter batter, Match match)
        {
            var hitsForAtBats = GetHitsForAtBats(batter, match);

            if (!string.IsNullOrWhiteSpace(hitsForAtBats)) return hitsForAtBats; 

            if (match.AtBats.Any(atBat => atBat.Batter == batter.Id && atBat.AtBatResult == AtBat.AtBatType.HitByPitch)) return "HBP";

            if (match.AtBats.Any(atBat => atBat.Batter == batter.Id && atBat.AtBatResult == AtBat.AtBatType.Walk))
            {
                var numberOfWalks = match.AtBats.Count(atBat =>
                    atBat.Batter == batter.Id && atBat.AtBatResult == AtBat.AtBatType.Walk);
                return numberOfWalks == 1 ? "WALK" : $"{numberOfWalks} WALKS";
            }

            if (match.AtBats.Any(atBat => atBat.Batter == batter.Id && atBat.AtBatResult == AtBat.AtBatType.SacrificeFly)) 
                return "SAC FLY";

            return batter.BattingStats.AVG.ToString("#.000", new CultureInfo("en-US"));
        }

        public static string GetHitsForAtBats(Batter batter, Match match)
        {
            var atBatsCount = match.AtBats.Count(atBat => atBat.Batter == batter.Id &&
                                                          atBat.AtBatResult is AtBat.AtBatType.Double or 
                                                                               AtBat.AtBatType.Triple or 
                                                                               AtBat.AtBatType.HomeRun or 
                                                                               AtBat.AtBatType.Single or 
                                                                               AtBat.AtBatType.Popout or 
                                                                               AtBat.AtBatType.Strikeout or 
                                                                               AtBat.AtBatType.Flyout or 
                                                                               AtBat.AtBatType.Groundout);

            var hitsCount = match.AtBats.Count(atBat => atBat.Batter == batter.Id &&
                                                        atBat.AtBatResult is AtBat.AtBatType.Double or 
                                                                             AtBat.AtBatType.Triple or 
                                                                             AtBat.AtBatType.HomeRun or 
                                                                             AtBat.AtBatType.Single);
            
            return atBatsCount > 0 ? $"{hitsCount} FOR {atBatsCount}" : "";
        }
    }
}