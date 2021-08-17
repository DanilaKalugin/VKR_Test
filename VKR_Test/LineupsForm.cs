using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
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
        public enum RosterType { StartingLineups, Reserves, FreeAgents };
        private RosterType rosterType;


        public LineupsForm(RosterType _rosterType)
        {
            InitializeComponent();

            players = new PlayerBL();
            teamsBL = new TeamsBL();
            rosterType = _rosterType;
            teams = teamsBL.GetAllTeams();
            switch (rosterType)
            {
                case RosterType.StartingLineups:
                    {
                        lineups = players.GetRoster("GetStartingLineups");
                        bench = players.GetRoster("GetBench");
                        break;
                    }
                case RosterType.Reserves:
                    {
                        lineups = players.GetRoster("GetActivePlayers");
                        bench = players.GetRoster("GetReserves");
                        break;
                    }
                case RosterType.FreeAgents:
                    {
                        lineups = players.GetRoster("GetReserves");
                        bench = players.GetFreeAgents();
                        break;
                    }
            }
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

            label4.ForeColor = teams[TeamNumber].TeamColor[0];
            label5.ForeColor = teams[TeamNumber].TeamColor[0];
            label6.ForeColor = teams[TeamNumber].TeamColor[0];
            btnIncreaseTeamNumberBy1.ForeColor = teams[TeamNumber].TeamColor[0];
            btnDecreaseTeamNumberBy1.ForeColor = teams[TeamNumber].TeamColor[0];
            btnIncLineupTypeNumberBy1.ForeColor = teams[TeamNumber].TeamColor[0];
            btnDecLineupTypeNumberBy1.ForeColor = teams[TeamNumber].TeamColor[0];
            lbLineUpType.ForeColor = teams[TeamNumber].TeamColor[0];
            lbPlayerName.ForeColor = teams[TeamNumber].TeamColor[0];


            lbPlayerNumber.ForeColor = Color.FromArgb((int)(teams[TeamNumber].TeamColor[0].R * 0.7), (int)(teams[TeamNumber].TeamColor[0].G * 0.7), (int)(teams[TeamNumber].TeamColor[0].B * 0.7));
            dgvBench.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb((int)(teams[TeamNumber].TeamColor[0].R * 0.65), (int)(teams[TeamNumber].TeamColor[0].G * 0.65), (int)(teams[TeamNumber].TeamColor[0].B * 0.65));

            lbl_LineupHeader.ForeColor = teams[TeamNumber].TeamColor[0];
            DisplayRoster(TeamNumber, LineupNumber);
        }

        private void DisplayRoster(int TeamNumber, int LineupNumber)
        {
            dgvLineup.Rows.Clear();
            switch (rosterType)
            {
                case RosterType.StartingLineups:
                    {
                        foreach (PlayerInLineup player in lineups[TeamNumber][LineupNumber])
                        {
                            dgvLineup.Rows.Add(player.NumberInLineup, player.Position, $"{player.FirstName[0]}. {player.SecondName}");
                        }
                        dgvBench.Columns[0].HeaderText = LineupNumber != 4 ? "BENCH" : "BULLPEN";
                        break;
                    }
                case RosterType.Reserves:
                    {
                        foreach (PlayerInLineup player in lineups[TeamNumber][LineupNumber])
                        {
                            dgvLineup.Rows.Add(player.NumberInLineup, player.PlayerPositions[0], $"{player.FirstName[0]}. {player.SecondName}");
                        }
                        dgvBench.Columns[0].HeaderText = "RESERVE";
                        dgvLineup.Columns[0].Visible = false;
                        break;
                    }
                case RosterType.FreeAgents:
                    {
                        foreach (PlayerInLineup player in lineups[TeamNumber][LineupNumber])
                        {
                            dgvLineup.Rows.Add(player.NumberInLineup, player.PlayerPositions[0], $"{player.FirstName[0]}. {player.SecondName}");
                        }
                        dgvBench.Columns[0].HeaderText = "FREE AGENTS";
                        dgvLineup.Columns[0].Visible = false;
                        break;
                    }
            }
            lbLineUpType.Text = Lineups[LineupNumber];
            dgvBench.Rows.Clear();
            if (rosterType == RosterType.FreeAgents)
            {
                foreach (PlayerInLineup player in bench[0][0])
                {
                    dgvBench.Rows.Add($"{player.FirstName[0]}. {player.SecondName}");
                }
            }
            else
            {
                foreach (PlayerInLineup player in bench[TeamNumber][LineupNumber])
                {
                    dgvBench.Rows.Add($"{player.FirstName[0]}. {player.SecondName}");
                }
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
            if (rosterType == RosterType.FreeAgents)
            {
                ShowNewPlayer(dgvBench, dgvLineup, bench[0][0][dgvBench.SelectedRows[0].Index]);
            }
            else
            {
                ShowNewPlayer(dgvBench, dgvLineup, bench[TeamNumber][LineupNumber][dgvBench.SelectedRows[0].Index]);
            }
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

            if (player.PlayerPositions.IndexOf("P") == -1)
            {
                label4.Text = "AVG";
                label5.Text = "HR";
                label6.Text = "RBI";
                Batter batter = players.GetBatterByCode(player.id);
                label1.Text = batter.AVG.ToString("#.000", new CultureInfo("en-US"));
                label2.Text = batter.HomeRuns.ToString();
                label3.Text = batter.RBI.ToString();
            }
            else
            {
                label4.Text = "ERA";
                label5.Text = "SO";
                label6.Text = "WHIP";
                Pitcher pitcher = players.GetPitcherByCode(player.id);
                label1.Text = pitcher.ERA.ToString("0.00", new CultureInfo("en-US"));
                label2.Text = pitcher.Strikeouts.ToString();
                label3.Text = pitcher.WHIP.ToString("0.00", new CultureInfo("en-US"));
            }
            label7.Text = $"Positions: {string.Join(", ", player.PlayerPositions)}";

            if (dgv1.SelectedRows.Count > 0)
            {
                if (File.Exists($"PlayerPhotos/Player{player.id:0000}.png"))
                {
                    pbPlayerPhoto.BackgroundImage = Image.FromFile($"PlayerPhotos/Player{player.id:0000}.png");
                }
                else
                {
                    pbPlayerPhoto.BackgroundImage = null;
                }
                lbPlayerNumber.Text = $"#{player.PlayerNumber}";
                lbPlayerName.Text = player.FullName.ToUpper();
                lbPlayerPlace_and_DateOfBirth.Text = $"{player.PlaceOfBirth.ToUpper()} / {player.DateOfBirth.ToShortDateString().ToUpper()}";
                playerHands.Text = $"B/T: {player.BattingHand[0]}/{player.Pitchinghand[0]}".ToUpper();
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBench.SelectedRows.Count > 0 && !LineupChanged)
            {
                if (rosterType == RosterType.FreeAgents)
                {
                    ShowNewPlayer(dgvBench, dgvLineup, bench[0][0][dgvBench.SelectedRows[0].Index]);
                }
                else
                {
                    ShowNewPlayer(dgvBench, dgvLineup, bench[TeamNumber][LineupNumber][dgvBench.SelectedRows[0].Index]);
                }
            }
        }

        private void LineupsForm_Load(object sender, EventArgs e)
        {
            lbl_LineupHeader.Visible = rosterType == RosterType.StartingLineups;
            btnDecLineupTypeNumberBy1.Visible = rosterType == RosterType.StartingLineups;
            btnIncLineupTypeNumberBy1.Visible = rosterType == RosterType.StartingLineups;
            lbLineUpType.Visible = rosterType == RosterType.StartingLineups;
        }
    }
}