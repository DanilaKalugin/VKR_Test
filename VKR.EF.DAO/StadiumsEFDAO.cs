using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class StadiumsEFDAO
    {
        public async Task<List<Stadium>> GetAllStadiumsAsync()
        {
            await using var db = new VKRApplicationContext();
            return await db.Stadiums
                .Include(stadium => stadium.StadiumCity)
                .Include(s => s.StadiumFactor)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<Stadium> GetHomeStadiumForThisTeamAndTypeOfMatchAsync(string teamAbbreviation, TypeOfMatchEnum typeOfMatch)
        {
            await using var db = new VKRApplicationContext();
            return await db.TeamStadiumForTypeOfMatch
                .Where(tsmt => tsmt.TeamAbbreviation == teamAbbreviation && tsmt.TypeOfMatchId == typeOfMatch)
                .Include(tsmt => tsmt.Stadium)
                .ThenInclude(stadium => stadium.StadiumFactor)
                .Include(tsmt => tsmt.Stadium.StadiumCity)
                .Select(tsmt => tsmt.Stadium)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}