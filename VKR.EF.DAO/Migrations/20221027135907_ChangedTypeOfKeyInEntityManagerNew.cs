using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class ChangedTypeOfKeyInEntityManagerNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ManagerID",
                table: "Managers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "ManagerID",
                table: "Managers",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
