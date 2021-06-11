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
            TeamChanged(TeamNumber);
        }

        private void btnIncreaseTeamNumberBy1_Click(object sender, EventArgs e)
        {
            TeamNumber = TeamNumber < teams.Count - 1 ? TeamNumber + 1 : 0;
            TeamChanged(TeamNumber);
        }

        private void btnDecreaseTeamNumberBy1_Click(object sender, EventArgs e)
        {
            TeamNumber = TeamNumber > 0 ? TeamNumber - 1 : teams.Count - 1;
            TeamChanged(TeamNumber);
        }

        private void TeamChanged(int TeamNumber)
        {
            panelTeamLogo.BackgroundImage = Image.FromFile($"TeamLogoForMenu/{teams[TeamNumber].TeamAbbreviation}.png");
            lbTeamtitle.Text = teams[TeamNumber].TeamTitle.ToUpper();
            lbTeamtitle.BackColor = teams[TeamNumber].TeamColor[0];
            lbTeamtitle.ForeColor = Color.White;
            dgvLineup.DefaultCellStyle.SelectionBackColor = teams[TeamNumber].TeamColor[0];
            dgvLineup.DefaultCellStyle.SelectionForeColor = Color.White;

            btnIncreaseTeamNumberBy1.ForeColor = teams[TeamNumber].TeamColor[0];
            btnDecreaseTeamNumberBy1.ForeColor = teams[TeamNumber].TeamColor[0];

            btnIncLineupTypeNumberBy1.ForeColor = teams[TeamNumber].TeamColor[0];
            btnDecLineupTypeNumberBy1.ForeColor = teams[TeamNumber].TeamColor[0];
            lbLineUpType.ForeColor = teams[TeamNumber].TeamColor[0];
            lbPlayerName.ForeColor = teams[TeamNumber].TeamColor[0];
            lbPlayerNumber.ForeColor = Color.FromArgb((int)(teams[TeamNumber].TeamColor[0].R * 0.7), (int)(teams[TeamNumber].TeamColor[0].G * 0.7), (int)(teams[TeamNumber].TeamColor[0].B * 0.7));
            label6.ForeColor = Color.FromArgb((int)(teams[TeamNumber].TeamColor[0].R * 0.65), (int)(teams[TeamNumber].TeamColor[0].G * 0.65), (int)(teams[TeamNumber].TeamColor[0].B * 0.65));

            lbl_LineupHeader.ForeColor = teams[TeamNumber].TeamColor[0];
            DisplayRoster(TeamNumber, LineupNumber);
        }

        private void DisplayRoster(int TeamNumber, int LineupNumber)
        {
            dgvLineup.Rows.Clear();
            foreach (PlayerInLineup player in lineups[TeamNumber][LineupNumber])
            {
                dgvLineup.Rows.Add(player.NumberInLineup, player.Position, $"{player.FirstName[0]}. {player.SecondName}");
            }
            lbLineUpType.Text = Lineups[LineupNumber];
            dgvBench.Rows.Clear();
            foreach (PlayerInLineup player in bench[TeamNumber][LineupNumber])
            {
                dgvBench.Rows.Add($"{player.FirstName[0]}. {player.SecondName}");
            }
            LineupChanged = true;

            label6.Text = LineupNumber != 4 ? "BENCH" : "BULLPEN";
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
            if (dgvLineup.SelectedRows.Count > 0)
            {
                ShowNewPlayer(dgvLineup, dgvBench, lineups[TeamNumber][LineupNumber][dgvLineup.SelectedRows[0].Index]);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowNewPlayer(dgvLineup, dgvBench, lineups[TeamNumber][LineupNumber][dgvLineup.SelectedRows[0].Index]);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LineupChanged = false;
            ShowNewPlayer(dgvBench, dgvLineup, bench[TeamNumber][LineupNumber][dgvBench.SelectedRows[0].Index]);
        }

        private void ShowNewPlayer(DataGridView dgv1, DataGridView dgv2, PlayerInLineup player)
        {
            dgv2.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dgv2.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgv2.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv2.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;

            dgv1.DefaultCellStyle.SelectionBackColor = teams[TeamNumber].TeamColor[0];
            dgv1.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv1.AlternatingRowsDefaultCellStyle.SelectionBackColor = teams[TeamNumber].TeamColor[0];
            dgv1.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;

            if (dgv1.SelectedRows.Count > 0)
            {
                pbPlayerPhoto.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{player.id:0000}.png");
                lbPlayerNumber.Text = $"#{player.PlayerNumber}";
                lbPlayerName.Text = player.FullName.ToUpper();
                lbPlayerPlace_and_DateOfBirth.Text = $"{player.PlaceOfBirth.ToUpper()} / {player.DateOfBirth.ToShortDateString().ToUpper()}";
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBench.SelectedRows.Count > 0 && !LineupChanged)
            {
                ShowNewPlayer(dgvBench, dgvLineup, bench[TeamNumber][LineupNumber][dgvBench.SelectedRows[0].Index]);
            }
        }
    }
}