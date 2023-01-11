using System.Collections.Generic;
using VKR.EF.Entities.Enums;

namespace VKR.EF.Entities.Tables
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