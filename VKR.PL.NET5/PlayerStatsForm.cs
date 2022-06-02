﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.Entities.NET5;

namespace VKR.PL.NET5
{
    public partial class PlayerStatsForm : Form
    {
        private enum SortMode { Ascending, Descending }
        private enum PlayerType { Pitchers, Batters }
        private enum StatsType { Standard, Expanded }
        public enum SortingObjects { Players, Teams }

        private readonly PlayerBL _playersBL = new();
        private readonly TeamsBL _teamsBL = new();
        private readonly SortingBL _sortingBL = new();
        private readonly List<Team> _teams;
        private List<Player> _batters;
        private List<Player> _pitchers;
        private List<Team> _teamBattingStats;
        private List<Team> _teamPitchingStats;
        private readonly SortMode[][] _sortModes = new SortMode[2][];
        private PlayerType _playerType;
        private StatsType _statsType;
        private readonly SortingObjects _objects;
        private int _lastBattingSort = 11;
        private int _lastPitchingSort = 2;

        public PlayerStatsForm(SortingObjects sortingObject)
        {
            InitializeComponent();

            _teams = _teamsBL.GetAllTeams().ToList();
            _objects = sortingObject;
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
                _sortModes[0][e.ColumnIndex - 3] = _sortModes[0][e.ColumnIndex - 3] == SortMode.Descending && _lastBattingSort == e.ColumnIndex - 3 ? SortMode.Ascending : SortMode.Descending;
                _lastBattingSort = e.ColumnIndex - 3;
            }

