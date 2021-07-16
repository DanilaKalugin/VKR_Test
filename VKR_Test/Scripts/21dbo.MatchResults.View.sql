CREATE VIEW [dbo].[MatchResults]
AS
SELECT        MatchID, AwayTeam, HomeTeam, Sum(CASE WHEN TeamID = AwayTeam THEN RBI ELSE 0 END) AS AwayRuns, Sum(CASE WHEN TeamID = HomeTeam THEN RBI ELSE 0 END) AS HomeRuns, AwayTeam AS Winner, 
                         MAX(Inning) AS InningNumber, Stadium, MatchDate
FROM            (Matches INNER JOIN
                         AtBats ON MatchID = Match) INNER JOIN
                         PlayersInTeams ON PlayerInTeamID = Batter
WHERE        MatchEnded = 1 And IsQuickMatch = 0
GROUP BY MatchID, AwayTeam, HomeTeam, Stadium, MatchDate
HAVING        Sum(CASE WHEN TeamID = AwayTeam THEN RBI ELSE 0 END) > Sum(CASE WHEN TeamID = HomeTeam THEN RBI ELSE 0 END)
UNION
SELECT        MatchID, AwayTeam, HomeTeam, Sum(CASE WHEN TeamID = AwayTeam THEN RBI ELSE 0 END) AS AwayRuns, Sum(CASE WHEN TeamID = HomeTeam THEN RBI ELSE 0 END) AS HomeRuns, '', MAX(Inning), Stadium, 
                         MatchDate
FROM            (Matches INNER JOIN
                         AtBats ON MatchID = Match) INNER JOIN
                         PlayersInTeams ON PlayerInTeamID = Batter
WHERE        MatchEnded = 0 And IsQuickMatch = 0
GROUP BY MatchID, AwayTeam, HomeTeam, Stadium, MatchDate
UNION
SELECT        MatchID, AwayTeam, HomeTeam, Sum(CASE WHEN TeamID = AwayTeam THEN RBI ELSE 0 END) AS AwayRuns, Sum(CASE WHEN TeamID = HomeTeam THEN RBI ELSE 0 END) AS HomeRuns, HomeTeam, MAX(Inning), 
                         Stadium, MatchDate
FROM            (Matches INNER JOIN
                         AtBats ON MatchID = Match) INNER JOIN
                         PlayersInTeams ON PlayerInTeamID = Batter
WHERE        MatchEnded = 1 And IsQuickMatch = 0
GROUP BY MatchID, AwayTeam, HomeTeam, Stadium, MatchDate
HAVING        Sum(CASE WHEN TeamID = AwayTeam THEN RBI ELSE 0 END) < Sum(CASE WHEN TeamID = HomeTeam THEN RBI ELSE 0 END)

