using System.Collections.Generic;

namespace VKR.EF.Entities
{
    public class AtBatResult
    {
        public AtBatType Id { get; set; }
        public string Description { get; set; }
        public virtual List<AtBat> AtBats { get; set; } = new();
    }
}