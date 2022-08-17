using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class FixedViewTotalRunsForEachMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW TotalRunsForEachMatch
AS 
SELECT        dbo.Matches.MatchID, SUM(CASE WHEN TeamId = AwayTeam THEN RBI ELSE 0 END) AS AwayRuns, SUM(CASE WHEN TeamId = HomeTeam THEN RBI ELSE 0 END) AS HomeRuns, MAX(dbo.AtBats.Inning) AS Inning
FROM            dbo.Matches INNER JOIN
                         dbo.AtBats ON dbo.Matches.MatchID = dbo.AtBats.Match INNER JOIN
                         dbo.PlayersInTeams ON dbo.PlayersInTeams.PlayerInTeamID = dbo.AtBats.Batter
WHERE MatchEnded = 0
GROUP BY dbo.Matches.MatchID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
migrationBuilder.Sql(@"ALTER VIEW TotalRunsForEachMatch
AS 
SELECT        dbo.Matches.MatchID, SUM(CASE WHEN TeamId = AwayTeam THEN RBI ELSE 0 END) AS AwayRuns, SUM(CASE WHEN TeamId = HomeTeam THEN RBI ELSE 0 END) AS HomeRuns, MAX(dbo.AtBats.Inning) AS Inning
FROM            dbo.Matches INNER JOIN
                         dbo.AtBats ON dbo.Matches.MatchID = dbo.AtBats.Match INNER JOIN
                         dbo.PlayersInTeams ON dbo.PlayersInTeams.PlayerInTeamID = dbo.AtBats.Batter
GROUP BY dbo.Matches.MatchID");
        }
    }
}
