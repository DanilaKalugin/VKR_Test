CREATE PROCEDURE [dbo].[GetStartingPitcherForThisTeam]
(
@Match int,
@Team nvarchar(3)
)
AS
SELECT PitcherStatistics.*, PlayerPositionInLineup
FROM PitcherStatistics INNER JOIN PlayersInTeams ON PitcherStatistics.PlayerID = PlayersInTeams.PlayerID
						INNER JOIN StartingLineups On PlayersInTeams.PlayerInTeamID = StartingLineups.PlayerInTeamID
WHERE PitcherStatistics.PlayerID IN (SELECT TOP 1 PlayerID
					FROM LineupsForMatches Inner JOIN PlayersInTeams ON LineupsForMatches.PlayerInTeamID = PlayersInTeams.PlayerInTeamID
					WHERE NumberInLineup = 10
					AND Match = @Match AND TeamID = @Team)

