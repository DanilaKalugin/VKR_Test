CREATE PROCEDURE [dbo].[GetPlayerNameByID]
(
@Code int
)
AS
SELECT PlayerFirstName, PlayerSecondName
FROM Players
WHERE PlayerID = @Code
