using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using VKR.EF.Entities.Tables;
using VKR.EF.Entities.ViewModels;
using VKR.PL.Utils.NET5;

namespace VKR.PL.NET5
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
            panelTeamLogo.BackgroundImage = Image.FromFile($"Images/TeamLogosForSubstitution/{_currentTeam.TeamAbbreviation}.png");
        }

        public SubstitutionForm(Team offense, List<Batter> batters)
        {
            InitializeComponent();
            _currentTeam = offense;
            _batters = batters;
            lbTeamTitle.Text = offense.TeamName.ToUpper();
            lbTeamTitle.ForeColor = offense.TeamColorForThisMatch;
            Text = $"New batter for {offense.TeamName}";
            lbHeader.Text = "PINCH HITTER";
            dgvAvailablePlayers.Columns[2].HeaderText = "AVG";
            dgvAvailablePlayers.Columns[3].HeaderText = "HR";
            foreach (var batter in _batters)
            {
                var image = ImageHelper.ShowImageIfExists($"Images/PlayerPhotosForSubstitution/Player{batter.Id:0000}.jpg");
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