using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedFunctionRunsScoredByTeamBeforeThisDateInMatchType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION RunsScoredByTeamBeforeThisDateInMatchType(@Type tinyint, @Date date)
RETURNS TABLE
AS
RETURN (SELECT        dbo.Teams.TeamAbbreviation, @Type As MatchType, Year(@Date) As Season, COUNT(CASE WHEN AtBatResult = 13 AND m1.Season = Year(matchDate) THEN 1 ELSE NULL END) AS RS
FROM            dbo.Teams CROSS JOIN
                         dbo.CombinationsOfYearAndMatchType AS m1 LEFT OUTER JOIN
						 dbo.PlayersInTeams ON dbo.PlayersInTeams.TeamID = teams.TeamAbbreviation LEFT JOIN
                         dbo.AtBats ON dbo.AtBats.Batter = dbo.PlayersInTeams.PlayerInTeamID LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.AtBats.Match AND m1.MatchType = dbo.Matches.MatchType
WHERE m1.Season = Year(@Date) AND (MatchDate <= @Date OR MatchDate Is Null) AND m1.MatchType = @Type
GROUP BY dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION RunsScoredByTeamBeforeThisDateInMatchType");
        }
    }
}
