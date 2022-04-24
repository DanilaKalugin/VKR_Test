using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;


namespace VKR_Test
{
    class RandomGenerators
    {
        private readonly static Random _stealingAttemptRandomGenerator;
        private readonly static Random _buntAttemptRandomGenerator;
        private readonly static Random _pitcherSubstitutionRandomGenerator;
        private readonly static Random _batterSubstitutionRandomGenerator;

        public enum BaseNumberForStealing { Second, Third }
        public enum StealingAttempt { Attempt, NoAttempt }
        public enum BuntAttempt { Attempt, NoAttempt }
        public enum PitcherSubstitution { Substitution, NoSubstitution }
        public enum BatterSubstitution { Substitution, NoSubstitution }

        public static StealingAttempt stealingAttempt_Definition(BaseNumberForStealing baseNumber, GameSituation situation, Team awayTeam)
        {
            var stealingAttemptRandomValue = _stealingAttemptRandomGenerator.Next(1, 1000);
            var offense = situation.Offense;
            var batterNumberComponent = 5 - Math.Abs(offense == awayTeam ? situation.NumberOfBatterFromHomeTeam - 3 : situation.NumberOfBatterFromAwayTeam - 3);
            var correctedStealingBaseProbability = offense.StealingBaseProbability + batterNumberComponent * 2 + situation.Balls * 10 - situation.Strikes * 15 - situation.Strikes * 5;

            if (baseNumber == BaseNumberForStealing.Third)
            {
                correctedStealingBaseProbability /= 2;
            }

            if (stealingAttemptRandomValue <= correctedStealingBaseProbability)
            {
                return StealingAttempt.Attempt;
            }

            return StealingAttempt.NoAttempt;
        }

        public static BuntAttempt BuntAttempt_Definition(GameSituation situation, Team awayTeam, List<AtBat> atBats)
        {
            var stealingAttemptRandomValue = _buntAttemptRandomGenerator.Next(1, 1000);
            var offense = situation.Offense;
            var batterNumberComponent = offense == awayTeam ? situation.NumberOfBatterFromHomeTeam : situation.NumberOfBatterFromAwayTeam;
            var batterID = situation.Offense.BattingLineup[batterNumberComponent - 1].Id;
            var buntsCount = atBats.Where(atbat => atbat.AtBatResult == AtBat.AtBatType.SacrificeBunt && atbat.Batter == batterID).Count();
            
            if (stealingAttemptRandomValue <= batterNumberComponent * (18 - batterNumberComponent - buntsCount) * 5)
            {
                return BuntAttempt.Attempt;
            }
            
            return BuntAttempt.NoAttempt;
        }

        public static PitcherSubstitution PitcherSubstitution_Definition(Pitcher pitcher, List<AtBat> atBats)
        {
            var pitchingSubstituionRandomValue = _pitcherSubstitutionRandomGenerator.Next(1, 1250);
            var runsByThisPitcher = atBats.Where(atBat => atBat.Pitcher == pitcher.Id && atBat.AtBatResult == AtBat.AtBatType.Run).Count();

            if (pitchingSubstituionRandomValue <= Math.Pow(pitcher.RemainingStamina / 10 - 25, 2) + Math.Pow(runsByThisPitcher + 1, 2))
            {
                return PitcherSubstitution.Substitution;
            }

            return PitcherSubstitution.NoSubstitution;
        }

        /*public static BatterSubstitution BatterSubstitution_Definition()
        {
            
        }*/


        static RandomGenerators()
        {
            Random InitializeRandomGenerator = new Random(DateTime.Now.Second);
            _stealingAttemptRandomGenerator = new Random(23 + InitializeRandomGenerator.Next(1, 1000));
            _buntAttemptRandomGenerator = new Random(29 + InitializeRandomGenerator.Next(1, 1000));
            _pitcherSubstitutionRandomGenerator = new Random(31 + InitializeRandomGenerator.Next(1, 1000));
        }
    }
}