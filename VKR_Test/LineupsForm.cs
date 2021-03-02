using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class LineupsForm : Form
    {
        private readonly PlayerBL players;
        private readonly TeamsBL teamsBL;
        List<List<List<PlayerInLineup>>> lineups;
        List<List<List<PlayerInLineup>>> bench;
        List<Team> teams;
        int TeamNumber;
        int LineupNumber;
        bool LineupChanged;
        string[] Lineups = { "RH W/ DH", "RH NO DH", "LH W/ DH", "LH NO DH", "ROTATION" };

        public LineupsForm()
        {
            InitializeComponent();

            players = new PlayerBL();
            teamsBL = new TeamsBL();
            teams = teamsBL.GetAllTeams();
            lineups = players.GetLineups();
            bench = players.GetBench();
            DisplayRoster(TeamNumber, LineupNumber);
        }

        private void btnIncreaseTeamNumberBy1_Click(object sender, EventArgs e)
        {
            TeamNumber = TeamNumber < teams.Count - 1 ? TeamNumber + 1 : 0;
            DisplayRoster(TeamNumber, LineupNumber);
            LineupChanged = true;
        }

        private void btnDecreaseTeamNumberBy1_Click(object sender, EventArgs e)
        {
            TeamNumber = TeamNumber > 0 ? TeamNumber - 1 : teams.Count - 1;
            DisplayRoster(TeamNumber, LineupNumber);
            LineupChanged = true;
        }

        private void DisplayRoster(int TeamNumber, int LineupNumber)
        {
            dataGridView1.Rows.Clear();
            foreach (PlayerInLineup player in lineups[TeamNumber][LineupNumber])
            {
                dataGridView1.Rows.Add(player.NumberInLineup, player.Position, $"{player.FirstName[0]}. {player.SecondName}");
            }
            label7.Text = teams[TeamNumber].TeamTitle.ToUpper();
            label7.BackColor = teams[TeamNumber].TeamColor[0];
            label7.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = teams[TeamNumber].TeamColor[0];
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView2.DefaultCellStyle.SelectionBackColor = teams[TeamNumber].TeamColor[0];
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.White;
            label1.Text = Lineups[LineupNumber];

            btnIncreaseTeamNumberBy1.ForeColor = teams[TeamNumber].TeamColor[0];
            btnDecreaseTeamNumberBy1.ForeColor = teams[TeamNumber].TeamColor[0];

            btnIncLineupTypeNumberBy1.ForeColor = teams[TeamNumber].TeamColor[0];
            btnDecLineupTypeNumberBy1.ForeColor = teams[TeamNumber].TeamColor[0];
            label1.ForeColor = teams[TeamNumber].TeamColor[0];
            lbl_LineupHeader.ForeColor = teams[TeamNumber].TeamColor[0];

            dataGridView2.Rows.Clear();
            foreach (PlayerInLineup player in bench[TeamNumber][LineupNumber])
            {
                dataGridView2.Rows.Add($"{player.FirstName[0]}. {player.SecondName}");
            }
        }

        private void btnIncLineupTypeNumberBy1_Click(object sender, EventArgs e)
        {
            LineupNumber = LineupNumber < lineups[TeamNumber].Count - 1 ? LineupNumber + 1 : 0;
            DisplayRoster(TeamNumber, LineupNumber);
            LineupChanged = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LineupNumber = LineupNumber > 0 ? LineupNumber - 1 : lineups[TeamNumber].Count - 1;
            DisplayRoster(TeamNumber, LineupNumber);
            LineupChanged = true;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                panel10.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{lineups[TeamNumber][LineupNumber][dataGridView1.SelectedRows[0].Index].id:0000}.jpg");
                label2.Text = $"#{lineups[TeamNumber][LineupNumber][dataGridView1.SelectedRows[0].Index].PlayerNumber}";
                label3.Text = $"{lineups[TeamNumber][LineupNumber][dataGridView1.SelectedRows[0].Index].FirstName} {lineups[TeamNumber][LineupNumber][dataGridView1.SelectedRows[0].Index].SecondName}".ToUpper();
                label4.Text = $"{lineups[TeamNumber][LineupNumber][dataGridView1.SelectedRows[0].Index].PlaceOfBirth}".ToUpper();
                label5.Text = $"{lineups[TeamNumber][LineupNumber][dataGridView1.SelectedRows[0].Index].DateOfBirth.ToShortDateString()}".ToUpper();
                LineupChanged = false;
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0 && ! LineupChanged)
            {
                panel10.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{bench[TeamNumber][LineupNumber][dataGridView2.SelectedRows[0].Index].id:0000}.jpg");
                label2.Text = $"#{bench[TeamNumber][LineupNumber][dataGridView2.SelectedRows[0].Index].PlayerNumber}";
                label3.Text = $"{bench[TeamNumber][LineupNumber][dataGridView2.SelectedRows[0].Index].FirstName} {bench[TeamNumber][LineupNumber][dataGridView2.SelectedRows[0].Index].SecondName}".ToUpper();
                label4.Text = $"{bench[TeamNumber][LineupNumber][dataGridView2.SelectedRows[0].Index].PlaceOfBirth}".ToUpper();
                label5.Text = $"{bench[TeamNumber][LineupNumber][dataGridView2.SelectedRows[0].Index].DateOfBirth.ToShortDateString()}".ToUpper();
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            LineupChanged = true;
        }
    }
}