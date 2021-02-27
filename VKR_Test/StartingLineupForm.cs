using Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class StartingLineupForm : Form
    {
        public StartingLineupForm(Team team)
        {
            InitializeComponent();
            label37.Text = $"{team.TeamTitle.ToUpper()} Batting Order".ToUpper();
            panel1.BackColor = team.TeamColorForThisMatch;
            teamLogo.BackgroundImage = Image.FromFile($"BigTeamLogos/{team.TeamAbbreviation}.png");
            GetInfoAboutBatter(team.BattingLineup[0], p1, label1, label18, label19, label20);
            GetInfoAboutBatter(team.BattingLineup[1], p2, label2, label17, label22, label21);
            GetInfoAboutBatter(team.BattingLineup[2], p3, label3, label16, label24, label23);
            GetInfoAboutBatter(team.BattingLineup[3], p4, label4, label15, label26, label25);
            GetInfoAboutBatter(team.BattingLineup[4], p5, label5, label14, label28, label27);
            GetInfoAboutBatter(team.BattingLineup[5], p6, label6, label13, label30, label29);
            GetInfoAboutBatter(team.BattingLineup[6], p7, label7, label12, label32, label31);
            GetInfoAboutBatter(team.BattingLineup[7], p8, label8, label11, label34, label33);
            GetInfoAboutBatter(team.BattingLineup[8], p9, label9, label10, label36, label35);
            teamManager.Text = $"► Team Manager: {team.TeamManager.FirstName} {team.TeamManager.SecondName}".ToUpper();
            timer1.Start();
        }

        public void GetInfoAboutBatter(Batter batter, Panel photo, Label Name, Label SecondName, Label Number, Label Position)
        {
            photo.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{batter.id.ToString("0000")}.jpg");
            Name.Text = batter.FirstName;
            SecondName.Text = batter.SecondName;
            Number.Text = batter.PlayerNumber.ToString();
            Position.Text = batter.PositionForThisMatch;
        }

        private void timer_LineupForm_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.1;
            if (Opacity == 0)
            {
                Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_LineupForm.Start();
            timer1.Stop();
        }
    }
}