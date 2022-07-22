using System;

namespace VKR.EF.Entities.Views
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
        //public int GamesStarted { get; set; }
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

        public double KperNineInnings => Strikeouts / ((double)Outs / 3) * 9;

        public double BBperNineInnings => WalksAllowed / ((double)Outs / 3) * 9;

        public double KperBb => (double)Strikeouts / WalksAllowed;

        public double GOtoAo => (double)Groundouts / Flyouts;

        public PitchingStats(int g, int gs, int k, int outs, int bb, int sac, int sf, int sb, int cs, int tbf,
                       int qs, int sho, int cg, int w, int l, int sv, int hld, int hbp,
                       int singles, int doubles, int triples, int hr, int runs, int doublePlay, int groundout, int flyout, int tgp)
        {
            GamesPlayed = g;
            //GamesStarted = gs;
            Strikeouts = k;
            Outs = outs;
            WalksAllowed = bb;
            SacrificeBunts = sac;
            SacrificeFlies = sf;
            StolenBasesAllowed = sb;
            CaughtStealing = cs;
            TotalBattersFaced = tbf;
            QualityStarts = qs;
            Shutouts = sho;
            CompleteGames = cg;
            Wins = w;
            Losses = l;
            Saves = sv;
            Holds = hld;
            HitByPitch = hbp;
            SinglesAllowed = singles;
            DoublesAllowed = doubles;
            TriplesAllowed = triples;
            HomeRunsAllowed = hr;
            RunsAllowed = runs;
            DoublePlays = doublePlay;
            Groundouts = groundout;
            Flyouts = flyout;
            TGP = tgp;
        }

        public PitchingStats()
        {

        }
    }
}