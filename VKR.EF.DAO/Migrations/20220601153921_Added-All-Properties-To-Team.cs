using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedAllPropertiesToTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "StrikeZoneProbability",
                table: "Teams");

            migrationBuilder.AddColumn<byte>(
                name: "SwingOutsideStrikeZoneProbability",
                table: "Teams",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<short>(
                name: "HitByPitchProbability",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "HittingProbability",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "FoulProbability",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "SingleProbability",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "DoubleProbability",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "HomeRunProbability",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "TripleProbability",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "PopoutOnFoulProbability",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "FlyoutOnHomeRunProbability",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "GroundoutProbability",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "FlyoutProbability",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<byte>(
                name: "SacrificeFlyProbability",
                table: "Teams",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "DoublePlayProbability",
                table: "Teams",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<short>(
                name: "StealingBaseProbability",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<byte>(
                name: "StealingBaseSuccessfulAttemptProbability",
                table: "Teams",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<short>(
                name: "SuccessfulBuntAttemptProbability",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Teams_TeamCity_TeamName",
                table: "Teams",
                columns: new[] { "TeamCity", "TeamName" });

            migrationBuilder.AddCheckConstraint(
                name: "StrikeZoneProbability",
                table: "Teams",
                sql: "StrikeZoneProbability BETWEEN 1 AND 3000");

            migrationBuilder.AddCheckConstraint(
                name: "HitByPitchProbability",
                table: "Teams",
                sql: "HitByPitchProbability BETWEEN 1 AND 3000");

            migrationBuilder.AddCheckConstraint(
                name: "SwingOutsideStrikeZoneProbability",
                table: "Teams",
                sql: "SwingOutsideStrikeZoneProbability BETWEEN 1 AND 100");

            migrationBuilder.AddCheckConstraint(
                name: "HittingProbability",
                table: "Teams",
                sql: "HittingProbability BETWEEN 1 AND 2000");

            migrationBuilder.AddCheckConstraint(
                name: "FoulProbability",
                table: "Teams",
                sql: "FoulProbability BETWEEN 1 AND 2000");

            migrationBuilder.AddCheckConstraint(
                name: "SingleProbability",
                table: "Teams",
                sql: "SingleProbability BETWEEN 1 AND 2000");

            migrationBuilder.AddCheckConstraint(
                name: "DoubleProbability",
                table: "Teams",
                sql: "DoubleProbability BETWEEN 1 AND 2000");

            migrationBuilder.AddCheckConstraint(
                name: "HomeRunProbability",
                table: "Teams",
                sql: "HomeRunProbability BETWEEN 1 AND 2000");

            migrationBuilder.AddCheckConstraint(
                name: "TripleProbability",
                table: "Teams",
                sql: "TripleProbability BETWEEN 1 AND 2000");

            migrationBuilder.AddCheckConstraint(
                name: "PopoutOnFoulProbability",
                table: "Teams",
                sql: "PopoutOnFoulProbability BETWEEN 1 AND 1000");

            migrationBuilder.AddCheckConstraint(
                name: "FlyoutOnHomeRunProbability",
                table: "Teams",
                sql: "FlyoutOnHomeRunProbability BETWEEN 1 AND 1000");

            migrationBuilder.AddCheckConstraint(
                name: "GroundoutProbability",
                table: "Teams",
                sql: "GroundoutProbability BETWEEN 1 AND 1000");

            migrationBuilder.AddCheckConstraint(
                name: "FlyoutProbability",
                table: "Teams",
                sql: "FlyoutProbability BETWEEN 1 AND 1000");

            migrationBuilder.AddCheckConstraint(
                name: "DoublePlayProbability",
                table: "Teams",
                sql: "DoublePlayProbability BETWEEN 1 AND 100");

            migrationBuilder.AddCheckConstraint(
                name: "SacrificeFlyProbability",
                table: "Teams",
                sql: "SacrificeFlyProbability BETWEEN 1 AND 100");

            migrationBuilder.AddCheckConstraint(
                name: "StealingBaseProbability",
                table: "Teams",
                sql: "StealingBaseProbability BETWEEN 1 AND 1000");

            migrationBuilder.AddCheckConstraint(
                name: "StealingBaseSuccessfulAttemptProbability",
                table: "Teams",
                sql: "StealingBaseSuccessfulAttemptProbability BETWEEN 1 AND 100");

            migrationBuilder.AddCheckConstraint(
                name: "SuccessfulBuntAttemptProbability",
                table: "Teams",
                sql: "SuccessfulBuntAttemptProbability BETWEEN 1 AND 100");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Teams_TeamCity_TeamName",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "StrikeZoneProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "HitByPitchProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "SwingOutsideStrikeZoneProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "HittingProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "FoulProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "SingleProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "DoubleProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "HomeRunProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "TripleProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "PopoutOnFoulProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "FlyoutOnHomeRunProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "GroundoutProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "FlyoutProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "DoublePlayProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "SacrificeFlyProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "StealingBaseProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "StealingBaseSuccessfulAttemptProbability",
                table: "Teams");

            migrationBuilder.DropCheckConstraint(
                name: "SuccessfulBuntAttemptProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "DoublePlayProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "DoubleProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "FlyoutOnHomeRunProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "FlyoutProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "FoulProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GroundoutProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "HitByPitchProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "HittingProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "HomeRunProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "PopoutOnFoulProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "SacrificeFlyProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "SingleProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "StealingBaseProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "StealingBaseSuccessfulAttemptProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "SuccessfulBuntAttemptProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "SwingOutsideStrikeZoneProbability",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TripleProbability",
                table: "Teams");

            migrationBuilder.AddCheckConstraint(
                name: "StrikeZoneProbability",
                table: "Teams",
                sql: "StrikeZoneProbability BETWEEN 1 AND 2000");
        }
    }
}
