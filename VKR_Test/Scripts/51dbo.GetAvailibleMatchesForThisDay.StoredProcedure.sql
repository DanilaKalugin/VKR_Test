CREATE PROCEDURE [dbo].[GetAvailibleMatchesForThisDay]
(
@Date date
)
AS
SELECT *
FROM NextMatches
WHERE IsPlayed = 0 AND MatchDate = @Date

