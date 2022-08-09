namespace VKR.EF.Entities
{
    public class Runner
    {
        public uint RunnerId;
        public string RunnerPosition;
        public uint PitcherId;
        public bool IsBaseNotEmpty;
        public bool IsBaseStealingAttempt;

        public Runner()
        {
            RunnerId = 0;
            RunnerPosition = "";
            PitcherId = 0;
            IsBaseNotEmpty = false;
        }

        public Runner(Runner runnerOnFirst)
        {
            if (runnerOnFirst.IsBaseNotEmpty)
            {
                RunnerId = runnerOnFirst.RunnerId;
                RunnerPosition = runnerOnFirst.RunnerPosition;
                PitcherId = runnerOnFirst.PitcherId;
                IsBaseNotEmpty = true;
            }
            else
            {
                RunnerId = 0;
                RunnerPosition = "";
                PitcherId = 0;
                IsBaseNotEmpty = false;
            }
            IsBaseStealingAttempt = false;
        }

        public Runner(Batter batter, Pitcher pitcher)
        {
            RunnerId = batter.Id;
            RunnerPosition = batter.PositionForThisMatch;
            PitcherId = pitcher.Id;
            IsBaseNotEmpty = true;
        }
    }
}