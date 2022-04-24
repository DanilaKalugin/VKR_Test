using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class PlayerStatsForm : Form
    {
        private enum SortMode { Ascending, Descending };
        private enum PlayerType { Pitchers, Batters };
        private enum StatsType { Standard, Expanded };
        public enum SortingObjects { Players, Teams };

        private readonly PlayerBL _playersBL;
        private readonly TeamsBL _teamsBL;
        private List<Team> _teams;
        private List<Player> _batters;
        private List<Player> _pitchers;
        private List<Team> _teamBattingStats;
        private List<Team> _teamPitchingStats;
        private SortMode[][] _sortModes;
        private PlayerType _playerType;
        private StatsType _statsType;
        private SortingObjects _objects;
        private int _lastBattingSort = 11;
        private int _lastPitchingSort = 2;

        public PlayerStatsForm(SortingObjects sortingObject)
        {
            InitializeComponent();

            _playersBL = new PlayerBL();
            _teamsBL = new TeamsBL();
            _teams = _teamsBL.GetAllTeams().ToList();
            _objects = sortingObject;
            _sortModes = new SortMode[2][];
            _sortModes[0] = new SortMode[dataGridView1.ColumnCount - 3 + dataGridView2.ColumnCount - 3];
            _sortModes[1] = new SortMode[dataGridView3.ColumnCount - 3 + dataGridView4.ColumnCount - 3];
            _sortModes[0][11] = SortMode.Descending;
        }

        private void ShowNewStats(PlayerType playerType, StatsType statsType)
        {
            panelStandardBatterStats.Visible = playerType == PlayerType.Batters && statsType == StatsType.Standard;
            panelExpandedBatterStats.Visible = playerType == PlayerType.Batters && statsType == StatsType.Expanded;
            panelStandardPitcherStats.Visible = playerType == PlayerType.Pitchers && statsType == StatsType.Standard;
            panelExpandedPitcherStats.Visible = playerType == PlayerType.Pitchers && statsType == StatsType.Expanded;

            btnExpandedStats.BackColor = statsType == StatsType.Expanded ? Color.LightGray : Color.DarkGray;
            btnStandardStats.BackColor = statsType == StatsType.Standard ? Color.LightGray : Color.DarkGray;
            btnHitting.BackColor = playerType == PlayerType.Batters ? Color.LightGray : Color.DarkGray;
            btnPitching.BackColor = playerType == PlayerType.Pitchers ? Color.LightGray : Color.DarkGray;
            cbPositions.Visible = playerType == PlayerType.Batters && _objects == SortingObjects.Players;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                _sortModes[0][e.ColumnIndex - 3] = (_sortModes[0][e.ColumnIndex - 3] == SortMode.Descending && _lastBattingSort == e.ColumnIndex - 3) ? SortMode.Ascending : SortMode.Descending;
                _lastBattingSort = e.ColumnIndex - 3;
            }
            GetSortedListsBySortingCodes(_lastBattingSort, _lastPitchingSort, _objects);
        }

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                if (e.ColumnIndex == 8 || e.ColumnIndex == 12 || e.ColumnIndex == 15)
                {
                    _sortModes[0][dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3] = (_sortModes[0][dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3] == SortMode.Ascending && _lastBattingSort == dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3) ? SortMode.Descending : SortMode.Ascending;
                }
                else
                {
                    _sortModes[0][dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3] = (_sortModes[0][dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3] == SortMode.Descending && _lastBattingSort == dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3) ? SortMode.Ascending : SortMode.Descending;
                }
                _lastBattingSort = dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3;
            }
            GetSortedListsBySortingCodes(_lastBattingSort, _lastPitchingSort, _objects);
        }

        private void GetSortedListsBySortingCodes(int batting, int pitching, SortingObjects obj)
        {
            if (obj == SortingObjects.Players)
            {
                switch (batting)
                {
                    case 0:
                        {
                            if (_sortModes[0][0] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.Games);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.Games);
                            }
                            break;
                        }
                    case 1:
                        {
                            if (_sortModes[0][1] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.AtBats);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.AtBats);
                            }
                            break;
                        }
                    case 2:
                        {
                            if (_sortModes[0][2] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.Runs);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.Runs);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (_sortModes[0][3] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.Hits);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.Hits);
                            }
                            break;
                        }
                    case 4:
                        {
                            if (_sortModes[0][4] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.Doubles);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.Doubles);
                            }
                            break;
                        }
                    case 5:
                        {
                            if (_sortModes[0][5] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.Triples);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.Triples);
                            }
                            break;
                        }
                    case 6:
                        {
                            if (_sortModes[0][6] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.HomeRuns);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.HomeRuns);
                            }
                            break;
                        }
                    case 7:
                        {
                            if (_sortModes[0][7] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.RBI);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.RBI);
                            }
                            break;
                        }
                    case 8:
                        {
                            if (_sortModes[0][8] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.Walks);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.Walks);
                            }
                            break;
                        }
                    case 9:
                        {
                            if (_sortModes[0][9] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.StolenBases);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.StolenBases);
                            }
                            break;
                        }
                    case 10:
                        {
                            if (_sortModes[0][10] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.CaughtStealing);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.CaughtStealing);
                            }
                            break;
                        }
                    case 11:
                        {
                            if (_sortModes[0][11] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.AVG);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.AVG);
                            }
                            break;
                        }
                    case 12:
                        {
                            if (_sortModes[0][12] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.OBP);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.OBP);
                            }
                            break;
                        }
                    case 13:
                        {
                            if (_sortModes[0][13] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.SLG);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.SLG);
                            }
                            break;
                        }
                    case 14:
                        {
                            if (_sortModes[0][14] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.OPS);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.OPS);
                            }
                            break;
                        }
                    case 15:
                        {
                            if (_sortModes[0][15] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.PA);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.PA);
                            }
                            break;
                        }
                    case 16:
                        {
                            if (_sortModes[0][16] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.HitByPitch);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.HitByPitch);
                            }
                            break;
                        }
                    case 17:
                        {
                            if (_sortModes[0][17] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.SacrificeBunts);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.SacrificeBunts);
                            }
                            break;
                        }
                    case 18:
                        {
                            if (_sortModes[0][18] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.SacrificeFlies);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.SacrificeFlies);
                            }
                            break;
                        }
                    case 19:
                        {
                            if (_sortModes[0][19] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.DoublePlay);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.DoublePlay);
                            }
                            break;
                        }
                    case 20:
                        {
                            if (_sortModes[0][20] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.GOtoAO);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.GOtoAO);
                            }
                            break;
                        }
                    case 21:
                        {
                            if (_sortModes[0][21] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.XBH);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.XBH);
                            }
                            break;
                        }
                    case 22:
                        {
                            if (_sortModes[0][22] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.TotalBases);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.TotalBases);
                            }
                            break;
                        }
                    case 23:
                        {
                            if (_sortModes[0][23] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.ISO);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.ISO);
                            }
                            break;
                        }
                    case 24:
                        {
                            if (_sortModes[0][24] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.ABperHR);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.ABperHR);
                            }
                            break;
                        }
                    case 25:
                        {
                            if (_sortModes[0][25] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.WalkToStrikeout);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.WalkToStrikeout);
                            }
                            break;
                        }
                    case 26:
                        {
                            if (_sortModes[0][26] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.WalkPercentage);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.WalkPercentage);
                            }
                            break;
                        }
                    case 27:
                        {
                            if (_sortModes[0][27] == SortMode.Descending)
                            {
                                _batters = _playersBL.GetSortedBattersStatsDesc(_batters, batter => batter.battingStats.StrikeoutPercentage);
                            }
                            else
                            {
                                _batters = _playersBL.GetSortedBattersStats(_batters, batter => batter.battingStats.StrikeoutPercentage);
                            }
                            break;
                        }
                }
                switch (pitching)
                {
                    case 0:
                        {
                            if (_sortModes[1][0] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.Wins);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.Wins);
                            }
                            break;
                        }
                    case 1:
                        {
                            if (_sortModes[1][1] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.Losses);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.Losses);
                            }
                            break;
                        }
                    case 2:
                        {
                            if (_sortModes[1][2] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.ERA);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.ERA);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (_sortModes[1][3] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.GamesPlayed);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.GamesPlayed);
                            }
                            break;
                        }
                    case 4:
                        {
                            if (_sortModes[1][3] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.GamesStarted);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.GamesStarted);
                            }
                            break;
                        }
                    case 5:
                        {
                            if (_sortModes[1][5] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.CompleteGames);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.CompleteGames);
                            }
                            break;
                        }
                    case 6:
                        {
                            if (_sortModes[1][6] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.Shutouts);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.Shutouts);
                            }
                            break;
                        }
                    case 7:
                        {
                            if (_sortModes[1][7] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.Saves);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.Saves);
                            }
                            break;
                        }
                    case 8:
                        {
                            if (_sortModes[1][8] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.IP);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.IP);
                            }
                            break;
                        }
                    case 9:
                        {
                            if (_sortModes[1][9] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.HitsAllowed);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.HitsAllowed);
                            }
                            break;
                        }
                    case 10:
                        {
                            if (_sortModes[1][10] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.RunsAllowed);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.RunsAllowed);
                            }
                            break;
                        }
                    case 11:
                        {
                            if (_sortModes[1][11] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.HomeRunsAllowed);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.HomeRunsAllowed);
                            }
                            break;
                        }
                    case 12:
                        {
                            if (_sortModes[1][12] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.HitByPitch);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.HitByPitch);
                            }
                            break;
                        }
                    case 13:
                        {
                            if (_sortModes[1][13] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.WalksAllowed);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.WalksAllowed);
                            }
                            break;
                        }
                    case 14:
                        {
                            if (_sortModes[1][14] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.Strikeouts);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.Strikeouts);
                            }
                            break;
                        }
                    case 15:
                        {
                            if (_sortModes[1][15] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.WHIP);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.WHIP);
                            }
                            break;
                        }
                    case 16:
                        {
                            if (_sortModes[1][16] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.BAA);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.BAA);
                            }
                            break;
                        }
                    case 17:
                        {
                            if (_sortModes[1][17] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.TotalBattersFaced);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.TotalBattersFaced);
                            }
                            break;
                        }
                    case 18:
                        {
                            if (_sortModes[1][18] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.QualityStarts);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.QualityStarts);
                            }
                            break;
                        }
                    case 19:
                        {
                            if (_sortModes[1][19] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.Holds);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.Holds);
                            }
                            break;
                        }
                    case 20:
                        {
                            if (_sortModes[1][20] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.DoublePlays);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.DoublePlays);
                            }
                            break;
                        }
                    case 21:
                        {
                            if (_sortModes[1][21] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.GOtoAO);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.GOtoAO);
                            }
                            break;
                        }
                    case 22:
                        {
                            if (_sortModes[1][22] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.KperNineInnings);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.KperNineInnings);
                            }
                            break;
                        }
                    case 23:
                        {
                            if (_sortModes[1][23] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.BBperNineInnings);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.BBperNineInnings);
                            }
                            break;
                        }
                    case 24:
                        {
                            if (_sortModes[1][24] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.KperBB);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.KperBB);
                            }
                            break;
                        }
                    case 25:
                        {
                            if (_sortModes[1][25] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.StolenBasesAllowed);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.StolenBasesAllowed);
                            }
                            break;
                        }
                    case 26:
                        {
                            if (_sortModes[1][26] == SortMode.Descending)
                            {
                                _pitchers = _playersBL.GetSortedPitchersStatsDesc(_pitchers, batter => batter.pitchingStats.CaughtStealing);
                            }
                            else
                            {
                                _pitchers = _playersBL.GetSortedPitchersStats(_pitchers, batter => batter.pitchingStats.CaughtStealing);
                            }
                            break;
                        }
                }
            }
            else
            {
                switch (batting)
                {
                    case 0:
                        {
                            if (_sortModes[0][0] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.TGP);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.TGP);
                            }
                            break;
                        }
                    case 1:
                        {
                            if (_sortModes[0][1] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.AtBats);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.AtBats);
                            }
                            break;
                        }
                    case 2:
                        {
                            if (_sortModes[0][2] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.Runs);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.Runs);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (_sortModes[0][3] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.Hits);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.Hits);
                            }
                            break;
                        }
                    case 4:
                        {
                            if (_sortModes[0][4] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.Doubles);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.Doubles);
                            }
                            break;
                        }
                    case 5:
                        {
                            if (_sortModes[0][5] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.Triples);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.Triples);
                            }
                            break;
                        }
                    case 6:
                        {
                            if (_sortModes[0][6] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.HomeRuns);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.HomeRuns);
                            }
                            break;
                        }
                    case 7:
                        {
                            if (_sortModes[0][7] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.RBI);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.RBI);
                            }
                            break;
                        }
                    case 8:
                        {
                            if (_sortModes[0][8] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.Walks);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.Walks);
                            }
                            break;
                        }
                    case 9:
                        {
                            if (_sortModes[0][9] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.StolenBases);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.StolenBases);
                            }
                            break;
                        }
                    case 10:
                        {
                            if (_sortModes[0][10] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.CaughtStealing);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.CaughtStealing);
                            }
                            break;
                        }
                    case 11:
                        {
                            if (_sortModes[0][11] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.AVG);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.AVG);
                            }
                            break;
                        }
                    case 12:
                        {
                            if (_sortModes[0][12] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.OBP);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.OBP);
                            }
                            break;
                        }
                    case 13:
                        {
                            if (_sortModes[0][13] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.SLG);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.SLG);
                            }
                            break;
                        }
                    case 14:
                        {
                            if (_sortModes[0][14] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.OPS);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.OPS);
                            }
                            break;
                        }
                    case 15:
                        {
                            if (_sortModes[0][15] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.PA);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.PA);
                            }
                            break;
                        }
                    case 16:
                        {
                            if (_sortModes[0][16] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.HitByPitch);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.HitByPitch);
                            }
                            break;
                        }
                    case 17:
                        {
                            if (_sortModes[0][17] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.SacrificeBunts);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.SacrificeBunts);
                            }
                            break;
                        }
                    case 18:
                        {
                            if (_sortModes[0][18] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.SacrificeFlies);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.SacrificeFlies);
                            }
                            break;
                        }
                    case 19:
                        {
                            if (_sortModes[0][19] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.DoublePlay);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.DoublePlay);
                            }
                            break;
                        }
                    case 20:
                        {
                            if (_sortModes[0][20] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.GOtoAO);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.GOtoAO);
                            }
                            break;
                        }
                    case 21:
                        {
                            if (_sortModes[0][21] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.XBH);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.XBH);
                            }
                            break;
                        }
                    case 22:
                        {
                            if (_sortModes[0][22] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.TotalBases);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.TotalBases);
                            }
                            break;
                        }
                    case 23:
                        {
                            if (_sortModes[0][23] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.ISO);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.ISO);
                            }
                            break;
                        }
                    case 24:
                        {
                            if (_sortModes[0][24] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.ABperHR);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.ABperHR);
                            }
                            break;
                        }
                    case 25:
                        {
                            if (_sortModes[0][25] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.WalkToStrikeout);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.WalkToStrikeout);
                            }
                            break;
                        }
                    case 26:
                        {
                            if (_sortModes[0][26] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.WalkPercentage);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.WalkPercentage);
                            }
                            break;
                        }
                    case 27:
                        {
                            if (_sortModes[0][27] == SortMode.Descending)
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStatsDesc(_teamBattingStats, team => team.battingStats.StrikeoutPercentage);
                            }
                            else
                            {
                                _teamBattingStats = _teamsBL.GetSortedTeamStats(_teamBattingStats, team => team.battingStats.StrikeoutPercentage);
                            }
                            break;
                        }
                }
                switch (pitching)
                {
                    case 0:
                        {
                            if (_sortModes[1][0] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.Wins);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.Wins);
                            }
                            break;
                        }
                    case 1:
                        {
                            if (_sortModes[1][1] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.Losses);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.Losses);
                            }
                            break;
                        }
                    case 2:
                        {
                            if (_sortModes[1][2] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.ERA);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.ERA);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (_sortModes[1][3] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.TGP);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.TGP);
                            }
                            break;
                        }
                    case 4:
                        {
                            if (_sortModes[1][3] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.TGP);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.TGP);
                            }
                            break;
                        }
                    case 5:
                        {
                            if (_sortModes[1][5] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.CompleteGames);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.CompleteGames);
                            }
                            break;
                        }
                    case 6:
                        {
                            if (_sortModes[1][6] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.Shutouts);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.Shutouts);
                            }
                            break;
                        }
                    case 7:
                        {
                            if (_sortModes[1][7] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.Saves);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.Saves);
                            }
                            break;
                        }
                    case 8:
                        {
                            if (_sortModes[1][8] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.IP);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.IP);
                            }
                            break;
                        }
                    case 9:
                        {
                            if (_sortModes[1][9] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.HitsAllowed);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.HitsAllowed);
                            }
                            break;
                        }
                    case 10:
                        {
                            if (_sortModes[1][10] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.RunsAllowed);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.RunsAllowed);
                            }
                            break;
                        }
                    case 11:
                        {
                            if (_sortModes[1][11] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.HomeRunsAllowed);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.HomeRunsAllowed);
                            }
                            break;
                        }
                    case 12:
                        {
                            if (_sortModes[1][12] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.HitByPitch);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.HitByPitch);
                            }
                            break;
                        }
                    case 13:
                        {
                            if (_sortModes[1][13] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.WalksAllowed);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.WalksAllowed);
                            }
                            break;
                        }
                    case 14:
                        {
                            if (_sortModes[1][14] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.Strikeouts);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.Strikeouts);
                            }
                            break;
                        }
                    case 15:
                        {
                            if (_sortModes[1][15] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.WHIP);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.WHIP);
                            }
                            break;
                        }
                    case 16:
                        {
                            if (_sortModes[1][16] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.BAA);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.BAA);
                            }
                            break;
                        }
                    case 17:
                        {
                            if (_sortModes[1][17] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.TotalBattersFaced);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.TotalBattersFaced);
                            }
                            break;
                        }
                    case 18:
                        {
                            if (_sortModes[1][18] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.QualityStarts);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.QualityStarts);
                            }
                            break;
                        }
                    case 19:
                        {
                            if (_sortModes[1][19] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.Holds);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.Holds);
                            }
                            break;
                        }
                    case 20:
                        {
                            if (_sortModes[1][20] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.DoublePlays);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.DoublePlays);
                            }
                            break;
                        }
                    case 21:
                        {
                            if (_sortModes[1][21] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.GOtoAO);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.GOtoAO);
                            }
                            break;
                        }
                    case 22:
                        {
                            if (_sortModes[1][22] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.KperNineInnings);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.KperNineInnings);
                            }
                            break;
                        }
                    case 23:
                        {
                            if (_sortModes[1][23] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.BBperNineInnings);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.BBperNineInnings);
                            }
                            break;
                        }
                    case 24:
                        {
                            if (_sortModes[1][24] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.KperBB);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.KperBB);
                            }
                            break;
                        }
                    case 25:
                        {
                            if (_sortModes[1][25] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.StolenBasesAllowed);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.StolenBasesAllowed);
                            }
                            break;
                        }
                    case 26:
                        {
                            if (_sortModes[1][26] == SortMode.Descending)
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStatsDesc(_teamPitchingStats, team => team.pitchingStats.CaughtStealing);
                            }
                            else
                            {
                                _teamPitchingStats = _teamsBL.GetSortedTeamStats(_teamPitchingStats, team => team.pitchingStats.CaughtStealing);
                            }
                            break;
                        }
                }
            }
            FillBattersAndPitchersTable(_batters, _pitchers, _teamBattingStats, _teamPitchingStats);
        }

        private void dataGridView4_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                _sortModes[1][dataGridView3.ColumnCount - 3 + e.ColumnIndex - 3] = (_sortModes[1][dataGridView3.ColumnCount - 3 + e.ColumnIndex - 3] == SortMode.Descending && _lastPitchingSort == dataGridView3.ColumnCount - 3 + e.ColumnIndex - 3) ? SortMode.Ascending : SortMode.Descending;
                _lastPitchingSort = dataGridView3.ColumnCount - 3 + e.ColumnIndex - 3;
            }
            GetSortedListsBySortingCodes(_lastBattingSort, _lastPitchingSort, _objects);
        }

        private void dataGridView3_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                if (e.ColumnIndex == 5)
                {
                    _sortModes[1][e.ColumnIndex - 3] = (_sortModes[1][e.ColumnIndex - 3] == SortMode.Ascending && _lastPitchingSort == e.ColumnIndex - 3) ? SortMode.Descending : SortMode.Ascending;
                }
                else
                {
                    _sortModes[1][e.ColumnIndex - 3] = (_sortModes[1][e.ColumnIndex - 3] == SortMode.Descending && _lastPitchingSort == e.ColumnIndex - 3) ? SortMode.Ascending : SortMode.Descending;
                }
                _lastPitchingSort = e.ColumnIndex - 3;
            }
            GetSortedListsBySortingCodes(_lastBattingSort, _lastPitchingSort, _objects);
        }

        private void btnHitting_Click(object sender, EventArgs e)
        {
            _playerType = PlayerType.Batters;
            ShowNewStats(_playerType, _statsType);
        }

        private void btnPitching_Click(object sender, EventArgs e)
        {
            _playerType = PlayerType.Pitchers;
            ShowNewStats(_playerType, _statsType);
        }

        private void btnStandardStats_Click(object sender, EventArgs e)
        {
            _statsType = StatsType.Standard;
            ShowNewStats(_playerType, _statsType);
        }

        private void btnExpandedStats_Click(object sender, EventArgs e)
        {
            _statsType = StatsType.Expanded;
            ShowNewStats(_playerType, _statsType);
        }

        private void FillBattersAndPitchersTable(List<Player> batters, List<Player> pitchers, List<Team> teamBatting, List<Team> teamPitching)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            if (_objects == SortingObjects.Players)
            {
                for (int i = 0; i < batters.Count; i++)
                {
                    dataGridView1.Rows.Add(i + 1,
                                            "",
                                            batters[i].FullName,
                                            batters[i].battingStats.Games,
                                            batters[i].battingStats.AtBats,
                                            batters[i].battingStats.Runs,
                                            batters[i].battingStats.Hits,
                                            batters[i].battingStats.Doubles,
                                            batters[i].battingStats.Triples,
                                            batters[i].battingStats.HomeRuns,
                                            batters[i].battingStats.RBI,
                                            batters[i].battingStats.Walks,
                                            batters[i].battingStats.StolenBases,
                                            batters[i].battingStats.CaughtStealing,
                                            batters[i].battingStats.AVG.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].battingStats.OBP.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].battingStats.SLG.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].battingStats.OPS.ToString("#.000", new CultureInfo("en-US")));
                    GetCorrectColorForCell(dataGridView1, i, batters[i].Team);

                    dataGridView2.Rows.Add(i + 1,
                                            "",
                                            batters[i].FullName,
                                            batters[i].battingStats.PA,
                                            batters[i].battingStats.HitByPitch,
                                            batters[i].battingStats.SacrificeBunts,
                                            batters[i].battingStats.SacrificeFlies,
                                            batters[i].battingStats.DoublePlay,
                                            batters[i].battingStats.GOtoAO.ToString("0.00", new CultureInfo("en-US")),
                                            batters[i].battingStats.XBH,
                                            batters[i].battingStats.TotalBases,
                                            batters[i].battingStats.ISO.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].battingStats.ABperHR.ToString("0.00", new CultureInfo("en-US")),
                                            batters[i].battingStats.WalkToStrikeout.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].battingStats.WalkPercentage.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].battingStats.StrikeoutPercentage.ToString("#.000", new CultureInfo("en-US")));
                    GetCorrectColorForCell(dataGridView2, i, batters[i].Team);
                }
                for (int i = 0; i < pitchers.Count; i++)
                {
                    dataGridView3.Rows.Add(i + 1,
                                            "",
                                            pitchers[i].FullName,
                                            pitchers[i].pitchingStats.Wins,
                                            pitchers[i].pitchingStats.Losses,
                                            pitchers[i].pitchingStats.ERA.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].pitchingStats.GamesPlayed,
                                            pitchers[i].pitchingStats.GamesStarted,
                                            pitchers[i].pitchingStats.CompleteGames,
                                            pitchers[i].pitchingStats.Shutouts,
                                            pitchers[i].pitchingStats.Saves,
                                            pitchers[i].pitchingStats.IP.ToString("0.0", new CultureInfo("en-US")),
                                            pitchers[i].pitchingStats.HitsAllowed,
                                            pitchers[i].pitchingStats.RunsAllowed,
                                            pitchers[i].pitchingStats.HomeRunsAllowed,
                                            pitchers[i].pitchingStats.HitByPitch,
                                            pitchers[i].pitchingStats.WalksAllowed,
                                            pitchers[i].pitchingStats.Strikeouts,
                                            pitchers[i].pitchingStats.WHIP.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].pitchingStats.BAA.ToString("#.000", new CultureInfo("en-US")));
                    GetCorrectColorForCell(dataGridView3, i, pitchers[i].Team);

                    dataGridView4.Rows.Add(i + 1,
                                            "",
                                            pitchers[i].FullName,
                                            pitchers[i].pitchingStats.TotalBattersFaced,
                                            pitchers[i].pitchingStats.QualityStarts,
                                            pitchers[i].pitchingStats.Holds,
                                            pitchers[i].pitchingStats.DoublePlays,
                                            pitchers[i].pitchingStats.GOtoAO.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].pitchingStats.KperNineInnings.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].pitchingStats.BBperNineInnings.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].pitchingStats.KperBB.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].pitchingStats.StolenBasesAllowed,
                                            pitchers[i].pitchingStats.CaughtStealing);
                    GetCorrectColorForCell(dataGridView4, i, pitchers[i].Team);
                }
            }
            else
            {
                for (int i = 0; i < teamBatting.Count; i++)
                {
                    dataGridView1.Rows.Add(i + 1,
                                            "",
                                            teamBatting[i].TeamTitle,
                                            teamBatting[i].battingStats.TGP,
                                            teamBatting[i].battingStats.AtBats,
                                            teamBatting[i].battingStats.Runs,
                                            teamBatting[i].battingStats.Hits,
                                            teamBatting[i].battingStats.Doubles,
                                            teamBatting[i].battingStats.Triples,
                                            teamBatting[i].battingStats.HomeRuns,
                                            teamBatting[i].battingStats.RBI,
                                            teamBatting[i].battingStats.Walks,
                                            teamBatting[i].battingStats.StolenBases,
                                            teamBatting[i].battingStats.CaughtStealing,
                                            teamBatting[i].battingStats.AVG.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].battingStats.OBP.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].battingStats.SLG.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].battingStats.OPS.ToString("#.000", new CultureInfo("en-US")));
                    GetCorrectColorForCell(dataGridView1, i, teamBatting[i].TeamAbbreviation);

                    dataGridView2.Rows.Add(i + 1,
                                            "",
                                            teamBatting[i].TeamTitle,
                                            teamBatting[i].battingStats.PA,
                                            teamBatting[i].battingStats.HitByPitch,
                                            teamBatting[i].battingStats.SacrificeBunts,
                                            teamBatting[i].battingStats.SacrificeFlies,
                                            teamBatting[i].battingStats.DoublePlay,
                                            teamBatting[i].battingStats.GOtoAO.ToString("0.00", new CultureInfo("en-US")),
                                            teamBatting[i].battingStats.XBH,
                                            teamBatting[i].battingStats.TotalBases,
                                            teamBatting[i].battingStats.ISO.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].battingStats.ABperHR.ToString("0.00", new CultureInfo("en-US")),
                                            teamBatting[i].battingStats.WalkToStrikeout.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].battingStats.WalkPercentage.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].battingStats.StrikeoutPercentage.ToString("#.000", new CultureInfo("en-US")));
                    GetCorrectColorForCell(dataGridView2, i, teamBatting[i].TeamAbbreviation);
                }
                for (int i = 0; i < teamPitching.Count; i++)
                {
                    dataGridView3.Rows.Add(i + 1,
                                            "",
                                            teamPitching[i].TeamTitle,
                                            teamPitching[i].Wins,
                                            teamPitching[i].Losses,
                                            teamPitching[i].pitchingStats.ERA.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].pitchingStats.TGP,
                                            teamPitching[i].pitchingStats.TGP,
                                            teamPitching[i].pitchingStats.CompleteGames,
                                            teamPitching[i].pitchingStats.Shutouts,
                                            teamPitching[i].pitchingStats.Saves,
                                            teamPitching[i].pitchingStats.IP.ToString("0.0", new CultureInfo("en-US")),
                                            teamPitching[i].pitchingStats.HitsAllowed,
                                            teamPitching[i].pitchingStats.RunsAllowed,
                                            teamPitching[i].pitchingStats.HomeRunsAllowed,
                                            teamPitching[i].pitchingStats.HitByPitch,
                                            teamPitching[i].pitchingStats.WalksAllowed,
                                            teamPitching[i].pitchingStats.Strikeouts,
                                            teamPitching[i].pitchingStats.WHIP.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].pitchingStats.BAA.ToString("#.000", new CultureInfo("en-US")));
                    GetCorrectColorForCell(dataGridView3, i, teamPitching[i].TeamAbbreviation);

                    dataGridView4.Rows.Add(i + 1,
                                            "",
                                            teamPitching[i].TeamTitle,
                                            teamPitching[i].pitchingStats.TotalBattersFaced,
                                            teamPitching[i].pitchingStats.QualityStarts,
                                            teamPitching[i].pitchingStats.Holds,
                                            teamPitching[i].pitchingStats.DoublePlays,
                                            teamPitching[i].pitchingStats.GOtoAO.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].pitchingStats.KperNineInnings.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].pitchingStats.BBperNineInnings.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].pitchingStats.KperBB.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].pitchingStats.StolenBasesAllowed,
                                            teamPitching[i].pitchingStats.CaughtStealing);
                    GetCorrectColorForCell(dataGridView4, i, teamPitching[i].TeamAbbreviation);
                }
            }
        }

        private void GetCorrectColorForCell(DataGridView dgv, int RowNumber, string TeamForThisPlayer)
        {
            if (TeamForThisPlayer != "")
            {
                dgv.Rows[RowNumber].Cells[1].Style.BackColor = _teams.Where(team => team.TeamAbbreviation == TeamForThisPlayer).First().TeamColor[0];
                dgv.Rows[RowNumber].Cells[1].Style.SelectionBackColor = _teams.Where(team => team.TeamAbbreviation == TeamForThisPlayer).First().TeamColor[0];
            }
        }

        private void dataGridView4_CellStyleChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor;
        }

        private void PlayerStatsForm_Load(object sender, EventArgs e)
        {
            if (_objects == SortingObjects.Players)
            {
                _batters = _playersBL.GetBattersStats();
                _pitchers = _playersBL.GetPitchersStats();
            }
            else
            {
                _teamBattingStats = _teamsBL.GetTeamBattingStats();
                _teamPitchingStats = _teamsBL.GetTeamPitchingStats();
            }
            _playerType = PlayerType.Batters;
            _statsType = StatsType.Standard;
            cbPlayers.DataSource = cbPlayers.Items;
            ShowNewStats(_playerType, _statsType);
            List<string> teamsInComboBox = new List<string>
            {
                "MLB",
                "AL",
                "NL"
            };
            teamsInComboBox.AddRange(_teams.Select(team => team.TeamTitle).ToList());
            cbTeams.DataSource = teamsInComboBox;

            cbPositions.DataSource = _playersBL.GetPlayerPositions();
            cbPositions.DisplayMember = "FullTitle";
            cbPositions.ValueMember = "ShortTitle";

            cbPlayers.Visible = _objects == SortingObjects.Players;
            cbTeams.Visible = _objects == SortingObjects.Players;
            cbPositions.Visible = _objects == SortingObjects.Players;

            Text = _objects == SortingObjects.Players ? "Player statistics" : "Team statistics";
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTeams.Visible = cbPlayers.Text != "Free Agents";
            if (cbTeams.Items != null && cbPositions.DataSource != null)
            {
                if (_objects == SortingObjects.Players)
                {
                    _pitchers = _playersBL.GetPitchersStats(cbPlayers.Text, cbTeams.SelectedValue.ToString());
                    if (cbPositions.SelectedValue is PlayerPosition)
                    {
                        _batters = _playersBL.GetBattersStats(cbTeams.SelectedValue.ToString(), cbPlayers.Text, (cbPositions.SelectedValue as PlayerPosition).ShortTitle);
                    }
                    else
                    {
                        _batters = _playersBL.GetBattersStats(cbTeams.SelectedValue.ToString(), cbPlayers.Text, cbPositions.SelectedValue.ToString());
                    }
                }
                GetSortedListsBySortingCodes(_lastBattingSort, _lastPitchingSort, _objects);
            }
        }
    }
}