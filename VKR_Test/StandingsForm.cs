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
    public partial class StandingsForm : Form
    {
        private readonly TeamsBL teamsBl;
        public StandingsForm()
        {
            InitializeComponent();
            teamsBl = new TeamsBL();
            comboBox1.Text = "MLB";
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<Team> teams = teamsBl.GetStandings(comboBox1.Text);
            for (int i = 0; i < teams.Count; i++)
            {
                dataGridView1.Rows.Add("", teams[i].TeamTitle, teams[i].Wins, teams[i].Losses, teams[i].GamesBehind.ToString("0.0", new CultureInfo("en-US")), teams[i].PCT.ToString("#.000", new CultureInfo("en-US")));
                dataGridView1.Rows[i].Cells[0].Style.BackColor = teams[i].TeamColor[0];
                dataGridView1.Rows[i].Cells[0].Style.SelectionBackColor = teams[i].TeamColor[0];
            }

            Height = 96 + 26 + 22 * teams.Count;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<Team> teams = teamsBl.GetStandings(comboBox1.Text);
            for (int i = 0; i < teams.Count; i++)
            {
                dataGridView1.Rows.Add("", teams[i].TeamTitle, teams[i].Wins, teams[i].Losses, teams[i].GamesBehind.ToString("0.0", new CultureInfo("en-US")), teams[i].PCT.ToString("#.000", new CultureInfo("en-US")));
                dataGridView1.Rows[i].Cells[0].Style.BackColor = teams[i].TeamColor[0];
                dataGridView1.Rows[i].Cells[0].Style.SelectionBackColor = teams[i].TeamColor[0];
            }

            Height = 96 + 26 + 22 * teams.Count;
        }
    }
}
