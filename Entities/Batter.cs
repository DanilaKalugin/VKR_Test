using System;

namespace Entities
{
    public class Batter : Player
    {
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
        public string PositionForThisMatch;
        public int NumberInBattingLineup;
        public int PA;
        public int DoublePlay;
        public int TGP;

        public int Hits { get { return Singles + Doubles + Triples + HomeRuns; } }

        public int AtBats { get { return Singles + Doubles + Triples + HomeRuns + Groundouts + Flyouts + Poputs + Strikeouts; } }

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

        public int TotalBases { get { return 4 * HomeRuns + 3 * Triples + 2 * Doubles + Singles; } }

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

        public int XBH
        {
            get
            {
                return Hits - Singles;
            }
        }

        public double OPS { get { return OBP + SLG; } }

        public double ISO { get { return SLG - AVG; } }

        public double ABperHR
        {
            get
            {
                return (double)AtBats / HomeRuns;
            }
        }

        public double WalkToStrikeout
        {
            get
            {
                return (double)Walks / Strikeouts;
            }
        }

        public double GOtoAO
        {
            get
            {
                return (double)Groundouts / Flyouts;
            }
        }

        public double WalkPercentage
        {
            get
            {
                return (double)Walks / PA;
            }
        }

        public double StrikeoutPercentage
        {
            get
            {
                return (double)Strikeouts / PA;
            }
        }


        public Batter(int _id, string _FirstName, string _secondName, int _Number, int _games,
                      int _singles, int _doubles, int _triples, int _hr, int _sf, int _sac,
                      int _rbi, int _hbp, int _sb, int _cs, int _runs, int _bb, int _k, int _go,
                      int _ao, int _po, int _pa, int _gidp, int _tgp, string _b, string _t, string team)
        {
            id = _id;
            FirstName = _FirstName;
            SecondName = _secondName;
            PlayerNumber = _Number;
            Games = _games;
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
            Team = team;
            BattingHand = _b;
            Pitchinghand = _t;
        }

        public Batter(int _id, string _firstName, string _secondName, int _Number, int _games, int _singles, int _doubles,
                              int _triples, int _hr, int _sf, int _sac, int _rbi, int _hbp, int _sb,
                              int _cs, int _runs, int _bb, string _position, int _numberInLineup,
                              int _k, int _go, int _ao, int _po, string _b, string _t)
        {
            id = _id;
            FirstName = _firstName;
            SecondName = _secondName;
            PlayerNumber = _Number;
            Games = _games;
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
            PositionForThisMatch = _position;
            NumberInBattingLineup = _numberInLineup;
            Strikeouts = _k;
            Groundouts = _go;
            Flyouts = _ao;
            Poputs = _po;
            BattingHand = _b;
            Pitchinghand = _t;
        }

        public Batter(string _FirstName, string _SecondName)
        {
            FirstName = _FirstName;
            SecondName = _SecondName;
        }
    }
}