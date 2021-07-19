using System;
using System.Collections.Generic;

namespace Entities
{
    public class Match
    {
        public int MatchID;
        public Team HomeTeam;
        public Team AwayTeam;
        public Stadium stadium;
        public bool DHRule;
        public List<GameSituation> gameSituations;
        public List<AtBat> atBats;
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
            for (int i = 0; i < gameSituations.Count; i++)
            {
                if (gameSituations[i].AwayTeamRuns > gameSituations[i].HomeTeamRuns)
                {
                    leaderAfterEachAtBat.Add(AwayTeam.TeamAbbreviation);
                }
                else if (gameSituations[i].AwayTeamRuns < gameSituations[i].HomeTeamRuns)
                {
                    leaderAfterEachAtBat.Add(HomeTeam.TeamAbbreviation);
                }
                else leaderAfterEachAtBat.Add("");
            }
            return leaderAfterEachAtBat;
        }

        public Match(int _id, Team _homeTeam, Team _awayTeam, Stadium _stadium, bool _dh, DateTime date)
        {
            MatchID = _id;
            HomeTeam = _homeTeam;
            AwayTeam = _awayTeam;
            stadium = _stadium;
            DHRule = _dh;
            gameSituations = new List<GameSituation>
            {
                new GameSituation(AwayTeam)
            };
            atBats = new List<AtBat>();
            MatchDate = date;
        }

        public Match(int _id, string _AwayTeam, int _AwayRuns, int _homeRuns, string _homeTeam, int _StadiumNumber, string Winner, int Inning, DateTime date)
        {
            MatchID = _id;
            AwayTeamAbbreviation = _AwayTeam;
            AwayTeamRuns = _AwayRuns;
            HomeTeamRuns = _homeRuns;
            HomeTeamAbbreviation = _homeTeam;
            StadiumNumber = _StadiumNumber;
            MatchWinner = Winner;
            InningNumber = Inning;
            MatchDate = date;
        }

        public Match(int _id, string _AwayTeam, string _homeTeam, DateTime date)
        {
            MatchID = _id;
            AwayTeamAbbreviation = _AwayTeam;
            HomeTeamAbbreviation = _homeTeam;
            MatchDate = date;
        }

        public Match(int _id, string _AwayTeam, string _homeTeam, int _StadiumNumber, DateTime date)
        {
            MatchID = _id;
            AwayTeamAbbreviation = _AwayTeam;
            HomeTeamAbbreviation = _homeTeam;
            MatchDate = date;
            StadiumNumber = _StadiumNumber;
        }

        public Match(DateTime date, bool QuickMatch)
        {
            MatchDate = date;
            IsQuickMatch = QuickMatch;
            atBats = new List<AtBat>();
        }
    }
}