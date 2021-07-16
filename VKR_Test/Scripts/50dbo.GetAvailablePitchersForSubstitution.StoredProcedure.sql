CREATE PROCEDURE [dbo].[GetAvailablePitchersForSubstitution]
(
@Match int,
@Team nvarchar(3)
)
AS
SELECT PitcherStatistics.*
FROM PitcherStatistics INNER JOIN PlayersInTeams On PlayersInTeams.PlayerID = PitcherStatistics.PlayerID
Where PitcherStatistics.PlayerID NOT IN (SELECT PlayerID
						FROM PlayersInTeams INNER JOIN StartingLineups ON PlayersInTeams.PlayerInTeamID = StartingLineups.PlayerInTeamID
						WHERE LineupType = 5
						UNION 
						SELECT PlayerID
						FROM PlayersInTeams INNER JOIN LineupsForMatches ON PlayersInTeams.PlayerInTeamID = LineupsForMatches.PlayerInTeamID
						WHERE Match = @Match)
						AND TeamID = @Team 
						AND InActiveRoster = 1  
						And InCurrentTeam = 1

