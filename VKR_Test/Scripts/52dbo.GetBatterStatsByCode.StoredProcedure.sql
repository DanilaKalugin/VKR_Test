CREATE PROCEDURE [dbo].[GetBatterStatsByCode]
(
@Code int
)
AS
SELECT *
FROM BatterStatistics
WHERE PlayerID = @Code

