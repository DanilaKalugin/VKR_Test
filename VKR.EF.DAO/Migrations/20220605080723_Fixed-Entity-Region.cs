using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class FixedEntityRegion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Regions_Country",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Cities",
                newName: "Region");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_Country",
                table: "Cities",
                newName: "IX_Cities_Region");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Regions_Region",
                table: "Cities",
                column: "Region",
                principalTable: "Regions",
                principalColumn: "RegionCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Regions_Region",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Cities",
                newName: "Country");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_Region",
                table: "Cities",
                newName: "IX_Cities_Country");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Regions_Country",
                table: "Cities",
                column: "Country",
                principalTable: "Regions",
                principalColumn: "RegionCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
