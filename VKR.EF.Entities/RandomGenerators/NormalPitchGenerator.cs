using System;
using System.Linq;
using VKR.EF.Entities.Enums;

namespace VKR.EF.Entities.RandomGenerators
{
    public class NormalPitchGenerator : PitchGenerator
    {
        protected static readonly Random _gettingIntoStrikeZoneRandomGenerator;
        protected static readonly Random _swingRandomGenerator;
        private static readonly Random _hittingRandomGenerator;
        private static readonly Random _hitTypeRandomGenerator;
        private static readonly Random _outTypeRandomGenerator;
        private static readonly Random _otherConditionRandomGenerator;

        protected enum GettingIntoStrikeZoneTypeOfResult { BallInTheStrikeZone, BallIsOutOfTheStrikeZone, HitByPitch }
        protected GettingIntoStrikeZoneTypeOfResult _newPitchGettingIntoStrikeZoneResult;

        protected enum SwingResultType { Swing, NoSwing, NoResult }
        protected SwingResultType _newPitchSwingResult;

        protected enum HittingResultType { Hit, Miss, NoResult }
        protected HittingResultType _newPitchHitting;

        protected enum HitType { Foul, Single, Double, Triple, HomeRun, NoResult, GroundRuleDouble }
        protected static HitType _newPitchHitType;

        protected enum OutType { Flyout, Groundout, Popout, NoResult }
        protected static OutType _newPitchOutType;

        protected static OtherCondition _newPitchOtherCondition;

        protected PitchResult PitchResultDefinition(GettingIntoStrikeZoneTypeOfResult gettingIntoStrikeZoneResult,
                                                   SwingResultType swingResult,
                                                   HittingResultType hittingResult = HittingResultType.Miss,
                                                   HitType hitTypeResult = HitType.NoResult,
                                                   OutType outType = OutType.NoResult,
                                                   OtherCondition otherCondition = OtherCondition.NoOtherCondition)
        {
            switch (gettingIntoStrikeZoneResult)
            {
                case GettingIntoStrikeZoneTypeOfResult.HitByPitch:
                    return PitchResult.HitByPitch;
                case GettingIntoStrikeZoneTypeOfResult.BallIsOutOfTheStrikeZone when swingResult == SwingResultType.NoSwing:
                    return PitchResult.Ball;
            }

            if ((gettingIntoStrikeZoneResult == GettingIntoStrikeZoneTypeOfResult.BallInTheStrikeZone && swingResult == SwingResultType.NoSwing) ||
                (swingResult == SwingResultType.Swing && hittingResult == HittingResultType.Miss))
                return PitchResult.Strike;

            if (outType == OutType.NoResult)
            {
                return hitTypeResult switch
                {
                    HitType.Foul => PitchResult.Foul,
                    HitType.Single => PitchResult.Single,
                    HitType.Double => PitchResult.Double,
                    HitType.GroundRuleDouble => PitchResult.GroundRuleDouble,
                    HitType.Triple => PitchResult.Triple,
                    HitType.HomeRun => PitchResult.HomeRun,
                    _ => PitchResult.Null
                };
            }

            if (otherCondition == OtherCondition.NoOtherCondition)
            {
                return outType switch
                {
                    OutType.Flyout => PitchResult.Flyout,
                    OutType.Groundout => PitchResult.Groundout,
                    OutType.Popout => PitchResult.Popout,
                    _ => PitchResult.Null
                };
            }

            return otherCondition switch
            {
                OtherCondition.DoublePlay => PitchResult.DoublePlay,
                OtherCondition.SacFly => PitchResult.SacrificeFly,
                OtherCondition.DoublePlayOnFlyout => PitchResult.DoublePlayOnFlyout,
                _ => PitchResult.Null
            };
        }

