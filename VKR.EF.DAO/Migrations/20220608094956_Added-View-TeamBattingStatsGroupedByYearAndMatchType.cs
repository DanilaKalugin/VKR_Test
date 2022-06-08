using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedViewTeamBattingStatsGroupedByYearAndMatchType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW TeamBattingStatsByYearAndMatchType
AS
SELECT t1.*, TGP AS GamesPlayed, TGP
FROM InGameTeamBattingStatsByYearAndMatchType t1 INNER JOIN
                CountOfMatchesPlayedByTeam t3 ON t1.TeamAbbreviation = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW TeamBattingStatsByYearAndMatchType");
        }
    }
}
