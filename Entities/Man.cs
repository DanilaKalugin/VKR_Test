using System;

namespace Entities
{
    abstract public class Man
    {
        public int Id;
        public string FirstName;
        public string SecondName;
        public DateTime DateOfBirth;
        public string PlaceOfBirth;

        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName;
            }
        }
    }
}