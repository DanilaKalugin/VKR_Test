using System;

namespace VKR.Entities.NET5
{
    public class PlayerInLineup : Player
    {
        public int LineupType;
        public string Position;
        public int NumberInLineup;

        public PlayerInLineup(int id, string firstName, string secondName, DateTime dob, string placeOfBirth, int number, int lineupType, string team, int numberInLineup, string b, string t, BattingStats battingStats, PitchingStats pitchingStats) 
            : base (id, firstName, secondName, number, placeOfBirth, dob, b, t, team, true, battingStats, pitchingStats)
        {
            LineupType = lineupType;
            NumberInLineup = numberInLineup;
        }

        public PlayerInLineup(int id, string firstName, string secondName, DateTime dob, string placeOfBirth, int number, int lineupType, string team, string position, int numberInLineup, string b, string t, BattingStats battingStats, PitchingStats pitchingStats) 
            : this (id, firstName, secondName, dob, placeOfBirth, number, lineupType, team, numberInLineup, b, t, battingStats, pitchingStats)
        {
            Position = position;
        }
    }
}