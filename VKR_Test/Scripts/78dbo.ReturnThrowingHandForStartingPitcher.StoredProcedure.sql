CREATE PROCEDURE [dbo].[ReturnThrowingHandForStartingPitcher]
(
@Player int,
@ThrowingHand nvarchar(5) output
)
AS
SELECT @ThrowingHand = PlayerPitchingHand
FROM Players
WHERE PlayerID = @Player
