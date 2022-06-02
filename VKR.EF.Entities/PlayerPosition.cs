using System.Collections.Generic;

namespace VKR.EF.Entities
{
    public class PlayerPosition
    {
        public string ShortTitle { get; set; }
        public string FullTitle { get; set; }
        public byte Number { get; set; }
        public virtual List<Player> Players { get; set; } = new();

        public PlayerPosition(string shortTitle, string fullTitle)
        {
            ShortTitle = shortTitle;
            FullTitle = fullTitle;
        }
    }
}