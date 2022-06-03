using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityTeamStadiumMatchType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Stadiums_TeamStadium",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TeamStadium",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamStadium",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "IsQuickMatch",
                table: "Matches");

            migrationBuilder.AddColumn<byte>(
                name: "MatchType",
                table: "Matches",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "TeamStadiumForTypeOfMatch",
                columns: table => new
                {
                    TeamAbbreviation = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    TypeOfMatchId = table.Column<byte>(type: "tinyint", nullable: false),
                    StadiumId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamStadiumForTypeOfMatch", x => new { x.TeamAbbreviation, x.TypeOfMatchId, x.StadiumId });
                    table.ForeignKey(
                        name: "FK_TeamStadiumForTypeOfMatch_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "StadiumId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamStadiumForTypeOfMatch_Teams_TeamAbbreviation",
                        column: x => x.TeamAbbreviation,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamStadiumForTypeOfMatch_TypesOfMatches_TyprOfMatchId",
                        column: x => x.TypeOfMatchId,
                        principalTable: "TypesOfMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MatchType",
                table: "Matches",
                column: "MatchType");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStadiumForTypeOfMatch_StadiumId",
                table: "TeamStadiumForTypeOfMatch",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStadiumForTypeOfMatch_TypeOfMatchId",
                table: "TeamStadiumForTypeOfMatch",
                column: "TypeOfMatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_TypesOfMatches_MatchType",
                table: "Matches",
                column: "MatchType",
                principalTable: "TypesOfMatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_TypesOfMatches_MatchType",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "TeamStadiumForTypeOfMatch");

            migrationBuilder.DropIndex(
                name: "IX_Matches_MatchType",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "MatchType",
                table: "Matches");

            migrationBuilder.AddColumn<short>(
                name: "TeamStadium",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<bool>(
                name: "IsQuickMatch",
                table: "Matches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamStadium",
                table: "Teams",
                column: "TeamStadium");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Stadiums_TeamStadium",
                table: "Teams",
                column: "TeamStadium",
                principalTable: "Stadiums",
                principalColumn: "StadiumId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
