using System;

namespace VKR.EF.Entities.Tables
{
    public class TeamRating
    {
        public Team Team { get; set; }
        public string TeamAbbreviation { get; set; }
        public ushort StrikeZoneProbability { get; set; }
        public ushort HitByPitchProbability { get; set; }
        public short SwingInStrikeZoneProbability { get; set; }
        public short SwingOutsideStrikeZoneProbability { get; set; }
        public ushort HittingProbability { get; set; }
        public ushort FoulProbability { get; set; }
        public ushort SingleProbability { get; set; }
        public ushort DoubleProbability { get; set; }
        public ushort HomeRunProbability { get; set; }
        public ushort TripleProbability { get; set; }
        public ushort PopoutOnFoulProbability { get; set; }
        public ushort FlyoutOnHomeRunProbability { get; set; }
        public ushort GroundoutProbability { get; set; }
        public ushort FlyoutProbability { get; set; }
        public byte DoublePlayProbability { get; set; }
        public byte SacrificeFlyProbability { get; set; }
        public ushort StealingBaseProbability { get; set; }
        public byte SuccessfulStealingBaseAttemptProbability { get; set; }
        public ushort SuccessfulBuntAttemptProbability { get; set; }

        public int NormalizedOffensiveRating { get; set; }
        public int NormalizedDefensiveRating { get; set; }

        public int OverallRating => (NormalizedDefensiveRating + NormalizedOffensiveRating) / 2;
        public double DefensiveRating
        {
            get
            {
                var pitchingComponent = (double)(3000 - StrikeZoneProbability - HitByPitchProbability) / 36;
                var groundoutComponent = GroundoutProbability * 1.1 / 20;
                var outfieldComponent = (double)(FlyoutProbability - GroundoutProbability) / 20;
                var doublePlayComponent = (double)DoublePlayProbability / 3;
                return Math.Round(pitchingComponent + groundoutComponent + outfieldComponent + doublePlayComponent, 2);
            }
        }

        public double OffensiveRating
        {
            get
            {
                var fullHittingProbability = (double)(2000 - HittingProbability) / 2000;
                var fullSingleProbability = (double)SingleProbability / 2000;
                var fullDoubleProbability = (double)DoubleProbability / 2000;
                var fullHrProbability = (double)HomeRunProbability / 2000;
                var fullTripleProbability = (double)TripleProbability / 2000;

                var doubleComponent = fullHittingProbability * fullDoubleProbability * 75;
                var homeRunComponent = fullHittingProbability * fullHrProbability * 225;
                var tripleComponent = fullHittingProbability * fullTripleProbability * 150;
                var singleComponent = fullHittingProbability * fullSingleProbability * 50;

                var baseStealingComponent = (double)(StealingBaseProbability * SuccessfulStealingBaseAttemptProbability) / 8000;
                return Math.Round(
                    singleComponent + doubleComponent + homeRunComponent + tripleComponent + baseStealingComponent, 2);
            }
        }
    }
}