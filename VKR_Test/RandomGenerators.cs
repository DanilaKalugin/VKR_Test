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

        public enum BaseNumberForStealing { Second, Third }
        public enum StealingAttempt { Attempt, NoAttempt }
        public enum BuntAttempt { Attempt, NoAttempt }

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

        public static BuntAttempt BuntAttempt_Definition(GameSituation situation, Team AwayTeam)
        {
            int StealingAttempt_RandomValue = BuntAttempt_RandomGenerator.Next(1, 1000);
            Team Offense = situation.offense;
            int BatterNumberComponent = Offense == AwayTeam ? situation.BatterNumber_AwayTeam : situation.BatterNumber_HomeTeam;
            if (StealingAttempt_RandomValue <= BatterNumberComponent * (18 - BatterNumberComponent) * 5)
            {
                return BuntAttempt.Attempt;
            }
            else
            {
                return BuntAttempt.NoAttempt;
            }
        }

        static RandomGenerators()
        {
            Random InitializeRandomGenerator = new Random(DateTime.Now.Second);
            StealingAttempt_RandomGenerator = new Random(23 + InitializeRandomGenerator.Next(1, 1000));
            BuntAttempt_RandomGenerator = new Random(29 + InitializeRandomGenerator.Next(1, 1000));
        }
    }
}
