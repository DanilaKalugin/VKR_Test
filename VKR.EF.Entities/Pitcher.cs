namespace VKR.EF.Entities
{
    public class Pitcher : Player
    {
        public int RemainingStamina;
        public int NumberInRotation;
        public uint PitcherId;
        public bool IsPinchHitter => !CanPlayAsPitcher;

        public new Pitcher SetPitchingStats(PlayerPitchingStats pitchingStats)
        {
            PitchingStats = pitchingStats;
            return this;
        }

        public Pitcher(Player player, int numberInRotation, uint pitcherId)
        {
            NumberInRotation = numberInRotation;
            Id = player.Id;
            FirstName = player.FirstName;
            SecondName = player.SecondName;
            PlayerNumber = player.PlayerNumber;
            PlayerBattingHand = player.PlayerBattingHand;
            PlayerPitchingHand = player.PlayerPitchingHand;
            Positions = player.Positions;
            PitcherId = pitcherId;
        }
    }
}