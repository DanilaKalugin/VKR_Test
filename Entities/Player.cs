using System;
using System.Collections.Generic;

namespace Entities
{
    public class Player : ManInTeam
    {
        public int PlayerNumber;
        public List<string> PlayerPositions;
        public string BattingHand;
        public string PitchingHand;
        public bool InActiveRoster;

        public BattingStats battingStats;
        public PitchingStats pitchingStats;

        public Player(int id, string firstName, string secondName, int number, string placeOfBirth, DateTime dateOfBirth, string battingHand, string pitchingHand, string team, bool inActiveRoster, BattingStats batting, PitchingStats pitching) : base(id, firstName, secondName, team, dateOfBirth, placeOfBirth)
        {
            PlayerNumber = number;
            BattingHand = battingHand;
            PitchingHand = pitchingHand;
            InActiveRoster = inActiveRoster;
            battingStats = batting;
            pitchingStats = pitching;
        }

        public Player() : base()
        {
        }
    }
}