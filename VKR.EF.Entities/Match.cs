using System;
using System.Collections.Generic;
using System.Linq;

namespace VKR.EF.Entities
{
    public class Match: MatchBaseClass
    {
        public bool DHRule { get; set; }
        public byte MatchLength { get; set; }
        public bool MatchEnded { get; set; }
        public Stadium Stadium { get; set; }
        public ushort StadiumId { get; set; }
        public virtual List<LineupForMatch> LineupsForMatches { get; set; } = new();
        public virtual List<AtBat> AtBats { get; set; } = new();
        public virtual List<PitcherResults> PitcherResults { get; set; } = new();
    }
}