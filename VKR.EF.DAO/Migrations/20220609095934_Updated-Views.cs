using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
migrationBuilder.Sql(
                @"ALTER VIEW InGameBattingStats
AS
SELECT        dbo.Players.PlayerID, m1.MatchType, m1.Season, 
						 COUNT(CASE WHEN AtBatResult = 1 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS K, 
                         COUNT(CASE WHEN AtBatResult = 2 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS BB, 
						 COUNT(CASE WHEN AtBatResult = 3 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS HBP, 
						 COUNT(CASE WHEN AtBatResult = 4 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS AO, 
                         COUNT(CASE WHEN AtBatResult = 5 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS [GO], 
						 COUNT(CASE WHEN AtBatResult = 6 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS PO, 
						 COUNT(CASE WHEN AtBatResult = 7 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS [1B], 
                         COUNT(CASE WHEN AtBatResult = 8 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS [2B], 
						 COUNT(CASE WHEN AtBatResult = 9 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS [3B], 
						 COUNT(CASE WHEN AtBatResult = 10 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS HR, 
                         COUNT(CASE WHEN AtBatResult = 11 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS SB, 
						 COUNT(CASE WHEN AtBatResult = 12 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS CS, 
						 COUNT(CASE WHEN AtBatResult = 13 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS R, 
                         COUNT(CASE WHEN AtBatResult = 14 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS SF, 
						 COUNT(CASE WHEN AtBatResult = 15 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS SAC, 
						 COUNT(CASE WHEN (AtBatResult < 11 OR AtBatResult > 13) AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS PA, 
						 COUNT(CASE WHEN AtBatResult = 5 AND Outs = 2 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS GIDP, 
						 ISNULL(SUM(CASE WHEN Outs <> 2 AND m1.Season = YEAR(MatchDate) THEN dbo.ExpandedAtBats.RBI ELSE 0 END), 0) AS RBI
FROM            dbo.Players Cross JOIN combinationsOfYearAndMatchType m1
						LEFT OUTER JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Batter = dbo.Players.PlayerID LEFT JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.ExpandedAtBats.Match AND m1.MatchType = matches.MatchType
GROUP BY dbo.Players.PlayerID, m1.MatchType, m1.Season"
            );

            migrationBuilder.Sql(@"ALTER VIEW RunsAgainstByTeamSeasonAndMatchType AS
SELECT        dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season, COUNT(CASE WHEN AtBatResult = 13 AND m1.Season = Year(matchDate) THEN 1 ELSE NULL END) AS RS
FROM            dbo.Teams CROSS JOIN CombinationsOfYearAndMatchType m1
						  LEFT JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Defense = dbo.Teams.TeamAbbreviation LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.ExpandedAtBats.Match AND m1.MatchType = Matches.MatchType
GROUP BY dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season");

            migrationBuilder.Sql(@"ALTER VIEW RunsScoredByTeamSeasonAndMatchType AS
SELECT        dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season, COUNT(CASE WHEN AtBatResult = 13 AND m1.Season = Year(matchDate) THEN 1 ELSE NULL END) AS RS
FROM            dbo.Teams CROSS JOIN CombinationsOfYearAndMatchType m1
						  LEFT JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Offense = dbo.Teams.TeamAbbreviation LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.ExpandedAtBats.Match AND m1.MatchType = Matches.MatchType
GROUP BY dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"ALTER VIEW InGameBattingStats
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

            migrationBuilder.Sql(@"CREATE VIEW RunsAgainstByTeamSeasonAndMatchType AS
SELECT        dbo.Teams.TeamAbbreviation, MatchType, Year(MatchDate) As Season, COUNT(CASE WHEN AtBatResult = 13 THEN 1 ELSE NULL END) AS RS
FROM            dbo.Matches INNER JOIN
                         dbo.ExpandedAtBats ON dbo.Matches.MatchID = dbo.ExpandedAtBats.Match RIGHT OUTER JOIN
                         dbo.Teams ON dbo.ExpandedAtBats.Defense = dbo.Teams.TeamAbbreviation
GROUP BY dbo.Teams.TeamAbbreviation, MatchType, Year(MatchDate)");

            migrationBuilder.Sql(@"CREATE VIEW RunsScoredByTeamSeasonAndMatchType AS
SELECT        dbo.Teams.TeamAbbreviation, MatchType, Year(MatchDate) As Season, COUNT(CASE WHEN AtBatResult = 13 THEN 1 ELSE NULL END) AS RS
FROM            dbo.Matches INNER JOIN
                         dbo.ExpandedAtBats ON dbo.Matches.MatchID = dbo.ExpandedAtBats.Match RIGHT OUTER JOIN
                         dbo.Teams ON dbo.ExpandedAtBats.Defense = dbo.Teams.TeamAbbreviation
GROUP BY dbo.Teams.TeamAbbreviation, MatchType, Year(MatchDate)");
        }
    }
}
