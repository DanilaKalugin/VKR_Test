using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKR.DAL.NET5;
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
            var maxOffensiveRating = teams.Select(team => team.OffensiveRating()).Max();
            var maxDefensiveRating = teams.Select(team => team.DefensiveRating()).Max();

            foreach (var team in teams)
            {
                team.NormalizedOffensiveRating = (int)(team.OffensiveRating() / maxOffensiveRating * 99);
                team.NormalizedDefensiveRating = (int)(team.DefensiveRating() / maxDefensiveRating * 99);
            }

            return teams.ToList();
        }

        public List<Team> GetStandings(string filter, DateTime date)
        {
            var teams = _teamsEF.GetStandings(date, (byte)TypeOfMatchEnum.RegularSeason);

            if (filter != "MLB")
            {
                Func<Team, bool> teamFilter = filter is "NL" or "AL"
                    ? team => team.Division.LeagueId == filter
                    : team => team.Division.DivisionTitle == filter;

                teams = teams.Where(teamFilter).ToList();
            }

            var leaderW = teams[0].Wins;
            var leaderL = teams[0].Losses;

            foreach (var team in teams) team.GamesBehind = (double)(leaderW - leaderL - (team.Wins - team.Losses)) / 2;

            teams = teams.OrderBy(team => team.GamesBehind)
                .ThenByDescending(team => team.Wins)
                .ThenByDescending(team => team.RunDifferential)
                .ThenByDescending(team => team.RunsScored).ToList();

            var minimumGamesBehind = teams.Select(team => team.GamesBehind).Min();

            foreach (var team in teams) team.GamesBehind -= minimumGamesBehind;

            return teams;
        }

        public List<Team> GetWildCardStandings(string filter, DateTime date)
        {
            var teams = GetStandings(filter, date);

            var westLeader = teams.First(team => team.Division.DivisionTitle == $"{filter} West");
            var centralLeader = teams.First(team => team.Division.DivisionTitle == $"{filter} Central");
            var eastLeader = teams.First(team => team.Division.DivisionTitle == $"{filter} East");

            var divisionLeaders = new List<Team>{westLeader, centralLeader, eastLeader};
            teams = teams.Except(divisionLeaders).ToList();

            var leaderW = teams[2].Wins;
            var leaderL = teams[2].Losses;

            foreach (var team in teams) team.GamesBehind = (double)(leaderW - leaderL - (team.Wins - team.Losses)) / 2;

            return teams;
        }

        public void UpdateTeamBalance(Team team, Match match)
        {
            var newBalanceForThisTeam =
                _teamsEF.GetNewTeamBalanceForThisTeam(team, match.MatchTypeId, match.MatchDate.Year);
            team.SetTeamBalance(newBalanceForThisTeam);
        }

        public List<Team> GetTeamBattingStats()
        {
            return _teamsEF.GetBattingStatsByYearAndMatchType(2021, TypeOfMatchEnum.RegularSeason)
                           .OrderByDescending(team => team.BattingStats.AVG).ToList();
        }

        public List<Team> GetTeamPitchingStats()
        {
            return _teamsEF.GetPitchingStatsByYearAndMatchType(2021, TypeOfMatchEnum.RegularSeason)
                .OrderBy(team => team.PitchingStats.ERA).ToList();
        }
    }
}