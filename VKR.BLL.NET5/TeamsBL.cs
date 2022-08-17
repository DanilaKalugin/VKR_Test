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
            var allTeams = await _teamsEF.GetListAsync();
            return allTeams.ToList();
        }

        public List<Team> GetAllTeams() => _teamsEF.GetList().ToList();

        public List<Team> GetTeamsWithWLBalance(int season, TypeOfMatchEnum matchType)
        {
            var teams = _teamsEF.GetTeamsWithWLBalance(season, matchType).OrderBy(t => t.TeamName).ToList();
            var maxOffensiveRating = teams.Select(team => team.TeamRating.OffensiveRating).Max();
            var maxDefensiveRating = teams.Select(team => team.TeamRating.DefensiveRating).Max();

            foreach (var team in teams)
            {
                team.TeamRating.NormalizedOffensiveRating = (int)(team.TeamRating.OffensiveRating / maxOffensiveRating * 99);
                team.TeamRating.NormalizedDefensiveRating = (int)(team.TeamRating.DefensiveRating / maxDefensiveRating * 99);
            }

            return teams.ToList();
        }

        public void UpdateTeamBalance(Team team, Match match)
        {
            var newBalanceForThisTeam =
                _teamsEF.GetNewTeamBalanceForThisTeam(team, match.MatchTypeId, match.MatchDate.Year);
            team.SetTeamBalance(newBalanceForThisTeam);
        }
    }
}