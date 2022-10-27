using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class RemovedNullablesFromTeamFoundationYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "FoundationYear",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "FoundationYear",
                table: "Teams",
                sql: "FoundationYear BETWEEN 1850 AND 2022");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "FoundationYear",
                table: "Teams");

            migrationBuilder.AlterColumn<long>(
                name: "FoundationYear",
                table: "Teams",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");
        }
    }
}
