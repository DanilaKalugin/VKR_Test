using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedKeyInTeamHistoricalName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamHistoricalNames",
                table: "TeamHistoricalNames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamHistoricalNames",
                table: "TeamHistoricalNames",
                columns: new[] { "TeamAbbreviation", "FirstSeasonWithName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamHistoricalNames",
                table: "TeamHistoricalNames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamHistoricalNames",
                table: "TeamHistoricalNames",
                column: "TeamAbbreviation");
        }
    }
}
