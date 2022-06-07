using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedViewPitcherResultsGroupedByPitcher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW PitcherResultsGroupedByPitcher
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view PitcherResultsGroupedByPitcher");
        }
    }
}
