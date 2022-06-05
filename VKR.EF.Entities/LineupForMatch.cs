using System.ComponentModel.DataAnnotations.Schema;

namespace VKR.EF.Entities
{
    public class LineupForMatch
    {
        public uint Id { get; set; }
        public Match Match { get; set; }
        public int MatchId { get; set; }
        public PlayerInTeam PlayerInTeam { get; set; }
        public uint PlayerInTeamId { get; set; }
        public byte PlayerNumberInLineup { get; set; }
        public PlayerPosition PlayerPosition { get; set; }
        public string PlayerPositionId { get; set; }
    }
}