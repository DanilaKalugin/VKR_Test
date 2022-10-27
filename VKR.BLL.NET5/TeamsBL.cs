using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class TeamsBL
    {
        private readonly TeamsEFDAO _teamsEF = new();

        public async Task<List<Team>> GetListAsync()
        {
            var allTeams = await _teamsEF.GetListAsync()
                .ConfigureAwait(false);
            return allTeams.ToList();
        }

        public async Task<List<Team>> GetTeamsWithWLBalanceAsync(int season, TypeOfMatchEnum matchType)
        {
            var teams = await _teamsEF.GetTeamsWithWLBalanceAsync(season, matchType)
                .ConfigureAwait(false);
                teams = teams.OrderBy(t => t.TeamName).ToList();
            var maxOffensiveRating = teams.Select(team => team.TeamRating.OffensiveRating).Max();
            var maxDefensiveRating = teams.Select(team => team.TeamRating.DefensiveRating).Max();

            foreach (var team in teams)
            {
                team.TeamRating.NormalizedOffensiveRating = (int)(team.TeamRating.OffensiveRating / maxOffensiveRating * 99);
                team.TeamRating.NormalizedDefensiveRating = (int)(team.TeamRating.DefensiveRating / maxDefensiveRating * 99);
            }

            return teams.ToList();
        }

        public async Task UpdateTeamBalance(Team team, Match match)
        {
            var newBalanceForThisTeam = await _teamsEF.GetNewTeamBalanceForThisTeam(team, match.MatchTypeId, match.MatchDate.Year)
                .ConfigureAwait(false);
            team.SetTeamBalance(newBalanceForThisTeam);
        }

        public async Task<List<Team>> GetTeamsWithInfoAsync() => 
            await _teamsEF.GetTeamsWithInfoAsync()
                .ConfigureAwait(false);

        public async Task<List<TeamStadiumForTypeOfMatch>> GetAllStadiumsForThisTeam(Team team) =>
            await _teamsEF.GetAllStadiumsForThisTeam(team)
                .ConfigureAwait(false);

        public async Task UpdateTeam(Team team) => 
            await _teamsEF.UpdateTeam(team)
                .ConfigureAwait(false);
    }
}