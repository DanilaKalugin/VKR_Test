﻿using System.Globalization;
using System.Linq;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.Tables;
using VKR.EF.Entities.ViewModels;

namespace VKR.PL.Utils.NET5
{
    public class HitsForAtBatsHelper
    {
        public static string GetDailyStats(Batter batter, Match match)
        {
            var hitsForAtBats = GetHitsForAtBats(batter, match);

            if (!string.IsNullOrWhiteSpace(hitsForAtBats)) return hitsForAtBats; 

            if (match.AtBats.Any(atBat => atBat.BatterId == batter.BatterId && atBat.AtBatType == AtBatType.HitByPitch)) return "HBP";

            if (match.AtBats.Any(atBat => atBat.BatterId == batter.BatterId && atBat.AtBatType == AtBatType.Walk))
            {
                var numberOfWalks = match.AtBats.Count(atBat =>
                    atBat.BatterId == batter.BatterId && atBat.AtBatType == AtBatType.Walk);
                return numberOfWalks == 1 ? "WALK" : $"{numberOfWalks} WALKS";
            }

            if (match.AtBats.Any(atBat => atBat.BatterId == batter.BatterId && atBat.AtBatType == AtBatType.SacrificeFly)) 
                return "SAC FLY";

            if (match.AtBats.Any(atBat => atBat.BatterId == batter.BatterId && atBat.AtBatType == AtBatType.SacrificeBunt)) 
                return "SAC BUNT";

            return batter.BattingStats.AVG.ToString("#.000", new CultureInfo("en-US"));
        }

        public static string GetHitsForAtBats(Batter batter, Match match)
        {
            var atBatsCount = match.AtBats.Count(atBat => atBat.BatterId == batter.BatterId &&
                                                          atBat.AtBatType is AtBatType.Double or 
                                                                               AtBatType.Triple or 
                                                                               AtBatType.HomeRun or 
                                                                               AtBatType.Single or 
                                                                               AtBatType.Popout or 
                                                                               AtBatType.Strikeout or 
                                                                               AtBatType.Flyout or 
                                                                               AtBatType.Groundout);

            var hitsCount = match.AtBats.Count(atBat => atBat.BatterId == batter.BatterId &&
                                                        atBat.AtBatType is AtBatType.Double or 
                                                                             AtBatType.Triple or 
                                                                             AtBatType.HomeRun or 
                                                                             AtBatType.Single);
            
            return atBatsCount > 0 ? $"{hitsCount} FOR {atBatsCount}" : string.Empty;
        }
    }
}