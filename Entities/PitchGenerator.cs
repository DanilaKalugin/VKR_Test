﻿using System;
using System.Linq;

namespace Entities
{
    public class PitchGenerator
    {
        private static readonly Random _gettingIntoStrikeZoneRandomGenerator;
        private static readonly Random _swingRandomGenerator;
        private static readonly Random _hittingRandomGenerator;
        private static readonly Random _hitTypeRandomGenerator;
        private static readonly Random _outTypeRandomGenerator;
        private static readonly Random _otherConditionRandomGenerator;
        private static readonly Random _buntResultRandomGenerator;
        private static readonly Random _stealingResultRandomGenerator;

        private enum GettingIntoStrikeZoneTypeOfResult { BallInTheStrikeZone, BallIsOutOfTheStrikeZone, HitByPitch }
        private static GettingIntoStrikeZoneTypeOfResult _newPitchGettingIntoStrikeZoneResult;

        private enum SwingResultType { Swing, NoSwing, NoResult }
        private static SwingResultType _newPitchSwingResult;

        private enum HittingResultType { Hit, Miss, NoResult }
        private static HittingResultType _newPitchHitting;

        private enum HitType { Foul, Single, Double, Triple, HomeRun, NoResult, GroundRuleDouble }
        private static HitType _newPitchHitType;

        private enum OutType { Flyout, Groundout, Popout, NoResult }
        private static OutType _newPitchOutType;

        private enum OtherCondition { SacFly, DoublePlay, NoOtherCondition, DoublePlayOnFlyout }
        private static OtherCondition _newPitchOtherCondition;
        private static OtherCondition _newBuntOtherConditions;

        public enum BuntResult { SuccessfulBunt, FoulOnBunt, SingleOnBunt, HitByPitch, Ball }
        private static BuntResult _newBuntResult;

        public static PitchResult NewPitchResult;

        public enum StealingType { OnlySecondBase, OnlyThirdBase, ThirdBaseBeforeSecond, SecondBaseAfterThird }

        public enum StealingResult { SecondBaseStolen, ThirdBaseStolen, NoResult, CaughtStealingOnSecond, CaughtStealingOnThird }
        public static StealingResult NewStealingAttemptResult;

        private static PitchResult PitchResultDefinition(GettingIntoStrikeZoneTypeOfResult gettingIntoStrikeZoneResult,
                                                   SwingResultType swingResult,
                                                   HittingResultType hittingResult = HittingResultType.Miss,
                                                   HitType hitTypeResult = HitType.NoResult,
                                                   OutType outType = OutType.NoResult,
                                                   OtherCondition otherCondition = OtherCondition.NoOtherCondition)
        {
            if (gettingIntoStrikeZoneResult == GettingIntoStrikeZoneTypeOfResult.HitByPitch)
                return PitchResult.HitByPitch;

            if (gettingIntoStrikeZoneResult == GettingIntoStrikeZoneTypeOfResult.BallIsOutOfTheStrikeZone &&
                swingResult == SwingResultType.NoSwing)
                return PitchResult.Ball;

            if ((gettingIntoStrikeZoneResult == GettingIntoStrikeZoneTypeOfResult.BallInTheStrikeZone && swingResult == SwingResultType.NoSwing) ||
                (swingResult == SwingResultType.Swing && hittingResult == HittingResultType.Miss))
                return PitchResult.Strike;

            if (outType == OutType.NoResult)
            {
                switch (hitTypeResult)
                {
                    case HitType.Foul:
                        return PitchResult.Foul;
                    case HitType.Single:
                        return PitchResult.Single;
                    case HitType.Double:
                        return PitchResult.Double;
                    case HitType.GroundRuleDouble:
                        return PitchResult.GroundRuleDouble;
                    case HitType.Triple:
                        return PitchResult.Triple;
                    case HitType.HomeRun:
                        return PitchResult.HomeRun;
                    default:
                        return PitchResult.Null;
                }
            }

            if (otherCondition == OtherCondition.NoOtherCondition)
            {
                switch (outType)
                {
                    case OutType.Flyout:
                        return PitchResult.Flyout;
                    case OutType.Groundout:
                        return PitchResult.Groundout;
                    case OutType.Popout:
                        return PitchResult.Popout;
                    default:
                        return PitchResult.Null;
                }
            }

            switch (otherCondition)
            {
                case OtherCondition.DoublePlay:
                    return PitchResult.DoublePlay;
                case OtherCondition.SacFly:
                    return PitchResult.SacrificeFly;
                case OtherCondition.DoublePlayOnFlyout:
                    return PitchResult.DoublePlayOnFlyout;
                default:
                    return PitchResult.Null;
            }
        }

