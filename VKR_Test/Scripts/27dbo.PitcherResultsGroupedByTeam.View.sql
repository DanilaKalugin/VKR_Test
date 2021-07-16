CREATE View [dbo].[PitcherResultsGroupedByTeam] AS
SELECT        dbo.PlayersInTeams.TeamID, COUNT(CASE WHEN Shutout = 1 THEN 1 ELSE NULL END) AS SHO, COUNT(CASE WHEN QualityStart = 1 THEN 1 ELSE NULL END) AS QS, 
                         COUNT(CASE WHEN CompleteGame = 1 THEN 1 ELSE NULL END) AS CG, COUNT(CASE WHEN Win = 1 THEN 1 ELSE NULL END) AS W, COUNT(CASE WHEN Loss = 1 THEN 1 ELSE NULL END) AS L, 
                         COUNT(CASE WHEN [Save] = 1 THEN 1 ELSE NULL END) AS SV, COUNT(CASE WHEN Hold = 1 THEN 1 ELSE NULL END) AS HLD
FROM            dbo.PitcherResults RIGHT OUTER JOIN
                         dbo.PlayersInTeams ON dbo.PitcherResults.Pitcher = dbo.PlayersInTeams.PlayerInTeamID
GROUP BY dbo.PlayersInTeams.TeamID

