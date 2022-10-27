using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class ManagerEFDAO
    {
        public async Task<List<Manager>> GetAllManagersAsync()
        {
            await using var db = new VKRApplicationContext();
            return await db.Managers
                .Include(m => m.City)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}