using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Entities;

namespace VKR_Test
{
    public partial class DefenseForm : Form
    {
        private readonly Team _defense;

        public DefenseForm(Team team)
        {
            InitializeComponent();
            Text = $@"{team.TeamCity} {team.TeamTitle}";
            lbTeamTitle.Text = $@"{team.TeamTitle.ToUpper()} Defense".ToUpper();
            teamLogo.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{team.TeamAbbreviation}.png");
            _defense = team;
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

        private void DisplayInfoAboutPlayer(Label firstName, Label secondName, Label position, string positionTitle)
        {
            position.BackColor = _defense.TeamColorForThisMatch;

            position.ForeColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(position.BackColor, false);
            if (positionTitle == "P")
            {
                firstName.Text = _defense.CurrentPitcher.FirstName.ToUpper();
                secondName.Text = _defense.CurrentPitcher.SecondName.ToUpper();
            }
            else
            {
                var batter = _defense.BattingLineup.FirstOrDefault(batter1 => batter1.PositionForThisMatch == positionTitle);
                firstName.Text = batter.FirstName.ToUpper();
                secondName.Text = batter.SecondName.ToUpper();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.005;
            if (Opacity < 1E-7) Close();
        }

        private void timer_Defense_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            timer_Defense.Stop();
        }

        private void tableLayoutPanel1_MouseDoubleClick(object sender, MouseEventArgs e) => Close();
    }
}