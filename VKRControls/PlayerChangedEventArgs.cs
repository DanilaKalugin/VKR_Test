using System;
using Entities;

namespace VKRControls
{
    public class PlayerChangedEventArgs: EventArgs
    {
        public PlayerChangedEventArgs() { }

        public PlayerChangedEventArgs(Batter playerInfo) => PlayerInfo = playerInfo;

        public Batter PlayerInfo { get; set; }
    }
}