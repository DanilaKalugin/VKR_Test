using System;

namespace Entities
{
    public class Manager: Man
    {
        public Manager(int _id, string  _FirstName, string _SecondName, string _PlaceOfBirth, DateTime _DateOfBirth)
        {
            id = _id;
            FirstName = _FirstName;
            SecondName = _SecondName;
            PlaceOfBirth = _PlaceOfBirth;
            DateOfBirth = _DateOfBirth;
        }
    }
}