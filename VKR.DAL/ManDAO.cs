using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace VKR.DAL
{
    public class ManDAO : IDisposable
    {
        private SqlConnection _connection;

        public static string GetConnectionString()
        {
            var currentConnection = ConfigurationManager.AppSettings["CurrentConnectionString"];
            var connectionString = ConfigurationManager.ConnectionStrings[currentConnection].ConnectionString;
            return connectionString;
        }

        public ManDAO()
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

        public IEnumerable<ManInTeam> GetListOfPeopleWithBirthdayToday()
        {
            using (SqlCommand command = new SqlCommand("GetListOfPeopleWithBirthdayToday", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Prepare();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int PlayerID = (int)reader["PlayerID"];
                        string TeamID = (string)reader["TeamID"];
                        string FirstName = (string)reader["PlayerFirstName"];
                        string SecondName = (string)reader["PlayerSecondName"];
                        DateTime date = (DateTime)reader["PlayerDateOfBirth"];

                        yield return new ManInTeam(PlayerID, FirstName, SecondName, TeamID, date);
                    }
                }
            }
        }
    }
}