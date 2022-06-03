using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityAtBat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtBat",
                columns: table => new
                {
                    AtBatID = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Match = table.Column<int>(type: "int", nullable: false),
                    Batter = table.Column<long>(type: "bigint", nullable: false),
                    AtBatResult = table.Column<byte>(type: "tinyint", nullable: false),
                    Pitcher = table.Column<long>(type: "bigint", nullable: false),
                    Outs = table.Column<byte>(type: "tinyint", nullable: false),
                    RBI = table.Column<byte>(type: "tinyint", nullable: false),
                    Inning = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtBat", x => x.AtBatID);
                    table.ForeignKey(
                        name: "FK_AtBat_Matches_Match",
                        column: x => x.Match,
                        principalTable: "Matches",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtBat_PlayersInTeams_Batter",
                        column: x => x.Batter,
                        principalTable: "PlayersInTeams",
                        principalColumn: "PlayerInTeamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtBat_PlayersInTeams_Pitcher",
                        column: x => x.Pitcher,
                        principalTable: "PlayersInTeams",
                        principalColumn: "PlayerInTeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AtBat_TypesOfAtBatResults_AtBatResult",
                        column: x => x.AtBatResult,
                        principalTable: "TypesOfAtBatResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtBat_AtBatResult",
                table: "AtBat",
                column: "AtBatResult");

            migrationBuilder.CreateIndex(
                name: "IX_AtBat_Batter",
                table: "AtBat",
                column: "Batter");

            migrationBuilder.CreateIndex(
                name: "IX_AtBat_Match",
                table: "AtBat",
                column: "Match");

            migrationBuilder.CreateIndex(
                name: "IX_AtBat_Pitcher",
                table: "AtBat",
                column: "Pitcher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtBat");
        }
    }
}
