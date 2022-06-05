﻿using System;
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
        public Region Region { get; set; }
        public string RegionCode { get; set; }
        public virtual List<Stadium> Stadiums { get; set; } = new();
        public virtual List<Manager> Managers { get; set; } = new();
        public virtual List<Player> Players { get; set; } = new();
    }
}
