using System;
using System.Drawing;
using System.Windows.Forms;
using VKR.EF.Entities;
using VKR.EF.Entities.ViewModels;
using VKR.PL.Controls.NET5.EventArgs;
using VKR.PL.Utils.NET5;

namespace VKR.PL.Controls.NET5
{
    public partial class RunnerData : UserControl
    {
        public enum BaseTypeEnum
        {
            First = 1,
            Second = 2,
            Third = 3
        }

        private BaseTypeEnum _baseTypeEnum = BaseTypeEnum.First;
        private Batter _batter;
        private Color _teamColor;

        public BaseTypeEnum BaseType
        {
            get => _baseTypeEnum;
            set
            {
                _baseTypeEnum = value;
                var num = $@"{OrdinalNumerals.GetOrdinalNumeralFromQuantitative((int)value)} base";
                lb1stBase.Text = num.ToUpper();
            }
        }

        public Batter Batter
        {
            get => _batter;
            set
            {
                _batter = value;
                var args = new PlayerChangedEventArgs(_batter);
                RunnerChanged(this, args);
            }
        }

        public Color TeamColor
        {
            get => _teamColor;
            set
            {
                _teamColor = value;
                lb1stBase.BackColor = value;
            }
        }

        internal event EventHandler<PlayerChangedEventArgs> RunnerChanged;

        public RunnerData()
        {
            InitializeComponent();
            RunnerChanged += OnRunnerChanged;
        }

        private void OnRunnerChanged(object? sender, PlayerChangedEventArgs e)
        {
            if (e.PlayerInfo is null) return;

            RunnerOn1Photo.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/PlayerPhotos/Player{e.PlayerInfo.Id:0000}.png");
            lb_Runner1_Name.Text = e.PlayerInfo.FullName.ToUpper();
        }
    }
}
