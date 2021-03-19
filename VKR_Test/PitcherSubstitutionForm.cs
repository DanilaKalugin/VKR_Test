using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class PitcherSubstitutionForm : Form
    {
        Team Defense;
        List<Pitcher> Pitchers;
        public Pitcher newPitcherForThisTeam;
        private readonly PlayerBL playerBL;

        public PitcherSubstitutionForm(Team defense, List<Pitcher> pitchers)
        {
            InitializeComponent();
            Defense = defense;
            Pitchers = pitchers;
            lbTeamTitle.Text = defense.TeamTitle.ToUpper();
            lbTeamTitle.ForeColor = defense.TeamColor[0];
        }

        private void PitcherSubstitutionForm_Load(object sender, EventArgs e)
        {
            foreach (Pitcher pitcher in Pitchers)
            {
                dataGridView1.Rows.Add(Image.FromFile($"PlayerPhotos/Player{pitcher.id:0000}.jpg"), pitcher.FirstName + " " + pitcher.SecondName, $"ERA: {pitcher.ERA.ToString("0.00", new CultureInfo("en-US"))}", $"SO: {pitcher.Strikeouts}");
            }
            dataGridView1.DefaultCellStyle.SelectionBackColor = Defense.TeamColor[0];
        }

        public PitcherSubstitutionForm()
        {
            InitializeComponent();
            playerBL = new PlayerBL();
            Pitchers = playerBL.GetPitchersStats();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            newPitcherForThisTeam = Pitchers[dataGridView1.SelectedRows[0].Index];
            DialogResult = DialogResult.OK;
        }
    }
}
