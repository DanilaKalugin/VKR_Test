using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using VKR.DAL;

namespace VKR.BLL
{
    public class MatchBL
    {
        private readonly MatchDAO matchDAO;
        private readonly StadiumsDAO stadiumsDAO;

        public MatchBL()
        {
            matchDAO = new MatchDAO();
            stadiumsDAO = new StadiumsDAO();
        }

        public void StartNewMatch(Match match)
        {
            matchDAO.StartNewMatch(match);
            match.gameSituations = new List<GameSituation>
            {
                new GameSituation(match.AwayTeam)
            };
        }

        public int GetNumberOfMatchesPlayed(Match newMatch)
        {
            return matchDAO.GetNumberOfMatchesPlayed(newMatch);
        }

        public void AddNewAtBat(AtBat atBat, Match currentMatch)
        {
            if (!currentMatch.IsQuickMatch)
            {
                matchDAO.AddNewAtBat(atBat);
            }
        }

        public void FinishMatch(Match match)
        {
            matchDAO.FinishMatch(match);
        }

        public void AddMatchResultForThisPitcher(PitcherResults pitcherResults, Match currentMatch)
        {
            if (!currentMatch.IsQuickMatch)
            {
                matchDAO.AddMatchResultForThisPitcher(pitcherResults);
            }
        }

        public List<Match> GetResultsForallMatches(string team = "")
        {
            List<Match> matches = matchDAO.GetResultsForAllMatches().ToList();
            List<Stadium> stadiums = stadiumsDAO.GetAllStadiums().ToList();
            foreach (Match match in matches)
            {
                match.stadium = stadiums.Where(stadium => stadium.stadiumId == match.StadiumNumber).First();
            }
            if (team != "")
            {
                return matches.Where(match => match.AwayTeamAbbreviation == team || match.HomeTeamAbbreviation == team).ToList();
            }
            else
            {
                return matches;
            }
        }

        public void DeleteThisMatch(int matchNumberForDelete)
        {
            matchDAO.DeleteThisMatch(matchNumberForDelete);
        }

        public DateTime GetMaxDateForAllMatches()
        {
            List<Match> matches = GetResultsForallMatches();
            return matches.Select(match => match.MatchDate).Max();
        }

        public DateTime GetDateForNextMatch()
        {
            return matchDAO.GetDateForNextMatch();
        }

        public List<Match> GetMatchesForThisDay(DateTime date)
        {
            return matchDAO.GetMatchesForThisDay(date).ToList();
        }

        public List<Match> GetSchedule(string team = "")
        {
            List<Match> matches = matchDAO.GetSchedule().ToList();
            List<Stadium> stadiums = stadiumsDAO.GetAllStadiums().ToList();
            foreach (Match match in matches)
            {
                match.stadium = stadiums.Where(stadium => stadium.stadiumId == match.StadiumNumber).First();
            }
            if (team != "")
            {
                return matches.Where(match => match.AwayTeamAbbreviation == team || match.HomeTeamAbbreviation == team).ToList();
            }
            else
            {
                return matches;
            }
        }
    }
}