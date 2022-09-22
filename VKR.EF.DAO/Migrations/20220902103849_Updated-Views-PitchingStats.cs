using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedViewsPitchingStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW PlayerPitchingStatsByYearAndMatchType AS
SELECT        t1.*, ISNULL(GamesPlayed, 0) AS GamesPlayed, SHO, QS, CG, W, L, SV, HLD, TGP, ISNULL(GS, 0) AS GS, R, ER
FROM            PlayersInTeams p INNER JOIN
                         InGamePitchingStatsByYearAndMatchType t1 ON p.PlayerId = t1.PlayerID LEFT JOIN
                         CountOfMatchesPlayedForPitcher t2 ON t1.PlayerID = t2.PlayerID AND t1.Season = t2.Season AND t1.MatchType = t2.MatchType INNER JOIN
                         CountOfMatchesPlayedByTeam t3 ON p.TeamID = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType INNER JOIN
                         PitcherResultsGroupedByPitcher t4 ON t1.PlayerID = t4.PlayerID AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType INNER JOIN 
						 PlayerPitchingRunsByYearAndMatchType t6 ON t1.PlayerID = t6.PlayerID AND t1.Season = t6.Season AND t1.MatchType = t6.MatchType LEFT JOIN
                         StartingPitchers t5 ON t1.PlayerID = t5.PlayerID AND t1.Season = t5.Season AND t1.MatchType = t5.MatchType 
WHERE        InTeamStatus != 0
UNION
SELECT        t1.*, ISNULL(GamesPlayed, 0), SHO, QS, CG, W, L, SV, HLD, 1, ISNULL(GS, 0), R, ER
FROM            Players p INNER JOIN
                         InGamePitchingStatsByYearAndMatchType t1 ON p.PlayerId = t1.PlayerID LEFT JOIN
                         CountOfMatchesPlayedForPitcher t2 ON t1.PlayerID = t2.PlayerID AND t1.Season = t2.Season AND t1.MatchType = t2.MatchType INNER JOIN
                         PitcherResultsGroupedByPitcher t4 ON t1.PlayerID = t4.PlayerID AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType INNER JOIN 
						 PlayerPitchingRunsByYearAndMatchType t6 ON t1.PlayerID = t6.PlayerID AND t1.Season = t6.Season AND t1.MatchType = t6.MatchType LEFT JOIN
                         StartingPitchers t5 ON t1.PlayerID = t5.PlayerID AND t1.Season = t5.Season AND t1.MatchType = t5.MatchType
WHERE        CurrentPlayerStatus != 1
");

			migrationBuilder.Sql(@"ALTER VIEW TeamPitchingStatsByYearAndMatchType AS
SELECT        t1.*, t3.TGP AS GamesPlayed, t3.TGP, t4.SHO, t4.QS, t4.CG, 
                         t4.W, t4.L, t4.SV, t4.HLD, t3.TGP AS GS, R, ER
FROM            dbo.InGameTeamPitchingStatsByYearAndMatchType AS t1 INNER JOIN
                         dbo.CountOfMatchesPlayedByTeam AS t3 ON t1.TeamAbbreviation = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType INNER JOIN
                         dbo.PitcherResultsGroupedByTeam AS t4 ON t1.TeamAbbreviation = t4.TeamId AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType INNER JOIN 
						 TeamPitchingRunsByYearAndMatchType t6 ON t1.TeamAbbreviation = t6.TeamAbbreviation AND t1.Season = t6.Season AND t1.MatchType = t6.MatchType
");
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW PlayerPitchingStatsByYearAndMatchType AS
SELECT        t1.*, ISNULL(GamesPlayed, 0) AS GamesPlayed, SHO, QS, CG, W, L, SV, HLD, TGP, ISNULL(GS, 0) AS GS
FROM            PlayersInTeams p INNER JOIN
                         InGamePitchingStatsByYearAndMatchType t1 ON p.PlayerId = t1.PlayerID LEFT JOIN
                         CountOfMatchesPlayedForPitcher t2 ON t1.PlayerID = t2.PlayerID AND t1.Season = t2.Season AND t1.MatchType = t2.MatchType INNER JOIN
                         CountOfMatchesPlayedByTeam t3 ON p.TeamID = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType INNER JOIN
                         PitcherResultsGroupedByPitcher t4 ON t1.PlayerID = t4.PlayerID AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType LEFT JOIN
                         StartingPitchers t5 ON t1.PlayerID = t5.PlayerID AND t1.Season = t5.Season AND t1.MatchType = t5.MatchType
WHERE        InTeamStatus != 0
UNION
SELECT        t1.*, ISNULL(GamesPlayed, 0), SHO, QS, CG, W, L, SV, HLD, 1, ISNULL(GS, 0)
FROM            Players p INNER JOIN
                         InGamePitchingStatsByYearAndMatchType t1 ON p.PlayerId = t1.PlayerID LEFT JOIN
                         CountOfMatchesPlayedForPitcher t2 ON t1.PlayerID = t2.PlayerID AND t1.Season = t2.Season AND t1.MatchType = t2.MatchType INNER JOIN
                         PitcherResultsGroupedByPitcher t4 ON t1.PlayerID = t4.PlayerID AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType LEFT JOIN
                         StartingPitchers t5 ON t1.PlayerID = t5.PlayerID AND t1.Season = t5.Season AND t1.MatchType = t5.MatchType
WHERE        CurrentPlayerStatus = 2
");

            migrationBuilder.Sql(@"ALTER VIEW TeamPitchingStatsByYearAndMatchType AS
SELECT        t1.TeamAbbreviation, t1.MatchType, t1.Season, t1.K, t1.Outs, t1.R, t1.BB, t1.[1B], t1.[2B], t1.[3B], t1.HR, t1.TBF, t1.HBP, t1.SF, t1.SAC, t1.SB, t1.CS, t1.GO, t1.AO, t1.GIDP, t3.TGP AS GamesPlayed, t3.TGP, t4.SHO, t4.QS, t4.CG, 
                         t4.W, t4.L, t4.SV, t4.HLD, t3.TGP AS GS
FROM            dbo.InGameTeamPitchingStatsByYearAndMatchType AS t1 INNER JOIN
                         dbo.CountOfMatchesPlayedByTeam AS t3 ON t1.TeamAbbreviation = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType INNER JOIN
                         dbo.PitcherResultsGroupedByTeam AS t4 ON t1.TeamAbbreviation = t4.TeamId AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType
");
        }
    }
}
