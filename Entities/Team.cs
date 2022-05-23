using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Entities
{
    public class Team
    {
        public string TeamAbbreviation;
        public string TeamCity;
        public string TeamTitle;
        public List<Color> TeamColor;
        public Color TeamColorForThisMatch;
        public bool DhRule;
        public int StrikeZoneProbability;
        public int SwingInStrikeZoneProbability;
        public int SwingOutsideStrikeZoneProbability;
        public int HittingProbability;
        public int FoulProbability;
        public int SingleProbability;
        public int DoubleProbability;
        public int HomeRunProbability;
        public int TripleProbability;
        public int PopoutOnFoulProbability;
        public int FlyoutOnHomeRunProbability;
        public int GroundoutProbability;
        public int FlyoutProbability;
        public int DoublePlayProbability;
        public int SacrificeFlyProbability;
        public int StealingBaseProbability;
        public int SuccessfulStealingBaseAttemptProbability;
        public int SuccessfulBuntAttemptProbability;
        public int HitByPitchProbability;

        public int NormalizedOffensiveRating;
        public int NormalizedDefensiveRating;
        public int Stadium;
        public Manager TeamManager;
        public string League;

        public List<Pitcher> PitchersPlayedInMatch;
        public Pitcher CurrentPitcher => PitchersPlayedInMatch.Last();
        public List<Batter> BattingLineup;
        public string Division;
        public int Wins;
        public int Losses;
        public string HomeBalance;
        public string AwayBalance;
        public double GamesBehind;
        public int RunsScored;
        public int RunsAllowed;
        public int Streak;
        public int RunDifferential => RunsScored - RunsAllowed;

        public double Pct => Wins + Losses == 0 ? 0 : Math.Round(Wins / (double)(Wins + Losses), 3);

        public int OverallRating => (NormalizedDefensiveRating + NormalizedOffensiveRating) / 2;

        public double DefensiveRating()
        {
            var pitchingComponent = (double)(1600 - StrikeZoneProbability - (3000 - HitByPitchProbability)) / 36;
            var groundoutComponent = GroundoutProbability * 1.1 / 20;
            var outfieldComponent = (double)(FlyoutProbability - GroundoutProbability) / 20;
            var doublePlayComponent = (double)DoublePlayProbability / 3;
            var pitcherNumber = (Wins + Losses + 1) % 5 == 0 ? 1 : 6 - (Wins + Losses + 1) % 5;
            var pitcherNumberComponent = (double)pitcherNumber / 2;
            return Math.Round(pitchingComponent + groundoutComponent + outfieldComponent + doublePlayComponent + pitcherNumberComponent, 2);
        }

        public double OffensiveRating()
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
            return Math.Round(singleComponent + doubleComponent + homeRunComponent + tripleComponent + baseStealingComponent, 2);
        }
        
        public BattingStats BattingStats;
        public PitchingStats PitchingStats;

        public string StreakString => Streak > 0 ? $"Won {Streak}" : $"Lost {Math.Abs(Streak)}";

        public Team(string abbreviation, string city, string name, int strikeZoneProbability, int swingSzProbability, int swingNotSzProbability,
                    int hitProbability, int foulProbability, int singleProbability, int doubleProbability, int homeRunProbability,
                    int popoutOnFoulProbability, int flyoutOnHrProbability, int groundoutProbability, int flyoutProbability, int sacFlyProbability,
                    int doublePlayProbability, int successfulBaseStealingProbability, int successfulBuntProbability, int stadium, bool dhRule,
                    int w, int l, int hitByPitch, int sb, int tripleProbability, string league = "")
        {
            TeamAbbreviation = abbreviation;
            TeamCity = city;
            TeamTitle = name;
            StrikeZoneProbability = strikeZoneProbability;
            SwingInStrikeZoneProbability = swingSzProbability;
            SwingOutsideStrikeZoneProbability = swingNotSzProbability;
            HittingProbability = hitProbability;
            FoulProbability = foulProbability;
            SingleProbability = singleProbability;
            DoubleProbability = doubleProbability;
            HomeRunProbability = homeRunProbability;
            PopoutOnFoulProbability = popoutOnFoulProbability;
            FlyoutOnHomeRunProbability = flyoutOnHrProbability;
            GroundoutProbability = groundoutProbability;
            FlyoutProbability = flyoutProbability;
            DoublePlayProbability = doublePlayProbability;
            SacrificeFlyProbability = sacFlyProbability;
            SuccessfulStealingBaseAttemptProbability = successfulBaseStealingProbability;
            SuccessfulBuntAttemptProbability = successfulBuntProbability;
            Stadium = stadium;
            PitchersPlayedInMatch = new List<Pitcher>();
            DhRule = dhRule;
            Wins = w;
            Losses = l;
            HitByPitchProbability = hitByPitch;
            StealingBaseProbability = sb;
            TripleProbability = tripleProbability;
            League = league;
        }

        public Team (string abbreviation, string name, string league, string division, int homeWins, int homeLosses, int awayWins, int awayLosses, int streak)
        {
            TeamAbbreviation = abbreviation;
            TeamTitle = name;
            League = league;
            Division = division;
            HomeBalance = $"{homeWins}-{homeLosses}";
            AwayBalance = $"{awayWins}-{awayLosses}";
            Wins = homeWins + awayWins;
            Losses = homeLosses + awayLosses;
            Streak = streak;
        }
    }
}