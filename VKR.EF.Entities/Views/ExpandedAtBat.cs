using System;
using System.Collections.Generic;

#nullable disable

namespace VKR.EF.Entities
{
    public partial class ExpandedAtBat
    {
        public int AtBatId { get; set; }
        public int Match { get; set; }
        public string Offense { get; set; }
        public int Batter { get; set; }
        public int AtBatResult { get; set; }
        public string Defense { get; set; }
        public int Pitcher { get; set; }
        public int Outs { get; set; }
        public int Rbi { get; set; }
        public int Inning { get; set; }
    }
}
