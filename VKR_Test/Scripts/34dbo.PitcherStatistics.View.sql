CREATE VIEW [dbo].[PitcherStatistics]
AS
SELECT        dbo.Players.PlayerID, dbo.Players.PlayerFirstName, dbo.Players.PlayerSecondName, dbo.PlayersPositions.PlayerPositionID, ISNULL(dbo.CountOfMatchesPlayedForPitcher.G, 0) AS G, ISNULL(dbo.MatchesPlayedByTeam.TGP, 
                         0) AS TGP, COUNT(CASE WHEN AtBatResult = 1 THEN 1 ELSE NULL END) AS K, ISNULL(SUM(dbo.ExpandedAtBats.Outs), 0) AS Outs, COUNT(CASE WHEN AtBatResult = 13 THEN 1 ELSE NULL END) AS R, 
                         COUNT(CASE WHEN AtBatResult = 2 THEN 1 ELSE NULL END) AS BB, COUNT(CASE WHEN AtBatResult = 7 THEN 1 ELSE NULL END) AS [1B], COUNT(CASE WHEN AtBatResult = 8 THEN 1 ELSE NULL END) AS [2B], 
                         COUNT(CASE WHEN AtBatResult = 9 THEN 1 ELSE NULL END) AS [3B], COUNT(CASE WHEN AtBatResult = 10 THEN 1 ELSE NULL END) AS HR, COUNT(CASE WHEN AtBatResult <> 13 THEN 1 ELSE NULL END) AS TBF, 
                         COUNT(CASE WHEN AtBatResult = 3 THEN 1 ELSE NULL END) AS HBP, COUNT(CASE WHEN AtBatResult = 14 THEN 1 ELSE NULL END) AS SF, COUNT(CASE WHEN AtBatResult = 15 THEN 1 ELSE NULL END) AS SAC, 
                         COUNT(CASE WHEN AtBatResult = 11 THEN 1 ELSE NULL END) AS SB, COUNT(CASE WHEN AtBatResult = 12 THEN 1 ELSE NULL END) AS CS, COUNT(CASE WHEN AtBatResult = 5 AND Outs = 1 THEN 1 ELSE NULL END) 
                         AS GO, COUNT(CASE WHEN AtBatResult = 4 THEN 1 ELSE NULL END) AS AO, COUNT(CASE WHEN AtBatResult = 5 AND Outs = 2 THEN 1 ELSE NULL END) AS GIDP, dbo.Players.PlayerNumber, 
                         dbo.PitcherResultsGroupedByPitcher.SHO, dbo.PitcherResultsGroupedByPitcher.QS, dbo.PitcherResultsGroupedByPitcher.CG, dbo.PitcherResultsGroupedByPitcher.W, dbo.PitcherResultsGroupedByPitcher.L, 
                         dbo.PitcherResultsGroupedByPitcher.SV, dbo.PitcherResultsGroupedByPitcher.HLD, PlayerBattingHand, PlayerPitchingHand
FROM            dbo.Players INNER JOIN
                         dbo.PlayersInTeams ON dbo.Players.PlayerID = dbo.PlayersInTeams.PlayerID INNER JOIN
                         dbo.PitcherResultsGroupedByPitcher ON dbo.Players.PlayerID = dbo.PitcherResultsGroupedByPitcher.PlayerID LEFT OUTER JOIN
                         dbo.CountOfMatchesPlayedForPitcher ON dbo.Players.PlayerID = dbo.CountOfMatchesPlayedForPitcher.PlayerID LEFT OUTER JOIN
                         dbo.PlayersPositions ON dbo.Players.PlayerID = dbo.PlayersPositions.PlayerID LEFT OUTER JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Pitcher = dbo.Players.PlayerID LEFT OUTER JOIN
                         dbo.MatchesPlayedByTeam ON dbo.MatchesPlayedByTeam.TeamAbbreviation = dbo.PlayersInTeams.TeamID
WHERE        (dbo.PlayersPositions.PlayerPositionID = 'P') AND InCurrentTeam = 1
GROUP BY dbo.Players.PlayerID, dbo.Players.PlayerFirstName, dbo.Players.PlayerSecondName, dbo.Players.PlayerNumber, dbo.PlayersPositions.PlayerPositionID, dbo.PitcherResultsGroupedByPitcher.SHO, 
                         dbo.PitcherResultsGroupedByPitcher.QS, dbo.PitcherResultsGroupedByPitcher.CG, dbo.MatchesPlayedByTeam.TGP, dbo.CountOfMatchesPlayedForPitcher.G, ISNULL(dbo.CountOfMatchesPlayedForPitcher.G, 0), 
                         ISNULL(dbo.MatchesPlayedByTeam.TGP, 0), dbo.PitcherResultsGroupedByPitcher.W, dbo.PitcherResultsGroupedByPitcher.L, dbo.PitcherResultsGroupedByPitcher.SV, dbo.PitcherResultsGroupedByPitcher.HLD, 
						 PlayerBattingHand, PlayerPitchingHand
