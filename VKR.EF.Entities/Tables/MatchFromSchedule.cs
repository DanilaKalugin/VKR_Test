namespace VKR.EF.Entities.Tables
{
    public class MatchFromSchedule : MatchBaseClass
    {
        public bool IsPlayed { get; set; }
        public int? MatchResultId { get; set; }
        public Match Match { get; set; }
    }
}