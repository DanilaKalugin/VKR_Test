CREATE PROCEDURE [dbo].[FinishMatch]
(
@Match int
)
AS
UPDATE Matches
SET MatchEnded = 1
Where MatchID = @Match
