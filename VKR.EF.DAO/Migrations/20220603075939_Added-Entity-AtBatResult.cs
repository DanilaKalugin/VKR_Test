using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityAtBatResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypesOfAtBatResults",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfAtBatResults", x => x.Id);
                    table.UniqueConstraint("AK_TypesOfAtBatResults_Description", x => x.Description);
                });

            migrationBuilder.InsertData(
                table: "TypesOfAtBatResults",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { (byte)0, "NoResult" },
                    { (byte)1, "Strikeout" },
                    { (byte)2, "Walk" },
                    { (byte)3, "HitByPitch" },
                    { (byte)4, "Flyout" },
                    { (byte)5, "Groundout" },
                    { (byte)6, "Popout" },
                    { (byte)7, "Single" },
                    { (byte)8, "Double" },
                    { (byte)9, "Triple" },
                    { (byte)10, "HomeRun" },
                    { (byte)11, "StolenBase" },
                    { (byte)12, "CaughtStealing" },
                    { (byte)13, "Run" },
                    { (byte)14, "SacrificeFly" },
                    { (byte)15, "SacrificeBunt" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypesOfAtBatResults");
        }
    }
}
