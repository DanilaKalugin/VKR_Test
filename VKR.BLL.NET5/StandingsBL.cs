using System;
using System.Collections.Generic;
using System.Linq;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class StandingsBL
    {
        private readonly StandingsEFDAO _standingsDao = new();

        public List<Team> GetStandings(string filter, DateTime date)
        {
            var teams = _standingsDao.GetStandings(date, (byte)TypeOfMatchEnum.RegularSeason);

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

            var divisionLeaders = new List<Team> { westLeader, centralLeader, eastLeader };
            teams = teams.Except(divisionLeaders).ToList();

            var leaderW = teams[2].Wins;
            var leaderL = teams[2].Losses;

            foreach (var team in teams) team.GamesBehind = (double)(leaderW - leaderL - (team.Wins - team.Losses)) / 2;

            return teams;
        }
    }
}