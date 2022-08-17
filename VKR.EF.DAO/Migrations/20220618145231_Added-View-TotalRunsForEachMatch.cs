using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedViewTotalRunsForEachMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW TotalRunsForEachMatch
AS
SELECT MatchID, Sum(CASE WHEN TeamId = AwayTeam THEN RBI ELSE 0 END) AS AwayRuns, Sum(CASE WHEN TeamId = HomeTeam THEN RBI ELSE 0 END) AS HomeRuns, Max(Inning) As Inning
FROM            Matches INNER JOIN AtBats ON MatchId = Match
						INNER JOIN PlayersInTeams ON PlayerInTeamID = Batter
GROUP BY MatchID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW TotalRunsForEachMatch");
        }
    }
}
