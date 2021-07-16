CREATE VIEW [dbo].[BatterStatistics]
AS
SELECT        TOP (100) PERCENT dbo.Players.PlayerID, dbo.Players.PlayerFirstName, dbo.Players.PlayerSecondName, dbo.Players.PlayerNumber, ISNULL(dbo.CountOfMatchesPlayed.G, 0) AS G, ISNULL(dbo.MatchesPlayedByTeam.TGP, 
                         0) AS TGP, COUNT(CASE WHEN AtBatResult = 1 THEN 1 ELSE NULL END) AS K, COUNT(CASE WHEN AtBatResult = 2 THEN 1 ELSE NULL END) AS BB, COUNT(CASE WHEN AtBatResult = 3 THEN 1 ELSE NULL END) AS HBP, 
                         COUNT(CASE WHEN AtBatResult = 4 THEN 1 ELSE NULL END) AS AO, COUNT(CASE WHEN AtBatResult = 5 THEN 1 ELSE NULL END) AS GO, COUNT(CASE WHEN AtBatResult = 6 THEN 1 ELSE NULL END) AS PO, 
                         COUNT(CASE WHEN AtBatResult = 7 THEN 1 ELSE NULL END) AS [1B], COUNT(CASE WHEN AtBatResult = 8 THEN 1 ELSE NULL END) AS [2B], COUNT(CASE WHEN AtBatResult = 9 THEN 1 ELSE NULL END) AS [3B], 
                         COUNT(CASE WHEN AtBatResult = 10 THEN 1 ELSE NULL END) AS HR, COUNT(CASE WHEN AtBatResult = 11 THEN 1 ELSE NULL END) AS SB, COUNT(CASE WHEN AtBatResult = 12 THEN 1 ELSE NULL END) AS CS, 
                         COUNT(CASE WHEN AtBatResult = 13 THEN 1 ELSE NULL END) AS R, COUNT(CASE WHEN AtBatResult = 14 THEN 1 ELSE NULL END) AS SF, COUNT(CASE WHEN AtBatResult = 15 THEN 1 ELSE NULL END) AS SAC, 
                         COUNT(CASE WHEN AtBatResult < 11 OR AtBatResult > 13 THEN 1 ELSE NULL END) AS PA, COUNT(CASE WHEN AtBatResult = 5 AND Outs = 2 THEN 1 ELSE NULL END) AS GIDP, 
						 ISNULL(SUM(CASE WHEN Outs <> 2 THEN dbo.ExpandedAtBats.RBI ELSE 0 END), 0) AS RBI, PlayerBattingHand, PlayerPitchingHand
FROM            dbo.MatchesPlayedByTeam RIGHT OUTER JOIN
                         dbo.PlayersInTeams ON dbo.MatchesPlayedByTeam.TeamAbbreviation = dbo.PlayersInTeams.TeamID RIGHT OUTER JOIN
                         dbo.Players ON dbo.PlayersInTeams.PlayerID = dbo.Players.PlayerID LEFT OUTER JOIN
                         dbo.CountOfMatchesPlayed ON dbo.Players.PlayerID = dbo.CountOfMatchesPlayed.PlayerID LEFT OUTER JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Batter = dbo.Players.PlayerID
WHERE        InCurrentTeam = 1
GROUP BY dbo.Players.PlayerID, dbo.Players.PlayerFirstName, dbo.Players.PlayerSecondName, dbo.Players.PlayerNumber, dbo.CountOfMatchesPlayed.G, dbo.MatchesPlayedByTeam.TGP, PlayerBattingHand, PlayerPitchingHand
UNION
SELECT        TOP (100) PERCENT dbo.Players.PlayerID, dbo.Players.PlayerFirstName, dbo.Players.PlayerSecondName, dbo.Players.PlayerNumber, ISNULL(dbo.CountOfMatchesPlayed.G, 0), ISNULL(dbo.MatchesPlayedByTeam.TGP, 
                         0), COUNT(CASE WHEN AtBatResult = 1 THEN 1 ELSE NULL END), COUNT(CASE WHEN AtBatResult = 2 THEN 1 ELSE NULL END), COUNT(CASE WHEN AtBatResult = 3 THEN 1 ELSE NULL END), 
                         COUNT(CASE WHEN AtBatResult = 4 THEN 1 ELSE NULL END), COUNT(CASE WHEN AtBatResult = 5 THEN 1 ELSE NULL END), COUNT(CASE WHEN AtBatResult = 6 THEN 1 ELSE NULL END), 
                         COUNT(CASE WHEN AtBatResult = 7 THEN 1 ELSE NULL END), COUNT(CASE WHEN AtBatResult = 8 THEN 1 ELSE NULL END), COUNT(CASE WHEN AtBatResult = 9 THEN 1 ELSE NULL END), 
                         COUNT(CASE WHEN AtBatResult = 10 THEN 1 ELSE NULL END), COUNT(CASE WHEN AtBatResult = 11 THEN 1 ELSE NULL END), COUNT(CASE WHEN AtBatResult = 12 THEN 1 ELSE NULL END), 
                         COUNT(CASE WHEN AtBatResult = 13 THEN 1 ELSE NULL END), COUNT(CASE WHEN AtBatResult = 14 THEN 1 ELSE NULL END), COUNT(CASE WHEN AtBatResult = 15 THEN 1 ELSE NULL END), 
                         COUNT(CASE WHEN AtBatResult < 11 OR AtBatResult > 13 THEN 1 ELSE NULL END), COUNT(CASE WHEN AtBatResult = 5 AND Outs = 2 THEN 1 ELSE NULL END), 
						 ISNULL(SUM(CASE WHEN Outs <> 2 THEN dbo.ExpandedAtBats.RBI ELSE 0 END), 0), PlayerBattingHand, PlayerPitchingHand
FROM            dbo.MatchesPlayedByTeam RIGHT OUTER JOIN
                         dbo.PlayersInTeams ON dbo.MatchesPlayedByTeam.TeamAbbreviation = dbo.PlayersInTeams.TeamID RIGHT OUTER JOIN
                         dbo.Players ON dbo.PlayersInTeams.PlayerID = dbo.Players.PlayerID LEFT OUTER JOIN
                         dbo.CountOfMatchesPlayed ON dbo.Players.PlayerID = dbo.CountOfMatchesPlayed.PlayerID LEFT OUTER JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Batter = dbo.Players.PlayerID
WHERE        Players.PlayerID NOT IN
                             (SELECT        PlayerID
                               FROM            PlayersInTeams
                               WHERE        InCurrentTeam = 1
                               GROUP BY PlayerID)
GROUP BY dbo.Players.PlayerID, dbo.Players.PlayerFirstName, dbo.Players.PlayerSecondName, dbo.Players.PlayerNumber, dbo.CountOfMatchesPlayed.G, dbo.MatchesPlayedByTeam.TGP, PlayerBattingHand, PlayerPitchingHand
ORDER BY dbo.Players.PlayerID