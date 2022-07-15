using System.Collections.Generic;

namespace VKR.EF.Entities
{
    public class LineupType
    {
        public byte Id { get; set; }
        public string Description { get; set; }
        public PitchingHand PitcherHand { get; set; }
        public PitchingHandEnum? PitcherHandId { get; set; }
        public bool? DesignatedHitterRule { get; set; }
        public virtual List<StartingLineup> StartingLineups { get; set; } = new();
    }
}