using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerID = table.Column<long>(type: "bigint", nullable: false),
                    PlayerNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    PlayerFirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    PlayerSecondName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    PlayerDateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    PlaceOfBirth = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Player_Cities_PlaceOfBirth",
                        column: x => x.PlaceOfBirth,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_PlaceOfBirth",
                table: "Player",
                column: "PlaceOfBirth");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}