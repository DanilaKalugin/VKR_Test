﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.EF.Entities
{
    public class PlayerInTeam
    {
        public uint Id { get; set; }
        public Player Player { get; set; }
        public uint PlayerId { get; set; }
        public Team Team { get; set; }
        public string TeamId { get; set; }
        public InTeamStatus InTeamStatus { get; set; }
        public InTeamStatusEnum CurrentPlayerInTeamStatus { get; set; }
    }
}