using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityTeamHistoricalName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamHistoricalNames",
                columns: table => new
                {
                    TeamAbbreviation = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    TeamRegion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    FirstSeasonWithName = table.Column<short>(type: "smallint", nullable: false),
                    LastSeasonWithName = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamHistoricalNames", x => x.TeamAbbreviation);
                    table.CheckConstraint("FirstSeasonGreaterThan1850", "FirstSeasonWithName > 1850");
                    table.CheckConstraint("LastSeasonGreaterThan1850", "LastSeasonWithName > 1850");
                    table.CheckConstraint("LastSeasonMustBeGreaterThanFirst", "LastSeasonWithName >= FirstSeasonWithName");
                    table.ForeignKey(
                        name: "FK_TeamHistoricalNames_Teams_TeamAbbreviation",
                        column: x => x.TeamAbbreviation,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamHistoricalNames");
        }
    }
}
