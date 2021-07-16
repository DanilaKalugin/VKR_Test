CREATE PROCEDURE [dbo].[DeleteMatch]
(
@Match int
)
AS
DECLARE @HomeTeam nvarchar(3), @AwayTeam nvarchar(3), @MatchDate date
SELECT @HomeTeam = HomeTeam
FROM Matches
WHERE MatchID = @Match

SELECT @HomeTeam = AwayTeam
FROM Matches
WHERE MatchID = @Match

SELECT @MatchDate = MatchDate
FROM Matches
WHERE MatchID = @Match

update NextMatches
SET IsPlayed = 0
WHERE HomeTeam = @HomeTeam AND AwayTeam = @AwayTeam AND MatchDate = @MatchDate

DELETE FROM Matches
WHERE MatchID = @Match
