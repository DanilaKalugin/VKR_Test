namespace Entities.NET5
{
    public class Stadium
    {
        public int StadiumId;
        public string StadiumTitle;
        public string StadiumLocation;
        public int StadiumCapacity;
        public int StadiumDistanceToCenterfield;

        public Stadium(int id, string title, string location, int capacity, int distanceToCenterField)
        {
            StadiumId = id;
            StadiumTitle = title;
            StadiumLocation = location;
            StadiumCapacity = capacity;
            StadiumDistanceToCenterfield = distanceToCenterField;
        }
    }
}