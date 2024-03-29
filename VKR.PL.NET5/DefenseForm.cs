﻿using System;
using System.Linq;
using System.Windows.Forms;
using VKR.PL.Utils.NET5;
using VKR.EF.Entities.Tables;

namespace VKR.PL.NET5
{
    public partial class DefenseForm : Form
    {
        private readonly Team _defense;

        public DefenseForm(Team team)
        {
            InitializeComponent();
            Text = $"{team.TeamCity} {team.TeamName}";
            lbTeamTitle.Text = $"{team.TeamName.ToUpper()} Defense".ToUpper();
            teamLogo.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/TeamLogoForMenu/{team.TeamAbbreviation}.png");
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

        private void DisplayInfoAboutPlayer(Control firstName, Control secondName, Control position, string positionTitle)
        {
            position.BackColor = _defense.TeamColorForThisMatch;

            position.ForeColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(position.BackColor, false);

            var player = positionTitle == "P" ? (Player)_defense.CurrentPitcher : _defense.BattingLineup.FirstOrDefault(batter1 => batter1.PositionForThisMatch == positionTitle);

            firstName.Text = player?.FirstName.ToUpper();
            secondName.Text = player?.SecondName.ToUpper();
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