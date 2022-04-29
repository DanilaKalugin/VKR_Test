using System;
using Entities;

namespace VKR_Test
{
    public class PlayerChangedEventArgs: EventArgs
    {
        public PlayerChangedEventArgs()
        {
        }

        public PlayerChangedEventArgs(Batter playerInfo)
        {
            PlayerInfo = playerInfo;
        }

        public Batter PlayerInfo { get; set; }
    }
}