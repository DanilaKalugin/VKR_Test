using System;
using System.Collections.Generic;

namespace Entities.NET5
{
    public class Player : ManInTeam
    {
        public int PlayerNumber;
        public List<string> PlayerPositions;
        public string BattingHand;
        public string PitchingHand;
        public bool InActiveRoster;

        public BattingStats BattingStats;
        public PitchingStats PitchingStats;

        public Player(int id, string firstName, string secondName, int number, string placeOfBirth, DateTime dateOfBirth, string battingHand, string pitchingHand, string team, bool inActiveRoster, BattingStats batting, PitchingStats pitching) : base(id, firstName, secondName, team, dateOfBirth, placeOfBirth)
        {
            PlayerNumber = number;
            BattingHand = battingHand;
            PitchingHand = pitchingHand;
            InActiveRoster = inActiveRoster;
            BattingStats = batting;
            PitchingStats = pitching;
        }

        public Player() { }
    }
}