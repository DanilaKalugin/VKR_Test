using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedFunctionGetStreakForAllTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE Function [dbo].[ReturnStreakForAllTeams](@date date, @MatchType tinyint)
            RETURNS TABLE
            AS
                RETURN(
                    With MatchRes AS
            (
                SELECT MatchID, AwayTeam, CASE WHEN Winner = AwayTeam THEN 1 ELSE - 1 END As Result
            FROM MatchResults
            WHERE MatchDate <= @date
            And MatchType = @MatchType
            AND Year(MatchDate) = Year(@Date)
            UNION
            SELECT MatchID, HomeTeam, CASE WHEN Winner = HomeTeam THEN 1 ELSE - 1 END
                FROM MatchResults
                WHERE MatchDate <= @date
            And MatchType = @MatchType
            AND Year(MatchDate) = Year(@Date)
                ),
            MatchResWithPrev AS
            (
                SELECT MatchID, AwayTeam, Result, LAG(Result) OVER(Partition BY AwayTeam

                    ORDER BY MatchID) As Prev
                    FROM MatchRes
            ),
            MatchResWithStartOfStreak AS
            (
                SELECT MatchID, AwayTeam, Result, Prev, CASE WHEN Result != Prev Then Result

            WHEN Prev IS NULL Then Result ELSE NULL END As StreakStarted
                FROM MatchResWithPrev
                )
            SELECT m1.AwayTeam, Count(m1.MatchID) * m1.Result As Streak
            FROM MatchResWithStartOfStreak m1
                WHERE m1.MatchID >= (SELECT MAX(MatchID)

            FROM MatchResWithStartOfStreak m2

                WHERE m2.StreakStarted IS NOT NULL AND m2.AwayTeam = m1.AwayTeam)
            GROUP BY m1.AwayTeam, m1.Result
                )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION ReturnStreakForAllTeams");
        }
    }
}
