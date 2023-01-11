namespace VKR.EF.Entities.Views
{
    public class TeamBalance :StatGroupedBySeasonAndMatchType
    {
        public string TeamAbbreviation { get; set; }
        public int HomeWins { get; set; }
        public int HomeLosses { get; set; }
        public int AwayWins { get; set; }
        public int AwayLosses { get; set; }

        public int W => HomeWins + AwayWins;
        public int L => HomeLosses + AwayLosses;
    }
}