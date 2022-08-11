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

        public void StartNewMatch(Match match)
        {
            _matchEfdao.StartNewMatch(match);
            match.GameSituations = new List<GameSituation> { new(match.AwayTeam) };
        }

        public int GetNextMatchId(Match newMatch) => _matchEfdao.GetNextMatchId(newMatch.MatchTypeId);

        public void AddNewAtBat(AtBat atBat) => _matchEfdao.AddNewAtBat(atBat);

        public void FinishMatch(Match match) => _matchEfdao.FinishMatch(match);

        public void AddMatchResultForThisPitcher(PitcherResults pitcherResults) => _matchEfdao.AddMatchResultForThisPitcher(pitcherResults);

        public void DeleteThisMatch(int matchID) => _matchEfdao.DeleteMatch(matchID);

        public DateTime GetMaxDateForAllMatches() => _matchEfdao.GetMaxDateForAllMatches();

        public DateTime GetDateForNextMatch(TypeOfMatchEnum matchType) => _matchEfdao.GetDateForNextMatch(matchType);

        public List<MatchFromSchedule> GetMatchesForThisDay(DateTime date, TypeOfMatchEnum matchType) => _matchEfdao.GetRemainingScheduleForThisDay(date, matchType).ToList();
    }
}