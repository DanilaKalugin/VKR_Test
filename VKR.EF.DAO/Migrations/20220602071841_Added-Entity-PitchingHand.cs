using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityPitchingHand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "PlayerPitchingHand",
                table: "Players",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "PitchingHand",
                columns: table => new
                {
                    PitchingHandId = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PitchingHand", x => x.PitchingHandId);
                    table.UniqueConstraint("AK_PitchingHand_Description", x => x.Description);
                });

            migrationBuilder.InsertData(
                table: "PitchingHand",
                columns: new[] { "PitchingHandId", "Description" },
                values: new object[] { (byte)1, "Left" });

            migrationBuilder.InsertData(
                table: "PitchingHand",
                columns: new[] { "PitchingHandId", "Description" },
                values: new object[] { (byte)2, "Right" });

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerPitchingHand",
                table: "Players",
                column: "PlayerPitchingHand");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PitchingHand_PlayerPitchingHand",
                table: "Players",
                column: "PlayerPitchingHand",
                principalTable: "PitchingHand",
                principalColumn: "PitchingHandId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PitchingHand_PlayerPitchingHand",
                table: "Players");

            migrationBuilder.DropTable(
                name: "PitchingHand");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerPitchingHand",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerPitchingHand",
                table: "Players");
        }
    }
}
