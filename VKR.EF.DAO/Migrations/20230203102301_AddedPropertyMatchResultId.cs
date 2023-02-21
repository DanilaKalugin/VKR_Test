using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedPropertyMatchResultId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayedMatchId",
                table: "NextMatches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NextMatches_PlayedMatchId",
                table: "NextMatches",
                column: "PlayedMatchId",
                unique: true,
                filter: "[PlayedMatchId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_NextMatches_Matches_PlayedMatchId",
                table: "NextMatches",
                column: "PlayedMatchId",
                principalTable: "Matches",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NextMatches_Matches_PlayedMatchId",
                table: "NextMatches");

            migrationBuilder.DropIndex(
                name: "IX_NextMatches_PlayedMatchId",
                table: "NextMatches");

            migrationBuilder.DropColumn(
                name: "PlayedMatchId",
                table: "NextMatches");
        }
    }
}
