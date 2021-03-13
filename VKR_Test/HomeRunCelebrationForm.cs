using Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class HomeRunCelebrationForm : Form
    {
        public HomeRunCelebrationForm(Team team, string HRType, Batter batter)
        {
            InitializeComponent();
            BackColor = team.TeamColor[0];
            label1.Text = HRType;
            timer2.Start();
            panel1.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{team.TeamAbbreviation}.png");
            panel2.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{team.TeamAbbreviation}.png");
            panel10.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{batter.id.ToString("0000")}.jpg");
            label2.Text = batter.FirstName.ToUpper() + " " + batter.SecondName.ToUpper();

            if (batter.HomeRuns + 1 % 10 == 1 && batter.HomeRuns + 1 % 100 != 11)
            {
                label3.Text = $"{batter.HomeRuns + 1}st HR in career";
            }
            else if (batter.HomeRuns + 1 % 10 == 2 && batter.HomeRuns + 2 % 100 != 12)
            {
                label3.Text = $"{batter.HomeRuns + 1}nd HR in career";
            }
            else if (batter.HomeRuns + 1 % 10 == 3 && batter.HomeRuns + 2 % 100 != 13)
            {
                label3.Text = $"{batter.HomeRuns + 1}rd HR in career";
            }
            else
            {
                label3.Text = $"{batter.HomeRuns + 1}th HR in career";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.1;
            if (Opacity == 0)
            {
                Close();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}