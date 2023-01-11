using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.DAO.Contexts;
using VKR.EF.Entities.Tables;

namespace VKR.EF.DAO
{
    public class PrimaryTeamColorEFDAO
    {
        public async Task<List<TeamColor>> GetPrimaryTeamColorsAsync()
        {
            await using var db = new VKRApplicationContext();
            return await db.TeamColors
                .Where(tc => tc.ColorNumber == 1)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}