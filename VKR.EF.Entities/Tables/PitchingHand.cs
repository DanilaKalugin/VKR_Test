using System.Collections.Generic;

namespace VKR.EF.Entities
{
    public class PitchingHand
    {
        public PitchingHandEnum PitchingHandId { get; set; }
        public string Description { get; set; }

        public virtual List<Player> Players { get; set; } = new();
        public virtual List<LineupType> LineupTypes { get; set; } = new();
    }
}