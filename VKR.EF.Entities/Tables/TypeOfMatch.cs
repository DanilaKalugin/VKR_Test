using System.Collections.Generic;
using VKR.EF.Entities.Enums;

namespace VKR.EF.Entities.Tables
{
    public class TypeOfMatch
    {
        public TypeOfMatchEnum Id { get; set; }
        public string Description { get; set; }
        public virtual List<TeamStadiumForTypeOfMatch> TeamStadiumsForMatchTypes { get; set; } = new();
        public virtual List<Match> MatchesOfThisType { get; set; } = new();
        public virtual List<MatchFromSchedule> NextMatchesOfThisType { get; set; } = new();
        public virtual List<LeagueSeason> LeagueSeasons { get; set; } = new();
    }
}