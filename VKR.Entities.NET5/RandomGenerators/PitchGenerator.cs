using System;

namespace Entities.NET5
{
    public abstract class PitchGenerator
    {
        public abstract Pitch CreatePitch(GameSituation situation, Match match);

        protected static Random InitializeRandomGenerator = new Random(DateTime.Now.Second);

        public PitchResult NewPitchResult;
    }
}