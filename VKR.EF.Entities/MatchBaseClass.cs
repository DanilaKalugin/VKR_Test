﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VKR.EF.Entities
{
    public class MatchBaseClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Team HomeTeam { get; set; }
        public string HomeTeamAbbreviation { get; set; }
        public Team AwayTeam { get; set; }
        public string AwayTeamAbbreviation { get; set; }
        public DateTime MatchDate { get; set; }
        public TypeOfMatch MatchType { get; set; }
        public TypeOfMatchEnum MatchTypeId { get; set; }
    }
}