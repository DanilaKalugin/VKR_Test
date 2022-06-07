using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedViewInGameBattingStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW InGameBattingStats
AS
SELECT        TOP (100) PERCENT dbo.Players.PlayerID, MatchType, Year(MatchDate) AS Season, COUNT(CASE WHEN AtBatResult = 1 THEN 1 ELSE NULL END) AS K, COUNT(CASE WHEN AtBatResult = 2 THEN 1 ELSE NULL END) AS BB, 
                         COUNT(CASE WHEN AtBatResult = 3 THEN 1 ELSE NULL END) AS HBP, COUNT(CASE WHEN AtBatResult = 4 THEN 1 ELSE NULL END) AS AO, COUNT(CASE WHEN AtBatResult = 5 THEN 1 ELSE NULL END) AS GO, 
                         COUNT(CASE WHEN AtBatResult = 6 THEN 1 ELSE NULL END) AS PO, COUNT(CASE WHEN AtBatResult = 7 THEN 1 ELSE NULL END) AS [1B], COUNT(CASE WHEN AtBatResult = 8 THEN 1 ELSE NULL END) AS [2B], 
                         COUNT(CASE WHEN AtBatResult = 9 THEN 1 ELSE NULL END) AS [3B], COUNT(CASE WHEN AtBatResult = 10 THEN 1 ELSE NULL END) AS HR, COUNT(CASE WHEN AtBatResult = 11 THEN 1 ELSE NULL END) AS SB, 
                         COUNT(CASE WHEN AtBatResult = 12 THEN 1 ELSE NULL END) AS CS, COUNT(CASE WHEN AtBatResult = 13 THEN 1 ELSE NULL END) AS R, COUNT(CASE WHEN AtBatResult = 14 THEN 1 ELSE NULL END) AS SF, 
                         COUNT(CASE WHEN AtBatResult = 15 THEN 1 ELSE NULL END) AS SAC, COUNT(CASE WHEN AtBatResult < 11 OR
                         AtBatResult > 13 THEN 1 ELSE NULL END) AS PA, COUNT(CASE WHEN AtBatResult = 5 AND Outs = 2 THEN 1 ELSE NULL END) AS GIDP, ISNULL(SUM(CASE WHEN Outs <> 2 THEN dbo.ExpandedAtBats.RBI ELSE 0 END), 0) 
                         AS RBI
FROM            dbo.Players LEFT OUTER JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Batter = dbo.Players.PlayerID
						 INNER JOIN Matches ON MatchID = Match
GROUP BY dbo.Players.PlayerID, MatchType, Year(MatchDate)"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view InGameBattingStats");
        }
    }
}
