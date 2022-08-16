using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedentitySeason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Season",
                table: "NextMatches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Season",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NextMatches_Season",
                table: "NextMatches",
                column: "Season");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Season",
                table: "Matches",
                column: "Season");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NextMatches_Season",
                table: "NextMatches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Season",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "NextMatches");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "Matches");
        }
    }
}
