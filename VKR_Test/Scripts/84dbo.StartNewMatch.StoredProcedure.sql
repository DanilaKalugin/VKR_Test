CREATE PROCEDURE [dbo].[StartNewMatch]
(
	@AwayTeam nvarchar(3),
	@HomeTeam nvarchar(3),
	@Stadium int,
	@DHRule bit,
	@Date date,
	@QuickMatch bit
)
AS
DECLARE @MatchID int, @MaxMatchID int

IF @QuickMatch = 1
BEGIN

SELECT @MaxMatchID = COUNT(MatchID)
	FROM Matches
	WHERE IsQuickMatch = 1

IF @MaxMatchID IS NULL
SET @MatchID = 10001
ELSE SET @MatchID = @MaxMatchID + 10001
END
ELSE
BEGIN

SELECT @MaxMatchID = COUNT(MatchID)
	FROM Matches
	WHERE IsQuickMatch = 0

IF @MaxMatchID IS NULL
SET @MatchID = 1
ELSE SET @MatchID = @MaxMatchID + 1
END

INSERT INTO Matches Values (@MatchID, NULL, NULL, NULL, 0, 0, NULL, @QuickMatch)

EXEC AddPlayersToTheMatch @MatchID, @AwayTeam, @DHRule
EXEC AddPlayersToTheMatch @MatchID, @HomeTeam, @DHRule

UPDATE Matches
SET AwayTeam = @AwayTeam, HomeTeam = @HomeTeam, Stadium = @Stadium, DHRule = @DHRule, MatchDate = @Date
WHERE MatchID = @MatchID

IF @QuickMatch = 0
UPDATE NextMatches
SET IsPlayed = 1
WHERE HomeTeam = @HomeTeam ANd AwayTeam = @AwayTeam AND MatchDate = @Date
