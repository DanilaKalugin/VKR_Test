﻿using System;

namespace VKR.EF.Entities.Views
{
    public class PitchingStats :StatGroupedBySeasonAndMatchType
    {
        public int GamesPlayed { get; set; }
        public int Strikeouts { get; set; }
        public int RunsAllowed { get; set; }
        public int EarnedRuns { get; set; }
        public int Outs { get; set; }
        public int WalksAllowed { get; set; }
        public int SacrificeBunts { get; set; }
        public int SacrificeFlies { get; set; }
        public int StolenBasesAllowed { get; set; }
        public int CaughtStealing { get; set; }
        public int TotalBattersFaced { get; set; }
        public int QualityStarts { get; set; }
        public int Shutouts { get; set; }
        public int CompleteGames { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Saves { get; set; }
        public int Holds { get; set; }
        public int HitByPitch { get; set; }
        public int Groundouts { get; set; }
        public int Flyouts { get; set; }
        public int GamesStarted { get; set; }
        public int SinglesAllowed { get; set; }
        public int DoublesAllowed { get; set; }
        public int TriplesAllowed { get; set; }
        public int HomeRunsAllowed { get; set; }
        public int DoublePlays { get; set; }
        public int TGP { get; set; }

        public int HitsAllowed => SinglesAllowed + DoublesAllowed + TriplesAllowed + HomeRunsAllowed;

        public double InningsPitched => Math.Round(Outs / 3 + (double)(Outs % 3) / 10, 1);

        public double WHIP
        {
            get
            {
                if (Outs == 0) return 0;

                return Math.Round((WalksAllowed + HitsAllowed) / ((double)Outs / 3), 2);
            }
        }

        public double BAA
        {
            get
            {
                if (TotalBattersFaced - WalksAllowed - HitByPitch - SacrificeFlies - SacrificeBunts == 0)
                    return 0;

                return Math.Round((double)HitsAllowed / (TotalBattersFaced - WalksAllowed - HitByPitch - SacrificeFlies - SacrificeBunts), 3);
            }
        }

        public double ERA
        {
            get
            {
                if (Outs == 0) return 0;

                return Math.Round(EarnedRuns / ((double)Outs / 3) * 9, 2);
            }
        }

        public double StrikeoutsPerNineInnings => Outs == 0 ? 0 : Strikeouts / ((double)Outs / 3) * 9;

        public double WalksPerNineInnings => Outs == 0 ? 0 : WalksAllowed / ((double)Outs / 3) * 9;

        public double StrikeoutsPerWalks => WalksAllowed == 0 ? 0 : (double)Strikeouts / WalksAllowed;

        public double GOtoAo => Flyouts == 0 ? 0 : (double)Groundouts / Flyouts;
    }
}