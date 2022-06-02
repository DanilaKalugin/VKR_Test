using System;
using System.Collections.Generic;
using System.Linq;

namespace VKR.EF.Entities
{
    public class Match
    {
        public int MatchID { get; set; }
        public Team HomeTeam { get; set; }
        public string HomeTeamAbbreviation { get; set; }
        public Team AwayTeam { get; set; }
        public string AwayTeamAbbreviation { get; set; }
        public Stadium Stadium { get; set; }
        public ushort StadiumId { get; set; }
        public bool DHRule { get; set; }
        public DateTime MatchDate { get; set; }
        public byte MatchLength { get; set; }
        public bool MatchEnded { get; set; }
        public bool IsQuickMatch { get; set; }
    }
}