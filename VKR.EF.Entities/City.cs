using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.EF.Entities
{
    public class City
    {
        public ushort Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public string CountryCode { get; set; }
        
    }
}
