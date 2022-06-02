using System.Collections.Generic;

namespace VKR.EF.Entities
{
    public class Stadium
    {
        public ushort StadiumId { get; set; }
        public string StadiumTitle { get; set; }
        public uint StadiumCapacity { get; set; }
        public ushort StadiumDistanceToCenterfield { get; set; }
        public City StadiumCity { get; set; }
        public ushort StadiumLocation { get; set; }
        public virtual List<Team> Teams { get; set; } = new();
        public virtual List<Match> MatchesPlayedInThisStadium { get; set; } = new();
    }
}