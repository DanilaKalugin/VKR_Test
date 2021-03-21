using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace VKR.DAL
{
    public class PlayerDAO : IDisposable
    {
        private SqlConnection _connection;

        public static string GetConnectionString()
        {
            var currentConnection = ConfigurationManager.AppSettings["CurrentConnectionString"];
            var connectionString = ConfigurationManager.ConnectionStrings[currentConnection].ConnectionString;
            return connectionString;
        }

        public PlayerDAO()
        {
            InitConnection();
        }

        private void InitConnection()
        {
            _connection = new SqlConnection(GetConnectionString());
            _connection.Open();
            _connection.StateChange += ConnectionStateChange;
        }

        void ConnectionStateChange(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState == ConnectionState.Broken)
            {
                InitConnection();
            }
        }

        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
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

                        yield return new Batter(id, FirstName, SecondName, number, Games, Single, Double, Triple, HomeRun, SacFlies, Bunts, RBI, HitByPitch, StolenBase, CaughtStealing, Runs, Walks, Strikeouts, Groundout, Flyout, Popout, PA, GIDP, TGP);
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
                        int TGP = (int)reader["TGP"];
                        yield return new Pitcher(id, FirstName, SecondName, number, Games, Strikeouts, Outs, Walks, Bunts, SacFlies, StolenBase, CaughtStealing, BattersFaced, QualityStarts, Shutouts, CompleteGames, 0, 0, 0, 0, HitByPitch, Single, Double, Triple, HomeRun, Runs, DoublePlay, TGP);
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
                        int NumberInLineup = (int)reader["PlayerPositionInLineup"];
                        string Position = (string)reader["PlayerPosition"];
                        yield return new PlayerInLineup(id, FirstName, SecondName, dob, Place, number, Lineup, Team, Position, NumberInLineup);
                    }
                }
            }
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
                        yield return new PlayerInLineup(id, FirstName, SecondName, dob, Place, number, Lineup, Team, NumberInLineup);
                    }
                }
            }
        }
    }
}