using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class FixedNamesOfTablesAtBatsAndStartingLineups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtBat_Matches_Match",
                table: "AtBat");

            migrationBuilder.DropForeignKey(
                name: "FK_AtBat_PlayersInTeams_Batter",
                table: "AtBat");

            migrationBuilder.DropForeignKey(
                name: "FK_AtBat_PlayersInTeams_Pitcher",
                table: "AtBat");

            migrationBuilder.DropForeignKey(
                name: "FK_AtBat_TypesOfAtBatResults_AtBatResult",
                table: "AtBat");

            migrationBuilder.DropForeignKey(
                name: "FK_StartingLineup_LineupType_LineupTypeId",
                table: "StartingLineup");

            migrationBuilder.DropForeignKey(
                name: "FK_StartingLineup_PlayerPositions_PlayerPosition",
                table: "StartingLineup");

            migrationBuilder.DropForeignKey(
                name: "FK_StartingLineup_PlayersInTeams_PlayerInTeamId",
                table: "StartingLineup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StartingLineup",
                table: "StartingLineup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtBat",
                table: "AtBat");

            migrationBuilder.RenameTable(
                name: "StartingLineup",
                newName: "StartingLineups");

            migrationBuilder.RenameTable(
                name: "AtBat",
                newName: "AtBats");

            migrationBuilder.RenameIndex(
                name: "IX_StartingLineup_PlayerPosition",
                table: "StartingLineups",
                newName: "IX_StartingLineups_PlayerPosition");

            migrationBuilder.RenameIndex(
                name: "IX_StartingLineup_LineupTypeId",
                table: "StartingLineups",
                newName: "IX_StartingLineups_LineupTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AtBat_Pitcher",
                table: "AtBats",
                newName: "IX_AtBats_Pitcher");

            migrationBuilder.RenameIndex(
                name: "IX_AtBat_Match",
                table: "AtBats",
                newName: "IX_AtBats_Match");

            migrationBuilder.RenameIndex(
                name: "IX_AtBat_Batter",
                table: "AtBats",
                newName: "IX_AtBats_Batter");

            migrationBuilder.RenameIndex(
                name: "IX_AtBat_AtBatResult",
                table: "AtBats",
                newName: "IX_AtBats_AtBatResult");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StartingLineups",
                table: "StartingLineups",
                columns: new[] { "PlayerInTeamId", "LineupTypeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtBats",
                table: "AtBats",
                column: "AtBatID");

            migrationBuilder.AddForeignKey(
                name: "FK_AtBats_Matches_Match",
                table: "AtBats",
                column: "Match",
                principalTable: "Matches",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtBats_PlayersInTeams_Batter",
                table: "AtBats",
                column: "Batter",
                principalTable: "PlayersInTeams",
                principalColumn: "PlayerInTeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtBats_PlayersInTeams_Pitcher",
                table: "AtBats",
                column: "Pitcher",
                principalTable: "PlayersInTeams",
                principalColumn: "PlayerInTeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AtBats_TypesOfAtBatResults_AtBatResult",
                table: "AtBats",
                column: "AtBatResult",
                principalTable: "TypesOfAtBatResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StartingLineups_LineupType_LineupTypeId",
                table: "StartingLineups",
                column: "LineupTypeId",
                principalTable: "LineupType",
                principalColumn: "LineupTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StartingLineups_PlayerPositions_PlayerPosition",
                table: "StartingLineups",
                column: "PlayerPosition",
                principalTable: "PlayerPositions",
                principalColumn: "PositionCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StartingLineups_PlayersInTeams_PlayerInTeamId",
                table: "StartingLineups",
                column: "PlayerInTeamId",
                principalTable: "PlayersInTeams",
                principalColumn: "PlayerInTeamID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtBats_Matches_Match",
                table: "AtBats");

            migrationBuilder.DropForeignKey(
                name: "FK_AtBats_PlayersInTeams_Batter",
                table: "AtBats");

            migrationBuilder.DropForeignKey(
                name: "FK_AtBats_PlayersInTeams_Pitcher",
                table: "AtBats");

            migrationBuilder.DropForeignKey(
                name: "FK_AtBats_TypesOfAtBatResults_AtBatResult",
                table: "AtBats");

            migrationBuilder.DropForeignKey(
                name: "FK_StartingLineups_LineupType_LineupTypeId",
                table: "StartingLineups");

            migrationBuilder.DropForeignKey(
                name: "FK_StartingLineups_PlayerPositions_PlayerPosition",
                table: "StartingLineups");

            migrationBuilder.DropForeignKey(
                name: "FK_StartingLineups_PlayersInTeams_PlayerInTeamId",
                table: "StartingLineups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StartingLineups",
                table: "StartingLineups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtBats",
                table: "AtBats");

            migrationBuilder.RenameTable(
                name: "StartingLineups",
                newName: "StartingLineup");

            migrationBuilder.RenameTable(
                name: "AtBats",
                newName: "AtBat");

            migrationBuilder.RenameIndex(
                name: "IX_StartingLineups_PlayerPosition",
                table: "StartingLineup",
                newName: "IX_StartingLineup_PlayerPosition");

            migrationBuilder.RenameIndex(
                name: "IX_StartingLineups_LineupTypeId",
                table: "StartingLineup",
                newName: "IX_StartingLineup_LineupTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AtBats_Pitcher",
                table: "AtBat",
                newName: "IX_AtBat_Pitcher");

            migrationBuilder.RenameIndex(
                name: "IX_AtBats_Match",
                table: "AtBat",
                newName: "IX_AtBat_Match");

            migrationBuilder.RenameIndex(
                name: "IX_AtBats_Batter",
                table: "AtBat",
                newName: "IX_AtBat_Batter");

            migrationBuilder.RenameIndex(
                name: "IX_AtBats_AtBatResult",
                table: "AtBat",
                newName: "IX_AtBat_AtBatResult");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StartingLineup",
                table: "StartingLineup",
                columns: new[] { "PlayerInTeamId", "LineupTypeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtBat",
                table: "AtBat",
                column: "AtBatID");

            migrationBuilder.AddForeignKey(
                name: "FK_AtBat_Matches_Match",
                table: "AtBat",
                column: "Match",
                principalTable: "Matches",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtBat_PlayersInTeams_Batter",
                table: "AtBat",
                column: "Batter",
                principalTable: "PlayersInTeams",
                principalColumn: "PlayerInTeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtBat_PlayersInTeams_Pitcher",
                table: "AtBat",
                column: "Pitcher",
                principalTable: "PlayersInTeams",
                principalColumn: "PlayerInTeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AtBat_TypesOfAtBatResults_AtBatResult",
                table: "AtBat",
                column: "AtBatResult",
                principalTable: "TypesOfAtBatResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StartingLineup_LineupType_LineupTypeId",
                table: "StartingLineup",
                column: "LineupTypeId",
                principalTable: "LineupType",
                principalColumn: "LineupTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StartingLineup_PlayerPositions_PlayerPosition",
                table: "StartingLineup",
                column: "PlayerPosition",
                principalTable: "PlayerPositions",
                principalColumn: "PositionCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StartingLineup_PlayersInTeams_PlayerInTeamId",
                table: "StartingLineup",
                column: "PlayerInTeamId",
                principalTable: "PlayersInTeams",
                principalColumn: "PlayerInTeamID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
