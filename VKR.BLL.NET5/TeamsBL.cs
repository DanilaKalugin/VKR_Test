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

        public async Task<List<Team>> GetTeamsWithInfoAsync()
        {
            var teamsInfo = await _teamsEF.GetTeamsWithInfoAsync()
                .ConfigureAwait(false);

        public async Task<List<TeamStadiumForTypeOfMatch>> GetAllStadiumsForThisTeam(Team team) =>
            await _teamsEF.GetAllStadiumsForThisTeam(team)
                .ConfigureAwait(false);
            return teamsInfo.OrderBy(t => t.TeamName).ToList();
        }

        public async Task UpdateTeam(Team team) => 
            await _teamsEF.UpdateTeam(team)
                .ConfigureAwait(false);

        public async Task<List<RetiredNumber>> GetRetiredNumbersForThisTeam(Team team)
        {
            var numbers = await _teamsEF.GetRetiredNumbersForThisTeam(team)
                .ConfigureAwait(false);

            return numbers
                .OrderBy(rn => rn.Number)
                .ToList();
        }

        public async Task<List<byte>> GetAvailableNumbers(Team team)
        {
            var retiredNumbers = await _teamsEF.GetRetiredNumbersForThisTeam(team)
                .ConfigureAwait(false);

            var numbers = retiredNumbers.Select(rn => rn.Number);

            return Enumerable.Range(0,100)
                .Select(num => (byte)num)
                .Where(num => !numbers.Contains(num))
                .OrderByDescending(n => n)
                .ToList();
        }
    }
}