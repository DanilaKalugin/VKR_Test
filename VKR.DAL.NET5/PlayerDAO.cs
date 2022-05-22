using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Entities.NET5;

namespace VKR.DAL.NET5
{
    public class PlayerDAO : DAO
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
                var Games = (int)reader["G"];
                var GamesStarted = (int)reader["GS"];
                var Strikeouts = (int)reader["K"];
                var Outs = (int)reader["Outs"];
                var Runs = (int)reader["R"];
                var Walks = (int)reader["BB"];
                var Single = (int)reader["1B"];
                var Double = (int)reader["2B"];
                var Triple = (int)reader["3B"];
                var HomeRun = (int)reader["HR"];
                var BattersFaced = (int)reader["TBF"];
                var HitByPitch = (int)reader["HBP"];
                var SacFlies = (int)reader["SF"];
                var Bunts = (int)reader["SAC"];
                var StolenBase = (int)reader["SB"];
                var CaughtStealing = (int)reader["CS"];
                var DoublePlay = (int)reader["GIDP"];
                var QualityStarts = (int)reader["QS"];
                var CompleteGames = (int)reader["CG"];
                var Shutouts = (int)reader["SHO"];
                var Flyout = (int)reader["AO"];
                var Groundout = (int)reader["GO"];
                var Wins = (int)reader["W"];
                var Losses = (int)reader["L"];
                var Saves = (int)reader["SV"];
                var Holds = (int)reader["HLD"];
                yield return new PitchingStats(Games, GamesStarted, Strikeouts, Outs,
                    Walks, Bunts, SacFlies, StolenBase, CaughtStealing, BattersFaced,
                    QualityStarts, Shutouts, CompleteGames, Wins, Losses, Saves, Holds,
                    HitByPitch, Single, Double, Triple, HomeRun, Runs, DoublePlay,
                    Groundout, Flyout, pitcher.PitchingStats.Tgp);
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
                var Code = (string)reader["PositionCode"];
                var Full = (string)reader["PositionFullTitle"];
                yield return new PlayerPosition(Code, Full);
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
                var FirstName = (string)reader["PlayerFirstName"];
                var SecondName = (string)reader["PlayerSecondName"];
                var number = (int)reader["PlayerNumber"];
                var Place = (string)reader["PlaceOfBirth"];
                var dob = (DateTime)reader["PlayerDateOfBirth"];
                var Team = (string)reader["TeamID"];
                var Lineup = (int)reader["LineupType"];
                var NumberInLineup = (int)reader["PositionInLineup"];
                var BattingHand = (string)reader["PlayerBattingHand"];
                var PitchingHand = (string)reader["PlayerPitchingHand"];

                var batting = GetBattingStatsForPlayer(reader);
                var pitching = GetPitchingStatsForPlayer(reader);

                yield return new PlayerInLineup(id, FirstName, SecondName, dob, Place, number, Lineup, Team,
                    NumberInLineup, BattingHand, PitchingHand, batting, pitching);
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
                var FirstName = (string)reader["PlayerFirstName"];
                var SecondName = (string)reader["PlayerSecondName"];
                var number = (int)reader["PlayerNumber"];
                var Place = (string)reader["PlaceOfBirth"];
                var dob = (DateTime)reader["PlayerDateOfBirth"];
                var Team = (string)reader["TeamID"];
                var Lineup = (int)reader["LineupType"];
                var NumberInLineup = (int)reader["PositionInLineup"];
                var Batting = (string)reader["PlayerBattingHand"];
                var Pitching = (string)reader["PlayerPitchingHand"];
                var Position = (string)reader["PlayerPosition"];

                var batting = GetBattingStatsForPlayer(reader);
                var pitching = GetPitchingStatsForPlayer(reader);

