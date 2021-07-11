using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace VKR.DAL
{
    public class PlayerDAO : DAO
    {

        public PlayerDAO()
        {
            InitConnection();
        }

        public IEnumerable<Batter> GetBattersStats()
        {
            using (SqlCommand command = new SqlCommand("ReturnBatterStatistics", _connection))
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
                        int Games = (int)reader["G"];
                        int Strikeouts = (int)reader["K"];
                        int Walks = (int)reader["BB"];
                        int HitByPitch = (int)reader["HBP"];
                        int Flyout = (int)reader["AO"];
                        int Groundout = (int)reader["GO"];
                        int Popout = (int)reader["PO"];
                        int Single = (int)reader["1B"];
                        int Double = (int)reader["2B"];
                        int Triple = (int)reader["3B"];
                        int HomeRun = (int)reader["HR"];
                        int StolenBase = (int)reader["SB"];
                        int CaughtStealing = (int)reader["CS"];
                        int Runs = (int)reader["R"];
                        int SacFlies = (int)reader["SF"];
                        int Bunts = (int)reader["SAC"];
                        int RBI = (int)reader["RBI"]; ;
                        int PA = (int)reader["PA"];
                        int GIDP = (int)reader["GIDP"];
                        int TGP = (int)reader["TGP"];
                        string Batting = (string)reader["PlayerBattingHand"];
                        string Pitching = (string)reader["PlayerPitchingHand"];
                        string team = (string)reader["TeamID"];
                        yield return new Batter(id, FirstName, SecondName, number, Games, Single, Double, Triple, 
                                                HomeRun, SacFlies, Bunts, RBI, HitByPitch, StolenBase, CaughtStealing, 
                                                Runs, Walks, Strikeouts, Groundout, Flyout, Popout, PA, GIDP, TGP, 
                                                Batting, Pitching, team);
                    }
                }
            }
        }

        public IEnumerable<Pitcher> GetPitcherByCode(int code)
        {
            using (SqlCommand command = new SqlCommand("GetPitcherStatsByCode", _connection))
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
                        string FirstName = (string)reader["PlayerFirstName"];
                        string SecondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        int Games = (int)reader["G"];
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
                        int TGP = (int)reader["TGP"];
                        int Wins = (int)reader["W"];
                        int Losses = (int)reader["L"];
                        int Saves = (int)reader["SV"];
                        int Holds = (int)reader["HLD"];
                        string Batting = (string)reader["PlayerBattingHand"];
                        string Pitching = (string)reader["PlayerPitchingHand"];
                        yield return new Pitcher(id, FirstName, SecondName, number, Games, Strikeouts, Outs, 
                                                 Walks, Bunts, SacFlies, StolenBase, CaughtStealing, BattersFaced, 
                                                 QualityStarts, Shutouts, CompleteGames, Wins, Losses, Saves, Holds, 
                                                 HitByPitch, Single, Double, Triple, HomeRun, Runs, DoublePlay, TGP, 
                                                 Groundout, Flyout, "", Batting, Pitching);
                    }
                }
            }
        }

        public IEnumerable<Batter> GetBatterByCode(int code)
        {
            using (SqlCommand command = new SqlCommand("GetBatterStatsByCode", _connection))
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
                        string FirstName = (string)reader["PlayerFirstName"];
                        string SecondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        int Games = (int)reader["G"];
                        int Strikeouts = (int)reader["K"];
                        int Walks = (int)reader["BB"];
                        int HitByPitch = (int)reader["HBP"];
                        int Flyout = (int)reader["AO"];
                        int Groundout = (int)reader["GO"];
                        int Popout = (int)reader["PO"];
                        int Single = (int)reader["1B"];
                        int Double = (int)reader["2B"];
                        int Triple = (int)reader["3B"];
                        int HomeRun = (int)reader["HR"];
                        int StolenBase = (int)reader["SB"];
                        int CaughtStealing = (int)reader["CS"];
                        int Runs = (int)reader["R"];
                        int SacFlies = (int)reader["SF"];
                        int Bunts = (int)reader["SAC"];
                        int RBI = (int)reader["RBI"]; ;
                        int PA = (int)reader["PA"];
                        int GIDP = (int)reader["GIDP"];
                        int TGP = (int)reader["TGP"];
                        string Batting = (string)reader["PlayerBattingHand"];
                        string Pitching = (string)reader["PlayerPitchingHand"];
                        yield return new Batter(id, FirstName, SecondName, number, Games, Single, Double, Triple, 
                                                HomeRun, SacFlies, Bunts, RBI, HitByPitch, StolenBase, CaughtStealing, 
                                                Runs, Walks, Strikeouts, Groundout, Flyout, Popout, PA, GIDP, TGP, 
                                                Batting, Pitching, "");
                    }
                }
            }
        }

        public IEnumerable<Pitcher> GetPitchersStats()
        {
            using (SqlCommand command = new SqlCommand("ReturnPitcherStatistics", _connection))
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
                        int Games = (int)reader["G"];
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
                        int TGP = (int)reader["TGP"];
                        string team = (string)reader["TeamID"];
                        int Wins = (int)reader["W"];
                        int Losses = (int)reader["L"];
                        int Saves = (int)reader["SV"];
                        int Holds = (int)reader["HLD"];
                        string Batting = (string)reader["PlayerBattingHand"];
                        string Pitching = (string)reader["PlayerPitchingHand"];
                        yield return new Pitcher(id, FirstName, SecondName, number, Games, Strikeouts, Outs, 
                                                 Walks, Bunts, SacFlies, StolenBase, CaughtStealing, BattersFaced, 
                                                 QualityStarts, Shutouts, CompleteGames, Wins, Losses, Saves, Holds, 
                                                 HitByPitch, Single, Double, Triple, HomeRun, Runs, DoublePlay, TGP, 
                                                 Groundout, Flyout, team, Batting, Pitching);
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

        public IEnumerable<PlayerInLineup> GetStartingLineups()
        {
            List<PlayerInLineup> players = new List<PlayerInLineup>();
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
                        int NumberInLineup = (int)reader["PlayerPositionInLineup"];
                        string Position = (string)reader["PlayerPosition"];
                        string Batting = (string)reader["PlayerBattingHand"];
                        string Pitching = (string)reader["PlayerPitchingHand"];
                        players.Add(new PlayerInLineup(id, FirstName, SecondName, dob, Place, number, Lineup, Team, Position, NumberInLineup, Batting, Pitching));
                    }
                }
            }
            return players;
        }

        public IEnumerable<PlayerInLineup> GetBench()
        {
            using (SqlCommand command = new SqlCommand("GetBench", _connection))
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
                        yield return new PlayerInLineup(id, FirstName, SecondName, dob, Place, number, Lineup, Team, NumberInLineup, Batting, Pitching);
                    }
                }
            }
        }

        public IEnumerable<Batter> GetPlayerNameByID(int code)
        {
            using (SqlCommand command = new SqlCommand("GetPlayerNameByID", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Code", SqlDbType.Int);
                command.Prepare();
                command.Parameters[0].Value = code;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string FirstName = (string)reader["PlayerFirstName"];
                        string SecondName = (string)reader["PlayerSecondName"];
                        yield return new Batter(FirstName, SecondName);
                    }
                }
            }
        }
    }
}