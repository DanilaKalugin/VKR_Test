using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class ManEFDAO
    {
        public async Task<List<ManInTeam>> GetListOfPeopleWithBirthdayTodayAsync()
        {
            await using var db = new VKRApplicationContext();
            return await db.ManInTeam.ToListAsync().ConfigureAwait(false);
        }
    }
}