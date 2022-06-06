using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddViewCountOfMatchesPlayedForPitcher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW CountOfMatchesPlayedForPitcher
AS
SELECT        dbo.PlayersInTeams.PlayerID, MatchType, YEAR(MatchDate) As Season, COUNT(dbo.LineupsForMatches.MatchID) AS GamesPlayed
FROM            dbo.Matches INNER JOIN
                         dbo.LineupsForMatches ON dbo.Matches.MatchID = dbo.LineupsForMatches.MatchID RIGHT OUTER JOIN
                         dbo.PlayersInTeams ON dbo.LineupsForMatches.PlayerInTeamID = dbo.PlayersInTeams.PlayerInTeamID
WHERE        (dbo.LineupsForMatches.NumberInLineup = 10)
GROUP BY dbo.PlayersInTeams.PlayerID, MatchType, YEAR(MatchDate)"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view CountOfMatchesPlayedForPitcher");
        }
    }
}
