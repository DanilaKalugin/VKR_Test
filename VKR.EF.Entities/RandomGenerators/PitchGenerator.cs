using System;
using VKR.EF.Entities.Enums;

namespace VKR.EF.Entities.RandomGenerators
{
    public abstract class PitchGenerator
    {
        public abstract Pitch CreatePitch(GameSituation situation, Match match);

        protected static Random InitializeRandomGenerator = new(DateTime.Now.Second);

        public PitchResult NewPitchResult;
    }
}