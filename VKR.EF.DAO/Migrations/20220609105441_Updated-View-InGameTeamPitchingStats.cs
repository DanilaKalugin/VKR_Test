using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedViewInGameTeamPitchingStats : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW InGameTeamPitchingStatsByYearAndMatchType
AS
SELECT        dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season, COUNT(CASE WHEN AtBatResult = 1 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS K, ISNULL(SUM(CASE WHEN m1.Season = YEAR(MatchDate) 
                         THEN dbo.ExpandedAtBats.Outs ELSE 0 END), 0) AS Outs, COUNT(CASE WHEN AtBatResult = 13 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS R, COUNT(CASE WHEN AtBatResult = 2 AND 
                         m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS BB, COUNT(CASE WHEN AtBatResult = 7 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS [1B], COUNT(CASE WHEN AtBatResult = 8 AND 
                         m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS [2B], COUNT(CASE WHEN AtBatResult = 9 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS [3B], COUNT(CASE WHEN AtBatResult = 10 AND 
                         m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS HR, COUNT(CASE WHEN (AtBatResult < 11 OR AtBatResult > 13) AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS TBF, 
                         COUNT(CASE WHEN AtBatResult = 3 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS HBP, COUNT(CASE WHEN AtBatResult = 14 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS SF, 
                         COUNT(CASE WHEN AtBatResult = 15 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS SAC, COUNT(CASE WHEN AtBatResult = 11 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS SB, 
                         COUNT(CASE WHEN AtBatResult = 12 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS CS, COUNT(CASE WHEN AtBatResult = 5 AND m1.Season = YEAR(MatchDate) AND Outs = 1 THEN 1 ELSE NULL END) 
                         AS GO, COUNT(CASE WHEN AtBatResult = 4 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS AO, COUNT(CASE WHEN AtBatResult = 5 AND m1.Season = YEAR(MatchDate) AND Outs = 2 THEN 1 ELSE NULL 
                         END) AS GIDP
FROM            dbo.Teams CROSS JOIN
                         dbo.CombinationsOfYearAndMatchType AS m1 LEFT OUTER JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Defense = dbo.Teams.TeamAbbreviation LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.ExpandedAtBats.Match AND m1.MatchType = dbo.Matches.MatchType
GROUP BY dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW InGameTeamPitchingStatsByYearAndMatchType
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
	}
}
