using System;
using VKR.EF.Entities;

namespace VKR.PL.Controls.NET5
{
    public class PlayerChangedEventArgs: EventArgs
    {
        public PlayerChangedEventArgs(Batter playerInfo) => PlayerInfo = playerInfo;

        public Batter PlayerInfo { get; set; }
    }
}