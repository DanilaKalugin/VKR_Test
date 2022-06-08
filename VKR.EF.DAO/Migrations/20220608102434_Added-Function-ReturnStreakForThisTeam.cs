using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedFunctionReturnStreakForThisTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE Function ReturnStreakForThisTeam(@date date, @Team nvarchar(3), @MatchType tinyint)
RETURNS INT
AS
BEGIN
DECLARE @Result int;
With MatchRes AS
(
SELECT MatchID, AwayTeam, CASE WHEN Winner = AwayTeam THEN 1 ELSE -1 END As Result
FROM MatchResults
WHERE MatchDate <= @date 
AND AwayTeam = @Team 
And MatchType = @MatchType
AND Year(MatchDate) = Year(@Date)
UNION 
SELECT MatchID, HomeTeam, CASE WHEN Winner = HomeTeam THEN 1 ELSE -1 END
FROM MatchResults
WHERE MatchDate <= @date 
AND HomeTeam = @Team
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
SELECT @Result =  Count(m1.MatchID) * m1.Result
FROM MatchResWithStartOfStreak m1
WHERE m1.MatchID >= (SELECT MAX(MatchID)
					 FROM MatchResWithStartOfStreak m2
					 WHERE m2.StreakStarted IS NOT NULL AND m2.AwayTeam = @Team)
GROUP BY m1.AwayTeam, m1.Result

Return @Result 
END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION ReturnStreakForThisTeam");
        }
    }
}
