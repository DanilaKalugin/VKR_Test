using System;
using System.Collections.Generic;
using System.Linq;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class MatchBL
    {
        private readonly MatchEFDAO _matchEfdao = new();

        public enum TableType { Results, Schedule }

        public void StartNewMatch(Match match)
        {
            _matchEfdao.StartNewMatch(match);
            match.GameSituations = new List<GameSituation> { new(match.AwayTeam) };
        }

        public int GetNumberOfMatchesPlayed(Match newMatch) => _matchEfdao.GetNextMatchId(newMatch.MatchTypeId);

        public void AddNewAtBat(AtBat atBat) => _matchEfdao.AddNewAtBat(atBat);

        public void FinishMatch(Match match) => _matchEfdao.FinishMatch(match);

        public void AddMatchResultForThisPitcher(PitcherResults pitcherResults) => _matchEfdao.AddMatchResultForThisPitcher(pitcherResults);

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

        public void DeleteThisMatch(int matchID) => _matchEfdao.DeleteMatch(matchID);

        public DateTime GetMaxDateForAllMatches() => _matchEfdao.GetMaxDateForAllMatches();

        public DateTime GetDateForNextMatch(TypeOfMatchEnum matchType) => _matchEfdao.GetDateForNextMatch(matchType);

        public List<MatchFromSchedule> GetMatchesForThisDay(DateTime date, TypeOfMatchEnum matchType) => _matchEfdao.GetRemainingScheduleForThisDay(date, matchType).ToList();

        public List<MatchScheduleViewModel> GetSchedule() => _matchEfdao.GetScheduleForAllMatches().ToList();

        public void SubstitutePitcher(Match match, Pitcher pitcher) => _matchEfdao.SubstitutePitcher(match, pitcher);
        public void SubstituteBatter(Match match, Batter batter) => _matchEfdao.SubstituteBatter(match, batter);
    }
}