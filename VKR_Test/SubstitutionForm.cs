using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class SubstitutionForm : Form
    {
        private Team _currentTeam;
        private List<Batter> _batters;
        public Batter NewBatterForThisTeam;

        private void PitcherSubstitutionForm_Load(object sender, EventArgs e)
        {
            dgvAvailablePlayers.DefaultCellStyle.SelectionBackColor = _currentTeam.TeamColorForThisMatch;
            dgvAvailablePlayers.DefaultCellStyle.SelectionForeColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(_currentTeam.TeamColorForThisMatch, false);
            panelTeamLogo.BackgroundImage = Image.FromFile($"TeamLogosForSubstitution/{_currentTeam.TeamAbbreviation}.png");
        }

        public SubstitutionForm(Team offense, List<Batter> batters)
        {
            InitializeComponent();
            _currentTeam = offense;
            _batters = batters;
            lbTeamTitle.Text = offense.TeamTitle.ToUpper();
            lbTeamTitle.ForeColor = offense.TeamColorForThisMatch;
            Text = $"New batter for {offense.TeamTitle}";
            lbHeader.Text = "PINCH HITTER";
            dgvAvailablePlayers.Columns[2].HeaderText = "AVG";
            dgvAvailablePlayers.Columns[3].HeaderText = "HR";
            for (int i = 0; i < _batters.Count; i++)
            {
                if (File.Exists($"PlayerPhotosForSubstitution/Player{_batters[i].Id:0000}.jpg"))
                {
                    dgvAvailablePlayers.Rows.Add(Image.FromFile($"PlayerPhotosForSubstitution/Player{_batters[i].Id:0000}.jpg"), _batters[i].FullName, $"{_batters[i].battingStats.AVG.ToString("#.000", new CultureInfo("en-US"))}", $"{_batters[i].battingStats.HomeRuns}");
                }
                else
                {
                    dgvAvailablePlayers.Rows.Add(null, _batters[i].FullName, $"{_batters[i].battingStats.AVG.ToString("#.000", new CultureInfo("en-US"))}", $"{_batters[i].battingStats.HomeRuns}");
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            NewBatterForThisTeam = _batters[dgvAvailablePlayers.SelectedRows[0].Index];
            DialogResult = DialogResult.OK;
        }
    }
}