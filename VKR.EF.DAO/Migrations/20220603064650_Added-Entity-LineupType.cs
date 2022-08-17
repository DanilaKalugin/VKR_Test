using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityLineupType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LineupType",
                columns: table => new
                {
                    LineupTypeId = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PitcherHandId = table.Column<byte>(type: "tinyint", nullable: true),
                    DesignatedHitterRule = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineupType", x => x.LineupTypeId);
                    table.ForeignKey(
                        name: "FK_LineupType_PitchingHand_PitcherHandId",
                        column: x => x.PitcherHandId,
                        principalTable: "PitchingHand",
                        principalColumn: "PitchingHandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineupType_PitcherHandId",
                table: "LineupType",
                column: "PitcherHandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineupType");
        }
    }
}
