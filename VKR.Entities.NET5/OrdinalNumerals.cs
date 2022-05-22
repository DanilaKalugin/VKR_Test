﻿namespace Entities.NET5
{
    public class OrdinalNumerals
    {
        public static string GetOrdinalNumeralFromQuantitive(int number)
        {
            return (number % 10) switch
            {
                1 when number % 100 != 11 => $"{number}st",
                2 when number % 100 != 12 => $"{number}nd",
                3 when number % 100 != 13 => $"{number}rd",
                _ => $"{number}th"
            };
        }
    }
}