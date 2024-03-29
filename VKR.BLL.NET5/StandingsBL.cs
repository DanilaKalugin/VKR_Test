﻿using System;
using System.Collections.Generic;
using System.Linq;
using VKR.EF.DAO;
using VKR.EF.DAO.Interfaces;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.ViewModels;

namespace VKR.BLL.NET5
{
    public class StandingsBL
    {
        private readonly IStandingsDAO _standingsDao = new StandingsEFDAO();

        public List<TeamStandingsViewModel> GetStandings(string filter, DateTime date)
        {
            var teams = _standingsDao.GetStandings(date, TypeOfMatchEnum.RegularSeason);

            if (filter != "MLB")
            {
                Func<TeamStandingsViewModel, bool> teamFilter = filter is "NL" or "AL"
                    ? team => team.LeagueName == filter
                    : team => team.DivisionName == filter;

                teams = teams.Where(teamFilter).ToList();
            }

            var leaderW = teams[0].Wins;
            var leaderL = teams[0].Losses;

            foreach (var team in teams) team.GamesBehind = (double)(leaderW - leaderL - (team.Wins - team.Losses)) / 2;

            teams = teams.OrderBy(team => team.GamesBehind)
                .ThenByDescending(team => team.WinPercentage)
                .ThenByDescending(team => team.RunDifferential)
                .ThenByDescending(team => team.RunsScored).ToList();

            var minimumGamesBehind = teams.Select(team => team.GamesBehind).Min();

            foreach (var team in teams) 
                team.GamesBehind -= minimumGamesBehind;
            
            return teams;
        }

        public List<TeamStandingsViewModel> GetWildCardStandings(string filter, DateTime date)
        {
            var teams = GetStandings(filter, date);

            var westLeader = teams.First(team => team.DivisionName == $"{filter} West");
            var centralLeader = teams.First(team => team.DivisionName == $"{filter} Central");
            var eastLeader = teams.First(team => team.DivisionName == $"{filter} East");

            var divisionLeaders = new List<TeamStandingsViewModel> { westLeader, centralLeader, eastLeader };
            teams = teams.Except(divisionLeaders).ToList();

            var leaderW = teams[2].Wins;
            var leaderL = teams[2].Losses;

            foreach (var team in teams) team.GamesBehind = (double)(leaderW - leaderL - (team.Wins - team.Losses)) / 2;

            return teams;
        }
    }
}