using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedTableTeamRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "SwingInStrikeZoneProbability1",
                table: "TeamRating");

            migrationBuilder.DropCheckConstraint(
                name: "SwingOutsideStrikeZoneProbability1",
                table: "TeamRating");

            migrationBuilder.AlterColumn<short>(
                name: "SwingOutsideStrikeZoneProbability",
                table: "TeamRating",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<short>(
                name: "SwingInStrikeZoneProbability",
                table: "TeamRating",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddCheckConstraint(
                name: "SwingInStrikeZoneProbability1",
                table: "TeamRating",
                sql: "SwingInStrikeZoneProbability BETWEEN 1 AND 1000");

            migrationBuilder.AddCheckConstraint(
                name: "SwingOutsideStrikeZoneProbability1",
                table: "TeamRating",
                sql: "SwingOutsideStrikeZoneProbability BETWEEN 1 AND 1000");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "SwingInStrikeZoneProbability1",
                table: "TeamRating");

            migrationBuilder.DropCheckConstraint(
                name: "SwingOutsideStrikeZoneProbability1",
                table: "TeamRating");

            migrationBuilder.AlterColumn<byte>(
                name: "SwingOutsideStrikeZoneProbability",
                table: "TeamRating",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<byte>(
                name: "SwingInStrikeZoneProbability",
                table: "TeamRating",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddCheckConstraint(
                name: "SwingInStrikeZoneProbability1",
                table: "TeamRating",
                sql: "SwingInStrikeZoneProbability BETWEEN 1 AND 100");

            migrationBuilder.AddCheckConstraint(
                name: "SwingOutsideStrikeZoneProbability1",
                table: "TeamRating",
                sql: "SwingOutsideStrikeZoneProbability BETWEEN 1 AND 100");
        }
    }
}
