using System.Collections.Generic;
using VKR.EF.Entities.Enums;

namespace VKR.EF.Entities.Tables
{
    public class InTeamStatus
    {
        public InTeamStatusEnum InTeamStatusId { get; set; }
        public string InTeamStatusTitle { get; set; }
        public virtual List<PlayerInTeam> PlayerInTeams { get; set; } = new();
    }
}