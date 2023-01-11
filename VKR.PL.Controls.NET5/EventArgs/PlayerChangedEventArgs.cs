using VKR.EF.Entities.ViewModels;

namespace VKR.PL.Controls.NET5.EventArgs
{
    public class PlayerChangedEventArgs : System.EventArgs
    {
        public PlayerChangedEventArgs(Batter playerInfo) => PlayerInfo = playerInfo;

        public Batter PlayerInfo { get; set; }
    }
}