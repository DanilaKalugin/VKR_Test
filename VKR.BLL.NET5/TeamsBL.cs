using System;
using System.Collections.Generic;
using System.Linq;
using VKR.DAL.NET5;
using VKR.EF.DAO;
using VKR.Entities.NET5;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class TeamsBL
    {
        private readonly TeamsDao _teamsDAO = new();
        private readonly TeamsEFDAO _teamsEF = new();

        public List<EF.Entities.Team> GetAllTeams()
        {
            return _teamsEF.GetList().OrderBy(t => t.TeamName).ToList();
        }

        public List<EF.Entities.Team> GetTeamsWithWLBalance(int season, TypeOfMatchEnum matchType)
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

        public List<EF.Entities.Team> GetStandings(string filter, DateTime date)
        {
            var teams = _teamsEF.GetStandings(date, TypeOfMatchEnum.RegularSeason).ToList();

            foreach (var team in teams)
            {
                //team.TeamColor = _teamsDAO.GetAllColorsForThisTeam(team.TeamAbbreviation).ToList();
                //team.RunsScored = _teamsDAO.GetRunsScoredByTeamAfterThisDate(team, date);
                //team.RunsAllowed = _teamsDAO.GetRunsAllowedByTeamAfterThisDate(team, date);
            }

            if (filter != "MLB")
            {
                teams = filter is "NL" or "AL"
                    ? teams.Where(team => team.Division.LeagueId == filter).ToList()
                    : teams.Where(team => team.Division.DivisionTitle == filter).ToList();
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

        public List<Entities.NET5.Team> GetWCStandings(string filter, DateTime date)
        {
            throw new NotImplementedException();
/*
            var teams = GetStandings(filter, date).ToList();
            var westLeader = teams.First(team => team.Division == $"{filter} West");
            var centralLeader = teams.First(team => team.Division == $"{filter} Central");
            var eastLeader = teams.First(team => team.Division == $"{filter} East");
            teams = teams.Where(team => team.TeamAbbreviation != westLeader.TeamAbbreviation && team.TeamAbbreviation != eastLeader.TeamAbbreviation && team.TeamAbbreviation != centralLeader.TeamAbbreviation).ToList();
            var leaderW = teams[1].Wins;
            var leaderL = teams[1].Losses;

            foreach (var team in teams) team.GamesBehind = (double)(leaderW - leaderL - (team.Wins - team.Losses)) / 2;

            return teams;*/
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