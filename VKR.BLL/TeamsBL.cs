using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using VKR.DAL;

namespace VKR.BLL
{
    public class TeamsBL
    {
        private readonly TeamsDAO _teamsDAO = new TeamsDAO();

        public List<Team> GetAllTeams()
        {
            var teams = _teamsDAO.GetList().ToList();
            var MaxOffensiveRating = teams.Select(team => team.OffensiveRating()).Max();
            var MaxDefensiveRating = teams.Select(team => team.DefensiveRating()).Max();

            foreach (var team in teams)
            {
                team.NormalizedOffensiveRating = (int)(team.OffensiveRating() / MaxOffensiveRating * 99);
                team.NormalizedDefensiveRating = (int)(team.DefensiveRating() / MaxDefensiveRating * 99);
            }

            return teams;
        }

        public List<Team> GetStandings(string Filter, DateTime date)
        {
            var teams = _teamsDAO.GetStandings(date).ToList();

            foreach (var team in teams)
            {
                team.TeamColor = _teamsDAO.GetAllColorsForThisTeam(team.TeamAbbreviation).ToList();
                team.RunsScored = _teamsDAO.GetRunsScoredByTeamAfterThisDate(team, date);
                team.RunsAllowed = _teamsDAO.GetRunsAllowedByTeamAfterThisDate(team, date);
            }

            if (Filter != "MLB")
            {
                teams = Filter == "NL" || Filter == "AL"
                    ? teams.Where(team => team.League == Filter).ToList()
                    : teams.Where(team => team.Division == Filter).ToList();
            }

            var LeaderW = teams[0].Wins;
            var LeaderL = teams[0].Losses;

            foreach (var team in teams) team.GamesBehind = (double)(LeaderW - LeaderL - (team.Wins - team.Losses)) / 2;
            
            teams = teams.OrderBy(team => team.GamesBehind)
                .ThenByDescending(team => team.Wins)
                .ThenByDescending(team => team.RunDifferential).ThenByDescending(team => team.RunsScored).ToList();

            var leadGB = teams[0].GamesBehind;

            if (!(leadGB < 0)) return teams;

            foreach (var team in teams) team.GamesBehind -= leadGB;

            return teams;
        }

        public List<Team> GetWCStandings(string Filter, DateTime date)
        {
            var teams = GetStandings(Filter, date).ToList();
            var WestLeader = teams.First(team => team.Division == $"{Filter} West");
            var CentralLeader = teams.First(team => team.Division == $"{Filter} Central");
            var EastLeader = teams.First(team => team.Division == $"{Filter} East");
            teams = teams.Where(team => team.TeamAbbreviation != WestLeader.TeamAbbreviation && team.TeamAbbreviation != EastLeader.TeamAbbreviation && team.TeamAbbreviation != CentralLeader.TeamAbbreviation).ToList();
            var LeaderW = teams[1].Wins;
            var LeaderL = teams[1].Losses;

            foreach (var team in teams) team.GamesBehind = (double)(LeaderW - LeaderL - (team.Wins - team.Losses)) / 2;
            
            return teams;
        }

        public void UpdateTeamBalance(Team team)
        {
            var teamWithNewBalance = _teamsDAO.UpdateBalanceForThisTeam(team).First();
            team.Wins = teamWithNewBalance.Item1;
            team.Losses = teamWithNewBalance.Item2;
        }

        public List<Team> GetTeamBattingStats() => _teamsDAO.GetList().OrderByDescending(team => team.BattingStats.AVG).ToList();

        public List<Team> GetTeamPitchingStats() => _teamsDAO.GetList().OrderBy(team => team.PitchingStats.ERA).ToList();
    }
}