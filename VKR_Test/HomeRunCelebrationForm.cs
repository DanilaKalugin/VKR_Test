using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class HomeRunCelebrationForm : Form
    {
        public HomeRunCelebrationForm(Team team, string HRType, Batter batter, List<AtBat> allAtBats)
        {
            InitializeComponent();
            BackColor = team.TeamColorForThisMatch;
            label1.Text = HRType;
            timer2.Start();
            panel1.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{team.TeamAbbreviation}.png");
            panel2.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{team.TeamAbbreviation}.png");
            panel10.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{batter.id:0000}.png");
            label2.Text = batter.FullName.ToUpper();

            int HRTodayForThisBatter = allAtBats.Where(atBat => atBat.AtBatResult == AtBat.AtBatType.HomeRun && atBat.Batter == batter.id).Count();

            label3.Text = $"{OrdinalNumerals.GetOrdinalNumeralFromQuantitive(batter.HomeRuns + 1)} HR in career";
            label4.Text = $"{OrdinalNumerals.GetOrdinalNumeralFromQuantitive(HRTodayForThisBatter + 1)} HR in this match";
            label4.Visible = HRTodayForThisBatter > 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.05;
            if (Opacity == 0)
            {
                Close();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void HomeRunCelebrationForm_BackColorChanged(object sender, EventArgs e)
        {
            List<int> colorcomponents = new List<int> { BackColor.R, BackColor.G, BackColor.B };
            if(colorcomponents.Max() <= 40)
            {
                label1.ForeColor = Color.WhiteSmoke;
                label2.ForeColor = Color.WhiteSmoke;
                label3.ForeColor = Color.WhiteSmoke;
                label4.ForeColor = Color.WhiteSmoke;
            }
        }
    }
}