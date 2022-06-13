using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class TeamsEFDAO
    {
        public IEnumerable<Team> GetList()
        {
            using var db = new VKRApplicationContext();

            return db.Teams.Include(t => t.TeamColors)
                .ToList();
        }

        public IEnumerable<Team> GetTeamsWithWLBalance(int season, TypeOfMatchEnum type)
        {
            using var db = new VKRApplicationContext();

            var f = db.Teams.Include(t => t.TeamColors)
                .Include(t => t.Manager)
                .Include(t => t.Division)
                .ThenInclude(d => d.League).ToList();

            var f1 = db.TeamStandings.Where(ts => ts.MatchType == type && ts.Season == season).ToList();

            return f.Join(f1,
                    t => t.TeamAbbreviation, tb => tb.TeamAbbreviation,
                    (team, balance) => new Team(team, balance)).ToList();
        }
    }
}
