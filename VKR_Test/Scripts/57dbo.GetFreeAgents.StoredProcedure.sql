CREATE PROCEDURE [dbo].[GetFreeAgents]
AS
SELECT Players.PlayerID, PlayerFirstName, PlayerSecondName, PlayerNumber, CityName + ', ' + Country As PlaceOfBirth, PlayerDateOfBirth, '' As TeamID, 1 AS LineupType, 0 AS PositionInLineup, PlayerBattingHand, PlayerPitchingHand
FROM PlayersInTeams INNER JOIN Players On Players.PlayerID = PlayersInTeams.PlayerID
					 INNER JOIN Cities On PlayerPlaceOfBirth = CityID
					 INNER JOIN Teams ON PlayersInTeams.TeamID = TeamAbbreviation
WHERE Players.PlayerID NOT IN (SELECT PlayerID
							   FROM PlayersInTeams
							   WHERE InCurrentTeam = 1
							   GROUP BY PlayerID)
ORDER BY PlayerSecondName, PlayerFirstName

