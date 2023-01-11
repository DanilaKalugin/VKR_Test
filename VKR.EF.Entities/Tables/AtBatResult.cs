using System.Collections.Generic;
using VKR.EF.Entities.Enums;

namespace VKR.EF.Entities.Tables
{
    public class AtBatResult
    {
        public AtBatType Id { get; set; }
        public string Description { get; set; }
        public virtual List<AtBat> AtBats { get; set; } = new();
    }
}