using Entities;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class StartingLineupForm : Form
    {
        public StartingLineupForm(Team team)
        {
            InitializeComponent();
            Text = $"{team.TeamTitle.ToUpper()} Batting Order".ToUpper();
            lbTeamTitle.Text = $"{team.TeamTitle.ToUpper()} Batting Order".ToUpper();
            teamLogo.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{team.TeamAbbreviation}.png");
            BackColor = team.TeamColorForThisMatch;
            GetInfoAboutBatter(team.BattingLineup[0], p1_photo, p1_FirstName, p1_SecondName, p1_Number, p1_Position, team);
            GetInfoAboutBatter(team.BattingLineup[1], p2_photo, p2_FirstName, p2_SecondName, p2_Number, p2_Position, team);
            GetInfoAboutBatter(team.BattingLineup[2], p3_photo, p3_FirstName, p3_SecondName, p3_Number, p3_Position, team);
            GetInfoAboutBatter(team.BattingLineup[3], p4_photo, p4_FirstName, p4_SecondName, p4_Number, p4_Position, team);
            GetInfoAboutBatter(team.BattingLineup[4], p5_photo, p5_FirstName, p5_SecondName, p5_Number, p5_Position, team);
            GetInfoAboutBatter(team.BattingLineup[5], p6_photo, p6_Firstname, p6_SecondName, p6_Number, p6_Position, team);
            GetInfoAboutBatter(team.BattingLineup[6], p7_photo, p7_FirstName, p7_SecondName, p7_Number, p7_Position, team);
            GetInfoAboutBatter(team.BattingLineup[7], p8_photo, p8_FirstName, p8_SecondName, p8_Number, p8_Position, team);
            GetInfoAboutBatter(team.BattingLineup[8], p9_photo, p9_FirstName, p9_SecondName, p9_Number, p9_Position, team);
            teamManager.Text = $"► Team Manager: {team.TeamManager.FullName}".ToUpper();
            timer1.Start();
        }

        public void GetInfoAboutBatter(Batter batter, Panel photo, Label Name, Label SecondName, Label Number, Label Position, Team team)
        {
            if (BackColor == team.TeamColor[1])
            {
                photo.BackColor = team.TeamColor[0];
            }
            else
            {
                photo.BackColor = team.TeamColor[1];
            }

            if (File.Exists($"PlayerPhotos/Player{batter.id:0000}.png"))
            {
                photo.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{batter.id:0000}.png");
            }
            else
            {
                photo.BackgroundImage = null;
            }

            Name.Text = batter.FirstName.ToUpper();
            SecondName.Text = batter.SecondName.ToUpper();
            Number.Text = batter.PlayerNumber.ToString();
            Position.Text = batter.PositionForThisMatch;
        }

        private void timer_LineupForm_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.04;
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

        private void StartingLineupForm_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}