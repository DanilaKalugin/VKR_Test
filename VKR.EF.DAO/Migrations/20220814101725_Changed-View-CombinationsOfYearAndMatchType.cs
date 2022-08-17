using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class ChangedViewCombinationsOfYearAndMatchType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER View CombinationsOfYearAndMatchType
AS
SELECT Id, Year
FROM typesOfMatches, Seasons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" AS
SELECT        t1.Season, t2.MatchType
FROM            (SELECT DISTINCT YEAR(MatchDate) AS Season
                          FROM            dbo.Matches) AS t1 CROSS JOIN
                             (SELECT DISTINCT MatchType
                               FROM            dbo.Matches) AS t2");
        }
    }
}
