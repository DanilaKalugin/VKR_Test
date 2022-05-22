using System.Collections.Generic;
using System.Data.SqlClient;
using Entities.NET5;

namespace VKR.DAL.NET5
{
    public class StadiumsDAO : DAO
    {
        public IEnumerable<Stadium> GetAllStadiums()
        {
            using var command = new SqlCommand("GetAllStadiums", _connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var ID = (int)reader["StadiumID"];
                var Title = (string)reader["StadiumTitle"];
                var Location = (string)reader["Location"];
                var Capacity = (int)reader["StadiumCapacity"];
                var DistanceToCF = (int)reader["StadiumDistanceToCenterField"];
                yield return new Stadium(ID, Title, Location, Capacity, DistanceToCF);
            }
        }
    }
}