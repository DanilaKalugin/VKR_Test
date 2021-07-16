CREATE PROCEDURE [dbo].[SubstitutePitcher]
(
@Match int,
@Team nvarchar(3),
@NewPitcher int
)
AS
DECLARE @PlayerInTeam int, @DHRule bit

SELECT @PlayerInTeam = PlayerInTeamID
FROM PlayersInTeams
WHERE TeamID = @Team AND PlayerID = @NewPitcher

SELECT @DHRule = Matches.DHRule
FROM Matches
WHERE MatchID = @Match

INSERT INTO LineupsForMatches Values(@Match, @PlayerInTeam, 10, 'P')

IF @DHRule = 0
	INSERT INTO LineupsForMatches Values(@Match, @PlayerInTeam, 9, 'P')

