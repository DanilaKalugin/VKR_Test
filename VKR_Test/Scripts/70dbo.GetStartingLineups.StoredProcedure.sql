SELECT Players.PlayerID, PlayerFirstName, PlayerSecondName, PlayerNumber, CityName + ', ' + Country As PlaceOfBirth, 
		PlayerDateOfBirth, TeamID, LineupType, PlayerPositionInLineup As PositionInLineup, PlayerPosition, PlayerBattingHand, PlayerPitchingHand
FROM StartingLineups INNER JOIN PlayersInTeams ON StartingLineups.PlayerInTeamID = PlayersInTeams.PlayerInTeamID
					 INNER JOIN Players On Players.PlayerID = PlayersInTeams.PlayerID
					 INNER JOIN Cities On PlayerPlaceOfBirth = CityID
WHERE InCurrentTeam = 1 AND InActiveRoster = 1
Order BY LineupType, PlayerPositionInLineup
