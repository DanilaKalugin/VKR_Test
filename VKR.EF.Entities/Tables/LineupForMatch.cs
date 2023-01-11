namespace VKR.EF.Entities.Tables
{
    public class LineupForMatch
    {
        public long Id { get; set; }
        public Match Match { get; set; }
        public int MatchId { get; set; }
        public PlayerInTeam PlayerInTeam { get; set; }
        public uint PlayerInTeamId { get; set; }
        public byte PlayerNumberInLineup { get; set; }
        public PlayerPosition PlayerPosition { get; set; }
        public string PlayerPositionId { get; set; }
    }
}