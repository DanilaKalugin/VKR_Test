using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddViewRunsByPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW PlayerBattingRunsGroupedBySeasonAndMatchType
AS
SELECT        dbo.Players.PlayerID, m1.MatchType, m1.Season, 
	COUNT(CASE WHEN m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS R
FROM            dbo.CombinationsOfYearAndMatchType AS m1 
						CROSS JOIN dbo.Players
						LEFT OUTER JOIN PlayersInTeams ON players.PlayerID = PlayersInTeams.PlayerId
                         LEFT OUTER JOIN dbo.Runs ON Runner = PlayerInTeamID LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.Runs.Match 
GROUP BY dbo.Players.PlayerID, m1.MatchType, m1.Season
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW PlayerBattingRunsGroupedBySeasonAndMatchType");
        }
    }
}
