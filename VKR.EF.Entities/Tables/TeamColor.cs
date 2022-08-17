using System.Drawing;

namespace VKR.EF.Entities
{
    public class TeamColor
    {
        public Team Team { get; set; }
        public string TeamName { get; set; }
        public byte ColorNumber { get; set; }
        public byte RedComponent { get; set; }
        public byte GreenComponent { get; set; }
        public byte BlueComponent { get; set; }
        public Color Color => Color.FromArgb(RedComponent, GreenComponent, BlueComponent);
    }
}
