using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedViewCombinationsOfYearAndMatchType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW CombinationsOfYearAndMatchType
AS
select *
from 
(select distinct Season
from StandingsBySeasonAndMatchType) t1, 
(select distinct MatchType
from StandingsBySeasonAndMatchType) t2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW CombinationsOfYearAndMatchType");
        }
    }
}
