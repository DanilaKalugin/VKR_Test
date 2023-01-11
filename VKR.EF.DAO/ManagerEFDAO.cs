using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.DAO.Contexts;
using VKR.EF.Entities.Tables;

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

        public async Task<uint> GetIdForNewManager()
        {
            await using var db = new VKRApplicationContext();

            var maxId = await db.Managers.MaxAsync(p => p.Id)
                .ConfigureAwait(false);
            return maxId + 1;
        }

        public async Task AddManager(Manager manager)
        {
            await using var db = new VKRApplicationContext();

            await db.Managers.AddAsync(manager)
                .ConfigureAwait(false);

            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}