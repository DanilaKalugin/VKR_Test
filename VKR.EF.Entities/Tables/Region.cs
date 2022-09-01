using System.Collections.Generic;

namespace VKR.EF.Entities
{
    public class Region
    {
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public Country Country { get; set; }
        public string CountryCode { get; set; }
        public virtual List<City> Cities { get; set; } = new();

        public override string ToString() => $"{RegionName}, {CountryCode}";
        public string RegionLocation => ToString();
    }
}
