using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedViewPlayerPitchingStatsByYearAndMatchType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW PlayerPitchingStatsByYearAndMatchType
AS
SELECT        t1.*, GamesPlayed, SHO, QS, CG, W, L, SV, HLD, TGP
FROM            InGamePitchingStatsByYearAndMatchType t1 
				INNER JOIN CountOfMatchesPlayed t2 ON t1.PlayerID = t2.PlayerID AND t1.Season = t2.Season AND t1.MatchType = t2.MatchType 
				INNER JOIN PlayersInTeams p ON p.PlayerId = t1.PlayerID
				INNER JOIN CountOfMatchesPlayedByTeam t3 ON p.TeamID = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType  
				INNER JOIN PitcherResultsGroupedByPitcher t4 ON t1.PlayerID = t4.PlayerID AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType 
WHERE        InTeamStatus != 0
UNION
SELECT        t1.*, GamesPlayed, SHO, QS, CG, W, L, SV, HLD, 1
FROM            InGamePitchingStatsByYearAndMatchType t1 
				INNER JOIN CountOfMatchesPlayed t2 ON t1.PlayerID = t2.PlayerID AND t1.Season = t2.Season AND t1.MatchType = t2.MatchType 
				INNER JOIN Players p ON p.PlayerId = t1.PlayerID
				INNER JOIN PitcherResultsGroupedByPitcher t4 ON t1.PlayerID = t4.PlayerID AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType 
WHERE        CurrentPlayerStatus = 2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW PlayerPitchingStatsByYearAndMatchType");
        }
    }
}
