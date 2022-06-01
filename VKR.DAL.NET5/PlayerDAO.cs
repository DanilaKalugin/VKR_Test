using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using VKR.Entities.NET5;

namespace VKR.DAL.NET5
{
    public class PlayerDao : DAO
    {
        public IEnumerable<Player> GetAllPlayers()
        {
            var players = new List<Player>();
            using (var command = new SqlCommand("GetAllPlayers", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = (int)reader["PlayerID"];
                        var firstName = (string)reader["PlayerFirstName"];
                        var secondName = (string)reader["PlayerSecondName"];
                        var number = (int)reader["PlayerNumber"];
                        var placeOfBirth = (string)reader["PlaceOfBirth"];
                        var dateOfBirth = (DateTime)reader["PlayerDateOfBirth"];
                        var battingHand = (string)reader["PlayerBattingHand"];
                        var pitchingHand = (string)reader["PlayerPitchingHand"];
                        var team = (string)reader["TeamID"];
                        var inActiveRoster = (bool)reader["InActiveRoster"];

                        var batting = GetBattingStatsForPlayer(reader);
                        var pitching = GetPitchingStatsForPlayer(reader);

                        var player = new Player(id, firstName, secondName, number, placeOfBirth, dateOfBirth, battingHand, pitchingHand, team, inActiveRoster, batting, pitching);

                        players.Add(player);
                    }
                }
            }
            foreach (var player1 in players) player1.PlayerPositions = GetPositionsForThisPlayer(player1.Id).ToList();
            return players;
        }

        public IEnumerable<PitchingStats> GetPitchingStatsByCode(Pitcher pitcher)
        {
            using var command = new SqlCommand("GetPitcherStatsByCode", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Code", SqlDbType.Int);
            command.Prepare();
            command.Parameters[0].Value = pitcher.Id;

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var games = (int)reader["G"];
                var gamesStarted = (int)reader["GS"];
                var strikeouts = (int)reader["K"];
                var outs = (int)reader["Outs"];
                var runs = (int)reader["R"];
                var walks = (int)reader["BB"];
                var single = (int)reader["1B"];
                var @double = (int)reader["2B"];
                var triple = (int)reader["3B"];
                var homeRun = (int)reader["HR"];
                var battersFaced = (int)reader["TBF"];
                var hitByPitch = (int)reader["HBP"];
                var sacFlies = (int)reader["SF"];
                var bunts = (int)reader["SAC"];
                var stolenBase = (int)reader["SB"];
                var caughtStealing = (int)reader["CS"];
                var doublePlay = (int)reader["GIDP"];
                var qualityStarts = (int)reader["QS"];
                var completeGames = (int)reader["CG"];
                var shutouts = (int)reader["SHO"];
                var flyout = (int)reader["AO"];
                var groundout = (int)reader["GO"];
                var wins = (int)reader["W"];
                var losses = (int)reader["L"];
                var saves = (int)reader["SV"];
                var holds = (int)reader["HLD"];
                yield return new PitchingStats(games, gamesStarted, strikeouts, outs,
                    walks, bunts, sacFlies, stolenBase, caughtStealing, battersFaced,
                    qualityStarts, shutouts, completeGames, wins, losses, saves, holds,
                    hitByPitch, single, @double, triple, homeRun, runs, doublePlay,
                    groundout, flyout, pitcher.PitchingStats.Tgp);
            }
        }

        public IEnumerable<Player> GetPlayerByCode(int code)
        {
            using var command = new SqlCommand("GetPlayerByCode", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Code", SqlDbType.Int);
            command.Prepare();
            command.Parameters[0].Value = code;

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = (int)reader["PlayerID"];
                var firstName = (string)reader["PlayerFirstName"];
                var secondName = (string)reader["PlayerSecondName"];
                var number = (int)reader["PlayerNumber"];
                var placeOfBirth = (string)reader["PlaceOfBirth"];
                var dateOfBirth = (DateTime)reader["PlayerDateOfBirth"];
                var battingHand = (string)reader["PlayerBattingHand"];
                var pitchingHand = (string)reader["PlayerPitchingHand"];
                var team = (string)reader["TeamID"];
                var inActiveRoster = (bool)reader["InActiveRoster"];

                var batting = GetBattingStatsForPlayer(reader);
                var pitching = GetPitchingStatsForPlayer(reader);

                yield return new Player(id, firstName, secondName, number, placeOfBirth, dateOfBirth,
                    battingHand, pitchingHand, team, inActiveRoster, batting, pitching);
            }
        }

