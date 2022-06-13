using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    }
}