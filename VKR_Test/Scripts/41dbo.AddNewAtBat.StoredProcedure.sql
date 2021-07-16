CREATE PROCEDURE [dbo].[AddNewAtBat]
(
@MatchID int,
@Offense nvarchar(3),
@Batter int,
@AtBatResult int,
@Defense nvarchar(3),
@Pitcher int,
@Outs int,
@RBI int,
@Inning int
)
AS
DECLARE @BatterInTeamID int, @MaxAtBatID int, @AtBatID int, @PitcherInTeamID int

SELECT @BatterInTeamID = PlayersInTeams.PlayerInTeamID
FROM PlayersInTeams
WHERE PlayerID = @Batter AND TeamID = @Offense

SELECT @PitcherInTeamID = PlayersInTeams.PlayerInTeamID
FROM PlayersInTeams
WHERE PlayerID = @Pitcher AND TeamID = @Defense

SELECT @AtBatID = ISNULL(Max(AtBatID), 0) + 1
FROM AtBats

INSERT INTO AtBats Values(@AtBatID, @MatchID, @BatterInTeamID, @AtBatResult, @PitcherInTeamID, @Outs, @RBI, @Inning)

