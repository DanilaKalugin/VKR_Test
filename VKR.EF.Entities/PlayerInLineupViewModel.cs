using System;
using System.Text;

namespace VKR.EF.Entities
{
    public class PlayerInLineupViewModel : Player
    {
        public string TeamAbbreviation { get; set; }
        public string PositionInLineup { get; set; }
        public byte LineupNumber { get; set; }
        public byte NumberInLineup { get; set; }

        public PlayerInLineupViewModel(Player player, byte lineupNumber, byte numberInLineup, string team, string positionInLineup)
        {
            Id = player.Id;
            FirstName = player.FirstName;
            SecondName = player.SecondName;
            DateOfBirth = player.DateOfBirth;
            City = player.City;
            PlayerNumber = player.PlayerNumber;
            BattingHand = player.BattingHand;
            PitchingHand = player.PitchingHand;
            Positions = player.Positions;
            PlayerStatus = player.PlayerStatus;
            TeamAbbreviation = team;
            PositionInLineup = positionInLineup;
            LineupNumber = lineupNumber;
            NumberInLineup = numberInLineup;
        }
    }
}