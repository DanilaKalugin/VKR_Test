namespace VKR.EF.Entities
{
    public class TeamStadiumForTypeOfMatch
    {
        public Team Team { get; set; }
        public string TeamAbbreviation { get; set; }
        public TypeOfMatch TypeOfMatch { get; set; }
        public TypeOfMatchEnum TypeOfMatchId { get; set; }
        public Stadium Stadium { get; set; }
        public ushort StadiumId { get; set; }
    }
}