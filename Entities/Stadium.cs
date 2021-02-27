namespace Entities
{
    public class Stadium
    {
        public int stadiumId;
        public string StadiumTitle;
        public string stadiumLocation;
        public int stadiumCapacity;
        public int stadiumDistanceToCenterfield;

        public Stadium(int _id, string _title, string _Location, int _Capacity, int _distanceToCenterField)
        {
            stadiumId = _id;
            StadiumTitle = _title;
            stadiumLocation = _Location;
            stadiumCapacity = _Capacity;
            stadiumDistanceToCenterfield = _distanceToCenterField;
        }
    }
}