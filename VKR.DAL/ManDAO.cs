using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace VKR.DAL
{
    public class ManDAO : DAO
    {
        public ManDAO() :base() { }

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
                        string placeOfBirth = (string)reader["PlaceOfBirth"];

                        yield return new ManInTeam(PlayerID, FirstName, SecondName, TeamID, date, placeOfBirth);
                    }
                }
            }
        }
    }
}