CREATE PROCEDURE [dbo].[GetStandings]
(
@Date date
)
AS
SELECT TeamAbbreviation, TeamName, LeagueID, DivisionTitle, Count(Case WHEN Winner = TeamAbbreviation THEN 1 ELSE NULL END) AS W, Count(Case WHEN Winner <> TeamAbbreviation AND Winner <> '' THEN 1 ELSE NULL END) AS L
FROM Teams INNER JOIN Divisions ON TeamDivision = DivisionNumber Inner JOIN Leagues ON League = LeagueID LEFT JOIN MatchResults ON (TeamAbbreviation = AwayTeam OR TeamAbbreviation = HomeTeam)
WHERE MatchDate <= @Date
GROUP BY TeamAbbreviation, TeamName, LeagueID, DivisionTitle
ORDER BY W Desc, L

