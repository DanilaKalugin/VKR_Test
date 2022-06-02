using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityPlayerInTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayersInTeams",
                columns: table => new
                {
                    PlayerInTeamID = table.Column<long>(type: "bigint", nullable: false),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    TeamId = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    InTeamStatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersInTeams", x => x.PlayerInTeamID);
                    table.ForeignKey(
                        name: "FK_PlayersInTeams_InTeamStatuses_InTeamStatus",
                        column: x => x.InTeamStatus,
                        principalTable: "InTeamStatuses",
                        principalColumn: "InTeamStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayersInTeams_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayersInTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayersInTeams_InTeamStatus",
                table: "PlayersInTeams",
                column: "InTeamStatus");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersInTeams_PlayerId",
                table: "PlayersInTeams",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersInTeams_TeamId",
                table: "PlayersInTeams",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersInTeams");
        }
    }
}
