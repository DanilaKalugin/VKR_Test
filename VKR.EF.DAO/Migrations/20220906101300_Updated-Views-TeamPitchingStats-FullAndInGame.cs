using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedViewsTeamPitchingStatsFullAndInGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW InGameTeamPitchingStatsByYearAndMatchType AS
SELECT        dbo.PlayersInTeams.TeamId, m1.MatchType, m1.Season, 
COUNT(CASE WHEN AtBatResult = 1 AND m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN 1 ELSE NULL END) AS K, 
ISNULL(SUM(CASE WHEN m1.Season = matches.Season AND m1.MatchType = matches.MatchType THEN dbo.AtBats.Outs ELSE 0 END), 0) AS Outs, 
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
FROM            dbo.PlayersInTeams LEFT OUTER JOIN
                         dbo.AtBats ON dbo.AtBats.Pitcher = dbo.PlayersInTeams.PlayerInTeamID LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.AtBats.Match CROSS JOIN
                         dbo.CombinationsOfYearAndMatchType AS m1
GROUP BY dbo.PlayersInTeams.TeamId, m1.MatchType, m1.Season
");

            migrationBuilder.Sql(@"ALTER VIEW TeamPitchingStatsByYearAndMatchType AS
SELECT        t1.*, t3.TGP AS GamesPlayed, t3.TGP, t4.SHO, t4.QS, t4.CG, t4.W, t4.L, t4.SV, t4.HLD, t6.R, t6.ER
FROM            dbo.InGameTeamPitchingStatsByYearAndMatchType AS t1 INNER JOIN
                         dbo.CountOfMatchesPlayedByTeam AS t3 ON t1.TeamId = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType INNER JOIN
                         dbo.PitcherResultsGroupedByTeam AS t4 ON t1.TeamId = t4.TeamId AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType INNER JOIN
                         dbo.TeamPitchingRunsByYearAndMatchType AS t6 ON t1.TeamId = t6.TeamAbbreviation AND t1.Season = t6.Season AND t1.MatchType = t6.MatchType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
migrationBuilder.Sql(@"ALTER VIEW InGameTeamPitchingStatsByYearAndMatchType AS
SELECT        dbo.PlayersInTeams.TeamId, m1.MatchType, m1.Season, COUNT(CASE WHEN AtBatResult = 1 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS K, 
                         COUNT(CASE WHEN AtBatResult = 2 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS BB, COUNT(CASE WHEN AtBatResult = 3 AND 
                         m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS HBP, COUNT(CASE WHEN AtBatResult = 4 AND m1.Season = matches.Season AND 
                         m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS AO, COUNT(CASE WHEN AtBatResult = 5 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) 
                         AS GO, COUNT(CASE WHEN AtBatResult = 6 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS PO, COUNT(CASE WHEN AtBatResult = 7 AND 
                         m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS [1B], COUNT(CASE WHEN AtBatResult = 8 AND m1.Season = matches.Season AND 
                         m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS [2B], COUNT(CASE WHEN AtBatResult = 9 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) 
                         AS [3B], COUNT(CASE WHEN AtBatResult = 10 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS HR, COUNT(CASE WHEN AtBatResult = 11 AND 
                         m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS SB, COUNT(CASE WHEN AtBatResult = 12 AND m1.Season = matches.Season AND 
                         m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS CS, COUNT(CASE WHEN AtBatResult = 14 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) 
                         AS SF, COUNT(CASE WHEN AtBatResult = 15 AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS SAC, COUNT(CASE WHEN (AtBatResult < 11 OR
                         AtBatResult > 13) AND m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS PA, COUNT(CASE WHEN AtBatResult = 5 AND Outs = 2 AND m1.Season = matches.Season AND 
                         m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS GIDP, ISNULL(SUM(CASE WHEN Outs <> 2 AND m1.Season = matches.Season AND 
                         m1.MatchType = dbo.Matches.MatchType THEN dbo.AtBats.RBI ELSE 0 END), 0) AS RBI
FROM            dbo.PlayersInTeams LEFT OUTER JOIN
                         dbo.AtBats ON dbo.AtBats.Pitcher = dbo.PlayersInTeams.PlayerInTeamID LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.AtBats.Match CROSS JOIN
                         dbo.CombinationsOfYearAndMatchType AS m1
GROUP BY dbo.PlayersInTeams.TeamId, m1.MatchType, m1.Season
");

            migrationBuilder.Sql(@"ALTER VIEW TeamPitchingStatsByYearAndMatchType AS
SELECT        t1.TeamId AS TeamAbbreviation, t1.MatchType, t1.Season, t1.K, t1.BB AS Outs, t1.HBP AS BB, t1.AO AS [1B], t1.GO AS [2B], t1.PO AS [3B], t1.[1B] AS HR, t1.[2B] AS TBF, t1.[3B] AS HBP, t1.HR AS SF, t1.SB AS SAC, t1.CS AS SB, 
                         t1.SF AS CS, t1.SAC AS GO, t1.PA AS AO, t1.GIDP, t1.RBI AS GamesPlayed, t3.TGP, t3.TGP AS SHO, t4.SHO AS QS, t4.QS AS CG, t4.CG AS W, t4.W AS L, t4.L AS SV, t4.SV AS HLD, t4.HLD AS GS, t3.TGP AS R, t6.R AS ER, 
                         t6.ER
FROM            dbo.InGameTeamPitchingStatsByYearAndMatchType AS t1 INNER JOIN
                         dbo.CountOfMatchesPlayedByTeam AS t3 ON t1.TeamAbbreviation = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType INNER JOIN
                         dbo.PitcherResultsGroupedByTeam AS t4 ON t1.TeamAbbreviation = t4.TeamId AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType INNER JOIN
                         dbo.TeamPitchingRunsByYearAndMatchType AS t6 ON t1.TeamAbbreviation = t6.TeamAbbreviation AND t1.Season = t6.Season AND t1.MatchType = t6.MatchType");
        }
    }
}
