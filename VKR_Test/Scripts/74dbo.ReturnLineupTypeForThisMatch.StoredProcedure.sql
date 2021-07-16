CREATE PROCEDURE [dbo].[ReturnLineupTypeForThisMatch]
(
@Hand nvarchar(5),
@DHRule bit,
@LineupType int output
)
AS
IF @DHRule = 1
		IF @Hand = 'Right'
			SET @LineupType = 1
		ELSE 
			SET @LineupType = 3
	ELSE
		IF @Hand = 'Right'
			SET @LineupType = 2
		ELSE 
			SET @LineupType = 4