            GetSortedListsBySortingCodes(_lastBattingSort, _lastPitchingSort, _objects);
        }

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                if (e.ColumnIndex is 8 or 12 or 15)
                    _sortModes[0][dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3] = _sortModes[0][dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3] == SortMode.Ascending && _lastBattingSort == dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3 ? SortMode.Descending : SortMode.Ascending;
                else
                    _sortModes[0][dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3] = _sortModes[0][dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3] == SortMode.Descending && _lastBattingSort == dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3 ? SortMode.Ascending : SortMode.Descending;
                _lastBattingSort = dataGridView1.ColumnCount - 3 + e.ColumnIndex - 3;

            }

            GetSortedListsBySortingCodes(_lastBattingSort, _lastPitchingSort, _objects);
        }

        private void GetSortedListsBySortingCodes(int batting, int pitching, SortingObjects obj)
        {
            var playerBattingActions = new List<Func<Player, double>>
            {
                batter => batter.BattingStats.Games,
                batter => batter.BattingStats.AtBats,
                batter => batter.BattingStats.Runs,
                batter => batter.BattingStats.Hits,
                batter => batter.BattingStats.Doubles,
                batter => batter.BattingStats.Triples,
                batter => batter.BattingStats.HomeRuns,
                batter => batter.BattingStats.RBI,
                batter => batter.BattingStats.Walks,
                batter => batter.BattingStats.StolenBases,
                batter => batter.BattingStats.CaughtStealing,
                batter => batter.BattingStats.AVG,
                batter => batter.BattingStats.OBP,
                batter => batter.BattingStats.SLG,
                batter => batter.BattingStats.OPS,
                batter => batter.BattingStats.PA,
                batter => batter.BattingStats.HitByPitch,
                batter => batter.BattingStats.SacrificeBunts,
                batter => batter.BattingStats.SacrificeFlies,
                batter => batter.BattingStats.DoublePlay,
                batter => batter.BattingStats.GOtoAO,
                batter => batter.BattingStats.XBH,
                batter => batter.BattingStats.TotalBases,
                batter => batter.BattingStats.ISO,
                batter => batter.BattingStats.ABperHR,
                batter => batter.BattingStats.WalkToStrikeout,
                batter => batter.BattingStats.WalkPercentage,
                batter => batter.BattingStats.StrikeoutPercentage
            };

            var playerPitchingActions = new List<Func<Player, double>>
            {
                pitcher => pitcher.PitchingStats.Wins,
                pitcher => pitcher.PitchingStats.Losses,
                pitcher => pitcher.PitchingStats.ERA,
                pitcher => pitcher.PitchingStats.GamesPlayed,
                pitcher => pitcher.PitchingStats.GamesStarted,
                pitcher => pitcher.PitchingStats.CompleteGames,
                pitcher => pitcher.PitchingStats.Shutouts,
                pitcher => pitcher.PitchingStats.Saves,
                pitcher => pitcher.PitchingStats.IP,
                pitcher => pitcher.PitchingStats.HitsAllowed,
                pitcher => pitcher.PitchingStats.RunsAllowed,
                pitcher => pitcher.PitchingStats.HomeRunsAllowed,
                pitcher => pitcher.PitchingStats.HitByPitch,
                pitcher => pitcher.PitchingStats.WalksAllowed,
                pitcher => pitcher.PitchingStats.Strikeouts,
                pitcher => pitcher.PitchingStats.WHIP,
                pitcher => pitcher.PitchingStats.BAA,
                pitcher => pitcher.PitchingStats.TotalBattersFaced,
                pitcher => pitcher.PitchingStats.QualityStarts,
                pitcher => pitcher.PitchingStats.Holds,
                pitcher => pitcher.PitchingStats.DoublePlays,
                pitcher => pitcher.PitchingStats.GOtoAo,
                pitcher => pitcher.PitchingStats.KperNineInnings,
                pitcher => pitcher.PitchingStats.BBperNineInnings,
                pitcher => pitcher.PitchingStats.KperBb,
                pitcher => pitcher.PitchingStats.StolenBasesAllowed,
                pitcher => pitcher.PitchingStats.CaughtStealing
            };

            var teamBattingActions = new List<Func<Team, double>>
            {
                teamBatting => teamBatting.BattingStats.TGP,
                teamBatting => teamBatting.BattingStats.AtBats,
                teamBatting => teamBatting.BattingStats.Runs,
                teamBatting => teamBatting.BattingStats.Hits,
                teamBatting => teamBatting.BattingStats.Doubles,
                teamBatting => teamBatting.BattingStats.Triples,
                teamBatting => teamBatting.BattingStats.HomeRuns,
                teamBatting => teamBatting.BattingStats.RBI,
                teamBatting => teamBatting.BattingStats.Walks,
                teamBatting => teamBatting.BattingStats.StolenBases,
                teamBatting => teamBatting.BattingStats.CaughtStealing,
                teamBatting => teamBatting.BattingStats.AVG,
                teamBatting => teamBatting.BattingStats.OBP,
                teamBatting => teamBatting.BattingStats.SLG,
                teamBatting => teamBatting.BattingStats.OPS,
                teamBatting => teamBatting.BattingStats.PA,
                teamBatting => teamBatting.BattingStats.HitByPitch,
                teamBatting => teamBatting.BattingStats.SacrificeBunts,
                teamBatting => teamBatting.BattingStats.SacrificeFlies,
                teamBatting => teamBatting.BattingStats.DoublePlay,
                teamBatting => teamBatting.BattingStats.GOtoAO,
                teamBatting => teamBatting.BattingStats.XBH,
                teamBatting => teamBatting.BattingStats.TotalBases,
                teamBatting => teamBatting.BattingStats.ISO,
                teamBatting => teamBatting.BattingStats.ABperHR,
                teamBatting => teamBatting.BattingStats.WalkToStrikeout,
                teamBatting => teamBatting.BattingStats.WalkPercentage,
                teamBatting => teamBatting.BattingStats.StrikeoutPercentage
            };

            var teamPitchingActions = new List<Func<Team, double>>
            {
                pitcher => pitcher.Wins,
                pitcher => pitcher.Losses,
                pitcher => pitcher.PitchingStats.ERA,
                pitcher => pitcher.PitchingStats.Tgp,
                pitcher => pitcher.PitchingStats.Tgp,
                pitcher => pitcher.PitchingStats.CompleteGames,
                pitcher => pitcher.PitchingStats.Shutouts,
                pitcher => pitcher.PitchingStats.Saves,
                pitcher => pitcher.PitchingStats.IP,
                pitcher => pitcher.PitchingStats.HitsAllowed,
                pitcher => pitcher.PitchingStats.RunsAllowed,
                pitcher => pitcher.PitchingStats.HomeRunsAllowed,
                pitcher => pitcher.PitchingStats.HitByPitch,
                pitcher => pitcher.PitchingStats.WalksAllowed,
                pitcher => pitcher.PitchingStats.Strikeouts,
                pitcher => pitcher.PitchingStats.WHIP,
                pitcher => pitcher.PitchingStats.BAA,
                pitcher => pitcher.PitchingStats.TotalBattersFaced,
                pitcher => pitcher.PitchingStats.QualityStarts,
                pitcher => pitcher.PitchingStats.Holds,
                pitcher => pitcher.PitchingStats.DoublePlays,
                pitcher => pitcher.PitchingStats.GOtoAo,
                pitcher => pitcher.PitchingStats.KperNineInnings,
                pitcher => pitcher.PitchingStats.BBperNineInnings,
                pitcher => pitcher.PitchingStats.KperBb,
                pitcher => pitcher.PitchingStats.StolenBasesAllowed,
                pitcher => pitcher.PitchingStats.CaughtStealing
            };

            if (obj == SortingObjects.Players)
            {
                _batters = _sortModes[0][batting] == SortMode.Descending ? _sortingBL.GetSortedStatsDesc(_batters, playerBattingActions[batting]) 
                                                                         : _sortingBL.GetSortedStats(_batters, playerBattingActions[batting]);

                _pitchers = _sortModes[1][pitching] == SortMode.Descending ? _sortingBL.GetSortedStatsDesc(_pitchers, playerPitchingActions[pitching]) 
                                                                           : _sortingBL.GetSortedStats(_pitchers, playerPitchingActions[pitching]);
            }
            else
            {
                _teamBattingStats = _sortModes[0][batting] == SortMode.Descending ? _sortingBL.GetSortedStatsDesc(_teamBattingStats, teamBattingActions[batting]) 
                                                                                  : _sortingBL.GetSortedStats(_teamBattingStats, teamBattingActions[batting]);

                _teamPitchingStats = _sortModes[1][pitching] == SortMode.Descending ? _sortingBL.GetSortedStatsDesc(_teamPitchingStats, teamPitchingActions[pitching]) 
                                                                                    : _sortingBL.GetSortedStats(_teamPitchingStats, teamPitchingActions[pitching]);
            }

            FillBattersAndPitchersTable(_batters, _pitchers, _teamBattingStats, _teamPitchingStats);
        }

        private void dataGridView4_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                _sortModes[1][dataGridView3.ColumnCount - 3 + e.ColumnIndex - 3] = _sortModes[1][dataGridView3.ColumnCount - 3 + e.ColumnIndex - 3] == SortMode.Descending && _lastPitchingSort == dataGridView3.ColumnCount - 3 + e.ColumnIndex - 3 ? SortMode.Ascending : SortMode.Descending;
                _lastPitchingSort = dataGridView3.ColumnCount - 3 + e.ColumnIndex - 3;
            }
            GetSortedListsBySortingCodes(_lastBattingSort, _lastPitchingSort, _objects);
        }

        private void dataGridView3_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                if (e.ColumnIndex == 5) _sortModes[1][e.ColumnIndex - 3] = _sortModes[1][e.ColumnIndex - 3] == SortMode.Ascending && _lastPitchingSort == e.ColumnIndex - 3
                            ? SortMode.Descending
                            : SortMode.Ascending;
                else
                    _sortModes[1][e.ColumnIndex - 3] = _sortModes[1][e.ColumnIndex - 3] == SortMode.Descending && _lastPitchingSort == e.ColumnIndex - 3
                            ? SortMode.Ascending
                            : SortMode.Descending;

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
                for (var i = 0; i < batters.Count; i++)
                {
                    dataGridView1.Rows.Add(i + 1,
                                            "",
                                            batters[i].FullName,
                                            batters[i].BattingStats.Games,
                                            batters[i].BattingStats.AtBats,
                                            batters[i].BattingStats.Runs,
                                            batters[i].BattingStats.Hits,
                                            batters[i].BattingStats.Doubles,
                                            batters[i].BattingStats.Triples,
                                            batters[i].BattingStats.HomeRuns,
                                            batters[i].BattingStats.RBI,
                                            batters[i].BattingStats.Walks,
                                            batters[i].BattingStats.StolenBases,
                                            batters[i].BattingStats.CaughtStealing,
                                            batters[i].BattingStats.AVG.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].BattingStats.OBP.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].BattingStats.SLG.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].BattingStats.OPS.ToString("#.000", new CultureInfo("en-US")));
                    GetCorrectColorForCell(dataGridView1, i, batters[i].Team);

                    dataGridView2.Rows.Add(i + 1,
                                            "",
                                            batters[i].FullName,
                                            batters[i].BattingStats.PA,
                                            batters[i].BattingStats.HitByPitch,
                                            batters[i].BattingStats.SacrificeBunts,
                                            batters[i].BattingStats.SacrificeFlies,
                                            batters[i].BattingStats.DoublePlay,
                                            batters[i].BattingStats.GOtoAO.ToString("0.00", new CultureInfo("en-US")),
                                            batters[i].BattingStats.XBH,
                                            batters[i].BattingStats.TotalBases,
                                            batters[i].BattingStats.ISO.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].BattingStats.ABperHR.ToString("0.00", new CultureInfo("en-US")),
                                            batters[i].BattingStats.WalkToStrikeout.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].BattingStats.WalkPercentage.ToString("#.000", new CultureInfo("en-US")),
                                            batters[i].BattingStats.StrikeoutPercentage.ToString("#.000", new CultureInfo("en-US")));
                    GetCorrectColorForCell(dataGridView2, i, batters[i].Team);
                }
                for (var i = 0; i < pitchers.Count; i++)
                {
                    dataGridView3.Rows.Add(i + 1,
                                            "",
                                            pitchers[i].FullName,
                                            pitchers[i].PitchingStats.Wins,
                                            pitchers[i].PitchingStats.Losses,
                                            pitchers[i].PitchingStats.ERA.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].PitchingStats.GamesPlayed,
                                            pitchers[i].PitchingStats.GamesStarted,
                                            pitchers[i].PitchingStats.CompleteGames,
                                            pitchers[i].PitchingStats.Shutouts,
                                            pitchers[i].PitchingStats.Saves,
                                            pitchers[i].PitchingStats.IP.ToString("0.0", new CultureInfo("en-US")),
                                            pitchers[i].PitchingStats.HitsAllowed,
                                            pitchers[i].PitchingStats.RunsAllowed,
                                            pitchers[i].PitchingStats.HomeRunsAllowed,
                                            pitchers[i].PitchingStats.HitByPitch,
                                            pitchers[i].PitchingStats.WalksAllowed,
                                            pitchers[i].PitchingStats.Strikeouts,
                                            pitchers[i].PitchingStats.WHIP.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].PitchingStats.BAA.ToString("#.000", new CultureInfo("en-US")));
                    GetCorrectColorForCell(dataGridView3, i, pitchers[i].Team);

                    dataGridView4.Rows.Add(i + 1,
                                            "",
                                            pitchers[i].FullName,
                                            pitchers[i].PitchingStats.TotalBattersFaced,
                                            pitchers[i].PitchingStats.QualityStarts,
                                            pitchers[i].PitchingStats.Holds,
                                            pitchers[i].PitchingStats.DoublePlays,
                                            pitchers[i].PitchingStats.GOtoAo.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].PitchingStats.KperNineInnings.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].PitchingStats.BBperNineInnings.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].PitchingStats.KperBb.ToString("0.00", new CultureInfo("en-US")),
                                            pitchers[i].PitchingStats.StolenBasesAllowed,
                                            pitchers[i].PitchingStats.CaughtStealing);
                    GetCorrectColorForCell(dataGridView4, i, pitchers[i].Team);
                }
            }
            else
            {
                for (var i = 0; i < teamBatting.Count; i++)
                {
                    dataGridView1.Rows.Add(i + 1,
                                            "",
                                            teamBatting[i].TeamTitle,
                                            teamBatting[i].BattingStats.TGP,
                                            teamBatting[i].BattingStats.AtBats,
                                            teamBatting[i].BattingStats.Runs,
                                            teamBatting[i].BattingStats.Hits,
                                            teamBatting[i].BattingStats.Doubles,
                                            teamBatting[i].BattingStats.Triples,
                                            teamBatting[i].BattingStats.HomeRuns,
                                            teamBatting[i].BattingStats.RBI,
                                            teamBatting[i].BattingStats.Walks,
                                            teamBatting[i].BattingStats.StolenBases,
                                            teamBatting[i].BattingStats.CaughtStealing,
                                            teamBatting[i].BattingStats.AVG.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].BattingStats.OBP.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].BattingStats.SLG.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].BattingStats.OPS.ToString("#.000", new CultureInfo("en-US")));
                    GetCorrectColorForCell(dataGridView1, i, teamBatting[i].TeamAbbreviation);

                    dataGridView2.Rows.Add(i + 1,
                                            "",
                                            teamBatting[i].TeamTitle,
                                            teamBatting[i].BattingStats.PA,
                                            teamBatting[i].BattingStats.HitByPitch,
                                            teamBatting[i].BattingStats.SacrificeBunts,
                                            teamBatting[i].BattingStats.SacrificeFlies,
                                            teamBatting[i].BattingStats.DoublePlay,
                                            teamBatting[i].BattingStats.GOtoAO.ToString("0.00", new CultureInfo("en-US")),
                                            teamBatting[i].BattingStats.XBH,
                                            teamBatting[i].BattingStats.TotalBases,
                                            teamBatting[i].BattingStats.ISO.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].BattingStats.ABperHR.ToString("0.00", new CultureInfo("en-US")),
                                            teamBatting[i].BattingStats.WalkToStrikeout.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].BattingStats.WalkPercentage.ToString("#.000", new CultureInfo("en-US")),
                                            teamBatting[i].BattingStats.StrikeoutPercentage.ToString("#.000", new CultureInfo("en-US")));
                    GetCorrectColorForCell(dataGridView2, i, teamBatting[i].TeamAbbreviation);
                }
                for (var i = 0; i < teamPitching.Count; i++)
                {
                    dataGridView3.Rows.Add(i + 1,
                                            "",
                                            teamPitching[i].TeamTitle,
                                            teamPitching[i].Wins,
                                            teamPitching[i].Losses,
                                            teamPitching[i].PitchingStats.ERA.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].PitchingStats.Tgp,
                                            teamPitching[i].PitchingStats.Tgp,
                                            teamPitching[i].PitchingStats.CompleteGames,
                                            teamPitching[i].PitchingStats.Shutouts,
                                            teamPitching[i].PitchingStats.Saves,
                                            teamPitching[i].PitchingStats.IP.ToString("0.0", new CultureInfo("en-US")),
                                            teamPitching[i].PitchingStats.HitsAllowed,
                                            teamPitching[i].PitchingStats.RunsAllowed,
                                            teamPitching[i].PitchingStats.HomeRunsAllowed,
                                            teamPitching[i].PitchingStats.HitByPitch,
                                            teamPitching[i].PitchingStats.WalksAllowed,
                                            teamPitching[i].PitchingStats.Strikeouts,
                                            teamPitching[i].PitchingStats.WHIP.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].PitchingStats.BAA.ToString("#.000", new CultureInfo("en-US")));
                    GetCorrectColorForCell(dataGridView3, i, teamPitching[i].TeamAbbreviation);

                    dataGridView4.Rows.Add(i + 1,
                                            "",
                                            teamPitching[i].TeamTitle,
                                            teamPitching[i].PitchingStats.TotalBattersFaced,
                                            teamPitching[i].PitchingStats.QualityStarts,
                                            teamPitching[i].PitchingStats.Holds,
                                            teamPitching[i].PitchingStats.DoublePlays,
                                            teamPitching[i].PitchingStats.GOtoAo.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].PitchingStats.KperNineInnings.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].PitchingStats.BBperNineInnings.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].PitchingStats.KperBb.ToString("0.00", new CultureInfo("en-US")),
                                            teamPitching[i].PitchingStats.StolenBasesAllowed,
                                            teamPitching[i].PitchingStats.CaughtStealing);
                    GetCorrectColorForCell(dataGridView4, i, teamPitching[i].TeamAbbreviation);
                }
            }
        }

        private void GetCorrectColorForCell(DataGridView dgv, int rowNumber, string teamForThisPlayer)
        {
            if (teamForThisPlayer == "") return;

            dgv.Rows[rowNumber].Cells[1].Style.BackColor = _teams.First(team => team.TeamAbbreviation == teamForThisPlayer).TeamColor[0];
            dgv.Rows[rowNumber].Cells[1].Style.SelectionBackColor = _teams.First(team => team.TeamAbbreviation == teamForThisPlayer).TeamColor[0];
        }

        private void dataGridView4_CellStyleChanged(object sender, DataGridViewCellEventArgs e) => dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor;

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
            
            var teamsInComboBox = new List<string> { "MLB", "AL", "NL" };
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

            if (cbPositions.DataSource == null) return;

            if (_objects == SortingObjects.Players)
            {
                _pitchers = _playersBL.GetPitchersStats(cbPlayers.Text, cbTeams.SelectedValue.ToString());
                var positionTitle = cbPositions.SelectedValue is PlayerPosition position ? position.ShortTitle : cbPositions.SelectedValue.ToString();
                _batters = _playersBL.GetBattersStats(cbTeams.SelectedValue.ToString(), cbPlayers.Text, positionTitle);
            }

            GetSortedListsBySortingCodes(_lastBattingSort, _lastPitchingSort, _objects);
        }
    }
}