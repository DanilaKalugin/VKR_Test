using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VKR.EF.DAO.Migrations;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class TeamsEFDAO
    {
        public IEnumerable<Team> GetList()
        {
            using var db = new VKRApplicationContext();

            return db.Teams.Include(t => t.TeamColors)
                .ToList();
        }

        public IEnumerable<Team> GetTeamsWithWLBalance(int season, TypeOfMatchEnum type)
        {
            using var db = new VKRApplicationContext();

            var f = db.Teams.Include(t => t.TeamColors)
                .Include(t => t.Manager)
                .Include(t => t.Division)
                .ThenInclude(d => d.League)
                .Include(t => t.StadiumsForMatchTypes).ToList();

            var f1 = db.TeamStandings.Where(ts => ts.MatchType == type && ts.Season == season).ToList();

            return f.Join(f1,
                    t => t.TeamAbbreviation, tb => tb.TeamAbbreviation,
                    (team, balance) => new Team(team, balance)).ToList();
        }

        public List<Team> GetStandings(DateTime date, byte type)
        {
            using var db = new VKRApplicationContext();

            var teamWithLeagueAndDivision = db.Teams.Include(t => t.TeamColors)
                .Include(t => t.Division)
                .ThenInclude(d => d.League)
                .Include(t => t.Manager)
                .ToList();

            var dateParam = new SqlParameter("@Date", date);
            var TypeParam = new SqlParameter("@Type", type);

            var teamBalances = db.TeamStandings.FromSqlRaw(
                @"SELECT dbo.Teams.TeamAbbreviation, {0} As MatchType, Year({1}) As Season,
						 COUNT(CASE WHEN Winner = Teams.TeamAbbreviation AND HomeTeam = Teams.TeamAbbreviation THEN 1 ELSE NULL END) AS HW, 
						 COUNT(CASE WHEN Loser = Teams.TeamAbbreviation AND HomeTeam = Teams.TeamAbbreviation THEN 1 ELSE NULL END) AS HL, 
						 COUNT(CASE WHEN Winner = Teams.TeamAbbreviation AND AwayTeam = Teams.TeamAbbreviation THEN 1 ELSE NULL END) AS AW, 
						 COUNT(CASE WHEN Loser = Teams.TeamAbbreviation AND AwayTeam = Teams.TeamAbbreviation THEN 1 ELSE NULL END) AS AL
FROM            dbo.Teams CROSS JOIN
                         dbo.CombinationsOfYearAndMatchType AS m1 LEFT OUTER JOIN
                         dbo.MatchResults ON (dbo.Teams.TeamAbbreviation = dbo.MatchResults.AwayTeam OR
                         dbo.Teams.TeamAbbreviation = dbo.MatchResults.HomeTeam) AND m1.MatchType = dbo.MatchResults.MatchType AND m1.Season = MatchResults.Season
WHERE m1.Season = Year({1}) AND (m1.MatchType = {0}) AND (matchDate <= {1} OR MatchDate IS NULL)
GROUP BY dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season", type,
                date).ToList();

            var streaks = db.ReturnStreakForAllTeams(date, type).ToList();
            var rs = db.RunsScoredByTeamBeforeThisDateInMatchType(type, date).ToList();
            
            return teamWithLeagueAndDivision.Join(teamBalances,
                t => t.TeamAbbreviation, 
                tb => tb.TeamAbbreviation,
                (team, balance) => new {team, balance })
                .Join(streaks, 
                    team => team.team.TeamAbbreviation, 
                    streak => streak.AwayTeam, 
                    (team, stat) => new { team.team, team.balance, stat})
                .Join(rs, 
                    team => team.team.TeamAbbreviation, 
                    runsScored => runsScored.TeamAbbreviation,
                    (team, rs) => new Team(team.team, team.balance, team.stat.Streak, rs.RunsScored)).ToList();
        }
        /*
        public int GetStreakForThisTeam(DateTime date, TypeOfMatchEnum type, string teamID)
        {
            using var db = new VKRApplicationContext();
            /*return db.Teams.Where(team => team.TeamAbbreviation == teamID)
                .Select(t => VKRApplicationContext.ReturnStreakForAllTeams(date, teamID, type)).First();
        
        }*/
    }
}
