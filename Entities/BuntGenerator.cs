using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BuntGenerator : PitchGenerator
    {
        private static readonly Random _buntResultRandomGenerator;
        private static readonly Random _otherConditionRandomGenerator;

        private static OtherCondition _newBuntOtherConditions;


        public enum BuntResult { SuccessfulBunt, FoulOnBunt, SingleOnBunt, HitByPitch, Ball }
        private static BuntResult _newBuntResult;

        private BuntResult BuntResultDefinition(GameSituation situation, int successfulBuntAttemptProbabilty, int strikeZoneProbability, int hitByPitchProbability, int batterNumberComponent)
        {
            var buntRandomValue = _buntResultRandomGenerator.Next(1, 1000);

            if (buntRandomValue <= 50)
                return BuntResult.FoulOnBunt;

            if (buntRandomValue <= (strikeZoneProbability - (situation.Strikes - situation.Balls) * 15) / 3)
                return BuntResult.Ball;

            if (buntRandomValue <= successfulBuntAttemptProbabilty - batterNumberComponent * 15)
                return BuntResult.SuccessfulBunt;

            if (buntRandomValue <= hitByPitchProbability / 3)
                return BuntResult.SingleOnBunt;

            return BuntResult.HitByPitch;
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

            _newBuntResult = BuntResultDefinition(situation, offense.SuccessfulBuntAttemptProbability, defense.StrikeZoneProbability, defense.HitByPitchProbability, batterNumberComponent);
            _newBuntOtherConditions = OtherCondition_Definition(_newBuntResult, situation, defense.DoublePlayProbability, countOfNotEmptyBases);
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

            switch (newBuntResult)
            {
                case BuntResult.FoulOnBunt:
                    return PitchResult.Strike;
                case BuntResult.SuccessfulBunt:
                    return PitchResult.SacrificeBunt;
                case BuntResult.SingleOnBunt:
                    return PitchResult.Single;
                case BuntResult.HitByPitch:
                    return PitchResult.HitByPitch;
                case BuntResult.Ball:
                    return PitchResult.Ball;
                default:
                    return PitchResult.Null;
            }
        }

        static BuntGenerator()
        {
            _buntResultRandomGenerator = new Random(17 + initializeRandomGenerator.Next(1, 1000));
            _otherConditionRandomGenerator = new Random(19 + initializeRandomGenerator.Next(1, 1000));
        }
    }
}
