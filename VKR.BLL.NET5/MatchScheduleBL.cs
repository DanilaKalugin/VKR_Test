using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class MatchScheduleBL
    {
        public enum TableType { Results, Schedule }

        private readonly MatchScheduleEFDAO _scheduleDao = new();

        public async Task<List<MatchScheduleViewModel>> GetSchedule(TypeOfMatchEnum matchType, Season season) => await _scheduleDao.GetScheduleForAllMatches(season, matchType);

        public async Task<List<MatchScheduleViewModel>> GetResultsForAllMatches(TypeOfMatchEnum matchType, Season season) => await _scheduleDao.GetResultsForAllMatches(season, matchType);

        public async Task<List<MatchScheduleViewModel>> GetMatchesForSelectedTeam(TypeOfMatchEnum matchType, Season season, TableType tableType, string team)
        {
            var matches = tableType == TableType.Results
                ? (await GetResultsForAllMatches(matchType, season)).OrderByDescending(match => match.MatchDate).ToList()
                : (await GetSchedule(matchType, season)).OrderBy(match => match.MatchDate).ToList();

            return matches.Where(match => match.AwayTeamAbbreviation == team ||
                                          match.HomeTeamAbbreviation == team).ToList();
        }

        public async Task<List<MatchScheduleViewModel>> GetMatchesFromThisSeries(TableType tableType, TypeOfMatchEnum matchType, Season season, string firstTeamID, string secondTeamID)
        {
            var teams = new List<string> { firstTeamID, secondTeamID };

            Func<TypeOfMatchEnum, Season, Task<List<MatchScheduleViewModel>>> matchesFunc =
                tableType == TableType.Results ? GetResultsForAllMatches : GetSchedule;

            var matches = await matchesFunc(matchType, season);
            return matches.Where(match => teams.Contains(match.AwayTeamAbbreviation) &&
                                          teams.Contains(match.HomeTeamAbbreviation)).ToList();
        }
    }
}