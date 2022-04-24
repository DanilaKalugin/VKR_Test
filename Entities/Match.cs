using System;
using System.Collections.Generic;

namespace Entities
{
    public class Match
    {
        public int MatchID;
        public Team HomeTeam;
        public Team AwayTeam;
        public Stadium Stadium;
        public bool DHRule;
        public List<GameSituation> GameSituations;
        public List<AtBat> AtBats;
        public int HomeTeamRuns;
        public int AwayTeamRuns;
        public int InningNumber;
        public string AwayTeamAbbreviation;
        public string HomeTeamAbbreviation;
        public int StadiumNumber;
        public DateTime MatchDate;
        public bool IsQuickMatch;
        public int MatchLength;

        public string MatchStatus
        {
            get
            {
                if (MatchWinner == "")
                {
                    return $"{OrdinalNumerals.GetOrdinalNumeralFromQuantitive(InningNumber)} inning";
                }
                else
                {
                    if (InningNumber != 9)
                    {
                        if (InningNumber == 0)
                        {
                            return "";
                        }
                        else
                        {
                            return $"Final/{InningNumber}";
                        }
                    }
                    else
                    {
                        return "Final";
                    }

                }
            }
        }

        public string MatchWinner;

        public List<string> GetMatchLeaderAfterEachPitch()
        {
            List<string> leaderAfterEachAtBat = new List<string>();
            for (int i = 0; i < GameSituations.Count; i++)
            {
                if (GameSituations[i].AwayTeamRuns > GameSituations[i].HomeTeamRuns)
                {
                    leaderAfterEachAtBat.Add(AwayTeam.TeamAbbreviation);
                }
                else if (GameSituations[i].AwayTeamRuns < GameSituations[i].HomeTeamRuns)
                {
                    leaderAfterEachAtBat.Add(HomeTeam.TeamAbbreviation);
                }
                else leaderAfterEachAtBat.Add("");
            }
            return leaderAfterEachAtBat;
        }

        public Match(int id, Team homeTeam, Team awayTeam, Stadium stadium, bool dh, DateTime date)
        {
            MatchID = id;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Stadium = stadium;
            DHRule = dh;
            GameSituations = new List<GameSituation>
            {
                new GameSituation(AwayTeam)
            };
            AtBats = new List<AtBat>();
            MatchDate = date;
        }

        public Match(int id, string AwayTeam, int AwayRuns, int homeRuns, string homeTeam, int stadiumNumber, string winner, int inning, DateTime date)
        {
            MatchID = id;
            AwayTeamAbbreviation = AwayTeam;
            AwayTeamRuns = AwayRuns;
            HomeTeamRuns = homeRuns;
            HomeTeamAbbreviation = homeTeam;
            StadiumNumber = stadiumNumber;
            MatchWinner = winner;
            InningNumber = inning;
            MatchDate = date;
        }

        public Match(int id, string awayTeam, string homeTeam, DateTime date)
        {
            MatchID = id;
            AwayTeamAbbreviation = awayTeam;
            HomeTeamAbbreviation = homeTeam;
            MatchDate = date;
        }

        public Match(int id, string AwayTeam, string homeTeam, int stadiumNumber, DateTime date)
        {
            MatchID = id;
            AwayTeamAbbreviation = AwayTeam;
            HomeTeamAbbreviation = homeTeam;
            MatchDate = date;
            StadiumNumber = stadiumNumber;
        }

        public Match(DateTime date, bool quickMatch)
        {
            MatchDate = date;
            IsQuickMatch = quickMatch;
            AtBats = new List<AtBat>();
        }
    }
}