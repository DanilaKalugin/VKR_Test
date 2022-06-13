using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedViewsPitcherResultsGroupedByPitcherYearAndMatchType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"ALTER VIEW PitcherResultsGroupedByPitcher AS
SELECT        dbo.PlayersInTeams.PlayerId, m1.MatchType, m1.Season, COUNT(CASE WHEN Shutout = 1 AND m1.Season = Year(MatchDate) THEN 1 ELSE NULL END) AS SHO, 
																	COUNT(CASE WHEN QualityStart = 1 AND m1.Season = Year(MatchDate) THEN 1 ELSE NULL END) AS QS, 
																	COUNT(CASE WHEN CompleteGame = 1 AND m1.Season = Year(MatchDate) THEN 1 ELSE NULL END) AS CG, 
																	COUNT(CASE WHEN MatchResultID = 1 AND m1.Season = Year(MatchDate) THEN 1 ELSE NULL END) AS W, 
																	COUNT(CASE WHEN MatchResultID = 2 AND m1.Season = Year(MatchDate) THEN 1 ELSE NULL END) AS L, 
																	COUNT(CASE WHEN MatchResultID = 3 AND m1.Season = Year(MatchDate) THEN 1 ELSE NULL END) AS SV, 
																	COUNT(CASE WHEN MatchResultID = 4 AND m1.Season = Year(MatchDate) THEN 1 ELSE NULL END) AS HLD
FROM    dbo.PlayersInTeams CROSS JOIN dbo.CombinationsOfYearAndMatchType m1
						  LEFT JOIN dbo.PitcherResults ON dbo.PitcherResults.Pitcher = dbo.PlayersInTeams.PlayerInTeamID 
						  LEFT JOIN dbo.Matches ON dbo.Matches.MatchID = dbo.PitcherResults.Match
												AND m1.MatchType = Matches.MatchType
												AND m1.Season = Year(MatchDate)
GROUP BY dbo.PlayersInTeams.PlayerId, m1.MatchType, m1.Season");

            migrationBuilder.Sql(
                @"ALTER VIEW PitcherResultsGroupedByTeam AS
SELECT        dbo.PlayersInTeams.TeamId, m1.MatchType, m1.Season, COUNT(CASE WHEN Shutout = 1 AND m1.Season = Year(MatchDate) THEN 1 ELSE NULL END) AS SHO, 
																	COUNT(CASE WHEN QualityStart = 1 AND m1.Season = Year(MatchDate) THEN 1 ELSE NULL END) AS QS, 
																	COUNT(CASE WHEN CompleteGame = 1 AND m1.Season = Year(MatchDate) THEN 1 ELSE NULL END) AS CG, 
																	COUNT(CASE WHEN MatchResultID = 1 AND m1.Season = Year(MatchDate) THEN 1 ELSE NULL END) AS W, 
																	COUNT(CASE WHEN MatchResultID = 2 AND m1.Season = Year(MatchDate) THEN 1 ELSE NULL END) AS L, 
																	COUNT(CASE WHEN MatchResultID = 3 AND m1.Season = Year(MatchDate) THEN 1 ELSE NULL END) AS SV, 
																	COUNT(CASE WHEN MatchResultID = 4 AND m1.Season = Year(MatchDate) THEN 1 ELSE NULL END) AS HLD
FROM    dbo.PlayersInTeams CROSS JOIN dbo.CombinationsOfYearAndMatchType m1
						  LEFT JOIN dbo.PitcherResults ON dbo.PitcherResults.Pitcher = dbo.PlayersInTeams.PlayerInTeamID 
						  LEFT JOIN dbo.Matches ON dbo.Matches.MatchID = dbo.PitcherResults.Match
												AND m1.MatchType = Matches.MatchType
												AND m1.Season = Year(MatchDate)
GROUP BY dbo.PlayersInTeams.TeamId, m1.MatchType, m1.Season");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW PitcherResultsGroupedByPitcher
AS
SELECT        dbo.PlayersInTeams.PlayerID, MatchType, YEAR(MatchDate) As Season, 
						COUNT(CASE WHEN Shutout = 1 THEN 1 ELSE NULL END) AS SHO, 
						COUNT(CASE WHEN QualityStart = 1 THEN 1 ELSE NULL END) AS QS, 
                        COUNT(CASE WHEN CompleteGame = 1 THEN 1 ELSE NULL END) AS CG, 
						COUNT(CASE WHEN MatchResultID = 1 THEN 1 ELSE NULL END) AS W, 
						COUNT(CASE WHEN MatchResultID = 2 THEN 1 ELSE NULL END) AS L, 
                        COUNT(CASE WHEN MatchResultID = 3 THEN 1 ELSE NULL END) AS SV, 
						COUNT(CASE WHEN MatchResultID = 4 THEN 1 ELSE NULL END) AS HLD
FROM            dbo.PitcherResults 
						INNER JOIN Matches On Matches.MatchID = PitcherResults.Match INNER JOIN
                         dbo.PlayersInTeams ON dbo.PitcherResults.Pitcher = dbo.PlayersInTeams.PlayerInTeamID
GROUP BY dbo.PlayersInTeams.PlayerID, MatchType, YEAR(MatchDate)");
            
            migrationBuilder.Sql(@"ALTER VIEW PitcherResultsGroupedByTeam
AS
SELECT        dbo.PlayersInTeams.TeamID, MatchType, YEAR(MatchDate) As Season, 
						COUNT(CASE WHEN Shutout = 1 THEN 1 ELSE NULL END) AS SHO, 
						COUNT(CASE WHEN QualityStart = 1 THEN 1 ELSE NULL END) AS QS, 
                        COUNT(CASE WHEN CompleteGame = 1 THEN 1 ELSE NULL END) AS CG, 
						COUNT(CASE WHEN MatchResultID = 1 THEN 1 ELSE NULL END) AS W, 
						COUNT(CASE WHEN MatchResultID = 2 THEN 1 ELSE NULL END) AS L, 
                        COUNT(CASE WHEN MatchResultID = 3 THEN 1 ELSE NULL END) AS SV, 
						COUNT(CASE WHEN MatchResultID = 4 THEN 1 ELSE NULL END) AS HLD
FROM            dbo.PitcherResults 
						INNER JOIN Matches On Matches.MatchID = PitcherResults.Match INNER JOIN
                         dbo.PlayersInTeams ON dbo.PitcherResults.Pitcher = dbo.PlayersInTeams.PlayerInTeamID
GROUP BY dbo.PlayersInTeams.TeamID, MatchType, YEAR(MatchDate)");
        }
    }
}
