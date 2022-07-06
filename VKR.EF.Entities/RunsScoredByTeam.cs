namespace VKR.EF.Entities
{
    public class RunsScoredByTeam
    {
        public string TeamAbbreviation { get; set; }
        public int MatchType { get; set; }
        public int Season { get; set; }
        public int RunsScored { get; set; }
    }
}