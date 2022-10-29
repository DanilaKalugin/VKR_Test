using System.Collections.Generic;

namespace VKR.EF.Entities
{
    public class InTeamStatus
    {
        public InTeamStatusEnum InTeamStatusId { get; set; }
        public string InTeamStatusTitle { get; set; }
        public virtual List<PlayerInTeam> PlayerInTeams { get; set; } = new();
    }
}