using System;

namespace Entities
{
    public class Manager: Man
    {
        public Manager(int id, string  firstName, string secondName, string placeOfBirth, DateTime dateOfBirth)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            PlaceOfBirth = placeOfBirth;
            DateOfBirth = dateOfBirth;
        }
    }
}