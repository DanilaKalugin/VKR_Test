using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.EF.Entities
{
    public class Region
    {
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public Country Country { get; set; }
        public string CountryCode { get; set; }
        public virtual List<City> Cities { get; set; } = new();

    }
}
