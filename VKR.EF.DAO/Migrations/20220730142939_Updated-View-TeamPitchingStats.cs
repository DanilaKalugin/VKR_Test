using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedViewTeamPitchingStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW TeamPitchingStatsByYearAndMatchType AS
                SELECT        t1.TeamAbbreviation, t1.MatchType, t1.Season, t1.K, t1.Outs, t1.R, t1.BB, 
                              t1.[1B], t1.[2B], t1.[3B], t1.HR, t1.TBF, t1.HBP, t1.SF, t1.SAC, t1.SB, 
                              t1.CS, t1.[GO], t1.AO, t1.GIDP, t3.TGP AS GamesPlayed, t3.TGP, t4.SHO, t4.QS, t4.CG, 
                         t4.W, t4.L, t4.SV, t4.HLD, t3.TGP AS GS
FROM            dbo.InGameTeamPitchingStatsByYearAndMatchType AS t1 INNER JOIN
                         dbo.CountOfMatchesPlayedByTeam AS t3 ON t1.TeamAbbreviation = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType INNER JOIN
                         dbo.PitcherResultsGroupedByTeam AS t4 ON t1.TeamAbbreviation = t4.TeamId AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW TeamPitchingStatsByYearAndMatchType AS
SELECT        t1.TeamAbbreviation, t1.MatchType, t1.Season, t1.K, t1.Outs, t1.R, t1.BB, t1.[1B], t1.[2B], t1.[3B], t1.HR, t1.TBF, t1.HBP, t1.SF, t1.SAC, t1.SB, t1.CS, t1.GO, t1.AO, t1.GIDP, t3.TGP AS GamesPlayed, t3.TGP, t4.SHO, t4.QS, t4.CG, 
                         t4.W, t4.L, t4.SV, t4.HLD
FROM            dbo.InGameTeamPitchingStatsByYearAndMatchType AS t1 INNER JOIN
                         dbo.CountOfMatchesPlayedByTeam AS t3 ON t1.TeamAbbreviation = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType INNER JOIN
                         dbo.PitcherResultsGroupedByTeam AS t4 ON t1.TeamAbbreviation = t4.TeamId AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType");
        }
    }
}
