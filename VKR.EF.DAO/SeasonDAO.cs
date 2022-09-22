using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class SeasonDAO
    {
        public async Task<LeagueSeason> GetSeasonInfo(int year, TypeOfMatchEnum matchType = TypeOfMatchEnum.RegularSeason)
        {
            await using var db = new VKRApplicationContext();
            return await db.LeagueSeasons.FirstOrDefaultAsync(ls => ls.MatchTypeId == matchType && ls.SeasonId == year)
                .ConfigureAwait(false);
        }

        public async Task<Season> GetCurrentSeason()
        {
            await using var db = new VKRApplicationContext();
            var seasonYear = await db.Matches
                .Where(match => match.MatchTypeId == TypeOfMatchEnum.RegularSeason)
                .MaxAsync(match => match.SeasonId)
                .ConfigureAwait(false);

            return await db.Seasons.FirstOrDefaultAsync(season => season.Year == seasonYear)
                .ConfigureAwait(false);
        }

        public async Task<List<Season>> GetAllSeasonsAsync()
        {
            await using var db = new VKRApplicationContext();
            return await db.Seasons.ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
