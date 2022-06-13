using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedViewStandingsByYearAndMatchType : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(
                @"ALTER VIEW StandingsBySeasonAndMatchType AS
SELECT        dbo.Teams.TeamAbbreviation, dbo.Teams.TeamName, dbo.Leagues.LeagueID, dbo.Divisions.DivisionTitle, m1.Season, m1.MatchType, 
                         COUNT(CASE WHEN Winner = TeamAbbreviation THEN 1 ELSE NULL END) AS W, COUNT(CASE WHEN Loser = TeamAbbreviation THEN 1 ELSE NULL END) AS L, COUNT(CASE WHEN Winner = TeamAbbreviation AND 
                         HomeTeam = TeamAbbreviation THEN 1 ELSE NULL END) AS HW, COUNT(CASE WHEN Loser = TeamAbbreviation AND HomeTeam = TeamAbbreviation THEN 1 ELSE NULL END) AS HL, 
                         COUNT(CASE WHEN Winner = TeamAbbreviation AND AwayTeam = TeamAbbreviation THEN 1 ELSE NULL END) AS AW, COUNT(CASE WHEN Loser = TeamAbbreviation AND AwayTeam = TeamAbbreviation THEN 1 ELSE NULL 
                         END) AS AL
FROM            dbo.Teams INNER JOIN dbo.Divisions ON dbo.Teams.TeamDivision = dbo.Divisions.DivisionNumber 
						  INNER JOIN dbo.Leagues ON dbo.Divisions.League = dbo.Leagues.LeagueID 
						  CROSS JOIN CombinationsOfYearAndMatchType m1
						  LEFT OUTER JOIN dbo.MatchResults ON (dbo.Teams.TeamAbbreviation = dbo.MatchResults.AwayTeam OR dbo.Teams.TeamAbbreviation = dbo.MatchResults.HomeTeam) AND m1.MatchType = MatchResults.MatchType AND m1.Season = Year(MatchDate)
GROUP BY dbo.Teams.TeamAbbreviation, dbo.Teams.TeamName, dbo.Leagues.LeagueID, dbo.Divisions.DivisionTitle, m1.Season, m1.MatchType");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"ALTER VIEW StandingsBySeasonAndMatchType
AS
SELECT        dbo.Teams.TeamAbbreviation, dbo.Teams.TeamName, dbo.Leagues.LeagueID, dbo.Divisions.DivisionTitle, YEAR(dbo.MatchResults.MatchDate) AS Season, dbo.MatchResults.MatchType, 
                         COUNT(CASE WHEN Winner = TeamAbbreviation THEN 1 ELSE NULL END) AS W, COUNT(CASE WHEN Loser = TeamAbbreviation THEN 1 ELSE NULL END) AS L, COUNT(CASE WHEN Winner = TeamAbbreviation AND 
                         HomeTeam = TeamAbbreviation THEN 1 ELSE NULL END) AS HW, COUNT(CASE WHEN Loser = TeamAbbreviation AND HomeTeam = TeamAbbreviation THEN 1 ELSE NULL END) AS HL, 
                         COUNT(CASE WHEN Winner = TeamAbbreviation AND AwayTeam = TeamAbbreviation THEN 1 ELSE NULL END) AS AW, COUNT(CASE WHEN Loser = TeamAbbreviation AND AwayTeam = TeamAbbreviation THEN 1 ELSE NULL 
                         END) AS AL
FROM            dbo.Teams INNER JOIN
                         dbo.Divisions ON dbo.Teams.TeamDivision = dbo.Divisions.DivisionNumber INNER JOIN
                         dbo.Leagues ON dbo.Divisions.League = dbo.Leagues.LeagueID LEFT OUTER JOIN
                         dbo.MatchResults ON dbo.Teams.TeamAbbreviation = dbo.MatchResults.AwayTeam OR dbo.Teams.TeamAbbreviation = dbo.MatchResults.HomeTeam
GROUP BY dbo.Teams.TeamAbbreviation, dbo.Teams.TeamName, dbo.Leagues.LeagueID, dbo.Divisions.DivisionTitle, YEAR(dbo.MatchResults.MatchDate), dbo.MatchResults.MatchType");
		}
	}
}
