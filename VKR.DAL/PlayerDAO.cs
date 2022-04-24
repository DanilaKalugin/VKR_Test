using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace VKR.DAL
{
    public class PlayerDAO : DAO
    {
        public PlayerDAO() : base() { }

        public IEnumerable<Player> GetAllPlayers()
        {
            List<Player> players = new List<Player>();
            using (SqlCommand command = new SqlCommand("GetAllPlayers", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Prepare();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["PlayerID"];
                        string firstName = (string)reader["PlayerFirstName"];
                        string secondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        string placeOfBirth = (string)reader["PlaceOfBirth"];
                        DateTime dateOfBirth = (DateTime)reader["PlayerDateOfBirth"];
                        string battingHand = (string)reader["PlayerBattingHand"];
                        string pitchingHand = (string)reader["PlayerPitchingHand"];
                        string team = (string)reader["TeamID"];
                        bool inActiveRoster = (bool)reader["InActiveRoster"];

                        int Games = (int)reader["BatterG"];
                        int Strikeouts = (int)reader["BatterK"];
                        int Walks = (int)reader["BatterBB"];
                        int HitByPitch = (int)reader["BatterHBP"];
                        int Flyout = (int)reader["BatterAO"];
                        int Groundout = (int)reader["BatterGO"];
                        int Popout = (int)reader["BatterPO"];
                        int Single = (int)reader["Batter1B"];
                        int Double = (int)reader["Batter2B"];
                        int Triple = (int)reader["Batter3B"];
                        int HomeRun = (int)reader["BatterHR"];
                        int StolenBase = (int)reader["BatterSB"];
                        int CaughtStealing = (int)reader["BatterCS"];
                        int Runs = (int)reader["BatterR"];
                        int SacFlies = (int)reader["BatterSF"];
                        int Bunts = (int)reader["BatterSAC"];
                        int RBI = (int)reader["BatterRBI"];
                        int PA = (int)reader["BatterPA"];
                        int GIDP = (int)reader["BatterGIDP"];
                        int TGP = (int)reader["BatterTGP"];
                        var batting = new BattingStats(Games, Single, Double, Triple,
                                                HomeRun, SacFlies, Bunts, RBI, HitByPitch, StolenBase, CaughtStealing,
                                                Runs, Walks, Strikeouts, Groundout, Flyout, Popout, PA, GIDP, TGP);

                        int PitcherG = (int)reader["PitcherG"];
                        int PitcherGS = (int)reader["PitcherGS"];
                        int PitcherK = (int)reader["PitcherK"];
                        int PitcherOuts = (int)reader["PitcherOuts"];
                        int PitcherR = (int)reader["PitcherR"];
                        int PitcherBB = (int)reader["PitcherBB"];
                        int Pitcher1B = (int)reader["Pitcher1B"];
                        int Pitcher2B = (int)reader["Pitcher2B"];
                        int Pitcher3B = (int)reader["Pitcher3B"];
                        int PitcherHR = (int)reader["PitcherHR"];
                        int PitcherTBF = (int)reader["PitcherTBF"];
                        int PitcherHBP = (int)reader["PitcherHBP"];
                        int PitcherSF = (int)reader["PitcherSF"];
                        int PitcherSAC = (int)reader["PitcherSAC"];
                        int PitcherSB = (int)reader["PitcherSB"];
                        int PitcherCS = (int)reader["PitcherCS"];
                        int PitcherGIDP = (int)reader["PitcherGIDP"];
                        int PitcherQS = (int)reader["PitcherQS"];
                        int PitcherCG = (int)reader["PitcherCG"];
                        int PitcherSHO = (int)reader["PitcherSHO"];
                        int PitcherAO = (int)reader["PitcherAO"];
                        int PitcherGO = (int)reader["PitcherGO"];
                        int PitcherW = (int)reader["PitcherW"];
                        int PitcherL = (int)reader["PitcherL"];
                        int PitcherSV = (int)reader["PitcherSV"];
                        int PitcherHLD = (int)reader["PitcherHLD"];
                        var pitching =  new PitchingStats(PitcherG, PitcherGS, PitcherK, PitcherOuts,
                                                 PitcherBB, PitcherSAC, PitcherSF, PitcherSB, PitcherCS, PitcherTBF,
                                                 PitcherQS, PitcherSHO, PitcherCG, PitcherW, PitcherL, PitcherSV, PitcherHLD,
                                                 PitcherHBP, Pitcher1B, Pitcher2B, Pitcher3B, PitcherHR, PitcherR, PitcherGIDP,
                                                 PitcherGO, PitcherAO, TGP);

                        Player player = new Player(id, firstName, secondName, number, placeOfBirth, dateOfBirth, battingHand, pitchingHand, team, inActiveRoster, batting, pitching);

                        players.Add(player);
                    }
                }
            }
            foreach (Player player1 in players)
            {
                player1.PlayerPositions = GetPositionsForThisPlayer(player1.Id).ToList();
            }
            return players;
        }

        public IEnumerable<PitchingStats> GetPitchingStatsByCode(Pitcher pitcher)
        {
            using (SqlCommand command = new SqlCommand("GetPitcherStatsByCode", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Code", SqlDbType.Int);
                command.Prepare();
                command.Parameters[0].Value = pitcher.Id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Games = (int)reader["G"];
                        int GamesStarted = (int)reader["GS"];
                        int Strikeouts = (int)reader["K"];
                        int Outs = (int)reader["Outs"];
                        int Runs = (int)reader["R"];
                        int Walks = (int)reader["BB"];
                        int Single = (int)reader["1B"];
                        int Double = (int)reader["2B"];
                        int Triple = (int)reader["3B"];
                        int HomeRun = (int)reader["HR"];
                        int BattersFaced = (int)reader["TBF"];
                        int HitByPitch = (int)reader["HBP"];
                        int SacFlies = (int)reader["SF"];
                        int Bunts = (int)reader["SAC"];
                        int StolenBase = (int)reader["SB"];
                        int CaughtStealing = (int)reader["CS"];
                        int DoublePlay = (int)reader["GIDP"];
                        int QualityStarts = (int)reader["QS"];
                        int CompleteGames = (int)reader["CG"];
                        int Shutouts = (int)reader["SHO"];
                        int Flyout = (int)reader["AO"];
                        int Groundout = (int)reader["GO"];
                        int Wins = (int)reader["W"];
                        int Losses = (int)reader["L"];
                        int Saves = (int)reader["SV"];
                        int Holds = (int)reader["HLD"];
                        yield return new PitchingStats(Games, GamesStarted, Strikeouts, Outs,
                                                 Walks, Bunts, SacFlies, StolenBase, CaughtStealing, BattersFaced,
                                                 QualityStarts, Shutouts, CompleteGames, Wins, Losses, Saves, Holds,
                                                 HitByPitch, Single, Double, Triple, HomeRun, Runs, DoublePlay,
                                                 Groundout, Flyout, pitcher.pitchingStats.TGP);
                    }
                }
            }
        }

        public IEnumerable<Player> GetPlayerByCode(int code)
        {
            List<Player> players = new List<Player>();
            using (SqlCommand command = new SqlCommand("GetPlayerByCode", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Code", SqlDbType.Int);
                command.Prepare();
                command.Parameters[0].Value = code;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["PlayerID"];
                        string firstName = (string)reader["PlayerFirstName"];
                        string secondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        string placeOfBirth = (string)reader["PlaceOfBirth"];
                        DateTime dateOfBirth = (DateTime)reader["PlayerDateOfBirth"];
                        string battingHand = (string)reader["PlayerBattingHand"];
                        string pitchingHand = (string)reader["PlayerPitchingHand"];
                        string team = (string)reader["TeamID"];
                        bool inActiveRoster = (bool)reader["InActiveRoster"];

                        int Games = (int)reader["BatterG"];
                        int Strikeouts = (int)reader["BatterK"];
                        int Walks = (int)reader["BatterBB"];
                        int HitByPitch = (int)reader["BatterHBP"];
                        int Flyout = (int)reader["BatterAO"];
                        int Groundout = (int)reader["BatterGO"];
                        int Popout = (int)reader["BatterPO"];
                        int Single = (int)reader["Batter1B"];
                        int Double = (int)reader["Batter2B"];
                        int Triple = (int)reader["Batter3B"];
                        int HomeRun = (int)reader["BatterHR"];
                        int StolenBase = (int)reader["BatterSB"];
                        int CaughtStealing = (int)reader["BatterCS"];
                        int Runs = (int)reader["BatterR"];
                        int SacFlies = (int)reader["BatterSF"];
                        int Bunts = (int)reader["BatterSAC"];
                        int RBI = (int)reader["BatterRBI"];
                        int PA = (int)reader["BatterPA"];
                        int GIDP = (int)reader["BatterGIDP"];
                        int TGP = (int)reader["BatterTGP"];
                        var batting = new BattingStats(Games, Single, Double, Triple,
                                                HomeRun, SacFlies, Bunts, RBI, HitByPitch, StolenBase, CaughtStealing,
                                                Runs, Walks, Strikeouts, Groundout, Flyout, Popout, PA, GIDP, TGP);

                        int PitcherG = (int)reader["PitcherG"];
                        int PitcherGS = (int)reader["PitcherGS"];
                        int PitcherK = (int)reader["PitcherK"];
                        int PitcherOuts = (int)reader["PitcherOuts"];
                        int PitcherR = (int)reader["PitcherR"];
                        int PitcherBB = (int)reader["PitcherBB"];
                        int Pitcher1B = (int)reader["Pitcher1B"];
                        int Pitcher2B = (int)reader["Pitcher2B"];
                        int Pitcher3B = (int)reader["Pitcher3B"];
                        int PitcherHR = (int)reader["PitcherHR"];
                        int PitcherTBF = (int)reader["PitcherTBF"];
                        int PitcherHBP = (int)reader["PitcherHBP"];
                        int PitcherSF = (int)reader["PitcherSF"];
                        int PitcherSAC = (int)reader["PitcherSAC"];
                        int PitcherSB = (int)reader["PitcherSB"];
                        int PitcherCS = (int)reader["PitcherCS"];
                        int PitcherGIDP = (int)reader["PitcherGIDP"];
                        int PitcherQS = (int)reader["PitcherQS"];
                        int PitcherCG = (int)reader["PitcherCG"];
                        int PitcherSHO = (int)reader["PitcherSHO"];
                        int PitcherAO = (int)reader["PitcherAO"];
                        int PitcherGO = (int)reader["PitcherGO"];
                        int PitcherW = (int)reader["PitcherW"];
                        int PitcherL = (int)reader["PitcherL"];
                        int PitcherSV = (int)reader["PitcherSV"];
                        int PitcherHLD = (int)reader["PitcherHLD"];
                        var pitching = new PitchingStats(PitcherG, PitcherGS, PitcherK, PitcherOuts,
                                                 PitcherBB, PitcherSAC, PitcherSF, PitcherSB, PitcherCS, PitcherTBF,
                                                 PitcherQS, PitcherSHO, PitcherCG, PitcherW, PitcherL, PitcherSV, PitcherHLD,
                                                 PitcherHBP, Pitcher1B, Pitcher2B, Pitcher3B, PitcherHR, PitcherR, PitcherGIDP,
                                                 PitcherGO, PitcherAO, TGP);

                        yield return new Player(id, firstName, secondName, number, placeOfBirth, dateOfBirth, battingHand, pitchingHand, team, inActiveRoster, batting, pitching);
                    }
                }
            }
        }

        public IEnumerable<string> GetPositionsForThisPlayer(int code)
        {
            using (SqlCommand command = new SqlCommand("GetPlayerPositions", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Code", SqlDbType.Int);
                command.Prepare();
                command.Parameters[0].Value = code;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return (string)reader["PlayerPositionID"];
                    }
                }
            }
        }

        public IEnumerable<PlayerPosition> GetPlayerPositions()
        {
            using (SqlCommand command = new SqlCommand("GetAllPlayerPositions", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Prepare();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Code = (string)reader["PositionCode"];
                        string Full = (string)reader["PositionFullTitle"];
                        yield return new PlayerPosition(Code, Full);
                    }
                }
            }
        }

        public IEnumerable<PlayerInLineup> GetRoster(string rosterType)
        {
            using (SqlCommand command = new SqlCommand(rosterType, _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Prepare();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["PlayerID"];
                        string FirstName = (string)reader["PlayerFirstName"];
                        string SecondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        string Place = (string)reader["PlaceOfBirth"];
                        DateTime dob = (DateTime)reader["PlayerDateOfBirth"];
                        string Team = (string)reader["TeamID"];
                        int Lineup = (int)reader["LineupType"];
                        int NumberInLineup = (int)reader["PositionInLineup"];
                        string BattingHand = (string)reader["PlayerBattingHand"];
                        string PitchingHand = (string)reader["PlayerPitchingHand"];

                        int Games = (int)reader["BatterG"];
                        int Strikeouts = (int)reader["BatterK"];
                        int Walks = (int)reader["BatterBB"];
                        int HitByPitch = (int)reader["BatterHBP"];
                        int Flyout = (int)reader["BatterAO"];
                        int Groundout = (int)reader["BatterGO"];
                        int Popout = (int)reader["BatterPO"];
                        int Single = (int)reader["Batter1B"];
                        int Double = (int)reader["Batter2B"];
                        int Triple = (int)reader["Batter3B"];
                        int HomeRun = (int)reader["BatterHR"];
                        int StolenBase = (int)reader["BatterSB"];
                        int CaughtStealing = (int)reader["BatterCS"];
                        int Runs = (int)reader["BatterR"];
                        int SacFlies = (int)reader["BatterSF"];
                        int Bunts = (int)reader["BatterSAC"];
                        int RBI = (int)reader["BatterRBI"];
                        int PA = (int)reader["BatterPA"];
                        int GIDP = (int)reader["BatterGIDP"];
                        int TGP = (int)reader["BatterTGP"];
                        var batting = new BattingStats(Games, Single, Double, Triple,
                                                HomeRun, SacFlies, Bunts, RBI, HitByPitch, StolenBase, CaughtStealing,
                                                Runs, Walks, Strikeouts, Groundout, Flyout, Popout, PA, GIDP, TGP);

                        int PitcherG = (int)reader["PitcherG"];
                        int PitcherGS = (int)reader["PitcherGS"];
                        int PitcherK = (int)reader["PitcherK"];
                        int PitcherOuts = (int)reader["PitcherOuts"];
                        int PitcherR = (int)reader["PitcherR"];
                        int PitcherBB = (int)reader["PitcherBB"];
                        int Pitcher1B = (int)reader["Pitcher1B"];
                        int Pitcher2B = (int)reader["Pitcher2B"];
                        int Pitcher3B = (int)reader["Pitcher3B"];
                        int PitcherHR = (int)reader["PitcherHR"];
                        int PitcherTBF = (int)reader["PitcherTBF"];
                        int PitcherHBP = (int)reader["PitcherHBP"];
                        int PitcherSF = (int)reader["PitcherSF"];
                        int PitcherSAC = (int)reader["PitcherSAC"];
                        int PitcherSB = (int)reader["PitcherSB"];
                        int PitcherCS = (int)reader["PitcherCS"];
                        int PitcherGIDP = (int)reader["PitcherGIDP"];
                        int PitcherQS = (int)reader["PitcherQS"];
                        int PitcherCG = (int)reader["PitcherCG"];
                        int PitcherSHO = (int)reader["PitcherSHO"];
                        int PitcherAO = (int)reader["PitcherAO"];
                        int PitcherGO = (int)reader["PitcherGO"];
                        int PitcherW = (int)reader["PitcherW"];
                        int PitcherL = (int)reader["PitcherL"];
                        int PitcherSV = (int)reader["PitcherSV"];
                        int PitcherHLD = (int)reader["PitcherHLD"];
                        var pitching = new PitchingStats(PitcherG, PitcherGS, PitcherK, PitcherOuts,
                                                 PitcherBB, PitcherSAC, PitcherSF, PitcherSB, PitcherCS, PitcherTBF,
                                                 PitcherQS, PitcherSHO, PitcherCG, PitcherW, PitcherL, PitcherSV, PitcherHLD,
                                                 PitcherHBP, Pitcher1B, Pitcher2B, Pitcher3B, PitcherHR, PitcherR, PitcherGIDP,
                                                 PitcherGO, PitcherAO, TGP);

                        yield return new PlayerInLineup(id, FirstName, SecondName, dob, Place, number, Lineup, Team, NumberInLineup, BattingHand, PitchingHand, batting, pitching);
                    }
                }
            }
        }

        public IEnumerable<PlayerInLineup> GetStartingLineups()
        {
            using (SqlCommand command = new SqlCommand("GetStartingLineups", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Prepare();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["PlayerID"];
                        string FirstName = (string)reader["PlayerFirstName"];
                        string SecondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        string Place = (string)reader["PlaceOfBirth"];
                        DateTime dob = (DateTime)reader["PlayerDateOfBirth"];
                        string Team = (string)reader["TeamID"];
                        int Lineup = (int)reader["LineupType"];
                        int NumberInLineup = (int)reader["PositionInLineup"];
                        string Batting = (string)reader["PlayerBattingHand"];
                        string Pitching = (string)reader["PlayerPitchingHand"];
                        string Position = (string)reader["PlayerPosition"];

                        int Games = (int)reader["BatterG"];
                        int Strikeouts = (int)reader["BatterK"];
                        int Walks = (int)reader["BatterBB"];
                        int HitByPitch = (int)reader["BatterHBP"];
                        int Flyout = (int)reader["BatterAO"];
                        int Groundout = (int)reader["BatterGO"];
                        int Popout = (int)reader["BatterPO"];
                        int Single = (int)reader["Batter1B"];
                        int Double = (int)reader["Batter2B"];
                        int Triple = (int)reader["Batter3B"];
                        int HomeRun = (int)reader["BatterHR"];
                        int StolenBase = (int)reader["BatterSB"];
                        int CaughtStealing = (int)reader["BatterCS"];
                        int Runs = (int)reader["BatterR"];
                        int SacFlies = (int)reader["BatterSF"];
                        int Bunts = (int)reader["BatterSAC"];
                        int RBI = (int)reader["BatterRBI"];
                        int PA = (int)reader["BatterPA"];
                        int GIDP = (int)reader["BatterGIDP"];
                        int TGP = (int)reader["BatterTGP"];
                        var batting = new BattingStats(Games, Single, Double, Triple,
                                                HomeRun, SacFlies, Bunts, RBI, HitByPitch, StolenBase, CaughtStealing,
                                                Runs, Walks, Strikeouts, Groundout, Flyout, Popout, PA, GIDP, TGP);

                        int PitcherG = (int)reader["PitcherG"];
                        int PitcherGS = (int)reader["PitcherGS"];
                        int PitcherK = (int)reader["PitcherK"];
                        int PitcherOuts = (int)reader["PitcherOuts"];
                        int PitcherR = (int)reader["PitcherR"];
                        int PitcherBB = (int)reader["PitcherBB"];
                        int Pitcher1B = (int)reader["Pitcher1B"];
                        int Pitcher2B = (int)reader["Pitcher2B"];
                        int Pitcher3B = (int)reader["Pitcher3B"];
                        int PitcherHR = (int)reader["PitcherHR"];
                        int PitcherTBF = (int)reader["PitcherTBF"];
                        int PitcherHBP = (int)reader["PitcherHBP"];
                        int PitcherSF = (int)reader["PitcherSF"];
                        int PitcherSAC = (int)reader["PitcherSAC"];
                        int PitcherSB = (int)reader["PitcherSB"];
                        int PitcherCS = (int)reader["PitcherCS"];
                        int PitcherGIDP = (int)reader["PitcherGIDP"];
                        int PitcherQS = (int)reader["PitcherQS"];
                        int PitcherCG = (int)reader["PitcherCG"];
                        int PitcherSHO = (int)reader["PitcherSHO"];
                        int PitcherAO = (int)reader["PitcherAO"];
                        int PitcherGO = (int)reader["PitcherGO"];
                        int PitcherW = (int)reader["PitcherW"];
                        int PitcherL = (int)reader["PitcherL"];
                        int PitcherSV = (int)reader["PitcherSV"];
                        int PitcherHLD = (int)reader["PitcherHLD"];
                        var pitching = new PitchingStats(PitcherG, PitcherGS, PitcherK, PitcherOuts,
                                                 PitcherBB, PitcherSAC, PitcherSF, PitcherSB, PitcherCS, PitcherTBF,
                                                 PitcherQS, PitcherSHO, PitcherCG, PitcherW, PitcherL, PitcherSV, PitcherHLD,
                                                 PitcherHBP, Pitcher1B, Pitcher2B, Pitcher3B, PitcherHR, PitcherR, PitcherGIDP,
                                                 PitcherGO, PitcherAO, TGP);

                        yield return new PlayerInLineup(id, FirstName, SecondName, dob, Place, number, Lineup, Team, Position, NumberInLineup, Batting, Pitching, batting, pitching);
                    }
                }
            }
        }

        public IEnumerable<Batter> GetCurrentLineupForThisMatch(string team, int Match)
        {
            using (SqlCommand command = new SqlCommand("GetCurrentLineupForThisMatch", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Parameters.Add("@Match", SqlDbType.Int);
                command.Prepare();
                command.Parameters[0].Value = team;
                command.Parameters[1].Value = Match;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["PlayerID"];
                        string firstName = (string)reader["PlayerFirstName"];
                        string secondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        string placeOfBirth = (string)reader["PlaceOfBirth"];
                        DateTime dateOfBirth = (DateTime)reader["PlayerDateOfBirth"];
                        string battingHand = (string)reader["PlayerBattingHand"];
                        string pitchingHand = (string)reader["PlayerPitchingHand"];
                        string teamID = (string)reader["TeamID"];
                        bool inActiveRoster = (bool)reader["InActiveRoster"];
                        int PositionInLineup = (int)reader["NumberInLineup"];
                        string Position = (string)reader["PlayerPosition"];

                        int Games = (int)reader["BatterG"];
                        int Strikeouts = (int)reader["BatterK"];
                        int Walks = (int)reader["BatterBB"];
                        int HitByPitch = (int)reader["BatterHBP"];
                        int Flyout = (int)reader["BatterAO"];
                        int Groundout = (int)reader["BatterGO"];
                        int Popout = (int)reader["BatterPO"];
                        int Single = (int)reader["Batter1B"];
                        int Double = (int)reader["Batter2B"];
                        int Triple = (int)reader["Batter3B"];
                        int HomeRun = (int)reader["BatterHR"];
                        int StolenBase = (int)reader["BatterSB"];
                        int CaughtStealing = (int)reader["BatterCS"];
                        int Runs = (int)reader["BatterR"];
                        int SacFlies = (int)reader["BatterSF"];
                        int Bunts = (int)reader["BatterSAC"];
                        int RBI = (int)reader["BatterRBI"];
                        int PA = (int)reader["BatterPA"];
                        int GIDP = (int)reader["BatterGIDP"];
                        int TGP = (int)reader["BatterTGP"];
                        var batting = new BattingStats(Games, Single, Double, Triple,
                                                HomeRun, SacFlies, Bunts, RBI, HitByPitch, StolenBase, CaughtStealing,
                                                Runs, Walks, Strikeouts, Groundout, Flyout, Popout, PA, GIDP, TGP);

                        int PitcherG = (int)reader["PitcherG"];
                        int PitcherGS = (int)reader["PitcherGS"];
                        int PitcherK = (int)reader["PitcherK"];
                        int PitcherOuts = (int)reader["PitcherOuts"];
                        int PitcherR = (int)reader["PitcherR"];
                        int PitcherBB = (int)reader["PitcherBB"];
                        int Pitcher1B = (int)reader["Pitcher1B"];
                        int Pitcher2B = (int)reader["Pitcher2B"];
                        int Pitcher3B = (int)reader["Pitcher3B"];
                        int PitcherHR = (int)reader["PitcherHR"];
                        int PitcherTBF = (int)reader["PitcherTBF"];
                        int PitcherHBP = (int)reader["PitcherHBP"];
                        int PitcherSF = (int)reader["PitcherSF"];
                        int PitcherSAC = (int)reader["PitcherSAC"];
                        int PitcherSB = (int)reader["PitcherSB"];
                        int PitcherCS = (int)reader["PitcherCS"];
                        int PitcherGIDP = (int)reader["PitcherGIDP"];
                        int PitcherQS = (int)reader["PitcherQS"];
                        int PitcherCG = (int)reader["PitcherCG"];
                        int PitcherSHO = (int)reader["PitcherSHO"];
                        int PitcherAO = (int)reader["PitcherAO"];
                        int PitcherGO = (int)reader["PitcherGO"];
                        int PitcherW = (int)reader["PitcherW"];
                        int PitcherL = (int)reader["PitcherL"];
                        int PitcherSV = (int)reader["PitcherSV"];
                        int PitcherHLD = (int)reader["PitcherHLD"];
                        var pitching = new PitchingStats(PitcherG, PitcherGS, PitcherK, PitcherOuts,
                                                 PitcherBB, PitcherSAC, PitcherSF, PitcherSB, PitcherCS, PitcherTBF,
                                                 PitcherQS, PitcherSHO, PitcherCG, PitcherW, PitcherL, PitcherSV, PitcherHLD,
                                                 PitcherHBP, Pitcher1B, Pitcher2B, Pitcher3B, PitcherHR, PitcherR, PitcherGIDP,
                                                 PitcherGO, PitcherAO, TGP);

                        yield return new Batter(id, firstName, secondName, number, placeOfBirth, dateOfBirth, battingHand, pitchingHand, teamID, inActiveRoster, Position, PositionInLineup, batting, pitching);
                    }
                }
            }
        }

        public IEnumerable<Pitcher> GetStartingPitcherForThisTeam(Team team, Match match)
        {
            using (SqlCommand command = new SqlCommand("GetStartingPitcherForThisTeam", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Match", SqlDbType.Int);
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Prepare();
                command.Parameters[0].Value = match.MatchID;
                command.Parameters[1].Value = team.TeamAbbreviation;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["PlayerID"];
                        string firstName = (string)reader["PlayerFirstName"];
                        string secondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        string placeOfBirth = (string)reader["PlaceOfBirth"];
                        DateTime dateOfBirth = (DateTime)reader["PlayerDateOfBirth"];
                        string battingHand = (string)reader["PlayerBattingHand"];
                        string pitchingHand = (string)reader["PlayerPitchingHand"];
                        string teamID = (string)reader["TeamID"];
                        bool inActiveRoster = (bool)reader["InActiveRoster"];
                        int PositionInLineup = (int)reader["PlayerPositionInLineup"];
                        string Position = (string)reader["PlayerPosition"];

                        int Games = (int)reader["BatterG"];
                        int Strikeouts = (int)reader["BatterK"];
                        int Walks = (int)reader["BatterBB"];
                        int HitByPitch = (int)reader["BatterHBP"];
                        int Flyout = (int)reader["BatterAO"];
                        int Groundout = (int)reader["BatterGO"];
                        int Popout = (int)reader["BatterPO"];
                        int Single = (int)reader["Batter1B"];
                        int Double = (int)reader["Batter2B"];
                        int Triple = (int)reader["Batter3B"];
                        int HomeRun = (int)reader["BatterHR"];
                        int StolenBase = (int)reader["BatterSB"];
                        int CaughtStealing = (int)reader["BatterCS"];
                        int Runs = (int)reader["BatterR"];
                        int SacFlies = (int)reader["BatterSF"];
                        int Bunts = (int)reader["BatterSAC"];
                        int RBI = (int)reader["BatterRBI"];
                        int PA = (int)reader["BatterPA"];
                        int GIDP = (int)reader["BatterGIDP"];
                        int TGP = (int)reader["BatterTGP"];
                        var batting = new BattingStats(Games, Single, Double, Triple,
                                                HomeRun, SacFlies, Bunts, RBI, HitByPitch, StolenBase, CaughtStealing,
                                                Runs, Walks, Strikeouts, Groundout, Flyout, Popout, PA, GIDP, TGP);

                        int PitcherG = (int)reader["PitcherG"];
                        int PitcherGS = (int)reader["PitcherGS"];
                        int PitcherK = (int)reader["PitcherK"];
                        int PitcherOuts = (int)reader["PitcherOuts"];
                        int PitcherR = (int)reader["PitcherR"];
                        int PitcherBB = (int)reader["PitcherBB"];
                        int Pitcher1B = (int)reader["Pitcher1B"];
                        int Pitcher2B = (int)reader["Pitcher2B"];
                        int Pitcher3B = (int)reader["Pitcher3B"];
                        int PitcherHR = (int)reader["PitcherHR"];
                        int PitcherTBF = (int)reader["PitcherTBF"];
                        int PitcherHBP = (int)reader["PitcherHBP"];
                        int PitcherSF = (int)reader["PitcherSF"];
                        int PitcherSAC = (int)reader["PitcherSAC"];
                        int PitcherSB = (int)reader["PitcherSB"];
                        int PitcherCS = (int)reader["PitcherCS"];
                        int PitcherGIDP = (int)reader["PitcherGIDP"];
                        int PitcherQS = (int)reader["PitcherQS"];
                        int PitcherCG = (int)reader["PitcherCG"];
                        int PitcherSHO = (int)reader["PitcherSHO"];
                        int PitcherAO = (int)reader["PitcherAO"];
                        int PitcherGO = (int)reader["PitcherGO"];
                        int PitcherW = (int)reader["PitcherW"];
                        int PitcherL = (int)reader["PitcherL"];
                        int PitcherSV = (int)reader["PitcherSV"];
                        int PitcherHLD = (int)reader["PitcherHLD"];
                        var pitching = new PitchingStats(PitcherG, PitcherGS, PitcherK, PitcherOuts,
                                                 PitcherBB, PitcherSAC, PitcherSF, PitcherSB, PitcherCS, PitcherTBF,
                                                 PitcherQS, PitcherSHO, PitcherCG, PitcherW, PitcherL, PitcherSV, PitcherHLD,
                                                 PitcherHBP, Pitcher1B, Pitcher2B, Pitcher3B, PitcherHR, PitcherR, PitcherGIDP,
                                                 PitcherGO, PitcherAO, TGP);
                        yield return new Pitcher(id, firstName, secondName, number, placeOfBirth, dateOfBirth, battingHand, pitchingHand, teamID, inActiveRoster, PositionInLineup, Position != "P", batting, pitching);
                    }
                }
            }
        }

        public IEnumerable<Pitcher> GetAvailablePitchers(Match match, Team team)
        {
            using (SqlCommand command = new SqlCommand("GetAvailablePitchersForSubstitution", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Match", SqlDbType.Int);
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Prepare();
                command.Parameters[0].Value = match.MatchID;
                command.Parameters[1].Value = team.TeamAbbreviation;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["PlayerID"];
                        string firstName = (string)reader["PlayerFirstName"];
                        string secondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        string placeOfBirth = (string)reader["PlaceOfBirth"];
                        DateTime dateOfBirth = (DateTime)reader["PlayerDateOfBirth"];
                        string battingHand = (string)reader["PlayerBattingHand"];
                        string pitchingHand = (string)reader["PlayerPitchingHand"];
                        string teamID = (string)reader["TeamID"];
                        bool inActiveRoster = (bool)reader["InActiveRoster"];
                        int PositionInLineup = (int)reader["NumberInLineup"];
                        string Position = (string)reader["PlayerPosition"];

                        int Games = (int)reader["BatterG"];
                        int Strikeouts = (int)reader["BatterK"];
                        int Walks = (int)reader["BatterBB"];
                        int HitByPitch = (int)reader["BatterHBP"];
                        int Flyout = (int)reader["BatterAO"];
                        int Groundout = (int)reader["BatterGO"];
                        int Popout = (int)reader["BatterPO"];
                        int Single = (int)reader["Batter1B"];
                        int Double = (int)reader["Batter2B"];
                        int Triple = (int)reader["Batter3B"];
                        int HomeRun = (int)reader["BatterHR"];
                        int StolenBase = (int)reader["BatterSB"];
                        int CaughtStealing = (int)reader["BatterCS"];
                        int Runs = (int)reader["BatterR"];
                        int SacFlies = (int)reader["BatterSF"];
                        int Bunts = (int)reader["BatterSAC"];
                        int RBI = (int)reader["BatterRBI"];
                        int PA = (int)reader["BatterPA"];
                        int GIDP = (int)reader["BatterGIDP"];
                        int TGP = (int)reader["BatterTGP"];
                        var batting = new BattingStats(Games, Single, Double, Triple,
                                                HomeRun, SacFlies, Bunts, RBI, HitByPitch, StolenBase, CaughtStealing,
                                                Runs, Walks, Strikeouts, Groundout, Flyout, Popout, PA, GIDP, TGP);

                        int PitcherG = (int)reader["PitcherG"];
                        int PitcherGS = (int)reader["PitcherGS"];
                        int PitcherK = (int)reader["PitcherK"];
                        int PitcherOuts = (int)reader["PitcherOuts"];
                        int PitcherR = (int)reader["PitcherR"];
                        int PitcherBB = (int)reader["PitcherBB"];
                        int Pitcher1B = (int)reader["Pitcher1B"];
                        int Pitcher2B = (int)reader["Pitcher2B"];
                        int Pitcher3B = (int)reader["Pitcher3B"];
                        int PitcherHR = (int)reader["PitcherHR"];
                        int PitcherTBF = (int)reader["PitcherTBF"];
                        int PitcherHBP = (int)reader["PitcherHBP"];
                        int PitcherSF = (int)reader["PitcherSF"];
                        int PitcherSAC = (int)reader["PitcherSAC"];
                        int PitcherSB = (int)reader["PitcherSB"];
                        int PitcherCS = (int)reader["PitcherCS"];
                        int PitcherGIDP = (int)reader["PitcherGIDP"];
                        int PitcherQS = (int)reader["PitcherQS"];
                        int PitcherCG = (int)reader["PitcherCG"];
                        int PitcherSHO = (int)reader["PitcherSHO"];
                        int PitcherAO = (int)reader["PitcherAO"];
                        int PitcherGO = (int)reader["PitcherGO"];
                        int PitcherW = (int)reader["PitcherW"];
                        int PitcherL = (int)reader["PitcherL"];
                        int PitcherSV = (int)reader["PitcherSV"];
                        int PitcherHLD = (int)reader["PitcherHLD"];
                        var pitching = new PitchingStats(PitcherG, PitcherGS, PitcherK, PitcherOuts,
                                                 PitcherBB, PitcherSAC, PitcherSF, PitcherSB, PitcherCS, PitcherTBF,
                                                 PitcherQS, PitcherSHO, PitcherCG, PitcherW, PitcherL, PitcherSV, PitcherHLD,
                                                 PitcherHBP, Pitcher1B, Pitcher2B, Pitcher3B, PitcherHR, PitcherR, PitcherGIDP,
                                                 PitcherGO, PitcherAO, TGP);

                        var player = new Pitcher(id, firstName, secondName, number, placeOfBirth, dateOfBirth, battingHand, pitchingHand, teamID, inActiveRoster, PositionInLineup, Position != "P", batting, pitching);
                        yield return player;
                    }
                }
            }
        }

        public int GetNumberOfOutsPlayedByThisPitcherInLast5Days(int id)
        {
            using (SqlCommand command = new SqlCommand("GetRemainingStaminaForThisPitcher", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Pitcher", SqlDbType.Int);
                command.Prepare();
                command.Parameters[0].Value = id;

                return (int)command.ExecuteScalar();
            }
        }
    }
}