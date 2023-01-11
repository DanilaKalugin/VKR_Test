using System.Collections.Generic;
using VKR.EF.Entities.Enums;

namespace VKR.EF.Entities.Tables
{
    public class PlayerStatus
    {
        public PlayerStatusEnum PlayerStatusId { get; set; }
        public string PlayerStatusName { get; set; }
        public virtual List<Player> Players { get; set; }
    }
}