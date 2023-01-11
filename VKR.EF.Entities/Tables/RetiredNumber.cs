using System;

namespace VKR.EF.Entities.Tables
{
    public class RetiredNumber
    {
        public short Id { get; set; }
        public byte Number { get; set; }
        public Team Team { get; set; }
        public string? TeamId { get; set; }
        public string Person { get; set; }
        public DateTime Date { get; set; }
    }
}