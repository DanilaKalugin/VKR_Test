using System.Collections.Generic;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class SeasonBL
    {
        private readonly SeasonDAO _seasonDao = new ();

        public List<Season> GetAllSeasons() => _seasonDao.GetAllSeasons();

        public LeagueSeason GetLeagueSeasonInfo(int year, TypeOfMatchEnum matchType = TypeOfMatchEnum.RegularSeason) =>
            _seasonDao.GetSeasonInfo(year, matchType);
    }
}