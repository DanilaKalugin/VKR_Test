using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityPlayerStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "CurrentPlayerStatus",
                table: "Players",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "PlayerStatuses",
                columns: table => new
                {
                    PlayerStatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    PlayerStatusName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatuses", x => x.PlayerStatusId);
                    table.UniqueConstraint("AK_PlayerStatuses_PlayerStatusName", x => x.PlayerStatusName);
                });

            migrationBuilder.InsertData(
                table: "PlayerStatuses",
                columns: new[] { "PlayerStatusId", "PlayerStatusName" },
                values: new object[] { (byte)1, "Active" });

            migrationBuilder.InsertData(
                table: "PlayerStatuses",
                columns: new[] { "PlayerStatusId", "PlayerStatusName" },
                values: new object[] { (byte)2, "FreeAgent" });

            migrationBuilder.InsertData(
                table: "PlayerStatuses",
                columns: new[] { "PlayerStatusId", "PlayerStatusName" },
                values: new object[] { (byte)3, "Retired" });

            migrationBuilder.CreateIndex(
                name: "IX_Players_CurrentPlayerStatus",
                table: "Players",
                column: "CurrentPlayerStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerStatuses_CurrentPlayerStatus",
                table: "Players",
                column: "CurrentPlayerStatus",
                principalTable: "PlayerStatuses",
                principalColumn: "PlayerStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerStatuses_CurrentPlayerStatus",
                table: "Players");

            migrationBuilder.DropTable(
                name: "PlayerStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Players_CurrentPlayerStatus",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CurrentPlayerStatus",
                table: "Players");
        }
    }
}
