using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedViewsTeamStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW TeamBattingStatsByYearAndMatchType AS
SELECT        t1.*, t3.TGP AS GamesPlayed, t2.R
FROM            dbo.InGameTeamBattingStatsByYearAndMatchType AS t1 INNER JOIN
                         dbo.CountOfMatchesPlayedByTeam AS t3 ON t1.TeamId = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType INNER JOIN
						 TeamBattingRunsGroupedBySeasonAndMatchType AS t2 ON t1.TeamID = t2.TeamAbbreviation AND t1.Season = t2.Season AND t1.MatchType = t2.MatchType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
migrationBuilder.Sql(@"ALTER VIEW TeamBattingStatsByYearAndMatchType AS
SELECT        t1.TeamId AS TeamAbbreviation, t1.MatchType, t1.Season, t1.K, t1.BB, t1.HBP, t1.AO, t1.GO, t1.PO, t1.[1B], t1.[2B], t1.[3B], t1.HR, t1.SB, t1.CS, t1.SF AS R, t1.SAC AS SF, t1.PA AS SAC, t1.GIDP AS PA, t1.RBI AS GIDP, 
                         t3.TGP AS RBI, t3.TGP AS GamesPlayed
FROM            dbo.InGameTeamBattingStatsByYearAndMatchType AS t1 INNER JOIN
                         dbo.CountOfMatchesPlayedByTeam AS t3 ON t1.TeamAbbreviation = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType");
        }
    }
}
