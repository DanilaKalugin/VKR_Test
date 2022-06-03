namespace VKR.EF.Entities
{
    public class AtBat
    {
        public ulong Id { get; set; }
        public Match Match { get; set; }
        public int MatchId { get; set; }
        public PlayerInTeam Batter { get; set; }
        public uint BatterId { get; set; }
        public AtBatResult AtBatResult { get; set; }
        public AtBatType AtBatType { get; set; }
        public PlayerInTeam Pitcher { get; set; }
        public uint PitcherId { get; set; }
        public byte Outs { get; set; }
        public byte RBI { get; set; }
        public byte Inning { get; set; }
    }
}