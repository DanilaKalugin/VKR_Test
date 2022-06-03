using System.Collections.Generic;

namespace VKR.EF.Entities
{
    public class PlayerPosition
    {
        public string ShortTitle { get; set; }
        public string FullTitle { get; set; }
        public byte Number { get; set; }
        public virtual List<Player> Players { get; set; } = new();
        public virtual List<StartingLineup> PlayerPositionsInStartingLineups { get; set; } = new();
        public virtual List<LineupForMatch> PlayerPositionsInLineup { get; set; } = new();

        public PlayerPosition(string shortTitle, string fullTitle)
        {
            ShortTitle = shortTitle;
            FullTitle = fullTitle;
        }
    }
}