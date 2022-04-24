using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using VKR.DAL;

namespace VKR.BLL
{
    public class MatchBL
    {
        private readonly MatchDAO _matchDAO;
        private readonly StadiumsDAO _stadiumsDAO;

        public MatchBL()
        {
            _matchDAO = new MatchDAO();
            _stadiumsDAO = new StadiumsDAO();
        }

        public void StartNewMatch(Match match)
        {
            _matchDAO.StartNewMatch(match);
            match.GameSituations = new List<GameSituation>
            {
                new GameSituation(match.AwayTeam)
            };
        }

        public int GetNumberOfMatchesPlayed(Match newMatch)
        {
            return _matchDAO.GetNumberOfMatchesPlayed(newMatch);
        }

        public void AddNewAtBat(AtBat atBat, Match currentMatch)
        {
            if (!currentMatch.IsQuickMatch)
            {
                _matchDAO.AddNewAtBat(atBat);
            }
        }

        public void FinishMatch(Match match)
        {
            _matchDAO.FinishMatch(match);
        }

        public void AddMatchResultForThisPitcher(PitcherResults pitcherResults, Match currentMatch)
        {
            if (!currentMatch.IsQuickMatch)
            {
                _matchDAO.AddMatchResultForThisPitcher(pitcherResults);
            }
        }

        public List<Match> GetResultsForallMatches(string team = "")
        {
            List<Match> matches = _matchDAO.GetResultsForAllMatches().ToList();
            List<Stadium> stadiums = _stadiumsDAO.GetAllStadiums().ToList();
            foreach (Match match in matches)
            {
                match.Stadium = stadiums.Where(stadium => stadium.StadiumId == match.StadiumNumber).First();
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
            _matchDAO.DeleteThisMatch(matchNumberForDelete);
        }

        public DateTime GetMaxDateForAllMatches()
        {
            List<Match> matches = GetResultsForallMatches();
            return matches.Select(match => match.MatchDate).Max();
        }

        public DateTime GetDateForNextMatch()
        {
            return _matchDAO.GetDateForNextMatch();
        }

        public List<Match> GetMatchesForThisDay(DateTime date)
        {
            return _matchDAO.GetMatchesForThisDay(date).ToList();
        }

        public List<Match> GetSchedule(string team = "")
        {
            List<Match> matches = _matchDAO.GetSchedule().ToList();
            List<Stadium> stadiums = _stadiumsDAO.GetAllStadiums().ToList();
            foreach (Match match in matches)
            {
                match.Stadium = stadiums.Where(stadium => stadium.StadiumId == match.StadiumNumber).First();
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