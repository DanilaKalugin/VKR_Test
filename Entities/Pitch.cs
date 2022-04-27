using System;
using System.Linq;

namespace Entities
{
    public class Pitch
    {
        public PitchResult NewPitchResult;

        public Pitch(PitchResult pitchResult)
        {
            NewPitchResult = pitchResult;
        }
    }
}