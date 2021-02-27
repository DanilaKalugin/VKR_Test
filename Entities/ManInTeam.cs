using System;

namespace Entities
{
    public class ManInTeam : Man
    {
        public string Team;
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }
        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName;
            }
        }

        public ManInTeam(int _id, string _FirstName, string _SecondName, string _Team, DateTime date)
        {
            id = _id;
            FirstName = _FirstName;
            SecondName = _SecondName;
            Team = _Team;
            DateOfBirth = date;
        }
    }
}