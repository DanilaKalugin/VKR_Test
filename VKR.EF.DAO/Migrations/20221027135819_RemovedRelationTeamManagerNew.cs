using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class RemovedRelationTeamManagerNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Managers_TeamManager",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TeamManager",
                table: "Teams");

            migrationBuilder.AlterColumn<long>(
                name: "TeamManager",
                table: "Teams",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "TeamManager",
                table: "Teams",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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
    }
}
