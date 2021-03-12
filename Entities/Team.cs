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

        public List<Pitcher> PitchersRoster;
        public List<Batter> BattersRoster;
        public List<Pitcher> PitchersPlayedInMatch;
        public Pitcher CurrentPitcher { get { return PitchersPlayedInMatch.Last(); } }
        public List<Batter> BattingLineup;

        public int Wins;
        public int Losses;
        public double GamesBehind;

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
            double PitcherComponent = (double)(301 - StrikeZoneProbabilty) / 10 * 7 + 9;
            double OutfieldComponent = (double)FlyoutProbability / 20;
            return Math.Round(PitcherComponent + OutfieldComponent + DoublePlayProbabilty, 2);
        }

        public double OffensiveRating()
        {
            double DoubleComponent = (double)(DoubleProbability - SingleProbability - 102) / 6;
            double HomeRunComponent = (double)(HomeRunProbabilty - DoubleProbability - 3) / 2;
            double TripleComponent = (2000 - HomeRunProbabilty) / 2.5;
            double SingleComponent = (double)(SingleProbability - FoulProbability - 122) / 30;
            double BaseStealingComponent = (double)(StealingBaseProbability - 2) / 5;
            double HittingComponent = (double)(HittingProbability - 251) / 25;
            return Math.Round(SingleComponent + DoubleComponent + HomeRunComponent + TripleComponent + BaseStealingComponent + HittingComponent, 2);
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