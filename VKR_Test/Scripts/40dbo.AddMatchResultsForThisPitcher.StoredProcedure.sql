CREATE PROCEDURE [dbo].[AddMatchResultsForThisPitcher]
(
@Match int,
@Team nvarchar(3),
@Player int,
@isQS bit,
@isCG bit,
@isSHO bit,
@IsW bit,
@IsL bit
)
AS
DECLARE @PitcherInTeam int

SELECT @PitcherInTeam = PlayersInTeams.PlayerInTeamID
FROM PlayersInTeams
WHERE PlayerID = @Player AND TeamID = @Team

INSERT INTO PitcherResults
VALUES (@PitcherInTeam, @Match, @isQS, @isCG, @isSHO, @IsW, @IsL, NULL, NULL)
