using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedViewStartingPitchers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW StartingPitchers
AS
SELECT       dbo.PlayersInTeams.PlayerId, m1.MatchType, m1.Season, COUNT(CASE WHEN Year(MatchDate) = m1.Season THEN dbo.LineupsForMatches.MatchID ELSE NULL END) AS GS
FROM            Players Cross JOIN CombinationsOfYearAndMatchType m1
						LEFT JOIN PlayersInTeams ON dbo.PlayersInTeams.PlayerId = dbo.Players.PlayerID
						LEFT JOIN LineupsForMatches ON dbo.PlayersInTeams.PlayerInTeamID = dbo.LineupsForMatches.PlayerInTeamId
						LEFT JOIN dbo.Matches ON dbo.Matches.MatchID = dbo.LineupsForMatches.MatchId AND Year(Matchdate) = m1.Season AND matches.MatchType = m1.MatchType
WHERE        (dbo.LineupsForMatches.Id IN
                             (SELECT        MIN(LineupsForMatches_1.Id) AS Expr1
                               FROM            dbo.LineupsForMatches AS LineupsForMatches_1 INNER JOIN
                                                         dbo.PlayersInTeams AS PlayersInTeams_1 ON PlayersInTeams_1.PlayerInTeamID = LineupsForMatches_1.PlayerInTeamId INNER JOIN
                                                         dbo.Matches ON LineupsForMatches_1.MatchId = dbo.Matches.MatchID
                               WHERE        (LineupsForMatches_1.NumberInLineup = 10)
                               GROUP BY LineupsForMatches_1.MatchId, PlayersInTeams_1.TeamId))
GROUP BY dbo.PlayersInTeams.PlayerId, m1.MatchType, m1.Season 
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW StartingPitchers
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
    }
}
