CREATE PROCEDURE [dbo].[GetCurrentLineupForThisMatch]
(
@Match int,
@Team nvarchar(3)
)
AS
SELECT BatterStatistics.*, NumberInLineup, PlayerPosition, PlayersInTeams.PlayerID
FROM BatterStatistics RIGHT JOIN PlayersInTeams On BatterStatistics.PlayerID = PlayersInTeams.PlayerID
				  INNER JOIN LineupsForMatches On PlayersInTeams.PlayerInTeamID = LineupsForMatches.PlayerInTeamID
WHERE PlayersInTeams.PlayerInTeamID IN (
SELECT LineupsForMatches.PlayerInTeamID
FROM LineupsForMatches INNER JOIN PlayersInTeams ON PlayersInTeams.PlayerInTeamID = LineupsForMatches.PlayerInTeamID
WHERE Match = @Match AND NumberInLineup < 10 AND TeamID = @Team AND InCurrentTeam = 1
	AND PlayerInMatchLineupID IN (SELECT MAX(PlayerInMatchLineupID)
									FROM LineupsForMatches INNER JOIN PlayersInTeams ON PlayersInTeams.PlayerInTeamID = LineupsForMatches.PlayerInTeamID
									WHERE Match = @Match AND NumberInLineup < 10 AND TeamID = @Team AND InCurrentTeam = 1
									GROUP BY NumberInLineup)
) 
AND NumberInLineup < 10 AND Match = @Match AND InCurrentTeam = 1
Order BY NumberInLineup
