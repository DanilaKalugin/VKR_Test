using VKR.EF.Entities.Tables;
using VKR.EF.Entities.Views;

namespace VKR.EF.Entities.ViewModels
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