using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VKR.EF.Entities
{
    public abstract class Man
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public City City { get; set; }
        public short PlaceOfBirth { get; set; }
        public string FullName => $"{FirstName} {SecondName}";
        public byte Age
        {
            get
            {
                var now = DateTime.Today;
                var age = now.Year - DateOfBirth.Year;
                if (DateOfBirth > now.AddYears(-age)) age--;
                return (byte)age;
            }
        }
    }
}