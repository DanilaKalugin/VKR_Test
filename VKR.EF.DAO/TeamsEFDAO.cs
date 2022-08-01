using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class TeamsEFDAO
    {
        public async Task<IEnumerable<Team>> GetListAsync()
        {
            await using var db = new VKRApplicationContext();

            return await db.Teams.Include(t => t.TeamColors)
                .OrderBy(t => t.TeamName)
                .ToListAsync();
        }

        public IEnumerable<Team> GetList()
        {
            using var db = new VKRApplicationContext();

            return db.Teams.Include(t => t.TeamColors)
                .Include(t => t.Division)
                .ThenInclude(d => d.League)
                .OrderBy(t => t.TeamName)
                .ToList();
        }

        public IEnumerable<Team> GetTeamsWithWLBalance(int season, TypeOfMatchEnum type)
        {
            using var db = new VKRApplicationContext();

            var f = db.Teams.Include(t => t.TeamColors)
                .Include(t => t.Manager)
                .Include(t => t.Division)
                .ThenInclude(d => d.League).ToList();

            var f1 = db.TeamStandings.Where(ts => ts.MatchType == type && ts.Season == season).ToList();

            return f.Join(f1,
                    t => t.TeamAbbreviation, tb => tb.TeamAbbreviation,
                    (team, balance) => team.SetTeamBalance(balance)).ToList();
        }

        public List<Team> GetStandings(DateTime date, byte type)
        {
            using var db = new VKRApplicationContext();

            var teamWithLeagueAndDivision = db.Teams.Include(t => t.TeamColors)
                .Include(t => t.Division)
                .ThenInclude(d => d.League)
                .ToList();

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

            var runs = db.Runs.FromSqlRaw(
                @"SELECT team As TeamAbbreviation, ISNULL(SUM(CASE WHEN MatchDate <= {0} AND MatchType = {1} AND Year(MatchDate) = Year({0}) THEN RunsScored ELSE NULL END), 0) AS RunsScored, 
                               ISNULL(SUM(CASE WHEN MatchDate <= {0} AND MatchType = {1} AND Year(MatchDate) = Year({0}) THEN RunsAllowed ELSE NULL END), 0) AS RunsAllowed
                   FROM RunsScoredAndAllowedForEveryMatch
                   GROUP BY team", dateParam, typeParam).ToList();

            return teamWithLeagueAndDivision.Join(teamBalances,
                t => t.TeamAbbreviation,
                tb => tb.TeamAbbreviation,
                (team, balance) => team.SetTeamBalance(balance))
                .Join(streaks,
                    team => team.TeamAbbreviation,
                    streak => streak.AwayTeam,
                    (team, stat) => team.SetTeamStreak(stat.Streak))
                .Join(runs,
                    team => team.TeamAbbreviation,
                    run => run.TeamAbbreviation,
                    (team, run) => team.SetRunsByTeam(run)).ToList();
        }

        public List<Team> GetBattingStatsByYearAndMatchType(int year, TypeOfMatchEnum type)
        {
            using var db = new VKRApplicationContext();

            var teams = db.Teams.Include(team => team.TeamColors).ToList();

            var battingStats = db.TeamsBattingStats
                .Where(batting => batting.Season == year && batting.MatchType == type).ToList();

            return teams.Join(battingStats, team => team.TeamAbbreviation, stats => stats.TeamName,
                (team, stats) => team.SetBattingStats(stats)).ToList();
        }

        public List<Team> GetPitchingStatsByYearAndMatchType(int year, TypeOfMatchEnum type)
        {
            using var db = new VKRApplicationContext();

            var teams = db.Teams.Include(team => team.TeamColors).ToList();

            var battingStats = db.TeamsPitchingStats
                .Where(batting => batting.Season == year && batting.MatchType == type).ToList();

            return teams.Join(battingStats, team => team.TeamAbbreviation, stats => stats.TeamName,
                (team, stats) => team.SetPitchingStats(stats)).ToList();
        }
    }
}
