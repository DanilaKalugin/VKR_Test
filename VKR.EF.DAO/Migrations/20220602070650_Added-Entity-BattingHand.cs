using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityBattingHand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "PlayerBattingHand",
                table: "Players",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "BattingHand",
                columns: table => new
                {
                    BattingHandId = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattingHand", x => x.BattingHandId);
                    table.UniqueConstraint("AK_BattingHand_Description", x => x.Description);
                });

            migrationBuilder.InsertData(
                table: "BattingHand",
                columns: new[] { "BattingHandId", "Description" },
                values: new object[] { (byte)1, "Left" });

            migrationBuilder.InsertData(
                table: "BattingHand",
                columns: new[] { "BattingHandId", "Description" },
                values: new object[] { (byte)2, "Right" });

            migrationBuilder.InsertData(
                table: "BattingHand",
                columns: new[] { "BattingHandId", "Description" },
                values: new object[] { (byte)3, "Switch" });

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerBattingHand",
                table: "Players",
                column: "PlayerBattingHand");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_BattingHand_PlayerBattingHand",
                table: "Players",
                column: "PlayerBattingHand",
                principalTable: "BattingHand",
                principalColumn: "BattingHandId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_BattingHand_PlayerBattingHand",
                table: "Players");

            migrationBuilder.DropTable(
                name: "BattingHand");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerBattingHand",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerBattingHand",
                table: "Players");
        }
    }
}
