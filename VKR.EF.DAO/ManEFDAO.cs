using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class ManEFDAO
    {
        public IEnumerable<ManInTeam> GetListOfPeopleWithBirthdayToday()
        {
            using var db = new VKRApplicationContext();
            return db.ManInTeam.ToList();
        }
    }
}