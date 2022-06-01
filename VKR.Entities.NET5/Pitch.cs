namespace VKR.Entities.NET5
{
    public class Pitch
    {
        public PitchResult NewPitchResult;

        public Pitch(PitchResult pitchResult) => NewPitchResult = pitchResult;
    }
}