using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class MatchEFDAO
    {
        public IEnumerable<MatchFromSchedule> GetRemainingScheduleForThisDay(DateTime date, TypeOfMatchEnum matchType)
        {
            using var db = new VKRApplicationContext();
            return db.NextMatches.Where(nm => !nm.IsPlayed && nm.MatchTypeId == matchType && nm.MatchDate == date).ToList();
        }

        public DateTime GetMaxDateForAllMatches()
        {
            using var db = new VKRApplicationContext();
            return db.Matches.Include(m => m.MatchResult)
                .Where(m => m.MatchResult != null)
                .Select(m => m.MatchDate).Max();
        }

        public List<MatchScheduleViewModel> GetResultsForAllMatches()
        {
            using var db = new VKRApplicationContext();
            return db.Matches.Include(m => m.MatchResult)
                .Include(match => match.Stadium)
                .ThenInclude(stadium => stadium.StadiumCity)
                .Where(m => m.MatchResult != null)
                .Select(m => new MatchScheduleViewModel(true, m.MatchEnded, m.AwayTeamAbbreviation, m.HomeTeamAbbreviation, m.MatchLength, m.MatchResult.AwayTeamRuns, m.MatchResult.HomeTeamRuns, m.Stadium, m.MatchDate)).ToList();
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