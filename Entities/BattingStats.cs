using System;

namespace Entities
{
    public class BattingStats
    {
        public int Games;
        public int SacrificeFlies;
        public int SacrificeBunts;
        public int RBI;
        public int HitByPitch;
        public int StolenBases;
        public int CaughtStealing;
        public int Runs;
        public int Groundouts;
        public int Flyouts;
        public int Popouts;
        public int Strikeouts;
        public int Walks;
        public int Singles;
        public int Doubles;
        public int Triples;
        public int HomeRuns;
        public int PA;
        public int DoublePlay;
        public int TGP;

        public int Hits => Singles + Doubles + Triples + HomeRuns;

        public int AtBats => Singles + Doubles + Triples + HomeRuns + Groundouts + Flyouts + Popouts + Strikeouts;

        public double AVG => AtBats == 0 ? 0 : Math.Round((double)Hits / AtBats, 3);

        public double OBP
        {
            get
            {
                if (AtBats + Walks + HitByPitch + SacrificeFlies == 0) return 0;

                return Math.Round((double)(Hits + Walks + HitByPitch) / (AtBats + Walks + HitByPitch + SacrificeFlies), 3);
            }
        }

        public int TotalBases => 4 * HomeRuns + 3 * Triples + 2 * Doubles + Singles;

        public double SLG => TotalBases == 0 ? 0 : Math.Round((double)TotalBases / AtBats, 3);

        public int XBH => Hits - Singles;

        public double OPS => OBP + SLG;

        public double ISO => SLG - AVG;

        public double ABperHR => (double)AtBats / HomeRuns;

        public double WalkToStrikeout => (double)Walks / Strikeouts;

        public double GOtoAO => (double)Groundouts / Flyouts;

        public double WalkPercentage => (double)Walks / PA;

        public double StrikeoutPercentage => (double)Strikeouts / PA;

        public double ExpectedHomeRuns => TGP > 0 ? HomeRuns / TGP * 162 : 0;

        public BattingStats(int g, int singles, int doubles, int triples, int hr, int sf, int sac, int rbi, int hbp, int sb, int cs, int runs, int bb, int k, int go, int ao, int po, int pa, int gidp, int tgp)
        {
            Games = g;
            Singles = singles;
            Doubles = doubles;
            Triples = triples;
            HomeRuns = hr;
            SacrificeFlies = sf;
            SacrificeBunts = sac;
            RBI = rbi;
            HitByPitch = hbp;
            StolenBases = sb;
            CaughtStealing = cs;
            Runs = runs;
            Walks = bb;
            Strikeouts = k;
            Groundouts = go;
            Flyouts = ao;
            Popouts = po;
            PA = pa;
            DoublePlay = gidp;
            TGP = tgp;
        }
    }
}