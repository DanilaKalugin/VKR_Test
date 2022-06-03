using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.EF.Entities
{
    public class TeamStadiumForTypeOfMatch
    {
        public Team Team { get; set; }
        public string TeamAbbreviation { get; set; }
        public TypeOfMatch TypeOfMatch { get; set; }
        public TypeOfMatchEnum TyprOfMatchId { get; set; }
        public Stadium Stadium { get; set; }
        public ushort StadiumId { get; set; }
    }
}
