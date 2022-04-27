using System;
using System.Collections.Generic;
using System.Linq;

namespace VKR.BLL
{
    public class SortingBL
    {
        public List<TKey> GetSortedStatsDesc<TKey, TField>(List<TKey> statsList, Func<TKey, TField> sortingCondition) => statsList.OrderByDescending(sortingCondition).ToList();

        public List<TKey> GetSortedStats<TKey, TField>(List<TKey> statsList, Func<TKey, TField> sortingCondition) => statsList.OrderBy(sortingCondition).ToList();
    }
}