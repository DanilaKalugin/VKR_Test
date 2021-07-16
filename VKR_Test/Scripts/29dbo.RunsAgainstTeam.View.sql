CREATE VIEW [dbo].[RunsAgainstTeam]
AS
SELECT        dbo.Teams.TeamAbbreviation, COUNT(CASE WHEN AtBatResult = 13 THEN 1 ELSE NULL END) AS RS
FROM            dbo.Matches INNER JOIN
                         dbo.ExpandedAtBats ON dbo.Matches.MatchID = dbo.ExpandedAtBats.Match RIGHT OUTER JOIN
                         dbo.Teams ON dbo.ExpandedAtBats.Defense = dbo.Teams.TeamAbbreviation
WHERE        (dbo.Matches.IsQuickMatch = 0)
GROUP BY dbo.Teams.TeamAbbreviation
