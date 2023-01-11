using VKR.EF.Entities.Enums;

namespace VKR.EF.Entities.Tables
{
    public class PitcherResults
    {
        public PlayerInTeam Pitcher { get; set; }
        public uint PitcherId { get; set; }
        public Match Match { get; set; }
        public int MatchId { get; set; }
        public bool IsQualityStart { get; set; }
        public bool IsCompleteGame { get; set; }
        public bool IsShutout { get; set; }
        public PitcherResultsType MatchResult { get; set; }
        public PitcherResultEnum MatchResultId { get; set; }
    }
}