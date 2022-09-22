using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityRun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Runs",
                columns: table => new
                {
                    RunID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Match = table.Column<int>(type: "int", nullable: false),
                    Runner = table.Column<long>(type: "bigint", nullable: false),
                    IsEarned = table.Column<bool>(type: "bit", nullable: false),
                    Pitcher = table.Column<long>(type: "bigint", nullable: false),
                    Inning = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runs", x => x.RunID);
                    table.ForeignKey(
                        name: "FK_Runs_Matches_Match",
                        column: x => x.Match,
                        principalTable: "Matches",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Runs_PlayersInTeams_Pitcher",
                        column: x => x.Pitcher,
                        principalTable: "PlayersInTeams",
                        principalColumn: "PlayerInTeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Runs_PlayersInTeams_Runner",
                        column: x => x.Runner,
                        principalTable: "PlayersInTeams",
                        principalColumn: "PlayerInTeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Runs_Match",
                table: "Runs",
                column: "Match");

            migrationBuilder.CreateIndex(
                name: "IX_Runs_Pitcher",
                table: "Runs",
                column: "Pitcher");

            migrationBuilder.CreateIndex(
                name: "IX_Runs_Runner",
                table: "Runs",
                column: "Runner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Runs");
        }
    }
}
