using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedViewPitchingStatsGroupedByYearAndMatchType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
WHERE        CurrentPlayerStatus = 2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW PlayerPitchingStatsByYearAndMatchType AS
SELECT        t1.*, ISNULL(GamesPlayed, 0) AS GamesPlayed, SHO, QS, CG, W, L, SV, HLD, TGP, GS
FROM            PlayersInTeams p INNER JOIN
                         InGamePitchingStatsByYearAndMatchType t1 ON p.PlayerId = t1.PlayerID LEFT JOIN
                         CountOfMatchesPlayedForPitcher t2 ON t1.PlayerID = t2.PlayerID AND t1.Season = t2.Season AND t1.MatchType = t2.MatchType INNER JOIN
                         CountOfMatchesPlayedByTeam t3 ON p.TeamID = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType INNER JOIN
                         PitcherResultsGroupedByPitcher t4 ON t1.PlayerID = t4.PlayerID AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType INNER JOIN
                         StartingPitchers t5 ON t1.PlayerID = t5.PlayerID AND t1.Season = t5.Season AND t1.MatchType = t5.MatchType
WHERE        InTeamStatus != 0
UNION
SELECT        t1.*, ISNULL(GamesPlayed, 0), SHO, QS, CG, W, L, SV, HLD, 1, GS
FROM            Players p INNER JOIN
                         InGamePitchingStatsByYearAndMatchType t1 ON p.PlayerId = t1.PlayerID INNER JOIN
                         CountOfMatchesPlayedForPitcher t2 ON t1.PlayerID = t2.PlayerID AND t1.Season = t2.Season AND t1.MatchType = t2.MatchType INNER JOIN
                         PitcherResultsGroupedByPitcher t4 ON t1.PlayerID = t4.PlayerID AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType INNER JOIN
                         StartingPitchers t5 ON t1.PlayerID = t5.PlayerID AND t1.Season = t5.Season AND t1.MatchType = t5.MatchType
WHERE        CurrentPlayerStatus = 2");
        }
    }
}
