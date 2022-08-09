using System;
using System.Collections.Generic;
using System.Linq;
using VKR.DAL.NET5;
using VKR.EF.DAO;
using VKR.EF.Entities;
using Match = VKR.Entities.NET5.Match;
using PitcherResults = VKR.Entities.NET5.PitcherResults;

namespace VKR.BLL.NET5
{
    public class MatchBL
    {
        private readonly MatchDAO _matchDAO = new();
        private readonly MatchEFDAO _matchEfdao = new();

        public enum TableType { Results, Schedule }

        public void StartNewMatch(EF.Entities.Match match)
        {
            _matchEfdao.StartNewMatch(match);
            match.GameSituations = new List<GameSituation> { new(match.AwayTeam) };
        }

        public int GetNumberOfMatchesPlayed(EF.Entities.Match newMatch) => _matchEfdao.GetNextMatchId(newMatch.MatchTypeId);

        public void AddNewAtBat(AtBat atBat, Match currentMatch)
        {
            if (!currentMatch.IsQuickMatch) _matchDAO.AddNewAtBat(atBat);
        }

        public void FinishMatch(Match match) => _matchDAO.FinishMatch(match);

        public void AddMatchResultForThisPitcher(PitcherResults pitcherResults, Match currentMatch)
        {
            if (!currentMatch.IsQuickMatch) _matchDAO.AddMatchResultForThisPitcher(pitcherResults);
        }

        public List<EF.Entities.MatchScheduleViewModel> GetResultsForAllMatches() => _matchEfdao.GetResultsForAllMatches().ToList();

        public List<EF.Entities.MatchScheduleViewModel> GetMatchesForSelectedTeam(TableType tableType, string team)
        {
            var matches = tableType == TableType.Results 
                                                            ? GetResultsForAllMatches().OrderByDescending(match => match.MatchDate).ToList() 
                                                            : GetSchedule().OrderBy(match => match.MatchDate).ToList();

            return matches.Where(match => match.AwayTeamAbbreviation == team ||
                                          match.HomeTeamAbbreviation == team).ToList();
        }

        public List<EF.Entities.MatchScheduleViewModel> GetMatchesFromThisSeries(TableType tableType, string firstTeamID, string secondTeamID)
        {
            var teams = new List<string> { firstTeamID, secondTeamID }; 
            var matches = tableType == TableType.Results ? GetResultsForAllMatches() : GetSchedule();
            return matches.Where(match => teams.Contains(match.AwayTeamAbbreviation) &&
                                          teams.Contains(match.HomeTeamAbbreviation)).ToList();
        }

        public void DeleteThisMatch(int matchNumberForDelete) => _matchDAO.DeleteThisMatch(matchNumberForDelete);

        public DateTime GetMaxDateForAllMatches() => _matchEfdao.GetMaxDateForAllMatches();

        public DateTime GetDateForNextMatch(TypeOfMatchEnum matchType) => _matchEfdao.GetDateForNextMatch(matchType);

        public List<EF.Entities.MatchFromSchedule> GetMatchesForThisDay(DateTime date, EF.Entities.TypeOfMatchEnum matchType) => _matchEfdao.GetRemainingScheduleForThisDay(date, matchType).ToList();

        public List<EF.Entities.MatchScheduleViewModel> GetSchedule() => _matchEfdao.GetScheduleForAllMatches().ToList();
    }
}