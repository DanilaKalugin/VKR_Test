CREATE VIEW [dbo].[CurrentStandings]
AS
SELECT        TOP (100) PERCENT dbo.Teams.TeamAbbreviation, dbo.Teams.TeamName, dbo.Leagues.LeagueID, dbo.Divisions.DivisionTitle, COUNT(CASE WHEN Winner = TeamAbbreviation THEN 1 ELSE NULL END) AS W, 
                         COUNT(CASE WHEN Winner <> TeamAbbreviation AND Winner <> '' THEN 1 ELSE NULL END) AS L
FROM            dbo.Teams INNER JOIN
                         dbo.Divisions ON dbo.Teams.TeamDivision = dbo.Divisions.DivisionNumber INNER JOIN
                         dbo.Leagues ON dbo.Divisions.League = dbo.Leagues.LeagueID LEFT OUTER JOIN
                         dbo.MatchResults ON dbo.Teams.TeamAbbreviation = dbo.MatchResults.AwayTeam OR dbo.Teams.TeamAbbreviation = dbo.MatchResults.HomeTeam
GROUP BY dbo.Teams.TeamAbbreviation, dbo.Teams.TeamName, dbo.Leagues.LeagueID, dbo.Divisions.DivisionTitle
ORDER BY W DESC, L