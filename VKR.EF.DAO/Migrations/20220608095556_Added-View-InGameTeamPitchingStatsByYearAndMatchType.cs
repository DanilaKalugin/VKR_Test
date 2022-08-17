using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedViewInGameTeamPitchingStatsByYearAndMatchType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW InGameTeamPitchingStatsByYearAndMatchType
AS
SELECT        dbo.Teams.TeamAbbreviation, dbo.Matches.MatchType, YEAR(dbo.Matches.MatchDate) AS Season, 
				COUNT(CASE WHEN AtBatResult = 1 THEN 1 ELSE NULL END) AS K,	
				ISNULL(SUM(dbo.ExpandedAtBats.Outs), 0) AS Outs, 
				COUNT(CASE WHEN AtBatResult = 13 THEN 1 ELSE NULL END) AS R, 
				COUNT(CASE WHEN AtBatResult = 2 THEN 1 ELSE NULL END) AS BB, 
				COUNT(CASE WHEN AtBatResult = 7 THEN 1 ELSE NULL END) AS [1B], 
				COUNT(CASE WHEN AtBatResult = 8 THEN 1 ELSE NULL END) AS [2B], 
				COUNT(CASE WHEN AtBatResult = 9 THEN 1 ELSE NULL END) AS [3B], 
				COUNT(CASE WHEN AtBatResult = 10 THEN 1 ELSE NULL END) AS HR, 
				COUNT(CASE WHEN AtBatResult <> 13 THEN 1 ELSE NULL END) AS TBF,
				COUNT(CASE WHEN AtBatResult = 3 THEN 1 ELSE NULL END) AS HBP, 
				COUNT(CASE WHEN AtBatResult = 14 THEN 1 ELSE NULL END) AS SF, 
				COUNT(CASE WHEN AtBatResult = 15 THEN 1 ELSE NULL END) AS SAC, 
				COUNT(CASE WHEN AtBatResult = 11 THEN 1 ELSE NULL END) AS SB, 
				COUNT(CASE WHEN AtBatResult = 12 THEN 1 ELSE NULL END) AS CS, 
				COUNT(CASE WHEN AtBatResult = 5 AND Outs = 1 THEN 1 ELSE NULL END) AS [GO], 
				COUNT(CASE WHEN AtBatResult = 4 THEN 1 ELSE NULL END) AS AO, 
				COUNT(CASE WHEN AtBatResult = 5 AND Outs = 2 THEN 1 ELSE NULL END) AS GIDP
FROM            dbo.Teams INNER JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Defense = dbo.Teams.TeamAbbreviation INNER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.ExpandedAtBats.Match
GROUP BY dbo.Teams.TeamAbbreviation, dbo.Matches.MatchType, YEAR(dbo.Matches.MatchDate)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW InGameTeamPitchingStatsByYearAndMatchType");
        }
    }
}
