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
                @"SELECT teamAbbreviation, {0} As MatchType, Year({1}) As Season, 
						 COUNT(CASE WHEN HomeTeam = TeamAbbreviation AND MatchWinnerId = TeamAbbreviation AND MatchDate <= {1} AND Year(MatchDate) = Year({1}) AND MatchType = {0} Then 1 Else NULL END) AS HW,
						 COUNT(CASE WHEN HomeTeam = TeamAbbreviation AND MatchLoserId = TeamAbbreviation AND MatchDate <= {1} AND Year(MatchDate) = Year({1}) AND MatchType = {0} Then 1 Else NULL END) AS HL, 
						 COUNT(CASE WHEN AwayTeam = TeamAbbreviation AND MatchWinnerId = TeamAbbreviation AND MatchDate <= {1} AND Year(MatchDate) = Year({1}) AND MatchType = {0} Then 1 Else NULL END) AS AW,
						 COUNT(CASE WHEN AwayTeam = TeamAbbreviation AND MatchLoserId = TeamAbbreviation AND MatchDate <= {1} AND Year(MatchDate) = Year({1}) AND MatchType = {0} Then 1 Else NULL END) AS AL
FROM Teams INNER JOIN dbo.Matches ON (dbo.Teams.TeamAbbreviation = dbo.Matches.AwayTeam OR dbo.Teams.TeamAbbreviation = dbo.Matches.HomeTeam)
		   INNER JOIN ResultsOfMatches ON Matches.MatchID = ResultsOfMatches.MatchId
GROUP BY dbo.Teams.TeamAbbreviation", type,
                date).ToList();

            var streaks = db.ReturnStreakForAllTeams(date, type).ToList();
            
            return teamWithLeagueAndDivision.Join(teamBalances,
                t => t.TeamAbbreviation, 
                tb => tb.TeamAbbreviation,
                (team, balance) => new {team, balance })
                .Join(streaks, 
                    team => team.team.TeamAbbreviation, 
                    streak => streak.AwayTeam, 
                    (team, stat) => new Team(team.team, team.balance, stat.Streak)).ToList();
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
