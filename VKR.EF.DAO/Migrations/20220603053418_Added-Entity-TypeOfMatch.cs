using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityTypeOfMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypesOfMatches",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfMatches", x => x.Id);
                    table.UniqueConstraint("AK_TypesOfMatches_Description", x => x.Description);
                });

            migrationBuilder.InsertData(
                table: "TypesOfMatches",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { (byte)0, "QuickMatch" },
                    { (byte)1, "RegularSeason" },
                    { (byte)2, "Postseason" },
                    { (byte)3, "SpringTraining" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypesOfMatches");
        }
    }
}
