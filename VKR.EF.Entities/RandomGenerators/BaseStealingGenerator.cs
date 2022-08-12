using System;
using System.Linq;
using VKR.EF.Entities.Enums;

namespace VKR.EF.Entities.RandomGenerators
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

            var runnerPositionInDefense = stealingType switch
            {
                StealingType.OnlySecondBase => offense.BattingLineup.First(player => player.BatterId == situation.RunnerOnFirst.RunnerId).PositionForThisMatch,
                StealingType.SecondBaseAfterThird => offense.BattingLineup.First(player => player.BatterId == situation.RunnerOnFirst.RunnerId).PositionForThisMatch,
                StealingType.OnlyThirdBase => offense.BattingLineup.First(player => player.BatterId == situation.RunnerOnSecond.RunnerId).PositionForThisMatch,
                StealingType.ThirdBaseBeforeSecond => offense.BattingLineup.First(player => player.BatterId == situation.RunnerOnSecond.RunnerId).PositionForThisMatch,
                _ => ""
            };

            NewStealingAttemptResult = StealingAttemptResultDefinition(offense.TeamRating.SuccessfulStealingBaseAttemptProbability, runnerPositionInDefense, stealingType);
            _stealingResult = PitchResult_Definition(NewStealingAttemptResult);
            return new Pitch(_stealingResult);
        }

        private static PitchResult PitchResult_Definition(StealingResult newStealingAttemptResult)
        {
            return newStealingAttemptResult switch
            {
                StealingResult.CaughtStealingOnSecond => PitchResult.CaughtStealingOnSecond,
                StealingResult.CaughtStealingOnThird => PitchResult.CaughtStealingOnThird,
                StealingResult.SecondBaseStolen => PitchResult.SecondBaseStolen,
                StealingResult.ThirdBaseStolen => PitchResult.ThirdBaseStolen,
                _ => PitchResult.Null
            };
        }

        private StealingResult StealingAttemptResultDefinition(int successfulStealingProbability, string runnerPositionInDefense, StealingType stealingType)
        {
            var stealingAttemptRandomValue = _stealingResultRandomGenerator.Next(1, 100);

            int stealingProbabilityCorrectedByPosition;

            if (runnerPositionInDefense != "P")
                stealingProbabilityCorrectedByPosition = successfulStealingProbability;
            else
            {
                stealingProbabilityCorrectedByPosition = stealingType == StealingType.SecondBaseAfterThird
                    ? successfulStealingProbability * 2
                    : successfulStealingProbability / 2;
            }

            return stealingType switch
            {
                StealingType.OnlySecondBase when stealingAttemptRandomValue <= stealingProbabilityCorrectedByPosition => StealingResult.SecondBaseStolen,
                StealingType.OnlySecondBase => StealingResult.CaughtStealingOnSecond,
                StealingType.OnlyThirdBase when stealingAttemptRandomValue <= stealingProbabilityCorrectedByPosition / 4 => StealingResult.ThirdBaseStolen,
                StealingType.OnlyThirdBase => StealingResult.CaughtStealingOnThird,
                StealingType.ThirdBaseBeforeSecond when stealingAttemptRandomValue <= stealingProbabilityCorrectedByPosition / 5 => StealingResult.ThirdBaseStolen,
                StealingType.ThirdBaseBeforeSecond => StealingResult.CaughtStealingOnThird,
                StealingType.SecondBaseAfterThird when stealingAttemptRandomValue <= 100 - stealingProbabilityCorrectedByPosition / 3 => StealingResult.SecondBaseStolen,
                StealingType.SecondBaseAfterThird => StealingResult.CaughtStealingOnSecond,
                _ => StealingResult.NoResult
            };
        }

        public StealingAttempt StealingAttemptDefinition(BaseNumberForStealing baseNumber, GameSituation situation, Team awayTeam)
        {
            var stealingAttemptRandomValue = _stealingAttemptRandomGenerator.Next(1, 1000);
            var offense = situation.Offense;
            var batterNumberComponent = 5 - Math.Abs(offense == awayTeam ? situation.NumberOfBatterFromAwayTeam - 3 : situation.NumberOfBatterFromHomeTeam - 3);
            var correctedStealingBaseProbability = offense.TeamRating.StealingBaseProbability + batterNumberComponent * 2 + situation.Balls * 10 - situation.Strikes * 15 - situation.Strikes * 5;

            if (baseNumber == BaseNumberForStealing.Third) correctedStealingBaseProbability /= 2;

            return stealingAttemptRandomValue <= correctedStealingBaseProbability ? StealingAttempt.Attempt : StealingAttempt.NoAttempt;
        }
    }
}