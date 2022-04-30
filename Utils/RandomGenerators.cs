using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace VKR.PL.Utils
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
            var batterID = situation.Offense.BattingLineup[batterNumberComponent - 1].Id;
            var buntsCount = atBats.Count(atBat => atBat.AtBatResult == AtBat.AtBatType.SacrificeBunt && atBat.Batter == batterID);
            
            return stealingAttemptRandomValue <= batterNumberComponent * (18 - batterNumberComponent - buntsCount) * 5 ? BuntAttempt.Attempt : BuntAttempt.NoAttempt;
        }

        public static PitcherSubstitution PitcherSubstitution_Definition(Pitcher pitcher, List<AtBat> atBats)
        {
            var pitchingSubstitutionRandomValue = _pitcherSubstitutionRandomGenerator.Next(1, 1250);
            var runsByThisPitcher = atBats.Count(atBat => atBat.Pitcher == pitcher.Id && atBat.AtBatResult == AtBat.AtBatType.Run);

            return pitchingSubstitutionRandomValue <= Math.Pow(pitcher.RemainingStamina / 10 - 25, 2) + Math.Pow(runsByThisPitcher + 1, 2) ? PitcherSubstitution.Substitution : PitcherSubstitution.NoSubstitution;
        }

        /*public static BatterSubstitution BatterSubstitution_Definition()
        {
            
        }*/

        static RandomGenerators()
        {
            var initializeRandomGenerator = new Random(DateTime.Now.Second);
            _buntAttemptRandomGenerator = new Random(29 + initializeRandomGenerator.Next(1, 1000));
            _pitcherSubstitutionRandomGenerator = new Random(31 + initializeRandomGenerator.Next(1, 1000));
        }
    }
}