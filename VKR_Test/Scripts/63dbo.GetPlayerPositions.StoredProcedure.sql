CREATE PROCEDURE [dbo].[GetPlayerPositions]
(
@Code int
)
AS
SELECT PlayerPositionID
FROM PlayersPositions
WHERE PlayerID = @Code
