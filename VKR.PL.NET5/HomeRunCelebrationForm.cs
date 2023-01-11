using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VKR.PL.Utils.NET5;
using VKR.EF.Entities;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.Tables;
using VKR.EF.Entities.ViewModels;

namespace VKR.PL.NET5
{
    public partial class HomeRunCelebrationForm : Form
    {
        public HomeRunCelebrationForm(Team team, string hrType, Batter batter, IEnumerable<AtBat> allAtBats, bool isQuickMatch)
        {
            InitializeComponent();
            BackColor = team.TeamColorForThisMatch;
            lbHomeRunType.Text = hrType;
            Text = hrType;
            timer2.Start();

            panel1.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/TeamLogoForMenu/{team.TeamAbbreviation}.png");
            panel2.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/TeamLogoForMenu/{team.TeamAbbreviation}.png");
            pbPatterPhoto.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/PlayerPhotos/Player{batter.Id:0000}.png");
            
            lbBatterName.Text = batter.FullName.ToUpper();
            var hrTodayForThisBatter = allAtBats.Count(atBat => atBat.AtBatType == AtBatType.HomeRun && atBat.BatterId == batter.BatterId);

            lbBatterHRNumber.Visible = !isQuickMatch;

            lbBatterHRNumber.Text = $@"{OrdinalNumerals.GetOrdinalNumeralFromQuantitative(batter.BattingStats.HomeRuns + 1)} HR in season";
            lbBatterHRNumberInThisMatch.Text = $@"{OrdinalNumerals.GetOrdinalNumeralFromQuantitative(hrTodayForThisBatter + 1)} HR in this match";
            lbBatterHRNumberInThisMatch.Visible = hrTodayForThisBatter > 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.05;
            if (Opacity == 0) Close();
        }

        private void timer2_Tick(object sender, EventArgs e) => timer1.Start();

        private void BackColorChanging(object sender, EventArgs e)
        {
            if (sender is Label l) l.ForeColor = 
                CorrectForeColorForAllBackColors.GetForeColorForThisSituation(BackColor, true);
        }

        private void HomeRunCelebrationForm_DoubleClick(object sender, EventArgs e) => Close();
    }
}