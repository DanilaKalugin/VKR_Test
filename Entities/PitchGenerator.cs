using System;
using System.Linq;

namespace Entities
{
    public abstract class PitchGenerator
    {
        public abstract Pitch CreatePitch(GameSituation situation, Match match);

        protected static Random initializeRandomGenerator = new Random(DateTime.Now.Second);

        public PitchResult NewPitchResult;
    }
}