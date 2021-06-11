using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class SubstitutionForm : Form
    {
        private Team CurrentTeam;
        List<Pitcher> Pitchers;
        List<Batter> Batters;
        public Pitcher newPitcherForThisTeam;
        public Batter newBatterForThisTeam;

        public SubstitutionForm(Team defense, List<Pitcher> pitchers)
        {
            InitializeComponent();
            CurrentTeam = defense;
            Pitchers = pitchers;
            lbTeamTitle.Text = defense.TeamTitle.ToUpper();
            lbTeamTitle.ForeColor = defense.TeamColorForThisMatch;
            Text = $"New pitcher for {defense.TeamTitle}";
            foreach (Pitcher pitcher in Pitchers)
            {
                dgvAvailablePlayers.Rows.Add(Image.FromFile($"PlayerPhotosForSubstitution/Player{pitcher.id:0000}.jpg"), pitcher.FullName, $"ERA: {pitcher.ERA.ToString("0.00", new CultureInfo("en-US"))}", $"SO: {pitcher.Strikeouts}");
            }
        }

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
            for (int i = 0; i < Batters.Count; i++)
            {
                dgvAvailablePlayers.Rows.Add(Image.FromFile($"PlayerPhotosForSubstitution/Player{Batters[i].id:0000}.jpg"), Batters[i].FullName, $"AVG: {Batters[i].AVG.ToString("#.000", new CultureInfo("en-US"))}", $"HR: {Batters[i].HomeRuns}");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Pitchers == null)
            {
                newBatterForThisTeam = Batters[dgvAvailablePlayers.SelectedRows[0].Index];
            }
            else
            {
                newPitcherForThisTeam = Pitchers[dgvAvailablePlayers.SelectedRows[0].Index];
            }
            DialogResult = DialogResult.OK;
        }
    }
}