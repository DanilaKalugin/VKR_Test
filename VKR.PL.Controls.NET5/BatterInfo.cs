using System;
using System.Windows.Forms;
using VKR.Entities.NET5;
using VKR.PL.Utils.NET5;

namespace VKR.PL.Controls.NET5
{
    public partial class BatterInfo : UserControl
    {
        private static Match _match;
        
        internal event EventHandler<PlayerChangedEventArgs> BatterChanged;
        
        public BatterInfo()
        {
            InitializeComponent();
            BatterChanged += OnBatterChanged;
        }

        private void OnBatterChanged(object? sender, PlayerChangedEventArgs e)
        {
            BatterNumber.Text = $@"{e.PlayerInfo.NumberInBattingLineup}.";
            lbBatterSecondName.Text = e.PlayerInfo.SecondName;
            BatterStats.Text = HitsForAtBatsHelper.GetDailyStats(e.PlayerInfo, _match);
        }

        public void SetPlayer(Batter batter)
        {
            var args = new PlayerChangedEventArgs(batter);
            BatterChanged(this, args);
        }

        public static void SetMatch(Match match) => _match = match;
    }
}