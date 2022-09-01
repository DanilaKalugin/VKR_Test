namespace VKR.EF.Entities
{
    public abstract class StatGroupedBySeasonAndMatchType
    {
        public int Season { get; set; }
        public TypeOfMatchEnum MatchType { get; set; }
    }
}