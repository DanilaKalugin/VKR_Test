using System;

namespace VKR.PL.Controls.NET5
{
    public class ValuePositionChangedEventArgs: EventArgs
    {
        public ushort Position { get; set; }

        public ValuePositionChangedEventArgs(ushort _position) => Position = _position;
    }
}