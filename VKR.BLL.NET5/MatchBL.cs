using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class MatchBL
    {
        private readonly MatchEFDAO _matchEfdao = new();

        public async Task StartNewMatch(Match match)
        {
            await _matchEfdao.StartNewMatch(match)
                .ConfigureAwait(false);
            match.GameSituations = new List<GameSituation> { new(match.AwayTeam) };
        }

        public async Task<int> GetNextMatchId(Match newMatch) => 
            await _matchEfdao.GetNextMatchId(newMatch.MatchTypeId)
                .ConfigureAwait(false);

        public async Task AddNewAtBat(AtBat atBat) => 
            await _matchEfdao.AddNewAtBat(atBat)
                .ConfigureAwait(false);

        public async Task AddNewRun(Run run) => 
            await _matchEfdao.AddNewRun(run)
                .ConfigureAwait(false);

        public async Task FinishMatch(Match match) => 
            await _matchEfdao.FinishMatch(match)
                .ConfigureAwait(false);

        public async Task AddMatchResultForThisPitcher(PitcherResults pitcherResults) =>
            await _matchEfdao.AddMatchResultForThisPitcher(pitcherResults)
                .ConfigureAwait(false);

        public async Task DeleteThisMatch(int matchID) =>
            await _matchEfdao.DeleteMatch(matchID)
                .ConfigureAwait(false);

        public async Task<DateTime> GetMaxDateForAllMatchesAsync() => 
            await _matchEfdao.GetMaxDateForAllMatchesAsync()
                .ConfigureAwait(false);

        public async Task<DateTime> GetDateForNextMatchAsync(TypeOfMatchEnum matchType) =>
            await _matchEfdao.GetDateForNextMatchAsync(matchType)
                .ConfigureAwait(false);

        public async Task<List<MatchFromSchedule>> GetMatchesForThisDayAsync(DateTime date, TypeOfMatchEnum matchType)
        {
            var matches = await _matchEfdao.GetRemainingScheduleForThisDayAsync(date, matchType)
                .ConfigureAwait(false);
            return matches.ToList();
        }
    }
}