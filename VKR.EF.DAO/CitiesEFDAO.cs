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

            var newCity = new City
            {
                Name = city.Name,
                RegionCode = city.Region.RegionCode
            };

            await db.Cities.AddAsync(newCity);
            await db.SaveChangesAsync();
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