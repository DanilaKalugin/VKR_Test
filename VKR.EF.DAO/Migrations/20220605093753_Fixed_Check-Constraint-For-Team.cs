using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class Fixed_CheckConstraintForTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "SuccessfulBuntAttemptProbability",
                table: "Teams");

            migrationBuilder.AddCheckConstraint(
                name: "SuccessfulBuntAttemptProbability",
                table: "Teams",
                sql: "SuccessfulBuntAttemptProbability BETWEEN 1 AND 1000");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "SuccessfulBuntAttemptProbability",
                table: "Teams");

            migrationBuilder.AddCheckConstraint(
                name: "SuccessfulBuntAttemptProbability",
                table: "Teams",
                sql: "SuccessfulBuntAttemptProbability BETWEEN 1 AND 100");
        }
    }
}
