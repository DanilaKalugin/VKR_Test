using System;
using System.Windows.Forms;
using Entities;
using VKR.PL.Utils;

namespace VKRControls
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

        private void OnBatterChanged(object sender, PlayerChangedEventArgs e)
        {
            BatterNumber.Text = $@"{e.PlayerInfo.NumberInBattingLineup}.";
            lbBatterSecondName.Text = e.PlayerInfo.SecondName;
            BatterStats.Text = HitsForAtBatsHelper.GetDailyStats(e.PlayerInfo, _match);
        }

        public void SetPlayer(Batter batter)
        {
            var args = new PlayerChangedEventArgs(playerInfo: batter);
            BatterChanged?.Invoke(this, args);
        }

        public static void SetMatch(Match match) => _match = match;
    }
}