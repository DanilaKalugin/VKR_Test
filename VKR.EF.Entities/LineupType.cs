using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.EF.Entities
{
    public class LineupType
    {
        public byte Id { get; set; }
        public string Description { get; set; }
        public PitchingHand? PitcherHand { get; set; }
        public PitchingHandEnum? PitcherHandId { get; set; }
        public bool? DesignatedHitterRule { get; set; }
    }
}