using System;

namespace VKR.EF.Entities
{
    public class LeagueSeason
    {
        public Season Season { get; set; }
        public int SeasonId { get; set; }
        public TypeOfMatch MatchType { get; set; }
        public TypeOfMatchEnum MatchTypeId { get; set; }
        public DateTime SeasonStart { get; set; }
        public DateTime SeasonEnd { get; set; }
    }
}