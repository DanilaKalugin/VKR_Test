using System;
using Entities.NET5;

namespace VKR.PL.Controls.NET5
{
    public class PlayerChangedEventArgs: EventArgs
    {
        public PlayerChangedEventArgs() { }

        public PlayerChangedEventArgs(Batter playerInfo) => PlayerInfo = playerInfo;

        public Batter PlayerInfo { get; set; }
    }
}