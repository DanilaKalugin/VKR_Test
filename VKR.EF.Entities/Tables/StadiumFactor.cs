namespace VKR.EF.Entities.Tables
{
    public class StadiumFactor
    {
        public Stadium Stadium { get; set; }
        public ushort StadiumId { get; set; }
        public float HittingFactor { get; set; }
        public float SingleFactor { get; set; }
        public float DoubleFactor { get; set; }
        public float TripleFactor { get; set; }
        public float HomeRunFactor { get; set; }
    }
}