CREATE VIEW [dbo].[CountOfMatchesPlayedForPitcher]
AS
SELECT        dbo.PlayersInTeams.PlayerID, COUNT(dbo.LineupsForMatches.Match) AS G
FROM            dbo.Players LEFT OUTER JOIN
                         dbo.PlayersInTeams ON dbo.Players.PlayerID = dbo.PlayersInTeams.PlayerID LEFT OUTER JOIN
                         dbo.LineupsForMatches ON dbo.PlayersInTeams.PlayerInTeamID = dbo.LineupsForMatches.PlayerInTeamID INNER JOIN
                         dbo.Matches ON dbo.LineupsForMatches.Match = dbo.Matches.MatchID
WHERE        (dbo.LineupsForMatches.NumberInLineup = 10) AND (dbo.Matches.IsQuickMatch = 0)
GROUP BY dbo.PlayersInTeams.PlayerID

