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

            var managerDb = new Manager
            {
                Id = manager.Id,
                FirstName = manager.FirstName,
                SecondName = manager.SecondName,
                DateOfBirth = manager.DateOfBirth,
                PlaceOfBirth = manager.City.Id,
            };

            await db.Managers.AddAsync(managerDb)
                .ConfigureAwait(false);

            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}