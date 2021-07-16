CREATE PROCEDURE [dbo].[GetStartingPitcherID]
(
	@Team nvarchar(3),
	@ID int output
)
AS
DECLARE @Matches int, @PitcherNumberInLineUp int, @Pitcher_NumberInLineUp int
SELECT @Matches = COUNT(MatchID) + 1
From Matches
WHERE HomeTeam = @Team OR AwayTeam = @Team And IsQuickMatch = 0

SELECT @Pitcher_NumberInLineUp = @Matches % 5

IF @Pitcher_NumberInLineUp = 0
SET @PitcherNumberInLineUp = 5
ELSE SET @PitcherNumberInLineUp = @Pitcher_NumberInLineUp

SELECT @ID = Players.PlayerID
FROM (Players INNER JOIN PlayersInTeams ON Players.PlayerID = PlayersInTeams.PlayerID) 
			   INNER JOIN StartingLineups ON StartingLineups.PlayerInTeamID = PlayersInTeams.PlayerInTeamID
WHERE StartingLineups.LineupType = 5 AND PlayerPositionInLineup = @PitcherNumberInLineUp AND PlayersInTeams.TeamID = @Team

