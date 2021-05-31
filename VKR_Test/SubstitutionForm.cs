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
                dataGridView1.Rows.Add(Image.FromFile($"PlayerPhotos/Player{pitcher.id:0000}.png"), pitcher.FullName, $"ERA: {pitcher.ERA.ToString("0.00", new CultureInfo("en-US"))}", $"SO: {pitcher.Strikeouts}");
            }
        }

        private void PitcherSubstitutionForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.SelectionBackColor = CurrentTeam.TeamColorForThisMatch;
            dataGridView1.DefaultCellStyle.SelectionForeColor = CorrectForeColorForAllBackColors.GetForeColorForThisSituation(CurrentTeam.TeamColorForThisMatch, false);
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
                dataGridView1.Rows.Add(Image.FromFile($"PlayerPhotos/Player{Batters[i].id:0000}.png"), Batters[i].FullName, $"AVG: {Batters[i].AVG.ToString("#.000", new CultureInfo("en-US"))}", $"HR: {Batters[i].HomeRuns}");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Pitchers == null)
            {
                newBatterForThisTeam = Batters[dataGridView1.SelectedRows[0].Index];
            }
            else
            {
                newPitcherForThisTeam = Pitchers[dataGridView1.SelectedRows[0].Index];
            }
            DialogResult = DialogResult.OK;
        }
    }
}