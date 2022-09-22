using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdateViewInGameTeamBattingStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW InGameTeamBattingStatsByYearAndMatchType AS
SELECT        dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season, 
COUNT(CASE WHEN AtBatResult = 1 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS K, 
COUNT(CASE WHEN AtBatResult = 2 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS BB, 
COUNT(CASE WHEN AtBatResult = 3 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS HBP, 
COUNT(CASE WHEN AtBatResult = 4 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS AO, 
COUNT(CASE WHEN AtBatResult = 5 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS [GO], 
COUNT(CASE WHEN AtBatResult = 6 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS PO, 
COUNT(CASE WHEN AtBatResult = 7 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS [1B], 
COUNT(CASE WHEN AtBatResult = 8 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS [2B], 
COUNT(CASE WHEN AtBatResult = 9 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS [3B], 
COUNT(CASE WHEN AtBatResult = 10 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS HR, 
COUNT(CASE WHEN AtBatResult = 11 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS SB, 
COUNT(CASE WHEN AtBatResult = 12 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS CS, 
COUNT(CASE WHEN AtBatResult = 14 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS SF, 
COUNT(CASE WHEN AtBatResult = 15 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS SAC, 
COUNT(CASE WHEN (AtBatResult < 11 OR AtBatResult > 13) AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS PA, 
COUNT(CASE WHEN AtBatResult = 5 AND Outs = 2 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS GIDP, 
ISNULL(SUM(CASE WHEN Outs <> 2 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN dbo.ExpandedAtBats.RBI ELSE 0 END), 0) AS RBI
FROM            dbo.Teams CROSS JOIN
                         dbo.CombinationsOfYearAndMatchType AS m1 LEFT OUTER JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Offense = dbo.Teams.TeamAbbreviation LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.ExpandedAtBats.Match
GROUP BY dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
migrationBuilder.Sql(@"ALTER VIEW InGameTeamBattingStatsByYearAndMatchType AS
SELECT        dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season, COUNT(CASE WHEN AtBatResult = 1 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS K, COUNT(CASE WHEN AtBatResult = 2 AND 
                         m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS BB, COUNT(CASE WHEN AtBatResult = 3 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS HBP, COUNT(CASE WHEN AtBatResult = 4 AND 
                         m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS AO, COUNT(CASE WHEN AtBatResult = 5 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS GO, COUNT(CASE WHEN AtBatResult = 6 AND 
                         m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS PO, COUNT(CASE WHEN AtBatResult = 7 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS [1B], COUNT(CASE WHEN AtBatResult = 8 AND 
                         m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS [2B], COUNT(CASE WHEN AtBatResult = 9 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS [3B], COUNT(CASE WHEN AtBatResult = 10 AND 
                         m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS HR, COUNT(CASE WHEN AtBatResult = 11 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS SB, COUNT(CASE WHEN AtBatResult = 12 AND 
                         m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS CS, COUNT(CASE WHEN AtBatResult = 13 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS R, COUNT(CASE WHEN AtBatResult = 14 AND 
                         m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS SF, COUNT(CASE WHEN AtBatResult = 15 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS SAC, COUNT(CASE WHEN (AtBatResult < 11 OR
                         AtBatResult > 13) AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS PA, COUNT(CASE WHEN AtBatResult = 5 AND Outs = 2 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS GIDP, 
                         ISNULL(SUM(CASE WHEN Outs <> 2 AND m1.Season = YEAR(MatchDate) THEN dbo.ExpandedAtBats.RBI ELSE 0 END), 0) AS RBI
FROM            dbo.Teams CROSS JOIN
                         dbo.CombinationsOfYearAndMatchType AS m1 LEFT OUTER JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Offense = dbo.Teams.TeamAbbreviation LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.ExpandedAtBats.Match AND m1.MatchType = dbo.Matches.MatchType
GROUP BY dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season");
        }
    }
}
