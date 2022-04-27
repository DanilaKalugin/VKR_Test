namespace Entities
{
    public class OrdinalNumerals
    {
        public static string GetOrdinalNumeralFromQuantitive(int number)
        {
            switch (number % 10)
            {
                case 1 when number % 100 != 11:
                    return $"{number}st";
                case 2 when number % 100 != 12:
                    return $"{number}nd";
                case 3 when number % 100 != 13:
                    return $"{number}rd";
                default:
                    return $"{number}th";
            }
        }
    }
}