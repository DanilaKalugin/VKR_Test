using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedTwo_New_Propertiesto_Team : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "StrikeZoneProbability",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<byte>(
                name: "SwingInStrikeZoneProbability",
                table: "Teams",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddCheckConstraint(
                name: "StrikeZoneProbability",
                table: "Teams",
                sql: "StrikeZoneProbability BETWEEN 1 AND 2000");

            migrationBuilder.AddCheckConstraint(
                name: "SwingInStrikeZoneProbability",
                table: "Teams",
                sql: "SwingInStrikeZoneProbability BETWEEN 1 AND 100");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "StrikeZoneProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "SwingInStrikeZoneProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "StrikeZoneProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "SwingInStrikeZoneProbability",
                table: "Teams");
        }
    }
}
