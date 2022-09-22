using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdateViewPlayerBattingStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW PlayerBattingStats
AS
SELECT        t1.*, ISNULL(GamesPlayed, 0) AS GamesPlayed, TGP, R
FROM            InGameBattingStats t1 LEFT JOIN
                         CountOfMatchesPlayed t2 ON t1.PlayerID = t2.PlayerID AND t1.Season = t2.Season AND t1.MatchType = t2.MatchType INNER JOIN
                         PlayersInTeams p ON p.PlayerId = t1.PlayerID INNER JOIN
                         CountOfMatchesPlayedByTeam t3 ON p.TeamID = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType INNER JOIN
						 PlayerBattingRunsGroupedBySeasonAndMatchType t4 ON t1.PlayerID = t4.PlayerID AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType
WHERE        InTeamStatus != 0
UNION
SELECT        t1.*, ISNULL(GamesPlayed, 0), 1, R
FROM            InGameBattingStats t1 LEFT JOIN
                         CountOfMatchesPlayed t2 ON t1.PlayerID = t2.PlayerID AND t1.Season = t2.Season AND t1.MatchType = t2.MatchType INNER JOIN
						 PlayerBattingRunsGroupedBySeasonAndMatchType t4 ON t1.PlayerID = t4.PlayerID AND t1.Season = t4.Season AND t1.MatchType = t4.MatchType INNER JOIN
                         Players p1 ON p1.PlayerID = t1.PlayerID
WHERE        CurrentPlayerStatus <> 1
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
migrationBuilder.Sql(@"ALTER VIEW PlayerBattingStats
AS
SELECT        t1.*, ISNULL(GamesPlayed, 0) AS GamesPlayed, TGP
FROM            InGameBattingStats t1 LEFT JOIN
                         CountOfMatchesPlayed t2 ON t1.PlayerID = t2.PlayerID AND t1.Season = t2.Season AND t1.MatchType = t2.MatchType INNER JOIN
                         PlayersInTeams p ON p.PlayerId = t1.PlayerID INNER JOIN
                         CountOfMatchesPlayedByTeam t3 ON p.TeamID = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType
WHERE        InTeamStatus != 0
UNION
SELECT        t1.*, ISNULL(GamesPlayed, 0), 1
FROM            InGameBattingStats t1 LEFT JOIN
                         CountOfMatchesPlayed t2 ON t1.PlayerID = t2.PlayerID AND t1.Season = t2.Season AND t1.MatchType = t2.MatchType INNER JOIN
                         Players p1 ON p1.PlayerID = t1.PlayerID
WHERE        CurrentPlayerStatus = 2
");
        }
    }
}
