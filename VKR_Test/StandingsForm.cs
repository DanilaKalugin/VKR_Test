using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class StandingsForm : Form
    {
        private readonly TeamsBL teamsBl;
        List<Team> teams;
        public StandingsForm()
        {
            InitializeComponent();
            teamsBl = new TeamsBL();
            teams = teamsBl.GetStandings("MLB");
            comboBox1.Text = "MLB";
        }

        public StandingsForm(Team Home, Team Away)
        {
            InitializeComponent();
            teamsBl = new TeamsBL();
            teams = teamsBl.GetStandings("MLB");
            comboBox1.Text = "MLB";
            int HomeNumber = teams.FindIndex(team => team.TeamTitle == Home.TeamTitle);
            dataGridView1.Rows[HomeNumber].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.Rows[HomeNumber].DefaultCellStyle.ForeColor = Color.Black;
            int AwayNumber = teams.FindIndex(team => team.TeamTitle == Away.TeamTitle);
            dataGridView1.Rows[AwayNumber].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.Rows[AwayNumber].DefaultCellStyle.ForeColor = Color.Black;
            comboBox1.Visible = false;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            teams = teamsBl.GetStandings(comboBox1.Text);
            dataGridView1.Rows.Clear();
            
            for (int i = 0; i < teams.Count; i++)
            {
                dataGridView1.Rows.Add("", teams[i].TeamTitle, teams[i].Wins, teams[i].Losses, teams[i].GamesBehind.ToString("0.0", new CultureInfo("en-US")), teams[i].PCT.ToString("#.000", new CultureInfo("en-US")), teams[i].RunsScored, teams[i].RunsAllowed, teams[i].RunDifferential);
                dataGridView1.Rows[i].Cells[0].Style.BackColor = teams[i].TeamColor[0];
                dataGridView1.Rows[i].Cells[0].Style.SelectionBackColor = teams[i].TeamColor[0];
            }
            Height = 96 + 26 + 22 * teams.Count;
        }
    }
}