        public IEnumerable<string> GetPositionsForThisPlayer(int code)
        {
            using var command = new SqlCommand("GetPlayerPositions", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Code", SqlDbType.Int);
            command.Prepare();
            command.Parameters[0].Value = code;

            using var reader = command.ExecuteReader();
            while (reader.Read())
                yield return (string)reader["PlayerPositionID"];
        }

        public IEnumerable<PlayerPosition> GetPlayerPositions()
        {
            using var command = new SqlCommand("GetAllPlayerPositions", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Prepare();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var code = (string)reader["PositionCode"];
                var full = (string)reader["PositionFullTitle"];
                yield return new PlayerPosition(code, full);
            }
        }

        public IEnumerable<PlayerInLineup> GetRoster(string rosterType)
        {
            using var command = new SqlCommand(rosterType, _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Prepare();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = (int)reader["PlayerID"];
                var firstName = (string)reader["PlayerFirstName"];
                var secondName = (string)reader["PlayerSecondName"];
                var number = (int)reader["PlayerNumber"];
                var place = (string)reader["PlaceOfBirth"];
                var dob = (DateTime)reader["PlayerDateOfBirth"];
                var team = (string)reader["TeamID"];
                var lineup = (int)reader["LineupType"];
                var numberInLineup = (int)reader["PositionInLineup"];
                var battingHand = (string)reader["PlayerBattingHand"];
                var pitchingHand = (string)reader["PlayerPitchingHand"];

                var batting = GetBattingStatsForPlayer(reader);
                var pitching = GetPitchingStatsForPlayer(reader);

                yield return new PlayerInLineup(id, firstName, secondName, dob, place, number, lineup, team,
                    numberInLineup, battingHand, pitchingHand, batting, pitching);
            }
        }

        public IEnumerable<PlayerInLineup> GetStartingLineups()
        {
            using var command = new SqlCommand("GetStartingLineups", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Prepare();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = (int)reader["PlayerID"];
                var firstName = (string)reader["PlayerFirstName"];
                var secondName = (string)reader["PlayerSecondName"];
                var number = (int)reader["PlayerNumber"];
                var place = (string)reader["PlaceOfBirth"];
                var dob = (DateTime)reader["PlayerDateOfBirth"];
                var team = (string)reader["TeamID"];
                var lineup = (int)reader["LineupType"];
                var numberInLineup = (int)reader["PositionInLineup"];
                var batting = (string)reader["PlayerBattingHand"];
                var pitching = (string)reader["PlayerPitchingHand"];
                var position = (string)reader["PlayerPosition"];

                var battingStats = GetBattingStatsForPlayer(reader);
                var pitchingStats = GetPitchingStatsForPlayer(reader);

                yield return new PlayerInLineup(id, firstName, secondName, dob, place, number, lineup, team,
                    position, numberInLineup, batting, pitching, battingStats, pitchingStats);
            }
        }

        public IEnumerable<Batter> GetCurrentLineupForThisMatch(string team, int match)
        {
            using var command = new SqlCommand("GetCurrentLineupForThisMatch", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
            command.Parameters.Add("@Match", SqlDbType.Int);
            command.Prepare();
            command.Parameters[0].Value = team;
            command.Parameters[1].Value = match;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = (int)reader["PlayerID"];
                var firstName = (string)reader["PlayerFirstName"];
                var secondName = (string)reader["PlayerSecondName"];
                var number = (int)reader["PlayerNumber"];
                var placeOfBirth = (string)reader["PlaceOfBirth"];
                var dateOfBirth = (DateTime)reader["PlayerDateOfBirth"];
                var battingHand = (string)reader["PlayerBattingHand"];
                var pitchingHand = (string)reader["PlayerPitchingHand"];
                var teamId = (string)reader["TeamID"];
                var inActiveRoster = (bool)reader["InActiveRoster"];
                var positionInLineup = (int)reader["NumberInLineup"];
                var position = (string)reader["PlayerPosition"];

                var batting = GetBattingStatsForPlayer(reader);
                var pitching = GetPitchingStatsForPlayer(reader);

                yield return new Batter(id, firstName, secondName, number, placeOfBirth, dateOfBirth,
                    battingHand, pitchingHand, teamId, inActiveRoster, position, positionInLineup, batting,
                    pitching);
            }
        }

        public IEnumerable<Pitcher> GetStartingPitcherForThisTeam(Team team, Match match)
        {
            using var command = new SqlCommand("GetStartingPitcherForThisTeam", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Match", SqlDbType.Int);
            command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
            command.Prepare();
            command.Parameters[0].Value = match.MatchID;
            command.Parameters[1].Value = team.TeamAbbreviation;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = (int)reader["PlayerID"];
                var firstName = (string)reader["PlayerFirstName"];
                var secondName = (string)reader["PlayerSecondName"];
                var number = (int)reader["PlayerNumber"];
                var placeOfBirth = (string)reader["PlaceOfBirth"];
                var dateOfBirth = (DateTime)reader["PlayerDateOfBirth"];
                var battingHand = (string)reader["PlayerBattingHand"];
                var pitchingHand = (string)reader["PlayerPitchingHand"];
                var teamId = (string)reader["TeamID"];
                var inActiveRoster = (bool)reader["InActiveRoster"];
                var positionInLineup = (int)reader["PlayerPositionInLineup"];
                var position = (string)reader["PlayerPosition"];

                var batting = GetBattingStatsForPlayer(reader);
                var pitching = GetPitchingStatsForPlayer(reader);

                yield return new Pitcher(id, firstName, secondName, number, placeOfBirth, dateOfBirth,
                    battingHand, pitchingHand, teamId, inActiveRoster, positionInLineup, position != "P",
                    batting, pitching);
            }
        }

        public IEnumerable<Pitcher> GetAvailablePitchers(Match match, Team team)
        {
            using var command = new SqlCommand("GetAvailablePitchersForSubstitution", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Match", SqlDbType.Int);
            command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
            command.Prepare();
            command.Parameters[0].Value = match.MatchID;
            command.Parameters[1].Value = team.TeamAbbreviation;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = (int)reader["PlayerID"];
                var firstName = (string)reader["PlayerFirstName"];
                var secondName = (string)reader["PlayerSecondName"];
                var number = (int)reader["PlayerNumber"];
                var placeOfBirth = (string)reader["PlaceOfBirth"];
                var dateOfBirth = (DateTime)reader["PlayerDateOfBirth"];
                var battingHand = (string)reader["PlayerBattingHand"];
                var pitchingHand = (string)reader["PlayerPitchingHand"];
                var teamId = (string)reader["TeamID"];
                var inActiveRoster = (bool)reader["InActiveRoster"];
                var positionInLineup = (int)reader["NumberInLineup"];
                var position = (string)reader["PlayerPosition"];

                var batting = GetBattingStatsForPlayer(reader);
                var pitching = GetPitchingStatsForPlayer(reader);

                var player = new Pitcher(id, firstName, secondName, number, placeOfBirth, dateOfBirth,
                    battingHand, pitchingHand, teamId, inActiveRoster, positionInLineup, position != "P",
                    batting, pitching);
                yield return player;
            }
        }

        public int GetNumberOfOutsPlayedByThisPitcherInLast5Days(int id, int match = 0)
        {
            using var command = new SqlCommand("GetRemainingStaminaForThisPitcher", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Pitcher", SqlDbType.Int);
            command.Parameters.Add("Match", SqlDbType.Int);
            command.Prepare();
            command.Parameters[0].Value = id;
            command.Parameters[1].Value = match;

            return (int)command.ExecuteScalar();
        }

        public IEnumerable<Batter> GetAvailableBatters(Match match, Team team, Batter batter)
        {
            using var command = new SqlCommand("GetAvailableBattersForSubstitution", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Match", SqlDbType.Int);
            command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
            command.Parameters.Add("@Position", SqlDbType.NVarChar, 2);
            command.Prepare();
            command.Parameters[0].Value = match.MatchID;
            command.Parameters[1].Value = team.TeamAbbreviation;
            command.Parameters[2].Value = batter.PositionForThisMatch;

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = (int)reader["PlayerID"];
                var firstName = (string)reader["PlayerFirstName"];
                var secondName = (string)reader["PlayerSecondName"];
                var number = (int)reader["PlayerNumber"];
                var placeOfBirth = (string)reader["PlaceOfBirth"];
                var dateOfBirth = (DateTime)reader["PlayerDateOfBirth"];
                var battingHand = (string)reader["PlayerBattingHand"];
                var pitchingHand = (string)reader["PlayerPitchingHand"];
                var teamId = (string)reader["TeamID"];
                var inActiveRoster = (bool)reader["InActiveRoster"];
                var position = (string)reader["PlayerPositionID"];

                var batting = GetBattingStatsForPlayer(reader);
                var pitching = GetPitchingStatsForPlayer(reader);

                yield return new Batter(id, firstName, secondName, number, placeOfBirth, dateOfBirth,
                    battingHand, pitchingHand, teamId, inActiveRoster, position, batter.NumberInBattingLineup,
                    batting, pitching);
            }
        }
        public BattingStats GetBattingStatsForPlayer(SqlDataReader reader)
        {
            var games = (int)reader["BatterG"];
            var strikeouts = (int)reader["BatterK"];
            var walks = (int)reader["BatterBB"];
            var hitByPitch = (int)reader["BatterHBP"];
            var flyout = (int)reader["BatterAO"];
            var groundout = (int)reader["BatterGO"];
            var popout = (int)reader["BatterPO"];
            var single = (int)reader["Batter1B"];
            var @double = (int)reader["Batter2B"];
            var triple = (int)reader["Batter3B"];
            var homeRun = (int)reader["BatterHR"];
            var stolenBase = (int)reader["BatterSB"];
            var caughtStealing = (int)reader["BatterCS"];
            var runs = (int)reader["BatterR"];
            var sacFlies = (int)reader["BatterSF"];
            var bunts = (int)reader["BatterSAC"];
            var rbi = (int)reader["BatterRBI"];
            var pa = (int)reader["BatterPA"];
            var gidp = (int)reader["BatterGIDP"];
            var tgp = (int)reader["BatterTGP"];
            return new BattingStats(games, single, @double, triple,
                homeRun, sacFlies, bunts, rbi, hitByPitch, stolenBase, caughtStealing,
                runs, walks, strikeouts, groundout, flyout, popout, pa, gidp, tgp);
        }

        public PitchingStats GetPitchingStatsForPlayer(SqlDataReader reader)
        {
            var tgp = (int)reader["BatterTGP"];
            var pitcherG = (int)reader["PitcherG"];
            var pitcherGs = (int)reader["PitcherGS"];
            var pitcherK = (int)reader["PitcherK"];
            var pitcherOuts = (int)reader["PitcherOuts"];
            var pitcherR = (int)reader["PitcherR"];
            var pitcherBb = (int)reader["PitcherBB"];
            var pitcher1B = (int)reader["Pitcher1B"];
            var pitcher2B = (int)reader["Pitcher2B"];
            var pitcher3B = (int)reader["Pitcher3B"];
            var pitcherHr = (int)reader["PitcherHR"];
            var pitcherTbf = (int)reader["PitcherTBF"];
            var pitcherHbp = (int)reader["PitcherHBP"];
            var pitcherSf = (int)reader["PitcherSF"];
            var pitcherSac = (int)reader["PitcherSAC"];
            var pitcherSb = (int)reader["PitcherSB"];
            var pitcherCs = (int)reader["PitcherCS"];
            var pitcherGidp = (int)reader["PitcherGIDP"];
            var pitcherQs = (int)reader["PitcherQS"];
            var pitcherCg = (int)reader["PitcherCG"];
            var pitcherSho = (int)reader["PitcherSHO"];
            var pitcherAo = (int)reader["PitcherAO"];
            var pitcherGo = (int)reader["PitcherGO"];
            var pitcherW = (int)reader["PitcherW"];
            var pitcherL = (int)reader["PitcherL"];
            var pitcherSv = (int)reader["PitcherSV"];
            var pitcherHld = (int)reader["PitcherHLD"];
            return new PitchingStats(pitcherG, pitcherGs, pitcherK, pitcherOuts,
                                     pitcherBb, pitcherSac, pitcherSf, pitcherSb, pitcherCs, pitcherTbf,
                                     pitcherQs, pitcherSho, pitcherCg, pitcherW, pitcherL, pitcherSv, pitcherHld,
                                     pitcherHbp, pitcher1B, pitcher2B, pitcher3B, pitcherHr, pitcherR, pitcherGidp,
                                     pitcherGo, pitcherAo, tgp);
        }
    }
}