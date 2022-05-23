using System;

namespace Entities.NET5
{
    public class Batter : Player
    {
        public string PositionForThisMatch;
        public int NumberInBattingLineup;

        /// <summary>
        /// Batter In lineup
        /// </summary>
        public Batter(int id, string firstName, string secondName, int number, string placeOfBirth, DateTime dateOfBirth, string batting, string pitching, string team, bool inActiveRoster, string position, int numberInLineup, BattingStats battingStats, PitchingStats pitchingStats) 
            : base(id, firstName, secondName, number, placeOfBirth, dateOfBirth, batting, pitching, team, inActiveRoster, battingStats, pitchingStats) 
        {
            
            PositionForThisMatch = position;
            NumberInBattingLineup = numberInLineup;
        }
    }
}