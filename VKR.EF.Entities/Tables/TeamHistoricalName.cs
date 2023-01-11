namespace VKR.EF.Entities.Tables
{
    public class TeamHistoricalName
    {
        public Team Team { get; set; }
        public string TeamAbbreviation { get; set; }
        public string TeamRegion { get; set; }
        public string TeamName { get; set; }
        public short FirstSeasonWithName { get; set; }
        public short? LastSeasonWithName { get; set; }
    }
}