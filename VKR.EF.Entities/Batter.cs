namespace VKR.EF.Entities
{
    public class Batter: Player
    {
        public string PositionForThisMatch;
        public byte NumberInLineup;
        public uint BatterId;

        public new Batter SetBattingStats(PlayerBattingStats battingStats)
        {
            BattingStats = battingStats;
            return this;
        }

        public Batter(Player player, string positionForThisMatch, byte numberInLineup, uint batterId)
        {
            Id = player.Id;
            FirstName = player.FirstName;
            SecondName = player.SecondName;
            PlayerNumber = player.PlayerNumber;
            PlayerBattingHand = player.PlayerBattingHand;
            PlayerPitchingHand = player.PlayerPitchingHand;
            NumberInLineup = numberInLineup;
            PositionForThisMatch = positionForThisMatch;
            BatterId = batterId;
        }
    }
}