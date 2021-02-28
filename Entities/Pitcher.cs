﻿using System;

namespace Entities
{
    public class Pitcher : Player
    {
        public enum PitcherResult { QualityStart = 5, CompleteGame = 6, Shutout = 7 }

        public string ThrowingHand;
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
        public int NumberInRotation;

        public int SinglesAllowed;
        public int DoublesAllowed;
        public int TriplesAllowed;
        public int HomeRunsAllowed;
        public int DoublePlays;

        public int HitsAllowed { get { return SinglesAllowed + DoublesAllowed + TriplesAllowed + HomeRunsAllowed; } }

        public double IP { get { return Math.Round(Outs / 3 + (double)(Outs % 3) / 10, 1); } }

        public double WHIP
        {
            get
            {
                if (IP == 0)
                {
                    return 0;
                }
                else return Math.Round((WalksAllowed + HitsAllowed) / ((double)Outs / 3), 2);
            }
        }

        public double BAA
        {
            get
            {
                if (TotalBattersFaced - WalksAllowed - HitByPitch - SacrificeFlies - SacrificeBunts == 0)
                {
                    return 0;
                }
                else return Math.Round((double)HitsAllowed / (TotalBattersFaced - WalksAllowed - HitByPitch - SacrificeFlies - SacrificeBunts), 3);
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
                else
                {
                    return Math.Round(RunsAllowed / ((double)Outs / 3) * 9, 2);
                }
            }
        }

        public Pitcher(int _id, string _firstName, string _secondName, int _Number, int _games, 
                       int _k, int _outs, int _bb, int _sac, int _sf, int _sb, int _cs, int _tbf, 
                       int _qs, int _sho, int _cg, int _w, int _l, int _sv, int _hld, int _hbp,
                       int _singles, int _doubles, int _triples, int _hr, int _runs, int _NumberInRotation, bool IsStatistics)
        {
            id = _id;
            FirstName = _firstName;
            SecondName = _secondName;
            PlayerNumber = _Number;
            Games = _games;
            Strikeouts = _k;
            Outs = _outs;
            WalksAllowed = _bb;
            SacrificeBunts = _sac;
            SacrificeFlies = _sf;
            StolenBasesAllowed = _sb;
            CaughtStealing = _cs;
            TotalBattersFaced = _tbf;
            QualityStarts = _qs;
            Shutouts = _sho;
            CompleteGames = _cg;
            Wins = _w;
            Losses = _l;
            Saves = _sv;
            Holds = _hld;
            HitByPitch = _hbp;
            SinglesAllowed = _singles;
            DoublesAllowed = _doubles;
            TriplesAllowed = _triples;
            HomeRunsAllowed = _hr;
            RunsAllowed = _runs;
            if (IsStatistics)
            {
                DoublePlays = _NumberInRotation;
            }
            else
            {
                NumberInRotation = _NumberInRotation;
            }
        }

        public Pitcher(int _id, string _firstName, string _secondName, int _Number, int _games,
                       int _k, int _outs, int _bb, int _sac, int _sf, int _sb, int _cs, int _tbf,
                       int _qs, int _sho, int _cg, int _w, int _l, int _sv, int _hld, int _hbp,
                       int _singles, int _doubles, int _triples, int _hr, int _runs)
        {
            id = _id;
            FirstName = _firstName;
            SecondName = _secondName;
            PlayerNumber = _Number;
            Games = _games;
            Strikeouts = _k;
            Outs = _outs;
            WalksAllowed = _bb;
            SacrificeBunts = _sac;
            SacrificeFlies = _sf;
            StolenBasesAllowed = _sb;
            CaughtStealing = _cs;
            TotalBattersFaced = _tbf;
            QualityStarts = _qs;
            Shutouts = _sho;
            CompleteGames = _cg;
            Wins = _w;
            Losses = _l;
            Saves = _sv;
            Holds = _hld;
            HitByPitch = _hbp;
            SinglesAllowed = _singles;
            DoublesAllowed = _doubles;
            TriplesAllowed = _triples;
            HomeRunsAllowed = _hr;
            RunsAllowed = _runs;
        }
    }
}