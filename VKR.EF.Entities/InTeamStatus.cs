using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.EF.Entities
{
    public class InTeamStatus
    {
        public InTeamStatusEnum InTeamStatusId { get; set; }
        public string InTeamStatusTitle { get; set; }
        public virtual List<PlayerInTeam> PlayerInTeams { get; set; } = new();
    }
}
