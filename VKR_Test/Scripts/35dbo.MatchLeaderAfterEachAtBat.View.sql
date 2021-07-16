CREATE VIEW [dbo].[MatchLeaderAfterEachAtBat] AS
SELECT MatchID, AtBatID, AwayTeam AS Leader, Winner
FROM MatchResults INNER JOIN TeamRunsAfterEachAtBat On MatchID = Match
WHERE AwayTeamRuns > HomeTeamRuns
UNION
SELECT MatchID, AtBatID, HomeTeam, Winner
FROM MatchResults INNER JOIN TeamRunsAfterEachAtBat On MatchID = Match
WHERE AwayTeamRuns < HomeTeamRuns
UNION
SELECT MatchID, AtBatID, '', Winner
FROM MatchResults INNER JOIN TeamRunsAfterEachAtBat On MatchID = Match
WHERE AwayTeamRuns = HomeTeamRuns