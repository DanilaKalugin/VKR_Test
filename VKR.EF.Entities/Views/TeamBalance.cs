namespace VKR.EF.Entities
{
    public class TeamBalance
    {
        public string TeamAbbreviation { get; set; }
        public int Season { get; set; }
        public TypeOfMatchEnum MatchType { get; set; }
        public int HomeWins { get; set; }
        public int HomeLosses { get; set; }
        public int AwayWins { get; set; }
        public int AwayLosses { get; set; }

        public int W => HomeWins + AwayWins;
        public int L => HomeLosses + AwayLosses;
    }
}