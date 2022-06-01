using System;

namespace VKR.Entities.NET5.RandomGenerators
{
    public abstract class PitchGenerator
    {
        public abstract Pitch CreatePitch(GameSituation situation, Match match);

        protected static Random InitializeRandomGenerator = new(DateTime.Now.Second);

        public PitchResult NewPitchResult;
    }
}