        public override Pitch CreatePitch(GameSituation situation, Match match)
        {
            var offense = situation.Offense;
            var defense = situation.Offense == match.AwayTeam ? match.HomeTeam : match.AwayTeam;

            var batterNumberComponent = 5 - Math.Abs(offense == match.AwayTeam ? situation.NumberOfBatterFromAwayTeam - 3 : situation.NumberOfBatterFromHomeTeam - 3);
            var currentBatter = situation.Offense == match.AwayTeam ? match.AwayTeam.BattingLineup[situation.NumberOfBatterFromAwayTeam - 1] : match.HomeTeam.BattingLineup[situation.NumberOfBatterFromHomeTeam - 1];

            var numberOfPitches = match.GameSituations.Count(gameSituation => gameSituation.PitcherID == defense.CurrentPitcher.Id);
            var stadiumCoefficient = match.Stadium.StadiumDistanceToCenterfield - 400;
            var countOfNotEmptyBases = Convert.ToInt32(situation.RunnerOnFirst.IsBaseNotEmpty) + Convert.ToInt32(situation.RunnerOnSecond.IsBaseNotEmpty) * 2 + Convert.ToInt32(situation.RunnerOnThird.IsBaseNotEmpty) * 3;
            var pitcherCoefficient = GetPitcherCoefficientForThisPitcher(defense);
            var handsCoefficient = (byte)currentBatter.PlayerBattingHand == (byte)defense.CurrentPitcher.PlayerPitchingHand || currentBatter.PlayerBattingHand == BattingHandEnum.Switch ? 0 : 20;

            if (defense.CurrentPitcher.RemainingStamina < 25)
                numberOfPitches = (int)(numberOfPitches * (1 + Math.Abs(defense.CurrentPitcher.RemainingStamina - 25) / 5 * 0.2));

            if (numberOfPitches > pitcherCoefficient)
            {
                if (defense.PitchersPlayedInMatch.Count > 1)
                    numberOfPitches += (defense.PitchersPlayedInMatch.Count / 2 + 1) * (numberOfPitches - pitcherCoefficient);
                else numberOfPitches += numberOfPitches - pitcherCoefficient;
            }

            _newPitchGettingIntoStrikeZoneResult = GettingIntoStrikeZoneDefinition(defense.StrikeZoneProbability, defense.HitByPitchProbability, numberOfPitches, pitcherCoefficient, situation);
            _newPitchSwingResult = SwingDefinition(_newPitchGettingIntoStrikeZoneResult, offense.SwingInStrikeZoneProbability, offense.SwingOutsideStrikeZoneProbability, situation);
            _newPitchHitting = HittingDefinition(_newPitchSwingResult, offense.HittingProbability, batterNumberComponent, pitcherCoefficient, numberOfPitches, situation, handsCoefficient);
            _newPitchHitType = HitTypeDefinition(_newPitchHitting, offense.SingleProbability, offense.DoubleProbability, offense.HomeRunProbability, offense.TripleProbability, batterNumberComponent, numberOfPitches, stadiumCoefficient, countOfNotEmptyBases, situation, currentBatter);
            _newPitchOutType = OutTypeDefinition(_newPitchHitType, situation, defense.PopoutOnFoulProbability, defense.FlyoutOnHomeRunProbability, defense.GroundoutProbability, defense.FlyoutProbability);
            _newPitchOtherCondition = OtherConditionDefinition(_newPitchOutType, situation, defense.SacrificeFlyProbability, defense.DoublePlayProbability, countOfNotEmptyBases);
            NewPitchResult = PitchResultDefinition(_newPitchGettingIntoStrikeZoneResult, _newPitchSwingResult, _newPitchHitting, _newPitchHitType, _newPitchOutType, _newPitchOtherCondition);
            return new Pitch(NewPitchResult);
        }

        protected static GettingIntoStrikeZoneTypeOfResult GettingIntoStrikeZoneDefinition(int strikeZoneProbability, int hitByPitchProbability, int numberOfPitches, int pitcherCoefficient, GameSituation situation)
        {
            var gettingIntoStrikeZoneRandomValue = _gettingIntoStrikeZoneRandomGenerator.Next(1, 3000);

            if (gettingIntoStrikeZoneRandomValue < strikeZoneProbability - (pitcherCoefficient - numberOfPitches) * 3 + (situation.Strikes - situation.Balls) * 15)
                return GettingIntoStrikeZoneTypeOfResult.BallIsOutOfTheStrikeZone;

            return gettingIntoStrikeZoneRandomValue < hitByPitchProbability ? GettingIntoStrikeZoneTypeOfResult.BallInTheStrikeZone : GettingIntoStrikeZoneTypeOfResult.HitByPitch;
        }

