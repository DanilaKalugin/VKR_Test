CREATE PROCEDURE [dbo].[GetPitcherStatsByCode]
(
@Code int
)
AS
SELECT *
FROM PitcherStatistics
WHERE PlayerID = @Code
