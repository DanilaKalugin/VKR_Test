CREATE PROCEDURE [dbo].[GetAvailableBattersForSubstitution]
(
@Position nvarchar(2),
@Team nvarchar(3),
@Match int
)
AS
IF @Position = 'DH'
SELECT DISTINCT BatterStatistics.*
FROM BatterStatistics Inner Join PlayersPositions On BatterStatistics.PlayerID = PlayersPositions.PlayerID
	INNER JOIN PlayersInTeams On BatterStatistics.PlayerID = PlayersInTeams.PlayerID
WHERE PlayerPositionID <> 'P' AND TeamID = @Team 
AND BatterStatistics.PlayerID NOT IN (SELECT PlayerID
									  FROM PlayersInTeams INNER JOIN LineupsForMatches ON PlayersInTeams.PlayerInTeamID = LineupsForMatches.PlayerInTeamID
									  WHERE Match = @Match)
AND InActiveRoster = 1 And InCurrentTeam = 1
ELSE IF @Position <> 'P'
SELECT BatterStatistics.*
FROM BatterStatistics Inner Join PlayersPositions On BatterStatistics.PlayerID = PlayersPositions.PlayerID
	INNER JOIN PlayersInTeams On BatterStatistics.PlayerID = PlayersInTeams.PlayerID
WHERE PlayerPositionID = @Position AND TeamID = @Team 
AND BatterStatistics.PlayerID NOT IN (SELECT PlayerID
									  FROM PlayersInTeams INNER JOIN LineupsForMatches ON PlayersInTeams.PlayerInTeamID = LineupsForMatches.PlayerInTeamID
									  WHERE Match = @Match)
									  AND InActiveRoster = 1 And InCurrentTeam = 1
ELSE SELECT BatterStatistics.*
FROM BatterStatistics Inner Join PlayersPositions On BatterStatistics.PlayerID = PlayersPositions.PlayerID
	INNER JOIN PlayersInTeams On BatterStatistics.PlayerID = PlayersInTeams.PlayerID
WHERE PlayerPositionID = @Position AND TeamID = @Team 
AND BatterStatistics.PlayerID NOT IN (SELECT PlayerID
										FROM PlayersInTeams INNER JOIN StartingLineups ON PlayersInTeams.PlayerInTeamID = StartingLineups.PlayerInTeamID
										WHERE LineupType = 5
									  UNION SELECT PlayerID
										FROM PlayersInTeams INNER JOIN LineupsForMatches ON PlayersInTeams.PlayerInTeamID = LineupsForMatches.PlayerInTeamID
										WHERE Match = @Match)
										AND InActiveRoster = 1 And InCurrentTeam = 1