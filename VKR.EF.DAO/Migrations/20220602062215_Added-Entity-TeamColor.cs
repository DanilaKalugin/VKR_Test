using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityTeamColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamColor",
                columns: table => new
                {
                    TeamName = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    ColorNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    RedComponent = table.Column<byte>(type: "tinyint", nullable: false),
                    GreenComponent = table.Column<byte>(type: "tinyint", nullable: false),
                    BlueComponent = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamColor", x => new { x.TeamName, x.ColorNumber });
                    table.ForeignKey(
                        name: "FK_TeamColor_Teams_TeamName",
                        column: x => x.TeamName,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamColor");
        }
    }
}
