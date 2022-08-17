namespace VKR.EF.Entities
{
    public class Pitch
    {
        public Enums.PitchResult NewPitchResult;

        public Pitch(Enums.PitchResult pitchResult) => NewPitchResult = pitchResult;
    }
}