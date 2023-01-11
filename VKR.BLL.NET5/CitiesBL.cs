using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities.Tables;

namespace VKR.BLL.NET5
{
    public class CitiesBL
    {
        private readonly CitiesEFDAO _citiesEfdao = new();

        public async Task<List<City>> GetAllCitiesAsync()
        {
            var cities = await _citiesEfdao.GetAllCitiesAsync()
                .ConfigureAwait(false);

            return cities.OrderBy(city => city.Name)
                .ThenBy(city => city.RegionCode)
                .ToList();
        }

        public async Task AddCityAsync(City city) => await _citiesEfdao.AddCityAsync(city)
            .ConfigureAwait(false);

        public async Task<List<Region>> GetAllRegions()
        {
            return await _citiesEfdao.GetAllRegionsAsync()
                .ConfigureAwait(false);
        }
    }
}