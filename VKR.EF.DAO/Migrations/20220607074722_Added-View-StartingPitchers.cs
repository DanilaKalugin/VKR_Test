using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedViewStartingPitchers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW StartingPitchers
AS
SELECT        dbo.PlayersInTeams.PlayerID, MatchType, YEAR(MatchDate) As Season, COUNT(dbo.LineupsForMatches.MatchId) AS GS
FROM            dbo.LineupsForMatches INNER JOIN
                         dbo.PlayersInTeams ON dbo.PlayersInTeams.PlayerInTeamID = dbo.LineupsForMatches.PlayerInTeamID RIGHT OUTER JOIN
                         dbo.Players ON dbo.PlayersInTeams.PlayerID = dbo.Players.PlayerID
						 INNER JOIN Matches On Matches.MatchID = LineupsForMatches.MatchID
WHERE        (dbo.LineupsForMatches.ID IN
(SELECT        MIN(ID)
                               FROM            dbo.LineupsForMatches AS LineupsForMatches_1 INNER JOIN
                                                         dbo.PlayersInTeams AS PlayersInTeams_1 ON PlayersInTeams_1.PlayerInTeamID = LineupsForMatches_1.PlayerInTeamID 
													INNER JOIN
                                                         dbo.Matches ON LineupsForMatches_1.MatchId = dbo.Matches.MatchID
                               WHERE        (LineupsForMatches_1.NumberInLineup = 10)
                               GROUP BY LineupsForMatches_1.MatchId, PlayersInTeams_1.TeamID))
GROUP BY dbo.PlayersInTeams.PlayerID, MatchType, YEAR(MatchDate)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view StartingPitchers");
        }
    }
}
