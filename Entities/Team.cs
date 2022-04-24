﻿using System;
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
        public bool DHRule;
        public int StrikeZoneProbabilty;
        public int SwingInStrikeZoneProbability;
        public int SwingOutsideStrikeZoneProbability;
        public int HittingProbability;
        public int FoulProbability;
        public int SingleProbability;
        public int DoubleProbability;
        public int HomeRunProbabilty;
        public int TripleProbability;
        public int PopoutOnFoulProbability;
        public int FlyoutOnHomeRunProbability;
        public int GroundoutProbability;
        public int FlyoutProbability;
        public int DoublePlayProbabilty;
        public int SacrificeFlyProbability;
        public int StealingBaseProbability;
        public int SuccessfulStelingBaseAttemptProbabilty;
        public int SuccessfulBuntAttemptProbabilty;
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
        public int RunDifferential => RunsScored - RunsAllowed;

        public double PCT
        {
            get
            {
                if (Wins + Losses == 0)
                {
                    return 0;
                }
                else return Math.Round(Wins / (double)(Wins + Losses), 3);
            }
        }

        public int OverallRating => (NormalizedDefensiveRating + NormalizedOffensiveRating) / 2;

        public double DefensiveRating()
        {
            var pitchingComponent = (double)(1600 - StrikeZoneProbabilty - (3000 - HitByPitchProbability)) / 36;
            var groundoutComponent = (double)(GroundoutProbability * 1.1) / 20;
            var outfieldComponent = (double)(FlyoutProbability - GroundoutProbability) / 20;
            var doublePlayComponent = (double)DoublePlayProbabilty / 3;
            var pitcherNumber = (Wins + Losses + 1) % 5 == 0 ? 1 : 6 - (Wins + Losses + 1) % 5;
            var pitcherNumberComponent = (double)pitcherNumber / 2;
            return Math.Round(pitchingComponent + groundoutComponent + outfieldComponent + doublePlayComponent + pitcherNumberComponent, 2);
        }

        public double OffensiveRating()
        {
            var fullHitiingProbabilty = (double)(2000 - HittingProbability) / 2000;
            var fullSingleProbability = (double)SingleProbability / 2000;
            var fullDoubleProbability = (double)DoubleProbability / 2000;
            var fullHRProbability = (double)HomeRunProbabilty / 2000;
            var fullTripleProbability = (double)TripleProbability / 2000;

            var doubleComponent = fullHitiingProbabilty * fullDoubleProbability * 75;
            var homeRunComponent = fullHitiingProbabilty * fullHRProbability * 225;
            var tripleComponent = fullHitiingProbabilty * fullTripleProbability * 150;
            var singleComponent = fullHitiingProbabilty * fullSingleProbability * 50;

            var baseStealingComponent = (double)(StealingBaseProbability * SuccessfulStelingBaseAttemptProbabilty) / 8000;
            return Math.Round(singleComponent + doubleComponent + homeRunComponent + tripleComponent + baseStealingComponent, 2);
        }

        //Batting stats
        public BattingStats battingStats;
        public PitchingStats pitchingStats;

        public Team(string abbreviation, string city, string name, int strikeZoneProbability, int swingSZProbability, int swingNotSZProbability,
                    int hitProbability, int foulProbability, int singleProbability, int doubleProbability, int homeRunProbability,
                    int popoutOnFoulProbability, int flyoutOnHRProbability, int groundoutProbability, int flyoutProbability, int sacFlyProbability,
                    int doublePlayProbability, int successfulBaseStelingProbability, int successfulBuntProbability, int stadium, bool dhRule,
                    int w, int l, int hitByPitch, int sb, int tripleProbability, string league = "")
        {
            TeamAbbreviation = abbreviation;
            TeamCity = city;
            TeamTitle = name;
            StrikeZoneProbabilty = strikeZoneProbability;
            SwingInStrikeZoneProbability = swingSZProbability;
            SwingOutsideStrikeZoneProbability = swingNotSZProbability;
            HittingProbability = hitProbability;
            FoulProbability = foulProbability;
            SingleProbability = singleProbability;
            DoubleProbability = doubleProbability;
            HomeRunProbabilty = homeRunProbability;
            PopoutOnFoulProbability = popoutOnFoulProbability;
            FlyoutOnHomeRunProbability = flyoutOnHRProbability;
            GroundoutProbability = groundoutProbability;
            FlyoutProbability = flyoutProbability;
            DoublePlayProbabilty = doublePlayProbability;
            SacrificeFlyProbability = sacFlyProbability;
            SuccessfulStelingBaseAttemptProbabilty = successfulBaseStelingProbability;
            SuccessfulBuntAttemptProbabilty = successfulBuntProbability;
            Stadium = stadium;
            PitchersPlayedInMatch = new List<Pitcher>();
            DHRule = dhRule;
            Wins = w;
            Losses = l;
            HitByPitchProbability = hitByPitch;
            StealingBaseProbability = sb;
            TripleProbability = tripleProbability;
            League = league;
        }

        public Team (string abbreviation, string name, int wins, int losses, string league, string division, int homeWins, int homeLosses, int awayWins, int awayLosses)
        {
            TeamAbbreviation = abbreviation;
            TeamTitle = name;
            League = league;
            Wins = wins;
            Losses = losses;
            Division = division;
            HomeBalance = $"{homeWins}-{homeLosses}";
            AwayBalance = $"{awayWins}-{awayLosses}";
        }
    }
}