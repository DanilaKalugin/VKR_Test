using System.Collections.Generic;
using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.Tables;

namespace VKR.BLL.NET5
{
    public class SeasonBL
    {
        private readonly SeasonDAO _seasonDao = new ();

        public async Task<List<Season>> GetAllSeasonsAsync() => await _seasonDao.GetAllSeasonsAsync()
            .ConfigureAwait(false);

        public async Task<LeagueSeason> GetLeagueSeasonInfo(int year, TypeOfMatchEnum matchType = TypeOfMatchEnum.RegularSeason) =>
            await _seasonDao.GetSeasonInfo(year, matchType)
                .ConfigureAwait(false);

        public async Task<Season> GetCurrentSeason() => await _seasonDao.GetCurrentSeason()
            .ConfigureAwait(false);
    }
}