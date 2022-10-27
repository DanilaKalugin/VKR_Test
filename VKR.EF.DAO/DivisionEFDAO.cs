using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class DivisionEFDAO
    {
        public async Task<List<Division>> GetAllDivisionsAsync()
        {
            await using var db = new VKRApplicationContext();
            return await db.Divisions
                .Include(d => d.League)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}