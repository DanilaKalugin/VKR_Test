using System.Collections.Generic;
using System.Linq;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class PrimaryTeamColorEFDAO
    {
        public List<TeamColor> GetPrimaryTeamColors()
        {
            using var db = new VKRApplicationContext();
            return db.TeamColors.Where(tc => tc.ColorNumber == 1).ToList();
        }
    }
}