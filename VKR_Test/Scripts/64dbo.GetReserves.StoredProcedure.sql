CREATE PROCEDURE [dbo].[GetReserves]
AS
SELECT Players.PlayerID, PlayerFirstName, PlayerSecondName, PlayerNumber, CityName + ', ' + Country As PlaceOfBirth, PlayerDateOfBirth, TeamID, 1 AS LineupType, 0 AS PositionInLineup, PlayerBattingHand, PlayerPitchingHand
FROM PlayersInTeams INNER JOIN Players On Players.PlayerID = PlayersInTeams.PlayerID
					 INNER JOIN Cities On PlayerPlaceOfBirth = CityID
					 INNER JOIN Teams ON PlayersInTeams.TeamID = TeamAbbreviation
WHERE InActiveRoster = 0
AND InCurrentTeam = 1
ORDER BY TeamName, LineupType
