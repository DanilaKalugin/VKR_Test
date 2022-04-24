using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using VKR.DAL;

namespace VKR.BLL
{
    public class TeamsBL
    {
        private readonly TeamsDAO _teamsDAO;

        public TeamsBL()
        {
            _teamsDAO = new TeamsDAO();
        }

        public List<Team> GetAllTeams()
        {
            List<Team> teams = _teamsDAO.GetList().ToList();
            double MaxOffensiveRating = teams.Select(team => team.OffensiveRating()).Max();
            double MaxDefensiveRating = teams.Select(team => team.DefensiveRating()).Max();
            foreach (Team team in teams)
            {
                team.NormalizedOffensiveRating = (int)(team.OffensiveRating() / MaxOffensiveRating * 99);
                team.NormalizedDefensiveRating = (int)(team.DefensiveRating() / MaxDefensiveRating * 99);
            }
            return teams;
        }

        public List<Team> GetStandings(string Filter, DateTime date)
        {
            List<Team> teams = _teamsDAO.GetStandings(date).ToList();

            if (Filter != "MLB")
            {
                if (Filter == "NL" || Filter == "AL")
                {
                    teams = teams.Where(team => team.League == Filter).ToList();
                }
                else
                {
                    teams = teams.Where(team => team.Division == Filter).ToList();
                }
            }
            int LeaderW = teams[0].Wins;
            int LeaderL = teams[0].Losses;

            foreach (Team team in teams)
            {
                team.GamesBehind = (double)(LeaderW - LeaderL - (team.Wins - team.Losses)) / 2;
            }
            teams = teams.OrderBy(team => team.GamesBehind).ThenByDescending(team => team.Wins).ThenByDescending(team => team.RunDifferential).ThenByDescending(team => team.RunsScored).ToList();

            double leadGB = teams[0].GamesBehind;
            if (leadGB < 0)
            {
                foreach (Team team in teams)
                {
                    team.GamesBehind -= leadGB;
                }
            }
            return teams;
        }

        public List<Team> GetWCStandings(string Filter, DateTime date)
        {
            List<Team> teams = GetStandings(Filter, date).ToList();
            List<Team> allTeams = _teamsDAO.GetList().ToList();
            Team WestLeader = teams.Where(team => team.Division == $"{Filter} West").First();
            Team CentralLeader = teams.Where(team => team.Division == $"{Filter} Central").First();
            Team EastLeader = teams.Where(team => team.Division == $"{Filter} East").First();
            teams = teams.Where(team => team.TeamAbbreviation != WestLeader.TeamAbbreviation && team.TeamAbbreviation != EastLeader.TeamAbbreviation && team.TeamAbbreviation != CentralLeader.TeamAbbreviation).ToList();
            int LeaderW = teams[1].Wins;
            int LeaderL = teams[1].Losses;

            foreach (Team team in teams)
            {
                team.GamesBehind = (double)(LeaderW - LeaderL - (team.Wins - team.Losses)) / 2;
            }
            return teams;
        }

        public List<Team> GetSortedTeamStatsDesc<Tkey>(List<Team> teams, Func<Team, Tkey> key)
        {
            return teams.OrderByDescending(key).ToList();
        }

        public List<Team> GetSortedTeamStats<Tkey>(List<Team> teams, Func<Team, Tkey> key)
        {
            return teams.OrderBy(key).ToList();
        }

        public void UpdateTeamBalance(Team team)
        {
            Team TeamWithNewBalance = _teamsDAO.UpdateBalanceForThisTeam(team).First();
            team.Wins = TeamWithNewBalance.Wins;
            team.Losses = TeamWithNewBalance.Losses;
        }

        public List<Team> GetTeamBattingStats()
        {
            return _teamsDAO.GetList().OrderByDescending(team => team.battingStats.AVG).ToList();
        }

        public List<Team> GetTeamPitchingStats()
        {
            return _teamsDAO.GetList().OrderBy(team => team.pitchingStats.ERA).ToList();
        }
    }
}