CREATE PROCEDURE [dbo].[UpdatePitcherStats]
(
@Player int
)
AS
SELECT *
FROM PitcherStatistics
WHERE PlayerID = @Player
