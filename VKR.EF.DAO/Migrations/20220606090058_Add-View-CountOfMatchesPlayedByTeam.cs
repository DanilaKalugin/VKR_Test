using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddViewCountOfMatchesPlayedByTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW CountOfMatchesPlayedByTeam
AS
SELECT        dbo.Teams.TeamAbbreviation, MatchType, YEAR(MatchDate) As Season, COUNT(dbo.Matches.MatchID) AS TGP
FROM             dbo.Teams INNER JOIN
                        dbo.Matches ON dbo.Teams.TeamAbbreviation = dbo.Matches.HomeTeam OR dbo.Teams.TeamAbbreviation = dbo.Matches.AwayTeam
GROUP BY  dbo.Teams.TeamAbbreviation, MatchType, YEAR(MatchDate)"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view CountOfMatchesPlayedByTeam");
        }
    }
}
