using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class CitiesEFDAO
    {
        public async Task<List<City>> GetAllCitiesAsync()
        {
            await using var db = new VKRApplicationContext();
            return await db.Cities
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task AddCityAsync(City city)
        {
            await using var db = new VKRApplicationContext();

            await db.Cities.AddAsync(city)
                .ConfigureAwait(false);

            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            await using var db = new VKRApplicationContext();
            return await db.Regions
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}