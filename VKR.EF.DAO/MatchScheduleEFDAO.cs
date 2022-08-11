using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class MatchScheduleEFDAO
    {
        public List<MatchScheduleViewModel> GetResultsForAllMatches()
        {
            using var db = new VKRApplicationContext();

            var matches = db.Matches.Include(m => m.MatchResult)
                .Include(match => match.Stadium)
                .ThenInclude(stadium => stadium.StadiumCity);

            var results = matches
                .Where(m => m.MatchResult != null)
                .Select(m => new MatchScheduleViewModel(true, m.MatchEnded, m.AwayTeamAbbreviation, m.HomeTeamAbbreviation, m.MatchResult.Length, m.MatchResult.AwayTeamRuns, m.MatchResult.HomeTeamRuns, m.Stadium, m.MatchDate)).ToList();

            var activeMatches = db.ActiveMatchResults.ToList();

            var activeMatchResults = matches.ToList()
                .Join(activeMatches,
                    match => match.Id,
                    activeMatch => activeMatch.MatchId,
                    (match, res) => new MatchScheduleViewModel(true, match.MatchEnded, match.AwayTeamAbbreviation,
                        match.HomeTeamAbbreviation, res.Inning, res.AwayTeamRuns, res.HomeTeamRuns, match.Stadium,
                        match.MatchDate)).ToList();

            return results.Union(activeMatchResults).ToList();
        }

        public List<MatchScheduleViewModel> GetScheduleForAllMatches()
        {
            using var db = new VKRApplicationContext();
            return db.NextMatches.Include(m => m.HomeTeam)
                .ThenInclude(team => team.StadiumsForMatchTypes)
                .ThenInclude(tmts => tmts.Stadium)
                .ThenInclude(stadium => stadium.StadiumCity)
                .Where(m => !m.IsPlayed)
                .Select(m => new MatchScheduleViewModel(m.IsPlayed, false, m.AwayTeamAbbreviation, m.HomeTeamAbbreviation, 1, 0, 0, m.HomeTeam.StadiumsForMatchTypes.First().Stadium, m.MatchDate)).ToList();
        }
    }
}