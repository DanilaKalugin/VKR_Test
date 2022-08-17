using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityPlayerPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerPositions",
                columns: table => new
                {
                    PositionCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    PositionFullTitle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Number = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPositions", x => x.PositionCode);
                    table.UniqueConstraint("AK_PlayerPositions_Number", x => x.Number);
                    table.UniqueConstraint("AK_PlayerPositions_PositionFullTitle", x => x.PositionFullTitle);
                });

            migrationBuilder.CreateTable(
                name: "PlayersPositions",
                columns: table => new
                {
                    PlayersId = table.Column<long>(type: "bigint", nullable: false),
                    PositionsShortTitle = table.Column<string>(type: "nvarchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersPositions", x => new { x.PlayersId, x.PositionsShortTitle });
                    table.ForeignKey(
                        name: "FK_PlayersPositions_PlayerPositions_PositionsShortTitle",
                        column: x => x.PositionsShortTitle,
                        principalTable: "PlayerPositions",
                        principalColumn: "PositionCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayersPositions_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayersPositions_PositionsShortTitle",
                table: "PlayersPositions",
                column: "PositionsShortTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersPositions");

            migrationBuilder.DropTable(
                name: "PlayerPositions");
        }
    }
}
