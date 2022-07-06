using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedTableMatchResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResultsOfMatches",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamRuns = table.Column<int>(type: "int", nullable: false),
                    HomeTeamRuns = table.Column<int>(type: "int", nullable: false),
                    MatchWinnerId = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    MatchLoserId = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    Length = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultsOfMatches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_ResultsOfMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultsOfMatches_Teams_MatchLoserId",
                        column: x => x.MatchLoserId,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultsOfMatches_Teams_MatchWinnerId",
                        column: x => x.MatchWinnerId,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResultsOfMatches_MatchLoserId",
                table: "ResultsOfMatches",
                column: "MatchLoserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultsOfMatches_MatchWinnerId",
                table: "ResultsOfMatches",
                column: "MatchWinnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultsOfMatches");
        }
    }
}
