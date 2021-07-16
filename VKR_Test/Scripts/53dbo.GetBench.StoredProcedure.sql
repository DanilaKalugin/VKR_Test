CREATE PROCEDURE [dbo].[GetBench]
AS
SELECT Players.PlayerID, PlayerFirstName, PlayerSecondName, PlayerNumber, CityName + ', ' + Country As PlaceOfBirth, PlayerDateOfBirth, TeamID, 1 AS LineupType, 0 AS PositionInLineup, PlayerBattingHand, PlayerPitchingHand
FROM PlayersInTeams INNER JOIN Players On Players.PlayerID = PlayersInTeams.PlayerID
					 INNER JOIN Cities On PlayerPlaceOfBirth = CityID
WHERE PlayersInTeams.PlayerInTeamID NOT IN (SELECT PlayerInTeamID
											 FROM StartingLineups
											 WHERE LineupType = 1)
AND PlayersInTeams.PlayerID NOT IN (SELECT PlayerID
									FROM PlayersPositions
									WHERE PlayerPositionID = 'P')
AND InActiveRoster = 1
AND InCurrentTeam = 1
UNION ALL
SELECT Players.PlayerID, PlayerFirstName, PlayerSecondName, PlayerNumber, CityName + ', ' + Country As PlaceOfBirth, PlayerDateOfBirth, TeamID, 2 AS LineupType, 0 AS PositionInLineup, PlayerBattingHand, PlayerPitchingHand
FROM PlayersInTeams INNER JOIN Players On Players.PlayerID = PlayersInTeams.PlayerID
					 INNER JOIN Cities On PlayerPlaceOfBirth = CityID
WHERE PlayersInTeams.PlayerInTeamID NOT IN (SELECT PlayerInTeamID
											 FROM StartingLineups
											 WHERE LineupType = 2)
AND PlayersInTeams.PlayerID NOT IN (SELECT PlayerID
									FROM PlayersPositions
									WHERE PlayerPositionID = 'P')
AND InActiveRoster = 1
AND InCurrentTeam = 1
UNION ALL
SELECT Players.PlayerID, PlayerFirstName, PlayerSecondName, PlayerNumber, CityName + ', ' + Country As PlaceOfBirth, PlayerDateOfBirth, TeamID, 3 AS LineupType, 0 AS PositionInLineup, PlayerBattingHand, PlayerPitchingHand
FROM PlayersInTeams INNER JOIN Players On Players.PlayerID = PlayersInTeams.PlayerID
					 INNER JOIN Cities On PlayerPlaceOfBirth = CityID
WHERE PlayersInTeams.PlayerInTeamID NOT IN (SELECT PlayerInTeamID
											 FROM StartingLineups
											 WHERE LineupType = 3)
AND PlayersInTeams.PlayerID NOT IN (SELECT PlayerID
									FROM PlayersPositions
									WHERE PlayerPositionID = 'P')
AND InActiveRoster = 1
AND InCurrentTeam = 1
UNION ALL
SELECT Players.PlayerID, PlayerFirstName, PlayerSecondName, PlayerNumber, CityName + ', ' + Country As PlaceOfBirth, PlayerDateOfBirth, TeamID, 4 AS LineupType, 0 AS PositionInLineup, PlayerBattingHand, PlayerPitchingHand
FROM PlayersInTeams INNER JOIN Players On Players.PlayerID = PlayersInTeams.PlayerID
					 INNER JOIN Cities On PlayerPlaceOfBirth = CityID
WHERE PlayersInTeams.PlayerInTeamID NOT IN (SELECT PlayerInTeamID
											 FROM StartingLineups
											 WHERE LineupType = 4)
AND PlayersInTeams.PlayerID NOT IN (SELECT PlayerID
									FROM PlayersPositions
									WHERE PlayerPositionID = 'P')
AND InActiveRoster = 1
AND InCurrentTeam = 1
									UNION ALL
SELECT Players.PlayerID, PlayerFirstName, PlayerSecondName, PlayerNumber, CityName + ', ' + Country As PlaceOfBirth, PlayerDateOfBirth, TeamID, 5 AS LineupType, 0 AS PositionInLineup, PlayerBattingHand, PlayerPitchingHand
FROM PlayersInTeams INNER JOIN Players On Players.PlayerID = PlayersInTeams.PlayerID
					 INNER JOIN Cities On PlayerPlaceOfBirth = CityID
WHERE PlayersInTeams.PlayerInTeamID NOT IN (SELECT PlayerInTeamID
											 FROM StartingLineups
											 WHERE LineupType = 5)
AND PlayersInTeams.PlayerID IN (SELECT PlayerID
									FROM PlayersPositions
									WHERE PlayerPositionID = 'P')
AND InActiveRoster = 1
AND InCurrentTeam = 1
ORDER BY PlayerID, LineupType

