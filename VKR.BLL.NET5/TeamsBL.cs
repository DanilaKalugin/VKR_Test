using System;
using System.Collections.Generic;
using System.Linq;
using VKR.DAL.NET5;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class TeamsBL
    {
        private readonly TeamsDao _teamsDAO = new();
        private readonly TeamsEFDAO _teamsEF = new();

        public List<Team> GetAllTeams() => _teamsEF.GetList().OrderBy(t => t.TeamName).ToList();

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
                teams = filter is "NL" or "AL"
                    ? teams.Where(team => team.Division.LeagueId == filter).ToList()
                    : teams.Where(team => team.Division.DivisionTitle == filter).ToList();
            }

            foreach (var team in teams)
            {
                //team.Streak = _teamsEF.GetStreakForThisTeam(date, TypeOfMatchEnum.RegularSeason, team.TeamAbbreviation);
                //team.TeamColor = _teamsDAO.GetAllColorsForThisTeam(team.TeamAbbreviation).ToList();
                //team.RunsScored = _teamsDAO.GetRunsScoredByTeamAfterThisDate(team, date);
                //team.RunsAllowed = _teamsDAO.GetRunsAllowedByTeamAfterThisDate(team, date);
            }

            var leaderW = teams[0].Wins;
            var leaderL = teams[0].Losses;

            foreach (var team in teams) team.GamesBehind = (double)(leaderW - leaderL - (team.Wins - team.Losses)) / 2;

            teams = teams.OrderBy(team => team.GamesBehind)
                .ThenByDescending(team => team.Wins)
                /*.ThenByDescending(team => team.RunDifferential).ThenByDescending(team => team.RunsScored)*/.ToList();

            var leadGB = teams[0].GamesBehind;

            if (leadGB >= 0) return teams;

            foreach (var team in teams) team.GamesBehind -= leadGB;

            return teams;
        }

        public List<Team> GetWCStandings(string filter, DateTime date)
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

        public void UpdateTeamBalance(Entities.NET5.Team team)
        {
            var teamWithNewBalance = _teamsDAO.UpdateBalanceForThisTeam(team).First();
            team.Wins = teamWithNewBalance.Item1;
            team.Losses = teamWithNewBalance.Item2;
        }

        public List<Entities.NET5.Team> GetTeamBattingStats() => _teamsDAO.GetList().OrderByDescending(team => team.BattingStats.AVG).ToList();

        public List<Entities.NET5.Team> GetTeamPitchingStats() => _teamsDAO.GetList().OrderBy(team => team.PitchingStats.ERA).ToList();
    }
}