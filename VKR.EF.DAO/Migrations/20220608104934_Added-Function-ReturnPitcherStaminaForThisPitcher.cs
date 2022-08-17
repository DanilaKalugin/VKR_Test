using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedFunctionReturnPitcherStaminaForThisPitcher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetStaminaForThisPitcher
            (
                @Pitcher int,
                @MatchDate date
            )
            RETURNS INT
            AS
                BEGIN
            DECLARE @DayNumber int, @OutsPlayedByThisDay int, @TotalOutsCorrectedByDay int, @RunsForThisDay int, @RunsCorrectedByDay int,
            @HitsForThisDay int, @HitsCorrectedByDay int
            SET @DayNumber = 4
            SET @TotalOutsCorrectedByDay = 0
            SET @RunsCorrectedByDay = 0
            SET @HitsCorrectedByDay = 0

            WHILE @DayNumber >= 0
            BEGIN
            SELECT @OutsPlayedByThisDay = ISNULL(SUM(Outs), 0)
            FROM ExpandedAtBats INNER JOIN Matches ON Match = MatchID
            WHERE MatchType <> 0 AND Pitcher = @Pitcher AND AtBatResult <> 12
            AND Match IN(SELECT MatchID
            FROM Matches
            WHERE MatchDate = DATEADD(Day, (-1) * @DayNumber, @MatchDate))

            SELECT @TotalOutsCorrectedByDay = @TotalOutsCorrectedByDay + @OutsPlayedByThisDay * (8 - @DayNumber * 2)

            SELECT @HitsForThisDay = ISNULL(Count(CASE WHEN AtBatResult BETWEEN 7 AND 10 OR AtBatResult BETWEEN 2 AND 3 Then 1 ELSE NULL END), 0)
            FROM ExpandedAtBats INNER JOIN Matches ON Match = MatchID
            WHERE MatchType <> 0 AND Pitcher = @Pitcher
            AND Match IN(SELECT MatchID
            FROM Matches
            WHERE MatchDate = DATEADD(Day, (-1) * @DayNumber, @MatchDate))

            SET @HitsCorrectedByDay = @HitsCorrectedByDay + @HitsForThisDay * (10 - @DayNumber * 2)

            SELECT @RunsForThisDay = ISNULL(Count(CASE WHEN AtBatResult = 13 Then 1 ELSE NULL END), 0)
            FROM ExpandedAtBats INNER JOIN Matches ON Match = MatchID
            WHERE MatchType <> 0 AND Pitcher = @Pitcher
            AND Match IN(SELECT MatchID
            FROM Matches
            WHERE MatchDate = DATEADD(Day, (-1) * @DayNumber, @MatchDate))

            SET @RunsCorrectedByDay = @RunsCorrectedByDay + @RunsForThisDay * (6 - @DayNumber)

            SET @DayNumber = @DayNumber - 1
            END

                RETURN 250 - @TotalOutsCorrectedByDay - @RunsCorrectedByDay - @HitsCorrectedByDay
            END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION GetStaminaForThisPitcher");
        }
    }
}
