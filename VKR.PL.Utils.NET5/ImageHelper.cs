using System.Drawing;
using System.IO;

namespace VKR.PL.Utils.NET5
{
    public class ImageHelper
    {
        public static Image ShowImageIfExists(string path) => File.Exists(path) ? Image.FromFile(path) : null;
    }
}