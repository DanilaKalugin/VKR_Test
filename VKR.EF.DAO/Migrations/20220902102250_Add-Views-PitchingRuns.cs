using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddViewsPitchingRuns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW InGamePitchingStatsByYearAndMatchType AS
SELECT        dbo.Players.PlayerID, m1.MatchType, m1.Season, 
						COUNT(CASE WHEN AtBatResult = 1 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS K, 
                        ISNULL(SUM(CASE WHEN m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN dbo.ExpandedAtBats.Outs ELSE 0 END), 0) AS Outs,
						COUNT(CASE WHEN AtBatResult = 2 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS BB, 
						COUNT(CASE WHEN AtBatResult = 7 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS [1B], 
                        COUNT(CASE WHEN AtBatResult = 8 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS [2B], 
						COUNT(CASE WHEN AtBatResult = 9 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS [3B], 
						COUNT(CASE WHEN AtBatResult = 10 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS HR, 
						COUNT(CASE WHEN (AtBatResult < 11 OR AtBatResult > 13) AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS TBF, 
						COUNT(CASE WHEN AtBatResult = 3 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS HBP, 
						COUNT(CASE WHEN AtBatResult = 14 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS SF, 
                        COUNT(CASE WHEN AtBatResult = 15 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS SAC, 
						COUNT(CASE WHEN AtBatResult = 11 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS SB, 
						COUNT(CASE WHEN AtBatResult = 12 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS CS, 
						COUNT(CASE WHEN AtBatResult = 5 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType AND Outs = 1 THEN 1 ELSE NULL END) AS [GO], 
						COUNT(CASE WHEN AtBatResult = 4 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS AO, 
						COUNT(CASE WHEN AtBatResult = 5 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType AND Outs = 2 THEN 1 ELSE NULL END) AS GIDP
FROM            dbo.Players CROSS JOIN
                         dbo.CombinationsOfYearAndMatchType AS m1 LEFT OUTER JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Pitcher = dbo.Players.PlayerID LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.ExpandedAtBats.Match
GROUP BY dbo.Players.PlayerID, m1.MatchType, m1.Season
");

            migrationBuilder.Sql(@"ALTER VIEW InGameTeamPitchingStatsByYearAndMatchType AS
SELECT        dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season, 
						COUNT(CASE WHEN AtBatResult = 1 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS K, 
                        ISNULL(SUM(CASE WHEN m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN dbo.ExpandedAtBats.Outs ELSE 0 END), 0) AS Outs,
						COUNT(CASE WHEN AtBatResult = 2 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS BB, 
						COUNT(CASE WHEN AtBatResult = 7 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS [1B], 
                        COUNT(CASE WHEN AtBatResult = 8 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS [2B], 
						COUNT(CASE WHEN AtBatResult = 9 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS [3B], 
						COUNT(CASE WHEN AtBatResult = 10 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS HR, 
						COUNT(CASE WHEN (AtBatResult < 11 OR AtBatResult > 13) AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS TBF, 
						COUNT(CASE WHEN AtBatResult = 3 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS HBP, 
						COUNT(CASE WHEN AtBatResult = 14 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS SF, 
                        COUNT(CASE WHEN AtBatResult = 15 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS SAC, 
						COUNT(CASE WHEN AtBatResult = 11 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS SB, 
						COUNT(CASE WHEN AtBatResult = 12 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS CS, 
						COUNT(CASE WHEN AtBatResult = 5 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType AND Outs = 1 THEN 1 ELSE NULL END) AS [GO], 
						COUNT(CASE WHEN AtBatResult = 4 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS AO, 
						COUNT(CASE WHEN AtBatResult = 5 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType AND Outs = 2 THEN 1 ELSE NULL END) AS GIDP
FROM            dbo.Teams CROSS JOIN
                         dbo.CombinationsOfYearAndMatchType AS m1 LEFT OUTER JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Defense = TeamAbbreviation LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.ExpandedAtBats.Match AND m1.MatchType = dbo.Matches.MatchType
GROUP BY TeamAbbreviation, m1.MatchType, m1.Season
");

            migrationBuilder.Sql(@"CREATE View PlayerPitchingRunsByYearAndMatchType AS
SELECT        dbo.Players.PlayerID, m1.MatchType, m1.Season, COUNT(CASE WHEN m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS R,
COUNT(CASE WHEN m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType AND IsEarned = 1 THEN 1 ELSE NULL END) AS ER
FROM            dbo.CombinationsOfYearAndMatchType AS m1 CROSS JOIN
                         dbo.Players LEFT OUTER JOIN
                         dbo.PlayersInTeams ON dbo.Players.PlayerID = dbo.PlayersInTeams.PlayerId LEFT OUTER JOIN
                         dbo.Runs ON dbo.Runs.Pitcher = dbo.PlayersInTeams.PlayerInTeamID LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.Runs.Match
GROUP BY dbo.Players.PlayerID, m1.MatchType, m1.Season
");

            migrationBuilder.Sql(@"CREATE View TeamPitchingRunsByYearAndMatchType AS
SELECT        dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season, COUNT(CASE WHEN m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS R,
COUNT(CASE WHEN m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType AND IsEarned = 1 THEN 1 ELSE NULL END) AS ER
FROM            dbo.CombinationsOfYearAndMatchType AS m1 CROSS JOIN
                         dbo.Teams LEFT OUTER JOIN
                         dbo.PlayersInTeams ON dbo.Teams.TeamAbbreviation = dbo.PlayersInTeams.TeamId LEFT OUTER JOIN
                         dbo.Runs ON dbo.Runs.Pitcher = dbo.PlayersInTeams.PlayerInTeamID LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.Runs.Match
GROUP BY dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW InGamePitchingStatsByYearAndMatchType AS
SELECT        dbo.Players.PlayerID, m1.MatchType, m1.Season, COUNT(CASE WHEN AtBatResult = 1 AND m1.Season = YEAR(MatchDate) AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS K, 
                         ISNULL(SUM(CASE WHEN m1.Season = YEAR(MatchDate) AND m1.MatchType = matches.MatchType THEN dbo.ExpandedAtBats.Outs ELSE 0 END), 0) AS Outs, COUNT(CASE WHEN AtBatResult = 13 AND 
                         m1.Season = YEAR(MatchDate) AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS R, COUNT(CASE WHEN AtBatResult = 2 AND m1.Season = YEAR(MatchDate) AND 
                         m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS BB, COUNT(CASE WHEN AtBatResult = 7 AND m1.Season = YEAR(MatchDate) AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS [1B], 
                         COUNT(CASE WHEN AtBatResult = 8 AND m1.Season = YEAR(MatchDate) AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS [2B], COUNT(CASE WHEN AtBatResult = 9 AND m1.Season = YEAR(MatchDate) 
                         AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS [3B], COUNT(CASE WHEN AtBatResult = 10 AND m1.Season = YEAR(MatchDate) AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) 
                         AS HR, COUNT(CASE WHEN (AtBatResult < 11 OR
                         AtBatResult > 13) AND m1.Season = YEAR(MatchDate) AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS TBF, COUNT(CASE WHEN AtBatResult = 3 AND m1.Season = YEAR(MatchDate) AND 
                         m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS HBP, COUNT(CASE WHEN AtBatResult = 14 AND m1.Season = YEAR(MatchDate) AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS SF, 
                         COUNT(CASE WHEN AtBatResult = 15 AND m1.Season = YEAR(MatchDate) AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS SAC, COUNT(CASE WHEN AtBatResult = 11 AND m1.Season = YEAR(MatchDate)
                          AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS SB, COUNT(CASE WHEN AtBatResult = 12 AND m1.Season = YEAR(MatchDate) AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) 
                         AS CS, COUNT(CASE WHEN AtBatResult = 5 AND m1.Season = YEAR(MatchDate) AND m1.MatchType = matches.MatchType AND Outs = 1 THEN 1 ELSE NULL END) AS GO, COUNT(CASE WHEN AtBatResult = 4 AND 
                         m1.Season = YEAR(MatchDate) AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS AO, COUNT(CASE WHEN AtBatResult = 5 AND m1.Season = YEAR(MatchDate) AND 
                         m1.MatchType = matches.MatchType AND Outs = 2 THEN 1 ELSE NULL END) AS GIDP
FROM            dbo.Players CROSS JOIN
                         dbo.CombinationsOfYearAndMatchType AS m1 LEFT OUTER JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Pitcher = dbo.Players.PlayerID LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.ExpandedAtBats.Match AND m1.MatchType = dbo.Matches.MatchType
GROUP BY dbo.Players.PlayerID, m1.MatchType, m1.Season
");

            migrationBuilder.Sql(@"ALTER VIEW InGameTeamPitchingStatsByYearAndMatchType AS
SELECT        dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season, COUNT(CASE WHEN AtBatResult = 1 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS K, ISNULL(SUM(CASE WHEN m1.Season = YEAR(MatchDate) 
                         THEN dbo.ExpandedAtBats.Outs ELSE 0 END), 0) AS Outs, COUNT(CASE WHEN AtBatResult = 13 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS R, COUNT(CASE WHEN AtBatResult = 2 AND 
                         m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS BB, COUNT(CASE WHEN AtBatResult = 7 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS [1B], COUNT(CASE WHEN AtBatResult = 8 AND 
                         m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS [2B], COUNT(CASE WHEN AtBatResult = 9 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS [3B], COUNT(CASE WHEN AtBatResult = 10 AND 
                         m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS HR, COUNT(CASE WHEN (AtBatResult < 11 OR
                         AtBatResult > 13) AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS TBF, COUNT(CASE WHEN AtBatResult = 3 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS HBP, 
                         COUNT(CASE WHEN AtBatResult = 14 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS SF, COUNT(CASE WHEN AtBatResult = 15 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS SAC, 
                         COUNT(CASE WHEN AtBatResult = 11 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS SB, COUNT(CASE WHEN AtBatResult = 12 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) AS CS, 
                         COUNT(CASE WHEN AtBatResult = 5 AND m1.Season = YEAR(MatchDate) AND Outs = 1 THEN 1 ELSE NULL END) AS GO, COUNT(CASE WHEN AtBatResult = 4 AND m1.Season = YEAR(MatchDate) THEN 1 ELSE NULL END) 
                         AS AO, COUNT(CASE WHEN AtBatResult = 5 AND m1.Season = YEAR(MatchDate) AND Outs = 2 THEN 1 ELSE NULL END) AS GIDP
FROM            dbo.Teams CROSS JOIN
                         dbo.CombinationsOfYearAndMatchType AS m1 LEFT OUTER JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Defense = dbo.Teams.TeamAbbreviation LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.ExpandedAtBats.Match AND m1.MatchType = dbo.Matches.MatchType
GROUP BY dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season
");

            migrationBuilder.Sql(@"DROP View PlayerPitchingRunsByYearAndMatchType");

            migrationBuilder.Sql(@"DROP View TeamPitchingRunsByYearAndMatchType");
        }
    }
}
