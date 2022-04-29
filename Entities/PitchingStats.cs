using System;

namespace Entities
{
    public class PitchingStats
    {
        public int GamesPlayed;
        public int Strikeouts;
        public int RunsAllowed;
        public int Outs;
        public int WalksAllowed;
        public int SacrificeBunts;
        public int SacrificeFlies;
        public int StolenBasesAllowed;
        public int CaughtStealing;
        public int TotalBattersFaced;
        public int QualityStarts;
        public int Shutouts;
        public int CompleteGames;
        public int Wins;
        public int Losses;
        public int Saves;
        public int Holds;
        public int HitByPitch;
        public int Groundouts;
        public int Flyouts;
        public int GamesStarted;

        public int SinglesAllowed;
        public int DoublesAllowed;
        public int TriplesAllowed;
        public int HomeRunsAllowed;
        public int DoublePlays;
        public int Tgp;

        public int HitsAllowed => SinglesAllowed + DoublesAllowed + TriplesAllowed + HomeRunsAllowed;

        public double IP => Math.Round(Outs / 3 + (double)(Outs % 3) / 10, 1);

        public double WHIP
        {
            get
            {
                if (IP == 0)
                {
                    return 0;
                }

                return Math.Round((WalksAllowed + HitsAllowed) / ((double)Outs / 3), 2);
            }
        }

        public double Baa
        {
            get
            {
                if (TotalBattersFaced - WalksAllowed - HitByPitch - SacrificeFlies - SacrificeBunts == 0)
                {
                    return 0;
                }

                return Math.Round((double)HitsAllowed / (TotalBattersFaced - WalksAllowed - HitByPitch - SacrificeFlies - SacrificeBunts), 3);
            }
        }

        public double ERA
        {
            get
            {
                if (IP == 0)
                {
                    return 0;
                }

                return Math.Round(RunsAllowed / ((double)Outs / 3) * 9, 2);
            }
        }

        public double KperNineInnings
        => (double)Strikeouts / (Outs / 3) * 9;

        public double BBperNineInnings => WalksAllowed / ((double)Outs / 3) * 9;

        public double KperBb => (double)Strikeouts / WalksAllowed;

        public double GOtoAo => (double)Groundouts / Flyouts;

        public PitchingStats(int g, int gs, int k, int outs, int bb, int sac, int sf, int sb, int cs, int tbf,
                       int qs, int sho, int cg, int w, int l, int sv, int hld, int hbp,
                       int singles, int doubles, int triples, int hr, int runs, int doublePlay, int groundout, int flyout, int tgp)
        {
            GamesPlayed = g;
            GamesStarted = gs;
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
            Tgp = tgp;
        }
    }
}