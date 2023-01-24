using System;
using System.Collections.Generic;
using System.Linq;
using VKR.EF.Entities;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.Tables;
using VKR.EF.Entities.ViewModels;

namespace VKR.PL.Utils.NET5
{
    public class RandomGenerators
    {
        private static readonly Random _buntAttemptRandomGenerator;
        private static readonly Random _pitcherSubstitutionRandomGenerator;
        private static readonly Random _batterSubstitutionRandomGenerator;

        public enum BuntAttempt { Attempt, NoAttempt }
        public enum PitcherSubstitution { Substitution, NoSubstitution }
        public enum BatterSubstitution { Substitution, NoSubstitution }

        public static BuntAttempt BuntAttempt_Definition(GameSituation situation, Team awayTeam, List<AtBat> atBats)
        {
            var stealingAttemptRandomValue = _buntAttemptRandomGenerator.Next(1, 1000);
            var offense = situation.Offense;
            var batterNumberComponent = offense == awayTeam ? situation.NumberOfBatterFromHomeTeam : situation.NumberOfBatterFromAwayTeam;
            var batterId = situation.Offense.BattingLineup[batterNumberComponent - 1].Id;
            var buntsCount = atBats.Count(atBat => atBat.AtBatType == AtBatType.SacrificeBunt && atBat.BatterId == batterId);
            
            return stealingAttemptRandomValue <= batterNumberComponent * (18 - batterNumberComponent - buntsCount) * 5 ? BuntAttempt.Attempt : BuntAttempt.NoAttempt;
        }

        public static PitcherSubstitution PitcherSubstitution_Definition(Pitcher pitcher, List<Run> runs)
        {
            var pitchingSubstitutionRandomValue = _pitcherSubstitutionRandomGenerator.Next(1, 1500);
            var runsByThisPitcher = runs.Count(atBat => atBat.PitcherId == pitcher.PitcherId);

            return pitchingSubstitutionRandomValue <= Math.Pow(pitcher.RemainingStamina / 10 - 25, 2) + Math.Pow(runsByThisPitcher + 1, 2) ? PitcherSubstitution.Substitution : PitcherSubstitution.NoSubstitution;
        }

        public static BatterSubstitution BatterSubstitution_Definition(Batter batter, List<AtBat> atBats)
        {
            var batterSubstitutionRandomValue = _batterSubstitutionRandomGenerator.Next(1, 1000);

            var hitsForThisBatter = atBats.Count(atBat => atBat.BatterId == batter.BatterId && atBat.AtBatType is AtBatType.Double or AtBatType.Triple or AtBatType.HomeRun or AtBatType.Single);
            var outsForThisBatter = atBats.Count(atBat => atBat.BatterId == batter.BatterId && atBat.AtBatType is AtBatType.Groundout or AtBatType.Flyout or AtBatType.SacrificeFly or AtBatType.Strikeout or AtBatType.SacrificeBunt or AtBatType.Walk);

            var atBatsForThisBatter = outsForThisBatter == 0 ? 0 : hitsForThisBatter + outsForThisBatter;

            const int firstCoefficient = 25;
            const int deltaCoefficient = 75;

            return batterSubstitutionRandomValue <=
                   (firstCoefficient * 2 + deltaCoefficient * (outsForThisBatter - 1)) / 2 * (outsForThisBatter + atBatsForThisBatter)
                ? BatterSubstitution.Substitution
                : BatterSubstitution.NoSubstitution;
        }

        static RandomGenerators()
        {
            var initializeRandomGenerator = new Random(DateTime.Now.Second);
            _buntAttemptRandomGenerator = new Random(29 + initializeRandomGenerator.Next(1, 1000));
            _pitcherSubstitutionRandomGenerator = new Random(31 + initializeRandomGenerator.Next(1, 1000));
            _batterSubstitutionRandomGenerator = new Random(37 + initializeRandomGenerator.Next(1, 1000));
        }
    }
}