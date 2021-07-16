CREATE PROCEDURE [dbo].[AddPlayersToTheMatch]
(
	@Match int,
    @Team nvarchar(3),
	@DHRule bit
)
AS
	DECLARE @LineupType int, @PitcherID int, @ThrowingHand nvarchar(5)

	EXEC GetStartingPitcherID @Team, @PitcherID output
	EXEC ReturnThrowingHandForStartingPitcher @PitcherID, @ThrowingHand output
	EXEC ReturnLineupTypeForThisMatch @ThrowingHand, @DHRule, @LineupType output

	INSERT INTO LineupsForMatches
	SELECT @Match, PlayersInTeams.PlayerInTeamID, PlayerPositionInLineup, StartingLineups.PlayerPosition
	From (Players INNER JOIN PlayersInTeams ON Players.PlayerID = PlayersInTeams.PlayerID)
					 LEFT JOIN StartingLineups ON PlayersInTeams.PlayerInTeamID = StartingLineups.PlayerInTeamID
	WHERE TeamID = @Team AND LineupType = @LineupType
	UNION
	SELECT @Match, PlayersInTeams.PlayerInTeamID, 9, 'P'
	From (Players INNER JOIN PlayersInTeams ON Players.PlayerID = PlayersInTeams.PlayerID)
					 LEFT JOIN StartingLineups ON PlayersInTeams.PlayerInTeamID = StartingLineups.PlayerInTeamID
	WHERE Players.PlayerID = @PitcherID AND @LineupType % 2 = 0 And InCurrentTeam = 1
	UNION ALL
	SELECT @Match, PlayersInTeams.PlayerInTeamID, 10, 'P'
FROM Players INNER JOIN PlayersInTeams ON Players.PlayerID = PlayersInTeams.PlayerID
			 LEFT JOIN StartingLineups ON PlayersInTeams.PlayerInTeamID = StartingLineups.PlayerInTeamID
WHERE Players.PlayerID = @PitcherID And InCurrentTeam = 1
ORDER BY StartingLineups.PlayerPositionInLineup

