CREATE VIEW [dbo].[CountOfMatchesPlayed]
AS
SELECT        dbo.PlayersInTeams.PlayerID, COUNT(dbo.LineupsForMatches.Match) AS G
FROM            dbo.Matches INNER JOIN
                         dbo.LineupsForMatches ON dbo.Matches.MatchID = dbo.LineupsForMatches.Match RIGHT OUTER JOIN
                         dbo.Players LEFT OUTER JOIN
                         dbo.PlayersInTeams ON dbo.Players.PlayerID = dbo.PlayersInTeams.PlayerID ON dbo.LineupsForMatches.PlayerInTeamID = dbo.PlayersInTeams.PlayerInTeamID
WHERE        (dbo.LineupsForMatches.NumberInLineup <> 10) AND (dbo.Matches.IsQuickMatch = 0)
GROUP BY dbo.PlayersInTeams.PlayerID
