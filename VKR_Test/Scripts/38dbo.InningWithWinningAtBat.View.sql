CREATE View [dbo].[InningWithWinningAtBat] AS
SELECT Match, Inning
FROM AtBats
WHERE AtBatID IN (SELECT WinningAtBat
			      FROM WinningAtBats)
