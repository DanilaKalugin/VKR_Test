using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entities.NET5;

namespace VKR.DAL.NET5
{
    public class ManDAO : DAO
    {
        public IEnumerable<ManInTeam> GetListOfPeopleWithBirthdayToday()
        {
            using var command = new SqlCommand("GetListOfPeopleWithBirthdayToday", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Prepare();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var playerId = (int)reader["PlayerID"];
                var teamId = (string)reader["TeamID"];
                var firstName = (string)reader["PlayerFirstName"];
                var secondName = (string)reader["PlayerSecondName"];
                var date = (DateTime)reader["PlayerDateOfBirth"];
                var placeOfBirth = (string)reader["PlaceOfBirth"];

                yield return new ManInTeam(playerId, firstName, secondName, teamId, date, placeOfBirth);
            }
        }
    }
}