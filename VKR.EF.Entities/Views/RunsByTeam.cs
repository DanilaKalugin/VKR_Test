namespace VKR.EF.Entities.Views
{
    public class RunsByTeam: StatGroupedBySeasonAndMatchType
    {
        public string TeamAbbreviation { get; set; }
        public int RunsScored { get; set; }
        public int RunsAllowed { get; set; }
    }
}