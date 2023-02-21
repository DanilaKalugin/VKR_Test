using System;
using System.Drawing;
using System.Windows.Forms;
using VKR.EF.Entities;
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
        private Runner _runner;
        private Color _teamColor;

        public BaseTypeEnum BaseType
        {
            get => _baseTypeEnum;
            set
            {
                _baseTypeEnum = value;
                var num = $@"{OrdinalNumerals.GetOrdinalNumeralFromQuantitative((int)value)} base";
                lbHeader.Text = num.ToUpper();
            }
        }

        public Runner Runner
        {
            get => _runner;
            set
            {
                _runner = value;
                var args = new RunnerChangedEventArgs(_runner);
                RunnerChanged(this, args);
            }
        }

        public Color TeamColor
        {
            get => _teamColor;
            set
            {
                _teamColor = value;
                lbHeader.BackColor = value;
            }
        }

        internal event EventHandler<RunnerChangedEventArgs> RunnerChanged;
        public event EventHandler IsSelectedChanged;

        public RunnerData()
        {
            InitializeComponent();
            RunnerChanged += OnRunnerChanged;
        }

        private void OnRunnerChanged(object? sender, RunnerChangedEventArgs e)
        {
            if (e.Runner is null) return;

            RunnerPhoto.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/PlayerPhotos/Player{e.Runner.RunnerPhotoId:0000}.png");
            lbRunnerName.Text = e.Runner.RunnerName.ToUpper();
            lbRunnerName.ForeColor = e.Runner.IsBaseStealingAttempt ? Color.DarkGoldenrod : Color.Gainsboro;
        }

        private void RunnerData_Click(object sender, System.EventArgs e)
        {
            if (IsSelectedChanged != null)
                IsSelectedChanged(this, e);
        }

        private void lbHeader_BackColorChanged(object sender, System.EventArgs e)
        {
            lbHeader.ForeColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(lbHeader.BackColor, false);
        }
    }
}