        private static GettingIntoStrikeZoneTypeOfResult GettingIntoStrikeZoneDefinition(int strikeZoneProbability, int hitByPitchProbability, int numberOfPitches, int pitcherCoefficient, GameSituation situation)
        {
            var gettingIntoStrikeZoneRandomValue = _gettingIntoStrikeZoneRandomGenerator.Next(1, 3000);

            if (gettingIntoStrikeZoneRandomValue < strikeZoneProbability - (pitcherCoefficient - numberOfPitches) * 3 + (situation.Strikes - situation.Balls) * 15)
                return GettingIntoStrikeZoneTypeOfResult.BallIsOutOfTheStrikeZone;

            return gettingIntoStrikeZoneRandomValue < hitByPitchProbability ? GettingIntoStrikeZoneTypeOfResult.BallInTheStrikeZone : GettingIntoStrikeZoneTypeOfResult.HitByPitch;
        }

        private static SwingResultType SwingDefinition(GettingIntoStrikeZoneTypeOfResult ballInStrikeZone, int swingProbabilityInStrikeZone, int swingProbabilityOutsideStrikeZone, GameSituation situation)
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

            if (swingResult == SwingResultType.Swing)
            {
                if (hittingRandomValue > hittingProbability + pitcherCoefficient - batterNumberComponent * 3 - numberOfPitches / 3 - situation.Balls * 25 + situation.Strikes * 20 - handsCoefficient)
                    return HittingResultType.Hit;

                return HittingResultType.Miss;
            }

            return HittingResultType.NoResult;
        }

        private static HitType HitTypeDefinition(HittingResultType hittingResult, int singleProbability, int doubleProbability, int homeRunProbability, int tripleProbability, int иatterNumberComponent, int numberOfPitches, int stadiumCoefficient, int countOfNotEmptyBases, GameSituation situation, Batter currentBatter)
        {
            var tripleProbabilityNormalizedByBatterPosition = currentBatter.PositionForThisMatch == "P" ? tripleProbability / 5 : tripleProbability;
            var homeRunProbabilityNormalizedByBatterPosition = currentBatter.PositionForThisMatch == "P" ? homeRunProbability / 8 : homeRunProbability;
            var doubleProbabilityNormalizedByBatterPosition = currentBatter.PositionForThisMatch == "P" ? doubleProbability / 4 : doubleProbability;
            var singleProbabnilityNormalizedByBatterPosition = currentBatter.PositionForThisMatch == "P" ? (int)(singleProbability * 1.1) : singleProbability;
            var foulProbabilityNormalizedByBatterPosition = 2000 - tripleProbabilityNormalizedByBatterPosition - homeRunProbabilityNormalizedByBatterPosition - doubleProbabilityNormalizedByBatterPosition - singleProbabnilityNormalizedByBatterPosition;

            var hitTypeRandomValue = _hitTypeRandomGenerator.Next(1, 2000);

            if (hittingResult != HittingResultType.Hit) return HitType.NoResult;

            if (hitTypeRandomValue <= foulProbabilityNormalizedByBatterPosition - иatterNumberComponent * 7 + countOfNotEmptyBases * 26 + situation.Balls * 20 + situation.Strikes * 25)
                return HitType.Foul;

            if (hitTypeRandomValue <= foulProbabilityNormalizedByBatterPosition + singleProbabnilityNormalizedByBatterPosition - иatterNumberComponent * 5 + countOfNotEmptyBases * 15)
                return HitType.Single;

            if (hitTypeRandomValue < foulProbabilityNormalizedByBatterPosition + singleProbabnilityNormalizedByBatterPosition + doubleProbabilityNormalizedByBatterPosition - иatterNumberComponent * 3 + stadiumCoefficient / 3 + countOfNotEmptyBases * 8)
                return HitType.Double;

            if (hitTypeRandomValue == foulProbabilityNormalizedByBatterPosition + singleProbabnilityNormalizedByBatterPosition + doubleProbabilityNormalizedByBatterPosition - иatterNumberComponent * 3 + stadiumCoefficient / 3 + countOfNotEmptyBases * 8)
                return HitType.GroundRuleDouble;

            if (hitTypeRandomValue <= foulProbabilityNormalizedByBatterPosition + singleProbabnilityNormalizedByBatterPosition + doubleProbabilityNormalizedByBatterPosition + homeRunProbabilityNormalizedByBatterPosition - иatterNumberComponent - numberOfPitches / 4 - stadiumCoefficient / 9 + countOfNotEmptyBases * 7)
                return HitType.HomeRun;

            return HitType.Triple;
        }

