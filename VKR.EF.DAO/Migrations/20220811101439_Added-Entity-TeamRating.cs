using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedEntityTeamRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamRating",
                columns: table => new
                {
                    TeamAbbreviation = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    StrikeZoneProbability = table.Column<int>(type: "int", nullable: false),
                    HitByPitchProbability = table.Column<int>(type: "int", nullable: false),
                    SwingInStrikeZoneProbability = table.Column<byte>(type: "tinyint", nullable: false),
                    SwingOutsideStrikeZoneProbability = table.Column<byte>(type: "tinyint", nullable: false),
                    HittingProbability = table.Column<short>(type: "smallint", nullable: false),
                    FoulProbability = table.Column<short>(type: "smallint", nullable: false),
                    SingleProbability = table.Column<short>(type: "smallint", nullable: false),
                    DoubleProbability = table.Column<short>(type: "smallint", nullable: false),
                    HomeRunProbability = table.Column<short>(type: "smallint", nullable: false),
                    TripleProbability = table.Column<short>(type: "smallint", nullable: false),
                    PopoutOnFoulProbability = table.Column<short>(type: "smallint", nullable: false),
                    FlyoutOnHomeRunProbability = table.Column<short>(type: "smallint", nullable: false),
                    GroundoutProbability = table.Column<short>(type: "smallint", nullable: false),
                    FlyoutProbability = table.Column<short>(type: "smallint", nullable: false),
                    DoublePlayProbability = table.Column<byte>(type: "tinyint", nullable: false),
                    SacrificeFlyProbability = table.Column<byte>(type: "tinyint", nullable: false),
                    StealingBaseProbability = table.Column<short>(type: "smallint", nullable: false),
                    StealingBaseSuccessfulAttemptProbability = table.Column<byte>(type: "tinyint", nullable: false),
                    SuccessfulBuntAttemptProbability = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRating", x => x.TeamAbbreviation);
                    table.CheckConstraint("StrikeZoneProbability1", "StrikeZoneProbability BETWEEN 1 AND 3000");
                    table.CheckConstraint("HitByPitchProbability1", "HitByPitchProbability BETWEEN 1 AND 3000");
                    table.CheckConstraint("SwingInStrikeZoneProbability1", "SwingInStrikeZoneProbability BETWEEN 1 AND 100");
                    table.CheckConstraint("SwingOutsideStrikeZoneProbability1", "SwingOutsideStrikeZoneProbability BETWEEN 1 AND 100");
                    table.CheckConstraint("HittingProbability1", "HittingProbability BETWEEN 1 AND 2000");
                    table.CheckConstraint("FoulProbability1", "FoulProbability BETWEEN 1 AND 2000");
                    table.CheckConstraint("SingleProbability1", "SingleProbability BETWEEN 1 AND 2000");
                    table.CheckConstraint("DoubleProbability1", "DoubleProbability BETWEEN 1 AND 2000");
                    table.CheckConstraint("HomeRunProbability1", "HomeRunProbability BETWEEN 1 AND 2000");
                    table.CheckConstraint("TripleProbability1", "TripleProbability BETWEEN 1 AND 2000");
                    table.CheckConstraint("PopoutOnFoulProbability1", "PopoutOnFoulProbability BETWEEN 1 AND 1000");
                    table.CheckConstraint("FlyoutOnHomeRunProbability1", "FlyoutOnHomeRunProbability BETWEEN 1 AND 1000");
                    table.CheckConstraint("GroundoutProbability1", "GroundoutProbability BETWEEN 1 AND 1000");
                    table.CheckConstraint("FlyoutProbability1", "FlyoutProbability BETWEEN 1 AND 1000");
                    table.CheckConstraint("DoublePlayProbability1", "DoublePlayProbability BETWEEN 1 AND 100");
                    table.CheckConstraint("SacrificeFlyProbability1", "SacrificeFlyProbability BETWEEN 1 AND 100");
                    table.CheckConstraint("StealingBaseProbability1", "StealingBaseProbability BETWEEN 1 AND 1000");
                    table.CheckConstraint("StealingBaseSuccessfulAttemptProbability1", "StealingBaseSuccessfulAttemptProbability BETWEEN 1 AND 100");
                    table.CheckConstraint("SuccessfulBuntAttemptProbability1", "SuccessfulBuntAttemptProbability BETWEEN 1 AND 1000");
                    table.ForeignKey(
                        name: "FK_TeamRating_Teams_TeamAbbreviation",
                        column: x => x.TeamAbbreviation,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamRating");
        }
    }
}
