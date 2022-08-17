using System.Collections.Generic;

namespace VKR.EF.Entities
{
    public class Manager: Man
    {
        public virtual List<Team> Teams { get; set; } = new();
    }
}