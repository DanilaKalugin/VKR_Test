using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityStadium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "TeamStadium",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    StadiumId = table.Column<short>(type: "smallint", nullable: false),
                    StadiumTitle = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    StadiumCapacity = table.Column<long>(type: "bigint", nullable: false),
                    StadiumDistanceToCenterField = table.Column<int>(type: "int", nullable: false),
                    StadiumLocation = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.StadiumId);
                    table.UniqueConstraint("AK_Stadiums_StadiumTitle", x => x.StadiumTitle);
                    table.ForeignKey(
                        name: "FK_Stadiums_Cities_StadiumLocation",
                        column: x => x.StadiumLocation,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamStadium",
                table: "Teams",
                column: "TeamStadium");

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_StadiumLocation",
                table: "Stadiums",
                column: "StadiumLocation");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Stadiums_TeamStadium",
                table: "Teams",
                column: "TeamStadium",
                principalTable: "Stadiums",
                principalColumn: "StadiumId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Stadiums_TeamStadium",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Stadiums");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TeamStadium",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamStadium",
                table: "Teams");
        }
    }
}
