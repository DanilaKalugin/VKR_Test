using System.Collections.Generic;

namespace VKR.EF.Entities
{
    public class PlayerStatus
    {
        public PlayerStatusEnum PlayerStatusId { get; set; }
        public string PlayerStatusName { get; set; }
        public virtual List<Player> Players { get; set; }
    }
}