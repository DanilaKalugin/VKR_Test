using System.Collections.Generic;

namespace VKR.EF.Entities
{
    public class BattingHand
    {
        public BattingHandEnum BattingHandId { get; set; }
        public string Description { get; set; }

        public virtual List<Player> Players { get; set; } = new();
    }
}
