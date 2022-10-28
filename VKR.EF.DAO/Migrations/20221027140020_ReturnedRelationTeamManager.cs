using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class ReturnedRelationTeamManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamManager",
                table: "Teams",
                column: "TeamManager");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Managers_TeamManager",
                table: "Teams",
                column: "TeamManager",
                principalTable: "Managers",
                principalColumn: "ManagerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Managers_TeamManager",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TeamManager",
                table: "Teams");
        }
    }
}
