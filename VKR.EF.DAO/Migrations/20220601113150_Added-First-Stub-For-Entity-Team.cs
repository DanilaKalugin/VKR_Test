using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedFirstStubForEntityTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "League",
                table: "Divisions",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamAbbreviation = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    TeamCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    TeamDivision = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamAbbreviation);
                    table.ForeignKey(
                        name: "FK_Teams_Divisions_TeamDivision",
                        column: x => x.TeamDivision,
                        principalTable: "Divisions",
                        principalColumn: "DivisionNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamDivision",
                table: "Teams",
                column: "TeamDivision");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.AlterColumn<string>(
                name: "League",
                table: "Divisions",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);
        }
    }
}
