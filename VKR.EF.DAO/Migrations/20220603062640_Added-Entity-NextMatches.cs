using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityNextMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NextMatches",
                columns: table => new
                {
                    MatchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPlayed = table.Column<bool>(type: "bit", nullable: false),
                    HomeTeam = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    AwayTeam = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "date", nullable: false),
                    MatchType = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextMatches", x => x.MatchID);
                    table.ForeignKey(
                        name: "FK_NextMatches_Teams_AwayTeam",
                        column: x => x.AwayTeam,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NextMatches_Teams_HomeTeam",
                        column: x => x.HomeTeam,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NextMatches_TypesOfMatches_MatchType",
                        column: x => x.MatchType,
                        principalTable: "TypesOfMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NextMatches_AwayTeam",
                table: "NextMatches",
                column: "AwayTeam");

            migrationBuilder.CreateIndex(
                name: "IX_NextMatches_HomeTeam",
                table: "NextMatches",
                column: "HomeTeam");

            migrationBuilder.CreateIndex(
                name: "IX_NextMatches_MatchType",
                table: "NextMatches",
                column: "MatchType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NextMatches");
        }
    }
}
