using System.ComponentModel.DataAnnotations.Schema;

namespace VKR.EF.Entities
{
    public class Team
    {
        public string TeamAbbreviation { get; set; }
        public string TeamCity { get; set; }
        public string TeamName { get; set; }
        public Division Division { get; set; }
        public int DivisionId { get; set; }
    }
}