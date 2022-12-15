using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.DAO.Contexts;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class ManEFDAO
    {
        public async Task<List<ManInTeam>> GetListOfPeopleWithBirthdayTodayAsync()
        {
            await using var db = new PlayerBirthdayContext();
            return await db.ManInTeam.ToListAsync()
                .ConfigureAwait(false);
        }
    }
}