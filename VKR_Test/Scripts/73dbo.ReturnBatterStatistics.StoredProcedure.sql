CREATE PROCEDURE [dbo].[ReturnBatterStatistics]
AS
SELECT BatterStatistics.*, TeamID
FROM BatterStatistics INNER JOIN PlayersInTeams ON BatterStatistics.PlayerID = PlayersInTeams.PlayerID
WHERE G > 0 And InCurrentTeam = 1
UNION
SELECT BatterStatistics.*, ''
FROM BatterStatistics INNER JOIN PlayersInTeams ON BatterStatistics.PlayerID = PlayersInTeams.PlayerID
WHERE G > 0 And BatterStatistics.PlayerID NOT IN  (SELECT PlayerID
												FROM PlayersInTeams
												WHERE InCurrentTeam = 1
												GROUP BY PlayerID)

