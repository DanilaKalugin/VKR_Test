using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddEntityStadiumFactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StadiumFactors",
                columns: table => new
                {
                    Stadium = table.Column<short>(type: "smallint", nullable: false),
                    HittingFactor = table.Column<float>(type: "real", nullable: false, defaultValue: 1f),
                    SingleFactor = table.Column<float>(type: "real", nullable: false, defaultValue: 1f),
                    DoubleFactor = table.Column<float>(type: "real", nullable: false, defaultValue: 1f),
                    TripleFactor = table.Column<float>(type: "real", nullable: false, defaultValue: 1f),
                    HomeRunFactor = table.Column<float>(type: "real", nullable: false, defaultValue: 1f)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StadiumFactors", x => x.Stadium);
                    table.ForeignKey(
                        name: "FK_StadiumFactors_Stadiums_Stadium",
                        column: x => x.Stadium,
                        principalTable: "Stadiums",
                        principalColumn: "StadiumId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StadiumFactors");
        }
    }
}
