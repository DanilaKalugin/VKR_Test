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
        private Team CurrentTeam;
        List<Batter> Batters;
        public Batter newBatterForThisTeam;

        private void PitcherSubstitutionForm_Load(object sender, EventArgs e)
        {
            dgvAvailablePlayers.DefaultCellStyle.SelectionBackColor = CurrentTeam.TeamColorForThisMatch;
            dgvAvailablePlayers.DefaultCellStyle.SelectionForeColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(CurrentTeam.TeamColorForThisMatch, false);
            panelTeamLogo.BackgroundImage = Image.FromFile($"TeamLogosForSubstitution/{CurrentTeam.TeamAbbreviation}.png");
        }

        public SubstitutionForm(Team offense, List<Batter> batters)
        {
            InitializeComponent();
            CurrentTeam = offense;
            Batters = batters;
            lbTeamTitle.Text = offense.TeamTitle.ToUpper();
            lbTeamTitle.ForeColor = offense.TeamColorForThisMatch;
            Text = $"New batter for {offense.TeamTitle}";
            lbHeader.Text = "PINCH HITTER";
            dgvAvailablePlayers.Columns[2].HeaderText = "AVG";
            dgvAvailablePlayers.Columns[3].HeaderText = "HR";
            for (int i = 0; i < Batters.Count; i++)
            {
                if (File.Exists($"PlayerPhotosForSubstitution/Player{Batters[i].id:0000}.jpg"))
                {
                    dgvAvailablePlayers.Rows.Add(Image.FromFile($"PlayerPhotosForSubstitution/Player{Batters[i].id:0000}.jpg"), Batters[i].FullName, $"{Batters[i].AVG.ToString("#.000", new CultureInfo("en-US"))}", $"{Batters[i].HomeRuns}");
                }
                else
                {
                    dgvAvailablePlayers.Rows.Add(null, Batters[i].FullName, $"{Batters[i].AVG.ToString("#.000", new CultureInfo("en-US"))}", $"{Batters[i].HomeRuns}");
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            newBatterForThisTeam = Batters[dgvAvailablePlayers.SelectedRows[0].Index];
            DialogResult = DialogResult.OK;
        }
    }
}