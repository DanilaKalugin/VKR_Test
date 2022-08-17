using System.Collections.Generic;

namespace VKR.EF.Entities
{
    public class Country
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public virtual List<Region> Regions { get; set; } = new();
    }
}
