using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class Pitch
    {
        private readonly static Random GettingIntoStrikeZone_RandomGenerator;
        private readonly static Random Swing_RandomGenerator;
        private readonly static Random Hitting_RandomGenerator;
        private readonly static Random HitType_RandomGenerator;
        private readonly static Random OutType_RandomGenerator;
        private readonly static Random OtherCondition_RandomGenerator;
        private readonly static Random BuntResult_RandomGenerator;
        private readonly static Random StealingResult_RandomGenerator;

        private enum GettingIntoStrikeZone_TypeOfResult { BallInTheStrikeZone, BallIsOutOfTheStrikeZone, HitByPitch }
        GettingIntoStrikeZone_TypeOfResult newPitch_GettingIntoStrikeZone_Result;

        private enum Swing_ResultType { Swing, NoSwing, NoResult }
        Swing_ResultType newPitch_Swing_Result;

        private enum Hitting_ResultType { Hit, Miss, NoResult }
        Hitting_ResultType newPitch_Hitting;

        private enum HitType { Foul, Single, Double, Triple, HomeRun, NoResult, GroundRuleDouble }
        HitType newPitch_HitType;

        private enum OutType { Flyout, Groundout, Popout, NoResult, NoOut }
        OutType newPitch_OutType;

        private enum OtherCondition { SacFly, DoublePlay, NoOtherCondition };
        OtherCondition newPitch_OtherCondition;

        public enum BuntResult { SuccessfulBunt, FoulOnBunt, SingleOnBunt, HitByPitch };
        BuntResult newBunt_result;

        public PitchResult pitchResult;

        public enum PitchResult { HitByPitch, Ball, Strike, Null, Foul, Single, Double, Triple, HomeRun, Flyout, Groundout, Popout, DoublePlay, SacrificeFly, SacrificeBunt, SecondBaseStolen, ThirdBaseStolen, CaughtStealingOnSecond, CaughtStealingOnThird, GroundRuleDouble }

        public enum StealingType { OnlySecondBase, OnlyThirdBase, ThirdBaseBeforeSecond, SecondBaseAfterThird }

        public enum StealingResult { SecondBaseStolen, ThirdBaseStolen, NoResult, CaughtStealingOnSecond, CaughtStealingOnThird }
        public StealingResult newStealingAttempt_result;

        private PitchResult pitchResult_Definition(GettingIntoStrikeZone_TypeOfResult gettingIntoStrikeZone_Result,
                                                   Swing_ResultType swing_Result,
                                                   Hitting_ResultType hitting_Result,
                                                   HitType hitType_Result,
                                                   OutType outType,
                                                   OtherCondition otherCondition)
        {
            if (gettingIntoStrikeZone_Result == GettingIntoStrikeZone_TypeOfResult.HitByPitch)
            {
                return PitchResult.HitByPitch;
            }
            else if (gettingIntoStrikeZone_Result == GettingIntoStrikeZone_TypeOfResult.BallIsOutOfTheStrikeZone &&
                     swing_Result == Swing_ResultType.NoSwing)
            {
                return PitchResult.Ball;
            }
            else if ((gettingIntoStrikeZone_Result == GettingIntoStrikeZone_TypeOfResult.BallInTheStrikeZone &&
                      swing_Result == Swing_ResultType.NoSwing) ||
                     (swing_Result == Swing_ResultType.Swing &&
                      hitting_Result == Hitting_ResultType.Miss))
            {
                return PitchResult.Strike;
            }
            else if (outType == OutType.NoResult)
            {
                switch (hitType_Result)
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
            else if (otherCondition == OtherCondition.NoOtherCondition)
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
            else
            {
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
                    default:
                        {
                            return PitchResult.Null;
                        }
                }
            }
        }

        private GettingIntoStrikeZone_TypeOfResult GettingIntoStrikeZone_Definition(int strikeZone_probability, int numberOfPitches, int pitcherCoefficient)
        {
            int GettingIntoStrikeZone_RandomValue = GettingIntoStrikeZone_RandomGenerator.Next(1, 1000);

            if (GettingIntoStrikeZone_RandomValue < strikeZone_probability - pitcherCoefficient + numberOfPitches * 1)
            {
                return GettingIntoStrikeZone_TypeOfResult.BallIsOutOfTheStrikeZone;
            }
            else if (GettingIntoStrikeZone_RandomValue <= 990)
            {
                return GettingIntoStrikeZone_TypeOfResult.BallInTheStrikeZone;
            }
            else
            {
                return GettingIntoStrikeZone_TypeOfResult.HitByPitch;
            }
        }

        private Swing_ResultType Swing_Definition(GettingIntoStrikeZone_TypeOfResult ballInStrikeZone, int swingProbabilityInStrikeZone, int swingProbabilityOutsideStrikeZone, GameSituation situation)
        {
            int Swing_RandomValue = Swing_RandomGenerator.Next(1, 100);
            if (ballInStrikeZone == GettingIntoStrikeZone_TypeOfResult.HitByPitch)
            {
                return Swing_ResultType.NoResult;
            }
            else if (ballInStrikeZone == GettingIntoStrikeZone_TypeOfResult.BallInTheStrikeZone)
            {
                if (Swing_RandomValue > swingProbabilityInStrikeZone + situation.balls - situation.strikes)
                {
                    return Swing_ResultType.Swing;
                }
                else
                {
                    return Swing_ResultType.NoSwing;
                }
            }
            else
            {
                if (Swing_RandomValue > swingProbabilityOutsideStrikeZone + (situation.balls - situation.strikes) / 2)
                {
                    return Swing_ResultType.Swing;
                }
                else
                {
                    return Swing_ResultType.NoSwing;
                }
            }
        }

        private Hitting_ResultType Hitting_Definition(Swing_ResultType swingResult, int Hitting_probability, int BatterNumberComponent, int pitcherCoefficient, int numberOfPitches, GameSituation situation)
        {
            int Hitting_RandomValue = Hitting_RandomGenerator.Next(1, 2000);
            if (swingResult == Swing_ResultType.Swing)
            {
                if (Hitting_RandomValue > Hitting_probability + pitcherCoefficient - BatterNumberComponent * 3 - numberOfPitches / 3 - situation.balls * 20 + situation.strikes * 25)
                {
                    return Hitting_ResultType.Hit;
                }
                else
                {
                    return Hitting_ResultType.Miss;
                }
            }
            else
            {
                return Hitting_ResultType.NoResult;
            }
        }

        private HitType HitType_Definition(Hitting_ResultType hitting_Result, int Foul_Probability, int single_probability, int double_probability, int homeRun_Probability, int BatterNumberComponent, int numberOfPitches, int StadiumCoefficient, int countOfNotEmptyBases, GameSituation situation, Batter currentBatter)
        {
            int TripleProbabilityNormalizedByBatterPosition, HRProbabilityNormalizedByBatterPosition, DoubleProbabilityNormalizedByBatterPosition, SingleProbabnilityNormalizedByBatterPosition, FoulProbabilityNormalizedByBatterPosition;
            if (currentBatter.PositionForThisMatch == "P")
            {
                TripleProbabilityNormalizedByBatterPosition = (2000 - homeRun_Probability) / 5;
                HRProbabilityNormalizedByBatterPosition = (homeRun_Probability - double_probability) / 8;
                DoubleProbabilityNormalizedByBatterPosition = (double_probability - single_probability) / 4;
                SingleProbabnilityNormalizedByBatterPosition = (int)((single_probability - Foul_Probability) * 1.1);
            }
            else
            {
                TripleProbabilityNormalizedByBatterPosition = 2000 - homeRun_Probability;
                HRProbabilityNormalizedByBatterPosition = homeRun_Probability - double_probability;
                DoubleProbabilityNormalizedByBatterPosition = double_probability - single_probability;
                SingleProbabnilityNormalizedByBatterPosition = single_probability - Foul_Probability;
            }
            FoulProbabilityNormalizedByBatterPosition = 2000 - TripleProbabilityNormalizedByBatterPosition - HRProbabilityNormalizedByBatterPosition - DoubleProbabilityNormalizedByBatterPosition - SingleProbabnilityNormalizedByBatterPosition;

            int HitType_RandomValue = HitType_RandomGenerator.Next(1, 2000);
            if (hitting_Result == Hitting_ResultType.Hit)
            {
                if (HitType_RandomValue <= FoulProbabilityNormalizedByBatterPosition - BatterNumberComponent * 7 + countOfNotEmptyBases * 26 + situation.balls * 20 + situation.strikes * 25)
                {
                    return HitType.Foul;
                }
                else if (HitType_RandomValue <= FoulProbabilityNormalizedByBatterPosition + SingleProbabnilityNormalizedByBatterPosition - BatterNumberComponent * 5 + countOfNotEmptyBases * 15)
                {
                    return HitType.Single;
                }
                else if (HitType_RandomValue < FoulProbabilityNormalizedByBatterPosition + SingleProbabnilityNormalizedByBatterPosition + DoubleProbabilityNormalizedByBatterPosition - BatterNumberComponent * 3 + StadiumCoefficient / 3 + countOfNotEmptyBases * 8)
                {
                    return HitType.Double;
                }
                else if (HitType_RandomValue == FoulProbabilityNormalizedByBatterPosition + SingleProbabnilityNormalizedByBatterPosition + DoubleProbabilityNormalizedByBatterPosition - BatterNumberComponent * 3 + StadiumCoefficient / 3 + countOfNotEmptyBases * 8)
                {
                    return HitType.GroundRuleDouble;
                }
                else if (HitType_RandomValue <= FoulProbabilityNormalizedByBatterPosition + SingleProbabnilityNormalizedByBatterPosition + DoubleProbabilityNormalizedByBatterPosition + HRProbabilityNormalizedByBatterPosition - BatterNumberComponent - numberOfPitches / 3 - StadiumCoefficient / 9 + countOfNotEmptyBases * 5)
                {
                    return HitType.HomeRun;
                }
                else
                {
                    return HitType.Triple;
                }
            }
            else
            {
                return HitType.NoResult;
            }
        }

        private OutType OutType_Definition(HitType TypeOfHit, int PopoutOnFoul_probability, int FlyoutOnHomeRun_probability, int Groundout_probability, int Flyout_probability)
        {
            int OutType_RandomValue = OutType_RandomGenerator.Next(1, 1000);
            if (TypeOfHit != HitType.NoResult)
            {
                if (TypeOfHit == HitType.Foul)
                {
                    if (OutType_RandomValue < PopoutOnFoul_probability)
                    {
                        return OutType.Popout;
                    }
                    else if (OutType_RandomValue < PopoutOnFoul_probability + (Flyout_probability - Groundout_probability) / 3)
                    {
                        return OutType.Flyout;
                    }
                    else
                    {
                        return OutType.NoResult;
                    }
                }
                else if (TypeOfHit == HitType.HomeRun)
                {
                    if (OutType_RandomValue > FlyoutOnHomeRun_probability)
                    {
                        return OutType.Flyout;
                    }
                    else
                    {
                        return OutType.NoResult;
                    }
                }
                else if (OutType_RandomValue <= Groundout_probability && TypeOfHit != HitType.GroundRuleDouble)
                {
                    return OutType.Groundout;
                }
                else if (OutType_RandomValue <= Flyout_probability && TypeOfHit != HitType.GroundRuleDouble)
                {
                    return OutType.Flyout;
                }
                else
                {
                    return OutType.NoResult;
                }
            }
            else
            {
                return OutType.NoResult;
            }
        }

        private OtherCondition OtherCondition_Definition(OutType outType, GameSituation situation, int SacrificeFly_Probability, int DoublePlay_Probability, int CountOfNotEmptyBases)
        {
            int OtherCondition_RandomValue = OtherCondition_RandomGenerator.Next(1, 100);
            if (outType == OutType.Flyout && (situation.RunnerOnSecond.IsBaseNotEmpty || situation.RunnerOnThird.IsBaseNotEmpty) && situation.outs < 2 && OtherCondition_RandomValue <= SacrificeFly_Probability)
            {
                return OtherCondition.SacFly;
            }
            else if (outType == OutType.Groundout && situation.RunnerOnFirst.IsBaseNotEmpty && situation.outs <= 1 && OtherCondition_RandomValue <= DoublePlay_Probability + CountOfNotEmptyBases)
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
        public Pitch(GameSituation situation, List<GameSituation> match, Team HomeTeam, Team AwayTeam, Stadium stadium)
        {
            Team Offense = situation.offense;
            Team Defense = situation.offense == AwayTeam ? HomeTeam : AwayTeam;

            int BatterNumberComponent = 5 - Math.Abs(Offense == AwayTeam ? situation.BatterNumber_AwayTeam - 3 : situation.BatterNumber_HomeTeam - 3);
            List<GameSituation> ListOfHitsInCurrentInning = match.Where(gameSituation => gameSituation.inningNumber == situation.inningNumber && gameSituation.offense == situation.offense).ToList();

            Batter CurrentBatterPosition = situation.offense == AwayTeam ? AwayTeam.BattingLineup[situation.BatterNumber_AwayTeam - 1] : HomeTeam.BattingLineup[situation.BatterNumber_HomeTeam - 1];

            int numberOfPitches = match.Where(gameSituation => gameSituation.PitcherID == Defense.CurrentPitcher.id).Count();
            int StadiumCoefficient = stadium.stadiumDistanceToCenterfield - 400;
            int CountOfNotEmptyBases = Convert.ToInt32(situation.RunnerOnFirst.IsBaseNotEmpty) + Convert.ToInt32(situation.RunnerOnSecond.IsBaseNotEmpty);
            int PitcherCoefficient = GetPitcherCoeffitientForThisPitcher(Defense);

            if (numberOfPitches > PitcherCoefficient)
            {
                numberOfPitches += numberOfPitches - PitcherCoefficient;
            }
            newPitch_GettingIntoStrikeZone_Result = GettingIntoStrikeZone_Definition(Defense.StrikeZoneProbabilty, numberOfPitches, PitcherCoefficient);
            newPitch_Swing_Result = Swing_Definition(newPitch_GettingIntoStrikeZone_Result, Offense.SwingInStrikeZoneProbability, Offense.SwingOutsideStrikeZoneProbability, situation);
            newPitch_Hitting = Hitting_Definition(newPitch_Swing_Result, Offense.HittingProbability, BatterNumberComponent, PitcherCoefficient, numberOfPitches, situation);
            newPitch_HitType = HitType_Definition(newPitch_Hitting, Offense.FoulProbability, Offense.SingleProbability, Offense.DoubleProbability, Offense.HomeRunProbabilty, BatterNumberComponent, numberOfPitches, StadiumCoefficient, CountOfNotEmptyBases, situation, CurrentBatterPosition);
            newPitch_OutType = OutType_Definition(newPitch_HitType, Defense.PopoutOnFoulProbability, Defense.FlyoutOnHomeRunProbability, Defense.GroundoutProbability, Defense.FlyoutProbability);
            newPitch_OtherCondition = OtherCondition_Definition(newPitch_OutType, situation, Defense.SacrificeFlyProbability, Defense.DoublePlayProbabilty, CountOfNotEmptyBases);
            pitchResult = pitchResult_Definition(newPitch_GettingIntoStrikeZone_Result, newPitch_Swing_Result, newPitch_Hitting, newPitch_HitType, newPitch_OutType, newPitch_OtherCondition);
        }

        private BuntResult BuntResult_Definition(int successfulBuntAttemptProbabilty, int batterNumberComponent)
        {
            int Bunt_RandomValue = BuntResult_RandomGenerator.Next(1, 1000);
            if (Bunt_RandomValue <= 50)
            {
                return BuntResult.FoulOnBunt;
            }
            else if (Bunt_RandomValue <= successfulBuntAttemptProbabilty - batterNumberComponent * 15)
            {
                return BuntResult.SuccessfulBunt;
            }
            else if (Bunt_RandomValue <= 950)
            {
                return BuntResult.SingleOnBunt;
            }
            else
            {
                return BuntResult.HitByPitch;
            }
        }

        /// <summary>
        /// Bunt generator
        /// </summary>
        public Pitch(GameSituation situation, Team AwayTeam)
        {
            Team Offense = situation.offense;
            int BatterNumberComponent = 5 - Math.Abs(Offense == AwayTeam ? situation.BatterNumber_AwayTeam - 3 : situation.BatterNumber_HomeTeam - 3);

            newBunt_result = BuntResult_Definition(Offense.SuccessfulBuntAttemptProbabilty, BatterNumberComponent);
            pitchResult = pitchResult_Definition(newBunt_result);
        }

        private PitchResult pitchResult_Definition(BuntResult newBunt_result)
        {
            switch (newBunt_result)
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
                default:
                    {
                        return PitchResult.Null;
                    }
            }
        }

        static Pitch()
        {
            Random InitializeRandomGenerator = new Random(DateTime.Now.Second);
            GettingIntoStrikeZone_RandomGenerator = new Random(2 + InitializeRandomGenerator.Next(1, 1000));
            Swing_RandomGenerator = new Random(3 + InitializeRandomGenerator.Next(1, 1000));
            Hitting_RandomGenerator = new Random(5 + InitializeRandomGenerator.Next(1, 1000));
            HitType_RandomGenerator = new Random(7 + InitializeRandomGenerator.Next(1, 1000));
            OutType_RandomGenerator = new Random(11 + InitializeRandomGenerator.Next(1, 1000));
            OtherCondition_RandomGenerator = new Random(13 + InitializeRandomGenerator.Next(1, 1000));
            BuntResult_RandomGenerator = new Random(17 + InitializeRandomGenerator.Next(1, 1000));
            StealingResult_RandomGenerator = new Random(19 + InitializeRandomGenerator.Next(1, 1000));
        }

        /// <summary>
        /// Pitch generator for base stealing
        /// </summary>
        public Pitch(GameSituation situation, List<GameSituation> match, Team HomeTeam, Team AwayTeam)
        {
            Team Offense = situation.offense;
            Team Defense = situation.offense == AwayTeam ? HomeTeam : AwayTeam;

            int BatterNumberComponent = 5 - Math.Abs(Offense == AwayTeam ? situation.BatterNumber_AwayTeam - 3 : situation.BatterNumber_HomeTeam - 3);
            List<GameSituation> ListOfHitsInCurrentInning = match.Where(gameSituation => gameSituation.inningNumber == situation.inningNumber && gameSituation.offense == situation.offense).ToList();
            int CountOfHits = ListOfHitsInCurrentInning.Where(gameSituation => gameSituation.result == PitchResult.Double ||
                                                                               gameSituation.result == PitchResult.Triple ||
                                                                               gameSituation.result == PitchResult.HomeRun).Count();
            int numberOfPitches = match.Where(gameSituation => gameSituation.offense.TeamAbbreviation == situation.offense.TeamAbbreviation && situation.id > 0).Count();
            int CountOfNotEmptyBases = Convert.ToInt32(situation.RunnerOnFirst.IsBaseNotEmpty) + Convert.ToInt32(situation.RunnerOnSecond.IsBaseNotEmpty);
            int PitcherCoefficient = GetPitcherCoeffitientForThisPitcher(Defense);
            if (numberOfPitches > PitcherCoefficient)
            {
                numberOfPitches += numberOfPitches - PitcherCoefficient;
            }
            newPitch_GettingIntoStrikeZone_Result = GettingIntoStrikeZone_Definition(Defense.StrikeZoneProbabilty, numberOfPitches, PitcherCoefficient);
            newPitch_Swing_Result = Swing_Definition(newPitch_GettingIntoStrikeZone_Result, Offense.SwingInStrikeZoneProbability, Offense.SwingOutsideStrikeZoneProbability, situation);
            pitchResult = pitchResult_Definition(newPitch_GettingIntoStrikeZone_Result, newPitch_Swing_Result, Hitting_ResultType.Miss, HitType.NoResult, OutType.NoResult, OtherCondition.NoOtherCondition);
        }

        private int GetPitcherCoeffitientForThisPitcher(Team defense)
        {
            if (defense.PitchersPlayedInMatch.Count > 1)
            {
                return 28 - defense.PitchersPlayedInMatch.Count;
            }
            else
            {
                return 76 - defense.CurrentPitcher.NumberInRotation * 6;
            }
        }

        public Pitch(GameSituation situation, StealingType stealingType)
        {
            Team Offense = situation.offense;
            string RunnerPositionInDefense = "";
            switch (stealingType)
            {
                case StealingType.OnlySecondBase:
                case StealingType.SecondBaseAfterThird:
                    {
                        RunnerPositionInDefense = Offense.BattingLineup.Where(player => player.id == situation.RunnerOnFirst.runnerID).First().PositionForThisMatch;
                        break;
                    }
                case StealingType.OnlyThirdBase:
                case StealingType.ThirdBaseBeforeSecond:
                    {
                        RunnerPositionInDefense = Offense.BattingLineup.Where(player => player.id == situation.RunnerOnSecond.runnerID).First().PositionForThisMatch;
                        break;
                    }
            }
            newStealingAttempt_result = StealingAttempt_Result_Definition(Offense.StealingBaseProbability, RunnerPositionInDefense, stealingType);
            pitchResult = pitchResult_Definition(newStealingAttempt_result);
        }

        private PitchResult pitchResult_Definition(StealingResult newStealingAttempt_result)
        {
            switch (newStealingAttempt_result)
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

        private StealingResult StealingAttempt_Result_Definition(int sb_probability, string runnerPositionInDefense, StealingType stealingType)
        {
            int StealingAttempt_RandomValue = StealingResult_RandomGenerator.Next(1, 100);

            int StealingProbabilityCorrectedByPosition;
            if (runnerPositionInDefense != "P")
            {
                StealingProbabilityCorrectedByPosition = sb_probability;
            }
            else
            {
                if (stealingType == StealingType.SecondBaseAfterThird)
                {
                    StealingProbabilityCorrectedByPosition = sb_probability * 2;
                }
                else
                {
                    StealingProbabilityCorrectedByPosition = sb_probability / 2;
                }
            }

            switch (stealingType)
            {
                case StealingType.OnlySecondBase:
                    {
                        if (StealingAttempt_RandomValue <= StealingProbabilityCorrectedByPosition)
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
                        if (StealingAttempt_RandomValue <= StealingProbabilityCorrectedByPosition / 4)
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
                        if (StealingAttempt_RandomValue <= StealingProbabilityCorrectedByPosition / 5)
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
                        if (StealingAttempt_RandomValue <= 100 - StealingProbabilityCorrectedByPosition / 3)
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