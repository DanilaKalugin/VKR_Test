CREATE PROCEDURE [dbo].[GetListOfPeopleWithBirthdayToday]
AS

SELECT Players.PlayerID, TeamID, PlayerFirstName, PlayerSecondName, PlayerDateOfBirth
    FROM Players INNER JOIN PlayersInTeams On Players.PlayerID = PlayersInTeams.PlayerID
	WHERE DAY(PlayerDateOfBirth) = DAY(GETDATE()) AND MONTH(PlayerDateOfBirth) = MONTH(GETDATE()) AND InCurrentTeam = 1
UNION
SELECT Players.PlayerID, '', PlayerFirstName, PlayerSecondName, PlayerDateOfBirth
    FROM Players INNER JOIN PlayersInTeams On Players.PlayerID = PlayersInTeams.PlayerID
	WHERE DAY(PlayerDateOfBirth) = DAY(GETDATE()) AND MONTH(PlayerDateOfBirth) = MONTH(GETDATE()) AND Players.PlayerID NOT IN  (SELECT PlayerID
																																FROM PlayersInTeams
																																WHERE InCurrentTeam = 1
																																GROUP BY PlayerID)
UNION
SELECT ManagerID, TeamAbbreviation, ManagerFirstName, ManagerSecondName, ManagerDateOfBirth
    FROM Managers INNER JOIN Teams On TeamManager = ManagerID
	WHERE DAY(ManagerDateOfBirth) = DAY(GETDATE()) AND MONTH(ManagerDateOfBirth) = MONTH(GETDATE())
