using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Poputs;
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

        public int AtBats => Singles + Doubles + Triples + HomeRuns + Groundouts + Flyouts + Poputs + Strikeouts;

        public double AVG
        {
            get
            {
                if (AtBats == 0)
                {
                    return 0;
                }
                else return Math.Round((double)Hits / AtBats, 3);
            }
        }

        public double OBP
        {
            get
            {
                if (AtBats + Walks + HitByPitch + SacrificeFlies == 0)
                {
                    return 0;
                }
                else return Math.Round((double)(Hits + Walks + HitByPitch) / (AtBats + Walks + HitByPitch + SacrificeFlies), 3);
            }
        }

        public int TotalBases => 4 * HomeRuns + 3 * Triples + 2 * Doubles + Singles;

        public double SLG
        {
            get
            {
                if (TotalBases == 0)
                {
                    return 0;
                }
                else return Math.Round((double)TotalBases / AtBats, 3);
            }
        }

        public int XBH => Hits - Singles;

        public double OPS => OBP + SLG;

        public double ISO => SLG - AVG;

        public double ABperHR => (double)AtBats / HomeRuns;

        public double WalkToStrikeout => (double)Walks / Strikeouts;

        public double GOtoAO => (double)Groundouts / Flyouts;

        public double WalkPercentage => (double)Walks / PA;

        public double StrikeoutPercentage => (double)Strikeouts / PA;

        public BattingStats(int _g, int _singles, int _doubles, int _triples, int _hr, int _sf, int _sac, int _rbi, int _hbp, int _sb, int _cs, int _runs, int _bb, int _k, int _go, int _ao, int _po, int _pa, int _gidp, int _tgp)
        {
            Games = _g;
            Singles = _singles;
            Doubles = _doubles;
            Triples = _triples;
            HomeRuns = _hr;
            SacrificeFlies = _sf;
            SacrificeBunts = _sac;
            RBI = _rbi;
            HitByPitch = _hbp;
            StolenBases = _sb;
            CaughtStealing = _cs;
            Runs = _runs;
            Walks = _bb;
            Strikeouts = _k;
            Groundouts = _go;
            Flyouts = _ao;
            Poputs = _po;
            PA = _pa;
            DoublePlay = _gidp;
            TGP = _tgp;
        }
    }
}