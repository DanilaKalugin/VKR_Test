using System;

namespace VKR.EF.Entities.Views
{
    public class BattingStats : StatGroupedBySeasonAndMatchType
    {
        public int Games { get; set; }
        public int SacrificeFlies { get; set; }
        public int SacrificeBunts { get; set; }
        public int RBI { get; set; }
        public int HitByPitch { get; set; }
        public int StolenBases { get; set; }
        public int CaughtStealing { get; set; }
        public int Runs { get; set; }
        public int Groundouts { get; set; }
        public int Flyouts { get; set; }
        public int Popouts { get; set; }
        public int Strikeouts { get; set; }
        public int Walks { get; set; }
        public int Singles { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
        public int HomeRuns { get; set; }
        public int PA { get; set; }
        public int DoublePlay { get; set; }
        public int TGP { get; set; }

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

        public double ABperHR => HomeRuns == 0 ? 0 : (double)AtBats / HomeRuns;

        public double WalkToStrikeout => Strikeouts == 0 ? 0 : (double)Walks / Strikeouts;

        public double GOtoAO => Flyouts == 0 ? 0 : (double)Groundouts / Flyouts;

        public double WalkPercentage => PA == 0 ? 0 :(double)Walks / PA;

        public double StrikeoutPercentage => PA == 0 ? 0 : (double)Strikeouts / PA;

        public double ExpectedHomeRuns => TGP > 0 ? (double)HomeRuns / TGP * 162 : 0;
    }
}