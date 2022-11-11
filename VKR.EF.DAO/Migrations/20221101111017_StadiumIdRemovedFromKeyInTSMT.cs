using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class StadiumIdRemovedFromKeyInTSMT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamStadiumForTypeOfMatch",
                table: "TeamStadiumForTypeOfMatch");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamStadiumForTypeOfMatch",
                table: "TeamStadiumForTypeOfMatch",
                columns: new[] { "TeamAbbreviation", "TypeOfMatchId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamStadiumForTypeOfMatch",
                table: "TeamStadiumForTypeOfMatch");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamStadiumForTypeOfMatch",
                table: "TeamStadiumForTypeOfMatch",
                columns: new[] { "TeamAbbreviation", "TypeOfMatchId", "StadiumId" });
        }
    }
}
