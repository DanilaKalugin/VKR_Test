CREATE PROCEDURE [dbo].[GetAllTeams]
AS
SELECT TeamAbbreviation, TeamCity, TeamName, TeamStadium, StrikeZoneProbability, SwingInStrikeZoneProbability, 
	   SwingOutsideStrikeZoneProbability, HittingProbability, FoulProbability, SingleProbability, 
	   DoubleProbability, HomeRunProbability, PopoutOnFoulProbability, FlyoutOnHomerunProbability,
	   GroundoutProbability, FlyoutProbability, SacrificeFlyProbability, DoublePlayProbability, 
	   StealingBaseSuccessfulAttemptProbability, SuccessfulBuntAttemptProbability, LeagueDHRule, 
	   HitByPitchProbability, Count(Case WHEN Winner = TeamAbbreviation THEN 1 ELSE NULL END) AS W, 
	   Count(Case WHEN Winner <> TeamAbbreviation THEN 1 ELSE NULL END) AS L
From Teams INNER JOIN Divisions On TeamDivision = DivisionNumber Inner JOIN Leagues On League = LeagueID LEFT JOIN MatchResults ON (TeamAbbreviation = AwayTeam OR TeamAbbreviation = HomeTeam)
GROUP BY TeamAbbreviation, TeamCity, TeamName, TeamStadium, StrikeZoneProbability, SwingInStrikeZoneProbability, 
	   SwingOutsideStrikeZoneProbability, HittingProbability, FoulProbability, SingleProbability, 
	   DoubleProbability, HomeRunProbability, PopoutOnFoulProbability, FlyoutOnHomerunProbability,
	   GroundoutProbability, FlyoutProbability, SacrificeFlyProbability, DoublePlayProbability, 
	   StealingBaseSuccessfulAttemptProbability, SuccessfulBuntAttemptProbability, LeagueDHRule,
	   HitByPitchProbability
Order By TeamName
