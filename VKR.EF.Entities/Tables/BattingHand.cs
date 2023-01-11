using System.Collections.Generic;
using VKR.EF.Entities.Enums;

namespace VKR.EF.Entities.Tables
{
    public class BattingHand
    {
        public BattingHandEnum BattingHandId { get; set; }
        public string Description { get; set; }

        public virtual List<Player> Players { get; set; } = new();
    }
}