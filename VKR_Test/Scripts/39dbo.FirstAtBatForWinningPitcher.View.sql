CREATE VIEW [dbo].[FirstAtBatForWinningPitcher]
AS
SELECT        dbo.AtBats.Match, MIN(dbo.AtBats.AtBatID) AS AtBatID
FROM            dbo.AtBats INNER JOIN
                         dbo.MatchResults ON dbo.AtBats.Match = dbo.MatchResults.MatchID INNER JOIN
                         dbo.PlayersInTeams ON dbo.PlayersInTeams.PlayerInTeamID = dbo.AtBats.Pitcher AND dbo.MatchResults.Winner = dbo.PlayersInTeams.TeamID
WHERE        (dbo.AtBats.Inning =
                             (SELECT        Inning
                               FROM            dbo.InningWithWinningAtBat
                               WHERE        (Match = dbo.AtBats.Match)))
GROUP BY dbo.AtBats.Match
