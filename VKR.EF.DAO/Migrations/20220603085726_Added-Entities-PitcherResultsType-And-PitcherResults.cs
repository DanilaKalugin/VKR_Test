using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntitiesPitcherResultsTypeAndPitcherResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypesOfMatchResultsForPitcher",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfMatchResultsForPitcher", x => x.Id);
                    table.UniqueConstraint("AK_TypesOfMatchResultsForPitcher_Description", x => x.Description);
                });

            migrationBuilder.CreateTable(
                name: "PitcherResults",
                columns: table => new
                {
                    Pitcher = table.Column<long>(type: "bigint", nullable: false),
                    Match = table.Column<int>(type: "int", nullable: false),
                    QualityStart = table.Column<bool>(type: "bit", nullable: false),
                    CompleteGame = table.Column<bool>(type: "bit", nullable: false),
                    Shutout = table.Column<bool>(type: "bit", nullable: false),
                    MatchResultId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PitcherResults", x => new { x.Pitcher, x.Match });
                    table.ForeignKey(
                        name: "FK_PitcherResults_Matches_Match",
                        column: x => x.Match,
                        principalTable: "Matches",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PitcherResults_PlayersInTeams_Pitcher",
                        column: x => x.Pitcher,
                        principalTable: "PlayersInTeams",
                        principalColumn: "PlayerInTeamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PitcherResults_TypesOfMatchResultsForPitcher_MatchResultId",
                        column: x => x.MatchResultId,
                        principalTable: "TypesOfMatchResultsForPitcher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TypesOfMatchResultsForPitcher",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { (byte)0, "NoDecision" },
                    { (byte)1, "Win" },
                    { (byte)2, "Loss" },
                    { (byte)3, "Save" },
                    { (byte)4, "Hold" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PitcherResults_Match",
                table: "PitcherResults",
                column: "Match");

            migrationBuilder.CreateIndex(
                name: "IX_PitcherResults_MatchResultId",
                table: "PitcherResults",
                column: "MatchResultId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PitcherResults");

            migrationBuilder.DropTable(
                name: "TypesOfMatchResultsForPitcher");
        }
    }
}
