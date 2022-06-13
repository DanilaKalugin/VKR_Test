using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedViewsCountOfMatchesPlayedByPlayerGroupedByYearAndMatchType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"ALTER VIEW CountOfMatchesPlayed 
AS
SELECT        dbo.PlayersInTeams.PlayerId, m1.MatchType, m1.Season, COUNT(CASE WHEN YEAR(MatchDate) = m1.Season Then LineupsForMatches.MatchID ELSE NULL END) AS GamesPlayed
FROM          dbo.PlayersInTeams 
				CROSS JOIN CombinationsOfYearAndMatchType m1
				LEFT JOIN dbo.LineupsForMatches ON dbo.LineupsForMatches.PlayerInTeamId = dbo.PlayersInTeams.PlayerInTeamID
				LEFT JOIN dbo.Matches ON dbo.Matches.MatchID = dbo.LineupsForMatches.MatchId AND Matches.MatchType = m1.MatchType
WHERE        (dbo.LineupsForMatches.NumberInLineup <> 10)
GROUP BY dbo.PlayersInTeams.PlayerId, m1.MatchType, m1.Season"
            );

            migrationBuilder.Sql(
                @"ALTER VIEW CountOfMatchesPlayedForPitcher 
AS
SELECT        dbo.PlayersInTeams.PlayerId, m1.MatchType, m1.Season, COUNT(CASE WHEN YEAR(MatchDate) = m1.Season Then LineupsForMatches.MatchID ELSE NULL END) AS GamesPlayed
FROM          dbo.PlayersInTeams 
				CROSS JOIN CombinationsOfYearAndMatchType m1
				LEFT JOIN dbo.LineupsForMatches ON dbo.LineupsForMatches.PlayerInTeamId = dbo.PlayersInTeams.PlayerInTeamID
				LEFT JOIN dbo.Matches ON dbo.Matches.MatchID = dbo.LineupsForMatches.MatchId AND Matches.MatchType = m1.MatchType
WHERE        (dbo.LineupsForMatches.NumberInLineup = 10)
GROUP BY dbo.PlayersInTeams.PlayerId, m1.MatchType, m1.Season"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"ALTER VIEW CountOfMatchesPlayed 
AS
SELECT        dbo.PlayersInTeams.PlayerID, MatchType, YEAR(MatchDate) As Season, COUNT(dbo.LineupsForMatches.MatchID) AS GamesPlayed
FROM            dbo.Matches INNER JOIN
                         dbo.LineupsForMatches ON dbo.Matches.MatchID = dbo.LineupsForMatches.MatchID RIGHT OUTER JOIN
                         dbo.PlayersInTeams ON dbo.LineupsForMatches.PlayerInTeamID = dbo.PlayersInTeams.PlayerInTeamID
WHERE        (dbo.LineupsForMatches.NumberInLineup <> 10)
GROUP BY dbo.PlayersInTeams.PlayerID, MatchType, YEAR(MatchDate)"
            );


            migrationBuilder.Sql(
                @"ALTER VIEW CountOfMatchesPlayedForPitcher
AS
SELECT        dbo.PlayersInTeams.PlayerID, MatchType, YEAR(MatchDate) As Season, COUNT(dbo.LineupsForMatches.MatchID) AS GamesPlayed
FROM            dbo.Matches INNER JOIN
                         dbo.LineupsForMatches ON dbo.Matches.MatchID = dbo.LineupsForMatches.MatchID RIGHT OUTER JOIN
                         dbo.PlayersInTeams ON dbo.LineupsForMatches.PlayerInTeamID = dbo.PlayersInTeams.PlayerInTeamID
WHERE        (dbo.LineupsForMatches.NumberInLineup = 10)
GROUP BY dbo.PlayersInTeams.PlayerID, MatchType, YEAR(MatchDate)"
            );
        }
    }
}