UNION
SELECT        dbo.Players.PlayerID, dbo.Players.PlayerFirstName, dbo.Players.PlayerSecondName, dbo.PlayersPositions.PlayerPositionID, ISNULL(dbo.CountOfMatchesPlayedForPitcher.G, 0) AS G, ISNULL(dbo.MatchesPlayedByTeam.TGP, 
                         0) AS TGP, COUNT(CASE WHEN AtBatResult = 1 THEN 1 ELSE NULL END) AS K, ISNULL(SUM(dbo.ExpandedAtBats.Outs), 0) AS Outs, COUNT(CASE WHEN AtBatResult = 13 THEN 1 ELSE NULL END) AS R, 
                         COUNT(CASE WHEN AtBatResult = 2 THEN 1 ELSE NULL END) AS BB, COUNT(CASE WHEN AtBatResult = 7 THEN 1 ELSE NULL END) AS [1B], COUNT(CASE WHEN AtBatResult = 8 THEN 1 ELSE NULL END) AS [2B], 
                         COUNT(CASE WHEN AtBatResult = 9 THEN 1 ELSE NULL END) AS [3B], COUNT(CASE WHEN AtBatResult = 10 THEN 1 ELSE NULL END) AS HR, COUNT(CASE WHEN AtBatResult <> 13 THEN 1 ELSE NULL END) AS TBF, 
                         COUNT(CASE WHEN AtBatResult = 3 THEN 1 ELSE NULL END) AS HBP, COUNT(CASE WHEN AtBatResult = 14 THEN 1 ELSE NULL END) AS SF, COUNT(CASE WHEN AtBatResult = 15 THEN 1 ELSE NULL END) AS SAC, 
                         COUNT(CASE WHEN AtBatResult = 11 THEN 1 ELSE NULL END) AS SB, COUNT(CASE WHEN AtBatResult = 12 THEN 1 ELSE NULL END) AS CS, COUNT(CASE WHEN AtBatResult = 5 AND Outs = 1 THEN 1 ELSE NULL END) 
                         AS GO, COUNT(CASE WHEN AtBatResult = 4 THEN 1 ELSE NULL END) AS AO, COUNT(CASE WHEN AtBatResult = 5 AND Outs = 2 THEN 1 ELSE NULL END) AS GIDP, dbo.Players.PlayerNumber, 
                         dbo.PitcherResultsGroupedByPitcher.SHO, dbo.PitcherResultsGroupedByPitcher.QS, dbo.PitcherResultsGroupedByPitcher.CG, dbo.PitcherResultsGroupedByPitcher.W, dbo.PitcherResultsGroupedByPitcher.L, 
                         dbo.PitcherResultsGroupedByPitcher.SV, dbo.PitcherResultsGroupedByPitcher.HLD, PlayerBattingHand, PlayerPitchingHand
FROM            dbo.Players INNER JOIN
                         dbo.PlayersInTeams ON dbo.Players.PlayerID = dbo.PlayersInTeams.PlayerID INNER JOIN
                         dbo.PitcherResultsGroupedByPitcher ON dbo.Players.PlayerID = dbo.PitcherResultsGroupedByPitcher.PlayerID LEFT OUTER JOIN
                         dbo.CountOfMatchesPlayedForPitcher ON dbo.Players.PlayerID = dbo.CountOfMatchesPlayedForPitcher.PlayerID LEFT OUTER JOIN
                         dbo.PlayersPositions ON dbo.Players.PlayerID = dbo.PlayersPositions.PlayerID LEFT OUTER JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Pitcher = dbo.Players.PlayerID LEFT OUTER JOIN
                         dbo.MatchesPlayedByTeam ON dbo.MatchesPlayedByTeam.TeamAbbreviation = dbo.PlayersInTeams.TeamID
WHERE        (dbo.PlayersPositions.PlayerPositionID = 'P') AND Players.PlayerID NOT IN
                             (SELECT        PlayerID
                               FROM            PlayersInTeams
                               WHERE        InCurrentTeam = 1
                               GROUP BY PlayerID)
GROUP BY dbo.Players.PlayerID, dbo.Players.PlayerFirstName, dbo.Players.PlayerSecondName, dbo.Players.PlayerNumber, dbo.PlayersPositions.PlayerPositionID, dbo.PitcherResultsGroupedByPitcher.SHO, 
                         dbo.PitcherResultsGroupedByPitcher.QS, dbo.PitcherResultsGroupedByPitcher.CG, dbo.MatchesPlayedByTeam.TGP, dbo.CountOfMatchesPlayedForPitcher.G, ISNULL(dbo.CountOfMatchesPlayedForPitcher.G, 0), 
                         ISNULL(dbo.MatchesPlayedByTeam.TGP, 0), dbo.PitcherResultsGroupedByPitcher.W, dbo.PitcherResultsGroupedByPitcher.L, dbo.PitcherResultsGroupedByPitcher.SV, dbo.PitcherResultsGroupedByPitcher.HLD, 
						 PlayerBattingHand, PlayerPitchingHand
