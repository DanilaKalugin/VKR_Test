using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class StadiumsEFDAO
    {
        public IEnumerable<Stadium> GetAllStadiums()
        {
            using var db = new VKRApplicationContext();
            return db.Stadiums.Include(stadium => stadium.StadiumCity).ToList();
        }

        public Stadium GetHomeStadiumForThisTeamAndTypeOfMatch(string teamAbbreviation, TypeOfMatchEnum typeOfMatch)
        {
            using var db = new VKRApplicationContext();
            return db.TeamStadiumForTypeOfMatch
                .Where(tsmt => tsmt.TeamAbbreviation == teamAbbreviation && tsmt.TypeOfMatchId == typeOfMatch)
                .Include(tsmt => tsmt.Stadium)
                .ThenInclude(stadium => stadium.StadiumCity)
                .Select(tsmt => tsmt.Stadium).FirstOrDefault();
        }
    }
}