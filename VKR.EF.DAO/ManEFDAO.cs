using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.DAO.Contexts;
using VKR.EF.DAO.Interfaces;
using VKR.EF.Entities.Views;

namespace VKR.EF.DAO
{
    public class ManEFDAO: IManDAO
    {
        public async Task<List<ManInTeam>> GetListOfPeopleWithBirthdayTodayAsync()
        {
            await using var db = new PlayerBirthdayContext();
            return await db.ManInTeam.ToListAsync()
                .ConfigureAwait(false);
        }
    }
}