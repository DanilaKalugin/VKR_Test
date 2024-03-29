﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VKR.EF.DAO.Contexts;
using VKR.EF.DAO.Interfaces;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.ViewModels;

namespace VKR.EF.DAO
{
    public class StandingsEFDAO : IStandingsDAO
    {
        public List<TeamStandingsViewModel> GetStandings(DateTime date, TypeOfMatchEnum type)
        {
            using var db = new VKRApplicationContext();

            var teamsHistoricalNames = db.TeamHistoricalNames
                .Where(t => t.FirstSeasonWithName <= date.Year &&
                            (t.LastSeasonWithName == null || t.LastSeasonWithName >= date.Year))
                .ToList();

            var teamsDivisions = db.Teams.Include(t => t.Division)
                .ToList();

            var teamList = teamsHistoricalNames.Join(teamsDivisions,
                t1 => t1.TeamAbbreviation,
                t2 => t2.TeamAbbreviation,
                (t1, t2) => new TeamStandingsViewModel(t1, t2));

            var dateParam = new SqlParameter("@Date", date);
            var typeParam = new SqlParameter("@Type", type);

            var teamBalances = db.TeamStandings.FromSqlRaw(
                @"SELECT teamAbbreviation, {0} As MatchType, Year({1}) As Season, 
                         COUNT(CASE WHEN HomeTeam = TeamAbbreviation AND MatchWinnerId = TeamAbbreviation AND MatchDate <= {1} AND Year(MatchDate) = Year({1}) AND MatchType = {0} Then 1 Else NULL END) AS HW,
                         COUNT(CASE WHEN HomeTeam = TeamAbbreviation AND MatchLoserId = TeamAbbreviation AND MatchDate <= {1} AND Year(MatchDate) = Year({1}) AND MatchType = {0} Then 1 Else NULL END) AS HL, 
                         COUNT(CASE WHEN AwayTeam = TeamAbbreviation AND MatchWinnerId = TeamAbbreviation AND MatchDate <= {1} AND Year(MatchDate) = Year({1}) AND MatchType = {0} Then 1 Else NULL END) AS AW,
                         COUNT(CASE WHEN AwayTeam = TeamAbbreviation AND MatchLoserId = TeamAbbreviation AND MatchDate <= {1} AND Year(MatchDate) = Year({1}) AND MatchType = {0} Then 1 Else NULL END) AS AL
FROM Teams INNER JOIN dbo.Matches ON (dbo.Teams.TeamAbbreviation = dbo.Matches.AwayTeam OR dbo.Teams.TeamAbbreviation = dbo.Matches.HomeTeam)
           INNER JOIN ResultsOfMatches ON Matches.MatchID = ResultsOfMatches.MatchId
GROUP BY dbo.Teams.TeamAbbreviation", typeParam, dateParam).ToList();

            var streaks = db.ReturnStreakForAllTeams(date, type).ToList();

            var runs = db.RunsByTeam.FromSqlRaw(
                @"SELECT team As TeamAbbreviation, {1} As MatchType, Year({0}) As Season, 
                               ISNULL(SUM(CASE WHEN MatchDate <= {0} AND MatchType = {1} AND Season = Year({0}) THEN RunsScored ELSE NULL END), 0) AS RunsScored, 
                               ISNULL(SUM(CASE WHEN MatchDate <= {0} AND MatchType = {1} AND Season = Year({0}) THEN RunsAllowed ELSE NULL END), 0) AS RunsAllowed
                   FROM RunsScoredAndAllowedForEveryMatch
                   GROUP BY team", dateParam, typeParam).ToList();

            var teams = teamList.Join(teamBalances,
                t => t.TeamAbbreviation,
                tb => tb.TeamAbbreviation,
                (team, balance) => team.SetTeamBalance(balance))
                .Join(runs,
                    team => team.TeamAbbreviation,
                    run => run.TeamAbbreviation,
                    (team, run) => team.SetTeamRuns(run)).ToList();

            if (teams.Count != streaks.Count)
                return teams;

            return teams.Join(streaks,
                t => t.TeamAbbreviation,
                streak => streak.AwayTeam,
                (team, streak) => team.SetTeamStreak(streak.Streak)).ToList();
        }
    }
}