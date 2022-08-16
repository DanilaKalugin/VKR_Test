﻿using System.Collections.Generic;
using System.Linq;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class SeasonDAO
    {
        public List<Season> GetAllSeasons()
        {
            using var db = new VKRApplicationContext();
            return db.Seasons.ToList();
        }

        public LeagueSeason GetSeasonInfo(int year, TypeOfMatchEnum matchType = TypeOfMatchEnum.RegularSeason)
        {
            using var db = new VKRApplicationContext();
            return db.LeagueSeasons.FirstOrDefault(ls => ls.MatchTypeId == matchType && ls.SeasonId == year);
        }
    }
}
