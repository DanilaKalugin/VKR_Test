using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using VKR.EF.Entities;
using VKR.PL.Utils.NET5;
using ProgressBar = ExtendedDotNET.Controls.Progress.ProgressBar;

namespace VKR.PL.NET5
{
    public partial class PitcherSubstitutionForm : Form
    {
        private readonly Team _currentTeam;
        private readonly List<Pitcher> _pitchers;
        private int _playerIndex;
        private readonly List<ProgressBar> _progressBars;
        public Pitcher NewPitcherForThisTeam;

        public PitcherSubstitutionForm(Team defense, List<Pitcher> pitchers)
        {
            InitializeComponent();
            _progressBars = new List<ProgressBar>
            {
                pb_stamina1,
                pb_stamina2,
                pb_stamina3,
                pb_stamina4,
                pb_stamina5
            };
            _currentTeam = defense;
            _pitchers = pitchers;

            vScrollBar1.Maximum = pitchers.Count > 5 ? pitchers.Count - 5 : 0;
            lbTeamTitle.Text = defense.TeamName.ToUpper();
            lbTeamTitle.ForeColor = defense.TeamColorForThisMatch;
            Text = $"New pitcher for {defense.TeamName}";
            lbHeader.Text = "BULLPEN";

            foreach (Control c in tableLayoutPanel1.Controls)
            {
                c.MouseClick += ClickOnTableLayoutPanel;
                c.MouseDoubleClick += DoubleClickOnTableLayoutPanel;
            }
        }

        private void DoubleClickOnTableLayoutPanel(object sender, MouseEventArgs e)
        {
            var rowNumber = tableLayoutPanel1.GetRow((Control)sender);

            if (rowNumber <= 0 || rowNumber > _pitchers.Count) return;

            NewPitcherForThisTeam = _pitchers[_playerIndex + rowNumber - 1];
            DialogResult = DialogResult.OK;
        }

        private void PitcherSubstitutionForm_Load(object sender, EventArgs e)
        {
            foreach (var pb in _progressBars) 
                pb.MainColor = _currentTeam.TeamColorForThisMatch;

            panelTeamLogo.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/TeamLogosForSubstitution/{_currentTeam.TeamAbbreviation}.png");
            PlayersChanging();
        }


        private void RowChanging(int step, Label playerName, Label playerERA, Label playerSO, ProgressBar progressBar, PictureBox pb)
        {
            if (_playerIndex + step < _pitchers.Count)
            {
                pb.Image = ImageHelper.ShowImageIfExists($"Images/PlayerPhotos/Player{_pitchers[_playerIndex + step].Id:0000}.png");
                playerName.Text = _pitchers[_playerIndex + step].FullName;
                playerERA.Text = $"{_pitchers[_playerIndex + step].PitchingStats.ERA.ToString("0.00", new CultureInfo("en-US"))}";
                playerSO.Text = _pitchers[_playerIndex + step].PitchingStats.Strikeouts.ToString();
                progressBar.Value = (int)_pitchers[_playerIndex + step].RemainingStamina;
                progressBar.Visible = true;
            }
            else
            {
                pb.Image = null;
                playerName.Text = string.Empty;
                playerERA.Text = string.Empty;
                playerSO.Text = string.Empty;
                progressBar.Value = 0;
                progressBar.Visible = false;
            }
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            _playerIndex = vScrollBar1.Value;
            PlayersChanging();
        }

        private void PlayersChanging()
        {
            RowChanging(0, label1, label6, label11, _progressBars[0], pictureBox1);
            RowChanging(1, label2, label7, label12, _progressBars[1], pictureBox2);
            RowChanging(2, label3, label8, label13, _progressBars[2], pictureBox3);
            RowChanging(3, label4, label9, label14, _progressBars[3], pictureBox4);
            RowChanging(4, label5, label10, label15, _progressBars[4], pictureBox5);
        }

        public void ClickOnTableLayoutPanel(object sender, MouseEventArgs e)
        {
            var rowNumber = tableLayoutPanel1.GetRow((Control)sender);
            for (var i = 1; i < tableLayoutPanel1.RowCount; i++)
            for (var j = 1; j < tableLayoutPanel1.ColumnCount - 1; j++)
            {
                tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = i == rowNumber && rowNumber <= _pitchers.Count ? _currentTeam.TeamColorForThisMatch : Color.White;
                tableLayoutPanel1.GetControlFromPosition(j, i).ForeColor = i == rowNumber && rowNumber <= _pitchers.Count ? CorrectForeColorForAllBackColors.GetForeColorForThisSituation(_currentTeam.TeamColorForThisMatch, false) : Color.Black;
            }
        }
    }
}