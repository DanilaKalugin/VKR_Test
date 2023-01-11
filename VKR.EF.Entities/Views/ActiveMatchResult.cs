namespace VKR.EF.Entities.Views
{
    public class ActiveMatchResult
    {
        public int MatchId { get; set; }
        public int AwayTeamRuns { get; set; }
        public int HomeTeamRuns { get; set; }
        public byte Inning { get; set; }
    }
}