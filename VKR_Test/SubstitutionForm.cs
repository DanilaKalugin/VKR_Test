using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Entities;
using VKR.PL.Utils;

namespace VKR_Test
{
    public partial class SubstitutionForm : Form
    {
        private readonly Team _currentTeam;
        private readonly List<Batter> _batters;
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
            foreach (var batter in _batters)
            {
                var imagePath = $"PlayerPhotosForSubstitution/Player{batter.Id:0000}.jpg";
                var image = File.Exists(imagePath) ? Image.FromFile(imagePath) : null;
                dgvAvailablePlayers.Rows.Add(image, batter.FullName,
                        $"{batter.BattingStats.AVG.ToString("#.000", new CultureInfo("en-US"))}",
                        $"{batter.BattingStats.HomeRuns}");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            NewBatterForThisTeam = _batters[dgvAvailablePlayers.SelectedRows[0].Index];
            DialogResult = DialogResult.OK;
        }
    }
}