        protected static SwingResultType SwingDefinition(GettingIntoStrikeZoneTypeOfResult ballInStrikeZone, int swingProbabilityInStrikeZone, int swingProbabilityOutsideStrikeZone, GameSituation situation)
        {
            var swingRandomValue = _swingRandomGenerator.Next(1, 100);

            switch (ballInStrikeZone)
            {
                case GettingIntoStrikeZoneTypeOfResult.HitByPitch:
                    return SwingResultType.NoResult;
                case GettingIntoStrikeZoneTypeOfResult.BallInTheStrikeZone when swingRandomValue > swingProbabilityInStrikeZone + situation.Balls - situation.Strikes:
                    return SwingResultType.Swing;
                case GettingIntoStrikeZoneTypeOfResult.BallInTheStrikeZone:
                    return SwingResultType.NoSwing;
            }

            if (swingRandomValue > swingProbabilityOutsideStrikeZone + (situation.Balls - situation.Strikes) / 2)
                return SwingResultType.Swing;

            return SwingResultType.NoSwing;
        }

        private static HittingResultType HittingDefinition(SwingResultType swingResult, int hittingProbability, int batterNumberComponent, int pitcherCoefficient, int numberOfPitches, GameSituation situation, int handsCoefficient)
        {
            var hittingRandomValue = _hittingRandomGenerator.Next(1, 2000);

            if (swingResult != SwingResultType.Swing) return HittingResultType.NoResult;

            if (hittingRandomValue > hittingProbability + pitcherCoefficient - batterNumberComponent * 3 - numberOfPitches / 3 - situation.Balls * 25 + situation.Strikes * 20 - handsCoefficient)
                return HittingResultType.Hit;

            return HittingResultType.Miss;

        }

        private static HitType HitTypeDefinition(HittingResultType hittingResult, int singleProbability, int doubleProbability, int homeRunProbability, int tripleProbability, int batterNumberComponent, int numberOfPitches, int stadiumCoefficient, int countOfNotEmptyBases, GameSituation situation, Batter currentBatter)
        {
            var tripleProbabilityNormalizedByBatterPosition = currentBatter.PositionForThisMatch == "P" ? tripleProbability / 5 : tripleProbability;
            var homeRunProbabilityNormalizedByBatterPosition = currentBatter.PositionForThisMatch == "P" ? homeRunProbability / 8 : homeRunProbability;
            var doubleProbabilityNormalizedByBatterPosition = currentBatter.PositionForThisMatch == "P" ? doubleProbability / 4 : doubleProbability;
            var singleProbabilityNormalizedByBatterPosition = currentBatter.PositionForThisMatch == "P" ? (int)(singleProbability * 1.1) : singleProbability;
            var foulProbabilityNormalizedByBatterPosition = 2000 - tripleProbabilityNormalizedByBatterPosition - homeRunProbabilityNormalizedByBatterPosition - doubleProbabilityNormalizedByBatterPosition - singleProbabilityNormalizedByBatterPosition;

            var hitTypeRandomValue = _hitTypeRandomGenerator.Next(1, 2000);

            if (hittingResult != HittingResultType.Hit) return HitType.NoResult;

            if (hitTypeRandomValue <= foulProbabilityNormalizedByBatterPosition - batterNumberComponent * 7 + countOfNotEmptyBases * 26 + situation.Balls * 20 + situation.Strikes * 25)
                return HitType.Foul;

            if (hitTypeRandomValue <= foulProbabilityNormalizedByBatterPosition + singleProbabilityNormalizedByBatterPosition - batterNumberComponent * 5 + countOfNotEmptyBases * 15)
                return HitType.Single;

            if (hitTypeRandomValue < foulProbabilityNormalizedByBatterPosition + singleProbabilityNormalizedByBatterPosition + doubleProbabilityNormalizedByBatterPosition - batterNumberComponent * 3 + stadiumCoefficient / 3 + countOfNotEmptyBases * 8)
                return HitType.Double;

            if (hitTypeRandomValue == foulProbabilityNormalizedByBatterPosition + singleProbabilityNormalizedByBatterPosition + doubleProbabilityNormalizedByBatterPosition - batterNumberComponent * 3 + stadiumCoefficient / 3 + countOfNotEmptyBases * 8)
                return HitType.GroundRuleDouble;

            if (hitTypeRandomValue <= foulProbabilityNormalizedByBatterPosition + singleProbabilityNormalizedByBatterPosition + doubleProbabilityNormalizedByBatterPosition + homeRunProbabilityNormalizedByBatterPosition - batterNumberComponent - numberOfPitches / 4 - stadiumCoefficient / 9 + countOfNotEmptyBases * 7)
                return HitType.HomeRun;

            return HitType.Triple;
        }

