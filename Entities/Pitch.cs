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

        private enum GettingIntoStrikeZone_TypeOfResult { BallInTheStrikeZone, BallIsOutOfTheStrikeZone, HitByPitch }
        GettingIntoStrikeZone_TypeOfResult newPitch_GettingIntoStrikeZone_Result;
        private enum Swing_ResultType { Swing, NoSwing, NoResult }
        Swing_ResultType newPitch_Swing_Result;
        private enum Hitting_ResultType { Hit, Miss, NoResult }
        Hitting_ResultType newPitch_Hitting;
        private enum HitType { Foul, Single, Double, Triple, HomeRun, NoResult }
        HitType newPitch_HitType;
        private enum OutType { Flyout, Groundout, Popout, NoResult, NoOut }
        OutType newPitch_OutType;
        private enum OtherCondition { SacFly, DoublePlay, NoOtherCondition };
        OtherCondition newPitch_OtherCondition;

        public enum BuntResult { SuccessfulBunt, FoulOnBunt, SingleOnBunt };
        BuntResult newBunt_result;

        public PitchResult pitchResult;

        public enum PitchResult { HitByPitch, Ball, Strike, Null, Foul, Single, Double, Triple, HomeRun, Flyout, Groundout, Popout, DoublePlay, SacrificeFly, SacrificeBunt }

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
            else if (gettingIntoStrikeZone_Result == GettingIntoStrikeZone_TypeOfResult.BallIsOutOfTheStrikeZone && swing_Result == Swing_ResultType.NoSwing)
            {
                return PitchResult.Ball;
            }
            else if ((gettingIntoStrikeZone_Result == GettingIntoStrikeZone_TypeOfResult.BallInTheStrikeZone && swing_Result == Swing_ResultType.NoSwing) ||
                     (swing_Result == Swing_ResultType.Swing && hitting_Result == Hitting_ResultType.Miss))
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

            if (GettingIntoStrikeZone_RandomValue < strikeZone_probability - pitcherCoefficient + numberOfPitches)
            {
                return GettingIntoStrikeZone_TypeOfResult.BallIsOutOfTheStrikeZone;
            }
            else if (GettingIntoStrikeZone_RandomValue < 990)
            {
                return GettingIntoStrikeZone_TypeOfResult.BallInTheStrikeZone;
            }
            else
            {
                return GettingIntoStrikeZone_TypeOfResult.HitByPitch;
            }
        }

        private Swing_ResultType Swing_Definition(GettingIntoStrikeZone_TypeOfResult ballInStrikeZone, int swingProbabilityInStrikeZone, int swingProbabilityOutsideStrikeZone)
        {
            int Swing_RandomValue = Swing_RandomGenerator.Next(1, 100);
            if (ballInStrikeZone == GettingIntoStrikeZone_TypeOfResult.HitByPitch)
            {
                return Swing_ResultType.NoResult;
            }
            else if (ballInStrikeZone == GettingIntoStrikeZone_TypeOfResult.BallInTheStrikeZone)
            {
                if (Swing_RandomValue > swingProbabilityInStrikeZone)
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
                if (Swing_RandomValue > swingProbabilityOutsideStrikeZone)
                {
                    return Swing_ResultType.Swing;
                }
                else
                {
                    return Swing_ResultType.NoSwing;
                }
            }
        }

        private Hitting_ResultType Hitting_Definition(Swing_ResultType swingResult, int Hitting_probability, int BatterNumberComponent, int pitcherCoefficient)
        {
            int Hitting_RandomValue = Hitting_RandomGenerator.Next(1, 2000);
            if (swingResult == Swing_ResultType.Swing)
            {
                if (Hitting_RandomValue > Hitting_probability + pitcherCoefficient - BatterNumberComponent * 3)
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

        private HitType HitType_Definition(Hitting_ResultType hitting_Result, int Foul_Probability, int single_probability, int double_probability, int homeRun_Probability, int BatterNumberComponent, int countOfHits, int numberOfPitches, int StadiumCoefficient, int countOfNotEmptyBases)
        {
            int HitType_RandomValue = HitType_RandomGenerator.Next(1, 2000);
            if (hitting_Result == Hitting_ResultType.Hit)
            {
                if (HitType_RandomValue <= Foul_Probability - BatterNumberComponent * 2 + countOfHits * 45 + countOfNotEmptyBases * 10 * 4)
                {
                    return HitType.Foul;
                }
                else if (HitType_RandomValue <= single_probability - BatterNumberComponent * 1 + countOfHits * 30 + countOfNotEmptyBases * 10 * 3)
                {
                    return HitType.Single;
                }
                else if (HitType_RandomValue <= double_probability + countOfHits * 15 + StadiumCoefficient / 3 + countOfNotEmptyBases * 10 * 2)
                {
                    return HitType.Double;
                }
                else if (HitType_RandomValue <= homeRun_Probability - numberOfPitches / 3 - StadiumCoefficient / 9 + countOfNotEmptyBases * 10)
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

        private OutType OutType_Definition(HitType TypeOfHit, int PopoutOnFoul_probability, int FlyoutOnHomeRun_probability, int Groundout_probability, int Flyout_probability, int countOfHits)
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
                else if (OutType_RandomValue <= Groundout_probability + countOfHits * 15 && TypeOfHit != HitType.Triple)
                {
                    return OutType.Groundout;
                }
                else if (OutType_RandomValue <= Flyout_probability + countOfHits * 15 * (Flyout_probability / (double)Groundout_probability) && TypeOfHit != HitType.Single)
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

        private OtherCondition OtherCondition_Definition(OutType outType, GameSituation situation, int SacrificeFly_Probability, int DoublePlay_Probability)
        {
            int OtherCondition_RandomValue = OtherCondition_RandomGenerator.Next(1, 100);
            if (outType == OutType.Flyout && ((situation.RunnerOnSecond.IsBaseNotEmpty) || (situation.RunnerOnThird.IsBaseNotEmpty)) && situation.outs < 2 && OtherCondition_RandomValue <= SacrificeFly_Probability)
            {
                return OtherCondition.SacFly;
            }
            else if (outType == OutType.Groundout && (situation.RunnerOnFirst.IsBaseNotEmpty) && situation.outs <= 1 && OtherCondition_RandomValue <= DoublePlay_Probability)
            {
                return OtherCondition.DoublePlay;
            }
            else
            {
                return OtherCondition.NoOtherCondition;
            }
        }
        private BuntResult BuntResult_Definition(int successfulBuntAttemptProbabilty, int batterNumberComponent)
        {
            int Bunt_RandomValue = BuntResult_RandomGenerator.Next(1, 100);
            if (Bunt_RandomValue <= 5)
            {
                return BuntResult.FoulOnBunt;
            }
            else if (Bunt_RandomValue <= successfulBuntAttemptProbabilty - batterNumberComponent * 2)
            {
                return BuntResult.SuccessfulBunt;
            }
            else
            {
                return BuntResult.SingleOnBunt;
            }
        }

        public Pitch(GameSituation situation, List<GameSituation> match, Team HomeTeam, Team AwayTeam, Stadium stadium)
        {
            Team Offense = situation.offense;
            Team Defense = situation.offense == AwayTeam ? HomeTeam : AwayTeam;

            int BatterNumberComponent = (5 - Math.Abs(Offense == AwayTeam ? situation.BatterNumber_AwayTeam - 3 : situation.BatterNumber_HomeTeam - 3));
            List<GameSituation> ListOfHitsInCurrentInning = match.Where(gameSituation => gameSituation.inningNumber == situation.inningNumber && gameSituation.offense == situation.offense).ToList();
            int CountOfHits = ListOfHitsInCurrentInning.Where(gameSituation => gameSituation.result == PitchResult.Double).Count() * 2 +
                              ListOfHitsInCurrentInning.Where(gameSituation => gameSituation.result == PitchResult.Single || gameSituation.result == PitchResult.Triple || gameSituation.result == PitchResult.HomeRun).Count();
            int numberOfPitches = match.Where(gameSituation => gameSituation.offense.TeamAbbreviation == situation.offense.TeamAbbreviation).Count();
            int StadiumCoefficient = stadium.stadiumDistanceToCenterfield - 400;
            int CountOfNotEmptyBases = Convert.ToInt32(situation.RunnerOnFirst.IsBaseNotEmpty) + Convert.ToInt32(situation.RunnerOnSecond.IsBaseNotEmpty);
            int PitcherCoefficient;
            if (Defense.PitchersPlayedInMatch.Count > 1)
            {
                PitcherCoefficient = 35 - Defense.PitchersPlayedInMatch.Count;
            }
            else
            {
                PitcherCoefficient = 81 - Defense.CurrentPitcher.NumberInRotation * 5;
            }

            newPitch_GettingIntoStrikeZone_Result = GettingIntoStrikeZone_Definition(Defense.StrikeZoneProbabilty, numberOfPitches, PitcherCoefficient);
            newPitch_Swing_Result = Swing_Definition(newPitch_GettingIntoStrikeZone_Result, Offense.SwingInStrikeZoneProbability, Offense.SwingOutsideStrikeZoneProbability);
            newPitch_Hitting = Hitting_Definition(newPitch_Swing_Result, Offense.HittingProbability, BatterNumberComponent, PitcherCoefficient);
            newPitch_HitType = HitType_Definition(newPitch_Hitting, Offense.FoulProbability, Offense.SingleProbability, Offense.DoubleProbability, Offense.HomeRunProbabilty, BatterNumberComponent, CountOfHits, numberOfPitches, StadiumCoefficient, CountOfNotEmptyBases);
            newPitch_OutType = OutType_Definition(newPitch_HitType, Defense.PopoutOnFoulProbability, Defense.FlyoutOnHomeRunProbability, Defense.GroundoutProbability, Defense.FlyoutProbability, CountOfHits);
            newPitch_OtherCondition = OtherCondition_Definition(newPitch_OutType, situation, Defense.SacrificeFlyProbability, Defense.DoubleProbability);

            pitchResult = pitchResult_Definition(newPitch_GettingIntoStrikeZone_Result, newPitch_Swing_Result, newPitch_Hitting, newPitch_HitType, newPitch_OutType, newPitch_OtherCondition);
        }

        public Pitch(GameSituation situation, Team AwayTeam)
        {
            Team Offense = situation.offense;
            int BatterNumberComponent = (5 - Math.Abs(Offense == AwayTeam ? situation.BatterNumber_AwayTeam - 3 : situation.BatterNumber_HomeTeam - 3));

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
                default:
                    {
                        return PitchResult.Null;
                    }
            }
        }

        static Pitch()
        {
            GettingIntoStrikeZone_RandomGenerator = new Random(2 + new Random().Next(1, 1000));
            Swing_RandomGenerator = new Random(3 + new Random().Next(1, 3000));
            Hitting_RandomGenerator = new Random(5 + new Random().Next(1, 5000));
            HitType_RandomGenerator = new Random(7 + new Random().Next(1, 7990));
            OutType_RandomGenerator = new Random(11 + new Random().Next(1, 1100));
            OtherCondition_RandomGenerator = new Random(13 + new Random().Next(1, 1300));
            BuntResult_RandomGenerator = new Random(17 + new Random().Next(1, 1093));
        }
    }
}