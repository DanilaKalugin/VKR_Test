using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Entities;

namespace VKR_Test
{
    public partial class HomeRunCelebrationForm : Form
    {
        public HomeRunCelebrationForm(Team team, string hrType, Player batter, IEnumerable<AtBat> allAtBats, bool isQuickMatch)
        {
            InitializeComponent();
            BackColor = team.TeamColorForThisMatch;
            lbHomeRunType.Text = hrType;
            Text = hrType;
            timer2.Start();
            panel1.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{team.TeamAbbreviation}.png");
            panel2.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{team.TeamAbbreviation}.png");

            var imagePath = $"PlayerPhotos/Player{batter.Id:0000}.png";
            var image = File.Exists(imagePath) ? Image.FromFile(imagePath) : null;
            pbPatterPhoto.BackgroundImage = image;
            
            lbBatterName.Text = batter.FullName.ToUpper();
            var HRTodayForThisBatter = allAtBats.Count(atBat => atBat.AtBatResult == AtBat.AtBatType.HomeRun && atBat.Batter == batter.Id);

            lbBatterHRNumber.Visible = !isQuickMatch;
            lbBatterHRNumberInThisMatch.Visible = !isQuickMatch;

            lbBatterHRNumber.Text = $@"{OrdinalNumerals.GetOrdinalNumeralFromQuantitive(batter.BattingStats.HomeRuns + 1)} HR in career";
            lbBatterHRNumberInThisMatch.Text = $@"{OrdinalNumerals.GetOrdinalNumeralFromQuantitive(HRTodayForThisBatter + 1)} HR in this match";
            lbBatterHRNumberInThisMatch.Visible = HRTodayForThisBatter > 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.05;
            if (Opacity == 0) Close();
        }

        private void timer2_Tick(object sender, EventArgs e) => timer1.Start();

        private void BackColorChanging(object sender, EventArgs e)
        {
            if (sender is Label l) l.ForeColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(BackColor, true);
        }

        private void HomeRunCelebrationForm_DoubleClick(object sender, EventArgs e) => Close();
    }
}