using System.Collections.Generic;
using System.Linq;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class CitiesEFDAO
    {
        public List<City> GetAllCities()
        {
            using var db = new VKRApplicationContext();
            return db.Cities.ToList();
        }

        public void AddCity(City city)
        {
            using var db = new VKRApplicationContext();

            var newCity = new City
            {
                Name = city.Name,
                RegionCode = city.Region.RegionCode
            };

            db.Cities.Add(newCity);
            db.SaveChanges();
        }

        public List<Region> GetAllRegions()
        {
            using var db = new VKRApplicationContext();
            return db.Regions.ToList();
        }
    }
}