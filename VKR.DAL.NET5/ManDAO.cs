using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace VKR.DAL
{
    public class ManDAO : DAO
    {
        public IEnumerable<ManInTeam> GetListOfPeopleWithBirthdayToday()
        {
            using (var command = new SqlCommand("GetListOfPeopleWithBirthdayToday", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Prepare();

                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        var PlayerID = (int)reader["PlayerID"];
                        var TeamID = (string)reader["TeamID"];
                        var FirstName = (string)reader["PlayerFirstName"];
                        var SecondName = (string)reader["PlayerSecondName"];
                        var date = (DateTime)reader["PlayerDateOfBirth"];
                        var placeOfBirth = (string)reader["PlaceOfBirth"];

                        yield return new ManInTeam(PlayerID, FirstName, SecondName, TeamID, date, placeOfBirth);
                    }
            }
        }
    }
}