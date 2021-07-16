CREATE PROCEDURE [dbo].[GetNumberOfMatchesPlayed]
(
@QuickMatch bit,
@MatchID int output
)
AS
DECLARE @MaxMatchID int
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
