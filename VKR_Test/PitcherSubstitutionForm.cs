using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProgressBar = ExtendedDotNET.Controls.Progress.ProgressBar;
using Entities;
using VKR.BLL;
using System.IO;
using System.Globalization;

namespace VKR_Test
{
    public partial class PitcherSubstitutionForm : Form
    {
        private Team _currentTeam;
        private List<Pitcher> _pitchers;
        private int _playerIndex;
        private List<ProgressBar> _progressBars;
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
            lbTeamTitle.Text = defense.TeamTitle.ToUpper();
            lbTeamTitle.ForeColor = defense.TeamColorForThisMatch;
            Text = $"New pitcher for {defense.TeamTitle}";
            lbHeader.Text = "BULLPEN";
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                c.MouseClick += new MouseEventHandler(ClickOnTableLayoutPanel);
                c.MouseDoubleClick += new MouseEventHandler(DoubleClickOnTableLayoutPanel);
            }
        }

        private void DoubleClickOnTableLayoutPanel(object sender, MouseEventArgs e)
        {
            int rowNumber = tableLayoutPanel1.GetRow((Control)sender);
            if (rowNumber > 0 && rowNumber <= _pitchers.Count)
            {
                NewPitcherForThisTeam = _pitchers[_playerIndex + rowNumber - 1];
                DialogResult = DialogResult.OK;
            }
        }

        private void PitcherSubstitutionForm_Load(object sender, EventArgs e)
        {
            foreach (ProgressBar pb in _progressBars)
            {
                pb.MainColor = _currentTeam.TeamColorForThisMatch;
            }
            panelTeamLogo.BackgroundImage = Image.FromFile($"TeamLogosForSubstitution/{_currentTeam.TeamAbbreviation}.png");

            PlayersChaging();
        }


        private void RowChanging(int step, Label PlayerName, Label playerERA, Label playerSO, ProgressBar progressBar, PictureBox pb)
        {
            if (_playerIndex + step < _pitchers.Count)
            {
                if (File.Exists($"PlayerPhotos/Player{_pitchers[_playerIndex + step].Id:0000}.png"))
                {
                    pb.Image = Image.FromFile($"PlayerPhotos/Player{_pitchers[_playerIndex + step].Id:0000}.png");
                }
                else
                {
                    pb.Image = null;
                }
                PlayerName.Text = _pitchers[_playerIndex + step].FullName;
                playerERA.Text = $"{_pitchers[_playerIndex + step].pitchingStats.ERA.ToString("0.00", new CultureInfo("en-US"))}";
                playerSO.Text = _pitchers[_playerIndex + step].pitchingStats.Strikeouts.ToString();
                progressBar.Value = (int)_pitchers[_playerIndex + step].RemainingStamina;
                progressBar.Visible = true;
            }
            else
            {
                pb.Image = null;
                PlayerName.Text = string.Empty;
                playerERA.Text = string.Empty;
                playerSO.Text = string.Empty;
                progressBar.Value = 0;
                progressBar.Visible = false;
            }
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            _playerIndex = vScrollBar1.Value;
            PlayersChaging();
        }

        private void PlayersChaging()
        {
            RowChanging(0, label1, label6, label11, _progressBars[0], pictureBox1);
            RowChanging(1, label2, label7, label12, _progressBars[1], pictureBox2);
            RowChanging(2, label3, label8, label13, _progressBars[2], pictureBox3);
            RowChanging(3, label4, label9, label14, _progressBars[3], pictureBox4);
            RowChanging(4, label5, label10, label15, _progressBars[4], pictureBox5);
        }

        public void ClickOnTableLayoutPanel(object sender, MouseEventArgs e)
        {
            int RowNumber = tableLayoutPanel1.GetRow((Control)sender);
            for (int i = 1; i < tableLayoutPanel1.RowCount; i++)
            {
                if (i == RowNumber && RowNumber <= _pitchers.Count)
                {
                    for (int j = 1; j < tableLayoutPanel1.ColumnCount - 1; j++)
                    {
                        tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = _currentTeam.TeamColorForThisMatch;
                        tableLayoutPanel1.GetControlFromPosition(j, i).ForeColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(_currentTeam.TeamColorForThisMatch, false);
                    }
                }
                else
                {
                    for (int j = 1; j < tableLayoutPanel1.ColumnCount - 1; j++)
                    {
                        tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = Color.White;
                        tableLayoutPanel1.GetControlFromPosition(j, i).ForeColor = Color.Black;
                    }
                }
            }
        }
    }
}