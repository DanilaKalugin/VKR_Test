using System.Collections.Generic;

namespace VKR.EF.Entities
{
    public class League
    {
        public string LeagueId { get; set; }
        public string LeagueTitle { get; set; }
        public bool DHRule { get; set; }
        public ushort YearOfFoundation { get; set; }
        public virtual List<Division> Divisions { get; set; } = new();
    }
}