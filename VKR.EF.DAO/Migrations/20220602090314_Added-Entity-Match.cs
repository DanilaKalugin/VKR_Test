using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AwayTeam = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    HomeTeam = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    Stadium = table.Column<short>(type: "smallint", nullable: false),
                    DHRule = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    MatchDate = table.Column<DateTime>(type: "date", nullable: false),
                    MatchLength = table.Column<byte>(type: "tinyint", nullable: false),
                    MatchEnded = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsQuickMatch = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchID);
                    table.ForeignKey(
                        name: "FK_Matches_Stadiums_Stadium",
                        column: x => x.Stadium,
                        principalTable: "Stadiums",
                        principalColumn: "StadiumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_AwayTeam",
                        column: x => x.AwayTeam,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HomeTeam",
                        column: x => x.HomeTeam,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeam",
                table: "Matches",
                column: "AwayTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeam",
                table: "Matches",
                column: "HomeTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Stadium",
                table: "Matches",
                column: "Stadium");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
