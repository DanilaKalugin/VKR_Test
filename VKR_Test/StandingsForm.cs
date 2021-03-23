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
            comboBox1.Text = "MLB";
        }

        public StandingsForm(Team Home, Team Away)
        {
            InitializeComponent();
            teamsBl = new TeamsBL();
            comboBox1.Text = "MLB";
            int HomeNumber = teams.FindIndex(team => team.TeamTitle == Home.TeamTitle);
            dataGridView1.Rows[HomeNumber].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.Rows[HomeNumber].DefaultCellStyle.ForeColor = Color.Black;
            int AwayNumber = teams.FindIndex(team => team.TeamTitle == Away.TeamTitle);
            dataGridView1.Rows[AwayNumber].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.Rows[AwayNumber].DefaultCellStyle.ForeColor = Color.Black;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].DefaultCellStyle.SelectionBackColor = dataGridView1.Rows[i].DefaultCellStyle.BackColor;
                dataGridView1.Rows[i].DefaultCellStyle.SelectionForeColor = dataGridView1.Rows[i].DefaultCellStyle.ForeColor;
            }
            comboBox1.Visible = false;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        GetStandingsForThisGroup("MLB", 30, 0);
                        break;
                    }
                case 1:
                    {
                        GetStandingsForThisGroup("AL", 15, 0);
                        GetStandingsForThisGroup("NL", 15, 1);
                        break;
                    }
                case 2:
                    {
                        GetStandingsForThisGroup("AL East", 5, 0);
                        GetStandingsForThisGroup("AL Central", 5, 1);
                        GetStandingsForThisGroup("AL West", 5, 2);
                        GetStandingsForThisGroup("NL East", 5, 3);
                        GetStandingsForThisGroup("NL Central", 5, 4);
                        GetStandingsForThisGroup("NL West", 5, 5);
                        break;
                    }
            }
            Height = 97 + dataGridView1.RowTemplate.Height * dataGridView1.RowCount;
        }

        private void GetStandingsForThisGroup(string group, int TeamsInGroup, int GroupNumber)
        {
            teams = teamsBl.GetStandings(group, dateTimePicker1.Value);
            dataGridView1.Rows.Add("", group, "W", "L", "GB", "PCT", "RS", "RA", "DIFF");
            dataGridView1.Rows[(TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dataGridView1.Rows[(TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);

            dataGridView1.Rows[(TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dataGridView1.Rows[(TeamsInGroup + 1) * GroupNumber].DefaultCellStyle.SelectionForeColor = Color.White;

            for (int i = 0; i < teams.Count; i++)
            {
                dataGridView1.Rows.Add("", teams[i].TeamTitle, teams[i].Wins, teams[i].Losses, teams[i].GamesBehind.ToString("0.0", new CultureInfo("en-US")), teams[i].PCT.ToString("#.000", new CultureInfo("en-US")), teams[i].RunsScored, teams[i].RunsAllowed, teams[i].RunDifferential);
                dataGridView1.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].Cells[0].Style.BackColor = teams[i].TeamColor[0];
                dataGridView1.Rows[i + 1 + (TeamsInGroup + 1) * GroupNumber].Cells[0].Style.SelectionBackColor = teams[i].TeamColor[0];
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        GetStandingsForThisGroup("MLB", 30, 0);
                        break;
                    }
                case 1:
                    {
                        GetStandingsForThisGroup("AL", 15, 0);
                        GetStandingsForThisGroup("NL", 15, 1);
                        break;
                    }
                case 2:
                    {
                        GetStandingsForThisGroup("AL East", 5, 0);
                        GetStandingsForThisGroup("AL Central", 5, 1);
                        GetStandingsForThisGroup("AL West", 5, 2);
                        GetStandingsForThisGroup("NL East", 5, 3);
                        GetStandingsForThisGroup("NL Central", 5, 4);
                        GetStandingsForThisGroup("NL West", 5, 5);
                        break;
                    }
            }
            Height = 97 + dataGridView1.RowTemplate.Height * dataGridView1.RowCount;
        }
    }
}