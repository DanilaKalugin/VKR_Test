﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.EF.Entities
{
    public class Country
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public virtual List<City> Cities { get; set; } = new();
    }
}