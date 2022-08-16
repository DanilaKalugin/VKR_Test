using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedentityLeagueSeason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeagueSeasons",
                columns: table => new
                {
                    Season = table.Column<int>(type: "int", nullable: false),
                    MatchType = table.Column<byte>(type: "tinyint", nullable: false),
                    SeasonStart = table.Column<DateTime>(type: "date", nullable: false),
                    SeasonEnd = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueSeasons", x => new { x.Season, x.MatchType });
                    table.CheckConstraint("SeasonStart", "YEAR(SeasonStart) = Season");
                    table.CheckConstraint("SeasonEnd", "YEAR(SeasonEnd) = Season");
                    table.ForeignKey(
                        name: "FK_LeagueSeasons_Seasons_Season",
                        column: x => x.Season,
                        principalTable: "Seasons",
                        principalColumn: "Year",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeagueSeasons_TypesOfMatches_MatchType",
                        column: x => x.MatchType,
                        principalTable: "TypesOfMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeagueSeasons_MatchType",
                table: "LeagueSeasons",
                column: "MatchType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeagueSeasons");
        }
    }
}
