using System;

namespace Entities.NET5
{
    public abstract class Man
    {
        public int Id;
        public string FirstName;
        public string SecondName;
        public DateTime DateOfBirth;
        public string PlaceOfBirth;

        public string FullName => $"{FirstName} {SecondName}";
    }
}