        private static OutType OutTypeDefinition(HitType typeOfHit, GameSituation situation, int popoutOnFoulProbability, int flyoutOnHomeRunProbability, int groundoutProbability, int flyoutProbability)
        {
            var outTypeRandomValue = _outTypeRandomGenerator.Next(1, 1000);

            if (typeOfHit == HitType.NoResult) return OutType.NoResult;

            if (typeOfHit == HitType.Foul)
            {
                if (outTypeRandomValue < popoutOnFoulProbability - (situation.InningNumber - 1) * 5)
                    return OutType.Popout;

                if (outTypeRandomValue < popoutOnFoulProbability - (situation.InningNumber - 1) * 5 + (flyoutProbability - groundoutProbability) / 6)
                    return OutType.Flyout;

                return OutType.NoResult;
            }

            if (typeOfHit == HitType.HomeRun)
                return outTypeRandomValue > flyoutOnHomeRunProbability ? OutType.Flyout : OutType.NoResult;

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



        private static BuntResult BuntResultDefinition(GameSituation situation, int successfulBuntAttemptProbabilty, int strikeZoneProbability, int hitByPitchProbability, int batterNumberComponent)
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
        public static Pitch CreateBunt(GameSituation situation, Team awayTeam, Team homeTeam)
        {
            var offense = situation.Offense;
            var defense = situation.Offense == awayTeam ? homeTeam : awayTeam;

            var batterNumberComponent = 5 - Math.Abs(offense == awayTeam ? situation.NumberOfBatterFromAwayTeam - 3 : situation.NumberOfBatterFromHomeTeam - 3);
            var countOfNotEmptyBases = Convert.ToInt32(situation.RunnerOnFirst.IsBaseNotEmpty) + Convert.ToInt32(situation.RunnerOnSecond.IsBaseNotEmpty) * 2 + Convert.ToInt32(situation.RunnerOnThird.IsBaseNotEmpty) * 3;

            _newBuntResult = BuntResultDefinition(situation, offense.SuccessfulBuntAttemptProbabilty, defense.StrikeZoneProbabilty, defense.HitByPitchProbability, batterNumberComponent);
            _newBuntOtherConditions = OtherCondition_Definition(_newBuntResult, situation, defense.DoublePlayProbabilty, countOfNotEmptyBases);
            NewPitchResult = PitchResultDefinition(_newBuntResult, _newBuntOtherConditions);
            return new Pitch(NewPitchResult);
        }

        private static OtherCondition OtherCondition_Definition(BuntResult newBuntResult, GameSituation situation, int doublePlayProbability, int countOfNotEmptyBases)
        {
            var otherConditionRandomValue = _otherConditionRandomGenerator.Next(1, 100);

            if (newBuntResult == BuntResult.SuccessfulBunt && situation.RunnerOnFirst.IsBaseNotEmpty && situation.Outs <= 1 && otherConditionRandomValue <= doublePlayProbability + countOfNotEmptyBases)
                return OtherCondition.DoublePlay;

            return OtherCondition.NoOtherCondition;
        }

        private static PitchResult PitchResultDefinition(BuntResult newBuntResult, OtherCondition otherCondition)
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

        static PitchGenerator()
        {
            var initializeRandomGenerator = new Random(DateTime.Now.Second);
            _gettingIntoStrikeZoneRandomGenerator = new Random(2 + initializeRandomGenerator.Next(1, 1000));
            _swingRandomGenerator = new Random(3 + initializeRandomGenerator.Next(1, 1000));
            _hittingRandomGenerator = new Random(5 + initializeRandomGenerator.Next(1, 1000));
            _hitTypeRandomGenerator = new Random(7 + initializeRandomGenerator.Next(1, 1000));
            _outTypeRandomGenerator = new Random(11 + initializeRandomGenerator.Next(1, 1000));
            _otherConditionRandomGenerator = new Random(13 + initializeRandomGenerator.Next(1, 1000));
            _buntResultRandomGenerator = new Random(17 + initializeRandomGenerator.Next(1, 1000));
            _stealingResultRandomGenerator = new Random(19 + initializeRandomGenerator.Next(1, 1000));
        }

        private static int GetPitcherCoefficientForThisPitcher(Team defense)
        {
            if (defense.CurrentPitcher.IsPinchHitter)
                return 0;

            if (defense.PitchersPlayedInMatch.Count > 1)
                return 28 - defense.PitchersPlayedInMatch.Count;

            return 76 - defense.CurrentPitcher.NumberInRotation * 6;
        }

        public static Pitch CreateBaseStealing(GameSituation situation, StealingType stealingType)
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

            NewStealingAttemptResult = StealingAttemptResultDefinition(offense.SuccessfulStelingBaseAttemptProbabilty, runnerPositionInDefense, stealingType);
            NewPitchResult = PitchResult_Definition(NewStealingAttemptResult);
            return new Pitch(NewPitchResult);
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

        private static StealingResult StealingAttemptResultDefinition(int successfulStealingProbability, string runnerPositionInDefense, StealingType stealingType)
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

        public static Pitch CreateNormalPitch(GameSituation situation, Match match)
        {
            var offense = situation.Offense;
            var defense = situation.Offense == match.AwayTeam ? match.HomeTeam : match.AwayTeam;

            var batterNumberComponent = 5 - Math.Abs(offense == match.AwayTeam ? situation.NumberOfBatterFromAwayTeam - 3 : situation.NumberOfBatterFromHomeTeam - 3);
            var currentBatter = situation.Offense == match.AwayTeam ? match.AwayTeam.BattingLineup[situation.NumberOfBatterFromAwayTeam - 1] : match.HomeTeam.BattingLineup[situation.NumberOfBatterFromHomeTeam - 1];

            var numberOfPitches = match.GameSituations.Count(gameSituation => gameSituation.PitcherID == defense.CurrentPitcher.Id);
            var stadiumCoefficient = match.Stadium.StadiumDistanceToCenterfield - 400;
            var countOfNotEmptyBases = Convert.ToInt32(situation.RunnerOnFirst.IsBaseNotEmpty) + Convert.ToInt32(situation.RunnerOnSecond.IsBaseNotEmpty) * 2 + Convert.ToInt32(situation.RunnerOnThird.IsBaseNotEmpty) * 3;
            var pitcherCoefficient = GetPitcherCoefficientForThisPitcher(defense);
            var handsCoefficient = currentBatter.BattingHand == defense.CurrentPitcher.PitchingHand || currentBatter.BattingHand == "Switch" ? 0 : 20;

            if (defense.CurrentPitcher.RemainingStamina < 25)
                numberOfPitches = (int)(numberOfPitches * (1 + Math.Abs(defense.CurrentPitcher.RemainingStamina - 25) / 5 * 0.2));

            if (numberOfPitches > pitcherCoefficient)
            {
                if (defense.PitchersPlayedInMatch.Count > 1)
                    numberOfPitches += (defense.PitchersPlayedInMatch.Count / 2 + 1) * (numberOfPitches - pitcherCoefficient);
                else numberOfPitches += numberOfPitches - pitcherCoefficient;
            }

            _newPitchGettingIntoStrikeZoneResult = GettingIntoStrikeZoneDefinition(defense.StrikeZoneProbabilty, defense.HitByPitchProbability, numberOfPitches, pitcherCoefficient, situation);
            _newPitchSwingResult = SwingDefinition(_newPitchGettingIntoStrikeZoneResult, offense.SwingInStrikeZoneProbability, offense.SwingOutsideStrikeZoneProbability, situation);
            _newPitchHitting = HittingDefinition(_newPitchSwingResult, offense.HittingProbability, batterNumberComponent, pitcherCoefficient, numberOfPitches, situation, handsCoefficient);
            _newPitchHitType = HitTypeDefinition(_newPitchHitting, offense.SingleProbability, offense.DoubleProbability, offense.HomeRunProbabilty, offense.TripleProbability, batterNumberComponent, numberOfPitches, stadiumCoefficient, countOfNotEmptyBases, situation, currentBatter);
            _newPitchOutType = OutTypeDefinition(_newPitchHitType, situation, defense.PopoutOnFoulProbability, defense.FlyoutOnHomeRunProbability, defense.GroundoutProbability, defense.FlyoutProbability);
            _newPitchOtherCondition = OtherConditionDefinition(_newPitchOutType, situation, defense.SacrificeFlyProbability, defense.DoublePlayProbabilty, countOfNotEmptyBases);
            NewPitchResult = PitchResultDefinition(_newPitchGettingIntoStrikeZoneResult, _newPitchSwingResult, _newPitchHitting, _newPitchHitType, _newPitchOutType, _newPitchOtherCondition);
            return new Pitch(NewPitchResult);
        }

        /// <summary>
        /// Pitch generator for base stealing
        /// </summary>
        public static Pitch CreatePitchBeforeBaseStealing(GameSituation situation, Match match)
        {
            var offense = situation.Offense;
            var defense = situation.Offense == match.AwayTeam ? match.HomeTeam : match.AwayTeam;

            var numberOfPitches = match.GameSituations.Count(gameSituation => gameSituation.Offense.TeamAbbreviation == situation.Offense.TeamAbbreviation && situation.Id > 0);
            var pitcherCoefficient = GetPitcherCoefficientForThisPitcher(defense);

            if (numberOfPitches > pitcherCoefficient) numberOfPitches += numberOfPitches - pitcherCoefficient;

            _newPitchGettingIntoStrikeZoneResult = GettingIntoStrikeZoneDefinition(defense.StrikeZoneProbabilty, defense.HitByPitchProbability, numberOfPitches, pitcherCoefficient, situation);
            _newPitchSwingResult = SwingDefinition(_newPitchGettingIntoStrikeZoneResult, offense.SwingInStrikeZoneProbability, offense.SwingOutsideStrikeZoneProbability, situation);
            NewPitchResult = PitchResultDefinition(_newPitchGettingIntoStrikeZoneResult, _newPitchSwingResult);
            return new Pitch(NewPitchResult);
        }
    }
}