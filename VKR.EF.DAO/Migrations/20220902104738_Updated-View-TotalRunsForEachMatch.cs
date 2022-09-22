using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedViewTotalRunsForEachMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW TotalRunsForEachMatch AS
SELECT        dbo.Matches.MatchID, COUNT(CASE WHEN TeamID = AwayTeam THEN 1 ELSE NULL END) AS AwayRuns, 
COUNT(CASE WHEN TeamID = HomeTeam THEN 1 ELSE NULL END) AS HomeRuns, MAX(dbo.Runs.Inning) AS Inning
FROM            dbo.Matches 
INNER JOIN dbo.Runs ON dbo.Matches.MatchID = Runs.Match
INNER JOIN dbo.PlayersInTeams ON dbo.PlayersInTeams.PlayerInTeamID = dbo.Runs.Runner
WHERE        (dbo.Matches.MatchEnded = 0)
GROUP BY dbo.Matches.MatchID
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
migrationBuilder.Sql(@"ALTER VIEW TotalRunsForEachMatch AS
SELECT        dbo.Matches.MatchID, COUNT(CASE WHEN AtBatResult = 13 AND TeamID = AwayTeam THEN 1 ELSE NULL END) AS AwayRuns, COUNT(CASE WHEN AtBatResult = 13 AND TeamID = HomeTeam THEN 1 ELSE NULL END) 
                         AS HomeRuns, MAX(dbo.AtBats.Inning) AS Inning
FROM            dbo.Matches INNER JOIN
                         dbo.AtBats ON dbo.Matches.MatchID = dbo.AtBats.Match INNER JOIN
                         dbo.PlayersInTeams ON dbo.PlayersInTeams.PlayerInTeamID = dbo.AtBats.Batter
WHERE        (dbo.Matches.MatchEnded = 0)
GROUP BY dbo.Matches.MatchID
");
        }
    }
}
