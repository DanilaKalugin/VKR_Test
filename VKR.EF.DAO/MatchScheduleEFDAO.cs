using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class MatchScheduleEFDAO
    {
        public async Task<List<MatchScheduleViewModel>> GetResultsForAllMatches(Season season, TypeOfMatchEnum typeOfMatch)
        {
            await using var db = new VKRApplicationContext();

            var matches = db.Matches.Where(match => match.SeasonId == season.Year && match.MatchTypeId == typeOfMatch)
                .Include(m => m.MatchResult)
                .Include(match => match.Stadium)
                .ThenInclude(stadium => stadium.StadiumCity);

            var results = await matches
                .Where(m => m.MatchResult != null)
                .Select(m => new MatchScheduleViewModel(true, m.MatchEnded, m.AwayTeamAbbreviation, m.HomeTeamAbbreviation, m.MatchResult.Length, m.MatchResult.AwayTeamRuns, m.MatchResult.HomeTeamRuns, m.Stadium, m.MatchDate))
                .ToListAsync()
                .ConfigureAwait(false);

            var activeMatches = await db.ActiveMatchResults
                .ToListAsync()
                .ConfigureAwait(false);

            var activeMatchResults = (await matches.ToListAsync().ConfigureAwait(false))
                .Join(activeMatches,
                    match => match.Id,
                    activeMatch => activeMatch.MatchId,
                    (match, res) => new MatchScheduleViewModel(true, match.MatchEnded, match.AwayTeamAbbreviation,
                        match.HomeTeamAbbreviation, res.Inning, res.AwayTeamRuns, res.HomeTeamRuns, match.Stadium,
                        match.MatchDate)).ToList();

            return results.Union(activeMatchResults).ToList();
        }

        public async Task<List<MatchScheduleViewModel>> GetScheduleForAllMatches(Season season, TypeOfMatchEnum typeOfMatch)
        {
            await using var db = new VKRApplicationContext();
            return await db.NextMatches.Where(match => match.SeasonId == season.Year && match.MatchTypeId == typeOfMatch)
                .Include(m => m.HomeTeam)
                .ThenInclude(team => team.StadiumsForMatchTypes)
                .ThenInclude(tmts => tmts.Stadium)
                .ThenInclude(stadium => stadium.StadiumCity)
                .Where(m => !m.IsPlayed)
                .Select(m => new MatchScheduleViewModel(m.IsPlayed, false, m.AwayTeamAbbreviation, m.HomeTeamAbbreviation, 1, 0, 0, m.HomeTeam.StadiumsForMatchTypes.First().Stadium, m.MatchDate))
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}