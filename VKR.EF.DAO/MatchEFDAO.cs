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
    }
}