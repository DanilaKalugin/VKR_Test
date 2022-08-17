using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityStartingLineup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StartingLineup",
                columns: table => new
                {
                    PlayerInTeamId = table.Column<long>(type: "bigint", nullable: false),
                    LineupTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    PlayerPositionInLineup = table.Column<byte>(type: "tinyint", nullable: false),
                    PlayerPosition = table.Column<string>(type: "nvarchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartingLineup", x => new { x.PlayerInTeamId, x.LineupTypeId });
                    table.ForeignKey(
                        name: "FK_StartingLineup_LineupType_LineupTypeId",
                        column: x => x.LineupTypeId,
                        principalTable: "LineupType",
                        principalColumn: "LineupTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StartingLineup_PlayerPositions_PlayerPosition",
                        column: x => x.PlayerPosition,
                        principalTable: "PlayerPositions",
                        principalColumn: "PositionCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StartingLineup_PlayersInTeams_PlayerInTeamId",
                        column: x => x.PlayerInTeamId,
                        principalTable: "PlayersInTeams",
                        principalColumn: "PlayerInTeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StartingLineup_LineupTypeId",
                table: "StartingLineup",
                column: "LineupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StartingLineup_PlayerPosition",
                table: "StartingLineup",
                column: "PlayerPosition");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StartingLineup");
        }
    }
}
