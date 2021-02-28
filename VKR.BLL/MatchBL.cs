using Entities;
using System;
using VKR.DAL;

namespace VKR.BLL
{
    public class MatchBL
    {
        private readonly MatchDAO matchDAO;
        

        public MatchBL()
        {
            matchDAO = new MatchDAO();
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
    }
}