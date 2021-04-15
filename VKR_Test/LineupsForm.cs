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
        string[] Lineups = { "RH W/ DH", "RH NO DH", "LH W/ DH", "LH NO DH", "ROTATION" };
        bool LineupChanged;

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
        }

        private void btnDecreaseTeamNumberBy1_Click(object sender, EventArgs e)
        {
            TeamNumber = TeamNumber > 0 ? TeamNumber - 1 : teams.Count - 1;
            DisplayRoster(TeamNumber, LineupNumber);
        }

        private void DisplayRoster(int TeamNumber, int LineupNumber)
        {
            dataGridView1.Rows.Clear();
            panelTeamLogo.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{teams[TeamNumber].TeamAbbreviation}.png");
            foreach (PlayerInLineup player in lineups[TeamNumber][LineupNumber])
            {
                dataGridView1.Rows.Add(player.NumberInLineup, player.Position, $"{player.FirstName[0]}. {player.SecondName}");
            }
            label7.Text = teams[TeamNumber].TeamTitle.ToUpper();
            label7.BackColor = teams[TeamNumber].TeamColor[0];
            label7.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = teams[TeamNumber].TeamColor[0];
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
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
            LineupChanged = true;
        }

        private void btnIncLineupTypeNumberBy1_Click(object sender, EventArgs e)
        {
            LineupNumber = LineupNumber < lineups[TeamNumber].Count - 1 ? LineupNumber + 1 : 0;
            DisplayRoster(TeamNumber, LineupNumber);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LineupNumber = LineupNumber > 0 ? LineupNumber - 1 : lineups[TeamNumber].Count - 1;
            DisplayRoster(TeamNumber, LineupNumber);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ShowNewPlayer(dataGridView1, dataGridView2, lineups[TeamNumber][LineupNumber][dataGridView1.SelectedRows[0].Index]);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowNewPlayer(dataGridView1, dataGridView2, lineups[TeamNumber][LineupNumber][dataGridView1.SelectedRows[0].Index]);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LineupChanged = false;
            ShowNewPlayer(dataGridView2, dataGridView1, bench[TeamNumber][LineupNumber][dataGridView2.SelectedRows[0].Index]);
        }

        private void ShowNewPlayer(DataGridView dgv1, DataGridView dgv2, PlayerInLineup player)
        {
            dgv2.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dgv1.DefaultCellStyle.SelectionBackColor = teams[TeamNumber].TeamColor[0];
            dgv1.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv2.DefaultCellStyle.SelectionForeColor = Color.Black;
            if (dgv1.SelectedRows.Count > 0)
            {
                panel10.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{player.id:0000}.jpg");
                label2.Text = $"#{player.PlayerNumber}";
                label3.Text = player.FullName.ToUpper();
                label4.Text = player.PlaceOfBirth.ToUpper();
                label5.Text = player.DateOfBirth.ToShortDateString().ToUpper();
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView2.SelectedRows.Count > 0 && !LineupChanged)
            {
                ShowNewPlayer(dataGridView2, dataGridView1, bench[TeamNumber][LineupNumber][dataGridView2.SelectedRows[0].Index]);
            }
        }
    }
}