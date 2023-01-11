using System;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.RandomGenerators
{
    public class BuntGenerator : PitchGenerator
    {
        private static readonly Random _buntResultRandomGenerator;
        private static readonly Random _otherConditionRandomGenerator;

        private static OtherCondition _newBuntOtherConditions;


        public enum BuntResult { SuccessfulBunt, FoulOnBunt, SingleOnBunt, HitByPitch, Ball }
        private static BuntResult _newBuntResult;

        private BuntResult BuntResultDefinition(GameSituation situation, int successfulBuntAttemptProbability, int strikeZoneProbability, int hitByPitchProbability, int batterNumberComponent)
        {
            var buntRandomValue = _buntResultRandomGenerator.Next(1, 1000);

            if (buntRandomValue <= 50)
                return BuntResult.FoulOnBunt;

            if (buntRandomValue <= (strikeZoneProbability - (situation.Strikes - situation.Balls) * 15) / 3)
                return BuntResult.Ball;

            if (buntRandomValue <= successfulBuntAttemptProbability - batterNumberComponent * 15)
                return BuntResult.SuccessfulBunt;

            return buntRandomValue <= hitByPitchProbability / 3 ? BuntResult.SingleOnBunt : BuntResult.HitByPitch;
        }

        /// <summary>
        /// Bunt generator
        /// </summary>
        public override Pitch CreatePitch(GameSituation situation, Match match)
        {
            var offense = situation.Offense;
            var defense = situation.Offense == match.AwayTeam ? match.HomeTeam : match.AwayTeam;

            var batterNumberComponent = 5 - Math.Abs(offense == match.AwayTeam ? situation.NumberOfBatterFromAwayTeam - 3 : situation.NumberOfBatterFromHomeTeam - 3);
            var countOfNotEmptyBases = Convert.ToInt32(situation.RunnerOnFirst.IsBaseNotEmpty) + Convert.ToInt32(situation.RunnerOnSecond.IsBaseNotEmpty) * 2 + Convert.ToInt32(situation.RunnerOnThird.IsBaseNotEmpty) * 3;

            _newBuntResult = BuntResultDefinition(situation, offense.TeamRating.SuccessfulBuntAttemptProbability, defense.TeamRating.StrikeZoneProbability, defense.TeamRating.HitByPitchProbability, batterNumberComponent);
            _newBuntOtherConditions = OtherCondition_Definition(_newBuntResult, situation, defense.TeamRating.DoublePlayProbability, countOfNotEmptyBases);
            NewPitchResult = PitchResultDefinition(_newBuntResult, _newBuntOtherConditions);
            return new Pitch(NewPitchResult);
        }

        private OtherCondition OtherCondition_Definition(BuntResult newBuntResult, GameSituation situation, int doublePlayProbability, int countOfNotEmptyBases)
        {
            var otherConditionRandomValue = _otherConditionRandomGenerator.Next(1, 100);

            if (newBuntResult == BuntResult.SuccessfulBunt && situation.RunnerOnFirst.IsBaseNotEmpty && situation.Outs <= 1 && otherConditionRandomValue <= doublePlayProbability + countOfNotEmptyBases)
                return OtherCondition.DoublePlay;

            return OtherCondition.NoOtherCondition;
        }

        private PitchResult PitchResultDefinition(BuntResult newBuntResult, OtherCondition otherCondition)
        {
            if (otherCondition != OtherCondition.NoOtherCondition) return PitchResult.DoublePlay;

            return newBuntResult switch
            {
                BuntResult.FoulOnBunt => PitchResult.Strike,
                BuntResult.SuccessfulBunt => PitchResult.SacrificeBunt,
                BuntResult.SingleOnBunt => PitchResult.Single,
                BuntResult.HitByPitch => PitchResult.HitByPitch,
                BuntResult.Ball => PitchResult.Ball,
                _ => PitchResult.Null
            };
        }

        static BuntGenerator()
        {
            _buntResultRandomGenerator = new Random(17 + InitializeRandomGenerator.Next(1, 1000));
            _otherConditionRandomGenerator = new Random(19 + InitializeRandomGenerator.Next(1, 1000));
        }
    }
}