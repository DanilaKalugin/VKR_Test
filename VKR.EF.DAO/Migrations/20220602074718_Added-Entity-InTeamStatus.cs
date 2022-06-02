using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityInTeamStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InTeamStatuses",
                columns: table => new
                {
                    InTeamStatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    InTeamStatusTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InTeamStatuses", x => x.InTeamStatusId);
                    table.UniqueConstraint("AK_InTeamStatuses_InTeamStatusTitle", x => x.InTeamStatusTitle);
                });

            migrationBuilder.InsertData(
                table: "InTeamStatuses",
                columns: new[] { "InTeamStatusId", "InTeamStatusTitle" },
                values: new object[] { (byte)0, "NotInThisTeam" });

            migrationBuilder.InsertData(
                table: "InTeamStatuses",
                columns: new[] { "InTeamStatusId", "InTeamStatusTitle" },
                values: new object[] { (byte)1, "ActiveRoster" });

            migrationBuilder.InsertData(
                table: "InTeamStatuses",
                columns: new[] { "InTeamStatusId", "InTeamStatusTitle" },
                values: new object[] { (byte)2, "Reserve" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InTeamStatuses");
        }
    }
}
