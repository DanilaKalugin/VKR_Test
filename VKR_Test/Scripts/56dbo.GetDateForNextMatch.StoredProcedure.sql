CREATE PROCEDURE [dbo].[GetDateForNextMatch]
AS
SELECT MIN(MatchDate)
FROM NextMatches
WHERE IsPlayed = 0
