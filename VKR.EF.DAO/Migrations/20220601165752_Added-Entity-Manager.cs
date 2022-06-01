using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Divisions_TeamDivision",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Stadiums_TeamStadium",
                table: "Teams");

            migrationBuilder.AddColumn<short>(
                name: "TeamManager",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    ManagerID = table.Column<short>(type: "smallint", nullable: false),
                    ManagerFirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ManagerSecondName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ManagerDateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    ManagerPlaceOfBirth = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.ManagerID);
                    table.ForeignKey(
                        name: "FK_Manager_Cities_ManagerPlaceOfBirth",
                        column: x => x.ManagerPlaceOfBirth,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamManager",
                table: "Teams",
                column: "TeamManager");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_ManagerPlaceOfBirth",
                table: "Manager",
                column: "ManagerPlaceOfBirth");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Divisions_TeamDivision",
                table: "Teams",
                column: "TeamDivision",
                principalTable: "Divisions",
                principalColumn: "DivisionNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Manager_TeamManager",
                table: "Teams",
                column: "TeamManager",
                principalTable: "Manager",
                principalColumn: "ManagerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Stadiums_TeamStadium",
                table: "Teams",
                column: "TeamStadium",
                principalTable: "Stadiums",
                principalColumn: "StadiumId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Divisions_TeamDivision",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Manager_TeamManager",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Stadiums_TeamStadium",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TeamManager",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamManager",
                table: "Teams");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Divisions_TeamDivision",
                table: "Teams",
                column: "TeamDivision",
                principalTable: "Divisions",
                principalColumn: "DivisionNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Stadiums_TeamStadium",
                table: "Teams",
                column: "TeamStadium",
                principalTable: "Stadiums",
                principalColumn: "StadiumId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
