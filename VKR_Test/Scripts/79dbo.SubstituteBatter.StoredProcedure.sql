CREATE PROCEDURE [dbo].[SubstituteBatter]
(
@Match int,
@Team nvarchar(3),
@NewPitcher int,
@Position nvarchar(2),
@Number int
)
AS
DECLARE @PlayerInTeam int, @DHRule bit

SELECT @PlayerInTeam = PlayerInTeamID
FROM PlayersInTeams
WHERE TeamID = @Team AND PlayerID = @NewPitcher

SELECT @DHRule = Matches.DHRule
FROM Matches
WHERE MatchID = @Match

INSERT INTO LineupsForMatches Values(@Match, @PlayerInTeam, @Number, @Position)

IF @Position = 'P' AND @Number = 9 AND @DHRule = 0
	INSERT INTO LineupsForMatches Values(@Match, @PlayerInTeam, 10, 'P')
