using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    LeagueID = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    LeagueTitle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LeagueDHRule = table.Column<bool>(type: "bit", nullable: false),
                    LeagueYearOfFoundation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leagues");
        }
    }
}
