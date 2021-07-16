CREATE PROCEDURE [dbo].[ReturnPitcherStatistics]
AS

SELECT PitcherStatistics.*, TeamID
FROM PitcherStatistics INNER JOIN PlayersInTeams ON PitcherStatistics.PlayerID = PlayersInTeams.PlayerID
WHERE G > 0 And InCurrentTeam = 1
UNION
SELECT PitcherStatistics.*, ''
FROM PitcherStatistics INNER JOIN PlayersInTeams ON PitcherStatistics.PlayerID = PlayersInTeams.PlayerID
WHERE G > 0 And PitcherStatistics.PlayerID NOT IN  (SELECT PlayerID
												FROM PlayersInTeams
												WHERE InCurrentTeam = 1
												GROUP BY PlayerID)
