using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.DAO.Contexts;
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

        public async Task<ushort> GetIdForNewStadium()
        {
            await using var db = new VKRApplicationContext();
            var maxId = await db.Stadiums.MaxAsync(p => p.StadiumId)
                .ConfigureAwait(false);
            return (ushort)(maxId + 1);
        }

        public async Task AddNewStadium(Stadium stadium)
        {
            await using var db = new VKRApplicationContext();

            await db.Stadiums.AddAsync(stadium)
                .ConfigureAwait(false);

            var factorDb = new StadiumFactor
            {
                StadiumId = stadium.StadiumId
            };

            await db.StadiumFactors.AddAsync(factorDb)
                .ConfigureAwait(false);

            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task UpdateStadiumForThisTeamAndMatchType(TeamStadiumForTypeOfMatch tsmt)
        {
            await using var db = new VKRApplicationContext();

            var teamStadiumForMatchType = await db.TeamStadiumForTypeOfMatch.FirstOrDefaultAsync(t => t.TypeOfMatchId == tsmt.TypeOfMatchId 
                    && t.TeamAbbreviation == tsmt.TeamAbbreviation)
                .ConfigureAwait(false);

            if (teamStadiumForMatchType == null) return;

            teamStadiumForMatchType.StadiumId = tsmt.StadiumId;

            db.TeamStadiumForTypeOfMatch.Update(teamStadiumForMatchType);
            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}