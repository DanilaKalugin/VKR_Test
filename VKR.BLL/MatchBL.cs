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
        }

        public int GetNumberOfMatchesPlayed()
        {
            return matchDAO.GetNumberOfMatchesPlayed();
        }

        public void AddNewAtBat(AtBat atBat)
        {
            matchDAO.AddNewAtBat(atBat);
        }

        public void FinishMatch(Match match)
        {
            matchDAO.FinishMatch(match);
        }

        public void AddMatchResultForThisPitcher(PitcherResults pitcherResults)
        {
            matchDAO.AddMatchResultForThisPitcher(pitcherResults);
        }

        public List<Match> GetResultsForallMatches()
        {
            List<Match> matches = matchDAO.GetResultsForAllMatches().ToList();
            List<Stadium> stadiums = stadiumsDAO.GetAllStadiums().ToList();
            foreach (Match match in matches)
            {
                match.stadium = stadiums.Where(stadium => stadium.stadiumId == match.StadiumNumber).First();
            }
            return matches;
        }

        public List<Match> GetResultsForallMatches(string team)
        {
            List<Match> matches = matchDAO.GetResultsForAllMatches().ToList();
            List<Stadium> stadiums = stadiumsDAO.GetAllStadiums().ToList();
            foreach (Match match in matches)
            {
                match.stadium = stadiums.Where(stadium => stadium.stadiumId == match.StadiumNumber).First();
            }
            return matches.Where(match => match.AwayTeamAbbreviation == team || match.HomeTeamAbbreviation == team).ToList();
        }

        public void DeleteThisMatch(int matchNumberForDelete)
        {
            matchDAO.DeleteThisMatch(matchNumberForDelete);
        }
    }
}