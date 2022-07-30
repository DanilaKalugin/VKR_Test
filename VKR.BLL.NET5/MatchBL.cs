using System;
using System.Collections.Generic;
using System.Linq;
using VKR.DAL.NET5;
using VKR.EF.DAO;
using VKR.EF.Entities;
using AtBat = VKR.Entities.NET5.AtBat;
using GameSituation = VKR.Entities.NET5.GameSituation;
using Match = VKR.Entities.NET5.Match;
using PitcherResults = VKR.Entities.NET5.PitcherResults;

namespace VKR.BLL.NET5
{
    public class MatchBL
    {
        private readonly MatchDAO _matchDAO = new();
        private readonly MatchEFDAO _matchEfdao = new();

        public enum TableType { Results, Schedule }

        public void StartNewMatch(Match match)
        {
            _matchDAO.StartNewMatch(match);
            match.GameSituations = new List<GameSituation> { new(match.AwayTeam) };
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

        public List<MatchScheduleViewModel> GetResultsForAllMatches() => _matchEfdao.GetResultsForAllMatches().ToList();

        public List<MatchScheduleViewModel> GetMatchesForSelectedTeam(TableType tableType, string team)
        {
            var matches = tableType == TableType.Results 
                                                            ? GetResultsForAllMatches().OrderByDescending(match => match.MatchDate).ToList() 
                                                            : GetSchedule().OrderBy(match => match.MatchDate).ToList();

            return matches.Where(match => match.AwayTeamAbbreviation == team ||
                                          match.HomeTeamAbbreviation == team).ToList();
        }

        public List<MatchScheduleViewModel> GetMatchesFromThisSeries(TableType tableType, string firstTeamID, string secondTeamID)
        {
            var teams = new List<string> { firstTeamID, secondTeamID }; 
            var matches = tableType == TableType.Results ? GetResultsForAllMatches() : GetSchedule();
            return matches.Where(match => teams.Contains(match.AwayTeamAbbreviation) &&
                                          teams.Contains(match.HomeTeamAbbreviation)).ToList();
        }

        public void DeleteThisMatch(int matchNumberForDelete) => _matchDAO.DeleteThisMatch(matchNumberForDelete);

        public DateTime GetMaxDateForAllMatches() => _matchEfdao.GetMaxDateForAllMatches();

        public DateTime GetDateForNextMatch() => _matchDAO.GetDateForNextMatch();

        public List<MatchFromSchedule> GetMatchesForThisDay(DateTime date, TypeOfMatchEnum matchType) => _matchEfdao.GetRemainingScheduleForThisDay(date, matchType).ToList();

        public List<MatchScheduleViewModel> GetSchedule() => _matchEfdao.GetScheduleForAllMatches().ToList();
    }
}