using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class Pitch
    {
        private readonly static Random _gettingIntoStrikeZoneRandomGenerator;
        private readonly static Random _swingRandomGenerator;
        private readonly static Random _hittingRandomGenerator;
        private readonly static Random _hitTypeRandomGenerator;
        private readonly static Random _outTypeRandomGenerator;
        private readonly static Random _otherConditionRandomGenerator;
        private readonly static Random _buntResultRandomGenerator;
        private readonly static Random _stealingResultRandomGenerator;

        private enum GettingIntoStrikeZoneTypeOfResult { BallInTheStrikeZone, BallIsOutOfTheStrikeZone, HitByPitch }
        private GettingIntoStrikeZoneTypeOfResult _newPitchGettingIntoStrikeZoneResult;

        private enum SwingResultType { Swing, NoSwing, NoResult }
        private SwingResultType _newPitchSwingResult;

        private enum HittingResultType { Hit, Miss, NoResult }
        private HittingResultType _newPitchHitting;

        private enum HitType { Foul, Single, Double, Triple, HomeRun, NoResult, GroundRuleDouble }
        private HitType _newPitchHitType;

        private enum OutType { Flyout, Groundout, Popout, NoResult, NoOut }
        private OutType _newPitchOutType;

        private enum OtherCondition { SacFly, DoublePlay, NoOtherCondition, DoublePlayOnFlyout };
        private OtherCondition _newPitchOtherCondition;
        private OtherCondition _newBuntOtherConditions;

        public enum BuntResult { SuccessfulBunt, FoulOnBunt, SingleOnBunt, HitByPitch, Ball };
        private BuntResult _newBuntesult;

        public enum PitchResult
        {
            HitByPitch, Ball, Strike, Null, Foul, Single, Double, Triple, HomeRun, Flyout, Groundout,
            Popout, DoublePlay, SacrificeFly, SacrificeBunt, SecondBaseStolen, ThirdBaseStolen,
            CaughtStealingOnSecond, CaughtStealingOnThird, GroundRuleDouble, DoublePlayOnFlyout
        }
        public PitchResult NewPitchResult;

        public enum StealingType { OnlySecondBase, OnlyThirdBase, ThirdBaseBeforeSecond, SecondBaseAfterThird }

        public enum StealingResult { SecondBaseStolen, ThirdBaseStolen, NoResult, CaughtStealingOnSecond, CaughtStealingOnThird }
        public StealingResult NewStealingAttemptResult;

        private PitchResult PitchResultDefinition(GettingIntoStrikeZoneTypeOfResult gettingIntoStrikeZoneResult,
                                                   SwingResultType swingResult,
                                                   HittingResultType hittingResult,
                                                   HitType hitTypeResult = HitType.NoResult,
                                                   OutType outType = OutType.NoResult,
                                                   OtherCondition otherCondition = OtherCondition.NoOtherCondition)
        {
            if (gettingIntoStrikeZoneResult == GettingIntoStrikeZoneTypeOfResult.HitByPitch)
            {
                return PitchResult.HitByPitch;
            }

            if (gettingIntoStrikeZoneResult == GettingIntoStrikeZoneTypeOfResult.BallIsOutOfTheStrikeZone &&
                     swingResult == SwingResultType.NoSwing)
            {
                return PitchResult.Ball;
            }

            if ((gettingIntoStrikeZoneResult == GettingIntoStrikeZoneTypeOfResult.BallInTheStrikeZone &&
                      swingResult == SwingResultType.NoSwing) ||
                     (swingResult == SwingResultType.Swing &&
                      hittingResult == HittingResultType.Miss))
            {
                return PitchResult.Strike;
            }

            if (outType == OutType.NoResult)
            {
                switch (hitTypeResult)
                {
                    case HitType.Foul:
                        {
                            return PitchResult.Foul;
                        }
                    case HitType.Single:
                        {
                            return PitchResult.Single;
                        }
                    case HitType.Double:
                        {
                            return PitchResult.Double;
                        }
                    case HitType.GroundRuleDouble:
                        {
                            return PitchResult.GroundRuleDouble;
                        }
                    case HitType.Triple:
                        {
                            return PitchResult.Triple;
                        }
                    case HitType.HomeRun:
                        {
                            return PitchResult.HomeRun;
                        }
                    default:
                        {
                            return PitchResult.Null;
                        }
                }
            }

            if (otherCondition == OtherCondition.NoOtherCondition)
            {
                switch (outType)
                {
                    case OutType.Flyout:
                        {
                            return PitchResult.Flyout;
                        }
                    case OutType.Groundout:
                        {
                            return PitchResult.Groundout;
                        }
                    case OutType.Popout:
                        {
                            return PitchResult.Popout;
                        }
                    default:
                        {
                            return PitchResult.Null;
                        }
                }
            }

            switch (otherCondition)
            {
                case OtherCondition.DoublePlay:
                    {
                        return PitchResult.DoublePlay;
                    }
                case OtherCondition.SacFly:
                    {
                        return PitchResult.SacrificeFly;
                    }
                case OtherCondition.DoublePlayOnFlyout:
                    {
                        return PitchResult.DoublePlayOnFlyout;
                    }
                default:
                    {
                        return PitchResult.Null;
                    }
            }
        }

        private GettingIntoStrikeZoneTypeOfResult GettingIntoStrikeZoneDefinition(int strikeZoneProbability, int hitByPitchProbability, int numberOfPitches, int pitcherCoefficient, GameSituation situation)
        {
            int gettingIntoStrikeZoneRandomValue = _gettingIntoStrikeZoneRandomGenerator.Next(1, 3000);

            if (gettingIntoStrikeZoneRandomValue < strikeZoneProbability - (pitcherCoefficient - numberOfPitches) * 3 + (situation.Strikes - situation.Balls) * 15)
            {
                return GettingIntoStrikeZoneTypeOfResult.BallIsOutOfTheStrikeZone;
            }

            if (gettingIntoStrikeZoneRandomValue < hitByPitchProbability)
            {
                return GettingIntoStrikeZoneTypeOfResult.BallInTheStrikeZone;
            }
            return GettingIntoStrikeZoneTypeOfResult.HitByPitch;
        }

        private SwingResultType SwingDefinition(GettingIntoStrikeZoneTypeOfResult ballInStrikeZone, int swingProbabilityInStrikeZone, int swingProbabilityOutsideStrikeZone, GameSituation situation)
        {
            int swingRandomValue = _swingRandomGenerator.Next(1, 100);

            if (ballInStrikeZone == GettingIntoStrikeZoneTypeOfResult.HitByPitch)
            {
                return SwingResultType.NoResult;
            }

            if (ballInStrikeZone == GettingIntoStrikeZoneTypeOfResult.BallInTheStrikeZone)
            {
                if (swingRandomValue > swingProbabilityInStrikeZone + situation.Balls - situation.Strikes)
                {
                    return SwingResultType.Swing;
                }
                return SwingResultType.NoSwing;
            }

            if (swingRandomValue > swingProbabilityOutsideStrikeZone + (situation.Balls - situation.Strikes) / 2)
            {
                return SwingResultType.Swing;
            }
            return SwingResultType.NoSwing;
        }

        private HittingResultType HittingDefinition(SwingResultType swingResult, int hittingProbability, int batterNumberComponent, int pitcherCoefficient, int numberOfPitches, GameSituation situation, int handsCoefficient)
        {
            int hittingRandomValue = _hittingRandomGenerator.Next(1, 2000);

            if (swingResult == SwingResultType.Swing)
            {
                if (hittingRandomValue > hittingProbability + pitcherCoefficient - batterNumberComponent * 3 - numberOfPitches / 3 - situation.Balls * 25 + situation.Strikes * 20 - handsCoefficient)
                {
                    return HittingResultType.Hit;
                }

                return HittingResultType.Miss;
            }

            return HittingResultType.NoResult;
        }

        private HitType HitTypeDefinition(HittingResultType hittingResult, int singleProbability, int doubleProbability, int homeRunProbability, int tripleProbability, int иatterNumberComponent, int numberOfPitches, int StadiumCoefficient, int countOfNotEmptyBases, GameSituation situation, Batter currentBatter)
        {
            var tripleProbabilityNormalizedByBatterPosition = currentBatter.PositionForThisMatch == "P" ? tripleProbability / 5 : tripleProbability;
            var homeRunProbabilityNormalizedByBatterPosition = currentBatter.PositionForThisMatch == "P" ? homeRunProbability / 8 : homeRunProbability;
            var doubleProbabilityNormalizedByBatterPosition = currentBatter.PositionForThisMatch == "P" ? doubleProbability / 4 : doubleProbability;
            var singleProbabnilityNormalizedByBatterPosition = currentBatter.PositionForThisMatch == "P" ? (int)(singleProbability * 1.1) : singleProbability;
            var foulProbabilityNormalizedByBatterPosition = 2000 - tripleProbabilityNormalizedByBatterPosition - homeRunProbabilityNormalizedByBatterPosition - doubleProbabilityNormalizedByBatterPosition - singleProbabnilityNormalizedByBatterPosition;

            int hitTypeRandomValue = _hitTypeRandomGenerator.Next(1, 2000);

            if (hittingResult == HittingResultType.Hit)
            {
                if (hitTypeRandomValue <= foulProbabilityNormalizedByBatterPosition - иatterNumberComponent * 7 + countOfNotEmptyBases * 26 + situation.Balls * 20 + situation.Strikes * 25)
                {
                    return HitType.Foul;
                }

                if (hitTypeRandomValue <= foulProbabilityNormalizedByBatterPosition + singleProbabnilityNormalizedByBatterPosition - иatterNumberComponent * 5 + countOfNotEmptyBases * 15)
                {
                    return HitType.Single;
                }

                if (hitTypeRandomValue < foulProbabilityNormalizedByBatterPosition + singleProbabnilityNormalizedByBatterPosition + doubleProbabilityNormalizedByBatterPosition - иatterNumberComponent * 3 + StadiumCoefficient / 3 + countOfNotEmptyBases * 8)
                {
                    return HitType.Double;
                }

                if (hitTypeRandomValue == foulProbabilityNormalizedByBatterPosition + singleProbabnilityNormalizedByBatterPosition + doubleProbabilityNormalizedByBatterPosition - иatterNumberComponent * 3 + StadiumCoefficient / 3 + countOfNotEmptyBases * 8)
                {
                    return HitType.GroundRuleDouble;
                }

                if (hitTypeRandomValue <= foulProbabilityNormalizedByBatterPosition + singleProbabnilityNormalizedByBatterPosition + doubleProbabilityNormalizedByBatterPosition + homeRunProbabilityNormalizedByBatterPosition - иatterNumberComponent - numberOfPitches / 4 - StadiumCoefficient / 9 + countOfNotEmptyBases * 7)
                {
                    return HitType.HomeRun;
                }

                return HitType.Triple;
            }
            return HitType.NoResult;
        }

        private OutType OutTypeDefinition(HitType typeOfHit, GameSituation situation, int popoutOnFoulProbability, int flyoutOnHomeRunProbability, int groundoutProbability, int flyoutProbability)
        {
            int outTypeRandomValue = _outTypeRandomGenerator.Next(1, 1000);

            if (typeOfHit != HitType.NoResult)
            {
                if (typeOfHit == HitType.Foul)
                {
                    if (outTypeRandomValue < popoutOnFoulProbability - (situation.InningNumber - 1) * 5)
                    {
                        return OutType.Popout;
                    }

                    if (outTypeRandomValue < popoutOnFoulProbability - (situation.InningNumber - 1) * 5 + (flyoutProbability - groundoutProbability) / 6)
                    {
                        return OutType.Flyout;
                    }

                    return OutType.NoResult;
                }

                if (typeOfHit == HitType.HomeRun)
                {
                    if (outTypeRandomValue > flyoutOnHomeRunProbability)
                    {
                        return OutType.Flyout;
                    }
                    return OutType.NoResult;
                }

                if (outTypeRandomValue <= groundoutProbability && typeOfHit != HitType.GroundRuleDouble)
                {
                    return OutType.Groundout;
                }

                if (outTypeRandomValue <= flyoutProbability && typeOfHit != HitType.GroundRuleDouble)
                {
                    return OutType.Flyout;
                }
                return OutType.NoResult;
            }
            return OutType.NoResult;
        }

        private OtherCondition OtherConditionDefinition(OutType outType, GameSituation situation, int sacrificeFlyProbability, int doublePlayProbability, int countOfNotEmptyBases)
        {
            int otherConditionRandomValue = _otherConditionRandomGenerator.Next(1, 100);

            if (outType == OutType.Flyout && (situation.RunnerOnSecond.IsBaseNotEmpty || situation.RunnerOnThird.IsBaseNotEmpty) && situation.Outs < 2 && otherConditionRandomValue <= sacrificeFlyProbability)
            {
                return OtherCondition.SacFly;
            }
            else if (outType == OutType.Flyout && situation.RunnerOnThird.IsBaseNotEmpty && situation.Outs < 2 && otherConditionRandomValue <= sacrificeFlyProbability + doublePlayProbability / 10)
            {
                return OtherCondition.DoublePlayOnFlyout;
            }
            else if (outType == OutType.Groundout && situation.RunnerOnFirst.IsBaseNotEmpty && situation.Outs < 2 && otherConditionRandomValue <= doublePlayProbability + countOfNotEmptyBases)
            {
                return OtherCondition.DoublePlay;
            }
            else
            {
                return OtherCondition.NoOtherCondition;
            }
        }

        /// <summary>
        /// Normal pitches
        /// </summary>
        public Pitch(GameSituation situation, Match match)
        {
            var offense = situation.Offense;
            var defense = situation.Offense == match.AwayTeam ? match.HomeTeam : match.AwayTeam;

            var batterNumberComponent = 5 - Math.Abs(offense == match.AwayTeam ? situation.NumberOfBatterFromHomeTeam - 3 : situation.NumberOfBatterFromAwayTeam - 3);
            var currentBatter = situation.Offense == match.AwayTeam ? match.AwayTeam.BattingLineup[situation.NumberOfBatterFromHomeTeam - 1] : match.HomeTeam.BattingLineup[situation.NumberOfBatterFromAwayTeam - 1];

            var numberOfPitches = match.GameSituations.Where(gameSituation => gameSituation.PitcherID == defense.CurrentPitcher.Id).Count();
            var stadiumCoefficient = match.Stadium.StadiumDistanceToCenterfield - 400;
            var countOfNotEmptyBases = Convert.ToInt32(situation.RunnerOnFirst.IsBaseNotEmpty) + Convert.ToInt32(situation.RunnerOnSecond.IsBaseNotEmpty) * 2 + Convert.ToInt32(situation.RunnerOnThird.IsBaseNotEmpty) * 3;
            var pitcherCoefficient = GetPitcherCoeffitientForThisPitcher(defense);
            var handsCoefficient = currentBatter.BattingHand == defense.CurrentPitcher.PitchingHand || currentBatter.BattingHand == "Switch" ? 0 : 20;

            if (defense.CurrentPitcher.RemainingStamina < 25)
            {
                numberOfPitches = (int)(numberOfPitches * (1 + Math.Abs(defense.CurrentPitcher.RemainingStamina - 25) / 5 * 0.2));
            }

            if (numberOfPitches > pitcherCoefficient)
            {
                if (defense.PitchersPlayedInMatch.Count > 1)
                {
                    numberOfPitches += (defense.PitchersPlayedInMatch.Count / 2 + 1) * (numberOfPitches - pitcherCoefficient);
                }
                else
                {
                    numberOfPitches += numberOfPitches - pitcherCoefficient;
                }
            }

            _newPitchGettingIntoStrikeZoneResult = GettingIntoStrikeZoneDefinition(defense.StrikeZoneProbabilty, defense.HitByPitchProbability, numberOfPitches, pitcherCoefficient, situation);
            _newPitchSwingResult = SwingDefinition(_newPitchGettingIntoStrikeZoneResult, offense.SwingInStrikeZoneProbability, offense.SwingOutsideStrikeZoneProbability, situation);
            _newPitchHitting = HittingDefinition(_newPitchSwingResult, offense.HittingProbability, batterNumberComponent, pitcherCoefficient, numberOfPitches, situation, handsCoefficient);
            _newPitchHitType = HitTypeDefinition(_newPitchHitting, offense.SingleProbability, offense.DoubleProbability, offense.HomeRunProbabilty, offense.TripleProbability, batterNumberComponent, numberOfPitches, stadiumCoefficient, countOfNotEmptyBases, situation, currentBatter);
            _newPitchOutType = OutTypeDefinition(_newPitchHitType, situation, defense.PopoutOnFoulProbability, defense.FlyoutOnHomeRunProbability, defense.GroundoutProbability, defense.FlyoutProbability);
            _newPitchOtherCondition = OtherConditionDefinition(_newPitchOutType, situation, defense.SacrificeFlyProbability, defense.DoublePlayProbabilty, countOfNotEmptyBases);
            NewPitchResult = PitchResultDefinition(_newPitchGettingIntoStrikeZoneResult, _newPitchSwingResult, _newPitchHitting, _newPitchHitType, _newPitchOutType, _newPitchOtherCondition);
        }

        private BuntResult BuntResultDefinition(GameSituation situation, int successfulBuntAttemptProbabilty, int strikeZoneProbability, int hitByPitchProbability, int batterNumberComponent)
        {
            int buntRandomValue = _buntResultRandomGenerator.Next(1, 1000);

            if (buntRandomValue <= 50)
            {
                return BuntResult.FoulOnBunt;
            }

            if (buntRandomValue <= (strikeZoneProbability - (situation.Strikes - situation.Balls) * 15) / 3)
            {
                return BuntResult.Ball;
            }

            if (buntRandomValue <= successfulBuntAttemptProbabilty - batterNumberComponent * 15)
            {
                return BuntResult.SuccessfulBunt;
            }

            if (buntRandomValue <= hitByPitchProbability / 3)
            {
                return BuntResult.SingleOnBunt;
            }

            return BuntResult.HitByPitch;
        }

        /// <summary>
        /// Bunt generator
        /// </summary>
        public Pitch(GameSituation situation, Team AwayTeam, Team HomeTeam)
        {
            var offense = situation.Offense;
            var defense = situation.Offense == AwayTeam ? HomeTeam : AwayTeam;

            var batterNumberComponent = 5 - Math.Abs(offense == AwayTeam ? situation.NumberOfBatterFromHomeTeam - 3 : situation.NumberOfBatterFromAwayTeam - 3);
            var countOfNotEmptyBases = Convert.ToInt32(situation.RunnerOnFirst.IsBaseNotEmpty) + Convert.ToInt32(situation.RunnerOnSecond.IsBaseNotEmpty) * 2 + Convert.ToInt32(situation.RunnerOnThird.IsBaseNotEmpty) * 3;

            _newBuntesult = BuntResultDefinition(situation, offense.SuccessfulBuntAttemptProbabilty, defense.StrikeZoneProbabilty, defense.HitByPitchProbability, batterNumberComponent);
            _newBuntOtherConditions = OtherCondition_Definition(_newBuntesult, situation, defense.DoublePlayProbabilty, countOfNotEmptyBases);
            NewPitchResult = P(_newBuntesult, _newBuntOtherConditions);
        }

        private OtherCondition OtherCondition_Definition(BuntResult newBuntResult, GameSituation situation, int doublePlayProbability, int countOfNotEmptyBases)
        {
            int otherConditionRandomValue = _otherConditionRandomGenerator.Next(1, 100);

            if (newBuntResult == BuntResult.SuccessfulBunt && situation.RunnerOnFirst.IsBaseNotEmpty && situation.Outs <= 1 && otherConditionRandomValue <= doublePlayProbability + countOfNotEmptyBases)
            {
                return OtherCondition.DoublePlay;
            }
            else
            {
                return OtherCondition.NoOtherCondition;
            }
        }

        private PitchResult P(BuntResult newBuntResult, OtherCondition otherCondition)
        {
            if (otherCondition == OtherCondition.NoOtherCondition)
            {
                switch (newBuntResult)
                {
                    case BuntResult.FoulOnBunt:
                        {
                            return PitchResult.Strike;
                        }
                    case BuntResult.SuccessfulBunt:
                        {
                            return PitchResult.SacrificeBunt;
                        }
                    case BuntResult.SingleOnBunt:
                        {
                            return PitchResult.Single;
                        }
                    case BuntResult.HitByPitch:
                        {
                            return PitchResult.HitByPitch;
                        }
                    case BuntResult.Ball:
                        {
                            return PitchResult.Ball;
                        }
                    default:
                        {
                            return PitchResult.Null;
                        }
                }
            }

            return PitchResult.DoublePlay;
        }

        static Pitch()
        {
            Random InitializeRandomGenerator = new Random(DateTime.Now.Second);
            _gettingIntoStrikeZoneRandomGenerator = new Random(2 + InitializeRandomGenerator.Next(1, 1000));
            _swingRandomGenerator = new Random(3 + InitializeRandomGenerator.Next(1, 1000));
            _hittingRandomGenerator = new Random(5 + InitializeRandomGenerator.Next(1, 1000));
            _hitTypeRandomGenerator = new Random(7 + InitializeRandomGenerator.Next(1, 1000));
            _outTypeRandomGenerator = new Random(11 + InitializeRandomGenerator.Next(1, 1000));
            _otherConditionRandomGenerator = new Random(13 + InitializeRandomGenerator.Next(1, 1000));
            _buntResultRandomGenerator = new Random(17 + InitializeRandomGenerator.Next(1, 1000));
            _stealingResultRandomGenerator = new Random(19 + InitializeRandomGenerator.Next(1, 1000));
        }

        /// <summary>
        /// Pitch generator for base stealing
        /// </summary>
        public Pitch(GameSituation situation, List<GameSituation> match, Team homeTeam, Team awayTeam)
        {
            var offense = situation.Offense;
            var defense = situation.Offense == awayTeam ? homeTeam : awayTeam;

            var batterNumberComponent = 5 - Math.Abs(offense == awayTeam ? situation.NumberOfBatterFromHomeTeam - 3 : situation.NumberOfBatterFromAwayTeam - 3);
            var numberOfPitches = match.Where(gameSituation => gameSituation.Offense.TeamAbbreviation == situation.Offense.TeamAbbreviation && situation.Id > 0).Count();
            var pitcherCoefficient = GetPitcherCoeffitientForThisPitcher(defense);

            if (numberOfPitches > pitcherCoefficient)
            {
                numberOfPitches += numberOfPitches - pitcherCoefficient;
            }

            _newPitchGettingIntoStrikeZoneResult = GettingIntoStrikeZoneDefinition(defense.StrikeZoneProbabilty, defense.HitByPitchProbability, numberOfPitches, pitcherCoefficient, situation);
            _newPitchSwingResult = SwingDefinition(_newPitchGettingIntoStrikeZoneResult, offense.SwingInStrikeZoneProbability, offense.SwingOutsideStrikeZoneProbability, situation);
            NewPitchResult = PitchResultDefinition(_newPitchGettingIntoStrikeZoneResult, _newPitchSwingResult, HittingResultType.Miss);
        }

        private int GetPitcherCoeffitientForThisPitcher(Team defense)
        {
            if (defense.CurrentPitcher.IsPinchHitter)
            {
                return 0;
            }

            if (defense.PitchersPlayedInMatch.Count > 1)
            {
                return 28 - defense.PitchersPlayedInMatch.Count;
            }

            return 76 - defense.CurrentPitcher.NumberInRotation * 6;
        }

        public Pitch(GameSituation situation, StealingType stealingType)
        {
            var Offense = situation.Offense;
            var runnerPositionInDefense = "";

            switch (stealingType)
            {
                case StealingType.OnlySecondBase:
                case StealingType.SecondBaseAfterThird:
                    {
                        runnerPositionInDefense = Offense.BattingLineup.Where(player => player.Id == situation.RunnerOnFirst.RunnerID).First().PositionForThisMatch;
                        break;
                    }
                case StealingType.OnlyThirdBase:
                case StealingType.ThirdBaseBeforeSecond:
                    {
                        runnerPositionInDefense = Offense.BattingLineup.Where(player => player.Id == situation.RunnerOnSecond.RunnerID).First().PositionForThisMatch;
                        break;
                    }
            }

            NewStealingAttemptResult = StealingAttemptResultDefinition(Offense.SuccessfulStelingBaseAttemptProbabilty, runnerPositionInDefense, stealingType);
            NewPitchResult = PitchResult_Definition(NewStealingAttemptResult);
        }

        private PitchResult PitchResult_Definition(StealingResult newStealingAttemptResult)
        {
            switch (newStealingAttemptResult)
            {
                case StealingResult.CaughtStealingOnSecond:
                    {
                        return PitchResult.CaughtStealingOnSecond;
                    }
                case StealingResult.CaughtStealingOnThird:
                    {
                        return PitchResult.CaughtStealingOnThird;
                    }
                case StealingResult.SecondBaseStolen:
                    {
                        return PitchResult.SecondBaseStolen;
                    }
                case StealingResult.ThirdBaseStolen:
                    {
                        return PitchResult.ThirdBaseStolen;
                    }
                default:
                    {
                        return PitchResult.Null;
                    }
            }
        }

        private StealingResult StealingAttemptResultDefinition(int successfulStealingProbability, string runnerPositionInDefense, StealingType stealingType)
        {
            int stealingAttemptRandomValue = _stealingResultRandomGenerator.Next(1, 100);

            int stealingProbabilityCorrectedByPosition;

            if (runnerPositionInDefense != "P")
            {
                stealingProbabilityCorrectedByPosition = successfulStealingProbability;
            }
            else
            {
                if (stealingType == StealingType.SecondBaseAfterThird)
                {
                    stealingProbabilityCorrectedByPosition = successfulStealingProbability * 2;
                }
                else
                {
                    stealingProbabilityCorrectedByPosition = successfulStealingProbability / 2;
                }
            }

            switch (stealingType)
            {
                case StealingType.OnlySecondBase:
                    {
                        if (stealingAttemptRandomValue <= stealingProbabilityCorrectedByPosition)
                        {
                            return StealingResult.SecondBaseStolen;
                        }
                        else
                        {
                            return StealingResult.CaughtStealingOnSecond;
                        }
                    }
                case StealingType.OnlyThirdBase:
                    {
                        if (stealingAttemptRandomValue <= stealingProbabilityCorrectedByPosition / 4)
                        {
                            return StealingResult.ThirdBaseStolen;
                        }
                        else
                        {
                            return StealingResult.CaughtStealingOnThird;
                        }
                    }
                case StealingType.ThirdBaseBeforeSecond:
                    {
                        if (stealingAttemptRandomValue <= stealingProbabilityCorrectedByPosition / 5)
                        {
                            return StealingResult.ThirdBaseStolen;
                        }
                        else
                        {
                            return StealingResult.CaughtStealingOnThird;
                        }
                    }
                case StealingType.SecondBaseAfterThird:
                    {
                        if (stealingAttemptRandomValue <= 100 - stealingProbabilityCorrectedByPosition / 3)
                        {
                            return StealingResult.SecondBaseStolen;
                        }
                        else
                        {
                            return StealingResult.CaughtStealingOnSecond;
                        }
                    }
                default:
                    {
                        return StealingResult.NoResult;
                    }
            }
        }
    }
}