using System;

namespace VKR.EF.Entities
{
    public class CountOfMatchesPlayed
    {
        public ulong PlayerId { get; set; }
        public int? GamesPlayed { get; set; }
    }
}