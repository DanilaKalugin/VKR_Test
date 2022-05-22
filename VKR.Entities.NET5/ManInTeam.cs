using System;

namespace Entities.NET5
{
    public class ManInTeam : Man
    {
        public string Team;
        public int Age
        {
            get
            {
                var now = DateTime.Today;
                var age = now.Year - DateOfBirth.Year;
                if (DateOfBirth > now.AddYears(-age)) age--;
                return age;
            }
        }

        public ManInTeam(int id, string firstName, string secondName, string team, DateTime date, string placeOfBirth)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            Team = team;
            DateOfBirth = date;
            PlaceOfBirth = placeOfBirth;
        }

        public ManInTeam() { }
    }
}