using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedViewBattingStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW PlayerBattingStats
AS
select t1.*, GamesPlayed, TGP
from InGameBattingStats t1 INNER JOIN CountOfMatchesPlayed t2 ON t1.PlayerID = t2.PlayerID AND t1.Season = t2.Season AND t1.MatchType = t2.MatchType 
						   INNER JOIN PlayersInTeams p ON p.PlayerId = t1.PlayerID
						   INNER JOIN CountOfMatchesPlayedByTeam t3 ON p.TeamID = t3.TeamAbbreviation AND t1.Season = t3.Season AND t1.MatchType = t3.MatchType
WHERE InTeamStatus != 0
UNION
select t1.*, GamesPlayed, 1
from InGameBattingStats t1 INNER JOIN CountOfMatchesPlayed t2 ON t1.PlayerID = t2.PlayerID AND t1.Season = t2.Season AND t1.MatchType = t2.MatchType 
						   INNER JOIN Players p1 On p1.PlayerID = t1.PlayerID
WHERE CurrentPlayerStatus = 2"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view PlayerBattingStats");
        }
    }
}
