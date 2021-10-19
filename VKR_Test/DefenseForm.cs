using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class DefenseForm : Form
    {
        private Team Defense;

        public DefenseForm(Team team)
        {
            InitializeComponent();
            Text = $"{team.TeamCity} {team.TeamTitle}";
            lbTeamTitle.Text = $"{team.TeamTitle.ToUpper()} Defense".ToUpper();
            teamLogo.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{team.TeamAbbreviation}.png");
            Defense = team;
        }

        private void DefenseForm_Load(object sender, EventArgs e)
        {
            DisplayInfoAboutPlayer(c_FirstName, c_SecondName, c, "C");
            DisplayInfoAboutPlayer(_1b_FirstName, _1b_SecondName, _1b, "1B");
            DisplayInfoAboutPlayer(_2b_FirstName, _2b_SecondName, _2b, "2B");
            DisplayInfoAboutPlayer(_3b_FirstName, _3b_SecondName, _3b, "3B");
            DisplayInfoAboutPlayer(ss_FirstName, ss_SecondName, ss, "SS");
            DisplayInfoAboutPlayer(cf_FirstName, cf_SecondName, cf, "CF");
            DisplayInfoAboutPlayer(rf_FirstName, rf_SecondName, rf, "RF");
            DisplayInfoAboutPlayer(lf_FirstName, lf_SecondName, lf, "LF");
            DisplayInfoAboutPlayer(p_FirstName, p_SecondName, p, "P");
            timer_Defense.Start();
        }

        private void DisplayInfoAboutPlayer(Label FirstName, Label SecondName, Label Position, string PositionTitle)
        {
            Position.BackColor = Defense.TeamColorForThisMatch;
            Position.ForeColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(Position.BackColor, false);
            if (PositionTitle == "P")
            {
                FirstName.Text = Defense.CurrentPitcher.FirstName.ToUpper();
                SecondName.Text = Defense.CurrentPitcher.SecondName.ToUpper();
            }
            else
            {
                Batter batter = Defense.BattingLineup.Where(_batter => _batter.PositionForThisMatch == PositionTitle).FirstOrDefault();
                FirstName.Text = batter.FirstName.ToUpper();
                SecondName.Text = batter.SecondName.ToUpper();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.005;
            if (Opacity < 1E-7)
            {
                Close();
            }
        }

        private void timer_Defense_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            timer_Defense.Stop();
        }

        private void tableLayoutPanel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}