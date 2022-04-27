﻿using System;
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

                if (InningNumber != 9)
                {
                    return InningNumber == 0 ? "" : $"Final/{InningNumber}";
                }

                return "Final";
            }
        }

        public string MatchWinner;

        public List<string> GetMatchLeaderAfterEachPitch()
        {
            var leaderAfterEachAtBat = new List<string>();
            foreach (var gameSituation in GameSituations)
            {
                if (gameSituation.AwayTeamRuns > gameSituation.HomeTeamRuns)
                {
                    leaderAfterEachAtBat.Add(AwayTeam.TeamAbbreviation);
                }
                else if (gameSituation.AwayTeamRuns < gameSituation.HomeTeamRuns)
                {
                    leaderAfterEachAtBat.Add(HomeTeam.TeamAbbreviation);
                }
                else leaderAfterEachAtBat.Add("");
            }
            return leaderAfterEachAtBat;
        }

        public Match(int id, string awayTeam, int awayRuns, int homeRuns, string homeTeam, int stadiumNumber, string winner, int inning, DateTime date)
        {
            MatchID = id;
            AwayTeamAbbreviation = awayTeam;
            AwayTeamRuns = awayRuns;
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

        public Match(int id, string awayTeam, string homeTeam, int stadiumNumber, DateTime date)
        {
            MatchID = id;
            AwayTeamAbbreviation = awayTeam;
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