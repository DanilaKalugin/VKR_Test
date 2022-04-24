using System;

namespace Entities
{
    public class Pitcher : Player
    {
        public double RemainingStamina;
        public bool IsPinchHitter;
        public int NumberInRotation;

        public Pitcher(Player player)
        {
            Id = player.Id;
            FirstName = player.FirstName;
            SecondName = player.SecondName;
            PlayerNumber = player.PlayerNumber;
            PlaceOfBirth = player.PlaceOfBirth;
            DateOfBirth = player.DateOfBirth;
            battingStats = player.battingStats;
            pitchingStats = player.pitchingStats;
            BattingHand = player.BattingHand;
            PitchingHand = player.PitchingHand;
            Team = player.Team;
            InActiveRoster = player.InActiveRoster;
        }

        public Pitcher(int id, string firstName, string secondName, int number, string placeOfBirth, DateTime dateOfBirth, string batting, string pitching, string team, bool inActiveRoster, int numberInRotation, bool isPinchHitter, BattingStats battingStats, PitchingStats pitchingStats) 
            : base(id, firstName, secondName, number, placeOfBirth, dateOfBirth, batting, pitching, team, inActiveRoster, battingStats, pitchingStats)
        {
            NumberInRotation = numberInRotation;
            IsPinchHitter = isPinchHitter;
        }
    }
}