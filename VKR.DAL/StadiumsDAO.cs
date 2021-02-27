using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace VKR.DAL
{
    public class StadiumsDAO : IDisposable
    {
        private SqlConnection _connection;

        public static string GetConnectionString()
        {
            var currentConnection = ConfigurationManager.AppSettings["CurrentConnectionString"];
            var connectionString = ConfigurationManager.ConnectionStrings[currentConnection].ConnectionString;
            return connectionString;
        }

        public StadiumsDAO()
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

        public IEnumerable<Stadium> GetAllStadiums()
        {
            using (SqlCommand command = new SqlCommand("GetAllStadiums", _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ID = (int)reader["StadiumID"];
                        string Title = (string)reader["StadiumTitle"];
                        string Location = (string)reader["Location"];
                        int Capacity = (int)reader["StadiumCapacity"];
                        int DistanceToCF = (int)reader["StadiumDistanceToCenterField"];
                        yield return new Stadium(ID, Title, Location, Capacity, DistanceToCF);
                    }
                }
            }
        }
    }
}