using System.Collections.Generic;

namespace Entities
{
    public class Player: Man
    {
        public string Team;
        public int PlayerNumber;
        public List<string> PlayerPositions;
        public int Games;
        public string BattingHand;
        public string Pitchinghand;
        public bool InActiveRoster;
    }
}