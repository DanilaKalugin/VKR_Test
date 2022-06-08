using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedViewRunsAgainstByTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW RunsAgainstByTeam AS
SELECT        dbo.Teams.TeamAbbreviation, MatchType, Year(MatchDate) As Season, COUNT(CASE WHEN AtBatResult = 13 THEN 1 ELSE NULL END) AS RS
FROM            dbo.Matches INNER JOIN
                         dbo.ExpandedAtBats ON dbo.Matches.MatchID = dbo.ExpandedAtBats.Match RIGHT OUTER JOIN
                         dbo.Teams ON dbo.ExpandedAtBats.Defense = dbo.Teams.TeamAbbreviation
GROUP BY dbo.Teams.TeamAbbreviation, MatchType, Year(MatchDate)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW RunsAgainstByTeam");
        }
    }
}
