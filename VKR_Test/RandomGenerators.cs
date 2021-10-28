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
        private readonly static Random StealingAttempt_RandomGenerator;
        private readonly static Random BuntAttempt_RandomGenerator;
        private readonly static Random PitcherSubstitution_RandomGenerator;
        private readonly static Random BatterSubstitution_RandomGenerator; 

        public enum BaseNumberForStealing { Second, Third }
        public enum StealingAttempt { Attempt, NoAttempt }
        public enum BuntAttempt { Attempt, NoAttempt }
        public enum PitcherSubstitution { Substitution, NoSubstitution }
        public enum BatterSubstitution { Substitution, NoSubstitution }

        public static StealingAttempt stealingAttempt_Definition(BaseNumberForStealing baseNumber, GameSituation situation, Team AwayTeam)
        {
            int StealingAttempt_RandomValue = StealingAttempt_RandomGenerator.Next(1, 1000);
            Team Offense = situation.offense;
            int BatterNumberComponent = 5 - Math.Abs(Offense == AwayTeam ? situation.BatterNumber_AwayTeam - 3 : situation.BatterNumber_HomeTeam - 3);
            int SbAttempt_ProbabilityWithAllCoefficients = Offense.StealingBaseProbability + BatterNumberComponent * 2 + situation.balls * 10 - situation.strikes * 15 - situation.strikes * 5;

            if (baseNumber == BaseNumberForStealing.Third)
            {
                SbAttempt_ProbabilityWithAllCoefficients /= 2;
            }
            if (StealingAttempt_RandomValue <= SbAttempt_ProbabilityWithAllCoefficients)
            {
                return StealingAttempt.Attempt;
            }
            else
            {
                return StealingAttempt.NoAttempt;
            }
        }

        public static BuntAttempt BuntAttempt_Definition(GameSituation situation, Team AwayTeam, List<AtBat> atbats)
        {
            int StealingAttempt_RandomValue = BuntAttempt_RandomGenerator.Next(1, 1000);
            Team Offense = situation.offense;
            int BatterNumberComponent = Offense == AwayTeam ? situation.BatterNumber_AwayTeam : situation.BatterNumber_HomeTeam;
            int BatterID = situation.offense.BattingLineup[BatterNumberComponent - 1].id;
            int BuntsCount = atbats.Where(atbat => atbat.AtBatResult == AtBat.AtBatType.SacrificeBunt && atbat.Batter == BatterID).Count();
            if (StealingAttempt_RandomValue <= BatterNumberComponent * (18 - BatterNumberComponent - BuntsCount) * 5)
            {
                return BuntAttempt.Attempt;
            }
            else
            {
                return BuntAttempt.NoAttempt;
            }
        }

        public static PitcherSubstitution PitcherSubstitution_Definition(Pitcher pitcher, List<AtBat> atBats)
        {
            int PitchingSubstituion_RandomValue = PitcherSubstitution_RandomGenerator.Next(1, 1250);
            int RunsByThisPitcher = atBats.Where(atBat => atBat.Pitcher == pitcher.id && atBat.AtBatResult == AtBat.AtBatType.Run).Count();
            if (PitchingSubstituion_RandomValue <= Math.Pow(pitcher.RemainingStamina / 10 - 25, 2) + Math.Pow(RunsByThisPitcher + 1, 2)) 
            {
                return PitcherSubstitution.Substitution;
            }
            else
            {
                return PitcherSubstitution.NoSubstitution;
            }
        }

        /*public static BatterSubstitution BatterSubstitution_Definition()
        {
            
        }*/


        static RandomGenerators()
        {
            Random InitializeRandomGenerator = new Random(DateTime.Now.Second);
            StealingAttempt_RandomGenerator = new Random(23 + InitializeRandomGenerator.Next(1, 1000));
            BuntAttempt_RandomGenerator = new Random(29 + InitializeRandomGenerator.Next(1, 1000));
            PitcherSubstitution_RandomGenerator = new Random(31 + InitializeRandomGenerator.Next(1, 1000));
        }
    }
}