using System;
using System.Linq;

namespace Entities.NET5
{
    public class BaseStealingGenerator
    {
        private static readonly Random _stealingResultRandomGenerator;
        private static readonly Random _stealingAttemptRandomGenerator;

        public enum StealingType { OnlySecondBase, OnlyThirdBase, ThirdBaseBeforeSecond, SecondBaseAfterThird }

        public enum StealingResult { SecondBaseStolen, ThirdBaseStolen, NoResult, CaughtStealingOnSecond, CaughtStealingOnThird }
        public static StealingResult NewStealingAttemptResult;

        private PitchResult _stealingResult;

        public enum BaseNumberForStealing { Second, Third }
        public enum StealingAttempt { Attempt, NoAttempt }

        static BaseStealingGenerator()
        {
            _stealingResultRandomGenerator = new Random(19);
            _stealingAttemptRandomGenerator = new Random(23);
        }

        public Pitch CreateBaseStealing(GameSituation situation, StealingType stealingType)
        {
            var offense = situation.Offense;
            var runnerPositionInDefense = "";

            switch (stealingType)
            {
                case StealingType.OnlySecondBase:
                case StealingType.SecondBaseAfterThird:
                    runnerPositionInDefense = offense.BattingLineup.First(player => player.Id == situation.RunnerOnFirst.RunnerId).PositionForThisMatch;
                    break;
                case StealingType.OnlyThirdBase:
                case StealingType.ThirdBaseBeforeSecond:
                    runnerPositionInDefense = offense.BattingLineup.First(player => player.Id == situation.RunnerOnSecond.RunnerId).PositionForThisMatch;
                    break;
            }

            NewStealingAttemptResult = StealingAttemptResultDefinition(offense.SuccessfulStealingBaseAttemptProbability, runnerPositionInDefense, stealingType);
            _stealingResult = PitchResult_Definition(NewStealingAttemptResult);
            return new Pitch(_stealingResult);
        }

        private static PitchResult PitchResult_Definition(StealingResult newStealingAttemptResult)
        {
            switch (newStealingAttemptResult)
            {
                case StealingResult.CaughtStealingOnSecond:
                    return PitchResult.CaughtStealingOnSecond;
                case StealingResult.CaughtStealingOnThird:
                    return PitchResult.CaughtStealingOnThird;
                case StealingResult.SecondBaseStolen:
                    return PitchResult.SecondBaseStolen;
                case StealingResult.ThirdBaseStolen:
                    return PitchResult.ThirdBaseStolen;
                default:
                    return PitchResult.Null;
            }
        }

        private StealingResult StealingAttemptResultDefinition(int successfulStealingProbability, string runnerPositionInDefense, StealingType stealingType)
        {
            var stealingAttemptRandomValue = _stealingResultRandomGenerator.Next(1, 100);

            int stealingProbabilityCorrectedByPosition;

            if (runnerPositionInDefense != "P")
                stealingProbabilityCorrectedByPosition = successfulStealingProbability;
            else
            {
                if (stealingType == StealingType.SecondBaseAfterThird)
                    stealingProbabilityCorrectedByPosition = successfulStealingProbability * 2;
                else
                    stealingProbabilityCorrectedByPosition = successfulStealingProbability / 2;
            }

            switch (stealingType)
            {
                case StealingType.OnlySecondBase when stealingAttemptRandomValue <= stealingProbabilityCorrectedByPosition:
                    return StealingResult.SecondBaseStolen;
                case StealingType.OnlySecondBase:
                    return StealingResult.CaughtStealingOnSecond;
                case StealingType.OnlyThirdBase when stealingAttemptRandomValue <= stealingProbabilityCorrectedByPosition / 4:
                    return StealingResult.ThirdBaseStolen;
                case StealingType.OnlyThirdBase:
                    return StealingResult.CaughtStealingOnThird;
                case StealingType.ThirdBaseBeforeSecond when stealingAttemptRandomValue <= stealingProbabilityCorrectedByPosition / 5:
                    return StealingResult.ThirdBaseStolen;
                case StealingType.ThirdBaseBeforeSecond:
                    return StealingResult.CaughtStealingOnThird;
                case StealingType.SecondBaseAfterThird when stealingAttemptRandomValue <= 100 - stealingProbabilityCorrectedByPosition / 3:
                    return StealingResult.SecondBaseStolen;
                case StealingType.SecondBaseAfterThird:
                    return StealingResult.CaughtStealingOnSecond;
                default:
                    return StealingResult.NoResult;
            }
        }

        public StealingAttempt StealingAttemptDefinition(BaseNumberForStealing baseNumber, GameSituation situation, Team awayTeam)
        {
            var stealingAttemptRandomValue = _stealingAttemptRandomGenerator.Next(1, 1000);
            var offense = situation.Offense;
            var batterNumberComponent = 5 - Math.Abs(offense == awayTeam ? situation.NumberOfBatterFromAwayTeam - 3 : situation.NumberOfBatterFromHomeTeam - 3);
            var correctedStealingBaseProbability = offense.StealingBaseProbability + batterNumberComponent * 2 + situation.Balls * 10 - situation.Strikes * 15 - situation.Strikes * 5;

            if (baseNumber == BaseNumberForStealing.Third) correctedStealingBaseProbability /= 2;

            return stealingAttemptRandomValue <= correctedStealingBaseProbability ? StealingAttempt.Attempt : StealingAttempt.NoAttempt;
        }
    }
}