using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VKR.EF.Entities
{
    public class Stadium
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ushort StadiumId { get; set; }
        public string StadiumTitle { get; set; }
        public uint StadiumCapacity { get; set; }
        public ushort StadiumDistanceToCenterfield { get; set; }
        public City StadiumCity { get; set; }
        public short StadiumLocation { get; set; }
        public virtual List<Match> MatchesPlayedInThisStadium { get; set; } = new();
        public virtual List<TeamStadiumForTypeOfMatch> StadiumsForMatchTypes { get; set; } = new();
    }
}