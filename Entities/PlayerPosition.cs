namespace Entities
{
    public class PlayerPosition
    {
        public string ShortTitle { get; private set; }
        public string FullTitle { get; private set; }
        public PlayerPosition(string _short, string full)
        {
            ShortTitle = _short;
            FullTitle = full;
        }
    }
}