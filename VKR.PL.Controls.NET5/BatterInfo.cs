using System;
using System.ComponentModel;
using System.Windows.Forms;
using VKR.EF.Entities.Tables;
using VKR.EF.Entities.ViewModels;
using VKR.PL.Controls.NET5.EventArgs;
using VKR.PL.Utils.NET5;

namespace VKR.PL.Controls.NET5
{
    public partial class BatterInfo : UserControl
    {
        private static Match _match;
        private Batter _batter;

        [Browsable(false)]
        public Batter Batter
        {
            get => _batter;
            set
            {
                _batter = value;
                var args = new PlayerChangedEventArgs(_batter);
                BatterChanged(this, args);
            }
        }
        
        internal event EventHandler<PlayerChangedEventArgs> BatterChanged;
        
        public BatterInfo()
        {
            InitializeComponent();
            BatterChanged += OnBatterChanged;
        }

        private void OnBatterChanged(object? sender, PlayerChangedEventArgs e)
        {
            if (e.PlayerInfo is null) return;
            BatterNumber.Text = $@"{e.PlayerInfo.NumberInLineup}.";
            lbBatterSecondName.Text = e.PlayerInfo.SecondName;
            BatterStats.Text = HitsForAtBatsHelper.GetDailyStats(e.PlayerInfo, _match);
        }

        public static void SetMatch(Match match) => _match = match;
    }
}