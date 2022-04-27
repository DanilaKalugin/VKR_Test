using System;
using Entities;

namespace VKR_Test
{
    public class PlayerChangedEventArgs: EventArgs
    {
        public Batter PlayerInfo { get; set; }
    }
}