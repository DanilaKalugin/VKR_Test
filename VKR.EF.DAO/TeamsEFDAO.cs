using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class TeamsEFDAO
    {
        public async Task<List<Team>> GetListAsync()
        {
            await using var db = new VKRApplicationContext();

            return await db.Teams.Include(t => t.TeamColors)
                .OrderBy(t => t.TeamName)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Team>> GetTeamsWithWLBalanceAsync(int season, TypeOfMatchEnum type)
        {
            await using var db = new VKRApplicationContext();

            var f = await db.Teams.Include(t => t.TeamRating)
                .Include(t => t.TeamColors)
                .Include(t => t.Manager)
                .Include(t => t.Division)
                .ThenInclude(d => d.League)
                .ToListAsync()
                .ConfigureAwait(false);

            var f1 = await db.TeamStandings
                .Where(ts => ts.MatchType == type && ts.Season == season)
                .ToListAsync()
                .ConfigureAwait(false);

            return f.Join(f1,
                    t => t.TeamAbbreviation, tb => tb.TeamAbbreviation,
                    (team, balance) => team.SetTeamBalance(balance)).ToList();
        }

        public async Task<TeamBalance> GetNewTeamBalanceForThisTeam(Team team, TypeOfMatchEnum matchType, int year)
        {
            await using var db = new VKRApplicationContext();

            return await db.TeamStandings.FirstOrDefaultAsync(teamStandings => teamStandings.TeamAbbreviation == team.TeamAbbreviation &&
                                                           teamStandings.Season == year &&
                                                           teamStandings.MatchType == matchType)
                .ConfigureAwait(false);
        }

        public async Task<List<Team>> GetTeamsWithInfoAsync()
        {
            await using var db = new VKRApplicationContext();

            return await db.Teams.Include(t => t.TeamColors)
                .Include(t => t.Manager)
                .ThenInclude(m => m.City)
                .Include(t => t.Division)
                .ThenInclude(d => d.League)
                .Include(t => t.StadiumsForMatchTypes)
                .ThenInclude(tsmt => tsmt.Stadium)
                .OrderBy(t => t.TeamName)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<List<TeamStadiumForTypeOfMatch>> GetAllStadiumsForThisTeam(Team team)
        {
            await using var db = new VKRApplicationContext();

            return await db.TeamStadiumForTypeOfMatch
                .Include(tmts => tmts.Stadium)
                .Where(tmts => tmts.TeamAbbreviation == team.TeamAbbreviation)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task UpdateTeam(Team team)
        {
            await using var db = new VKRApplicationContext();

            var teamDb = await db.Teams.FirstOrDefaultAsync(p => p.TeamAbbreviation == team.TeamAbbreviation)
                .ConfigureAwait(false);

            if (teamDb == null) return;

            teamDb.TeamAbbreviation = team.TeamAbbreviation;
            teamDb.TeamCity = team.TeamCity;
            teamDb.TeamName = team.TeamName;
            teamDb.DivisionId = team.DivisionId;
            teamDb.TeamManager = team.Manager?.Id;
            teamDb.FoundationYear = team.FoundationYear;

            db.Teams.Update(teamDb);
            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}