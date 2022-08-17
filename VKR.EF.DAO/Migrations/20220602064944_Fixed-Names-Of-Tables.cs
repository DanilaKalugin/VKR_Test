using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class FixedNamesOfTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manager_Cities_ManagerPlaceOfBirth",
                table: "Manager");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Cities_PlaceOfBirth",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamColor_Teams_TeamName",
                table: "TeamColor");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Manager_TeamManager",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamColor",
                table: "TeamColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manager",
                table: "Manager");

            migrationBuilder.RenameTable(
                name: "TeamColor",
                newName: "TeamColors");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "Manager",
                newName: "Managers");

            migrationBuilder.RenameIndex(
                name: "IX_Player_PlaceOfBirth",
                table: "Players",
                newName: "IX_Players_PlaceOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_Manager_ManagerPlaceOfBirth",
                table: "Managers",
                newName: "IX_Managers_ManagerPlaceOfBirth");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamColors",
                table: "TeamColors",
                columns: new[] { "TeamName", "ColorNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "PlayerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managers",
                table: "Managers",
                column: "ManagerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Cities_ManagerPlaceOfBirth",
                table: "Managers",
                column: "ManagerPlaceOfBirth",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Cities_PlaceOfBirth",
                table: "Players",
                column: "PlaceOfBirth",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamColors_Teams_TeamName",
                table: "TeamColors",
                column: "TeamName",
                principalTable: "Teams",
                principalColumn: "TeamAbbreviation",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Managers_TeamManager",
                table: "Teams",
                column: "TeamManager",
                principalTable: "Managers",
                principalColumn: "ManagerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Cities_ManagerPlaceOfBirth",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Cities_PlaceOfBirth",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamColors_Teams_TeamName",
                table: "TeamColors");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Managers_TeamManager",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamColors",
                table: "TeamColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Managers",
                table: "Managers");

            migrationBuilder.RenameTable(
                name: "TeamColors",
                newName: "TeamColor");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");

            migrationBuilder.RenameTable(
                name: "Managers",
                newName: "Manager");

            migrationBuilder.RenameIndex(
                name: "IX_Players_PlaceOfBirth",
                table: "Player",
                newName: "IX_Player_PlaceOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_Managers_ManagerPlaceOfBirth",
                table: "Manager",
                newName: "IX_Manager_ManagerPlaceOfBirth");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamColor",
                table: "TeamColor",
                columns: new[] { "TeamName", "ColorNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "PlayerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manager",
                table: "Manager",
                column: "ManagerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Cities_ManagerPlaceOfBirth",
                table: "Manager",
                column: "ManagerPlaceOfBirth",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Cities_PlaceOfBirth",
                table: "Player",
                column: "PlaceOfBirth",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamColor_Teams_TeamName",
                table: "TeamColor",
                column: "TeamName",
                principalTable: "Teams",
                principalColumn: "TeamAbbreviation",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Manager_TeamManager",
                table: "Teams",
                column: "TeamManager",
                principalTable: "Manager",
                principalColumn: "ManagerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
