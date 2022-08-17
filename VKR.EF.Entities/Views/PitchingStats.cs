using System;

namespace VKR.EF.Entities
{
    public class PitchingStats
    {
        public int Season { get; set; }
        public TypeOfMatchEnum MatchType { get; set; }
        public int GamesPlayed { get; set; }
        public int Strikeouts { get; set; }
        public int RunsAllowed { get; set; }
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

        public double IP => Math.Round(Outs / 3 + (double)(Outs % 3) / 10, 1);

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

                return Math.Round(RunsAllowed / ((double)Outs / 3) * 9, 2);
            }
        }

        public double KperNineInnings => Outs == 0 ? 0 : Strikeouts / ((double)Outs / 3) * 9;

        public double BBperNineInnings => Outs == 0 ? 0 : WalksAllowed / ((double)Outs / 3) * 9;

        public double KperBb => WalksAllowed == 0 ? 0 : (double)Strikeouts / WalksAllowed;

        public double GOtoAo => Flyouts == 0 ? 0 : (double)Groundouts / Flyouts;
    }
}