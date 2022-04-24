using System.Collections.Generic;
using System.Data.SqlClient;
using Entities;

namespace VKR.DAL
{
    public class StadiumsDAO : DAO
    {
        public StadiumsDAO() : base() { }

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