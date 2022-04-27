using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Entities;

namespace VKR_Test
{
    public partial class StartingLineupForm : Form
    {
        private List<PlayerInfoWithPhoto> teamLineup;
        private Color photoBackColor;
        private readonly Team _team;

        public StartingLineupForm(Team team)
        {
            InitializeComponent();

            teamLineup = new List<PlayerInfoWithPhoto>()
            {
                FirstPlayerInLineup,
                SecondPlayerInLineup,
                ThirdPlayerInLineup,
                ForthPlayerInLineup,
                FifthPlayerInLineup,
                SixthPlayerInLineup,
                SeventhPlayerInLineup,
                EighthPlayerInLineup,
                NinethPlayerInLineup
            };

            _team = team;

            Text = $"{_team.TeamCity} {_team.TeamTitle}";
            lbTeamTitle.Text = $"{_team.TeamTitle.ToUpper()} Batting Order".ToUpper();
            teamLogo.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{_team.TeamAbbreviation}.png");
            teamManager.Text = $"► Team Manager: {team.TeamManager.FullName}".ToUpper();
            BackColor = _team.TeamColorForThisMatch;

            for (var i = 0; i < teamLineup.Count; i++)
            {
                teamLineup[i].SetPlayer(team.BattingLineup[i]);
                teamLineup[i].SetBackgroundColor(photoBackColor);
            }
            timer1.Start();
        }

        private void timer_LineupForm_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.005;
            if (Opacity == 0) Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_LineupForm.Start();
            timer1.Stop();
        }

        private void StartingLineupForm_DoubleClick(object sender, EventArgs e) => Close();

        private void StartingLineupForm_BackColorChanged(object sender, EventArgs e) => photoBackColor = BackColor == _team.TeamColor[1] ? _team.TeamColor[0] : _team.TeamColor[1];
    }
}