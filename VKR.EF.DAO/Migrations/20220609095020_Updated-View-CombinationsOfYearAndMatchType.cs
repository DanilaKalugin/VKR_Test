using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedViewCombinationsOfYearAndMatchType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW CombinationsOfYearAndMatchType
AS
SELECT        t1.Season, t2.MatchType
FROM            (SELECT DISTINCT Year(MatchDate) AS Season
                          FROM            dbo.Matches) AS t1 CROSS JOIN
                             (SELECT DISTINCT MatchType
                               FROM            Matches) AS t2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW CombinationsOfYearAndMatchType
AS
select *
from 
(select distinct Season
from StandingsBySeasonAndMatchType) t1, 
(select distinct MatchType
from StandingsBySeasonAndMatchType) t2");
        }
    }
}
