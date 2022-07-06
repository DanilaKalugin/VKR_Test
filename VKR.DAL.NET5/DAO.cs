using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace VKR.DAL.NET5
{
    public class DAO : IDisposable
    {
        protected SqlConnection _connection;

        public static string GetConnectionString()
        {
            var currentConnection = ConfigurationManager.AppSettings["CurrentConnectionStringADO"];
            var connectionString = ConfigurationManager.ConnectionStrings[currentConnection].ConnectionString;
            return connectionString;
        }

        public DAO() => InitConnection();

        protected void InitConnection()
        {
            _connection = new SqlConnection(GetConnectionString());
            _connection.Open();
            _connection.StateChange += ConnectionStateChange;
        }

        public void ConnectionStateChange(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState == ConnectionState.Broken) InitConnection();
        }

        public void Dispose() => _connection?.Dispose();
    }
}