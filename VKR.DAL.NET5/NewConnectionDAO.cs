using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace VKR.DAL.NET5
{
    public class NewConnectionDAO
    {
        public void DeployDataBase(string connectionTitle, string serverName, bool integratedSecurity, out int result, out string message, string userName = "", string userPassword = "")
        {
            var newConnection = $"Data Source={serverName};" +
                                "Initial Catalog=master;" +
                                $"Integrated Security={integratedSecurity};";
            
            if (!integratedSecurity) newConnection += $"User ID={userName};Password={userPassword}";
            
            try
            {
                using (var connection = new SqlConnection(newConnection))
                {
                    connection.Open();
                    using (var command = new SqlCommand("CREATE DATABASE [VKRnew]", connection))
                        command.ExecuteNonQuery();
                    connection.Close();
                }

                var dbConnection = $"Data Source={serverName};" +
                                   "Initial Catalog=VKRnew;" +
                                   $"Integrated Security={integratedSecurity};";

                if (!integratedSecurity) dbConnection += $"User ID={userName};Password={userPassword}";

                var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(connectionTitle, dbConnection));
                configuration.Save();

                ConfigurationManager.RefreshSection("ConnectionStrings");
                configuration.AppSettings.Settings["CurrentConnectionString"].Value = connectionTitle;
                configuration.Save();

                ConfigurationManager.RefreshSection("AppSettings");
                DeployScript(dbConnection);
                result = 0;
                message = "The database deployment was successful";
            }
            catch (SqlException ex)
            {
                message = ex.Message;
                result = 1;
            }
        }

        private static void DeployScript(string dbConnection)
        {
            var scripts = Directory.GetFiles(@"Scripts\").OrderBy(str => str).ToList();
            using var conn = new SqlConnection(dbConnection);
            conn.Open();

            foreach (var script in scripts.Select(File.ReadAllText))
                using (var command = new SqlCommand(script, conn))
                    command.ExecuteNonQuery();

            conn.Close();
        }
    }
}