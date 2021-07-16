CREATE VIEW [dbo].[MatchesPlayedByTeam]
AS
SELECT        dbo.Teams.TeamAbbreviation, COUNT(dbo.Matches.MatchID) AS TGP
FROM            dbo.Teams INNER JOIN
                         dbo.Matches ON dbo.Teams.TeamAbbreviation = dbo.Matches.HomeTeam OR dbo.Teams.TeamAbbreviation = dbo.Matches.AwayTeam
WHERE        (dbo.Matches.IsQuickMatch = 0)
GROUP BY dbo.Teams.TeamAbbreviation