                yield return new PlayerInLineup(id, FirstName, SecondName, dob, Place, number, Lineup, Team,
                    Position, NumberInLineup, Batting, Pitching, batting, pitching);
            }
        }

        public IEnumerable<Batter> GetCurrentLineupForThisMatch(string team, int Match)
        {
            using var command = new SqlCommand("GetCurrentLineupForThisMatch", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
            command.Parameters.Add("@Match", SqlDbType.Int);
            command.Prepare();
            command.Parameters[0].Value = team;
            command.Parameters[1].Value = Match;
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
                var teamID = (string)reader["TeamID"];
                var inActiveRoster = (bool)reader["InActiveRoster"];
                var PositionInLineup = (int)reader["NumberInLineup"];
                var Position = (string)reader["PlayerPosition"];

                var batting = GetBattingStatsForPlayer(reader);
                var pitching = GetPitchingStatsForPlayer(reader);

                yield return new Batter(id, firstName, secondName, number, placeOfBirth, dateOfBirth,
                    battingHand, pitchingHand, teamID, inActiveRoster, Position, PositionInLineup, batting,
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
                var teamID = (string)reader["TeamID"];
                var inActiveRoster = (bool)reader["InActiveRoster"];
                var PositionInLineup = (int)reader["PlayerPositionInLineup"];
                var Position = (string)reader["PlayerPosition"];

                var batting = GetBattingStatsForPlayer(reader);
                var pitching = GetPitchingStatsForPlayer(reader);

                yield return new Pitcher(id, firstName, secondName, number, placeOfBirth, dateOfBirth,
                    battingHand, pitchingHand, teamID, inActiveRoster, PositionInLineup, Position != "P",
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
                var teamID = (string)reader["TeamID"];
                var inActiveRoster = (bool)reader["InActiveRoster"];
                var PositionInLineup = (int)reader["NumberInLineup"];
                var Position = (string)reader["PlayerPosition"];

                var batting = GetBattingStatsForPlayer(reader);
                var pitching = GetPitchingStatsForPlayer(reader);

                var player = new Pitcher(id, firstName, secondName, number, placeOfBirth, dateOfBirth,
                    battingHand, pitchingHand, teamID, inActiveRoster, PositionInLineup, Position != "P",
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
                var teamID = (string)reader["TeamID"];
                var inActiveRoster = (bool)reader["InActiveRoster"];
                var Position = (string)reader["PlayerPositionID"];

                var batting = GetBattingStatsForPlayer(reader);
                var pitching = GetPitchingStatsForPlayer(reader);

                yield return new Batter(id, firstName, secondName, number, placeOfBirth, dateOfBirth,
                    battingHand, pitchingHand, teamID, inActiveRoster, Position, batter.NumberInBattingLineup,
                    batting,
                    pitching);
            }
        }
        public BattingStats GetBattingStatsForPlayer(SqlDataReader reader)
        {
            var Games = (int)reader["BatterG"];
            var Strikeouts = (int)reader["BatterK"];
            var Walks = (int)reader["BatterBB"];
            var HitByPitch = (int)reader["BatterHBP"];
            var Flyout = (int)reader["BatterAO"];
            var Groundout = (int)reader["BatterGO"];
            var Popout = (int)reader["BatterPO"];
            var Single = (int)reader["Batter1B"];
            var Double = (int)reader["Batter2B"];
            var Triple = (int)reader["Batter3B"];
            var HomeRun = (int)reader["BatterHR"];
            var StolenBase = (int)reader["BatterSB"];
            var CaughtStealing = (int)reader["BatterCS"];
            var Runs = (int)reader["BatterR"];
            var SacFlies = (int)reader["BatterSF"];
            var Bunts = (int)reader["BatterSAC"];
            var RBI = (int)reader["BatterRBI"];
            var PA = (int)reader["BatterPA"];
            var GIDP = (int)reader["BatterGIDP"];
            var TGP = (int)reader["BatterTGP"];
            return new BattingStats(Games, Single, Double, Triple,
                HomeRun, SacFlies, Bunts, RBI, HitByPitch, StolenBase, CaughtStealing,
                Runs, Walks, Strikeouts, Groundout, Flyout, Popout, PA, GIDP, TGP);
        }

        public PitchingStats GetPitchingStatsForPlayer(SqlDataReader reader)
        {
            var TGP = (int)reader["BatterTGP"];
            var PitcherG = (int)reader["PitcherG"];
            var PitcherGS = (int)reader["PitcherGS"];
            var PitcherK = (int)reader["PitcherK"];
            var PitcherOuts = (int)reader["PitcherOuts"];
            var PitcherR = (int)reader["PitcherR"];
            var PitcherBB = (int)reader["PitcherBB"];
            var Pitcher1B = (int)reader["Pitcher1B"];
            var Pitcher2B = (int)reader["Pitcher2B"];
            var Pitcher3B = (int)reader["Pitcher3B"];
            var PitcherHR = (int)reader["PitcherHR"];
            var PitcherTBF = (int)reader["PitcherTBF"];
            var PitcherHBP = (int)reader["PitcherHBP"];
            var PitcherSF = (int)reader["PitcherSF"];
            var PitcherSAC = (int)reader["PitcherSAC"];
            var PitcherSB = (int)reader["PitcherSB"];
            var PitcherCS = (int)reader["PitcherCS"];
            var PitcherGIDP = (int)reader["PitcherGIDP"];
            var PitcherQS = (int)reader["PitcherQS"];
            var PitcherCG = (int)reader["PitcherCG"];
            var PitcherSHO = (int)reader["PitcherSHO"];
            var PitcherAO = (int)reader["PitcherAO"];
            var PitcherGO = (int)reader["PitcherGO"];
            var PitcherW = (int)reader["PitcherW"];
            var PitcherL = (int)reader["PitcherL"];
            var PitcherSV = (int)reader["PitcherSV"];
            var PitcherHLD = (int)reader["PitcherHLD"];
            return new PitchingStats(PitcherG, PitcherGS, PitcherK, PitcherOuts,
                                     PitcherBB, PitcherSAC, PitcherSF, PitcherSB, PitcherCS, PitcherTBF,
                                     PitcherQS, PitcherSHO, PitcherCG, PitcherW, PitcherL, PitcherSV, PitcherHLD,
                                     PitcherHBP, Pitcher1B, Pitcher2B, Pitcher3B, PitcherHR, PitcherR, PitcherGIDP,
                                     PitcherGO, PitcherAO, TGP);
        }
    }
}