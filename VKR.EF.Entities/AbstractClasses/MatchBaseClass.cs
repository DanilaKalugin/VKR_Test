using System;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities
{
    public abstract class MatchBaseClass
    {
        public int Id { get; set; }
        public Team HomeTeam { get; set; }
        public string HomeTeamAbbreviation { get; set; }
        public Team AwayTeam { get; set; }
        public string AwayTeamAbbreviation { get; set; }
        public DateTime MatchDate { get; set; }
        public TypeOfMatch MatchType { get; set; }
        public TypeOfMatchEnum MatchTypeId { get; set; }
        public Season Season { get; set; }
        public int SeasonId { get; set; }
    }
}