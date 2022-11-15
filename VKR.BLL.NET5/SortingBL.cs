using System;
using System.Collections.Generic;
using System.Linq;

namespace VKR.BLL.NET5
{
    public static class SortingBL
    {
        public static List<TKey> GetSortedStatsDesc<TKey, TField>(this List<TKey> statsList, Func<TKey, TField> sortingCondition) => 
            statsList.OrderByDescending(sortingCondition).ToList();

        public static List<TKey> GetSortedStats<TKey, TField>(this List<TKey> statsList, Func<TKey, TField> sortingCondition) => 
            statsList.OrderBy(sortingCondition).ToList();
    }
}