using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityLineupsForMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LineupsForMatches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    PlayerInTeamId = table.Column<long>(type: "bigint", nullable: false),
                    NumberInLineup = table.Column<byte>(type: "tinyint", nullable: false),
                    PlayerPosition = table.Column<string>(type: "nvarchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineupsForMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineupsForMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineupsForMatches_PlayerPositions_PlayerPosition",
                        column: x => x.PlayerPosition,
                        principalTable: "PlayerPositions",
                        principalColumn: "PositionCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineupsForMatches_PlayersInTeams_PlayerInTeamId",
                        column: x => x.PlayerInTeamId,
                        principalTable: "PlayersInTeams",
                        principalColumn: "PlayerInTeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineupsForMatches_MatchId",
                table: "LineupsForMatches",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_LineupsForMatches_PlayerInTeamId",
                table: "LineupsForMatches",
                column: "PlayerInTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_LineupsForMatches_PlayerPosition",
                table: "LineupsForMatches",
                column: "PlayerPosition");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineupsForMatches");
        }
    }
}
