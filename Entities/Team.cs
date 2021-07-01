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
        public bool DHRule;
        public int StrikeZoneProbabilty;
        public int SwingInStrikeZoneProbability;
        public int SwingOutsideStrikeZoneProbability;
        public int HittingProbability;
        public int FoulProbability;
        public int SingleProbability;
        public int DoubleProbability;
        public int HomeRunProbabilty;
        public int PopoutOnFoulProbability;
        public int FlyoutOnHomeRunProbability;
        public int GroundoutProbability;
        public int FlyoutProbability;
        public int DoublePlayProbabilty;
        public int SacrificeFlyProbability;
        public int StealingBaseProbability;
        public int SuccessfulBuntAttemptProbabilty;
        public int NormalizedOffensiveRating;
        public int NormalizedDefensiveRating;
        public int Stadium;
        public Manager TeamManager;
        public string League;

        public List<Pitcher> PitchersPlayedInMatch;
        public Pitcher CurrentPitcher { get { return PitchersPlayedInMatch.Last(); } }
        public List<Batter> BattingLineup;

        public int Wins;
        public int Losses;
        public double GamesBehind;
        public int RunsScored;
        public int RunsAllowed;
        public int RunDifferential { get { return RunsScored - RunsAllowed; } }

        public string Division;

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

        public int OverallRating { get { return (NormalizedDefensiveRating + NormalizedOffensiveRating) / 2; } }

        public double DefensiveRating()
        {
            double PitchingComponent = (double)(470 - StrikeZoneProbabilty) / 12;
            double GroundoutComponent = (double)(GroundoutProbability * 1.1) / 20;
            double OutfieldComponent = (double)(FlyoutProbability - GroundoutProbability) / 20;
            double DoublePlayComponent = (double)DoublePlayProbabilty / 3;
            int PitcherNumber = (Wins + Losses + 1) % 5 == 0 ? 1 : 6 - (Wins + Losses + 1) % 5;
            double PitcherNumberComponent = (double)PitcherNumber / 2;
            return Math.Round(PitchingComponent + GroundoutComponent + OutfieldComponent + DoublePlayComponent + PitcherNumberComponent, 2);
        }

        public double OffensiveRating()
        {
            double DoubleComponent = (double)(DoubleProbability - SingleProbability) / 6;
            double HomeRunComponent = (double)(HomeRunProbabilty - DoubleProbability) / 2;
            double TripleComponent = (2000 - HomeRunProbabilty) / 2.5;
            double SingleComponent = (double)(SingleProbability - FoulProbability) / 30;
            double BaseStealingComponent = (double)StealingBaseProbability / 5;
            double HittingComponent = (double)HittingProbability / 25;
            return Math.Round(SingleComponent + DoubleComponent + HomeRunComponent + TripleComponent + BaseStealingComponent + HittingComponent, 2);
        }

        //Batting stats
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

        //Pitching stats
        public int Outs;
        public int WalksAllowed;
        public int StolenBasesAllowed;
        public int TotalBattersFaced;
        public int QualityStarts;
        public int Shutouts;
        public int CompleteGames;
        public int Saves;
        public int Holds;

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

        public double KperNineInnings
        {
            get
            {
                return (double)Strikeouts / (Outs / 3) * 9;
            }
        }

        public double BBperNineInnings
        {
            get
            {
                return 9 * (double)WalksAllowed / (Outs / 3) * 9;
            }
        }

        public double KperBB
        {
            get
            {
                return (double)Strikeouts / WalksAllowed;
            }
        }

        public Team(string abbreviation, string city, string name, int _StrikeZoneProbability, int _Swing_SZ_Probability, int _Swing_NotSZ_Probability,
                    int _Hit_Probability, int _Foul_Probability, int _Single_Probability, int _Double_Probability, int _HR_Probability,
                    int _PopoutOnFoul_Probability, int _FlyoutOnHR_Probability, int _Groundout_Probability, int _Flyout_Probability, int _sacFly_Probability,
                    int _DoublePlayProbability, int _SuccessfulBaseSteling_Probability, int _SuccessfulBunt_Probability, int _Stadium, bool _DHRule, int w, int l)
        {
            TeamAbbreviation = abbreviation;
            TeamCity = city;
            TeamTitle = name;
            StrikeZoneProbabilty = _StrikeZoneProbability;
            SwingInStrikeZoneProbability = _Swing_SZ_Probability;
            SwingOutsideStrikeZoneProbability = _Swing_NotSZ_Probability;
            HittingProbability = _Hit_Probability;
            FoulProbability = _Foul_Probability;
            SingleProbability = _Single_Probability;
            DoubleProbability = _Double_Probability;
            HomeRunProbabilty = _HR_Probability;
            PopoutOnFoulProbability = _PopoutOnFoul_Probability;
            FlyoutOnHomeRunProbability = _FlyoutOnHR_Probability;
            GroundoutProbability = _Groundout_Probability;
            FlyoutProbability = _Flyout_Probability;
            DoublePlayProbabilty = _DoublePlayProbability;
            SacrificeFlyProbability = _sacFly_Probability;
            StealingBaseProbability = _SuccessfulBaseSteling_Probability;
            SuccessfulBuntAttemptProbabilty = _SuccessfulBunt_Probability;
            Stadium = _Stadium;
            PitchersPlayedInMatch = new List<Pitcher>();
            DHRule = _DHRule;
            Wins = w;
            Losses = l;
        }

        public Team(string abbreviation, string name, int _games,
                      int _singles, int _doubles, int _triples, int _hr, int _sf, int _sac,
                      int _rbi, int _hbp, int _sb, int _cs, int _runs, int _bb, int _k, int _go,
                      int _ao, int _po, int _pa, int _gidp)
        {
            TeamAbbreviation = abbreviation;
            TeamTitle = name;
            TGP = _games;
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
        }

        public Team(string abbreviation, string name, int _games,
                       int _k, int _outs, int _bb, int _sac, int _sf, int _sb, int _cs, int _tbf,
                       int _qs, int _sho, int _cg, int _w, int _l, int _sv, int _hld, int _hbp,
                       int _singles, int _doubles, int _triples, int _hr, int _runs, int _DoublePlays,
                       int _go, int _ao)
        {
            TeamAbbreviation = abbreviation;
            TeamTitle = name;
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
            DoublePlays = _DoublePlays;
            TGP = _games;
            Groundouts = _go;
            Flyouts = _ao;
        }
        public Team (string abbreviation, string Name, int _W, int _L, string _League, string _Division)
        {
            TeamAbbreviation = abbreviation;
            TeamTitle = Name;
            League = _League;
            Wins = _W;
            Losses = _L;
            Division = _Division;
        }


    }
}