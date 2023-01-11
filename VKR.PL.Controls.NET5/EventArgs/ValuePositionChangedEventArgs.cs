using System;

namespace VKR.PL.Controls.NET5.EventArgs
{
    public class ValuePositionChangedEventArgs : System.EventArgs
    {
        public ushort Position { get; set; }

        public ValuePositionChangedEventArgs(ushort position) => Position = position;
    }
}