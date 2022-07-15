namespace VKR.EF.Entities
{
    public class MatchResult
    {
        public Match Match { get; set; }
        public int MatchId { get; set; }
        public int AwayTeamRuns { get; set; }
        public int HomeTeamRuns { get; set; }
        public Team MatchWinner { get; set; }
        public string MatchWinnerId { get; set; }
        public Team MatchLoser { get; set; }
        public string MatchLoserId { get; set; }
        public byte Length { get; set; }
    }
}