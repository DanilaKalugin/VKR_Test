namespace Entities
{
    public class PlayerPosition
    {
        public string ShortTitle { get; private set; }
        public string FullTitle { get; private set; }
        public PlayerPosition(string shortTitle, string fullTitle)
        {
            ShortTitle = shortTitle;
            FullTitle = fullTitle;
        }
    }
}