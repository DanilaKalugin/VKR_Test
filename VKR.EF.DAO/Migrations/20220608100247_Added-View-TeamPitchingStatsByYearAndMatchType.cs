using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedViewTeamPitchingStatsByYearAndMatchType : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW TeamPitchingStatsByYearAndMatchType
AS
SELECT        t1.*, TGP AS GamesPlayed, TGP, SHO, QS, CG, W, L, SV, HLD
FROM            InGameTeamPitchingStatsByYearAndMatchType t1 INNER JOIN
                         CountOfMatchesPlayedByTeam t3 ON t1.TeamAbbreviation = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType INNER JOIN
                         PitcherResultsGroupedByTeam t4 ON t1.TeamAbbreviation = t4.TeamID AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW TeamPitchingStatsByYearAndMatchType");
        }
	}
}
