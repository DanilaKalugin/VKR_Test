namespace Entities
{
    public class PlayerPosition
    {
        public string ShortTitle { get; }
        public string FullTitle { get; }

        public PlayerPosition(string shortTitle, string fullTitle)
        {
            ShortTitle = shortTitle;
            FullTitle = fullTitle;
        }
    }
}