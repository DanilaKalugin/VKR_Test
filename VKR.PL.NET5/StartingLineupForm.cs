using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VKR.EF.Entities;
using VKR.PL.Controls.NET5;
using VKR.PL.Utils.NET5;

namespace VKR.PL.NET5
{
    public partial class StartingLineupForm : Form
    {
        private Color _photoBackColor;
        private readonly Team _team;

        public StartingLineupForm(Team team)
        {
            InitializeComponent();

            var teamLineup = new List<PlayerInfoWithPhoto>
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

            Text = $"{_team.TeamCity} {_team.TeamName}";
            lbTeamTitle.Text = $"{_team.TeamName.ToUpper()} Batting Order".ToUpper();
            teamLogo.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/TeamLogoForMenu/{_team.TeamAbbreviation}.png");
            teamManager.Text = $"► Team Manager: {team.Manager.FullName}".ToUpper();
            BackColor = _team.TeamColorForThisMatch;

            for (var i = 0; i < teamLineup.Count; i++)
            {
                teamLineup[i].SetPlayer(team.BattingLineup[i]);
                teamLineup[i].SetBackgroundColor(_photoBackColor);
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

        private void StartingLineupForm_BackColorChanged(object sender, EventArgs e) => _photoBackColor = BackColor == _team.TeamColors[1].Color ? _team.TeamColors[0].Color : _team.TeamColors[1].Color;
    }
}