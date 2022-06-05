using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityRegion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_Country",
                table: "Cities");

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionCode);
                    table.UniqueConstraint("AK_Regions_RegionName_Country", x => new { x.RegionName, x.Country });
                    table.ForeignKey(
                        name: "FK_Regions_Countries_Country",
                        column: x => x.Country,
                        principalTable: "Countries",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Regions_Country",
                table: "Regions",
                column: "Country");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Regions_Country",
                table: "Cities",
                column: "Country",
                principalTable: "Regions",
                principalColumn: "RegionCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Regions_Country",
                table: "Cities");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_Country",
                table: "Cities",
                column: "Country",
                principalTable: "Countries",
                principalColumn: "CountryCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
