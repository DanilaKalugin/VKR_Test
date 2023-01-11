using System.Collections.Generic;

namespace VKR.EF.Entities.Tables
{
    public class Season
    {
        public int Year { get; set; }
        public virtual List<Match> Matches { get; set; } = new();
        public virtual List<MatchFromSchedule> NextMatches { get; set; } = new();
        public virtual List<LeagueSeason> LeagueSeasons { get; set; } = new();
    }
}