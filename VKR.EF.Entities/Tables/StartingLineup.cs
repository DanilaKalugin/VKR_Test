namespace VKR.EF.Entities
{
    public class StartingLineup
    {
        public PlayerInTeam PlayerInTeam { get; set; }
        public uint PlayerInTeamId { get; set; }
        public LineupType Type { get; set; }
        public byte LineupTypeId { get; set; }
        public byte PlayerNumberInLineup { get; set; }
        public PlayerPosition PlayerPosition { get; set; }
        public string PlayerPositionId { get; set; }
    }
}