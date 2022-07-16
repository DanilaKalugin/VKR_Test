using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedViewStandingsByYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW StandingsBySeasonAndMatchType AS
SELECT        dbo.Teams.TeamAbbreviation, dbo.Teams.TeamName, dbo.Leagues.LeagueID, dbo.Divisions.DivisionTitle, m1.Season, m1.MatchType, 
						 COUNT(CASE WHEN MatchWinnerID = TeamAbbreviation AND HomeTeam = TeamAbbreviation AND m1.MatchType = dbo.Matches.MatchType AND m1.Season = YEAR(dbo.Matches.MatchDate) THEN 1 ELSE NULL END) AS HW, 
                         COUNT(CASE WHEN MatchLoserID = TeamAbbreviation AND HomeTeam = TeamAbbreviation AND m1.MatchType = dbo.Matches.MatchType AND m1.Season = YEAR(dbo.Matches.MatchDate) THEN 1 ELSE NULL END) AS HL, 
						 COUNT(CASE WHEN MatchWinnerID = TeamAbbreviation AND AwayTeam = TeamAbbreviation AND m1.MatchType = dbo.Matches.MatchType AND m1.Season = YEAR(dbo.Matches.MatchDate) THEN 1 ELSE NULL END) AS AW, 
						 COUNT(CASE WHEN MatchLoserID = TeamAbbreviation AND AwayTeam = TeamAbbreviation AND m1.MatchType = dbo.Matches.MatchType AND m1.Season = YEAR(dbo.Matches.MatchDate) THEN 1 ELSE NULL END) AS AL
FROM            dbo.Teams INNER JOIN
                         dbo.Divisions ON dbo.Teams.TeamDivision = dbo.Divisions.DivisionNumber INNER JOIN
                         dbo.Leagues ON dbo.Divisions.League = dbo.Leagues.LeagueID CROSS JOIN
                         dbo.CombinationsOfYearAndMatchType AS m1 INNER JOIN
                         dbo.Matches ON (dbo.Teams.TeamAbbreviation = dbo.Matches.AwayTeam OR dbo.Teams.TeamAbbreviation = dbo.Matches.HomeTeam)
		   INNER JOIN ResultsOfMatches ON Matches.MatchID = ResultsOfMatches.MatchId
GROUP BY dbo.Teams.TeamAbbreviation, dbo.Teams.TeamName, dbo.Leagues.LeagueID, dbo.Divisions.DivisionTitle, m1.Season, m1.MatchType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW StandingsBySeasonAndMatchType AS
SELECT        dbo.Teams.TeamAbbreviation, dbo.Teams.TeamName, dbo.Leagues.LeagueID, dbo.Divisions.DivisionTitle, m1.Season, m1.MatchType, COUNT(CASE WHEN Winner = TeamAbbreviation THEN 1 ELSE NULL END) AS W, 
                         COUNT(CASE WHEN Loser = TeamAbbreviation THEN 1 ELSE NULL END) AS L, COUNT(CASE WHEN Winner = TeamAbbreviation AND HomeTeam = TeamAbbreviation THEN 1 ELSE NULL END) AS HW, 
                         COUNT(CASE WHEN Loser = TeamAbbreviation AND HomeTeam = TeamAbbreviation THEN 1 ELSE NULL END) AS HL, COUNT(CASE WHEN Winner = TeamAbbreviation AND AwayTeam = TeamAbbreviation THEN 1 ELSE NULL 
                         END) AS AW, COUNT(CASE WHEN Loser = TeamAbbreviation AND AwayTeam = TeamAbbreviation THEN 1 ELSE NULL END) AS AL
FROM            dbo.Teams INNER JOIN
                         dbo.Divisions ON dbo.Teams.TeamDivision = dbo.Divisions.DivisionNumber INNER JOIN
                         dbo.Leagues ON dbo.Divisions.League = dbo.Leagues.LeagueID CROSS JOIN
                         dbo.CombinationsOfYearAndMatchType AS m1 LEFT OUTER JOIN
                         dbo.MatchResults ON (dbo.Teams.TeamAbbreviation = dbo.MatchResults.AwayTeam OR
                         dbo.Teams.TeamAbbreviation = dbo.MatchResults.HomeTeam) AND m1.MatchType = dbo.MatchResults.MatchType AND m1.Season = YEAR(dbo.MatchResults.MatchDate)
GROUP BY dbo.Teams.TeamAbbreviation, dbo.Teams.TeamName, dbo.Leagues.LeagueID, dbo.Divisions.DivisionTitle, m1.Season, m1.MatchType");
        }
    }
}
