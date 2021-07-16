CREATE VIEW [dbo].[WinningAtBats]
AS
SELECT        T1.MatchID, MIN(T1.AtBatID) AS WinningAtBat
FROM            MatchLeaderAfterEachAtBat AS T1
WHERE        T1.AtBatID > (SELECT MAX(T2.AtBatID)
						FROM MatchLeaderAfterEachAtBat AS T2
						WHERE Leader <> Winner And T2.MatchID = T1.MatchID)
GROUP BY MatchID
UNION
SELECT        MatchID, MIN(AtBatID)
FROM            MatchLeaderAfterEachAtBat
WHERE        MatchID NOT IN
                             (SELECT        MatchID
                               FROM            MatchLeaderAfterEachAtBat
                               WHERE        Leader <> Winner
                               GROUP BY MatchID)
GROUP BY MatchID

GO