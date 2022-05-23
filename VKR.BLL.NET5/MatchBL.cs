using System;
using System.Collections.Generic;
using System.Linq;
using Entities.NET5;
using VKR.DAL.NET5;

namespace VKR.BLL.NET5
{
    public class MatchBL
    {
        private readonly MatchDAO _matchDAO = new();
        private readonly StadiumsDAO _stadiumsDAO = new();

        public void StartNewMatch(Match match)
        {
            _matchDAO.StartNewMatch(match);
            match.GameSituations = new List<GameSituation>
            {
                new(match.AwayTeam)
            };
        }

        public int GetNumberOfMatchesPlayed(Match newMatch) => _matchDAO.GetNumberOfMatchesPlayed(newMatch);

        public void AddNewAtBat(AtBat atBat, Match currentMatch)
        {
            if (!currentMatch.IsQuickMatch) _matchDAO.AddNewAtBat(atBat);
        }

        public void FinishMatch(Match match) => _matchDAO.FinishMatch(match);

        public void AddMatchResultForThisPitcher(PitcherResults pitcherResults, Match currentMatch)
        {
            if (!currentMatch.IsQuickMatch) _matchDAO.AddMatchResultForThisPitcher(pitcherResults);
        }

        public List<Match> GetResultsForAllMatches(string team = "")
        {
            var matches = _matchDAO.GetResultsForAllMatches().ToList();
            var stadiums = _stadiumsDAO.GetAllStadiums().ToList();
            
            foreach (var match in matches)
                match.Stadium = stadiums.FirstOrDefault(stadium => stadium.StadiumId == match.StadiumNumber);
            
            return team != "" ? matches.Where(match => match.AwayTeamAbbreviation == team || match.HomeTeamAbbreviation == team).ToList() : matches;
        }

        public void DeleteThisMatch(int matchNumberForDelete) => _matchDAO.DeleteThisMatch(matchNumberForDelete);

        public DateTime GetMaxDateForAllMatches()
        {
            var matches = GetResultsForAllMatches();
            return matches.Select(match => match.MatchDate).Max();
        }

        public DateTime GetDateForNextMatch() => _matchDAO.GetDateForNextMatch();

        public List<Match> GetMatchesForThisDay(DateTime date) => _matchDAO.GetMatchesForThisDay(date).ToList();

        public List<Match> GetSchedule(string team = "")
        {
            var matches = _matchDAO.GetSchedule().ToList();
            var stadiums = _stadiumsDAO.GetAllStadiums().ToList();

            foreach (var match in matches)
                match.Stadium = stadiums.First(stadium => stadium.StadiumId == match.StadiumNumber);

            if (team == "") return matches;
            
            return matches.Where(match => match.AwayTeamAbbreviation == team || match.HomeTeamAbbreviation == team).ToList();
        }
    }
}