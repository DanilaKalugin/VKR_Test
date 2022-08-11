using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class TeamsEFDAO
    {
        public async Task<IEnumerable<Team>> GetListAsync()
        {
            await using var db = new VKRApplicationContext();

            return await db.Teams.Include(t => t.TeamColors)
                .OrderBy(t => t.TeamName)
                .ToListAsync();
        }

        public IEnumerable<Team> GetList()
        {
            using var db = new VKRApplicationContext();

            return db.Teams.Include(t => t.TeamColors)
                .Include(t => t.Division)
                .ThenInclude(d => d.League)
                .OrderBy(t => t.TeamName)
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
                    (team, balance) => team.SetTeamBalance(balance)).ToList();
        }

        public TeamBalance GetNewTeamBalanceForThisTeam(Team team, TypeOfMatchEnum matchType, int year)
        {
            using var db = new VKRApplicationContext();

            return db.TeamStandings.First(teamStandings => teamStandings.TeamAbbreviation == team.TeamAbbreviation &&
                                                           teamStandings.Season == year &&
                                                           teamStandings.MatchType == matchType);
        }
    }
}