using System.Collections.Generic;
using System.Linq;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class MatchScheduleBL
    {
        public enum TableType { Results, Schedule }

        private readonly MatchScheduleEFDAO _scheduleDao = new();

        public List<MatchScheduleViewModel> GetSchedule() => _scheduleDao.GetScheduleForAllMatches().ToList();

        public List<MatchScheduleViewModel> GetResultsForAllMatches() => _scheduleDao.GetResultsForAllMatches().ToList();

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
    }
}