using System.Collections.Generic;

namespace VKR.EF.Entities
{
    public class TypeOfMatch
    {
        public TypeOfMatchEnum Id { get; set; }
        public string Description { get; set; }
        public virtual List<TeamStadiumForTypeOfMatch> TeamStadiumsForMatchTypes { get; set; } = new();
        public virtual List<Match> MatchesOfThisType { get; set; } = new();
        public virtual List<MatchFromSchedule> NextMatchesOfThisType { get; set; } = new();
    }
}