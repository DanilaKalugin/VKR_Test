using System.Collections.Generic;

namespace VKR.EF.Entities
{
    public class Division
    {
        public int Id { get; set; }
        public string DivisionTitle { get; set; }
        public League League { get; set; }
        public string LeagueId { get; set; }
        public virtual List<Team> Teams { get; set; } = new();
    }
}
