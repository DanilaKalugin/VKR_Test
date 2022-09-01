using System.Collections.Generic;
using System.Linq;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class CitiesBL
    {
        private readonly CitiesEFDAO _citiesEfdao = new();

        public List<City> GetAllCities() => _citiesEfdao.GetAllCities().OrderBy(city => city.Name).ThenBy(city => city.RegionCode).ToList();

        public void AddCity(City city) => _citiesEfdao.AddCity(city);

        public List<Region> GetAllRegions() => _citiesEfdao.GetAllRegions();
    }
}