        private static OutType OutTypeDefinition(HitType typeOfHit, GameSituation situation, int popoutOnFoulProbability, int flyoutOnHomeRunProbability, int groundoutProbability, int flyoutProbability)
        {
            var outTypeRandomValue = _outTypeRandomGenerator.Next(1, 1000);

            switch (typeOfHit)
            {
                case HitType.NoResult:
                    return OutType.NoResult;
                case HitType.Foul when outTypeRandomValue < popoutOnFoulProbability - (situation.InningNumber - 1) * 5:
                    return OutType.Popout;
                case HitType.Foul when outTypeRandomValue < popoutOnFoulProbability - (situation.InningNumber - 1) * 5 + (flyoutProbability - groundoutProbability) / 6:
                    return OutType.Flyout;
                case HitType.Foul:
                    return OutType.NoResult;
                case HitType.HomeRun:
                    return outTypeRandomValue > flyoutOnHomeRunProbability ? OutType.Flyout : OutType.NoResult;
            }

            if (outTypeRandomValue <= groundoutProbability && typeOfHit != HitType.GroundRuleDouble)
                return OutType.Groundout;

            if (outTypeRandomValue <= flyoutProbability && typeOfHit != HitType.GroundRuleDouble)
                return OutType.Flyout;

            return OutType.NoResult;
        }

        private static OtherCondition OtherConditionDefinition(OutType outType, GameSituation situation, int sacrificeFlyProbability, int doublePlayProbability, int countOfNotEmptyBases)
        {
            var otherConditionRandomValue = _otherConditionRandomGenerator.Next(1, 100);

            if (outType == OutType.Flyout && (situation.RunnerOnSecond.IsBaseNotEmpty || situation.RunnerOnThird.IsBaseNotEmpty) && situation.Outs < 2 && otherConditionRandomValue <= sacrificeFlyProbability)
                return OtherCondition.SacFly;

            if (outType == OutType.Flyout && situation.RunnerOnThird.IsBaseNotEmpty && situation.Outs < 2 && otherConditionRandomValue <= sacrificeFlyProbability + doublePlayProbability / 10)
                return OtherCondition.DoublePlayOnFlyout;

            if (outType == OutType.Groundout && situation.RunnerOnFirst.IsBaseNotEmpty && situation.Outs < 2 && otherConditionRandomValue <= doublePlayProbability + countOfNotEmptyBases)
                return OtherCondition.DoublePlay;

            return OtherCondition.NoOtherCondition;
        }

        protected static int GetPitcherCoefficientForThisPitcher(Team defense)
        {
            if (defense.CurrentPitcher.IsPinchHitter)
                return 0;

            if (defense.PitchersPlayedInMatch.Count > 1)
                return 28 - defense.PitchersPlayedInMatch.Count;

            return 76 - defense.CurrentPitcher.NumberInRotation * 6;
        }

        static NormalPitchGenerator()
        {
            _gettingIntoStrikeZoneRandomGenerator = new Random(2 + InitializeRandomGenerator.Next(1, 1000));
            _swingRandomGenerator = new Random(3 + InitializeRandomGenerator.Next(1, 1000));
            _hittingRandomGenerator = new Random(5 + InitializeRandomGenerator.Next(1, 1000));
            _hitTypeRandomGenerator = new Random(7 + InitializeRandomGenerator.Next(1, 1000));
            _outTypeRandomGenerator = new Random(11 + InitializeRandomGenerator.Next(1, 1000));
            _otherConditionRandomGenerator = new Random(13 + InitializeRandomGenerator.Next(1, 1000));
        }
    }
}